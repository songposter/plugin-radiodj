namespace Plugin_SongPoster
{
    partial class SongPoster_Config
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongPoster_Config));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.groupBoxGeneral = new System.Windows.Forms.GroupBox();
            this.labelTrackTypes = new System.Windows.Forms.Label();
            this.listBoxTrackTypes = new System.Windows.Forms.ListBox();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelInterval = new System.Windows.Forms.Label();
            this.groupBoxCredentials = new System.Windows.Forms.GroupBox();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.labelUserId = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.checkBoxEnable = new System.Windows.Forms.CheckBox();
            this.panelWaitFor = new System.Windows.Forms.Panel();
            this.radioButtonWaitForPlayCount = new System.Windows.Forms.RadioButton();
            this.radioButtonWaitForTime = new System.Windows.Forms.RadioButton();
            this.listBoxNetworks1 = new System.Windows.Forms.ListBox();
            this.labelNetworks1 = new System.Windows.Forms.Label();
            this.tabWebExportPAL = new System.Windows.Forms.TabPage();
            this.groupBoxExportWebPAL = new System.Windows.Forms.GroupBox();
            this.textBoxPAL = new System.Windows.Forms.TextBox();
            this.labelBrowse = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.openFileDialogPAL = new System.Windows.Forms.OpenFileDialog();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBoxGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.groupBoxCredentials.SuspendLayout();
            this.panelWaitFor.SuspendLayout();
            this.tabWebExportPAL.SuspendLayout();
            this.groupBoxExportWebPAL.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabWebExportPAL);
            this.tabControl1.Location = new System.Drawing.Point(6, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(563, 463);
            this.tabControl1.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupBoxGeneral);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(555, 437);
            this.tabGeneral.TabIndex = 3;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBoxGeneral
            // 
            this.groupBoxGeneral.Controls.Add(this.labelTrackTypes);
            this.groupBoxGeneral.Controls.Add(this.listBoxTrackTypes);
            this.groupBoxGeneral.Controls.Add(this.numericUpDownInterval);
            this.groupBoxGeneral.Controls.Add(this.labelInterval);
            this.groupBoxGeneral.Controls.Add(this.groupBoxCredentials);
            this.groupBoxGeneral.Controls.Add(this.textBoxResult);
            this.groupBoxGeneral.Controls.Add(this.labelResult);
            this.groupBoxGeneral.Controls.Add(this.checkBoxEnable);
            this.groupBoxGeneral.Controls.Add(this.panelWaitFor);
            this.groupBoxGeneral.Controls.Add(this.listBoxNetworks1);
            this.groupBoxGeneral.Controls.Add(this.labelNetworks1);
            this.groupBoxGeneral.Location = new System.Drawing.Point(3, 3);
            this.groupBoxGeneral.Name = "groupBoxGeneral";
            this.groupBoxGeneral.Size = new System.Drawing.Size(549, 431);
            this.groupBoxGeneral.TabIndex = 0;
            this.groupBoxGeneral.TabStop = false;
            this.groupBoxGeneral.Text = "General settings";
            // 
            // labelTrackTypes
            // 
            this.labelTrackTypes.AutoSize = true;
            this.labelTrackTypes.Location = new System.Drawing.Point(6, 338);
            this.labelTrackTypes.Name = "labelTrackTypes";
            this.labelTrackTypes.Size = new System.Drawing.Size(171, 13);
            this.labelTrackTypes.TabIndex = 26;
            this.labelTrackTypes.Text = "Post only the selected TrackTypes";
            // 
            // listBoxTrackTypes
            // 
            this.listBoxTrackTypes.ColumnWidth = 100;
            this.listBoxTrackTypes.Location = new System.Drawing.Point(6, 354);
            this.listBoxTrackTypes.MultiColumn = true;
            this.listBoxTrackTypes.Name = "listBoxTrackTypes";
            this.listBoxTrackTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxTrackTypes.Size = new System.Drawing.Size(528, 43);
            this.listBoxTrackTypes.TabIndex = 25;
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownInterval.Location = new System.Drawing.Point(77, 236);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(457, 20);
            this.numericUpDownInterval.TabIndex = 24;
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(6, 238);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(42, 13);
            this.labelInterval.TabIndex = 23;
            this.labelInterval.Text = "Interval";
            // 
            // groupBoxCredentials
            // 
            this.groupBoxCredentials.Controls.Add(this.textBoxUserId);
            this.groupBoxCredentials.Controls.Add(this.labelUserId);
            this.groupBoxCredentials.Controls.Add(this.textBoxPassword);
            this.groupBoxCredentials.Controls.Add(this.labelPassword);
            this.groupBoxCredentials.Controls.Add(this.textBoxEmail);
            this.groupBoxCredentials.Controls.Add(this.labelEmail);
            this.groupBoxCredentials.Location = new System.Drawing.Point(6, 114);
            this.groupBoxCredentials.Name = "groupBoxCredentials";
            this.groupBoxCredentials.Size = new System.Drawing.Size(528, 112);
            this.groupBoxCredentials.TabIndex = 21;
            this.groupBoxCredentials.TabStop = false;
            this.groupBoxCredentials.Text = "SongPoster.net Credentials";
            this.groupBoxCredentials.Validating += new System.ComponentModel.CancelEventHandler(this.groupBoxCredentials_Validating);
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserId.Location = new System.Drawing.Point(71, 80);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.ReadOnly = true;
            this.textBoxUserId.Size = new System.Drawing.Size(451, 20);
            this.textBoxUserId.TabIndex = 22;
            // 
            // labelUserId
            // 
            this.labelUserId.AutoSize = true;
            this.labelUserId.Location = new System.Drawing.Point(4, 83);
            this.labelUserId.Name = "labelUserId";
            this.labelUserId.Size = new System.Drawing.Size(49, 13);
            this.labelUserId.TabIndex = 21;
            this.labelUserId.Text = "ID (Auto)";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(71, 53);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(451, 20);
            this.textBoxPassword.TabIndex = 20;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(4, 56);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 19;
            this.labelPassword.Text = "Password";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.Location = new System.Drawing.Point(71, 26);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(451, 20);
            this.textBoxEmail.TabIndex = 18;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(4, 29);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(36, 13);
            this.labelEmail.TabIndex = 17;
            this.labelEmail.Text = "E-Mail";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResult.AutoCompleteCustomSource.AddRange(new string[] {
            "$title$",
            "$artist$"});
            this.textBoxResult.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxResult.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxResult.Location = new System.Drawing.Point(148, 306);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(386, 20);
            this.textBoxResult.TabIndex = 20;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(6, 309);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(97, 13);
            this.labelResult.TabIndex = 19;
            this.labelResult.Text = "Message Template";
            // 
            // checkBoxEnable
            // 
            this.checkBoxEnable.AutoSize = true;
            this.checkBoxEnable.Checked = true;
            this.checkBoxEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnable.Location = new System.Drawing.Point(9, 20);
            this.checkBoxEnable.Name = "checkBoxEnable";
            this.checkBoxEnable.Size = new System.Drawing.Size(59, 17);
            this.checkBoxEnable.TabIndex = 18;
            this.checkBoxEnable.Text = "Enable";
            this.checkBoxEnable.UseVisualStyleBackColor = true;
            // 
            // panelWaitFor
            // 
            this.panelWaitFor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWaitFor.Controls.Add(this.radioButtonWaitForPlayCount);
            this.panelWaitFor.Controls.Add(this.radioButtonWaitForTime);
            this.panelWaitFor.Location = new System.Drawing.Point(6, 267);
            this.panelWaitFor.Name = "panelWaitFor";
            this.panelWaitFor.Size = new System.Drawing.Size(528, 28);
            this.panelWaitFor.TabIndex = 17;
            // 
            // radioButtonWaitForPlayCount
            // 
            this.radioButtonWaitForPlayCount.AutoSize = true;
            this.radioButtonWaitForPlayCount.Location = new System.Drawing.Point(180, 3);
            this.radioButtonWaitForPlayCount.Name = "radioButtonWaitForPlayCount";
            this.radioButtonWaitForPlayCount.Size = new System.Drawing.Size(210, 17);
            this.radioButtonWaitForPlayCount.TabIndex = 20;
            this.radioButtonWaitForPlayCount.TabStop = true;
            this.radioButtonWaitForPlayCount.Text = "By number of songs between two posts";
            this.radioButtonWaitForPlayCount.UseVisualStyleBackColor = true;
            // 
            // radioButtonWaitForTime
            // 
            this.radioButtonWaitForTime.AutoSize = true;
            this.radioButtonWaitForTime.Location = new System.Drawing.Point(6, 3);
            this.radioButtonWaitForTime.Name = "radioButtonWaitForTime";
            this.radioButtonWaitForTime.Size = new System.Drawing.Size(168, 17);
            this.radioButtonWaitForTime.TabIndex = 19;
            this.radioButtonWaitForTime.TabStop = true;
            this.radioButtonWaitForTime.Text = "By minutes between two posts";
            this.radioButtonWaitForTime.UseVisualStyleBackColor = true;
            // 
            // listBoxNetworks1
            // 
            this.listBoxNetworks1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxNetworks1.FormattingEnabled = true;
            this.listBoxNetworks1.Items.AddRange(new object[] {
            "Facebook",
            "Google",
            "Twitter"});
            this.listBoxNetworks1.Location = new System.Drawing.Point(6, 65);
            this.listBoxNetworks1.Name = "listBoxNetworks1";
            this.listBoxNetworks1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxNetworks1.Size = new System.Drawing.Size(528, 43);
            this.listBoxNetworks1.TabIndex = 10;
            // 
            // labelNetworks1
            // 
            this.labelNetworks1.AutoSize = true;
            this.labelNetworks1.Location = new System.Drawing.Point(6, 48);
            this.labelNetworks1.Name = "labelNetworks1";
            this.labelNetworks1.Size = new System.Drawing.Size(52, 13);
            this.labelNetworks1.TabIndex = 9;
            this.labelNetworks1.Text = "Networks";
            // 
            // tabWebExportPAL
            // 
            this.tabWebExportPAL.Controls.Add(this.groupBoxExportWebPAL);
            this.tabWebExportPAL.Location = new System.Drawing.Point(4, 22);
            this.tabWebExportPAL.Name = "tabWebExportPAL";
            this.tabWebExportPAL.Size = new System.Drawing.Size(555, 437);
            this.tabWebExportPAL.TabIndex = 2;
            this.tabWebExportPAL.Text = "AutoConfig (from PAL)";
            this.tabWebExportPAL.UseVisualStyleBackColor = true;
            // 
            // groupBoxExportWebPAL
            // 
            this.groupBoxExportWebPAL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxExportWebPAL.Controls.Add(this.textBoxPAL);
            this.groupBoxExportWebPAL.Controls.Add(this.labelBrowse);
            this.groupBoxExportWebPAL.Controls.Add(this.buttonBrowse);
            this.groupBoxExportWebPAL.Location = new System.Drawing.Point(6, 6);
            this.groupBoxExportWebPAL.Name = "groupBoxExportWebPAL";
            this.groupBoxExportWebPAL.Size = new System.Drawing.Size(546, 425);
            this.groupBoxExportWebPAL.TabIndex = 0;
            this.groupBoxExportWebPAL.TabStop = false;
            this.groupBoxExportWebPAL.Text = "Export to Web (using PAL)";
            // 
            // textBoxPAL
            // 
            this.textBoxPAL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPAL.Location = new System.Drawing.Point(6, 52);
            this.textBoxPAL.Multiline = true;
            this.textBoxPAL.Name = "textBoxPAL";
            this.textBoxPAL.ReadOnly = true;
            this.textBoxPAL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPAL.Size = new System.Drawing.Size(533, 367);
            this.textBoxPAL.TabIndex = 5;
            // 
            // labelBrowse
            // 
            this.labelBrowse.AutoSize = true;
            this.labelBrowse.Location = new System.Drawing.Point(6, 28);
            this.labelBrowse.Name = "labelBrowse";
            this.labelBrowse.Size = new System.Drawing.Size(154, 13);
            this.labelBrowse.TabIndex = 3;
            this.labelBrowse.Text = "Open .pal file from WebService";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(169, 23);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(120, 23);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.CausesValidation = false;
            this.buttonClose.Location = new System.Drawing.Point(490, 472);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // openFileDialogPAL
            // 
            this.openFileDialogPAL.Filter = "PAL Files|*.pal";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(409, 472);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // SongPoster_Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 506);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SongPoster_Config";
            this.Text = "SongPoster Config";
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.groupBoxGeneral.ResumeLayout(false);
            this.groupBoxGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.groupBoxCredentials.ResumeLayout(false);
            this.groupBoxCredentials.PerformLayout();
            this.panelWaitFor.ResumeLayout(false);
            this.panelWaitFor.PerformLayout();
            this.tabWebExportPAL.ResumeLayout(false);
            this.groupBoxExportWebPAL.ResumeLayout(false);
            this.groupBoxExportWebPAL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TabPage tabWebExportPAL;
        private System.Windows.Forms.GroupBox groupBoxExportWebPAL;
        private System.Windows.Forms.TextBox textBoxPAL;
        private System.Windows.Forms.Label labelBrowse;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialogPAL;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.GroupBox groupBoxGeneral;
        private System.Windows.Forms.ListBox listBoxNetworks1;
        private System.Windows.Forms.Label labelNetworks1;
        private System.Windows.Forms.Panel panelWaitFor;
        private System.Windows.Forms.RadioButton radioButtonWaitForPlayCount;
        private System.Windows.Forms.RadioButton radioButtonWaitForTime;
        private System.Windows.Forms.CheckBox checkBoxEnable;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.GroupBox groupBoxCredentials;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelTrackTypes;
        private System.Windows.Forms.ListBox listBoxTrackTypes;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.Label labelUserId;
    }
}

