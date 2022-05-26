using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ConfigurationModules.DomainLayer.Models.Application;
using ConfigurationModules.DomainLayer.Models.Base;
using ConfigurationModules.DomainLayer.Models.Profiles;
using ConfigurationModules.DomainLayer.Repositories;

namespace ConfigurationModules.DataAccessLayer.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private Configuration _context = null;

        public ConfigurationRepository()
        {
            SetContext();
        }

        private void SetContext()
        {
            _context = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public ApplicationConfigSettings GetDefaultApplicationSettings()
        {
            var configSettings = (ApplicationSettings)ConfigurationManager.GetSection(nameof(ApplicationSettings));
            return configSettings.Settings;
        }

        public ApplicationConfigSettings GetProfile(string profileName)
        {
            var profilesSettings = (ProfilesSettings)_context.Sections[nameof(ProfilesSettings)];
            return (ApplicationConfigSettings)profilesSettings.Profiles.Get(profileName);
        }

        public List<ApplicationConfigSettings> GetProfiles()
        {
            var profileSettings = (ProfilesSettings)ConfigurationManager.GetSection(nameof(ProfilesSettings));
            return profileSettings.Profiles.OfType<ApplicationConfigSettings>().ToList();
        }

        public void AddProfile(ApplicationConfigSettings newProfile)
        {
            var profilesSettings = (ProfilesSettings)_context.Sections[nameof(ProfilesSettings)];
            profilesSettings.Profiles.Add(newProfile);
        }

        public void DeleteProfile(string newProfile)
        {
            SetContext();
            var profilesSettings = (ProfilesSettings)_context.Sections[nameof(ProfilesSettings)];
            profilesSettings.Profiles.Delete(newProfile);
        }

        public void Save()
        {
            _context.Save(ConfigurationSaveMode.Modified);
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
