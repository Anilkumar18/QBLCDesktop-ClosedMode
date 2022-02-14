namespace LabelConnector
{
    partial class FrmTemplateOperation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTemplateOperation));
            this.cmbtemplate = new System.Windows.Forms.ComboBox();
            this.lblseltemplate = new System.Windows.Forms.Label();
            this.txttemplate = new System.Windows.Forms.TextBox();
            this.lbltemplatename = new System.Windows.Forms.Label();
            this.lbltemplateheadertext = new System.Windows.Forms.Label();
            this.btnsavetemplateop = new System.Windows.Forms.Button();
            this.gbsaveas = new System.Windows.Forms.GroupBox();
            this.txtTewmpName = new System.Windows.Forms.TextBox();
            this.lbltemp = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbsaveas.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbtemplate
            // 
            this.cmbtemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtemplate.FormattingEnabled = true;
            this.cmbtemplate.Location = new System.Drawing.Point(143, 23);
            this.cmbtemplate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbtemplate.Name = "cmbtemplate";
            this.cmbtemplate.Size = new System.Drawing.Size(361, 24);
            this.cmbtemplate.TabIndex = 23;
            this.cmbtemplate.Visible = false;
            this.cmbtemplate.SelectedIndexChanged += new System.EventHandler(this.cmbtemplate_SelectedIndexChanged);
            // 
            // lblseltemplate
            // 
            this.lblseltemplate.AutoSize = true;
            this.lblseltemplate.Location = new System.Drawing.Point(19, 27);
            this.lblseltemplate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblseltemplate.Name = "lblseltemplate";
            this.lblseltemplate.Size = new System.Drawing.Size(114, 17);
            this.lblseltemplate.TabIndex = 22;
            this.lblseltemplate.Text = "Select Template:";
            // 
            // txttemplate
            // 
            this.txttemplate.Location = new System.Drawing.Point(143, 57);
            this.txttemplate.Margin = new System.Windows.Forms.Padding(4);
            this.txttemplate.Name = "txttemplate";
            this.txttemplate.Size = new System.Drawing.Size(361, 22);
            this.txttemplate.TabIndex = 20;
            this.txttemplate.Visible = false;
            this.txttemplate.TextChanged += new System.EventHandler(this.txttemplate_TextChanged);
            // 
            // lbltemplatename
            // 
            this.lbltemplatename.Location = new System.Drawing.Point(19, 60);
            this.lbltemplatename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltemplatename.Name = "lbltemplatename";
            this.lbltemplatename.Size = new System.Drawing.Size(113, 16);
            this.lbltemplatename.TabIndex = 21;
            this.lbltemplatename.Text = "Name:";
            this.lbltemplatename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbltemplatename.Visible = false;
            // 
            // lbltemplateheadertext
            // 
            this.lbltemplateheadertext.AutoSize = true;
            this.lbltemplateheadertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltemplateheadertext.Location = new System.Drawing.Point(197, 22);
            this.lbltemplateheadertext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltemplateheadertext.Name = "lbltemplateheadertext";
            this.lbltemplateheadertext.Size = new System.Drawing.Size(155, 20);
            this.lbltemplateheadertext.TabIndex = 24;
            this.lbltemplateheadertext.Text = "SaveAs Template";
            // 
            // btnsavetemplateop
            // 
            this.btnsavetemplateop.Enabled = false;
            this.btnsavetemplateop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsavetemplateop.Location = new System.Drawing.Point(160, 107);
            this.btnsavetemplateop.Margin = new System.Windows.Forms.Padding(4);
            this.btnsavetemplateop.Name = "btnsavetemplateop";
            this.btnsavetemplateop.Size = new System.Drawing.Size(99, 35);
            this.btnsavetemplateop.TabIndex = 25;
            this.btnsavetemplateop.Text = "      Save";
            this.btnsavetemplateop.UseVisualStyleBackColor = true;
            this.btnsavetemplateop.Click += new System.EventHandler(this.btnsavetemplateop_Click);
            // 
            // gbsaveas
            // 
            this.gbsaveas.Controls.Add(this.txtTewmpName);
            this.gbsaveas.Controls.Add(this.lbltemp);
            this.gbsaveas.Controls.Add(this.btnSelect);
            this.gbsaveas.Controls.Add(this.label1);
            this.gbsaveas.Controls.Add(this.btnClose);
            this.gbsaveas.Controls.Add(this.cmbtemplate);
            this.gbsaveas.Controls.Add(this.btnsavetemplateop);
            this.gbsaveas.Controls.Add(this.lbltemplatename);
            this.gbsaveas.Controls.Add(this.txttemplate);
            this.gbsaveas.Controls.Add(this.lblseltemplate);
            this.gbsaveas.Location = new System.Drawing.Point(29, 47);
            this.gbsaveas.Margin = new System.Windows.Forms.Padding(4);
            this.gbsaveas.Name = "gbsaveas";
            this.gbsaveas.Padding = new System.Windows.Forms.Padding(4);
            this.gbsaveas.Size = new System.Drawing.Size(532, 159);
            this.gbsaveas.TabIndex = 26;
            this.gbsaveas.TabStop = false;
            // 
            // txtTewmpName
            // 
            this.txtTewmpName.Location = new System.Drawing.Point(143, 23);
            this.txtTewmpName.Name = "txtTewmpName";
            this.txtTewmpName.Size = new System.Drawing.Size(361, 22);
            this.txtTewmpName.TabIndex = 33;
            this.txtTewmpName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbltemp
            // 
            this.lbltemp.AutoSize = true;
            this.lbltemp.Location = new System.Drawing.Point(282, 62);
            this.lbltemp.Name = "lbltemp";
            this.lbltemp.Size = new System.Drawing.Size(0, 17);
            this.lbltemp.TabIndex = 32;
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::LabelConnector.Properties.Resources.openfile;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(143, 53);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(125, 36);
            this.btnSelect.TabIndex = 31;
            this.btnSelect.Text = "      Create...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Create Location:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(337, 107);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 35);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "     Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmTemplateOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 217);
            this.Controls.Add(this.gbsaveas);
            this.Controls.Add(this.lbltemplateheadertext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTemplateOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTemplateOperation";
            this.Load += new System.EventHandler(this.FrmTemplateOperation_Load);
            this.gbsaveas.ResumeLayout(false);
            this.gbsaveas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbtemplate;
        private System.Windows.Forms.Label lblseltemplate;
        private System.Windows.Forms.TextBox txttemplate;
        private System.Windows.Forms.Label lbltemplatename;
        private System.Windows.Forms.Label lbltemplateheadertext;
        private System.Windows.Forms.Button btnsavetemplateop;
        private System.Windows.Forms.GroupBox gbsaveas;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbltemp;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTewmpName;
    }
}