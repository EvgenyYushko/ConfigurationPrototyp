using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ConfigurationModules.DomainLayer.Models.Application;
using ConfigurationModules.DomainLayer.Models.Base;
using ConfigurationModules.DomainLayer.Models.Profiles;
using ConfigurationModules.DomainLayer.Repositories;

namespace ConfigurationModules.DataAccessLayer.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private const string APP_DATA = "AppData";
        private const string CONFIG_FOLDER_NAME = "PrototypeConfigs";
        private const string CONFIG_FILE_NAME = "App.config";

        private readonly string _configFilePath;
        private Configuration _config;

        public ConfigurationRepository()
        {
            _configFilePath = Path.Combine(Environment.GetEnvironmentVariable(APP_DATA), CONFIG_FOLDER_NAME, CONFIG_FILE_NAME);
        }

        private Configuration Configuration => _config ??= InitConfig();

        private Configuration InitConfig()
        {
            var fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = _configFilePath
            };

            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None); 
        }

        public Config GetDefaultApplicationSettings()
        {
            var configSettings = (ApplicationSettings)GetSection(nameof(ApplicationSettings));
            return configSettings.Settings;
        }

        public ApplicationConfigSettings GetProfile(string profileName)
        {
            var profilesSettings = GetProfilesSettings();
            return (ApplicationConfigSettings)profilesSettings.Get(profileName);
        }

        public List<ApplicationConfigSettings> GetProfiles()
        {
            var profilesSettings = GetProfilesSettings();
            return profilesSettings.OfType<ApplicationConfigSettings>().ToList();
        }

        public void AddProfile(ApplicationConfigSettings newProfile)
        {
            var profilesSettings = GetProfilesSettings();
            profilesSettings.Add(newProfile);
        }

        public void DeleteProfile(string newProfile)
        {
            var profilesSettings = GetProfilesSettings();
            profilesSettings.Delete(newProfile);
        }

        private Profiles GetProfilesSettings()
        {
            var profilesSection = (ProfilesSettings)GetSection(nameof(ProfilesSettings));
            return profilesSection.Profiles;
        }

        private ConfigurationSection GetSection(string sectionName) => Configuration.Sections[sectionName];

        public void Save()
        {
            Configuration.Save(ConfigurationSaveMode.Modified);
            _config = null;
        }

        #region Test
        //public List<ApplicationConfigSettings> GetProfilesSettings()
        //{
        //    var profileSettings = (ProfilesSettings)ConfigurationManager.GetSection(nameof(ProfilesSettings));
        //    return profileSettings.Profiles.OfType<ApplicationConfigSettings>().ToList();
        //}

        //public void SaveActiveProfileName(string activeProfileName)
        //{
        //    Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    ApplicationSettings configSettings = (ApplicationSettings)cfg.Sections[nameof(ApplicationSettings)];
        //    if (configSettings != null)
        //    {
        //        configSettings.Settings.ActiveProfileName = activeProfileName;
        //        cfg.Save(ConfigurationSaveMode.Full);
        //    }
        //}

        //Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //ProfilesSettings profilesSettings = (ProfilesSettings)cfg.Sections[nameof(ProfilesSettings)];
        //profilesSettings.Profiles.Clear();
        //profilesSettings.Profiles.Add(profileSettings);
        #endregion
    }
}
