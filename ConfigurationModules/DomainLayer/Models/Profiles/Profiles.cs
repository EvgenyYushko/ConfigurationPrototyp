using System.Configuration;
using ConfigurationModules.DomainLayer.Models.Base;

namespace ConfigurationModules.DomainLayer.Models.Profiles
{
    [ConfigurationCollection(typeof(ApplicationSettingsBase), AddItemName = "Profile")]
    public class Profiles : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ApplicationConfigSettings();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ApplicationConfigSettings)(element)).ProfileName;
        }

        public ApplicationConfigSettings this[int idx] => (ApplicationConfigSettings)BaseGet(idx);

        public void Clear()
        {
            BaseClear();
        }

        public void Add(ConfigurationElement element)
        {
            BaseAdd(element);
        }

        public void Delete(string element)
        {
            BaseRemove(element);
        }

        public ConfigurationElement Get(string elementName) => BaseGet(elementName);
    }
}
