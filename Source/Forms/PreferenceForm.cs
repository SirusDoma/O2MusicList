using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2MusicList
{
    public partial class PreferenceForm : Form
    {
        public PreferenceForm()
        {
            InitializeComponent();
        }

        private void OnPreferenceFormLoad(object sender, EventArgs e)
        {
            LoadPreference();
        }

        private void OnOkButtonClick(object sender, EventArgs e)
        {
            Preference.Instance.FileFormat     = (FileFormat)VersionDropDown.SelectedIndex;
            Preference.Instance.IsCompactBuild = Convert.ToBoolean(BuildModeDropDown.SelectedIndex);
            Preference.Instance.PreserveFormat = PreserveFormatCheckBox.Checked;
            Preference.Instance.KeyMode        = new int[] { 0, 3, 5, 7 }[KeyModeDropDown.SelectedIndex];
            Preference.Instance.PublishDate    = PublishDatePicker.Value;

            Preference.Instance.AutoSyncrhonize     = AutoSynchronizeCheckBox.Checked;
            Preference.Instance.AutoCorrectKeyMode  = AutoCorrectKeyMode.Checked;
            Preference.Instance.AutoRemoveDuplicate = AutoRemoveDuplicateCheckBox.Checked;
            Preference.Instance.AutoDetectEncoding  = AutoEncodingDropDown.Checked;

            try
            {
                // Only update encoding name with valid ones
                // Ignore invalid encoding name
                var encoding = Encoding.GetEncoding(Preference.GetEncodingName(EncodingDropDown.Text));
                Preference.Instance.EncodingName = Preference.GetEncodingName(EncodingDropDown.Text);
            }
            catch
            {
            }

            Preference.Instance.Dirty = true;
            Preference.Instance.Save();
            Close();
        }

        private void OnResetButtonClick(object sender, EventArgs e)
        {
            Preference.Instance.Reset();
            LoadPreference();
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void OnBuildModeDropDownSelectedIndexChanged(object sender, EventArgs e)
        {
            PublishDatePicker.Enabled = BuildModeDropDown.SelectedIndex == 0;
        }

        private void OnPreserveFormatCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            VersionDropDown.Enabled = !PreserveFormatCheckBox.Checked;
        }

        private void OnAutoEncodingDropDownCheckedChanged(object sender, EventArgs e)
        {
            EncodingDropDown.Enabled = !AutoEncodingDropDown.Checked;
        }

        private void LoadPreference()
        {
            BuildModeDropDown.SelectedIndex     = Convert.ToInt32(Preference.Instance.IsCompactBuild);
            VersionDropDown.SelectedIndex       = (int)Preference.Instance.FileFormat;
            PreserveFormatCheckBox.Checked      = Preference.Instance.PreserveFormat;
            KeyModeDropDown.SelectedItem        = Preference.Instance.KeyMode == 0 ? "Default" : $"{Preference.Instance.KeyMode}K";
            PublishDatePicker.Value             = Preference.Instance.PublishDate;

            AutoSynchronizeCheckBox.Checked     = Preference.Instance.AutoSyncrhonize;
            AutoCorrectKeyMode.Checked          = Preference.Instance.AutoCorrectKeyMode;
            AutoRemoveDuplicateCheckBox.Checked = Preference.Instance.AutoRemoveDuplicate;

            EncodingDropDown.Text               = Preference.GetLocalizationName(Preference.Instance.EncodingName);
            AutoEncodingDropDown.Checked        = Preference.Instance.AutoDetectEncoding;
        }
    }
}
