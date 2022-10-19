using System.Configuration;

namespace ConfigurationModules.DomainLayer.Models.Profiles
{
    public class ProfilesSection : ConfigurationSection
    {
        [ConfigurationProperty(nameof(Profiles))]
        public Profiles Profiles => (Profiles)base[nameof(Profiles)];
    }
}
