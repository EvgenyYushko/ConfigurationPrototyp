using System.Collections.Generic;
using ConfigurationModules.DomainLayer.Models.Base;

namespace ConfigurationModules.DomainLayer.Repositories
{
    public interface IConfigurationRepository
    {
        ApplicationConfigSettings GetDefaultApplicationSettings();

        ApplicationConfigSettings GetProfile(string profileName);

        List<ApplicationConfigSettings> GetProfiles();

        void AddProfile(ApplicationConfigSettings newProfile);

        void DeleteProfile(string newProfile);

        void Save();
    }
}
