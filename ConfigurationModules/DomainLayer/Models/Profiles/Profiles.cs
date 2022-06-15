using System.Configuration;

namespace ConfigurationModules.DomainLayer.Models.Profiles
{
    [ConfigurationCollection(typeof(ApplicationSettingsBase), AddItemName = "Profile")]
    public class Profiles : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Profile();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Profile)(element)).ProfileName;
        }

        public Profile this[int idx] => (Profile)BaseGet(idx);

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
