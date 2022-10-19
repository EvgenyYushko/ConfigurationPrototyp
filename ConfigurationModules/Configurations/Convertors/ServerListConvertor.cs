using System.Collections.Specialized;
using System.ComponentModel;

namespace ConfigurationModules.Configurations.Convertors
{
    public class ServerListConvertor : StringConverter
    {
        static StringCollection _vList = null;

        public override bool GetStandardValuesSupported(
            ITypeDescriptorContext context)
        {
            return true;
        }
        
        public override bool GetStandardValuesExclusive(
            ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(
            ITypeDescriptorContext context)
        {
            _vList = new StringCollection();
            _vList.AddRange(new []
            {
                "itsrvdb16\\alfa2014", 
                "itsrvkdo", 
                "itsrvkdo / alfa2016"
            });
            return new StandardValuesCollection(_vList);
        }
    }
}
