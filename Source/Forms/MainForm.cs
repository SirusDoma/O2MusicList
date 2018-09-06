using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace O2MusicList
{
    public partial class MainForm : Form
    {
        private const int ThumbnailGapSize   = 85;
        private const string KoreanEncoding  = "ks_c_5601-1987";
        private const string ChineseEncoding = "big5";

        private OJNList headers;
        private OJN[] collections = new OJN[0];

        public OJN SelectedHeader { get; private set; }
        public bool Dirty { get; private set; } = false;

        #region --- Form Events ---
        public MainForm()
        {
            InitializeComponent();

            GenreDropdown.SelectedIndex = 0;
            ExLevelNumericBox.Maximum = NxLevelNumericBox.Maximum = HxLevelNumericBox.Maximum = short.MaxValue;
            ModeDropDown.SelectedIndex = 2;
            SortDropDown.SelectedIndex = (int)Preference.Instance.OrderBy;

            SearchTextBox.SetPlaceholder("Search for music..");
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
        }
        #endregion

        #region --- File Processing Events ---
        private void OnNewFileMenuClick(object sender, EventArgs e)
        {
            // Collection items are modified, ask the user to save the works before proceed
            if (Dirty)
            {
                var response = MessageBox.Show("Current music list is not yet saved.\nSave the file?", "Save File",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    SaveAsFileMenu.PerformClick();
                }
                else if (response == DialogResult.Cancel)
                {
                    return;
                }
            }

            // Reset all states
            headers = new OJNList();
            collections = new OJN[0];
            Dirty = false;

            PathTextBox.Text = string.Empty;
            MainStatusBar.Text = "Ready";
            SaveFileMenu.Enabled = SaveAsFileMenu.Enabled = EditMenu.Enabled = MusicGroupBox.Enabled = true;

            MusicListBox.Items.Clear();
            ResetFields();
        }

        async private void OnOpenFileMenuClick(object sender, EventArgs e)
        {
            // Collection items are modified, ask the user to save the works before proceed
            if (Dirty)
            {
                var response = MessageBox.Show("Current music list is not yet saved.\nSave the file?", "Save File", 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    SaveAsFileMenu.PerformClick();
                }
                else if (response == DialogResult.Cancel)
                {
                    return;
                }
            }

            // Setup open file dialog
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "O2Jam Music List|*.dat";
                openFileDialog.CheckFileExists = true;
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load OJNList
                        headers = OJNListDecoder.Decode(openFileDialog.FileName);

                        // Force to use specified encoding if auto detect is turned off
                        if (!Preference.Instance.AutoDetectEncoding)
                        {
                            headers.SetCharacterEncoding(Encoding.GetEncoding(Preference.Instance.EncodingName));
                        }

                        // Update Path and disable meta data editing
                        PathTextBox.Text = openFileDialog.FileName;
                        EditMenu.Enabled = MusicGroupBox.Enabled = MetadataGroupBox.Enabled = false;

                        // Attempt to load existing OJN files
                        if (Preference.Instance.AutoSyncrhonize)
                        {
                            string dir = $"{Directory.GetParent(Directory.GetParent(openFileDialog.FileName).FullName)}{Path.DirectorySeparatorChar}Music{Path.DirectorySeparatorChar}";
                            if (Directory.Exists(dir))
                            {
                                var loader = new LoadingForm();
                                loader.SetAction(() => SynchronizeFiles(loader, Directory.GetFiles(dir, "*.ojn", SearchOption.TopDirectoryOnly)));

                                using (loader)
                                {
                                    await Task.Run(() => Invoke(new Action(() => loader.ShowDialog(this))));
                                }
                            }
                        }

                        // Optimize before populate
                        if (Preference.Instance.AutoRemoveDuplicate)
                        {
                            headers.Optimize();
                        }

                        // Auto correct key
                        if (Preference.Instance.AutoCorrectKeyMode)
                        {
                            AutoCorrectKeyMode();
                        }

                        // Populate using existing search query
                        OnHeaderCollectionChanged(sender, e);

                        // Enable meta data editing, disable 7K for old version of OJNList
                        SaveFileMenu.Enabled = SaveAsFileMenu.Enabled = EditMenu.Enabled = MusicGroupBox.Enabled = true;
                        ModeLabel.Enabled = ModeDropDown.Enabled = headers.Version == FileFormat.New;

                        // Display the number of songs
                        MainStatusBar.Text = $"{headers.Count} songs";
                    }
                    catch (Exception ex)
                    {
                        // An error occur, reset the state of application
                        headers = new OJNList();
                        collections = new OJN[0];

                        PathTextBox.Text = string.Empty;
                        MainStatusBar.Text = "Ready";

                        MusicListBox.Items.Clear();
                        ResetFields();

                        // Display error to the user
                        MessageBox.Show($"Failed to load selected OJNList.\n{ex.Message}", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Reset dirty state
                        Dirty = false;
                    }
                }
            }
        }

        async private void OnSaveFileMenuClick(object sender, EventArgs e)
        {
            // Check whether valid path is already loaded
            if (string.IsNullOrEmpty(PathTextBox.Text))
            {
                // If not, use save as menu
                SaveAsFileMenu.PerformClick();
                return;
            }

            try
            {
                // Resolve preferred version and keymode
                var format = Preference.Instance.PreserveFormat ? headers.Version : Preference.Instance.FileFormat;
                int keymode = Preference.Instance.KeyMode;

                // Write the data into disk and reset dirty state
                File.WriteAllBytes(PathTextBox.Text, OJNListEncoder.Encode(headers, format, Preference.Instance.IsCompactBuild, keymode));

                // Synchronize changes with OJN files
                string[] errors = new string[0];
                if (Preference.Instance.AutoSyncrhonize)
                {
                    // Use loader to indicate convert progress
                    var loader = new LoadingForm();
                    loader.SetAction(() => errors = SaveHeaderFiles(loader));

                    using (loader)
                    {
                        await Task.Run(() => Invoke(new Action(() => loader.ShowDialog(this))));
                    }
                }

                // File already saved, reset dirty state
                Dirty = false;
                MainStatusBar.Text = $"{headers.Count} songs";

                // Notify user the OJNList is saved
                if (errors.Length == 0)
                {
                    MessageBox.Show("OJNList has been saved successfully.", "Information", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"OJNList has been saved successfully.\nHowever, failed to synchronize one or more OJN files.\n\n{string.Join("\n", errors)}", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Display error to the user in case failure
                MessageBox.Show($"Failed to save OJNList.\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSaveAsFileMenuClick(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                // Use existing filename if the filename is already made / loaded
                saveFileDialog.FileName = !string.IsNullOrEmpty(PathTextBox.Text) ? Path.GetFileName(PathTextBox.Text) : "OJNList.dat";
                saveFileDialog.Filter = "O2Jam Music List|*.dat";

                // Save the file according to selected filename
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PathTextBox.Text = saveFileDialog.FileName;
                    SaveFileMenu.PerformClick();
                }
            }
        }
        #endregion

        #region --- Collection Events ---
        private void OnHeaderCollectionChanged(object sender, EventArgs e)
        {
            // Fetch the new collections to display based on user query, also compare the collection size
            bool modified = headers.Modified;
            collections = headers.GetHeaders(header => header.TitleString.IndexOf(SearchTextBox.Text, StringComparison.InvariantCultureIgnoreCase) != -1);
            SortList();

            // Retrieve current index and rebuild listbox items
            int index = MusicListBox.SelectedIndex;
            MusicListBox.Items.Clear();
            MusicListBox.Items.AddRange(collections.Select(header => header.TitleString).ToArray());

            // Reposition to the last selected index if possible
            index = index >= 0 && index < MusicListBox.Items.Count ? index : MusicListBox.Items.Count > 0 ? 0 : -1;
            if (!modified && collections[index]?.Id != SelectedHeader?.Id)
            {
                index = MusicListBox.Items.Count == 0 ? -1 : 0;
            }

            // Apply the index, the selection now may have different id, so reload by triggering the appropriate event
            MusicListBox.SelectedIndex = index;
            OnMusicListBoxSelectedIndexChanged(sender, e);

            // Update statusbar to tell the number of displayed songs
            UpdateStatusBar();
        }

        private void OnMusicListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = MusicListBox.SelectedIndex;
            if (index >= 0)
            {
                // Update selected header based on new selected index
                SelectedHeader = collections[index];

                // Display header metadata to field
                IdTextBox.SetText(SelectedHeader.Id.ToString());
                TitleTextBox.SetText(SelectedHeader.TitleString);
                ArtistTextBox.SetText(SelectedHeader.ArtistString);
                PatternTextBox.SetText(SelectedHeader.PatternString);
                OJMTextBox.SetText(SelectedHeader.OJMString);
                EncodingDropDown.SetText(Preference.GetLocalizationName(SelectedHeader.CharacterEncoding.HeaderName));
                BPMNumericBox.Value = (decimal)SelectedHeader.BPM;
                ExLevelNumericBox.Value = SelectedHeader.LevelEx;
                NxLevelNumericBox.Value = SelectedHeader.LevelNx;
                HxLevelNumericBox.Value = SelectedHeader.LevelHx;
                ModeDropDown.SelectedItem = $"{SelectedHeader.KeyMode}K";
                GenreDropdown.SelectedIndex = (int)SelectedHeader.Genre;
                MetadataGroupBox.Enabled = true;

                // Check whether thumbnail available to display
                if (SelectedHeader.Thumbnail != null || File.Exists(SelectedHeader.Source))
                {
                    if (!ThumbnailPictureBox.Visible)
                    {
                        ToggleThumbnail();
                    }

                    ThumbnailPictureBox.Image = SelectedHeader.Thumbnail ?? Properties.Resources.Thumbnail;
                }
                else if (ThumbnailPictureBox.Visible)
                {
                    ToggleThumbnail();
                }

                // If selected header has been syncrhonized with OJN file, show encryption option
                EncryptedCheckBox.Enabled = File.Exists(SelectedHeader.Source);
                EncryptedCheckBox.Checked = SelectedHeader.Encrypted;
            }
            else
            {
                // Invalid selected index, reset all fields
                ResetFields();
            }
        }
        #endregion

        #region --- Add / Remove Events ---
        private void OnAddEditMenuClick(object sender, EventArgs e)
        {
            AddButton.PerformClick();
        }

        private void OnRemoveEditMenuClick(object sender, EventArgs e)
        {
            RemoveButton.PerformClick();
        }

        async private void OnAddButtonClick(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                // Setup open file dialog
                openFileDialog.Filter = "O2Jam Music File|*.ojn";
                openFileDialog.CheckFileExists = true;
                openFileDialog.Multiselect = true;

                // Load for every selected OJN files
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Use loader to indicate convert progress
                    var loader = new LoadingForm();
                    loader.SetAction(() => AddFiles(loader, openFileDialog.FileNames));

                    using (loader)
                    {
                        await Task.Run(() => Invoke(new Action(() => loader.ShowDialog(this))));
                        OnHeaderCollectionChanged(sender, e);
                    }
                }
            }
        }

        private void OnRemoveButtonClick(object sender, EventArgs e)
        {
            // Only load if selected item is valid
            if (MusicListBox.SelectedIndices.Count == 0)
            {
                return;
            }

            // Remove the selected items
            foreach (int index in MusicListBox.SelectedIndices)
            {
                var item = collections[index];
                headers.Remove(item.Id);
            }

            // List of header is modified, so set the dirty state
            // Also, update the displayed collection
            Dirty = true;
            OnHeaderCollectionChanged(sender, e);
        }
        #endregion

        #region --- Field Events ---
        private void OnIdTextBoxKeypress(object sender, KeyPressEventArgs e)
        {
            // Ignore non numeric value
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void OnMetaFieldTextChanged(object sender, EventArgs e)
        {
            // Recheck whether selected item is valid
            if (SelectedHeader == null)
            {
                return;
            }

            // Retrieve existing id and character encoding
            int id = SelectedHeader.Id;
            var encoding = SelectedHeader.CharacterEncoding;

            // Update the field
            SelectedHeader.Id = !string.IsNullOrEmpty(IdTextBox.Text) ? int.Parse(IdTextBox.Text) : 0;
            SelectedHeader.Title = encoding.GetBytes(TitleTextBox.Text.PadRight(64, '\0')).Take(64).ToArray();
            SelectedHeader.Artist = encoding.GetBytes(ArtistTextBox.Text.PadRight(32, '\0')).Take(32).ToArray();
            SelectedHeader.Pattern = encoding.GetBytes(PatternTextBox.Text.PadRight(32, '\0')).Take(32).ToArray();
            SelectedHeader.OJM = encoding.GetBytes(OJMTextBox.Text.PadRight(32, '\0')).Take(32).ToArray();
            SelectedHeader.Genre = (Genre)GenreDropdown.SelectedIndex;
            SelectedHeader.BPM = (float)BPMNumericBox.Value;
            SelectedHeader.LevelEx = (short)ExLevelNumericBox.Value;
            SelectedHeader.LevelNx = (short)NxLevelNumericBox.Value;
            SelectedHeader.LevelHx = (short)HxLevelNumericBox.Value;
            SelectedHeader.KeyMode = byte.Parse(ModeDropDown.SelectedItem.ToString().Substring(0, 1));
            SelectedHeader.Encrypted = EncryptedCheckBox.Checked;

            // Update the header and set dirty state
            Dirty = true;
            headers.Update(id, SelectedHeader);
            MusicListBox.Items[MusicListBox.SelectedIndex] = TitleTextBox.Text;
        }

        private void OnGenreDropdownValueChanged(object sender, EventArgs e)
        {
            if (SelectedHeader == null)
            {
                return;
            }

            Dirty = Dirty || (int)SelectedHeader.Genre != GenreDropdown.SelectedIndex;
            SelectedHeader.Genre = (Genre)GenreDropdown.SelectedIndex;
        }

        private void OnModeDropDownSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedHeader == null)
            {
                return;
            }

            byte mode = byte.Parse(ModeDropDown.SelectedItem.ToString().Substring(0, 1));
            Dirty = Dirty || SelectedHeader.KeyMode != mode;
            SelectedHeader.KeyMode = mode;
        }

        private void OnBPMNumericValueChanged(object sender, EventArgs e)
        {
            if (SelectedHeader == null)
            {
                return;
            }

            Dirty = Dirty || SelectedHeader.BPM != (float)BPMNumericBox.Value;
            SelectedHeader.BPM = (float)BPMNumericBox.Value;
        }


        private void OnExLevelNumericBoxValueChanged(object sender, EventArgs e)
        {
            if (SelectedHeader == null)
            {
                return;
            }

            Dirty = Dirty || SelectedHeader.LevelEx != (short)ExLevelNumericBox.Value;
            SelectedHeader.LevelEx = (short)ExLevelNumericBox.Value;
        }

        private void OnNxLevelNumericBoxValueChanged(object sender, EventArgs e)
        {
            if (SelectedHeader == null)
            {
                return;
            }

            Dirty = Dirty || SelectedHeader.LevelNx != (short)NxLevelNumericBox.Value;
            SelectedHeader.LevelNx = (short)NxLevelNumericBox.Value;
        }

        private void OnHxLevelNumericBoxValueChanged(object sender, EventArgs e)
        {
            if (SelectedHeader == null)
            {
                return;
            }

            Dirty = Dirty || SelectedHeader.LevelHx != (short)HxLevelNumericBox.Value;
            SelectedHeader.LevelHx = (short)HxLevelNumericBox.Value;
        }

        private void OnEncodingDropDownSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = MusicListBox.SelectedIndex;
            if (index < 0 || index >= MusicListBox.Items.Count)
            {
                return;
            }

            SelectedHeader.CharacterEncoding = Encoding.GetEncoding(Preference.GetEncodingName(EncodingDropDown.Text));
            MusicListBox.Items[index] = SelectedHeader.TitleString;
            OnMusicListBoxSelectedIndexChanged(sender, e);
        }

        private void OnSortDropDownSelectedIndexChanged(object sender, EventArgs e)
        {
            if (headers != null && collections != null && collections.Length > 0)
            {
                Preference.Instance.OrderBy = (SortingField)SortDropDown.SelectedIndex;
                Preference.Instance.Save();

                OnHeaderCollectionChanged(sender, e);
            }
        }
        #endregion

        #region --- Utilities Events ---
        private void OnRemoveDuplicateEditMenuClick(object sender, EventArgs e)
        {
            int removed = headers.Optimize();
            OnHeaderCollectionChanged(sender, e);

            MessageBox.Show($"{removed} duplicate files has been removed.", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnAutoCorrectKeyModeEditMenuClick(object sender, EventArgs e)
        {

            AutoCorrectKeyMode();
            MessageBox.Show("Autocorrection completed.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        async private void OnSynchronizeEditMenuClick(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                // Setup open file dialog
                openFileDialog.Filter = "O2Jam Music File|*.ojn";
                openFileDialog.CheckFileExists = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Use loader to synchronization progress
                    var errors = new string[0];
                    var loader = new LoadingForm();
                    loader.SetAction(() => errors = SynchronizeFiles(loader, openFileDialog.FileNames));

                    using (loader)
                    {
                        await Task.Run(() => Invoke(new Action(() => loader.ShowDialog(this))));
                        OnHeaderCollectionChanged(sender, e);

                        if (errors.Length > 0)
                        {
                            MessageBox.Show($"Failed to synchronize one or more selected OJN.\n{string.Join("\n", errors)}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show($"Files has been synchronized successfully.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        async private void OnConvertToolsMenuClick(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                // Setup open file dialog
                openFileDialog.Filter = "O2Jam Music File|*.ojn";
                openFileDialog.CheckFileExists = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Let user select a directory to specify where to dump the converted files
                    using (var folderBrowser = new FolderBrowserDialog())
                    {
                        // Setup the dialog
                        folderBrowser.ShowNewFolderButton = true;
                        folderBrowser.Description = "Select where converted OJN will be saved";
                        if (folderBrowser.ShowDialog() == DialogResult.OK)
                        {
                            // Use loader to indicate convert progress
                            var loader = new LoadingForm();
                            loader.SetAction(() => ConvertFiles(loader, openFileDialog.FileNames, folderBrowser.SelectedPath));

                            using (loader)
                            {
                                await Task.Run(() => Invoke(new Action(() => loader.ShowDialog(this))));
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region --- Misc ---
        private void OnPreferencesFileMenuClick(object sender, EventArgs e)
        {
            using (var preferenceForm = new PreferenceForm())
            {
                if (preferenceForm.ShowDialog() == DialogResult.OK)
                {
                    ModeLabel.Enabled = ModeDropDown.Enabled = Preference.Instance.PreserveFormat || Preference.Instance.FileFormat == FileFormat.New;

                    if (headers != null)
                    {
                        if (!Preference.Instance.AutoDetectEncoding)
                        {
                            headers.SetCharacterEncoding(Encoding.GetEncoding(Preference.Instance.EncodingName));
                        }

                        OnHeaderCollectionChanged(sender, e);
                    }
                }
            }
        }

        private void OnAboutHelpMenuClick(object sender, EventArgs e)
        {
            using (var aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }
        #endregion

        #region --- Exit Events ---
        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            if (Dirty)
            {
                var response = MessageBox.Show("Current music list is not yet saved.\nSave the file?", "Save File",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    SaveAsFileMenu.PerformClick();
                }
                else if (response == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void OnExitFileMenuClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region --- Methods ---
        private void AddFiles(LoadingForm loader, string[] filenames)
        {
            var errors = new List<string>();
            for (int i = 0; i < filenames.Length; i++)
            {
                try
                {
                    // Set loader status
                    loader.SetStatus($"Processing {Path.GetFileName(filenames[i])}..");
                    loader.SetProgress(((i + 1) / (float)filenames.Length) * 100f);

                    // Decode header data
                    var header = OJNDecoder.Decode(filenames[i]);

                    // Force to load selected encoding if user tell so
                    if (!Preference.Instance.AutoDetectEncoding)
                    {
                        header.CharacterEncoding = Encoding.GetEncoding(Preference.Instance.EncodingName);
                    }
                    else
                    {
                        // Detect by file format
                        string charset = headers.Version == FileFormat.New ? KoreanEncoding : ChineseEncoding;

                        header.CharacterEncoding = Encoding.GetEncoding(charset);
                    }

                    // Check whether OJNList has song with same id
                    // If so, display the error to the user.
                    if (!headers.Add(header))
                    {
                        throw new Exception("OJN with same ID already exists.");
                    }

                    // Headers collection is modified, set dirty state
                    Dirty = true;
                }
                catch (Exception ex)
                {
                    // Add the error into collection
                    errors.Add($"{Path.GetFileName(filenames[i])} ({ex.Message})");
                }
            }

            if (errors.Count > 0)
            {
                MessageBox.Show($"Failed to load one or more selected OJN.\n{string.Join("\n", errors)}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            loader.Terminate();
        }

        private void AutoCorrectKeyMode()
        {
            foreach (var header in headers.GetHeaders())
            {
                if (header.TitleString.IndexOf("[3K]", StringComparison.InvariantCultureIgnoreCase) != -1 ||
                    header.TitleString.IndexOf("[3M]", StringComparison.InvariantCultureIgnoreCase) != -1 ||
                    header.TitleString.IndexOf("[3D]", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    header.KeyMode = 3;
                    headers.Update(header.Id, header);
                }
                else if (header.TitleString.IndexOf("[5K]", StringComparison.InvariantCultureIgnoreCase) != -1 ||
                    header.TitleString.IndexOf("[5M]", StringComparison.InvariantCultureIgnoreCase) != -1 ||
                    header.TitleString.IndexOf("[5D]", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    header.KeyMode = 5;
                    headers.Update(header.Id, header);
                }
            }
        }

        private string[] SynchronizeFiles(LoadingForm loader, string[] filenames, bool thumbnailOnly = false)
        {
            var errors = new List<string>();
            int syncCount = 0;
            for (int i = 0; i < filenames.Length; i++)
            {
                try
                {
                    loader.SetStatus($"Processing {Path.GetFileName(filenames[i])}..");
                    loader.SetProgress(((i + 1) / (float)filenames.Length) * 100f);

                    var encoding = Encoding.GetEncoding(Preference.Instance.EncodingName);
                    if (Preference.Instance.AutoDetectEncoding)
                    {
                        encoding = headers.Version == FileFormat.New ? Encoding.GetEncoding(KoreanEncoding) : Encoding.GetEncoding(ChineseEncoding);
                    }

                    var header = OJNDecoder.Decode(filenames[i], encoding);
                    if (headers.Contains(header.Id))
                    {
                        syncCount++;
                        if (thumbnailOnly)
                        {
                            var thumbnail = header.Thumbnail;

                            header = headers[header.Id];
                            header.Thumbnail = thumbnail;
                        }

                        headers.Update(header.Id, header);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"{Path.GetFileName(filenames[i])} ({ex.Message})");
                }
            }

            loader.Terminate();
            return errors.ToArray();
        }

        private string[] SaveHeaderFiles(LoadingForm loader)
        {
            var errors = new List<string>();
            var data = headers.GetHeaders();
            for (int i = 0; i < data.Length; i++)
            {
                try
                {
                    loader.SetProgress(((i + 1) / (float)data.Length) * 100f);
                    if (File.Exists(SelectedHeader.Source))
                    {
                        loader.SetStatus($"Processing {Path.GetFileName(SelectedHeader.Source)}..");
                        var headerData = OJNEncoder.Encode(SelectedHeader);
                        File.WriteAllBytes(SelectedHeader.Source, headerData);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"{Path.GetFileName(data[i].Source)} ({ex.Message})");
                }
            }

            loader.Terminate();
            return errors.ToArray();
        }

        private void ConvertFiles(LoadingForm loader, string[] filenames, string outputDir)
        {
            var errors = new List<string>();
            for (int i = 0; i < filenames.Length; i++)
            {
                try
                {
                    loader.SetStatus($"Processing {Path.GetFileName(filenames[i])}..");
                    loader.SetProgress(((i + 1) / (float)filenames.Length) * 100f);

                    string output = $"{outputDir}{Path.DirectorySeparatorChar}{Path.GetFileName(filenames[i])}";
                    using (var fstream = new FileStream(filenames[i], FileMode.Open))
                    {
                        if (OJNDecoder.IsEncrypted(fstream, true))
                        {
                            byte[] data = OJNDecoder.Decrypt(fstream);
                            fstream.Close();

                            File.WriteAllBytes(output, data);
                        }
                        else
                        {
                            byte[] data = OJNEncoder.Encrypt(fstream);
                            fstream.Close();

                            File.WriteAllBytes(output, data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"{Path.GetFileName(filenames[i])} ({ex.Message})");
                }
            }

            if (errors.Count > 0)
            {
                MessageBox.Show($"Failed to convert one or more selected OJN.\n{string.Join("\n", errors)}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show($"{filenames.Length} files has been converted.", "Information", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            loader.Terminate();
        }

        private void SortList()
        {
            switch(Preference.Instance.OrderBy)
            {
                case SortingField.Title   : collections = collections.OrderBy(header => header.TitleString).ToArray();  break;
                case SortingField.Artist  : collections = collections.OrderBy(header => header.ArtistString).ToArray(); break;
                case SortingField.Pattern : collections = collections.OrderBy(header => header.PatternString).ToArray(); break;
                default                : collections = collections.OrderBy(header => header.Id).ToArray(); break;
            }
        }
        #endregion

        #region --- UI Methods ---
        private void ToggleThumbnail()
        {
            ToggleThumbnail(!ThumbnailPictureBox.Visible);
        }

        private void ToggleThumbnail(bool state)
        {
            if (state && !ThumbnailPictureBox.Visible)
            {
                IdTextBox.Width          -= ThumbnailGapSize;
                TitleTextBox.Width       -= ThumbnailGapSize;
                ArtistTextBox.Width      -= ThumbnailGapSize;
                EncodingDropDown.Location = new Point(EncodingDropDown.Location.X - ThumbnailGapSize, EncodingDropDown.Location.Y);
                
            }
            else if (!state && ThumbnailPictureBox.Visible)
            {
                IdTextBox.Width          += ThumbnailGapSize;
                TitleTextBox.Width       += ThumbnailGapSize;
                ArtistTextBox.Width      += ThumbnailGapSize;
                EncodingDropDown.Location = new Point(EncodingDropDown.Location.X + ThumbnailGapSize, EncodingDropDown.Location.Y);
            }

            ThumbnailPictureBox.Visible = state;
        }

        private void UpdateStatusBar()
        {
            if (headers != null && headers.Count > 0)
            {
                if (SearchTextBox.Text == string.Empty)
                {
                    MainStatusBar.Text = $"{headers.Count} songs";
                }
                else
                {
                    MainStatusBar.Text = $"Displaying {collections.Length} out of {headers.Count} songs";
                }
            }
            else
            {
                MainStatusBar.Text = "Ready";
            }
        }

        private void ResetFields()
        {
            SelectedHeader = null;
            MetadataGroupBox.Enabled = false;
            IdTextBox.SetText(string.Empty);
            TitleTextBox.SetText(string.Empty);
            ArtistTextBox.SetText(string.Empty);
            PatternTextBox.SetText(string.Empty);
            OJMTextBox.SetText(string.Empty);
            GenreDropdown.SelectedIndex = (int)0;
            BPMNumericBox.Value = 1;
            ExLevelNumericBox.Value = 0;
            NxLevelNumericBox.Value = 0;
            HxLevelNumericBox.Value = 0;
            ModeDropDown.SelectedIndex = 2;

            ToggleThumbnail(false);
            UpdateStatusBar();
        }
        #endregion
    }
}
