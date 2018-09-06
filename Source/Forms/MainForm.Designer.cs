namespace O2MusicList
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.FileMenu = new System.Windows.Forms.MenuItem();
            this.NewFileMenu = new System.Windows.Forms.MenuItem();
            this.OpenFileMenu = new System.Windows.Forms.MenuItem();
            this.MenuSeparator1 = new System.Windows.Forms.MenuItem();
            this.SaveFileMenu = new System.Windows.Forms.MenuItem();
            this.SaveAsFileMenu = new System.Windows.Forms.MenuItem();
            this.MenuSeparator2 = new System.Windows.Forms.MenuItem();
            this.PreferencesFileMenu = new System.Windows.Forms.MenuItem();
            this.MenuSeparator3 = new System.Windows.Forms.MenuItem();
            this.ExitFileMenu = new System.Windows.Forms.MenuItem();
            this.EditMenu = new System.Windows.Forms.MenuItem();
            this.AddEditMenu = new System.Windows.Forms.MenuItem();
            this.RemoveEditMenu = new System.Windows.Forms.MenuItem();
            this.SynchronizeEditMenu = new System.Windows.Forms.MenuItem();
            this.MenuSeparator4 = new System.Windows.Forms.MenuItem();
            this.RemoveDuplicateEditMenu = new System.Windows.Forms.MenuItem();
            this.AutoCorrectKeyModeEditMenu = new System.Windows.Forms.MenuItem();
            this.ToolsMenu = new System.Windows.Forms.MenuItem();
            this.ConvertToolsMenu = new System.Windows.Forms.MenuItem();
            this.HelpMenu = new System.Windows.Forms.MenuItem();
            this.AboutHelpMenu = new System.Windows.Forms.MenuItem();
            this.FileLabel = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.MusicGroupBox = new System.Windows.Forms.GroupBox();
            this.SortDropDown = new System.Windows.Forms.ComboBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.MusicListBox = new System.Windows.Forms.ListBox();
            this.MetadataGroupBox = new System.Windows.Forms.GroupBox();
            this.EncryptedCheckBox = new System.Windows.Forms.CheckBox();
            this.EncodingDropDown = new System.Windows.Forms.ComboBox();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.ModeDropDown = new System.Windows.Forms.ComboBox();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.LevelsGroupBox = new System.Windows.Forms.GroupBox();
            this.HxLabel = new System.Windows.Forms.Label();
            this.HxLevelNumericBox = new System.Windows.Forms.NumericUpDown();
            this.NxLabel = new System.Windows.Forms.Label();
            this.NxLevelNumericBox = new System.Windows.Forms.NumericUpDown();
            this.ExLabel = new System.Windows.Forms.Label();
            this.ExLevelNumericBox = new System.Windows.Forms.NumericUpDown();
            this.OJMTextBox = new System.Windows.Forms.TextBox();
            this.OJMLabel = new System.Windows.Forms.Label();
            this.BPMLabel = new System.Windows.Forms.Label();
            this.BPMNumericBox = new System.Windows.Forms.NumericUpDown();
            this.GenreLabel = new System.Windows.Forms.Label();
            this.GenreDropdown = new System.Windows.Forms.ComboBox();
            this.PatternTextBox = new System.Windows.Forms.TextBox();
            this.PatternLabel = new System.Windows.Forms.Label();
            this.ArtistTextBox = new System.Windows.Forms.TextBox();
            this.ArtistLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ThumbnailPictureBox = new System.Windows.Forms.PictureBox();
            this.MainStatusBar = new System.Windows.Forms.StatusBar();
            this.MusicGroupBox.SuspendLayout();
            this.MetadataGroupBox.SuspendLayout();
            this.LevelsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HxLevelNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NxLevelNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExLevelNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BPMNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileMenu,
            this.EditMenu,
            this.ToolsMenu,
            this.HelpMenu});
            // 
            // FileMenu
            // 
            this.FileMenu.Index = 0;
            this.FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.NewFileMenu,
            this.OpenFileMenu,
            this.MenuSeparator1,
            this.SaveFileMenu,
            this.SaveAsFileMenu,
            this.MenuSeparator2,
            this.PreferencesFileMenu,
            this.MenuSeparator3,
            this.ExitFileMenu});
            this.FileMenu.Text = "File";
            // 
            // NewFileMenu
            // 
            this.NewFileMenu.Index = 0;
            this.NewFileMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.NewFileMenu.Text = "New..";
            this.NewFileMenu.Click += new System.EventHandler(this.OnNewFileMenuClick);
            // 
            // OpenFileMenu
            // 
            this.OpenFileMenu.Index = 1;
            this.OpenFileMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.OpenFileMenu.Text = "Open";
            this.OpenFileMenu.Click += new System.EventHandler(this.OnOpenFileMenuClick);
            // 
            // MenuSeparator1
            // 
            this.MenuSeparator1.Index = 2;
            this.MenuSeparator1.Text = "-";
            // 
            // SaveFileMenu
            // 
            this.SaveFileMenu.Enabled = false;
            this.SaveFileMenu.Index = 3;
            this.SaveFileMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.SaveFileMenu.Text = "Save";
            this.SaveFileMenu.Click += new System.EventHandler(this.OnSaveFileMenuClick);
            // 
            // SaveAsFileMenu
            // 
            this.SaveAsFileMenu.Enabled = false;
            this.SaveAsFileMenu.Index = 4;
            this.SaveAsFileMenu.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.SaveAsFileMenu.Text = "Save As..";
            this.SaveAsFileMenu.Click += new System.EventHandler(this.OnSaveAsFileMenuClick);
            // 
            // MenuSeparator2
            // 
            this.MenuSeparator2.Index = 5;
            this.MenuSeparator2.Text = "-";
            // 
            // PreferencesFileMenu
            // 
            this.PreferencesFileMenu.Index = 6;
            this.PreferencesFileMenu.Text = "Preferences";
            this.PreferencesFileMenu.Click += new System.EventHandler(this.OnPreferencesFileMenuClick);
            // 
            // MenuSeparator3
            // 
            this.MenuSeparator3.Index = 7;
            this.MenuSeparator3.Text = "-";
            // 
            // ExitFileMenu
            // 
            this.ExitFileMenu.Index = 8;
            this.ExitFileMenu.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.ExitFileMenu.Text = "Exit";
            this.ExitFileMenu.Click += new System.EventHandler(this.OnExitFileMenuClick);
            // 
            // EditMenu
            // 
            this.EditMenu.Enabled = false;
            this.EditMenu.Index = 1;
            this.EditMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.AddEditMenu,
            this.RemoveEditMenu,
            this.SynchronizeEditMenu,
            this.MenuSeparator4,
            this.RemoveDuplicateEditMenu,
            this.AutoCorrectKeyModeEditMenu});
            this.EditMenu.Text = "Edit";
            // 
            // AddEditMenu
            // 
            this.AddEditMenu.Index = 0;
            this.AddEditMenu.Text = "Add..";
            this.AddEditMenu.Click += new System.EventHandler(this.OnAddEditMenuClick);
            // 
            // RemoveEditMenu
            // 
            this.RemoveEditMenu.Index = 1;
            this.RemoveEditMenu.Text = "Remove..";
            this.RemoveEditMenu.Click += new System.EventHandler(this.OnRemoveEditMenuClick);
            // 
            // SynchronizeEditMenu
            // 
            this.SynchronizeEditMenu.Index = 2;
            this.SynchronizeEditMenu.Text = "Synchronize..";
            this.SynchronizeEditMenu.Click += new System.EventHandler(this.OnSynchronizeEditMenuClick);
            // 
            // MenuSeparator4
            // 
            this.MenuSeparator4.Index = 3;
            this.MenuSeparator4.Text = "-";
            // 
            // RemoveDuplicateEditMenu
            // 
            this.RemoveDuplicateEditMenu.Index = 4;
            this.RemoveDuplicateEditMenu.Text = "Remove Duplicate";
            this.RemoveDuplicateEditMenu.Click += new System.EventHandler(this.OnRemoveDuplicateEditMenuClick);
            // 
            // AutoCorrectKeyModeEditMenu
            // 
            this.AutoCorrectKeyModeEditMenu.Index = 5;
            this.AutoCorrectKeyModeEditMenu.Text = "Autocorrect KeyMode";
            this.AutoCorrectKeyModeEditMenu.Click += new System.EventHandler(this.OnAutoCorrectKeyModeEditMenuClick);
            // 
            // ToolsMenu
            // 
            this.ToolsMenu.Index = 2;
            this.ToolsMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ConvertToolsMenu});
            this.ToolsMenu.Text = "Tools";
            // 
            // ConvertToolsMenu
            // 
            this.ConvertToolsMenu.Index = 0;
            this.ConvertToolsMenu.Text = "Encrypt / Decrypt OJN..";
            this.ConvertToolsMenu.Click += new System.EventHandler(this.OnConvertToolsMenuClick);
            // 
            // HelpMenu
            // 
            this.HelpMenu.Index = 3;
            this.HelpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.AboutHelpMenu});
            this.HelpMenu.Text = "Help";
            // 
            // AboutHelpMenu
            // 
            this.AboutHelpMenu.Index = 0;
            this.AboutHelpMenu.Text = "About";
            this.AboutHelpMenu.Click += new System.EventHandler(this.OnAboutHelpMenuClick);
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileLabel.Location = new System.Drawing.Point(12, 15);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(23, 13);
            this.FileLabel.TabIndex = 0;
            this.FileLabel.Text = "File";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathTextBox.Location = new System.Drawing.Point(41, 12);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(561, 21);
            this.PathTextBox.TabIndex = 1;
            // 
            // OpenButton
            // 
            this.OpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenButton.Location = new System.Drawing.Point(608, 10);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 2;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OnOpenFileMenuClick);
            // 
            // MusicGroupBox
            // 
            this.MusicGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MusicGroupBox.Controls.Add(this.SortDropDown);
            this.MusicGroupBox.Controls.Add(this.SearchTextBox);
            this.MusicGroupBox.Controls.Add(this.RemoveButton);
            this.MusicGroupBox.Controls.Add(this.AddButton);
            this.MusicGroupBox.Controls.Add(this.MusicListBox);
            this.MusicGroupBox.Enabled = false;
            this.MusicGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MusicGroupBox.Location = new System.Drawing.Point(15, 40);
            this.MusicGroupBox.Name = "MusicGroupBox";
            this.MusicGroupBox.Size = new System.Drawing.Size(258, 298);
            this.MusicGroupBox.TabIndex = 3;
            this.MusicGroupBox.TabStop = false;
            this.MusicGroupBox.Text = "Music";
            // 
            // SortDropDown
            // 
            this.SortDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortDropDown.FormattingEnabled = true;
            this.SortDropDown.Items.AddRange(new object[] {
            "ID",
            "Title",
            "Artist",
            "Pattern"});
            this.SortDropDown.Location = new System.Drawing.Point(6, 46);
            this.SortDropDown.Name = "SortDropDown";
            this.SortDropDown.Size = new System.Drawing.Size(246, 21);
            this.SortDropDown.TabIndex = 1;
            this.SortDropDown.SelectedIndexChanged += new System.EventHandler(this.OnSortDropDownSelectedIndexChanged);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.Location = new System.Drawing.Point(6, 19);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(246, 21);
            this.SearchTextBox.TabIndex = 0;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.OnHeaderCollectionChanged);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.Location = new System.Drawing.Point(132, 266);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(120, 25);
            this.RemoveButton.TabIndex = 4;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.OnRemoveButtonClick);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(6, 266);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(120, 25);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.OnAddButtonClick);
            // 
            // MusicListBox
            // 
            this.MusicListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MusicListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MusicListBox.FormattingEnabled = true;
            this.MusicListBox.Location = new System.Drawing.Point(6, 71);
            this.MusicListBox.Name = "MusicListBox";
            this.MusicListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.MusicListBox.Size = new System.Drawing.Size(246, 186);
            this.MusicListBox.TabIndex = 2;
            this.MusicListBox.SelectedIndexChanged += new System.EventHandler(this.OnMusicListBoxSelectedIndexChanged);
            // 
            // MetadataGroupBox
            // 
            this.MetadataGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetadataGroupBox.Controls.Add(this.EncryptedCheckBox);
            this.MetadataGroupBox.Controls.Add(this.EncodingDropDown);
            this.MetadataGroupBox.Controls.Add(this.ModeLabel);
            this.MetadataGroupBox.Controls.Add(this.ModeDropDown);
            this.MetadataGroupBox.Controls.Add(this.IdTextBox);
            this.MetadataGroupBox.Controls.Add(this.IdLabel);
            this.MetadataGroupBox.Controls.Add(this.LevelsGroupBox);
            this.MetadataGroupBox.Controls.Add(this.OJMTextBox);
            this.MetadataGroupBox.Controls.Add(this.OJMLabel);
            this.MetadataGroupBox.Controls.Add(this.BPMLabel);
            this.MetadataGroupBox.Controls.Add(this.BPMNumericBox);
            this.MetadataGroupBox.Controls.Add(this.GenreLabel);
            this.MetadataGroupBox.Controls.Add(this.GenreDropdown);
            this.MetadataGroupBox.Controls.Add(this.PatternTextBox);
            this.MetadataGroupBox.Controls.Add(this.PatternLabel);
            this.MetadataGroupBox.Controls.Add(this.ArtistTextBox);
            this.MetadataGroupBox.Controls.Add(this.ArtistLabel);
            this.MetadataGroupBox.Controls.Add(this.TitleTextBox);
            this.MetadataGroupBox.Controls.Add(this.TitleLabel);
            this.MetadataGroupBox.Controls.Add(this.ThumbnailPictureBox);
            this.MetadataGroupBox.Enabled = false;
            this.MetadataGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MetadataGroupBox.Location = new System.Drawing.Point(279, 40);
            this.MetadataGroupBox.Name = "MetadataGroupBox";
            this.MetadataGroupBox.Size = new System.Drawing.Size(404, 298);
            this.MetadataGroupBox.TabIndex = 4;
            this.MetadataGroupBox.TabStop = false;
            this.MetadataGroupBox.Text = "Metadata";
            // 
            // EncryptedCheckBox
            // 
            this.EncryptedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EncryptedCheckBox.AutoSize = true;
            this.EncryptedCheckBox.Location = new System.Drawing.Point(283, 209);
            this.EncryptedCheckBox.Name = "EncryptedCheckBox";
            this.EncryptedCheckBox.Size = new System.Drawing.Size(112, 17);
            this.EncryptedCheckBox.TabIndex = 19;
            this.EncryptedCheckBox.Text = "Encrypted Format";
            this.EncryptedCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EncryptedCheckBox.UseVisualStyleBackColor = true;
            this.EncryptedCheckBox.CheckedChanged += new System.EventHandler(this.OnMetaFieldTextChanged);
            // 
            // EncodingDropDown
            // 
            this.EncodingDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EncodingDropDown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodingDropDown.FormattingEnabled = true;
            this.EncodingDropDown.Items.AddRange(new object[] {
            "Latin",
            "Unicode",
            "Korean",
            "Chinese",
            "Japanese"});
            this.EncodingDropDown.Location = new System.Drawing.Point(308, 50);
            this.EncodingDropDown.Name = "EncodingDropDown";
            this.EncodingDropDown.Size = new System.Drawing.Size(79, 21);
            this.EncodingDropDown.TabIndex = 4;
            this.EncodingDropDown.SelectedIndexChanged += new System.EventHandler(this.OnEncodingDropDownSelectedIndexChanged);
            this.EncodingDropDown.TextChanged += new System.EventHandler(this.OnMetaFieldTextChanged);
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Enabled = false;
            this.ModeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeLabel.Location = new System.Drawing.Point(16, 187);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(33, 13);
            this.ModeLabel.TabIndex = 15;
            this.ModeLabel.Text = "Mode";
            this.ModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModeDropDown
            // 
            this.ModeDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModeDropDown.Enabled = false;
            this.ModeDropDown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeDropDown.FormattingEnabled = true;
            this.ModeDropDown.Items.AddRange(new object[] {
            "3K",
            "5K",
            "7K"});
            this.ModeDropDown.Location = new System.Drawing.Point(70, 182);
            this.ModeDropDown.Name = "ModeDropDown";
            this.ModeDropDown.Size = new System.Drawing.Size(318, 21);
            this.ModeDropDown.TabIndex = 16;
            this.ModeDropDown.SelectedIndexChanged += new System.EventHandler(this.OnModeDropDownSelectedIndexChanged);
            // 
            // IdTextBox
            // 
            this.IdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IdTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdTextBox.Location = new System.Drawing.Point(70, 23);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(317, 21);
            this.IdTextBox.TabIndex = 1;
            this.IdTextBox.TextChanged += new System.EventHandler(this.OnMetaFieldTextChanged);
            this.IdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnIdTextBoxKeypress);
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdLabel.Location = new System.Drawing.Point(16, 28);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(18, 13);
            this.IdLabel.TabIndex = 0;
            this.IdLabel.Text = "ID";
            this.IdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LevelsGroupBox
            // 
            this.LevelsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelsGroupBox.Controls.Add(this.HxLabel);
            this.LevelsGroupBox.Controls.Add(this.HxLevelNumericBox);
            this.LevelsGroupBox.Controls.Add(this.NxLabel);
            this.LevelsGroupBox.Controls.Add(this.NxLevelNumericBox);
            this.LevelsGroupBox.Controls.Add(this.ExLabel);
            this.LevelsGroupBox.Controls.Add(this.ExLevelNumericBox);
            this.LevelsGroupBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelsGroupBox.Location = new System.Drawing.Point(19, 232);
            this.LevelsGroupBox.Name = "LevelsGroupBox";
            this.LevelsGroupBox.Size = new System.Drawing.Size(369, 54);
            this.LevelsGroupBox.TabIndex = 17;
            this.LevelsGroupBox.TabStop = false;
            this.LevelsGroupBox.Text = "Levels";
            // 
            // HxLabel
            // 
            this.HxLabel.AutoSize = true;
            this.HxLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HxLabel.Location = new System.Drawing.Point(207, 25);
            this.HxLabel.Name = "HxLabel";
            this.HxLabel.Size = new System.Drawing.Size(20, 13);
            this.HxLabel.TabIndex = 15;
            this.HxLabel.Text = "Hx";
            this.HxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HxLevelNumericBox
            // 
            this.HxLevelNumericBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HxLevelNumericBox.Location = new System.Drawing.Point(232, 22);
            this.HxLevelNumericBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HxLevelNumericBox.Name = "HxLevelNumericBox";
            this.HxLevelNumericBox.Size = new System.Drawing.Size(59, 21);
            this.HxLevelNumericBox.TabIndex = 14;
            this.HxLevelNumericBox.ValueChanged += new System.EventHandler(this.OnHxLevelNumericBoxValueChanged);
            // 
            // NxLabel
            // 
            this.NxLabel.AutoSize = true;
            this.NxLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NxLabel.Location = new System.Drawing.Point(108, 25);
            this.NxLabel.Name = "NxLabel";
            this.NxLabel.Size = new System.Drawing.Size(20, 13);
            this.NxLabel.TabIndex = 13;
            this.NxLabel.Text = "Nx";
            this.NxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NxLevelNumericBox
            // 
            this.NxLevelNumericBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NxLevelNumericBox.Location = new System.Drawing.Point(133, 22);
            this.NxLevelNumericBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NxLevelNumericBox.Name = "NxLevelNumericBox";
            this.NxLevelNumericBox.Size = new System.Drawing.Size(59, 21);
            this.NxLevelNumericBox.TabIndex = 12;
            this.NxLevelNumericBox.ValueChanged += new System.EventHandler(this.OnNxLevelNumericBoxValueChanged);
            // 
            // ExLabel
            // 
            this.ExLabel.AutoSize = true;
            this.ExLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExLabel.Location = new System.Drawing.Point(9, 25);
            this.ExLabel.Name = "ExLabel";
            this.ExLabel.Size = new System.Drawing.Size(19, 13);
            this.ExLabel.TabIndex = 11;
            this.ExLabel.Text = "Ex";
            this.ExLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExLevelNumericBox
            // 
            this.ExLevelNumericBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExLevelNumericBox.Location = new System.Drawing.Point(34, 22);
            this.ExLevelNumericBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ExLevelNumericBox.Name = "ExLevelNumericBox";
            this.ExLevelNumericBox.Size = new System.Drawing.Size(59, 21);
            this.ExLevelNumericBox.TabIndex = 10;
            this.ExLevelNumericBox.ValueChanged += new System.EventHandler(this.OnExLevelNumericBoxValueChanged);
            // 
            // OJMTextBox
            // 
            this.OJMTextBox.AccessibleDescription = "";
            this.OJMTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OJMTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OJMTextBox.Location = new System.Drawing.Point(70, 155);
            this.OJMTextBox.Name = "OJMTextBox";
            this.OJMTextBox.Size = new System.Drawing.Size(318, 21);
            this.OJMTextBox.TabIndex = 14;
            this.OJMTextBox.TextChanged += new System.EventHandler(this.OnMetaFieldTextChanged);
            // 
            // OJMLabel
            // 
            this.OJMLabel.AutoSize = true;
            this.OJMLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OJMLabel.Location = new System.Drawing.Point(16, 160);
            this.OJMLabel.Name = "OJMLabel";
            this.OJMLabel.Size = new System.Drawing.Size(28, 13);
            this.OJMLabel.TabIndex = 13;
            this.OJMLabel.Text = "OJM";
            this.OJMLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BPMLabel
            // 
            this.BPMLabel.AutoSize = true;
            this.BPMLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPMLabel.Location = new System.Drawing.Point(215, 132);
            this.BPMLabel.Name = "BPMLabel";
            this.BPMLabel.Size = new System.Drawing.Size(27, 13);
            this.BPMLabel.TabIndex = 11;
            this.BPMLabel.Text = "BPM";
            this.BPMLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BPMNumericBox
            // 
            this.BPMNumericBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BPMNumericBox.DecimalPlaces = 2;
            this.BPMNumericBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPMNumericBox.Location = new System.Drawing.Point(248, 129);
            this.BPMNumericBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.BPMNumericBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BPMNumericBox.Name = "BPMNumericBox";
            this.BPMNumericBox.Size = new System.Drawing.Size(140, 21);
            this.BPMNumericBox.TabIndex = 12;
            this.BPMNumericBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BPMNumericBox.ValueChanged += new System.EventHandler(this.OnBPMNumericValueChanged);
            // 
            // GenreLabel
            // 
            this.GenreLabel.AutoSize = true;
            this.GenreLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreLabel.Location = new System.Drawing.Point(16, 134);
            this.GenreLabel.Name = "GenreLabel";
            this.GenreLabel.Size = new System.Drawing.Size(36, 13);
            this.GenreLabel.TabIndex = 9;
            this.GenreLabel.Text = "Genre";
            this.GenreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GenreDropdown
            // 
            this.GenreDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenreDropdown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreDropdown.FormattingEnabled = true;
            this.GenreDropdown.Items.AddRange(new object[] {
            "Ballad",
            "Rock",
            "Dance",
            "Techno",
            "HipHop",
            "Soul",
            "Jazz",
            "Funk",
            "Classical",
            "Traditional",
            "Etc"});
            this.GenreDropdown.Location = new System.Drawing.Point(70, 128);
            this.GenreDropdown.Name = "GenreDropdown";
            this.GenreDropdown.Size = new System.Drawing.Size(139, 21);
            this.GenreDropdown.TabIndex = 10;
            this.GenreDropdown.SelectedIndexChanged += new System.EventHandler(this.OnGenreDropdownValueChanged);
            // 
            // PatternTextBox
            // 
            this.PatternTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PatternTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatternTextBox.Location = new System.Drawing.Point(70, 102);
            this.PatternTextBox.Name = "PatternTextBox";
            this.PatternTextBox.Size = new System.Drawing.Size(318, 21);
            this.PatternTextBox.TabIndex = 8;
            this.PatternTextBox.TextChanged += new System.EventHandler(this.OnMetaFieldTextChanged);
            // 
            // PatternLabel
            // 
            this.PatternLabel.AutoSize = true;
            this.PatternLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatternLabel.Location = new System.Drawing.Point(16, 107);
            this.PatternLabel.Name = "PatternLabel";
            this.PatternLabel.Size = new System.Drawing.Size(43, 13);
            this.PatternLabel.TabIndex = 7;
            this.PatternLabel.Text = "Pattern";
            this.PatternLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ArtistTextBox
            // 
            this.ArtistTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArtistTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtistTextBox.Location = new System.Drawing.Point(70, 76);
            this.ArtistTextBox.Name = "ArtistTextBox";
            this.ArtistTextBox.Size = new System.Drawing.Size(317, 21);
            this.ArtistTextBox.TabIndex = 6;
            this.ArtistTextBox.TextChanged += new System.EventHandler(this.OnMetaFieldTextChanged);
            // 
            // ArtistLabel
            // 
            this.ArtistLabel.AutoSize = true;
            this.ArtistLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtistLabel.Location = new System.Drawing.Point(16, 81);
            this.ArtistLabel.Name = "ArtistLabel";
            this.ArtistLabel.Size = new System.Drawing.Size(33, 13);
            this.ArtistLabel.TabIndex = 5;
            this.ArtistLabel.Text = "Artist";
            this.ArtistLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleTextBox.Location = new System.Drawing.Point(70, 49);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(232, 21);
            this.TitleTextBox.TabIndex = 3;
            this.TitleTextBox.TextChanged += new System.EventHandler(this.OnMetaFieldTextChanged);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(16, 54);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(27, 13);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Title";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ThumbnailPictureBox
            // 
            this.ThumbnailPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ThumbnailPictureBox.Image = global::O2MusicList.Properties.Resources.Thumbnail;
            this.ThumbnailPictureBox.Location = new System.Drawing.Point(308, 20);
            this.ThumbnailPictureBox.Name = "ThumbnailPictureBox";
            this.ThumbnailPictureBox.Size = new System.Drawing.Size(80, 80);
            this.ThumbnailPictureBox.TabIndex = 18;
            this.ThumbnailPictureBox.TabStop = false;
            this.ThumbnailPictureBox.Visible = false;
            // 
            // MainStatusBar
            // 
            this.MainStatusBar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainStatusBar.Location = new System.Drawing.Point(0, 344);
            this.MainStatusBar.Name = "MainStatusBar";
            this.MainStatusBar.Size = new System.Drawing.Size(695, 22);
            this.MainStatusBar.TabIndex = 5;
            this.MainStatusBar.Text = "Ready";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 366);
            this.Controls.Add(this.MainStatusBar);
            this.Controls.Add(this.MetadataGroupBox);
            this.Controls.Add(this.MusicGroupBox);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.FileLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(645, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O2Jam Music List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormFormClosing);
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.MusicGroupBox.ResumeLayout(false);
            this.MusicGroupBox.PerformLayout();
            this.MetadataGroupBox.ResumeLayout(false);
            this.MetadataGroupBox.PerformLayout();
            this.LevelsGroupBox.ResumeLayout(false);
            this.LevelsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HxLevelNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NxLevelNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExLevelNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BPMNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu MainMenu;
        private System.Windows.Forms.MenuItem FileMenu;
        private System.Windows.Forms.MenuItem NewFileMenu;
        private System.Windows.Forms.MenuItem OpenFileMenu;
        private System.Windows.Forms.MenuItem MenuSeparator1;
        private System.Windows.Forms.MenuItem SaveFileMenu;
        private System.Windows.Forms.MenuItem SaveAsFileMenu;
        private System.Windows.Forms.MenuItem MenuSeparator2;
        private System.Windows.Forms.MenuItem PreferencesFileMenu;
        private System.Windows.Forms.MenuItem MenuSeparator3;
        private System.Windows.Forms.MenuItem ExitFileMenu;
        private System.Windows.Forms.MenuItem HelpMenu;
        private System.Windows.Forms.MenuItem AboutHelpMenu;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.GroupBox MusicGroupBox;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox MusicListBox;
        private System.Windows.Forms.GroupBox MetadataGroupBox;
        private System.Windows.Forms.TextBox PatternTextBox;
        private System.Windows.Forms.Label PatternLabel;
        private System.Windows.Forms.TextBox ArtistTextBox;
        private System.Windows.Forms.Label ArtistLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.StatusBar MainStatusBar;
        private System.Windows.Forms.TextBox OJMTextBox;
        private System.Windows.Forms.Label OJMLabel;
        private System.Windows.Forms.Label BPMLabel;
        private System.Windows.Forms.NumericUpDown BPMNumericBox;
        private System.Windows.Forms.Label GenreLabel;
        private System.Windows.Forms.ComboBox GenreDropdown;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.GroupBox LevelsGroupBox;
        private System.Windows.Forms.Label HxLabel;
        private System.Windows.Forms.NumericUpDown HxLevelNumericBox;
        private System.Windows.Forms.Label NxLabel;
        private System.Windows.Forms.NumericUpDown NxLevelNumericBox;
        private System.Windows.Forms.Label ExLabel;
        private System.Windows.Forms.NumericUpDown ExLevelNumericBox;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.ComboBox ModeDropDown;
        private System.Windows.Forms.ComboBox EncodingDropDown;
        private System.Windows.Forms.MenuItem ToolsMenu;
        private System.Windows.Forms.MenuItem ConvertToolsMenu;
        private System.Windows.Forms.ComboBox SortDropDown;
        private System.Windows.Forms.MenuItem EditMenu;
        private System.Windows.Forms.MenuItem AddEditMenu;
        private System.Windows.Forms.MenuItem RemoveEditMenu;
        private System.Windows.Forms.MenuItem MenuSeparator4;
        private System.Windows.Forms.MenuItem AutoCorrectKeyModeEditMenu;
        private System.Windows.Forms.MenuItem SynchronizeEditMenu;
        private System.Windows.Forms.MenuItem RemoveDuplicateEditMenu;
        private System.Windows.Forms.PictureBox ThumbnailPictureBox;
        private System.Windows.Forms.CheckBox EncryptedCheckBox;
    }
}

