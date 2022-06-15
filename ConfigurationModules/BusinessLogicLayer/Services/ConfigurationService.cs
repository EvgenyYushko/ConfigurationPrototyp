using System.Collections.Generic;
using AutoMapper;
using ConfigurationModules.DomainLayer.Models.Base;
using ConfigurationModules.DomainLayer.Repositories;
using ConfigurationModules.ServiceLayer.Models;
using ConfigurationModules.ServiceLayer.Services;

namespace ConfigurationModules.BusinessLogicLayer.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private const string DEFAULT_PROFILE_NAME = "Default";
        private const string DEFAULT_FIRST_PROFILE_NAME = "Profile1";

        private readonly IConfigurationRepository _repository;
        private readonly IMapper _mapper;

        public ConfigurationService(IConfigurationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ConfigSettingsDto GetSettings(string profileName)
        {
            var settings = GetDefaultApplicationSettings();
            if (profileName.Equals(DEFAULT_PROFILE_NAME))
            {
                settings.ProfileName = DEFAULT_FIRST_PROFILE_NAME;
            }
            else
            {
                var profile = _repository.GetProfile(profileName);
                if (profile != null)
                {
                    _mapper.Map(profile, settings);
                }
                else
                {
                    settings.ProfileName = profileName;
                }
            }

            return settings;
        }

        private ConfigSettingsDto GetDefaultApplicationSettings()
        {
            return _mapper.Map<ConfigSettingsDto>(_repository.GetDefaultApplicationSettings());
        }

        public List<ConfigSettingsDto> GetProfiles()
        {
            return _mapper.Map<List<ConfigSettingsDto>>(_repository.GetProfiles());
        }

        public void SaveProfiles(List<ConfigSettingsDto> configs)
        {
            if (configs.Count == 0)
            {
                return;
            }

            foreach (var config in configs)
            {
                var foundProfile = _repository.GetProfile(config.ProfileName);
                if (foundProfile != null)
                {
                    UpdateProfile(config, foundProfile);
                }
                else
                {
                    AddProfile(config);
                }
            }

            _repository.Save();
        }

        private void AddProfile(ConfigSettingsDto config)
        {
            var newProfile = _mapper.Map<ApplicationConfigSettings>(config);
            _repository.AddProfile(newProfile);
        }

        private void UpdateProfile(ConfigSettingsDto config, ApplicationConfigSettings foundProfile)
        {
            _mapper.Map(config, foundProfile);
        }

        public void DeleteProfile(ConfigSettingsDto config)
        {
            if (_repository.GetProfile(config.ProfileName) != null)
            {
                _repository.DeleteProfile(config.ProfileName);
                _repository.Save();
            }
        }
    }
}
