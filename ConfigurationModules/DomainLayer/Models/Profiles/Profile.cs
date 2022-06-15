using System.Configuration;
using ConfigurationModules.DomainLayer.Models.Base;

namespace ConfigurationModules.DomainLayer.Models.Profiles
{
    public class Profile : ConfigurationElement
    {
        [ConfigurationProperty(nameof(ProfileName), DefaultValue = "Default", IsKey = true, IsRequired = true)]
        public string ProfileName
        {
            get => ((string) (base[nameof(ProfileName)]));
            set
            {
                if (!((string) base[nameof(ProfileName)]).Equals(value))
                {
                    base[nameof(ProfileName)] = value;
                }
                
            }
        }

        [ConfigurationProperty(nameof(Config))]
        public Config Config
        {
            get => (Config) base[nameof(Config)];
            set
            {
                if (base[nameof(Config)] != value)
                {
                    this[nameof(Config)] = value;
                }
            }
        }
    }
}
