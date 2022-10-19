using System.ComponentModel;
using System.Drawing.Design;
using ConfigurationModules.Configurations.Convertors;

namespace ConfigurationModules.ServiceLayer.Models.Base
{
    public class ConfigBaseDto
    {
        [DisplayName("Имя сервера")]
        [Description(nameof(ServerName))]
        public string ServerName { get; set; }

        [Description("Список серверов")]
        [TypeConverter(typeof(ServerListConvertor))]
        public string ServerList { get; set; }

        [Description("Список баз данных")]
        [TypeConverter(typeof(DataBaseListConvertor))]
        public string DatabaseName { get; set; }

        [DisplayName("Строка подключения")]
        [Description(nameof(ConnectionString))]
        public string ConnectionString { get; set; }

        [DisplayName("Айди текущего подразделения")]
        [Description(nameof(CurrentWid))]
        public long CurrentWid { get; set; }

        [DisplayName("Путь для экспорта/ импорта темплт")]
        [Description(nameof(ExportImportPath))]
        [Editor(typeof(FolderNameEditorExtension), typeof(UITypeEditor))]
        public string ExportImportPath { get; set; }

        [DisplayName("Путь для экспорта всех темплат")]
        [Description(nameof(ExportAllTemplatePath))]
        [Editor(typeof(FolderNameEditorExtension), typeof(UITypeEditor))]
        public string ExportAllTemplatePath { get; set; }

        [DisplayName("Путь для хранения значка приложения")]
        [Description(nameof(IconFileName))]
        [Editor(typeof(IconFileNameEditorExtension), typeof(UITypeEditor))]
        public string IconFileName { get; set; }

        [DisplayName("Путь к ядру КДО")]
        [Description(nameof(KdoCorePath))]
        [Editor(typeof(FolderNameEditorExtension), typeof(UITypeEditor))]
        public string KdoCorePath { get; set; }

        [DisplayName("Путь к последней выгружаемой/закачиваемой сборке")]
        [Description(nameof(AssemblyPath))]
        [Editor(typeof(FolderNameEditorExtension), typeof(UITypeEditor))]
        public string AssemblyPath { get; set; }

        [DisplayName("Разрешить экспорт сборок с возможность замены существующих сборок при импорте")]
        [Description(nameof(AllowToReplaceFormAssemblies))]
        public bool AllowToReplaceFormAssemblies { get; set; }

        [DisplayName("Размеры текущего окна")]
        public System.Drawing.Size SizeForm { get; set; }

        public override string ToString() => $"{ServerName}.{DatabaseName}";
    }
}
