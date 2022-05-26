using System.Collections.Generic;
using ConfigurationModules.ServiceLayer.Models;

namespace ConfigurationModules.ServiceLayer.Services
{
    public interface IConfigurationService
    {
        ConfigSettingsDto GetSettings(string profileName);

        void SaveProfiles(List<ConfigSettingsDto> configSettings);

        List<ConfigSettingsDto> GetProfiles();

        void DeleteProfile(ConfigSettingsDto config);
    }
}
