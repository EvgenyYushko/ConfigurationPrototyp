using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConfigurationModules.ServiceLayer.Models;
using ConfigurationModules.ServiceLayer.Services;

namespace ConfigurationPrototyp
{
    public partial class AppCustomForm : Form
    {
        private readonly IConfigurationService _configurationService;
        private ConfigSettingsDto _profile;
        private List<ConfigSettingsDto> _profiles;
        private bool _operationRuning = false;

        public AppCustomForm(IConfigurationService configurationService)
        {
            InitializeComponent();
            _configurationService = configurationService;

            tbProfileName_TextChanged(tbProfileName, new EventArgs());
            cbProfiles_SelectedIndexChanged(cbProfiles, new EventArgs());
        }

        public string ProfileName
        {
            get => Properties.Settings.Default.ProfileName;
            set
            {
                Properties.Settings.Default.ProfileName = value;
                Properties.Settings.Default.Save();
            }
        }

        private void AppCustomForm_Load(object sender, EventArgs e)
        {
            _profiles = _configurationService.GetProfiles();
            UploadSettings();
        }

        private void UploadSettings()
        {
            _operationRuning = true;

            var profile = _profiles.FirstOrDefault(p => p.ProfileName == ProfileName);
            if (profile != null)
            {
                _profile = null;
                _profile = profile;
            }
            else
            {
                _profile = _configurationService.GetApplicationSetting(ProfileName);
                if (!_profiles.Contains(_profile))
                {
                    _profiles.Add(_profile);
                }
            }

            ProfileName = _profile.ProfileName;
            SettingToForm();

            _operationRuning = false;

            propertyGrid1.ExpandAllGridItems();
        }

        private void SettingToForm()
        {
            if (_configurationService != null)
            {
                cbProfiles.Items.Clear();
                cbProfiles.Items.AddRange(_profiles.Select(p => p.ProfileName).ToArray());
                cbProfiles.SelectedItem = ProfileName;
            }

            this.Size = _profile.Config.SizeForm;
            this.propertyGrid1.SelectedObject = _profile;
        }

        private void FormToSettings()
        {
            _profile.Config.SizeForm = this.Size;
            _profile = (ConfigSettingsDto)this.propertyGrid1.SelectedObject;
        }

        private void AppCustomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormToSettings();
            _configurationService.SaveProfiles(_profiles);
        }

        private void btAddProfile_Click(object sender, EventArgs e)
        {
            var newProfileName = tbProfileName.Text;
            if (string.IsNullOrWhiteSpace(newProfileName))
            {
                return;
            }

            cbProfiles.Items.Add(newProfileName);
            cbProfiles.SelectedItem = newProfileName;
            tbProfileName.Clear();
        }

        private void btDeleteProfile_Click(object sender, EventArgs e)
        {
            _operationRuning = true;

            if (_profiles.Contains(_profile))
            {
                _profiles.Remove(_profile);
                _configurationService.DeleteProfile(_profile);
            }

            cbProfiles.Items.Remove(cbProfiles.SelectedItem);
            if (cbProfiles.Items.Count != 0)
            {
                cbProfiles.SelectedIndex = 0;
                ProfileName = cbProfiles.SelectedItem.ToString();
            }

            _operationRuning = false;

            cbProfiles_SelectedIndexChanged(cbProfiles, new EventArgs());
        }

        private void tbProfileName_TextChanged(object sender, EventArgs e)
        {
            btAddProfile.Enabled = !string.IsNullOrWhiteSpace(tbProfileName.Text);
        }

        private void cbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btDeleteProfile.Enabled = cbProfiles.Items.Count > 1;
            if (_operationRuning || cbProfiles?.SelectedItem == null)
            {
                return;
            }

            FormToSettings();
            if (_profiles.Contains(_profile))
            {
                _profiles.Remove(_profile);
                _profiles.Add(_profile);
            }

            ProfileName = cbProfiles.SelectedItem.ToString();
            UploadSettings();
        }
    }
}
