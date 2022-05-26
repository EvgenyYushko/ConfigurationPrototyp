using System.Configuration;

namespace ConfigurationModules.DomainLayer.Models.Profiles
{
    public class ProfilesSettings : ConfigurationSection
    {
        [ConfigurationProperty(nameof(Profiles))]
        public Profiles Profiles => (Profiles)base[nameof(Profiles)];
    }
}
