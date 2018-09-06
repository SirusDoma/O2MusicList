namespace O2MusicList
{
    partial class PreferenceForm
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
            this.VersionDropDown = new System.Windows.Forms.ComboBox();
            this.EncodingDropDown = new System.Windows.Forms.ComboBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.CharsetEncodingGroupBox = new System.Windows.Forms.GroupBox();
            this.AutoEncodingDropDown = new System.Windows.Forms.CheckBox();
            this.BuildOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.PublishDatePicker = new System.Windows.Forms.DateTimePicker();
            this.AutoSynchronizeCheckBox = new System.Windows.Forms.CheckBox();
            this.PublishDateLabel = new System.Windows.Forms.Label();
            this.PreserveFormatCheckBox = new System.Windows.Forms.CheckBox();
            this.BuildModeDropDown = new System.Windows.Forms.ComboBox();
            this.LoadingOptimizationGroupBox = new System.Windows.Forms.GroupBox();
            this.AutoRemoveDuplicateCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoCorrectKeyMode = new System.Windows.Forms.CheckBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.KeyModeLabel = new System.Windows.Forms.Label();
            this.KeyModeDropDown = new System.Windows.Forms.ComboBox();
            this.CharsetEncodingGroupBox.SuspendLayout();
            this.BuildOptionsGroupBox.SuspendLayout();
            this.LoadingOptimizationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // VersionDropDown
            // 
            this.VersionDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VersionDropDown.FormattingEnabled = true;
            this.VersionDropDown.Items.AddRange(new object[] {
            "v1.8 Client",
            "v3.15 or newer Client"});
            this.VersionDropDown.Location = new System.Drawing.Point(6, 19);
            this.VersionDropDown.Name = "VersionDropDown";
            this.VersionDropDown.Size = new System.Drawing.Size(165, 21);
            this.VersionDropDown.TabIndex = 0;
            // 
            // EncodingDropDown
            // 
            this.EncodingDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EncodingDropDown.FormattingEnabled = true;
            this.EncodingDropDown.Items.AddRange(new object[] {
            "Latin",
            "Unicode",
            "Korean",
            "Chinese",
            "Japanese"});
            this.EncodingDropDown.Location = new System.Drawing.Point(6, 19);
            this.EncodingDropDown.Name = "EncodingDropDown";
            this.EncodingDropDown.Size = new System.Drawing.Size(248, 21);
            this.EncodingDropDown.TabIndex = 0;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(345, 197);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(92, 30);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OnOkButtonClick);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(443, 197);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(92, 30);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.OnCloseButtonClick);
            // 
            // CharsetEncodingGroupBox
            // 
            this.CharsetEncodingGroupBox.Controls.Add(this.AutoEncodingDropDown);
            this.CharsetEncodingGroupBox.Controls.Add(this.EncodingDropDown);
            this.CharsetEncodingGroupBox.Location = new System.Drawing.Point(12, 81);
            this.CharsetEncodingGroupBox.Name = "CharsetEncodingGroupBox";
            this.CharsetEncodingGroupBox.Size = new System.Drawing.Size(260, 72);
            this.CharsetEncodingGroupBox.TabIndex = 1;
            this.CharsetEncodingGroupBox.TabStop = false;
            this.CharsetEncodingGroupBox.Text = "Character Encoding";
            // 
            // AutoEncodingDropDown
            // 
            this.AutoEncodingDropDown.AutoSize = true;
            this.AutoEncodingDropDown.Location = new System.Drawing.Point(6, 46);
            this.AutoEncodingDropDown.Name = "AutoEncodingDropDown";
            this.AutoEncodingDropDown.Size = new System.Drawing.Size(228, 17);
            this.AutoEncodingDropDown.TabIndex = 1;
            this.AutoEncodingDropDown.Text = "Auto detect encoding from OJNList version";
            this.AutoEncodingDropDown.UseVisualStyleBackColor = true;
            this.AutoEncodingDropDown.CheckedChanged += new System.EventHandler(this.OnAutoEncodingDropDownCheckedChanged);
            // 
            // BuildOptionsGroupBox
            // 
            this.BuildOptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildOptionsGroupBox.Controls.Add(this.KeyModeDropDown);
            this.BuildOptionsGroupBox.Controls.Add(this.KeyModeLabel);
            this.BuildOptionsGroupBox.Controls.Add(this.VersionDropDown);
            this.BuildOptionsGroupBox.Controls.Add(this.PublishDatePicker);
            this.BuildOptionsGroupBox.Controls.Add(this.AutoSynchronizeCheckBox);
            this.BuildOptionsGroupBox.Controls.Add(this.PublishDateLabel);
            this.BuildOptionsGroupBox.Controls.Add(this.PreserveFormatCheckBox);
            this.BuildOptionsGroupBox.Controls.Add(this.BuildModeDropDown);
            this.BuildOptionsGroupBox.Location = new System.Drawing.Point(278, 12);
            this.BuildOptionsGroupBox.Name = "BuildOptionsGroupBox";
            this.BuildOptionsGroupBox.Size = new System.Drawing.Size(257, 177);
            this.BuildOptionsGroupBox.TabIndex = 2;
            this.BuildOptionsGroupBox.TabStop = false;
            this.BuildOptionsGroupBox.Text = "Build Options";
            // 
            // PublishDatePicker
            // 
            this.PublishDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PublishDatePicker.CustomFormat = "yyyy-MM-dd";
            this.PublishDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PublishDatePicker.Location = new System.Drawing.Point(6, 147);
            this.PublishDatePicker.Name = "PublishDatePicker";
            this.PublishDatePicker.Size = new System.Drawing.Size(245, 20);
            this.PublishDatePicker.TabIndex = 7;
            // 
            // AutoSynchronizeCheckBox
            // 
            this.AutoSynchronizeCheckBox.AutoSize = true;
            this.AutoSynchronizeCheckBox.Location = new System.Drawing.Point(6, 64);
            this.AutoSynchronizeCheckBox.Name = "AutoSynchronizeCheckBox";
            this.AutoSynchronizeCheckBox.Size = new System.Drawing.Size(178, 17);
            this.AutoSynchronizeCheckBox.TabIndex = 3;
            this.AutoSynchronizeCheckBox.Text = "Attempt to synchronize OJN files";
            this.AutoSynchronizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // PublishDateLabel
            // 
            this.PublishDateLabel.AutoSize = true;
            this.PublishDateLabel.Location = new System.Drawing.Point(3, 131);
            this.PublishDateLabel.Name = "PublishDateLabel";
            this.PublishDateLabel.Size = new System.Drawing.Size(67, 13);
            this.PublishDateLabel.TabIndex = 6;
            this.PublishDateLabel.Text = "Publish Date";
            // 
            // PreserveFormatCheckBox
            // 
            this.PreserveFormatCheckBox.AutoSize = true;
            this.PreserveFormatCheckBox.Location = new System.Drawing.Point(6, 46);
            this.PreserveFormatCheckBox.Name = "PreserveFormatCheckBox";
            this.PreserveFormatCheckBox.Size = new System.Drawing.Size(136, 17);
            this.PreserveFormatCheckBox.TabIndex = 2;
            this.PreserveFormatCheckBox.Text = "Preserve original format";
            this.PreserveFormatCheckBox.UseVisualStyleBackColor = true;
            this.PreserveFormatCheckBox.CheckedChanged += new System.EventHandler(this.OnPreserveFormatCheckBoxCheckedChanged);
            // 
            // BuildModeDropDown
            // 
            this.BuildModeDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildModeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BuildModeDropDown.FormattingEnabled = true;
            this.BuildModeDropDown.Items.AddRange(new object[] {
            "Full",
            "Compact"});
            this.BuildModeDropDown.Location = new System.Drawing.Point(177, 19);
            this.BuildModeDropDown.Name = "BuildModeDropDown";
            this.BuildModeDropDown.Size = new System.Drawing.Size(74, 21);
            this.BuildModeDropDown.TabIndex = 1;
            this.BuildModeDropDown.SelectedIndexChanged += new System.EventHandler(this.OnBuildModeDropDownSelectedIndexChanged);
            // 
            // LoadingOptimizationGroupBox
            // 
            this.LoadingOptimizationGroupBox.Controls.Add(this.AutoRemoveDuplicateCheckBox);
            this.LoadingOptimizationGroupBox.Controls.Add(this.AutoCorrectKeyMode);
            this.LoadingOptimizationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.LoadingOptimizationGroupBox.Name = "LoadingOptimizationGroupBox";
            this.LoadingOptimizationGroupBox.Size = new System.Drawing.Size(260, 63);
            this.LoadingOptimizationGroupBox.TabIndex = 0;
            this.LoadingOptimizationGroupBox.TabStop = false;
            this.LoadingOptimizationGroupBox.Text = "Loading Optimization";
            // 
            // AutoRemoveDuplicateCheckBox
            // 
            this.AutoRemoveDuplicateCheckBox.AutoSize = true;
            this.AutoRemoveDuplicateCheckBox.Location = new System.Drawing.Point(6, 38);
            this.AutoRemoveDuplicateCheckBox.Name = "AutoRemoveDuplicateCheckBox";
            this.AutoRemoveDuplicateCheckBox.Size = new System.Drawing.Size(172, 17);
            this.AutoRemoveDuplicateCheckBox.TabIndex = 2;
            this.AutoRemoveDuplicateCheckBox.Text = "Automatically remove duplicate";
            this.AutoRemoveDuplicateCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoCorrectKeyMode
            // 
            this.AutoCorrectKeyMode.AutoSize = true;
            this.AutoCorrectKeyMode.Location = new System.Drawing.Point(6, 19);
            this.AutoCorrectKeyMode.Name = "AutoCorrectKeyMode";
            this.AutoCorrectKeyMode.Size = new System.Drawing.Size(148, 17);
            this.AutoCorrectKeyMode.TabIndex = 1;
            this.AutoCorrectKeyMode.Text = "Autocorrect the key mode";
            this.AutoCorrectKeyMode.UseVisualStyleBackColor = true;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(12, 159);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(260, 30);
            this.ResetButton.TabIndex = 5;
            this.ResetButton.Text = "Default Settings";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.OnResetButtonClick);
            // 
            // KeyModeLabel
            // 
            this.KeyModeLabel.AutoSize = true;
            this.KeyModeLabel.Location = new System.Drawing.Point(3, 87);
            this.KeyModeLabel.Name = "KeyModeLabel";
            this.KeyModeLabel.Size = new System.Drawing.Size(95, 13);
            this.KeyModeLabel.TabIndex = 4;
            this.KeyModeLabel.Text = "Enforce Key Mode";
            // 
            // KeyModeDropDown
            // 
            this.KeyModeDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyModeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyModeDropDown.FormattingEnabled = true;
            this.KeyModeDropDown.Items.AddRange(new object[] {
            "Default",
            "7K",
            "5K",
            "3K"});
            this.KeyModeDropDown.Location = new System.Drawing.Point(6, 103);
            this.KeyModeDropDown.Name = "KeyModeDropDown";
            this.KeyModeDropDown.Size = new System.Drawing.Size(245, 21);
            this.KeyModeDropDown.TabIndex = 5;
            // 
            // PreferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 239);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.LoadingOptimizationGroupBox);
            this.Controls.Add(this.BuildOptionsGroupBox);
            this.Controls.Add(this.CharsetEncodingGroupBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.OnPreferenceFormLoad);
            this.CharsetEncodingGroupBox.ResumeLayout(false);
            this.CharsetEncodingGroupBox.PerformLayout();
            this.BuildOptionsGroupBox.ResumeLayout(false);
            this.BuildOptionsGroupBox.PerformLayout();
            this.LoadingOptimizationGroupBox.ResumeLayout(false);
            this.LoadingOptimizationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox VersionDropDown;
        private System.Windows.Forms.ComboBox EncodingDropDown;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox CharsetEncodingGroupBox;
        private System.Windows.Forms.GroupBox BuildOptionsGroupBox;
        private System.Windows.Forms.CheckBox PreserveFormatCheckBox;
        private System.Windows.Forms.ComboBox BuildModeDropDown;
        private System.Windows.Forms.DateTimePicker PublishDatePicker;
        private System.Windows.Forms.Label PublishDateLabel;
        private System.Windows.Forms.CheckBox AutoEncodingDropDown;
        private System.Windows.Forms.GroupBox LoadingOptimizationGroupBox;
        private System.Windows.Forms.CheckBox AutoCorrectKeyMode;
        private System.Windows.Forms.CheckBox AutoSynchronizeCheckBox;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.CheckBox AutoRemoveDuplicateCheckBox;
        private System.Windows.Forms.Label KeyModeLabel;
        private System.Windows.Forms.ComboBox KeyModeDropDown;
    }
}