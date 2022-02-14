namespace LabelConnector
{
    partial class FrmItemListSettingcs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemListSettingcs));
            this.btnSyncItem = new System.Windows.Forms.Button();
            this.chkInvItem = new System.Windows.Forms.CheckBox();
            this.chkassembly = new System.Windows.Forms.CheckBox();
            this.chknoninventory = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkgroupitem = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSyncItemDate = new System.Windows.Forms.Label();
            this.poqtypanel = new System.Windows.Forms.Panel();
            this.rdoPrintOneQty = new System.Windows.Forms.RadioButton();
            this.rdoPrintItemQty = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLotColumn = new System.Windows.Forms.TextBox();
            this.lblcolname = new System.Windows.Forms.Label();
            this.btnPrintOption = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFTPSave = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLoginID = new System.Windows.Forms.TextBox();
            this.txtFTPServerPath = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblFTPServerPath = new System.Windows.Forms.Label();
            this.drpitemcustomfield = new System.Windows.Forms.ComboBox();
            this.lblitemcustomfield = new System.Windows.Forms.Label();
            this.btnSyncCustom = new System.Windows.Forms.Button();
            this.btncustomfieldsave = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.poqtypanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSyncItem
            // 
            this.btnSyncItem.Location = new System.Drawing.Point(755, 39);
            this.btnSyncItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnSyncItem.Name = "btnSyncItem";
            this.btnSyncItem.Size = new System.Drawing.Size(155, 42);
            this.btnSyncItem.TabIndex = 0;
            this.btnSyncItem.Text = "Sync Items";
            this.btnSyncItem.UseVisualStyleBackColor = true;
            this.btnSyncItem.Click += new System.EventHandler(this.btnSyncItem_Click);
            // 
            // chkInvItem
            // 
            this.chkInvItem.AutoSize = true;
            this.chkInvItem.Location = new System.Drawing.Point(31, 28);
            this.chkInvItem.Margin = new System.Windows.Forms.Padding(4);
            this.chkInvItem.Name = "chkInvItem";
            this.chkInvItem.Size = new System.Drawing.Size(118, 21);
            this.chkInvItem.TabIndex = 1;
            this.chkInvItem.Text = "Inventory Item";
            this.chkInvItem.UseVisualStyleBackColor = true;
            // 
            // chkassembly
            // 
            this.chkassembly.AutoSize = true;
            this.chkassembly.Location = new System.Drawing.Point(196, 28);
            this.chkassembly.Margin = new System.Windows.Forms.Padding(4);
            this.chkassembly.Name = "chkassembly";
            this.chkassembly.Size = new System.Drawing.Size(120, 21);
            this.chkassembly.TabIndex = 2;
            this.chkassembly.Text = "Assembly Item";
            this.chkassembly.UseVisualStyleBackColor = true;
            // 
            // chknoninventory
            // 
            this.chknoninventory.AutoSize = true;
            this.chknoninventory.Location = new System.Drawing.Point(364, 28);
            this.chknoninventory.Margin = new System.Windows.Forms.Padding(4);
            this.chknoninventory.Name = "chknoninventory";
            this.chknoninventory.Size = new System.Drawing.Size(119, 21);
            this.chknoninventory.TabIndex = 3;
            this.chknoninventory.Text = "Non-Inventory";
            this.chknoninventory.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkgroupitem);
            this.panel1.Controls.Add(this.chkInvItem);
            this.panel1.Controls.Add(this.chknoninventory);
            this.panel1.Controls.Add(this.chkassembly);
            this.panel1.Location = new System.Drawing.Point(57, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 74);
            this.panel1.TabIndex = 4;
            // 
            // chkgroupitem
            // 
            this.chkgroupitem.AutoSize = true;
            this.chkgroupitem.Location = new System.Drawing.Point(533, 28);
            this.chkgroupitem.Margin = new System.Windows.Forms.Padding(4);
            this.chkgroupitem.Name = "chkgroupitem";
            this.chkgroupitem.Size = new System.Drawing.Size(100, 21);
            this.chkgroupitem.TabIndex = 9;
            this.chkgroupitem.Text = "Group Item";
            this.chkgroupitem.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(377, 662);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(155, 42);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnSyncItem);
            this.groupBox1.Location = new System.Drawing.Point(29, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(931, 111);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sync Items";
            // 
            // lblSyncItemDate
            // 
            this.lblSyncItemDate.AutoSize = true;
            this.lblSyncItemDate.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyncItemDate.Location = new System.Drawing.Point(37, 145);
            this.lblSyncItemDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSyncItemDate.Name = "lblSyncItemDate";
            this.lblSyncItemDate.Size = new System.Drawing.Size(44, 17);
            this.lblSyncItemDate.TabIndex = 8;
            this.lblSyncItemDate.Text = "label1";
            // 
            // poqtypanel
            // 
            this.poqtypanel.Controls.Add(this.rdoPrintOneQty);
            this.poqtypanel.Controls.Add(this.rdoPrintItemQty);
            this.poqtypanel.Location = new System.Drawing.Point(54, 46);
            this.poqtypanel.Margin = new System.Windows.Forms.Padding(4);
            this.poqtypanel.Name = "poqtypanel";
            this.poqtypanel.Size = new System.Drawing.Size(568, 63);
            this.poqtypanel.TabIndex = 20;
            // 
            // rdoPrintOneQty
            // 
            this.rdoPrintOneQty.AutoSize = true;
            this.rdoPrintOneQty.Checked = true;
            this.rdoPrintOneQty.Location = new System.Drawing.Point(31, 18);
            this.rdoPrintOneQty.Margin = new System.Windows.Forms.Padding(4);
            this.rdoPrintOneQty.Name = "rdoPrintOneQty";
            this.rdoPrintOneQty.Size = new System.Drawing.Size(177, 21);
            this.rdoPrintOneQty.TabIndex = 4;
            this.rdoPrintOneQty.TabStop = true;
            this.rdoPrintOneQty.Text = "Print 1 Label by Default";
            this.rdoPrintOneQty.UseVisualStyleBackColor = true;
            // 
            // rdoPrintItemQty
            // 
            this.rdoPrintItemQty.AutoSize = true;
            this.rdoPrintItemQty.Location = new System.Drawing.Point(281, 18);
            this.rdoPrintItemQty.Margin = new System.Windows.Forms.Padding(4);
            this.rdoPrintItemQty.Name = "rdoPrintItemQty";
            this.rdoPrintItemQty.Size = new System.Drawing.Size(273, 21);
            this.rdoPrintItemQty.TabIndex = 3;
            this.rdoPrintItemQty.Text = "Print By Item Qty (On Hand) by Default";
            this.rdoPrintItemQty.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtLotColumn);
            this.groupBox2.Controls.Add(this.lblcolname);
            this.groupBox2.Controls.Add(this.poqtypanel);
            this.groupBox2.Controls.Add(this.btnPrintOption);
            this.groupBox2.Location = new System.Drawing.Point(28, 268);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(931, 175);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print By";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Please select Entry1 from the data source in Label Design";
            // 
            // txtLotColumn
            // 
            this.txtLotColumn.Location = new System.Drawing.Point(196, 118);
            this.txtLotColumn.Margin = new System.Windows.Forms.Padding(4);
            this.txtLotColumn.Name = "txtLotColumn";
            this.txtLotColumn.Size = new System.Drawing.Size(239, 22);
            this.txtLotColumn.TabIndex = 6;
            // 
            // lblcolname
            // 
            this.lblcolname.AutoSize = true;
            this.lblcolname.Location = new System.Drawing.Point(64, 122);
            this.lblcolname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcolname.Name = "lblcolname";
            this.lblcolname.Size = new System.Drawing.Size(109, 17);
            this.lblcolname.TabIndex = 5;
            this.lblcolname.Text = "Lot No. Column:";
            // 
            // btnPrintOption
            // 
            this.btnPrintOption.Location = new System.Drawing.Point(755, 48);
            this.btnPrintOption.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintOption.Name = "btnPrintOption";
            this.btnPrintOption.Size = new System.Drawing.Size(155, 44);
            this.btnPrintOption.TabIndex = 0;
            this.btnPrintOption.Text = "Save";
            this.btnPrintOption.UseVisualStyleBackColor = true;
            this.btnPrintOption.Click += new System.EventHandler(this.btnPrintOption_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFTPSave);
            this.groupBox3.Controls.Add(this.txtPassword);
            this.groupBox3.Controls.Add(this.txtLoginID);
            this.groupBox3.Controls.Add(this.txtFTPServerPath);
            this.groupBox3.Controls.Add(this.lblPassword);
            this.groupBox3.Controls.Add(this.lblLogin);
            this.groupBox3.Controls.Add(this.lblFTPServerPath);
            this.groupBox3.Location = new System.Drawing.Point(28, 456);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(932, 194);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FTP Details";
            // 
            // btnFTPSave
            // 
            this.btnFTPSave.Location = new System.Drawing.Point(673, 73);
            this.btnFTPSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnFTPSave.Name = "btnFTPSave";
            this.btnFTPSave.Size = new System.Drawing.Size(228, 44);
            this.btnFTPSave.TabIndex = 6;
            this.btnFTPSave.Text = "Test FTP Connection && Save";
            this.btnFTPSave.UseVisualStyleBackColor = true;
            this.btnFTPSave.Click += new System.EventHandler(this.btnFTPSave_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(197, 114);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(239, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // txtLoginID
            // 
            this.txtLoginID.Location = new System.Drawing.Point(197, 73);
            this.txtLoginID.Margin = new System.Windows.Forms.Padding(4);
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(239, 22);
            this.txtLoginID.TabIndex = 4;
            // 
            // txtFTPServerPath
            // 
            this.txtFTPServerPath.Location = new System.Drawing.Point(197, 31);
            this.txtFTPServerPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtFTPServerPath.Name = "txtFTPServerPath";
            this.txtFTPServerPath.Size = new System.Drawing.Size(440, 22);
            this.txtFTPServerPath.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(105, 114);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(113, 73);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(60, 17);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login ID";
            // 
            // lblFTPServerPath
            // 
            this.lblFTPServerPath.AutoSize = true;
            this.lblFTPServerPath.Location = new System.Drawing.Point(61, 31);
            this.lblFTPServerPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFTPServerPath.Name = "lblFTPServerPath";
            this.lblFTPServerPath.Size = new System.Drawing.Size(113, 17);
            this.lblFTPServerPath.TabIndex = 0;
            this.lblFTPServerPath.Text = "FTP Server Path";
            // 
            // drpitemcustomfield
            // 
            this.drpitemcustomfield.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpitemcustomfield.FormattingEnabled = true;
            this.drpitemcustomfield.Location = new System.Drawing.Point(187, 31);
            this.drpitemcustomfield.Margin = new System.Windows.Forms.Padding(4);
            this.drpitemcustomfield.Name = "drpitemcustomfield";
            this.drpitemcustomfield.Size = new System.Drawing.Size(240, 24);
            this.drpitemcustomfield.TabIndex = 46;
            // 
            // lblitemcustomfield
            // 
            this.lblitemcustomfield.AutoSize = true;
            this.lblitemcustomfield.Location = new System.Drawing.Point(51, 34);
            this.lblitemcustomfield.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblitemcustomfield.Name = "lblitemcustomfield";
            this.lblitemcustomfield.Size = new System.Drawing.Size(127, 17);
            this.lblitemcustomfield.TabIndex = 45;
            this.lblitemcustomfield.Text = "Item Custom Field :";
            // 
            // btnSyncCustom
            // 
            this.btnSyncCustom.Location = new System.Drawing.Point(460, 23);
            this.btnSyncCustom.Margin = new System.Windows.Forms.Padding(4);
            this.btnSyncCustom.Name = "btnSyncCustom";
            this.btnSyncCustom.Size = new System.Drawing.Size(140, 37);
            this.btnSyncCustom.TabIndex = 49;
            this.btnSyncCustom.Text = "&Sync Fields";
            this.btnSyncCustom.UseVisualStyleBackColor = true;
            this.btnSyncCustom.Click += new System.EventHandler(this.btnSyncCustom_Click);
            // 
            // btncustomfieldsave
            // 
            this.btncustomfieldsave.Location = new System.Drawing.Point(608, 23);
            this.btncustomfieldsave.Margin = new System.Windows.Forms.Padding(4);
            this.btncustomfieldsave.Name = "btncustomfieldsave";
            this.btncustomfieldsave.Size = new System.Drawing.Size(119, 37);
            this.btncustomfieldsave.TabIndex = 7;
            this.btncustomfieldsave.Text = "Save";
            this.btncustomfieldsave.UseVisualStyleBackColor = true;
            this.btncustomfieldsave.Click += new System.EventHandler(this.btncustomfieldsave_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btncustomfieldsave);
            this.groupBox4.Controls.Add(this.lblitemcustomfield);
            this.groupBox4.Controls.Add(this.btnSyncCustom);
            this.groupBox4.Controls.Add(this.drpitemcustomfield);
            this.groupBox4.Location = new System.Drawing.Point(28, 180);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(932, 74);
            this.groupBox4.TabIndex = 50;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sync Items Custom Field";
            // 
            // FrmItemListSettingcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 709);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblSyncItemDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItemListSettingcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item List";
            this.Load += new System.EventHandler(this.FrmItemListSettingcs_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.poqtypanel.ResumeLayout(false);
            this.poqtypanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSyncItem;
        private System.Windows.Forms.CheckBox chkInvItem;
        private System.Windows.Forms.CheckBox chkassembly;
        private System.Windows.Forms.CheckBox chknoninventory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSyncItemDate;
        private System.Windows.Forms.CheckBox chkgroupitem;
        private System.Windows.Forms.Panel poqtypanel;
        private System.Windows.Forms.RadioButton rdoPrintOneQty;
        private System.Windows.Forms.RadioButton rdoPrintItemQty;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPrintOption;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFTPSave;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLoginID;
        private System.Windows.Forms.TextBox txtFTPServerPath;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblFTPServerPath;
        private System.Windows.Forms.TextBox txtLotColumn;
        private System.Windows.Forms.Label lblcolname;
        internal System.Windows.Forms.ComboBox drpitemcustomfield;
        internal System.Windows.Forms.Label lblitemcustomfield;
        private System.Windows.Forms.Button btnSyncCustom;
        private System.Windows.Forms.Button btncustomfieldsave;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
    }
}