namespace QBLC
{
    partial class frmLabelConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabelConfig));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pnlFolderSelection = new System.Windows.Forms.Panel();
            this.rdbtypeudlabel = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbtypebartederlabel = new System.Windows.Forms.RadioButton();
            this.checkmultidefault = new System.Windows.Forms.Panel();
            this.rdomanual = new System.Windows.Forms.RadioButton();
            this.rdoauto = new System.Windows.Forms.RadioButton();
            this.btnWeatherLabelPath = new System.Windows.Forms.Button();
            this.txtStaticLabelPath = new System.Windows.Forms.TextBox();
            this.lblWeatherLabelPath = new System.Windows.Forms.Label();
            this.lblLabelFolder = new System.Windows.Forms.Label();
            this.txtTemplateLabelPath = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.rdbInvoice = new System.Windows.Forms.RadioButton();
            this.rdbSO = new System.Windows.Forms.RadioButton();
            this.rdbPO = new System.Windows.Forms.RadioButton();
            this.rdbd = new System.Windows.Forms.RadioButton();
            this.rdbC = new System.Windows.Forms.RadioButton();
            this.rdbB = new System.Windows.Forms.RadioButton();
            this.rdbA = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbSR = new System.Windows.Forms.RadioButton();
            this.rdbInvPackaging = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cmbLabelPrinter = new System.Windows.Forms.ComboBox();
            this.lblprintername = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbldtatshift = new System.Windows.Forms.Label();
            this.btndateShift = new System.Windows.Forms.Button();
            this.txtdataShift = new System.Windows.Forms.TextBox();
            this.btnApplyTime = new System.Windows.Forms.Button();
            this.btnApplay = new System.Windows.Forms.Button();
            this.txtTimeFormat = new System.Windows.Forms.TextBox();
            this.txtDateStamp = new System.Windows.Forms.TextBox();
            this.lblTimeFormat = new System.Windows.Forms.Label();
            this.lblDateFormat = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDateShift = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSelectDirectory = new System.Windows.Forms.Button();
            this.txtSelectedDirectory = new System.Windows.Forms.TextBox();
            this.lblselectDirectory = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkEnableVariableImageCustCF = new System.Windows.Forms.CheckBox();
            this.pnlFolderSelection.SuspendLayout();
            this.checkmultidefault.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(604, 71);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(201, 28);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Select Static Folder ";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pnlFolderSelection
            // 
            this.pnlFolderSelection.Controls.Add(this.rdbtypeudlabel);
            this.pnlFolderSelection.Controls.Add(this.label4);
            this.pnlFolderSelection.Controls.Add(this.label1);
            this.pnlFolderSelection.Controls.Add(this.rdbtypebartederlabel);
            this.pnlFolderSelection.Controls.Add(this.checkmultidefault);
            this.pnlFolderSelection.Controls.Add(this.btnWeatherLabelPath);
            this.pnlFolderSelection.Controls.Add(this.txtStaticLabelPath);
            this.pnlFolderSelection.Controls.Add(this.lblWeatherLabelPath);
            this.pnlFolderSelection.Controls.Add(this.lblLabelFolder);
            this.pnlFolderSelection.Controls.Add(this.btnBrowse);
            this.pnlFolderSelection.Controls.Add(this.txtTemplateLabelPath);
            this.pnlFolderSelection.Location = new System.Drawing.Point(16, 2);
            this.pnlFolderSelection.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFolderSelection.Name = "pnlFolderSelection";
            this.pnlFolderSelection.Size = new System.Drawing.Size(857, 202);
            this.pnlFolderSelection.TabIndex = 1;
            // 
            // rdbtypeudlabel
            // 
            this.rdbtypeudlabel.AutoSize = true;
            this.rdbtypeudlabel.Location = new System.Drawing.Point(360, 175);
            this.rdbtypeudlabel.Margin = new System.Windows.Forms.Padding(4);
            this.rdbtypeudlabel.Name = "rdbtypeudlabel";
            this.rdbtypeudlabel.Size = new System.Drawing.Size(221, 21);
            this.rdbtypeudlabel.TabIndex = 8;
            this.rdbtypeudlabel.Text = "Use Label Connector designer";
            this.rdbtypeudlabel.UseVisualStyleBackColor = true;
            this.rdbtypeudlabel.CheckedChanged += new System.EventHandler(this.rdbtypeudlabel_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Print Label  Mode :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Print Mode :";
            // 
            // rdbtypebartederlabel
            // 
            this.rdbtypebartederlabel.AutoSize = true;
            this.rdbtypebartederlabel.Checked = true;
            this.rdbtypebartederlabel.Location = new System.Drawing.Point(185, 175);
            this.rdbtypebartederlabel.Margin = new System.Windows.Forms.Padding(4);
            this.rdbtypebartederlabel.Name = "rdbtypebartederlabel";
            this.rdbtypebartederlabel.Size = new System.Drawing.Size(147, 21);
            this.rdbtypebartederlabel.TabIndex = 7;
            this.rdbtypebartederlabel.TabStop = true;
            this.rdbtypebartederlabel.Text = "Bar Tender Labels";
            this.rdbtypebartederlabel.UseVisualStyleBackColor = true;
            this.rdbtypebartederlabel.CheckedChanged += new System.EventHandler(this.rdbtypebartederlabel_CheckedChanged);
            // 
            // checkmultidefault
            // 
            this.checkmultidefault.Controls.Add(this.rdomanual);
            this.checkmultidefault.Controls.Add(this.rdoauto);
            this.checkmultidefault.Location = new System.Drawing.Point(176, 119);
            this.checkmultidefault.Margin = new System.Windows.Forms.Padding(4);
            this.checkmultidefault.Name = "checkmultidefault";
            this.checkmultidefault.Size = new System.Drawing.Size(405, 42);
            this.checkmultidefault.TabIndex = 14;
            // 
            // rdomanual
            // 
            this.rdomanual.AutoSize = true;
            this.rdomanual.Checked = true;
            this.rdomanual.Location = new System.Drawing.Point(187, 9);
            this.rdomanual.Margin = new System.Windows.Forms.Padding(4);
            this.rdomanual.Name = "rdomanual";
            this.rdomanual.Size = new System.Drawing.Size(163, 21);
            this.rdomanual.TabIndex = 6;
            this.rdomanual.TabStop = true;
            this.rdomanual.Text = "Use Template Labels";
            this.rdomanual.UseVisualStyleBackColor = true;
            // 
            // rdoauto
            // 
            this.rdoauto.AutoSize = true;
            this.rdoauto.Location = new System.Drawing.Point(9, 9);
            this.rdoauto.Margin = new System.Windows.Forms.Padding(4);
            this.rdoauto.Name = "rdoauto";
            this.rdoauto.Size = new System.Drawing.Size(139, 21);
            this.rdoauto.TabIndex = 5;
            this.rdoauto.Text = "Use Static Labels";
            this.rdoauto.UseVisualStyleBackColor = true;
            // 
            // btnWeatherLabelPath
            // 
            this.btnWeatherLabelPath.Location = new System.Drawing.Point(604, 25);
            this.btnWeatherLabelPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnWeatherLabelPath.Name = "btnWeatherLabelPath";
            this.btnWeatherLabelPath.Size = new System.Drawing.Size(201, 28);
            this.btnWeatherLabelPath.TabIndex = 2;
            this.btnWeatherLabelPath.Text = "Select Template  Folder";
            this.btnWeatherLabelPath.UseVisualStyleBackColor = true;
            this.btnWeatherLabelPath.Click += new System.EventHandler(this.btnWeatherLabelPath_Click);
            // 
            // txtStaticLabelPath
            // 
            this.txtStaticLabelPath.Location = new System.Drawing.Point(176, 27);
            this.txtStaticLabelPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtStaticLabelPath.Name = "txtStaticLabelPath";
            this.txtStaticLabelPath.Size = new System.Drawing.Size(405, 22);
            this.txtStaticLabelPath.TabIndex = 1;
            // 
            // lblWeatherLabelPath
            // 
            this.lblWeatherLabelPath.AutoSize = true;
            this.lblWeatherLabelPath.Location = new System.Drawing.Point(20, 31);
            this.lblWeatherLabelPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeatherLabelPath.Name = "lblWeatherLabelPath";
            this.lblWeatherLabelPath.Size = new System.Drawing.Size(147, 17);
            this.lblWeatherLabelPath.TabIndex = 9;
            this.lblWeatherLabelPath.Text = "Template Label Path :";
            this.lblWeatherLabelPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLabelFolder
            // 
            this.lblLabelFolder.AutoSize = true;
            this.lblLabelFolder.Location = new System.Drawing.Point(37, 78);
            this.lblLabelFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLabelFolder.Name = "lblLabelFolder";
            this.lblLabelFolder.Size = new System.Drawing.Size(123, 17);
            this.lblLabelFolder.TabIndex = 8;
            this.lblLabelFolder.Text = "Static Label Path :";
            // 
            // txtTemplateLabelPath
            // 
            this.txtTemplateLabelPath.Location = new System.Drawing.Point(176, 75);
            this.txtTemplateLabelPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtTemplateLabelPath.Name = "txtTemplateLabelPath";
            this.txtTemplateLabelPath.Size = new System.Drawing.Size(405, 22);
            this.txtTemplateLabelPath.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(416, 633);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(124, 36);
            this.btnExit.TabIndex = 26;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(272, 633);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 36);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // rdbInvoice
            // 
            this.rdbInvoice.AutoSize = true;
            this.rdbInvoice.Checked = true;
            this.rdbInvoice.Location = new System.Drawing.Point(275, 9);
            this.rdbInvoice.Margin = new System.Windows.Forms.Padding(4);
            this.rdbInvoice.Name = "rdbInvoice";
            this.rdbInvoice.Size = new System.Drawing.Size(73, 21);
            this.rdbInvoice.TabIndex = 3;
            this.rdbInvoice.TabStop = true;
            this.rdbInvoice.Text = "Invoice";
            this.rdbInvoice.UseVisualStyleBackColor = true;
            this.rdbInvoice.CheckedChanged += new System.EventHandler(this.rdbInvoice_CheckedChanged);
            // 
            // rdbSO
            // 
            this.rdbSO.AutoSize = true;
            this.rdbSO.Location = new System.Drawing.Point(156, 9);
            this.rdbSO.Margin = new System.Windows.Forms.Padding(4);
            this.rdbSO.Name = "rdbSO";
            this.rdbSO.Size = new System.Drawing.Size(105, 21);
            this.rdbSO.TabIndex = 2;
            this.rdbSO.Text = "Sales Order";
            this.rdbSO.UseVisualStyleBackColor = true;
            this.rdbSO.CheckedChanged += new System.EventHandler(this.rdbSO_CheckedChanged);
            // 
            // rdbPO
            // 
            this.rdbPO.AutoSize = true;
            this.rdbPO.Location = new System.Drawing.Point(15, 9);
            this.rdbPO.Margin = new System.Windows.Forms.Padding(4);
            this.rdbPO.Name = "rdbPO";
            this.rdbPO.Size = new System.Drawing.Size(130, 21);
            this.rdbPO.TabIndex = 1;
            this.rdbPO.Text = "Purchase Order";
            this.rdbPO.UseVisualStyleBackColor = true;
            this.rdbPO.CheckedChanged += new System.EventHandler(this.rdbPO_CheckedChanged);
            // 
            // rdbd
            // 
            this.rdbd.AutoSize = true;
            this.rdbd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rdbd.Location = new System.Drawing.Point(401, 9);
            this.rdbd.Margin = new System.Windows.Forms.Padding(4);
            this.rdbd.Name = "rdbd";
            this.rdbd.Size = new System.Drawing.Size(148, 21);
            this.rdbd.TabIndex = 3;
            this.rdbd.Text = "Scan Sales Orders";
            this.rdbd.UseVisualStyleBackColor = true;
            this.rdbd.Visible = false;
            // 
            // rdbC
            // 
            this.rdbC.AutoSize = true;
            this.rdbC.Location = new System.Drawing.Point(277, 9);
            this.rdbC.Margin = new System.Windows.Forms.Padding(4);
            this.rdbC.Name = "rdbC";
            this.rdbC.Size = new System.Drawing.Size(95, 21);
            this.rdbC.TabIndex = 2;
            this.rdbC.Text = "Packaging";
            this.rdbC.UseVisualStyleBackColor = true;
            this.rdbC.Visible = false;
            // 
            // rdbB
            // 
            this.rdbB.AutoSize = true;
            this.rdbB.Location = new System.Drawing.Point(158, 9);
            this.rdbB.Margin = new System.Windows.Forms.Padding(4);
            this.rdbB.Name = "rdbB";
            this.rdbB.Size = new System.Drawing.Size(68, 21);
            this.rdbB.TabIndex = 1;
            this.rdbB.Text = "Single";
            this.rdbB.UseVisualStyleBackColor = true;
            this.rdbB.Visible = false;
            // 
            // rdbA
            // 
            this.rdbA.AutoSize = true;
            this.rdbA.Checked = true;
            this.rdbA.Location = new System.Drawing.Point(15, 9);
            this.rdbA.Margin = new System.Windows.Forms.Padding(4);
            this.rdbA.Name = "rdbA";
            this.rdbA.Size = new System.Drawing.Size(77, 21);
            this.rdbA.TabIndex = 0;
            this.rdbA.TabStop = true;
            this.rdbA.Text = "Multiple";
            this.rdbA.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Print Type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Print Option :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdbSR);
            this.panel2.Controls.Add(this.rdbInvPackaging);
            this.panel2.Controls.Add(this.rdbPO);
            this.panel2.Controls.Add(this.rdbInvoice);
            this.panel2.Controls.Add(this.rdbSO);
            this.panel2.Location = new System.Drawing.Point(171, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 41);
            this.panel2.TabIndex = 0;
            // 
            // rdbSR
            // 
            this.rdbSR.AutoSize = true;
            this.rdbSR.Location = new System.Drawing.Point(529, 9);
            this.rdbSR.Margin = new System.Windows.Forms.Padding(4);
            this.rdbSR.Name = "rdbSR";
            this.rdbSR.Size = new System.Drawing.Size(116, 21);
            this.rdbSR.TabIndex = 5;
            this.rdbSR.Text = "Sales Receipt";
            this.rdbSR.UseVisualStyleBackColor = true;
            this.rdbSR.CheckedChanged += new System.EventHandler(this.rdbSR_CheckedChanged);
            // 
            // rdbInvPackaging
            // 
            this.rdbInvPackaging.AutoSize = true;
            this.rdbInvPackaging.Location = new System.Drawing.Point(361, 9);
            this.rdbInvPackaging.Margin = new System.Windows.Forms.Padding(4);
            this.rdbInvPackaging.Name = "rdbInvPackaging";
            this.rdbInvPackaging.Size = new System.Drawing.Size(149, 21);
            this.rdbInvPackaging.TabIndex = 4;
            this.rdbInvPackaging.Text = "Packaging(Invoice)";
            this.rdbInvPackaging.UseVisualStyleBackColor = true;
            this.rdbInvPackaging.CheckedChanged += new System.EventHandler(this.rdbInvPackaging_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdbA);
            this.panel3.Controls.Add(this.rdbd);
            this.panel3.Controls.Add(this.rdbB);
            this.panel3.Controls.Add(this.rdbC);
            this.panel3.Location = new System.Drawing.Point(171, 60);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(556, 39);
            this.panel3.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Location = new System.Drawing.Point(16, 209);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(851, 110);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.cmbLabelPrinter);
            this.groupBox2.Controls.Add(this.lblprintername);
            this.groupBox2.Location = new System.Drawing.Point(16, 324);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(501, 85);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Printer Setting";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(320, 23);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(173, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Select Common Printer";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(117, 23);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(195, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Select Printer from Screen";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // cmbLabelPrinter
            // 
            this.cmbLabelPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelPrinter.FormattingEnabled = true;
            this.cmbLabelPrinter.Location = new System.Drawing.Point(115, 48);
            this.cmbLabelPrinter.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLabelPrinter.Name = "cmbLabelPrinter";
            this.cmbLabelPrinter.Size = new System.Drawing.Size(372, 24);
            this.cmbLabelPrinter.TabIndex = 2;
            // 
            // lblprintername
            // 
            this.lblprintername.AutoSize = true;
            this.lblprintername.Location = new System.Drawing.Point(10, 48);
            this.lblprintername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblprintername.Name = "lblprintername";
            this.lblprintername.Size = new System.Drawing.Size(101, 17);
            this.lblprintername.TabIndex = 10;
            this.lblprintername.Text = "Select Printer :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbldtatshift);
            this.groupBox3.Controls.Add(this.btndateShift);
            this.groupBox3.Controls.Add(this.txtdataShift);
            this.groupBox3.Controls.Add(this.btnApplyTime);
            this.groupBox3.Controls.Add(this.btnApplay);
            this.groupBox3.Controls.Add(this.txtTimeFormat);
            this.groupBox3.Controls.Add(this.txtDateStamp);
            this.groupBox3.Controls.Add(this.lblTimeFormat);
            this.groupBox3.Controls.Add(this.lblDateFormat);
            this.groupBox3.Controls.Add(this.lblTime);
            this.groupBox3.Controls.Add(this.lblDateShift);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(16, 417);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(851, 146);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set Date and Time Format";
            // 
            // lbldtatshift
            // 
            this.lbldtatshift.AutoSize = true;
            this.lbldtatshift.Location = new System.Drawing.Point(372, 118);
            this.lbldtatshift.Name = "lbldtatshift";
            this.lbldtatshift.Size = new System.Drawing.Size(0, 17);
            this.lbldtatshift.TabIndex = 16;
            // 
            // btndateShift
            // 
            this.btndateShift.Location = new System.Drawing.Point(532, 104);
            this.btndateShift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndateShift.Name = "btndateShift";
            this.btndateShift.Size = new System.Drawing.Size(195, 31);
            this.btndateShift.TabIndex = 5;
            this.btndateShift.Text = "Apply Date Shift";
            this.btndateShift.UseVisualStyleBackColor = true;
            this.btndateShift.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtdataShift
            // 
            this.txtdataShift.Location = new System.Drawing.Point(188, 107);
            this.txtdataShift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdataShift.Name = "txtdataShift";
            this.txtdataShift.Size = new System.Drawing.Size(177, 22);
            this.txtdataShift.TabIndex = 4;
            this.txtdataShift.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtdataShift.Leave += new System.EventHandler(this.txtdataShift_Leave);
            // 
            // btnApplyTime
            // 
            this.btnApplyTime.Location = new System.Drawing.Point(532, 26);
            this.btnApplyTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApplyTime.Name = "btnApplyTime";
            this.btnApplyTime.Size = new System.Drawing.Size(195, 31);
            this.btnApplyTime.TabIndex = 1;
            this.btnApplyTime.Text = "Apply Time Formatting";
            this.btnApplyTime.UseVisualStyleBackColor = true;
            this.btnApplyTime.Click += new System.EventHandler(this.btnApplyTime_Click);
            // 
            // btnApplay
            // 
            this.btnApplay.Location = new System.Drawing.Point(532, 64);
            this.btnApplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApplay.Name = "btnApplay";
            this.btnApplay.Size = new System.Drawing.Size(195, 31);
            this.btnApplay.TabIndex = 3;
            this.btnApplay.Text = "Apply Date Formatting";
            this.btnApplay.UseVisualStyleBackColor = true;
            this.btnApplay.Click += new System.EventHandler(this.btnApplay_Click);
            // 
            // txtTimeFormat
            // 
            this.txtTimeFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeFormat.Location = new System.Drawing.Point(188, 30);
            this.txtTimeFormat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimeFormat.Name = "txtTimeFormat";
            this.txtTimeFormat.Size = new System.Drawing.Size(177, 23);
            this.txtTimeFormat.TabIndex = 0;
            this.txtTimeFormat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeFormat_KeyPress);
            this.txtTimeFormat.Leave += new System.EventHandler(this.txtTimeFormat_Leave);
            // 
            // txtDateStamp
            // 
            this.txtDateStamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateStamp.Location = new System.Drawing.Point(188, 69);
            this.txtDateStamp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDateStamp.Name = "txtDateStamp";
            this.txtDateStamp.Size = new System.Drawing.Size(177, 23);
            this.txtDateStamp.TabIndex = 2;
            this.txtDateStamp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDateStamp_KeyPress);
            this.txtDateStamp.Leave += new System.EventHandler(this.txtDateStamp_Leave);
            // 
            // lblTimeFormat
            // 
            this.lblTimeFormat.AutoSize = true;
            this.lblTimeFormat.Location = new System.Drawing.Point(373, 39);
            this.lblTimeFormat.Name = "lblTimeFormat";
            this.lblTimeFormat.Size = new System.Drawing.Size(0, 17);
            this.lblTimeFormat.TabIndex = 15;
            // 
            // lblDateFormat
            // 
            this.lblDateFormat.AutoSize = true;
            this.lblDateFormat.Location = new System.Drawing.Point(373, 79);
            this.lblDateFormat.Name = "lblDateFormat";
            this.lblDateFormat.Size = new System.Drawing.Size(0, 17);
            this.lblDateFormat.TabIndex = 15;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(72, 32);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(95, 17);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Time Format :";
            // 
            // lblDateShift
            // 
            this.lblDateShift.AutoSize = true;
            this.lblDateShift.Location = new System.Drawing.Point(47, 111);
            this.lblDateShift.Name = "lblDateShift";
            this.lblDateShift.Size = new System.Drawing.Size(120, 17);
            this.lblDateShift.TabIndex = 0;
            this.lblDateShift.Text = "Date Shift(Days) :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Date Format :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSelectDirectory);
            this.groupBox4.Controls.Add(this.txtSelectedDirectory);
            this.groupBox4.Controls.Add(this.lblselectDirectory);
            this.groupBox4.Location = new System.Drawing.Point(16, 566);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(851, 57);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            // 
            // btnSelectDirectory
            // 
            this.btnSelectDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDirectory.Location = new System.Drawing.Point(580, 21);
            this.btnSelectDirectory.Name = "btnSelectDirectory";
            this.btnSelectDirectory.Size = new System.Drawing.Size(42, 24);
            this.btnSelectDirectory.TabIndex = 2;
            this.btnSelectDirectory.Text = ":::";
            this.btnSelectDirectory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
            // 
            // txtSelectedDirectory
            // 
            this.txtSelectedDirectory.Location = new System.Drawing.Point(171, 21);
            this.txtSelectedDirectory.Name = "txtSelectedDirectory";
            this.txtSelectedDirectory.Size = new System.Drawing.Size(410, 22);
            this.txtSelectedDirectory.TabIndex = 1;
            this.txtSelectedDirectory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSelectedDirectory_KeyPress);
            // 
            // lblselectDirectory
            // 
            this.lblselectDirectory.AutoSize = true;
            this.lblselectDirectory.Location = new System.Drawing.Point(6, 23);
            this.lblselectDirectory.Name = "lblselectDirectory";
            this.lblselectDirectory.Size = new System.Drawing.Size(156, 17);
            this.lblselectDirectory.TabIndex = 0;
            this.lblselectDirectory.Text = "Select image directory :";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkEnableVariableImageCustCF);
            this.groupBox5.Location = new System.Drawing.Point(524, 326);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(343, 83);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Enable Customer Custom Field";
            // 
            // chkEnableVariableImageCustCF
            // 
            this.chkEnableVariableImageCustCF.AutoSize = true;
            this.chkEnableVariableImageCustCF.Location = new System.Drawing.Point(60, 38);
            this.chkEnableVariableImageCustCF.Name = "chkEnableVariableImageCustCF";
            this.chkEnableVariableImageCustCF.Size = new System.Drawing.Size(269, 21);
            this.chkEnableVariableImageCustCF.TabIndex = 0;
            this.chkEnableVariableImageCustCF.Text = "Enable Customer Custom Field Option";
            this.chkEnableVariableImageCustCF.UseVisualStyleBackColor = true;
            // 
            // frmLabelConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 690);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlFolderSelection);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLabelConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Label Connector - General Settings";
            this.Load += new System.EventHandler(this.frmLabelConfig_Load);
            this.pnlFolderSelection.ResumeLayout(false);
            this.pnlFolderSelection.PerformLayout();
            this.checkmultidefault.ResumeLayout(false);
            this.checkmultidefault.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel pnlFolderSelection;
        private System.Windows.Forms.TextBox txtTemplateLabelPath;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblLabelFolder;
        private System.Windows.Forms.Button btnWeatherLabelPath;
        private System.Windows.Forms.TextBox txtStaticLabelPath;
        private System.Windows.Forms.Label lblWeatherLabelPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Panel checkmultidefault;
        private System.Windows.Forms.RadioButton rdomanual;
        private System.Windows.Forms.RadioButton rdoauto;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.RadioButton rdbInvoice;
        internal System.Windows.Forms.RadioButton rdbSO;
        internal System.Windows.Forms.RadioButton rdbPO;
        private System.Windows.Forms.RadioButton rdbd;
        private System.Windows.Forms.RadioButton rdbC;
        private System.Windows.Forms.RadioButton rdbB;
        private System.Windows.Forms.RadioButton rdbA;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RadioButton rdbInvPackaging;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox cmbLabelPrinter;
        private System.Windows.Forms.Label lblprintername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbtypeudlabel;
        private System.Windows.Forms.RadioButton rdbtypebartederlabel;
        internal System.Windows.Forms.RadioButton rdbSR;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDateFormat;
        private System.Windows.Forms.TextBox txtDateStamp;
        private System.Windows.Forms.Button btnApplay;
        private System.Windows.Forms.TextBox txtTimeFormat;
        private System.Windows.Forms.Label lblTimeFormat;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnApplyTime;
        private System.Windows.Forms.Button btndateShift;
        private System.Windows.Forms.TextBox txtdataShift;
        private System.Windows.Forms.Label lblDateShift;
        private System.Windows.Forms.Label lbldtatshift;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSelectedDirectory;
        private System.Windows.Forms.Label lblselectDirectory;
        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkEnableVariableImageCustCF;
    }
}