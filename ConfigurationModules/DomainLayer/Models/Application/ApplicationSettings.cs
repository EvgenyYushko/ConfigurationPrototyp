using System.Configuration;
using ConfigurationModules.DomainLayer.Models.Base;

namespace ConfigurationModules.DomainLayer.Models.Application
{
    public class ApplicationSettings : ConfigurationSection
    {
        [ConfigurationProperty(nameof(Settings))]
        public ApplicationConfigSettings Settings
        {
            get => (ApplicationConfigSettings)this[nameof(Settings)];
            set => this[nameof(Settings)] = value;
        }
    }
}
