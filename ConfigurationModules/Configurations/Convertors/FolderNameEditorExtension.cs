using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ConfigurationModules.Configurations.Convertors
{
    public class FolderNameEditorExtension : FolderNameEditor
    {
        private string _descriptionText;
        private FolderBrowserDialog _folderBrowser;

        public string Description
        {
            get => _descriptionText;
            set => _descriptionText = value ?? string.Empty;
        }

        public string DirectoryPath { get; set; } = string.Empty;

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (this._folderBrowser == null)
            {
                _folderBrowser = new FolderBrowserDialog { Description = _descriptionText };

                if (!string.IsNullOrEmpty((string) value))
                {
                    DirectoryPath = (string)value;
                }

                if (!string.IsNullOrEmpty(DirectoryPath))
                {
                    _folderBrowser.SelectedPath = DirectoryPath;
                }
            }

            return _folderBrowser.ShowDialog() != DialogResult.OK 
                ? value 
                : _folderBrowser.SelectedPath;
        }
    }
}
