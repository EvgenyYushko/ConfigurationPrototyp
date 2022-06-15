using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ConfigurationModules.DomainLayer.Models.Base;
using ConfigurationModules.DomainLayer.Models.Profiles;
using ConfigurationModules.DomainLayer.Repositories;

namespace ConfigurationModules.DataAccessLayer.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private const string APP_DATA = "AppData";
        private const string CONFIG_FOLDER_NAME = "PrototypeConfigs v2.0";
        private const string CONFIG_FILE_NAME = "ProfilesSettings.config";

        private readonly string _configFilePath;
        private Configuration _config;

        public ConfigurationRepository()
        {
            _configFilePath = Path.Combine(Environment.GetEnvironmentVariable(APP_DATA), CONFIG_FOLDER_NAME, CONFIG_FILE_NAME);
        }

        private Configuration Configurations => _config ??= InitConfig();

        private Configuration InitConfig()
        {
            var fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = _configFilePath
            };

            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None); 
        }
        
        public Config GetDefaultApplicationSettings() => new();

        public ApplicationConfigSettings GetProfile(string profileName)
        {
            return (ApplicationConfigSettings)GetProfilesSettings().Get(profileName);
        }

        public List<ApplicationConfigSettings> GetProfiles()
        {
           return GetProfilesSettings().OfType<ApplicationConfigSettings>().ToList();
        }

        public void AddProfile(ApplicationConfigSettings newProfile)
        {
            GetProfilesSettings().Add(newProfile);
        }

        public void DeleteProfile(string newProfile)
        {
            GetProfilesSettings().Delete(newProfile);
        }

        private Profiles GetProfilesSettings()
        {
            var profilesSection = (ProfilesSettings)GetSection(nameof(ProfilesSettings));
            return profilesSection.Profiles;
        }

        private ConfigurationSection GetSection(string sectionName) => Configurations.Sections[sectionName];

        public void Save()
        {
            Configurations.Save(ConfigurationSaveMode.Modified);
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
