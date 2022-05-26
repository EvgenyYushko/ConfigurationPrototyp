﻿namespace ConfigurationModules.ServiceLayer.Models
{
    public class ConfigSettingsDto 
    {
        public string ProfileName { get; set; }

        public string ConnectionString { get; set; }

        public string AssemblyPath { get; set; }

        public System.Drawing.Size SizeForm { get; set; }

        public string ServerName { get; set; }
    }
}