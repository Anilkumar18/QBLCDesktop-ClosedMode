namespace LabelConnector
{
    partial class LabelConnectorSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelConnectorSettings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbNotRunning = new System.Windows.Forms.GroupBox();
            this.rbRunModeLater = new System.Windows.Forms.RadioButton();
            this.rbRunModeYes = new System.Windows.Forms.RadioButton();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_mode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbVersion = new System.Windows.Forms.ComboBox();
            this.lblQBversion = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.txt_filenm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbPersonalData = new System.Windows.Forms.GroupBox();
            this.rbPersonalDataLater = new System.Windows.Forms.RadioButton();
            this.rbPersonalDataNo = new System.Windows.Forms.RadioButton();
            this.rbPersonalDataYes = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbConnectionType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbNotRunning.SuspendLayout();
            this.gbPersonalData.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.gbNotRunning);
            this.panel1.Controls.Add(this.btnTestConnection);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cb_mode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbVersion);
            this.panel1.Controls.Add(this.lblQBversion);
            this.panel1.Controls.Add(this.btn_browse);
            this.panel1.Controls.Add(this.txt_filenm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 214);
            this.panel1.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(413, 175);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 32);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gbNotRunning
            // 
            this.gbNotRunning.Controls.Add(this.rbRunModeLater);
            this.gbNotRunning.Controls.Add(this.rbRunModeYes);
            this.gbNotRunning.Location = new System.Drawing.Point(167, 124);
            this.gbNotRunning.Name = "gbNotRunning";
            this.gbNotRunning.Size = new System.Drawing.Size(206, 44);
            this.gbNotRunning.TabIndex = 19;
            this.gbNotRunning.TabStop = false;
            // 
            // rbRunModeLater
            // 
            this.rbRunModeLater.AutoSize = true;
            this.rbRunModeLater.Location = new System.Drawing.Point(66, 19);
            this.rbRunModeLater.Name = "rbRunModeLater";
            this.rbRunModeLater.Size = new System.Drawing.Size(82, 17);
            this.rbRunModeLater.TabIndex = 17;
            this.rbRunModeLater.Text = "Select Later";
            this.rbRunModeLater.UseVisualStyleBackColor = true;
            // 
            // rbRunModeYes
            // 
            this.rbRunModeYes.AutoSize = true;
            this.rbRunModeYes.Checked = true;
            this.rbRunModeYes.Location = new System.Drawing.Point(6, 19);
            this.rbRunModeYes.Name = "rbRunModeYes";
            this.rbRunModeYes.Size = new System.Drawing.Size(43, 17);
            this.rbRunModeYes.TabIndex = 16;
            this.rbRunModeYes.TabStop = true;
            this.rbRunModeYes.Text = "Yes";
            this.rbRunModeYes.UseVisualStyleBackColor = true;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(293, 174);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(112, 32);
            this.btnTestConnection.TabIndex = 17;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(212, 174);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 32);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 44);
            this.label5.TabIndex = 10;
            this.label5.Text = "Allow LabelConnector to access company file even if QuickBooks is not running:";
            // 
            // cb_mode
            // 
            this.cb_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mode.FormattingEnabled = true;
            this.cb_mode.Items.AddRange(new object[] {
            "Single-User",
            "Multi-User"});
            this.cb_mode.Location = new System.Drawing.Point(167, 93);
            this.cb_mode.Name = "cb_mode";
            this.cb_mode.Size = new System.Drawing.Size(287, 21);
            this.cb_mode.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "QuickBooks File Mode  *";
            // 
            // cbVersion
            // 
            this.cbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVersion.FormattingEnabled = true;
            this.cbVersion.Items.AddRange(new object[] {
            "QuickBooks Premier version 2005 and above"});
            this.cbVersion.Location = new System.Drawing.Point(167, 56);
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.Size = new System.Drawing.Size(287, 21);
            this.cbVersion.TabIndex = 4;
            // 
            // lblQBversion
            // 
            this.lblQBversion.AutoSize = true;
            this.lblQBversion.Location = new System.Drawing.Point(9, 59);
            this.lblQBversion.Name = "lblQBversion";
            this.lblQBversion.Size = new System.Drawing.Size(103, 13);
            this.lblQBversion.TabIndex = 3;
            this.lblQBversion.Text = "QuickBooks Version";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(461, 17);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(27, 23);
            this.btn_browse.TabIndex = 2;
            this.btn_browse.Text = "...";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // txt_filenm
            // 
            this.txt_filenm.Location = new System.Drawing.Point(167, 19);
            this.txt_filenm.Name = "txt_filenm";
            this.txt_filenm.Size = new System.Drawing.Size(287, 20);
            this.txt_filenm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "QuickBooks Company File  *";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gbPersonalData
            // 
            this.gbPersonalData.Controls.Add(this.rbPersonalDataLater);
            this.gbPersonalData.Controls.Add(this.rbPersonalDataNo);
            this.gbPersonalData.Controls.Add(this.rbPersonalDataYes);
            this.gbPersonalData.Location = new System.Drawing.Point(187, 153);
            this.gbPersonalData.Name = "gbPersonalData";
            this.gbPersonalData.Size = new System.Drawing.Size(206, 51);
            this.gbPersonalData.TabIndex = 22;
            this.gbPersonalData.TabStop = false;
            // 
            // rbPersonalDataLater
            // 
            this.rbPersonalDataLater.AutoSize = true;
            this.rbPersonalDataLater.Location = new System.Drawing.Point(66, 19);
            this.rbPersonalDataLater.Name = "rbPersonalDataLater";
            this.rbPersonalDataLater.Size = new System.Drawing.Size(82, 17);
            this.rbPersonalDataLater.TabIndex = 16;
            this.rbPersonalDataLater.TabStop = true;
            this.rbPersonalDataLater.Text = "Select Later";
            this.rbPersonalDataLater.UseVisualStyleBackColor = true;
            // 
            // rbPersonalDataNo
            // 
            this.rbPersonalDataNo.AutoSize = true;
            this.rbPersonalDataNo.Location = new System.Drawing.Point(154, 19);
            this.rbPersonalDataNo.Name = "rbPersonalDataNo";
            this.rbPersonalDataNo.Size = new System.Drawing.Size(39, 17);
            this.rbPersonalDataNo.TabIndex = 15;
            this.rbPersonalDataNo.TabStop = true;
            this.rbPersonalDataNo.Text = "No";
            this.rbPersonalDataNo.UseVisualStyleBackColor = true;
            // 
            // rbPersonalDataYes
            // 
            this.rbPersonalDataYes.AutoSize = true;
            this.rbPersonalDataYes.Location = new System.Drawing.Point(6, 19);
            this.rbPersonalDataYes.Name = "rbPersonalDataYes";
            this.rbPersonalDataYes.Size = new System.Drawing.Size(43, 17);
            this.rbPersonalDataYes.TabIndex = 14;
            this.rbPersonalDataYes.TabStop = true;
            this.rbPersonalDataYes.Text = "Yes";
            this.rbPersonalDataYes.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(29, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 28);
            this.label4.TabIndex = 21;
            this.label4.Text = "Allow LabelConnector to access personal data:";
            // 
            // cmbConnectionType
            // 
            this.cmbConnectionType.FormattingEnabled = true;
            this.cmbConnectionType.Items.AddRange(new object[] {
            "Local File",
            "Remote File"});
            this.cmbConnectionType.Location = new System.Drawing.Point(187, 126);
            this.cmbConnectionType.Name = "cmbConnectionType";
            this.cmbConnectionType.Size = new System.Drawing.Size(287, 21);
            this.cmbConnectionType.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "QuickBooks Connection Type";
            // 
            // LabelConnectorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 224);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbPersonalData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbConnectionType);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LabelConnectorSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accuware - Label Connector";
            this.Load += new System.EventHandler(this.LabelConnectorSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbNotRunning.ResumeLayout(false);
            this.gbNotRunning.PerformLayout();
            this.gbPersonalData.ResumeLayout(false);
            this.gbPersonalData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_filenm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_mode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbVersion;
        private System.Windows.Forms.Label lblQBversion;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbNotRunning;
        private System.Windows.Forms.RadioButton rbRunModeLater;
        private System.Windows.Forms.RadioButton rbRunModeYes;
        private System.Windows.Forms.GroupBox gbPersonalData;
        private System.Windows.Forms.RadioButton rbPersonalDataLater;
        private System.Windows.Forms.RadioButton rbPersonalDataNo;
        private System.Windows.Forms.RadioButton rbPersonalDataYes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbConnectionType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
    }
}