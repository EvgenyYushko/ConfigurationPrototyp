using System.Collections.Specialized;
using System.ComponentModel;

namespace ConfigurationModules.Configurations.Convertors
{
    public class DataBaseListConvertor : StringConverter
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
            _vList.AddRange(new[]
            {
                "Dev",
                "Test",
                "Demo"
            });
            return new StandardValuesCollection(_vList);
        }
    }
}
