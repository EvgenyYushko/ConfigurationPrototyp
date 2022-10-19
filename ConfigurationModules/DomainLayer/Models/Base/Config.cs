using System.Configuration;
using System.Runtime.CompilerServices;

namespace ConfigurationModules.DomainLayer.Models.Base
{
	/// <summary>
	/// Класс настроек приложения
	/// </summary>
	public class Config : ConfigurationElement
	{
		[ConfigurationProperty(nameof(ServerName))]
		public string ServerName
		{
			get => (string)GetValue();
			set => SetValueIfDif(value);
		}

		[ConfigurationProperty(nameof(ServerList))]
		public string ServerList
		{
			get => (string)GetValue();
			set => SetValueIfDif(value);
		}

		[ConfigurationProperty(nameof(DatabaseName))]
		public string DatabaseName
		{
			get => (string)GetValue();
			set => SetValueIfDif(value);
		}

		[ConfigurationProperty(nameof(ConnectionString), DefaultValue = "Default")]
		public string ConnectionString
		{
			get => (string)GetValue();
			set => SetValueIfDif(value);
		}

		[ConfigurationProperty(nameof(CurrentWid), DefaultValue = "1")]
		public long CurrentWid
		{
			get => (long)GetValue();
			set => SetValueIfDif(value);
		}

		[ConfigurationProperty(nameof(ExportImportPath), DefaultValue = "Default")]
		public string ExportImportPath
		{
			get => (string)GetValue();
			set => SetValueIfDif(value);
		}

		[ConfigurationProperty(nameof(ExportAllTemplatePath), DefaultValue = "Default")]
		public string ExportAllTemplatePath
		{
			get => (string)GetValue();
			set => SetValueIfDif(value);
		}

		[ConfigurationProperty(nameof(IconFileName), DefaultValue = "Default")]
		public string IconFileName
		{
			get => (string)GetValue();
			set => SetValueIfDif(value);
		}

		[ConfigurationProperty(nameof(KdoCorePath))]
		public string KdoCorePath
		{
			get => (string)GetValue();
			set => SetValueIfDif(value);
		}

		[ConfigurationProperty(nameof(AssemblyPath), DefaultValue = "Default")]
		public string AssemblyPath
		{
			get => (string)GetValue();
			set => SetValueIfDif(value);
		}

		[ConfigurationProperty(nameof(AllowToReplaceFormAssemblies), DefaultValue = false)]
		public bool AllowToReplaceFormAssemblies
		{
			get => (bool)GetValue();
			set => SetValueIfDif(value);
		}

		[ConfigurationProperty(nameof(SizeForm), DefaultValue = "700, 700")]
		public System.Drawing.Size SizeForm
		{
			get => (System.Drawing.Size)GetValue();
			set => SetValueIfDif(value);
		}

		#region ValueOperations
		private object GetValue([CallerMemberName] string prpertyName = "")
		{
			return base[prpertyName];
		}

		private void SetValueIfDif(object value, [CallerMemberName] string propertyName = "")
		{
			if (!base[propertyName].Equals(value))
			{
				base[propertyName] = value;
			}
		}

		#endregion
	}
}
