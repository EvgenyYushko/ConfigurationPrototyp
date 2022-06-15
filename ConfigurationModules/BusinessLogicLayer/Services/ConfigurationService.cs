using System.Collections.Generic;
using AutoMapper;
using ConfigurationModules.DomainLayer.Repositories;
using ConfigurationModules.ServiceLayer.Models;
using ConfigurationModules.ServiceLayer.Services;
using Profile = ConfigurationModules.DomainLayer.Models.Profiles.Profile;

namespace ConfigurationModules.BusinessLogicLayer.Services
{
    /// <inheritdoc cref="IConfigurationService"/>
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

        /// <inheritdoc />
        public ConfigSettingsDto GetApplicationSetting(string profileName)
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

        private ConfigSettingsDto GetDefaultApplicationSettings() =>
             _mapper.Map<ConfigSettingsDto>(_repository.GetDefaultApplicationSettings());

        /// <inheritdoc />
        public List<ConfigSettingsDto> GetProfiles() =>
             _mapper.Map<List<ConfigSettingsDto>>(_repository.GetProfiles());

        /// <inheritdoc />
        public void SaveProfiles(List<ConfigSettingsDto> profiles)
        {
            if (profiles.Count == 0)
            {
                return;
            }

            foreach (var profile in profiles)
            {
                var foundProfile = _repository.GetProfile(profile.ProfileName);
                if (foundProfile != null)
                {
                    UpdateProfile(profile, foundProfile);
                }
                else
                {
                    AddProfile(profile);
                }
            }

            _repository.Save();
        }

        private void AddProfile(ConfigSettingsDto config)
        {
            var newProfile = _mapper.Map<Profile>(config);
            _repository.AddProfile(newProfile);
        }

        private void UpdateProfile(ConfigSettingsDto config, Profile foundProfile) =>
            _mapper.Map(config, foundProfile);

        /// <inheritdoc />
        public void DeleteProfile(ConfigSettingsDto profile)
        {
            if (_repository.GetProfile(profile.ProfileName) != null)
            {
                _repository.DeleteProfile(profile.ProfileName);
                _repository.Save();
            }
        }
    }
}
