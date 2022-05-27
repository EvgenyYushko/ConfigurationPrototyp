using System.Configuration;

namespace ConfigurationModules.DomainLayer.Models.Base
{
    public class ApplicationConfigSettings : ConfigurationElement
    {
        [ConfigurationProperty(nameof(ProfileName), DefaultValue = "Default", IsKey = true, IsRequired = true)]
        //[StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
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
            set => this[nameof(Config)] = value;
        }
    }
}
