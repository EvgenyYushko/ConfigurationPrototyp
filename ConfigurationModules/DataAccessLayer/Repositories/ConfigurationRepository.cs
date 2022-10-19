using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ConfigurationModules.DomainLayer.Models.Base;
using ConfigurationModules.DomainLayer.Models.Profiles;
using ConfigurationModules.DomainLayer.Repositories;

namespace ConfigurationModules.DataAccessLayer.Repositories
{
    /// <inheritdoc cref="IConfigurationRepository"/>
    public class ConfigurationRepository : IConfigurationRepository
    {
        private const string APP_DATA = "AppData";
        private const string CONFIG_FOLDER_NAME = "PrototypeConfigs v2.0";
        private const string CONFIG_FILE_NAME = "ProfilesSettings.config";

        private readonly string _configFilePath;
        private Configuration _config;

        public ConfigurationRepository(string customConfigFilePath = null)
        {
            _configFilePath = customConfigFilePath ?? Path.Combine(Environment.GetEnvironmentVariable(APP_DATA), CONFIG_FOLDER_NAME, CONFIG_FILE_NAME);
        }

        private Configuration Configurations => _config ??= InitConfig();

        private Configuration InitConfig()
        {
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = _configFilePath };
            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }

        /// <inheritdoc />
        public Config GetDefaultApplicationSettings() => new();

        /// <inheritdoc />
        public Profile GetProfile(string profileName)
        {
            return (Profile)GetProfilesSettings().Get(profileName);
        }

        /// <inheritdoc />
        public List<Profile> GetProfiles()
        {
            return GetProfilesSettings().OfType<Profile>().ToList();
        }

        /// <inheritdoc />
        public void AddProfile(Profile newProfile)
        {
            GetProfilesSettings().Add(newProfile);
        }

        /// <inheritdoc />
        public void DeleteProfile(string newProfile)
        {
            GetProfilesSettings().Delete(newProfile);
        }

        private Profiles GetProfilesSettings()
        {
            var profilesSection = (ProfilesSection)GetSection(nameof(ProfilesSection));
            return profilesSection.Profiles;
        }

        private ConfigurationSection GetSection(string sectionName) => Configurations.Sections[sectionName];

        /// <inheritdoc />
        public void Save()
        {
            Configurations.Save(ConfigurationSaveMode.Modified);
            _config = null;
        }
    }
}
