using System.ComponentModel;
using ConfigurationModules.ServiceLayer.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace ConfigurationModules.ServiceLayer.Models
{
    public class ConfigSettingsDto //: ICustomTypeDescriptor
    {
        [Category("Профиль")]
        [DisplayName("Имя профиля")]
        public string ProfileName { get; set; }

        [Display(Order = 1)]
        [Category("Профиль")]
        [Description("Настройки текущего профиля")]
        [DisplayName("Настройки")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ConfigBaseDto Config { get; set; }

        #region Test

        //private readonly string _filter = string.Empty;
        //private readonly PropertyDescriptorCollection _filteredPropertyDescriptors = new(null);
        //private readonly PropertyDescriptorCollection _fullPropertyDescriptors = new(null);

        //public AttributeCollection GetAttributes()
        //{
        //    return TypeDescriptor.GetAttributes(this, true);
        //}

        //public string GetClassName()
        //{
        //    return TypeDescriptor.GetClassName(this, true);
        //}

        //public string GetComponentName()
        //{
        //    return TypeDescriptor.GetComponentName(this, true);
        //}

        //public TypeConverter GetConverter()
        //{
        //    return TypeDescriptor.GetConverter(this, true);
        //}

        //public EventDescriptor GetDefaultEvent()
        //{
        //    return TypeDescriptor.GetDefaultEvent(this, true);
        //}

        //public PropertyDescriptor GetDefaultProperty()
        //{
        //    return TypeDescriptor.GetDefaultProperty(this, true);
        //}

        //public object GetEditor(Type editorBaseType)
        //{
        //    return TypeDescriptor.GetEditor(this, editorBaseType, true);
        //}

        //public EventDescriptorCollection GetEvents()
        //{
        //    return TypeDescriptor.GetEvents(this, true);
        //}

        //public EventDescriptorCollection GetEvents(Attribute[] attributes)
        //{
        //    return TypeDescriptor.GetEvents(this, attributes, true);
        //}

        //public PropertyDescriptorCollection GetProperties()
        //{
        //    return GetProperties(new Attribute[0]);
        //}

        //public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        //{
        //    return _filter.Length != 0 ? _filteredPropertyDescriptors : _fullPropertyDescriptors;
        //}

        //public object GetPropertyOwner(PropertyDescriptor pd)
        //{
        //    return this;
        //}

        #endregion
    }
}
