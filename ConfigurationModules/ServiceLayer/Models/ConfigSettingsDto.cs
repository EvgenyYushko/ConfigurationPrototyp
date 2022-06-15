using ConfigurationModules.ServiceLayer.Models.Base;

namespace ConfigurationModules.ServiceLayer.Models
{
    public class ConfigSettingsDto 
    {
        public string ProfileName { get; set; }

        public ConfigBaseDto Config { get; set; }
    }
}
