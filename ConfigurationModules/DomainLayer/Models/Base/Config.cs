using System.Configuration;

namespace ConfigurationModules.DomainLayer.Models.Base
{
    public class Config : ConfigurationElement
    {
        [ConfigurationProperty(nameof(ConnectionString), DefaultValue = "Default")]
        public string ConnectionString
        {
            get => (string)base[nameof(ConnectionString)];
            set
            {
                if (!((string)base[nameof(ConnectionString)]).Equals((string)value))
                {
                    base[nameof(ConnectionString)] = (string)value;
                }
            }
        }

        [ConfigurationProperty(nameof(AssemblyPath), DefaultValue = "Default")]
        public string AssemblyPath
        {
            get => (string)base[nameof(AssemblyPath)];
            set
            {
                if (!((string)base[nameof(AssemblyPath)]).Equals((string)value))
                {
                    base[nameof(AssemblyPath)] = (string)value;
                }
            }
        }

        [ConfigurationProperty(nameof(SizeForm), DefaultValue = "700, 700")]
        public System.Drawing.Size SizeForm
        {
            get => (System.Drawing.Size)base[nameof(SizeForm)];
            set
            {
                if ((System.Drawing.Size)base[nameof(SizeForm)] != (System.Drawing.Size)value)
                {
                    base[nameof(SizeForm)] = (System.Drawing.Size)value;
                }
            }
        }

        [ConfigurationProperty(nameof(ServerName), DefaultValue = "Default")]
        public string ServerName
        {
            get => (string)base[nameof(ServerName)];
            set
            {
                if (!((string)base[nameof(ServerName)]).Equals((string)value))
                {
                    base[nameof(ServerName)] = (string)value;
                }
            }
        }
    }
}
