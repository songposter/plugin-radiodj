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
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.labelUserId = new System.Windows.Forms.Label();
            this.listBoxNetworks1 = new System.Windows.Forms.ListBox();
            this.labelNetworks1 = new System.Windows.Forms.Label();
            this.tabWebExport = new System.Windows.Forms.TabPage();
            this.groupBoxWebExport = new System.Windows.Forms.GroupBox();
            this.checkBoxEnable = new System.Windows.Forms.CheckBox();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.textBoxCustomData = new System.Windows.Forms.TextBox();
            this.labelMethod = new System.Windows.Forms.Label();
            this.labelCustomData = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.labelURL = new System.Windows.Forms.Label();
            this.tabWebExportPAL = new System.Windows.Forms.TabPage();
            this.groupBoxExportWebPAL = new System.Windows.Forms.GroupBox();
            this.checkBoxUsePAL = new System.Windows.Forms.CheckBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.textBoxPAL = new System.Windows.Forms.TextBox();
            this.labelBrowse = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.openFileDialogPAL = new System.Windows.Forms.OpenFileDialog();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBoxGeneral.SuspendLayout();
            this.tabWebExport.SuspendLayout();
            this.groupBoxWebExport.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabWebExport);
            this.tabControl1.Controls.Add(this.tabWebExportPAL);
            this.tabControl1.Location = new System.Drawing.Point(6, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(563, 463);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
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
            this.groupBoxGeneral.Controls.Add(this.textBoxPassword);
            this.groupBoxGeneral.Controls.Add(this.labelPassword);
            this.groupBoxGeneral.Controls.Add(this.textBoxUserId);
            this.groupBoxGeneral.Controls.Add(this.labelUserId);
            this.groupBoxGeneral.Controls.Add(this.listBoxNetworks1);
            this.groupBoxGeneral.Controls.Add(this.labelNetworks1);
            this.groupBoxGeneral.Location = new System.Drawing.Point(3, 3);
            this.groupBoxGeneral.Name = "groupBoxGeneral";
            this.groupBoxGeneral.Size = new System.Drawing.Size(549, 431);
            this.groupBoxGeneral.TabIndex = 0;
            this.groupBoxGeneral.TabStop = false;
            this.groupBoxGeneral.Text = "General settings";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(77, 122);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(457, 20);
            this.textBoxPassword.TabIndex = 14;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 125);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 13;
            this.labelPassword.Text = "Password";
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserId.Location = new System.Drawing.Point(77, 95);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(457, 20);
            this.textBoxUserId.TabIndex = 12;
            // 
            // labelUserId
            // 
            this.labelUserId.AutoSize = true;
            this.labelUserId.Location = new System.Drawing.Point(6, 98);
            this.labelUserId.Name = "labelUserId";
            this.labelUserId.Size = new System.Drawing.Size(40, 13);
            this.labelUserId.TabIndex = 11;
            this.labelUserId.Text = "UserID";
            // 
            // listBoxNetworks1
            // 
            this.listBoxNetworks1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxNetworks1.FormattingEnabled = true;
            this.listBoxNetworks1.Items.AddRange(new object[] {
            "Facebook",
            "Google+",
            "Twitter"});
            this.listBoxNetworks1.Location = new System.Drawing.Point(6, 33);
            this.listBoxNetworks1.Name = "listBoxNetworks1";
            this.listBoxNetworks1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxNetworks1.Size = new System.Drawing.Size(528, 56);
            this.listBoxNetworks1.TabIndex = 10;
            // 
            // labelNetworks1
            // 
            this.labelNetworks1.AutoSize = true;
            this.labelNetworks1.Location = new System.Drawing.Point(6, 16);
            this.labelNetworks1.Name = "labelNetworks1";
            this.labelNetworks1.Size = new System.Drawing.Size(52, 13);
            this.labelNetworks1.TabIndex = 9;
            this.labelNetworks1.Text = "Networks";
            // 
            // tabWebExport
            // 
            this.tabWebExport.Controls.Add(this.groupBoxWebExport);
            this.tabWebExport.Enabled = false;
            this.tabWebExport.Location = new System.Drawing.Point(4, 22);
            this.tabWebExport.Name = "tabWebExport";
            this.tabWebExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabWebExport.Size = new System.Drawing.Size(555, 437);
            this.tabWebExport.TabIndex = 1;
            this.tabWebExport.Text = "Web (Manual)";
            this.tabWebExport.UseVisualStyleBackColor = true;
            // 
            // groupBoxWebExport
            // 
            this.groupBoxWebExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWebExport.Controls.Add(this.checkBoxEnable);
            this.groupBoxWebExport.Controls.Add(this.comboBoxMethod);
            this.groupBoxWebExport.Controls.Add(this.textBoxCustomData);
            this.groupBoxWebExport.Controls.Add(this.labelMethod);
            this.groupBoxWebExport.Controls.Add(this.labelCustomData);
            this.groupBoxWebExport.Controls.Add(this.textBoxURL);
            this.groupBoxWebExport.Controls.Add(this.labelURL);
            this.groupBoxWebExport.Location = new System.Drawing.Point(6, 6);
            this.groupBoxWebExport.Name = "groupBoxWebExport";
            this.groupBoxWebExport.Size = new System.Drawing.Size(541, 429);
            this.groupBoxWebExport.TabIndex = 0;
            this.groupBoxWebExport.TabStop = false;
            this.groupBoxWebExport.Text = "Export to Web";
            // 
            // checkBoxEnable
            // 
            this.checkBoxEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEnable.AutoCheck = false;
            this.checkBoxEnable.AutoSize = true;
            this.checkBoxEnable.Location = new System.Drawing.Point(6, 92);
            this.checkBoxEnable.Name = "checkBoxEnable";
            this.checkBoxEnable.Size = new System.Drawing.Size(59, 17);
            this.checkBoxEnable.TabIndex = 6;
            this.checkBoxEnable.Text = "Enable";
            this.checkBoxEnable.UseVisualStyleBackColor = true;
            this.checkBoxEnable.Click += new System.EventHandler(this.checkBox_Click);
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMethod.FormattingEnabled = true;
            this.comboBoxMethod.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.comboBoxMethod.Location = new System.Drawing.Point(77, 65);
            this.comboBoxMethod.Name = "comboBoxMethod";
            this.comboBoxMethod.Size = new System.Drawing.Size(457, 21);
            this.comboBoxMethod.TabIndex = 5;
            // 
            // textBoxCustomData
            // 
            this.textBoxCustomData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCustomData.Location = new System.Drawing.Point(77, 39);
            this.textBoxCustomData.Name = "textBoxCustomData";
            this.textBoxCustomData.Size = new System.Drawing.Size(457, 20);
            this.textBoxCustomData.TabIndex = 4;
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.Location = new System.Drawing.Point(6, 68);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(43, 13);
            this.labelMethod.TabIndex = 3;
            this.labelMethod.Text = "Method";
            // 
            // labelCustomData
            // 
            this.labelCustomData.AutoSize = true;
            this.labelCustomData.Location = new System.Drawing.Point(6, 42);
            this.labelCustomData.Name = "labelCustomData";
            this.labelCustomData.Size = new System.Drawing.Size(68, 13);
            this.labelCustomData.TabIndex = 2;
            this.labelCustomData.Text = "Custom Data";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxURL.Location = new System.Drawing.Point(77, 13);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(457, 20);
            this.textBoxURL.TabIndex = 1;
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(6, 16);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(29, 13);
            this.labelURL.TabIndex = 0;
            this.labelURL.Text = "URL";
            // 
            // tabWebExportPAL
            // 
            this.tabWebExportPAL.Controls.Add(this.groupBoxExportWebPAL);
            this.tabWebExportPAL.Location = new System.Drawing.Point(4, 22);
            this.tabWebExportPAL.Name = "tabWebExportPAL";
            this.tabWebExportPAL.Size = new System.Drawing.Size(555, 437);
            this.tabWebExportPAL.TabIndex = 2;
            this.tabWebExportPAL.Text = "Web (PAL)";
            this.tabWebExportPAL.UseVisualStyleBackColor = true;
            // 
            // groupBoxExportWebPAL
            // 
            this.groupBoxExportWebPAL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxExportWebPAL.Controls.Add(this.checkBoxUsePAL);
            this.groupBoxExportWebPAL.Controls.Add(this.textBoxResult);
            this.groupBoxExportWebPAL.Controls.Add(this.labelResult);
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
            // checkBoxUsePAL
            // 
            this.checkBoxUsePAL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxUsePAL.AutoCheck = false;
            this.checkBoxUsePAL.AutoSize = true;
            this.checkBoxUsePAL.Location = new System.Drawing.Point(6, 313);
            this.checkBoxUsePAL.Name = "checkBoxUsePAL";
            this.checkBoxUsePAL.Size = new System.Drawing.Size(59, 17);
            this.checkBoxUsePAL.TabIndex = 11;
            this.checkBoxUsePAL.Text = "Enable";
            this.checkBoxUsePAL.UseVisualStyleBackColor = true;
            this.checkBoxUsePAL.Click += new System.EventHandler(this.checkBox_Click);
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
            this.textBoxResult.Location = new System.Drawing.Point(49, 287);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(490, 20);
            this.textBoxResult.TabIndex = 8;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(6, 290);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(37, 13);
            this.labelResult.TabIndex = 7;
            this.labelResult.Text = "Result";
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
            this.textBoxPAL.Size = new System.Drawing.Size(533, 229);
            this.textBoxPAL.TabIndex = 5;
            // 
            // labelBrowse
            // 
            this.labelBrowse.AutoSize = true;
            this.labelBrowse.Location = new System.Drawing.Point(6, 28);
            this.labelBrowse.Name = "labelBrowse";
            this.labelBrowse.Size = new System.Drawing.Size(117, 13);
            this.labelBrowse.TabIndex = 3;
            this.labelBrowse.Text = "Select PAL as template";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(129, 23);
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
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SongPoster_Config_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.groupBoxGeneral.ResumeLayout(false);
            this.groupBoxGeneral.PerformLayout();
            this.tabWebExport.ResumeLayout(false);
            this.groupBoxWebExport.ResumeLayout(false);
            this.groupBoxWebExport.PerformLayout();
            this.tabWebExportPAL.ResumeLayout(false);
            this.groupBoxExportWebPAL.ResumeLayout(false);
            this.groupBoxExportWebPAL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabWebExport;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBoxWebExport;
        private System.Windows.Forms.CheckBox checkBoxEnable;
        private System.Windows.Forms.ComboBox comboBoxMethod;
        private System.Windows.Forms.TextBox textBoxCustomData;
        private System.Windows.Forms.Label labelMethod;
        private System.Windows.Forms.Label labelCustomData;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.TabPage tabWebExportPAL;
        private System.Windows.Forms.GroupBox groupBoxExportWebPAL;
        private System.Windows.Forms.TextBox textBoxPAL;
        private System.Windows.Forms.Label labelBrowse;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialogPAL;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.CheckBox checkBoxUsePAL;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.GroupBox groupBoxGeneral;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.Label labelUserId;
        private System.Windows.Forms.ListBox listBoxNetworks1;
        private System.Windows.Forms.Label labelNetworks1;
    }
}

