
namespace LabelConnector
{
    partial class FrmAddLineProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddLineProperty));
            this.lblfieldpropertytext = new System.Windows.Forms.Label();
            this.cmborientation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddLineProperty = new System.Windows.Forms.Label();
            this.lbltemplateheaderwidth = new System.Windows.Forms.Label();
            this.txtimagename = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtaddimgwidth = new System.Windows.Forms.TextBox();
            this.lbladdimgwidth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtaddimgheight = new System.Windows.Forms.TextBox();
            this.Thickness = new System.Windows.Forms.Label();
            this.pnlbutton = new System.Windows.Forms.Panel();
            this.btnReposition = new System.Windows.Forms.Button();
            this.btnaddimgcancel = new System.Windows.Forms.Button();
            this.btnAddLine = new System.Windows.Forms.Button();
            this.pnlbutton.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblfieldpropertytext
            // 
            this.lblfieldpropertytext.AutoSize = true;
            this.lblfieldpropertytext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfieldpropertytext.Location = new System.Drawing.Point(118, -29);
            this.lblfieldpropertytext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfieldpropertytext.Name = "lblfieldpropertytext";
            this.lblfieldpropertytext.Size = new System.Drawing.Size(181, 20);
            this.lblfieldpropertytext.TabIndex = 73;
            this.lblfieldpropertytext.Text = "Add Field Properties";
            // 
            // cmborientation
            // 
            this.cmborientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmborientation.FormattingEnabled = true;
            this.cmborientation.Location = new System.Drawing.Point(207, 117);
            this.cmborientation.Margin = new System.Windows.Forms.Padding(4);
            this.cmborientation.Name = "cmborientation";
            this.cmborientation.Size = new System.Drawing.Size(127, 24);
            this.cmborientation.TabIndex = 9;
            this.cmborientation.SelectedIndexChanged += new System.EventHandler(this.cmborientation_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 104;
            this.label1.Text = "Orientation:";
            // 
            // lblAddLineProperty
            // 
            this.lblAddLineProperty.AutoSize = true;
            this.lblAddLineProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddLineProperty.Location = new System.Drawing.Point(158, 31);
            this.lblAddLineProperty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddLineProperty.Name = "lblAddLineProperty";
            this.lblAddLineProperty.Size = new System.Drawing.Size(176, 20);
            this.lblAddLineProperty.TabIndex = 76;
            this.lblAddLineProperty.Text = "Add Line Properties";
            // 
            // lbltemplateheaderwidth
            // 
            this.lbltemplateheaderwidth.AutoSize = true;
            this.lbltemplateheaderwidth.Location = new System.Drawing.Point(117, 85);
            this.lbltemplateheaderwidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltemplateheaderwidth.Name = "lbltemplateheaderwidth";
            this.lbltemplateheaderwidth.Size = new System.Drawing.Size(80, 17);
            this.lbltemplateheaderwidth.TabIndex = 90;
            this.lbltemplateheaderwidth.Text = "Line Name:";
            // 
            // txtimagename
            // 
            this.txtimagename.Location = new System.Drawing.Point(207, 82);
            this.txtimagename.Margin = new System.Windows.Forms.Padding(4);
            this.txtimagename.Name = "txtimagename";
            this.txtimagename.Size = new System.Drawing.Size(239, 22);
            this.txtimagename.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label5.Location = new System.Drawing.Point(320, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 17);
            this.label5.TabIndex = 131;
            this.label5.Text = "In.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtaddimgwidth
            // 
            this.txtaddimgwidth.Location = new System.Drawing.Point(206, 153);
            this.txtaddimgwidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtaddimgwidth.MaxLength = 6;
            this.txtaddimgwidth.Name = "txtaddimgwidth";
            this.txtaddimgwidth.Size = new System.Drawing.Size(113, 22);
            this.txtaddimgwidth.TabIndex = 126;
            this.txtaddimgwidth.TextChanged += new System.EventHandler(this.txtaddimgwidth_TextChanged);
            this.txtaddimgwidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaddimgwidth_KeyPress);
            // 
            // lbladdimgwidth
            // 
            this.lbladdimgwidth.AutoSize = true;
            this.lbladdimgwidth.Location = new System.Drawing.Point(146, 157);
            this.lbladdimgwidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbladdimgwidth.Name = "lbladdimgwidth";
            this.lbladdimgwidth.Size = new System.Drawing.Size(48, 17);
            this.lbladdimgwidth.TabIndex = 128;
            this.lbladdimgwidth.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(320, 197);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 134;
            this.label2.Text = "Px.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtaddimgheight
            // 
            this.txtaddimgheight.Location = new System.Drawing.Point(206, 191);
            this.txtaddimgheight.Margin = new System.Windows.Forms.Padding(4);
            this.txtaddimgheight.MaxLength = 6;
            this.txtaddimgheight.Name = "txtaddimgheight";
            this.txtaddimgheight.Size = new System.Drawing.Size(113, 22);
            this.txtaddimgheight.TabIndex = 132;
            this.txtaddimgheight.TextChanged += new System.EventHandler(this.txtaddimgheight_TextChanged);
            this.txtaddimgheight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaddimgheight_KeyPress);
            // 
            // Thickness
            // 
            this.Thickness.AutoSize = true;
            this.Thickness.Location = new System.Drawing.Point(119, 193);
            this.Thickness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Thickness.Name = "Thickness";
            this.Thickness.Size = new System.Drawing.Size(76, 17);
            this.Thickness.TabIndex = 133;
            this.Thickness.Text = "Thickness:";
            // 
            // pnlbutton
            // 
            this.pnlbutton.Controls.Add(this.btnReposition);
            this.pnlbutton.Controls.Add(this.btnaddimgcancel);
            this.pnlbutton.Controls.Add(this.btnAddLine);
            this.pnlbutton.Location = new System.Drawing.Point(62, 233);
            this.pnlbutton.Name = "pnlbutton";
            this.pnlbutton.Size = new System.Drawing.Size(384, 41);
            this.pnlbutton.TabIndex = 115;
            // 
            // btnReposition
            // 
            this.btnReposition.Image = global::LabelConnector.Properties.Resources.restore_pagesmall;
            this.btnReposition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReposition.Location = new System.Drawing.Point(4, 0);
            this.btnReposition.Margin = new System.Windows.Forms.Padding(4);
            this.btnReposition.Name = "btnReposition";
            this.btnReposition.Size = new System.Drawing.Size(138, 41);
            this.btnReposition.TabIndex = 17;
            this.btnReposition.Text = "           Reposition";
            this.btnReposition.UseVisualStyleBackColor = true;
            this.btnReposition.Click += new System.EventHandler(this.btnReposition_Click);
            // 
            // btnaddimgcancel
            // 
            this.btnaddimgcancel.Image = ((System.Drawing.Image)(resources.GetObject("btnaddimgcancel.Image")));
            this.btnaddimgcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddimgcancel.Location = new System.Drawing.Point(270, 0);
            this.btnaddimgcancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnaddimgcancel.Name = "btnaddimgcancel";
            this.btnaddimgcancel.Size = new System.Drawing.Size(114, 40);
            this.btnaddimgcancel.TabIndex = 16;
            this.btnaddimgcancel.Text = "      Close";
            this.btnaddimgcancel.UseVisualStyleBackColor = true;
            this.btnaddimgcancel.Click += new System.EventHandler(this.btnaddimgcancel_Click);
            // 
            // btnAddLine
            // 
            this.btnAddLine.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLine.Image")));
            this.btnAddLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddLine.Location = new System.Drawing.Point(150, 0);
            this.btnAddLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(112, 41);
            this.btnAddLine.TabIndex = 15;
            this.btnAddLine.Text = "     Save";
            this.btnAddLine.UseVisualStyleBackColor = true;
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // FrmAddLineProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 319);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtaddimgheight);
            this.Controls.Add(this.Thickness);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtaddimgwidth);
            this.Controls.Add(this.lbladdimgwidth);
            this.Controls.Add(this.pnlbutton);
            this.Controls.Add(this.lblAddLineProperty);
            this.Controls.Add(this.cmborientation);
            this.Controls.Add(this.lblfieldpropertytext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtimagename);
            this.Controls.Add(this.lbltemplateheaderwidth);
            this.Location = new System.Drawing.Point(350, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddLineProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Field Properties";
            this.Load += new System.EventHandler(this.FrmAddLineProperty_Load);
            this.pnlbutton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblfieldpropertytext;
        private System.Windows.Forms.ComboBox cmborientation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddLineProperty;
        private System.Windows.Forms.Label lbltemplateheaderwidth;
        private System.Windows.Forms.TextBox txtimagename;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtaddimgwidth;
        private System.Windows.Forms.Label lbladdimgwidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtaddimgheight;
        private System.Windows.Forms.Label Thickness;
        private System.Windows.Forms.Button btnAddLine;
        private System.Windows.Forms.Panel pnlbutton;
        private System.Windows.Forms.Button btnReposition;
        private System.Windows.Forms.Button btnaddimgcancel;
    }
}