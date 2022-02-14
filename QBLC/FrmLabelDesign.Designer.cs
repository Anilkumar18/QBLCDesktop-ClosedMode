namespace LabelConnector
{
    partial class FrmLabelDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLabelDesign));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radDiagram1 = new Telerik.WinControls.UI.RadDiagram();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbtemplatepreview = new System.Windows.Forms.GroupBox();
            this.gvfieldview = new System.Windows.Forms.DataGridView();
            this.lbldispname = new System.Windows.Forms.Label();
            this.txtdispname = new System.Windows.Forms.Label();
            this.lbldisptranstype = new System.Windows.Forms.Label();
            this.txtdistranstype = new System.Windows.Forms.Label();
            this.lbldispwidth = new System.Windows.Forms.Label();
            this.txtdispwidth = new System.Windows.Forms.Label();
            this.lbldispheight = new System.Windows.Forms.Label();
            this.txtdispheight = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtdispname1 = new System.Windows.Forms.Label();
            this.gbshowheaderdata = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.pnlselecttemplate = new System.Windows.Forms.Panel();
            this.cmbtemplatelist = new System.Windows.Forms.ComboBox();
            this.lblseltemplate = new System.Windows.Forms.Label();
            this.pnlheadercontrols = new System.Windows.Forms.Panel();
            this.btnopenAddFielddialog = new System.Windows.Forms.Button();
            this.cmbTransType = new System.Windows.Forms.ComboBox();
            this.lbltemplateheaderwidth = new System.Windows.Forms.Label();
            this.txttemplateheaderheight = new System.Windows.Forms.TextBox();
            this.btncreatetemplateheader = new System.Windows.Forms.Button();
            this.txttemplatename = new System.Windows.Forms.TextBox();
            this.txttemplateheaderwidth = new System.Windows.Forms.TextBox();
            this.lbltemplateheaderheight = new System.Windows.Forms.Label();
            this.lbltemplatename = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbltemplateheadertext = new System.Windows.Forms.Label();
            this.gbcreatetemplate = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblStaus1 = new System.Windows.Forms.Label();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.panelcontent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntxtEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtdelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddLine = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btntestprint = new System.Windows.Forms.Button();
            this.btnaddbarcode = new System.Windows.Forms.Button();
            this.btnaddtext = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbtemplatepreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvfieldview)).BeginInit();
            this.panel2.SuspendLayout();
            this.gbshowheaderdata.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlselecttemplate.SuspendLayout();
            this.pnlheadercontrols.SuspendLayout();
            this.gbcreatetemplate.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelcontent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.radDiagram1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(25, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 773);
            this.panel1.TabIndex = 21;
            // 
            // radDiagram1
            // 
            this.radDiagram1.BackColor = System.Drawing.SystemColors.Control;
            this.radDiagram1.IsZoomEnabled = false;
            this.radDiagram1.Location = new System.Drawing.Point(3, 3);
            this.radDiagram1.Name = "radDiagram1";
            // 
            // 
            // 
            this.radDiagram1.RootElement.ControlBounds = new System.Drawing.Rectangle(3, 3, 500, 500);
            this.radDiagram1.Size = new System.Drawing.Size(424, 184);
            this.radDiagram1.TabIndex = 22;
            this.radDiagram1.Text = "radDiagram1";
            this.radDiagram1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.radDiagram1_ControlAdded);
            this.radDiagram1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radDiagram1_MouseClick);
            this.radDiagram1.MouseEnter += new System.EventHandler(this.radDiagram1_MouseEnter);
            this.radDiagram1.MouseLeave += new System.EventHandler(this.radDiagram1_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(662, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 105);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // gbtemplatepreview
            // 
            this.gbtemplatepreview.Controls.Add(this.panel1);
            this.gbtemplatepreview.Location = new System.Drawing.Point(497, 97);
            this.gbtemplatepreview.Margin = new System.Windows.Forms.Padding(4);
            this.gbtemplatepreview.Name = "gbtemplatepreview";
            this.gbtemplatepreview.Padding = new System.Windows.Forms.Padding(4);
            this.gbtemplatepreview.Size = new System.Drawing.Size(1292, 945);
            this.gbtemplatepreview.TabIndex = 22;
            this.gbtemplatepreview.TabStop = false;
            this.gbtemplatepreview.Text = "Preview";
            // 
            // gvfieldview
            // 
            this.gvfieldview.AllowUserToAddRows = false;
            this.gvfieldview.AllowUserToDeleteRows = false;
            this.gvfieldview.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gvfieldview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvfieldview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvfieldview.Location = new System.Drawing.Point(8, 4);
            this.gvfieldview.Margin = new System.Windows.Forms.Padding(4);
            this.gvfieldview.Name = "gvfieldview";
            this.gvfieldview.RowHeadersVisible = false;
            this.gvfieldview.RowHeadersWidth = 51;
            this.gvfieldview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvfieldview.Size = new System.Drawing.Size(465, 665);
            this.gvfieldview.TabIndex = 23;
            this.gvfieldview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvfieldview_CellContentClick);
            this.gvfieldview.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvfieldview_CellFormatting);
            this.gvfieldview.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gvfieldview_CellPainting);
            this.gvfieldview.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvfieldview_CellValueChanged);
            // 
            // lbldispname
            // 
            this.lbldispname.Location = new System.Drawing.Point(25, 7);
            this.lbldispname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldispname.Name = "lbldispname";
            this.lbldispname.Size = new System.Drawing.Size(67, 27);
            this.lbldispname.TabIndex = 19;
            this.lbldispname.Text = "Name:";
            this.lbldispname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdispname
            // 
            this.txtdispname.AutoSize = true;
            this.txtdispname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdispname.Location = new System.Drawing.Point(100, 11);
            this.txtdispname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtdispname.MaximumSize = new System.Drawing.Size(263, 0);
            this.txtdispname.Name = "txtdispname";
            this.txtdispname.Size = new System.Drawing.Size(0, 17);
            this.txtdispname.TabIndex = 25;
            this.txtdispname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtdispname.Visible = false;
            this.txtdispname.TextChanged += new System.EventHandler(this.txtdispname_TextChanged);
            // 
            // lbldisptranstype
            // 
            this.lbldisptranstype.Location = new System.Drawing.Point(4, 41);
            this.lbldisptranstype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldisptranstype.Name = "lbldisptranstype";
            this.lbldisptranstype.Size = new System.Drawing.Size(88, 16);
            this.lbldisptranstype.TabIndex = 26;
            this.lbldisptranstype.Text = "Trans Type:";
            this.lbldisptranstype.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdistranstype
            // 
            this.txtdistranstype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdistranstype.Location = new System.Drawing.Point(100, 41);
            this.txtdistranstype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtdistranstype.Name = "txtdistranstype";
            this.txtdistranstype.Size = new System.Drawing.Size(172, 16);
            this.txtdistranstype.TabIndex = 27;
            this.txtdistranstype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbldispwidth
            // 
            this.lbldispwidth.Location = new System.Drawing.Point(328, 15);
            this.lbldispwidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldispwidth.Name = "lbldispwidth";
            this.lbldispwidth.Size = new System.Drawing.Size(59, 15);
            this.lbldispwidth.TabIndex = 28;
            this.lbldispwidth.Text = "Width:";
            this.lbldispwidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdispwidth
            // 
            this.txtdispwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdispwidth.Location = new System.Drawing.Point(394, 11);
            this.txtdispwidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtdispwidth.Name = "txtdispwidth";
            this.txtdispwidth.Size = new System.Drawing.Size(61, 23);
            this.txtdispwidth.TabIndex = 29;
            this.txtdispwidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtdispwidth.TextChanged += new System.EventHandler(this.txtdispwidth_TextChanged);
            // 
            // lbldispheight
            // 
            this.lbldispheight.Location = new System.Drawing.Point(329, 41);
            this.lbldispheight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldispheight.Name = "lbldispheight";
            this.lbldispheight.Size = new System.Drawing.Size(57, 16);
            this.lbldispheight.TabIndex = 30;
            this.lbldispheight.Text = "Height:";
            this.lbldispheight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdispheight
            // 
            this.txtdispheight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdispheight.Location = new System.Drawing.Point(392, 41);
            this.txtdispheight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtdispheight.Name = "txtdispheight";
            this.txtdispheight.Size = new System.Drawing.Size(64, 16);
            this.txtdispheight.TabIndex = 31;
            this.txtdispheight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbldispname);
            this.panel2.Controls.Add(this.txtdispheight);
            this.panel2.Controls.Add(this.txtdispname1);
            this.panel2.Controls.Add(this.txtdispname);
            this.panel2.Controls.Add(this.lbldispheight);
            this.panel2.Controls.Add(this.lbldisptranstype);
            this.panel2.Controls.Add(this.txtdispwidth);
            this.panel2.Controls.Add(this.txtdistranstype);
            this.panel2.Controls.Add(this.lbldispwidth);
            this.panel2.Location = new System.Drawing.Point(8, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 70);
            this.panel2.TabIndex = 32;
            // 
            // txtdispname1
            // 
            this.txtdispname1.AutoSize = true;
            this.txtdispname1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdispname1.Location = new System.Drawing.Point(100, 11);
            this.txtdispname1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtdispname1.MaximumSize = new System.Drawing.Size(263, 0);
            this.txtdispname1.Name = "txtdispname1";
            this.txtdispname1.Size = new System.Drawing.Size(0, 17);
            this.txtdispname1.TabIndex = 25;
            this.txtdispname1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtdispname1.TextChanged += new System.EventHandler(this.txtdispname_TextChanged);
            // 
            // gbshowheaderdata
            // 
            this.gbshowheaderdata.Controls.Add(this.panel2);
            this.gbshowheaderdata.Location = new System.Drawing.Point(8, 47);
            this.gbshowheaderdata.Margin = new System.Windows.Forms.Padding(4);
            this.gbshowheaderdata.Name = "gbshowheaderdata";
            this.gbshowheaderdata.Padding = new System.Windows.Forms.Padding(4);
            this.gbshowheaderdata.Size = new System.Drawing.Size(481, 107);
            this.gbshowheaderdata.TabIndex = 33;
            this.gbshowheaderdata.TabStop = false;
            this.gbshowheaderdata.Text = "Template Details";
            this.gbshowheaderdata.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton10,
            this.toolStripButton11,
            this.toolStripButton4,
            this.toolStripButton2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton3,
            this.toolStripButton8,
            this.toolStripButton9});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1805, 31);
            this.toolStrip1.TabIndex = 36;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::LabelConnector.Properties.Resources.New;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton10.Image = global::LabelConnector.Properties.Resources.open;
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton10.Text = "toolStripButton10";
            this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = global::LabelConnector.Properties.Resources.save24;
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton11.Text = "toolStripButton11";
            this.toolStripButton11.Click += new System.EventHandler(this.toolStripButton11_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::LabelConnector.Properties.Resources.saveas24;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::LabelConnector.Properties.Resources.open;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Visible = false;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::LabelConnector.Properties.Resources.edit;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::LabelConnector.Properties.Resources.delete;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton7.Text = "toolStripButton7";
            this.toolStripButton7.Visible = false;
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::LabelConnector.Properties.Resources.SyncFields;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::LabelConnector.Properties.Resources.close;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton8.Text = "toolStripButton8";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::LabelConnector.Properties.Resources.CloseDesigner;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton9.Text = "toolStripButton9";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // pnlselecttemplate
            // 
            this.pnlselecttemplate.Controls.Add(this.cmbtemplatelist);
            this.pnlselecttemplate.Controls.Add(this.lblseltemplate);
            this.pnlselecttemplate.Location = new System.Drawing.Point(23, 75);
            this.pnlselecttemplate.Margin = new System.Windows.Forms.Padding(4);
            this.pnlselecttemplate.Name = "pnlselecttemplate";
            this.pnlselecttemplate.Size = new System.Drawing.Size(325, 49);
            this.pnlselecttemplate.TabIndex = 21;
            // 
            // cmbtemplatelist
            // 
            this.cmbtemplatelist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtemplatelist.FormattingEnabled = true;
            this.cmbtemplatelist.Location = new System.Drawing.Point(139, 20);
            this.cmbtemplatelist.Margin = new System.Windows.Forms.Padding(4);
            this.cmbtemplatelist.Name = "cmbtemplatelist";
            this.cmbtemplatelist.Size = new System.Drawing.Size(361, 24);
            this.cmbtemplatelist.TabIndex = 19;
            this.cmbtemplatelist.SelectedIndexChanged += new System.EventHandler(this.cmbtemplatelist_SelectedIndexChanged);
            // 
            // lblseltemplate
            // 
            this.lblseltemplate.AutoSize = true;
            this.lblseltemplate.Location = new System.Drawing.Point(15, 23);
            this.lblseltemplate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblseltemplate.Name = "lblseltemplate";
            this.lblseltemplate.Size = new System.Drawing.Size(114, 17);
            this.lblseltemplate.TabIndex = 18;
            this.lblseltemplate.Text = "Select Template:";
            // 
            // pnlheadercontrols
            // 
            this.pnlheadercontrols.Controls.Add(this.btnopenAddFielddialog);
            this.pnlheadercontrols.Controls.Add(this.cmbTransType);
            this.pnlheadercontrols.Controls.Add(this.lbltemplateheaderwidth);
            this.pnlheadercontrols.Controls.Add(this.txttemplateheaderheight);
            this.pnlheadercontrols.Controls.Add(this.btncreatetemplateheader);
            this.pnlheadercontrols.Controls.Add(this.txttemplatename);
            this.pnlheadercontrols.Controls.Add(this.txttemplateheaderwidth);
            this.pnlheadercontrols.Controls.Add(this.lbltemplateheaderheight);
            this.pnlheadercontrols.Controls.Add(this.lbltemplatename);
            this.pnlheadercontrols.Controls.Add(this.label4);
            this.pnlheadercontrols.Location = new System.Drawing.Point(23, 132);
            this.pnlheadercontrols.Margin = new System.Windows.Forms.Padding(4);
            this.pnlheadercontrols.Name = "pnlheadercontrols";
            this.pnlheadercontrols.Size = new System.Drawing.Size(325, 213);
            this.pnlheadercontrols.TabIndex = 20;
            // 
            // btnopenAddFielddialog
            // 
            this.btnopenAddFielddialog.Location = new System.Drawing.Point(247, 177);
            this.btnopenAddFielddialog.Margin = new System.Windows.Forms.Padding(4);
            this.btnopenAddFielddialog.Name = "btnopenAddFielddialog";
            this.btnopenAddFielddialog.Size = new System.Drawing.Size(100, 28);
            this.btnopenAddFielddialog.TabIndex = 18;
            this.btnopenAddFielddialog.Text = "Add Field";
            this.btnopenAddFielddialog.UseVisualStyleBackColor = true;
            this.btnopenAddFielddialog.Click += new System.EventHandler(this.btnopenAddFielddialog_Click);
            // 
            // cmbTransType
            // 
            this.cmbTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransType.FormattingEnabled = true;
            this.cmbTransType.Location = new System.Drawing.Point(139, 48);
            this.cmbTransType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTransType.Name = "cmbTransType";
            this.cmbTransType.Size = new System.Drawing.Size(239, 24);
            this.cmbTransType.TabIndex = 2;
            this.cmbTransType.SelectedIndexChanged += new System.EventHandler(this.cmbTransType_SelectedIndexChanged);
            // 
            // lbltemplateheaderwidth
            // 
            this.lbltemplateheaderwidth.AutoSize = true;
            this.lbltemplateheaderwidth.Location = new System.Drawing.Point(80, 90);
            this.lbltemplateheaderwidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltemplateheaderwidth.Name = "lbltemplateheaderwidth";
            this.lbltemplateheaderwidth.Size = new System.Drawing.Size(48, 17);
            this.lbltemplateheaderwidth.TabIndex = 5;
            this.lbltemplateheaderwidth.Text = "Width:";
            // 
            // txttemplateheaderheight
            // 
            this.txttemplateheaderheight.Location = new System.Drawing.Point(139, 133);
            this.txttemplateheaderheight.Margin = new System.Windows.Forms.Padding(4);
            this.txttemplateheaderheight.Name = "txttemplateheaderheight";
            this.txttemplateheaderheight.Size = new System.Drawing.Size(113, 22);
            this.txttemplateheaderheight.TabIndex = 4;
            this.txttemplateheaderheight.TextChanged += new System.EventHandler(this.txttemplateheaderheight_TextChanged);
            this.txttemplateheaderheight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttemplateheaderheight_KeyPress);
            // 
            // btncreatetemplateheader
            // 
            this.btncreatetemplateheader.Enabled = false;
            this.btncreatetemplateheader.Location = new System.Drawing.Point(139, 177);
            this.btncreatetemplateheader.Margin = new System.Windows.Forms.Padding(4);
            this.btncreatetemplateheader.Name = "btncreatetemplateheader";
            this.btncreatetemplateheader.Size = new System.Drawing.Size(100, 28);
            this.btncreatetemplateheader.TabIndex = 5;
            this.btncreatetemplateheader.Text = "Save";
            this.btncreatetemplateheader.UseVisualStyleBackColor = true;
            this.btncreatetemplateheader.Click += new System.EventHandler(this.btncreatetemplateheader_Click);
            // 
            // txttemplatename
            // 
            this.txttemplatename.Location = new System.Drawing.Point(139, 4);
            this.txttemplatename.Margin = new System.Windows.Forms.Padding(4);
            this.txttemplatename.Name = "txttemplatename";
            this.txttemplatename.Size = new System.Drawing.Size(361, 22);
            this.txttemplatename.TabIndex = 1;
            this.txttemplatename.TextChanged += new System.EventHandler(this.txttemplatename_TextChanged);
            // 
            // txttemplateheaderwidth
            // 
            this.txttemplateheaderwidth.Location = new System.Drawing.Point(139, 90);
            this.txttemplateheaderwidth.Margin = new System.Windows.Forms.Padding(4);
            this.txttemplateheaderwidth.Name = "txttemplateheaderwidth";
            this.txttemplateheaderwidth.Size = new System.Drawing.Size(113, 22);
            this.txttemplateheaderwidth.TabIndex = 3;
            this.txttemplateheaderwidth.TextChanged += new System.EventHandler(this.txttemplateheaderwidth_TextChanged);
            this.txttemplateheaderwidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttemplateheaderwidth_KeyPress);
            // 
            // lbltemplateheaderheight
            // 
            this.lbltemplateheaderheight.AutoSize = true;
            this.lbltemplateheaderheight.Location = new System.Drawing.Point(76, 133);
            this.lbltemplateheaderheight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltemplateheaderheight.Name = "lbltemplateheaderheight";
            this.lbltemplateheaderheight.Size = new System.Drawing.Size(53, 17);
            this.lbltemplateheaderheight.TabIndex = 3;
            this.lbltemplateheaderheight.Text = "Height:";
            // 
            // lbltemplatename
            // 
            this.lbltemplatename.Location = new System.Drawing.Point(17, 7);
            this.lbltemplatename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltemplatename.Name = "lbltemplatename";
            this.lbltemplatename.Size = new System.Drawing.Size(113, 16);
            this.lbltemplatename.TabIndex = 1;
            this.lbltemplatename.Text = "Name:";
            this.lbltemplatename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Transaction Type:";
            // 
            // lbltemplateheadertext
            // 
            this.lbltemplateheadertext.AutoSize = true;
            this.lbltemplateheadertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltemplateheadertext.Location = new System.Drawing.Point(157, 36);
            this.lbltemplateheadertext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltemplateheadertext.Name = "lbltemplateheadertext";
            this.lbltemplateheadertext.Size = new System.Drawing.Size(166, 20);
            this.lbltemplateheadertext.TabIndex = 18;
            this.lbltemplateheadertext.Text = "Add New Template";
            // 
            // gbcreatetemplate
            // 
            this.gbcreatetemplate.Controls.Add(this.lbltemplateheadertext);
            this.gbcreatetemplate.Controls.Add(this.pnlheadercontrols);
            this.gbcreatetemplate.Controls.Add(this.pnlselecttemplate);
            this.gbcreatetemplate.Location = new System.Drawing.Point(579, 314);
            this.gbcreatetemplate.Margin = new System.Windows.Forms.Padding(4);
            this.gbcreatetemplate.Name = "gbcreatetemplate";
            this.gbcreatetemplate.Padding = new System.Windows.Forms.Padding(4);
            this.gbcreatetemplate.Size = new System.Drawing.Size(100, 39);
            this.gbcreatetemplate.TabIndex = 19;
            this.gbcreatetemplate.TabStop = false;
            this.gbcreatetemplate.Text = "Template Header";
            this.gbcreatetemplate.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblStaus1);
            this.panel3.Controls.Add(this.lblStatus2);
            this.panel3.Controls.Add(this.gvfieldview);
            this.panel3.Location = new System.Drawing.Point(8, 161);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(481, 732);
            this.panel3.TabIndex = 37;
            this.panel3.Click += new System.EventHandler(this.panel3_Click);
            this.panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            // 
            // lblStaus1
            // 
            this.lblStaus1.AutoSize = true;
            this.lblStaus1.Location = new System.Drawing.Point(3, 715);
            this.lblStaus1.Name = "lblStaus1";
            this.lblStaus1.Size = new System.Drawing.Size(46, 17);
            this.lblStaus1.TabIndex = 24;
            this.lblStaus1.Text = "label1";
            this.lblStaus1.Visible = false;
            // 
            // lblStatus2
            // 
            this.lblStatus2.AutoSize = true;
            this.lblStatus2.Location = new System.Drawing.Point(62, 715);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(46, 17);
            this.lblStatus2.TabIndex = 24;
            this.lblStatus2.Text = "label1";
            this.lblStatus2.Visible = false;
            // 
            // panelcontent
            // 
            this.panelcontent.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.panelcontent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cntxtEdit,
            this.cntxtdelete,
            this.cntxtCopy});
            this.panelcontent.Name = "contextMenuStrip1";
            this.panelcontent.Size = new System.Drawing.Size(147, 82);
            this.panelcontent.Tag = "";
            // 
            // cntxtEdit
            // 
            this.cntxtEdit.Image = ((System.Drawing.Image)(resources.GetObject("cntxtEdit.Image")));
            this.cntxtEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cntxtEdit.Name = "cntxtEdit";
            this.cntxtEdit.Size = new System.Drawing.Size(146, 26);
            this.cntxtEdit.Tag = "Edit";
            this.cntxtEdit.Text = "Edit";
            this.cntxtEdit.Click += new System.EventHandler(this.property_Click);
            // 
            // cntxtdelete
            // 
            this.cntxtdelete.Image = ((System.Drawing.Image)(resources.GetObject("cntxtdelete.Image")));
            this.cntxtdelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cntxtdelete.Name = "cntxtdelete";
            this.cntxtdelete.Size = new System.Drawing.Size(146, 26);
            this.cntxtdelete.Tag = "Delete";
            this.cntxtdelete.Text = "Delete";
            this.cntxtdelete.Click += new System.EventHandler(this.cntxtdelete_Click);
            // 
            // cntxtCopy
            // 
            this.cntxtCopy.Image = global::LabelConnector.Properties.Resources.copy;
            this.cntxtCopy.Name = "cntxtCopy";
            this.cntxtCopy.Size = new System.Drawing.Size(146, 26);
            this.cntxtCopy.Text = "Duplicate";
            this.cntxtCopy.Click += new System.EventHandler(this.cntxtCopy_Click);
            // 
            // btnAddLine
            // 
            this.btnAddLine.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLine.Image")));
            this.btnAddLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddLine.Location = new System.Drawing.Point(919, 47);
            this.btnAddLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(140, 36);
            this.btnAddLine.TabIndex = 39;
            this.btnAddLine.Text = "   Add Line";
            this.btnAddLine.UseVisualStyleBackColor = true;
            this.btnAddLine.Visible = false;
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Image = ((System.Drawing.Image)(resources.GetObject("btnAddImage.Image")));
            this.btnAddImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddImage.Location = new System.Drawing.Point(771, 47);
            this.btnAddImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(140, 36);
            this.btnAddImage.TabIndex = 38;
            this.btnAddImage.Text = "   Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Visible = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btntestprint
            // 
            this.btntestprint.Image = ((System.Drawing.Image)(resources.GetObject("btntestprint.Image")));
            this.btntestprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntestprint.Location = new System.Drawing.Point(1067, 47);
            this.btntestprint.Margin = new System.Windows.Forms.Padding(4);
            this.btntestprint.Name = "btntestprint";
            this.btntestprint.Size = new System.Drawing.Size(137, 36);
            this.btntestprint.TabIndex = 37;
            this.btntestprint.Text = "Test Print";
            this.btntestprint.UseVisualStyleBackColor = true;
            this.btntestprint.Visible = false;
            this.btntestprint.Click += new System.EventHandler(this.btntestprint_Click);
            // 
            // btnaddbarcode
            // 
            this.btnaddbarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnaddbarcode.Image")));
            this.btnaddbarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddbarcode.Location = new System.Drawing.Point(623, 47);
            this.btnaddbarcode.Margin = new System.Windows.Forms.Padding(4);
            this.btnaddbarcode.Name = "btnaddbarcode";
            this.btnaddbarcode.Size = new System.Drawing.Size(140, 36);
            this.btnaddbarcode.TabIndex = 18;
            this.btnaddbarcode.Text = "     Add BarCode";
            this.btnaddbarcode.UseVisualStyleBackColor = true;
            this.btnaddbarcode.Visible = false;
            this.btnaddbarcode.Click += new System.EventHandler(this.btnaddbarcode_Click);
            // 
            // btnaddtext
            // 
            this.btnaddtext.Image = ((System.Drawing.Image)(resources.GetObject("btnaddtext.Image")));
            this.btnaddtext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddtext.Location = new System.Drawing.Point(497, 47);
            this.btnaddtext.Margin = new System.Windows.Forms.Padding(4);
            this.btnaddtext.Name = "btnaddtext";
            this.btnaddtext.Size = new System.Drawing.Size(117, 36);
            this.btnaddtext.TabIndex = 17;
            this.btnaddtext.Text = "       Add Text";
            this.btnaddtext.UseVisualStyleBackColor = true;
            this.btnaddtext.Visible = false;
            this.btnaddtext.Click += new System.EventHandler(this.btnaddtext_Click);
            // 
            // FrmLabelDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1805, 902);
            this.Controls.Add(this.btnAddLine);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btntestprint);
            this.Controls.Add(this.btnaddbarcode);
            this.Controls.Add(this.btnaddtext);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbshowheaderdata);
            this.Controls.Add(this.gbtemplatepreview);
            this.Controls.Add(this.gbcreatetemplate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLabelDesign";
            this.Text = "Label Design";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLabelDesign_FormClosed);
            this.Load += new System.EventHandler(this.FrmLabelDesign_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FrmLabelDesign_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FrmLabelDesign_MouseDoubleClick);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbtemplatepreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvfieldview)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbshowheaderdata.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlselecttemplate.ResumeLayout(false);
            this.pnlselecttemplate.PerformLayout();
            this.pnlheadercontrols.ResumeLayout(false);
            this.pnlheadercontrols.PerformLayout();
            this.gbcreatetemplate.ResumeLayout(false);
            this.gbcreatetemplate.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelcontent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbtemplatepreview;
        private System.Windows.Forms.DataGridView gvfieldview;
        private System.Windows.Forms.Label lbldispname;
        private System.Windows.Forms.Label txtdispname;
        private System.Windows.Forms.Label lbldisptranstype;
        private System.Windows.Forms.Label txtdistranstype;
        private System.Windows.Forms.Label lbldispwidth;
        private System.Windows.Forms.Label txtdispwidth;
        private System.Windows.Forms.Label lbldispheight;
        private System.Windows.Forms.Label txtdispheight;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbshowheaderdata;
        private System.Windows.Forms.Button btnaddtext;
        private System.Windows.Forms.Button btnaddbarcode;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.Panel pnlselecttemplate;
        private System.Windows.Forms.ComboBox cmbtemplatelist;
        private System.Windows.Forms.Label lblseltemplate;
        private System.Windows.Forms.Panel pnlheadercontrols;
        private System.Windows.Forms.Button btnopenAddFielddialog;
        private System.Windows.Forms.ComboBox cmbTransType;
        private System.Windows.Forms.Label lbltemplateheaderwidth;
        private System.Windows.Forms.TextBox txttemplateheaderheight;
        private System.Windows.Forms.Button btncreatetemplateheader;
        private System.Windows.Forms.TextBox txttemplatename;
        private System.Windows.Forms.TextBox txttemplateheaderwidth;
        private System.Windows.Forms.Label lbltemplateheaderheight;
        private System.Windows.Forms.Label lbltemplatename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbltemplateheadertext;
        private System.Windows.Forms.GroupBox gbcreatetemplate;
        private System.Windows.Forms.Button btntestprint;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Panel panel3;
        private Telerik.WinControls.UI.RadDiagram radDiagram1;
        private System.Windows.Forms.ContextMenuStrip panelcontent;
        private System.Windows.Forms.ToolStripMenuItem cntxtEdit;
        private System.Windows.Forms.ToolStripMenuItem cntxtdelete;
        private System.Windows.Forms.Label lblStaus1;
        private System.Windows.Forms.Label lblStatus2;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.Label txtdispname1;
        private System.Windows.Forms.ToolStripMenuItem cntxtCopy;
        private System.Windows.Forms.Button btnAddLine;
    }
}