namespace LabelConnector
{
    partial class FrmAddEditTemplateHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddEditTemplateHeader));
            this.gbcreatetemplate = new System.Windows.Forms.GroupBox();
            this.lbltemplateheadertext = new System.Windows.Forms.Label();
            this.pnlheadercontrols = new System.Windows.Forms.Panel();
            this.lbltemplatename = new System.Windows.Forms.Label();
            this.txtscaley = new System.Windows.Forms.TextBox();
            this.txtscalex = new System.Windows.Forms.TextBox();
            this.lblscaley = new System.Windows.Forms.Label();
            this.lblscalex = new System.Windows.Forms.Label();
            this.txtdpi = new System.Windows.Forms.TextBox();
            this.lbldpi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbTransType = new System.Windows.Forms.ComboBox();
            this.lbltemplateheaderwidth = new System.Windows.Forms.Label();
            this.txttemplateheaderheight = new System.Windows.Forms.TextBox();
            this.btncreatetemplateheader = new System.Windows.Forms.Button();
            this.txttemplatename = new System.Windows.Forms.TextBox();
            this.txttemplateheaderwidth = new System.Windows.Forms.TextBox();
            this.lbltemplateheaderheight = new System.Windows.Forms.Label();
            this.lbltranstype = new System.Windows.Forms.Label();
            this.pnlselecttemplate = new System.Windows.Forms.Panel();
            this.txtTempName = new System.Windows.Forms.TextBox();
            this.cmbtemplatelist = new System.Windows.Forms.ComboBox();
            this.lblseltemplate = new System.Windows.Forms.Label();
            this.gbcreatetemplate.SuspendLayout();
            this.pnlheadercontrols.SuspendLayout();
            this.pnlselecttemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbcreatetemplate
            // 
            this.gbcreatetemplate.Controls.Add(this.lbltemplateheadertext);
            this.gbcreatetemplate.Controls.Add(this.pnlheadercontrols);
            this.gbcreatetemplate.Controls.Add(this.pnlselecttemplate);
            this.gbcreatetemplate.Location = new System.Drawing.Point(12, 12);
            this.gbcreatetemplate.Name = "gbcreatetemplate";
            this.gbcreatetemplate.Size = new System.Drawing.Size(429, 230);
            this.gbcreatetemplate.TabIndex = 20;
            this.gbcreatetemplate.TabStop = false;
            // 
            // lbltemplateheadertext
            // 
            this.lbltemplateheadertext.AutoSize = true;
            this.lbltemplateheadertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltemplateheadertext.Location = new System.Drawing.Point(118, 16);
            this.lbltemplateheadertext.Name = "lbltemplateheadertext";
            this.lbltemplateheadertext.Size = new System.Drawing.Size(143, 17);
            this.lbltemplateheadertext.TabIndex = 18;
            this.lbltemplateheadertext.Text = "Add New Template";
            // 
            // pnlheadercontrols
            // 
            this.pnlheadercontrols.Controls.Add(this.lbltemplatename);
            this.pnlheadercontrols.Controls.Add(this.txtscaley);
            this.pnlheadercontrols.Controls.Add(this.txtscalex);
            this.pnlheadercontrols.Controls.Add(this.lblscaley);
            this.pnlheadercontrols.Controls.Add(this.lblscalex);
            this.pnlheadercontrols.Controls.Add(this.txtdpi);
            this.pnlheadercontrols.Controls.Add(this.lbldpi);
            this.pnlheadercontrols.Controls.Add(this.label2);
            this.pnlheadercontrols.Controls.Add(this.label1);
            this.pnlheadercontrols.Controls.Add(this.btnClose);
            this.pnlheadercontrols.Controls.Add(this.cmbTransType);
            this.pnlheadercontrols.Controls.Add(this.lbltemplateheaderwidth);
            this.pnlheadercontrols.Controls.Add(this.txttemplateheaderheight);
            this.pnlheadercontrols.Controls.Add(this.btncreatetemplateheader);
            this.pnlheadercontrols.Controls.Add(this.txttemplatename);
            this.pnlheadercontrols.Controls.Add(this.txttemplateheaderwidth);
            this.pnlheadercontrols.Controls.Add(this.lbltemplateheaderheight);
            this.pnlheadercontrols.Controls.Add(this.lbltranstype);
            this.pnlheadercontrols.Location = new System.Drawing.Point(15, 82);
            this.pnlheadercontrols.Name = "pnlheadercontrols";
            this.pnlheadercontrols.Size = new System.Drawing.Size(395, 145);
            this.pnlheadercontrols.TabIndex = 20;
            this.pnlheadercontrols.Visible = false;
            // 
            // lbltemplatename
            // 
            this.lbltemplatename.Location = new System.Drawing.Point(-2, 4);
            this.lbltemplatename.Name = "lbltemplatename";
            this.lbltemplatename.Size = new System.Drawing.Size(99, 17);
            this.lbltemplatename.TabIndex = 1;
            this.lbltemplatename.Text = "Name:";
            this.lbltemplatename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbltemplatename.Visible = false;
            // 
            // txtscaley
            // 
            this.txtscaley.Location = new System.Drawing.Point(104, 200);
            this.txtscaley.Name = "txtscaley";
            this.txtscaley.Size = new System.Drawing.Size(86, 20);
            this.txtscaley.TabIndex = 16;
            this.txtscaley.Visible = false;
            this.txtscaley.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtscaley_KeyPress);
            // 
            // txtscalex
            // 
            this.txtscalex.Location = new System.Drawing.Point(104, 167);
            this.txtscalex.Name = "txtscalex";
            this.txtscalex.Size = new System.Drawing.Size(86, 20);
            this.txtscalex.TabIndex = 15;
            this.txtscalex.Visible = false;
            this.txtscalex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtscalex_KeyPress);
            // 
            // lblscaley
            // 
            this.lblscaley.AutoSize = true;
            this.lblscaley.Location = new System.Drawing.Point(54, 200);
            this.lblscaley.Name = "lblscaley";
            this.lblscaley.Size = new System.Drawing.Size(44, 13);
            this.lblscaley.TabIndex = 14;
            this.lblscaley.Text = "ScaleY:";
            this.lblscaley.Visible = false;
            // 
            // lblscalex
            // 
            this.lblscalex.AutoSize = true;
            this.lblscalex.Location = new System.Drawing.Point(54, 167);
            this.lblscalex.Name = "lblscalex";
            this.lblscalex.Size = new System.Drawing.Size(44, 13);
            this.lblscalex.TabIndex = 13;
            this.lblscalex.Text = "ScaleX:";
            this.lblscalex.Visible = false;
            // 
            // txtdpi
            // 
            this.txtdpi.Location = new System.Drawing.Point(104, 138);
            this.txtdpi.Name = "txtdpi";
            this.txtdpi.Size = new System.Drawing.Size(86, 20);
            this.txtdpi.TabIndex = 12;
            this.txtdpi.Visible = false;
            this.txtdpi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdpi_KeyPress);
            // 
            // lbldpi
            // 
            this.lbldpi.AutoSize = true;
            this.lbldpi.Location = new System.Drawing.Point(60, 138);
            this.lbldpi.Name = "lbldpi";
            this.lbldpi.Size = new System.Drawing.Size(26, 13);
            this.lbldpi.TabIndex = 11;
            this.lbldpi.Text = "Dpi:";
            this.lbldpi.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(196, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "In.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(196, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "In.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(199, 106);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "      Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbTransType
            // 
            this.cmbTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransType.FormattingEnabled = true;
            this.cmbTransType.Location = new System.Drawing.Point(104, 3);
            this.cmbTransType.Name = "cmbTransType";
            this.cmbTransType.Size = new System.Drawing.Size(180, 21);
            this.cmbTransType.TabIndex = 2;
            this.cmbTransType.SelectedIndexChanged += new System.EventHandler(this.cmbTransType_SelectedIndexChanged);
            // 
            // lbltemplateheaderwidth
            // 
            this.lbltemplateheaderwidth.AutoSize = true;
            this.lbltemplateheaderwidth.Location = new System.Drawing.Point(62, 39);
            this.lbltemplateheaderwidth.Name = "lbltemplateheaderwidth";
            this.lbltemplateheaderwidth.Size = new System.Drawing.Size(38, 13);
            this.lbltemplateheaderwidth.TabIndex = 5;
            this.lbltemplateheaderwidth.Text = "Width:";
            // 
            // txttemplateheaderheight
            // 
            this.txttemplateheaderheight.Location = new System.Drawing.Point(104, 73);
            this.txttemplateheaderheight.Name = "txttemplateheaderheight";
            this.txttemplateheaderheight.Size = new System.Drawing.Size(86, 20);
            this.txttemplateheaderheight.TabIndex = 4;
            this.txttemplateheaderheight.TextChanged += new System.EventHandler(this.txttemplateheaderheight_TextChanged);
            this.txttemplateheaderheight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttemplateheaderheight_KeyPress);
            // 
            // btncreatetemplateheader
            // 
            this.btncreatetemplateheader.Enabled = false;
            this.btncreatetemplateheader.Image = ((System.Drawing.Image)(resources.GetObject("btncreatetemplateheader.Image")));
            this.btncreatetemplateheader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncreatetemplateheader.Location = new System.Drawing.Point(104, 106);
            this.btncreatetemplateheader.Name = "btncreatetemplateheader";
            this.btncreatetemplateheader.Size = new System.Drawing.Size(75, 29);
            this.btncreatetemplateheader.TabIndex = 5;
            this.btncreatetemplateheader.Text = "     Save";
            this.btncreatetemplateheader.UseVisualStyleBackColor = true;
            this.btncreatetemplateheader.Click += new System.EventHandler(this.btncreatetemplateheader_Click);
            // 
            // txttemplatename
            // 
            this.txttemplatename.Location = new System.Drawing.Point(104, 3);
            this.txttemplatename.Name = "txttemplatename";
            this.txttemplatename.Size = new System.Drawing.Size(272, 20);
            this.txttemplatename.TabIndex = 1;
            this.txttemplatename.Visible = false;
            this.txttemplatename.TextChanged += new System.EventHandler(this.txttemplatename_TextChanged);
            // 
            // txttemplateheaderwidth
            // 
            this.txttemplateheaderwidth.Location = new System.Drawing.Point(104, 39);
            this.txttemplateheaderwidth.Name = "txttemplateheaderwidth";
            this.txttemplateheaderwidth.Size = new System.Drawing.Size(86, 20);
            this.txttemplateheaderwidth.TabIndex = 3;
            this.txttemplateheaderwidth.TextChanged += new System.EventHandler(this.txttemplateheaderwidth_TextChanged);
            this.txttemplateheaderwidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttemplateheaderwidth_KeyPress);
            // 
            // lbltemplateheaderheight
            // 
            this.lbltemplateheaderheight.AutoSize = true;
            this.lbltemplateheaderheight.Location = new System.Drawing.Point(58, 77);
            this.lbltemplateheaderheight.Name = "lbltemplateheaderheight";
            this.lbltemplateheaderheight.Size = new System.Drawing.Size(41, 13);
            this.lbltemplateheaderheight.TabIndex = 3;
            this.lbltemplateheaderheight.Text = "Height:";
            // 
            // lbltranstype
            // 
            this.lbltranstype.AutoSize = true;
            this.lbltranstype.Location = new System.Drawing.Point(5, 4);
            this.lbltranstype.Name = "lbltranstype";
            this.lbltranstype.Size = new System.Drawing.Size(93, 13);
            this.lbltranstype.TabIndex = 7;
            this.lbltranstype.Text = "Transaction Type:";
            // 
            // pnlselecttemplate
            // 
            this.pnlselecttemplate.Controls.Add(this.txtTempName);
            this.pnlselecttemplate.Controls.Add(this.cmbtemplatelist);
            this.pnlselecttemplate.Controls.Add(this.lblseltemplate);
            this.pnlselecttemplate.Location = new System.Drawing.Point(15, 36);
            this.pnlselecttemplate.Name = "pnlselecttemplate";
            this.pnlselecttemplate.Size = new System.Drawing.Size(395, 40);
            this.pnlselecttemplate.TabIndex = 21;
            // 
            // txtTempName
            // 
            this.txtTempName.Location = new System.Drawing.Point(104, 16);
            this.txtTempName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTempName.Name = "txtTempName";
            this.txtTempName.Size = new System.Drawing.Size(272, 20);
            this.txtTempName.TabIndex = 17;
            this.txtTempName.Visible = false;
            // 
            // cmbtemplatelist
            // 
            this.cmbtemplatelist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtemplatelist.FormattingEnabled = true;
            this.cmbtemplatelist.Location = new System.Drawing.Point(104, 16);
            this.cmbtemplatelist.Name = "cmbtemplatelist";
            this.cmbtemplatelist.Size = new System.Drawing.Size(272, 21);
            this.cmbtemplatelist.TabIndex = 19;
            // 
            // lblseltemplate
            // 
            this.lblseltemplate.AutoSize = true;
            this.lblseltemplate.Location = new System.Drawing.Point(11, 19);
            this.lblseltemplate.Name = "lblseltemplate";
            this.lblseltemplate.Size = new System.Drawing.Size(87, 13);
            this.lblseltemplate.TabIndex = 18;
            this.lblseltemplate.Text = "Select Template:";
            // 
            // FrmAddEditTemplateHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 245);
            this.Controls.Add(this.gbcreatetemplate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditTemplateHeader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add / Edit Template";
            this.Load += new System.EventHandler(this.FrmAddEditTemplateHeader_Load);
            this.gbcreatetemplate.ResumeLayout(false);
            this.gbcreatetemplate.PerformLayout();
            this.pnlheadercontrols.ResumeLayout(false);
            this.pnlheadercontrols.PerformLayout();
            this.pnlselecttemplate.ResumeLayout(false);
            this.pnlselecttemplate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbcreatetemplate;
        private System.Windows.Forms.Label lbltemplateheadertext;
        private System.Windows.Forms.Panel pnlselecttemplate;
        private System.Windows.Forms.ComboBox cmbtemplatelist;
        private System.Windows.Forms.Label lblseltemplate;
        private System.Windows.Forms.Panel pnlheadercontrols;
        private System.Windows.Forms.TextBox txtscaley;
        private System.Windows.Forms.TextBox txtscalex;
        private System.Windows.Forms.Label lblscaley;
        private System.Windows.Forms.Label lblscalex;
        private System.Windows.Forms.TextBox txtdpi;
        private System.Windows.Forms.Label lbldpi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbTransType;
        private System.Windows.Forms.Label lbltemplateheaderwidth;
        private System.Windows.Forms.TextBox txttemplateheaderheight;
        private System.Windows.Forms.Button btncreatetemplateheader;
        private System.Windows.Forms.TextBox txttemplatename;
        private System.Windows.Forms.TextBox txttemplateheaderwidth;
        private System.Windows.Forms.Label lbltemplateheaderheight;
        private System.Windows.Forms.Label lbltemplatename;
        private System.Windows.Forms.Label lbltranstype;
        private System.Windows.Forms.TextBox txtTempName;
    }
}