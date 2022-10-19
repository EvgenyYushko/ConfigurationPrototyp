using System.Windows.Forms.Design;

namespace ConfigurationModules.Configurations.Convertors
{
    public class IconFileNameEditorExtension : FileNameEditor
    {
        /// <summary>
        /// Настройка фильтра расширений 
        /// </summary>
        protected override void InitializeDialog(System.Windows.Forms.OpenFileDialog ofd)
        {
            ofd.CheckFileExists = true;
            ofd.Filter = "Файлы значков (*.ico)|*.ico";
        }
	}
}
