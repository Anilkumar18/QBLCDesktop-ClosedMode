namespace LabelConnector
{
    partial class FrmAddImages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddImages));
            this.txtimagename = new System.Windows.Forms.TextBox();
            this.lblimagename = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblxposimg = new System.Windows.Forms.Label();
            this.txtxposimg = new System.Windows.Forms.TextBox();
            this.lbllabeladdimges = new System.Windows.Forms.Label();
            this.pnladdimages = new System.Windows.Forms.Panel();
            this.RadioVariableImage = new System.Windows.Forms.RadioButton();
            this.RadioUseFixedImage = new System.Windows.Forms.RadioButton();
            this.cmbdatasource = new System.Windows.Forms.ComboBox();
            this.lblDatasource = new System.Windows.Forms.Label();
            this.txtdesignerheght = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmborientation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbrowsefilepath = new System.Windows.Forms.TextBox();
            this.btnbrowseimage = new System.Windows.Forms.Button();
            this.lblseltemplate = new System.Windows.Forms.Label();
            this.lblaspectratio = new System.Windows.Forms.Label();
            this.chkaspectratio = new System.Windows.Forms.CheckBox();
            this.txtaddimgheight = new System.Windows.Forms.TextBox();
            this.lbladdimgheight = new System.Windows.Forms.Label();
            this.txtaddimgwidth = new System.Windows.Forms.TextBox();
            this.lbladdimgwidth = new System.Windows.Forms.Label();
            this.btnaddimgcancel = new System.Windows.Forms.Button();
            this.btnaddimages = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblYposimg = new System.Windows.Forms.Label();
            this.txtxopos = new System.Windows.Forms.TextBox();
            this.txtyopos = new System.Windows.Forms.TextBox();
            this.txtyposimg = new System.Windows.Forms.TextBox();
            this.gbaddimg = new System.Windows.Forms.GroupBox();
            this.pnladdimages.SuspendLayout();
            this.gbaddimg.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtimagename
            // 
            this.txtimagename.Location = new System.Drawing.Point(144, 25);
            this.txtimagename.Margin = new System.Windows.Forms.Padding(4);
            this.txtimagename.Name = "txtimagename";
            this.txtimagename.Size = new System.Drawing.Size(233, 22);
            this.txtimagename.TabIndex = 1;
            this.txtimagename.TextChanged += new System.EventHandler(this.txtimagename_TextChanged);
            // 
            // lblimagename
            // 
            this.lblimagename.AutoSize = true;
            this.lblimagename.Location = new System.Drawing.Point(45, 25);
            this.lblimagename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblimagename.Name = "lblimagename";
            this.lblimagename.Size = new System.Drawing.Size(91, 17);
            this.lblimagename.TabIndex = 108;
            this.lblimagename.Text = "Image Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label3.Location = new System.Drawing.Point(267, 302);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 110;
            this.label3.Text = "In.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Visible = false;
            // 
            // lblxposimg
            // 
            this.lblxposimg.AutoSize = true;
            this.lblxposimg.Location = new System.Drawing.Point(60, 297);
            this.lblxposimg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblxposimg.Name = "lblxposimg";
            this.lblxposimg.Size = new System.Drawing.Size(76, 17);
            this.lblxposimg.TabIndex = 109;
            this.lblxposimg.Text = "X-Position:";
            // 
            // txtxposimg
            // 
            this.txtxposimg.Enabled = false;
            this.txtxposimg.Location = new System.Drawing.Point(144, 293);
            this.txtxposimg.Margin = new System.Windows.Forms.Padding(4);
            this.txtxposimg.Name = "txtxposimg";
            this.txtxposimg.Size = new System.Drawing.Size(113, 22);
            this.txtxposimg.TabIndex = 6;
            this.txtxposimg.TextChanged += new System.EventHandler(this.txtxposimg_TextChanged);
            this.txtxposimg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtxposimg_KeyPress);
            // 
            // lbllabeladdimges
            // 
            this.lbllabeladdimges.AutoSize = true;
            this.lbllabeladdimges.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllabeladdimges.Location = new System.Drawing.Point(243, 18);
            this.lbllabeladdimges.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllabeladdimges.Name = "lbllabeladdimges";
            this.lbllabeladdimges.Size = new System.Drawing.Size(107, 20);
            this.lbllabeladdimges.TabIndex = 111;
            this.lbllabeladdimges.Text = "Add Images";
            // 
            // pnladdimages
            // 
            this.pnladdimages.Controls.Add(this.RadioVariableImage);
            this.pnladdimages.Controls.Add(this.RadioUseFixedImage);
            this.pnladdimages.Controls.Add(this.cmbdatasource);
            this.pnladdimages.Controls.Add(this.lblDatasource);
            this.pnladdimages.Controls.Add(this.txtdesignerheght);
            this.pnladdimages.Controls.Add(this.label5);
            this.pnladdimages.Controls.Add(this.label4);
            this.pnladdimages.Controls.Add(this.cmborientation);
            this.pnladdimages.Controls.Add(this.label2);
            this.pnladdimages.Controls.Add(this.txtbrowsefilepath);
            this.pnladdimages.Controls.Add(this.btnbrowseimage);
            this.pnladdimages.Controls.Add(this.lblseltemplate);
            this.pnladdimages.Controls.Add(this.lblaspectratio);
            this.pnladdimages.Controls.Add(this.chkaspectratio);
            this.pnladdimages.Controls.Add(this.txtaddimgheight);
            this.pnladdimages.Controls.Add(this.lbladdimgheight);
            this.pnladdimages.Controls.Add(this.txtaddimgwidth);
            this.pnladdimages.Controls.Add(this.lbladdimgwidth);
            this.pnladdimages.Controls.Add(this.btnaddimgcancel);
            this.pnladdimages.Controls.Add(this.btnaddimages);
            this.pnladdimages.Controls.Add(this.label1);
            this.pnladdimages.Controls.Add(this.lblYposimg);
            this.pnladdimages.Controls.Add(this.txtimagename);
            this.pnladdimages.Controls.Add(this.lblimagename);
            this.pnladdimages.Controls.Add(this.label3);
            this.pnladdimages.Controls.Add(this.lblxposimg);
            this.pnladdimages.Controls.Add(this.txtxopos);
            this.pnladdimages.Controls.Add(this.txtyopos);
            this.pnladdimages.Controls.Add(this.txtyposimg);
            this.pnladdimages.Controls.Add(this.txtxposimg);
            this.pnladdimages.Location = new System.Drawing.Point(37, 42);
            this.pnladdimages.Margin = new System.Windows.Forms.Padding(4);
            this.pnladdimages.Name = "pnladdimages";
            this.pnladdimages.Size = new System.Drawing.Size(567, 417);
            this.pnladdimages.TabIndex = 112;
            // 
            // RadioVariableImage
            // 
            this.RadioVariableImage.AutoSize = true;
            this.RadioVariableImage.Location = new System.Drawing.Point(284, 58);
            this.RadioVariableImage.Name = "RadioVariableImage";
            this.RadioVariableImage.Size = new System.Drawing.Size(152, 21);
            this.RadioVariableImage.TabIndex = 133;
            this.RadioVariableImage.TabStop = true;
            this.RadioVariableImage.Text = "Use Variable Image";
            this.RadioVariableImage.UseVisualStyleBackColor = true;
            this.RadioVariableImage.CheckedChanged += new System.EventHandler(this.RadioVariableImage_CheckedChanged);
            // 
            // RadioUseFixedImage
            // 
            this.RadioUseFixedImage.AutoSize = true;
            this.RadioUseFixedImage.Location = new System.Drawing.Point(145, 58);
            this.RadioUseFixedImage.Name = "RadioUseFixedImage";
            this.RadioUseFixedImage.Size = new System.Drawing.Size(133, 21);
            this.RadioUseFixedImage.TabIndex = 132;
            this.RadioUseFixedImage.TabStop = true;
            this.RadioUseFixedImage.Text = "Use Fixed Image";
            this.RadioUseFixedImage.UseVisualStyleBackColor = true;
            this.RadioUseFixedImage.CheckedChanged += new System.EventHandler(this.RadioUseFixedImage_CheckedChanged);
            // 
            // cmbdatasource
            // 
            this.cmbdatasource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdatasource.FormattingEnabled = true;
            this.cmbdatasource.Location = new System.Drawing.Point(144, 132);
            this.cmbdatasource.Name = "cmbdatasource";
            this.cmbdatasource.Size = new System.Drawing.Size(232, 24);
            this.cmbdatasource.TabIndex = 4;
            this.cmbdatasource.SelectedIndexChanged += new System.EventHandler(this.cmbdatasource_SelectedIndexChanged);
            // 
            // lblDatasource
            // 
            this.lblDatasource.AutoSize = true;
            this.lblDatasource.Location = new System.Drawing.Point(41, 132);
            this.lblDatasource.Name = "lblDatasource";
            this.lblDatasource.Size = new System.Drawing.Size(91, 17);
            this.lblDatasource.TabIndex = 131;
            this.lblDatasource.Text = "Data Source:";
            // 
            // txtdesignerheght
            // 
            this.txtdesignerheght.Location = new System.Drawing.Point(326, 302);
            this.txtdesignerheght.Name = "txtdesignerheght";
            this.txtdesignerheght.Size = new System.Drawing.Size(10, 22);
            this.txtdesignerheght.TabIndex = 130;
            this.txtdesignerheght.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label5.Location = new System.Drawing.Point(268, 205);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 17);
            this.label5.TabIndex = 125;
            this.label5.Text = "In.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(267, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 17);
            this.label4.TabIndex = 124;
            this.label4.Text = "In.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmborientation
            // 
            this.cmborientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmborientation.FormattingEnabled = true;
            this.cmborientation.Location = new System.Drawing.Point(144, 260);
            this.cmborientation.Margin = new System.Windows.Forms.Padding(4);
            this.cmborientation.Name = "cmborientation";
            this.cmborientation.Size = new System.Drawing.Size(113, 24);
            this.cmborientation.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 264);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 115;
            this.label2.Text = "Orientation:";
            // 
            // txtbrowsefilepath
            // 
            this.txtbrowsefilepath.Location = new System.Drawing.Point(144, 94);
            this.txtbrowsefilepath.Margin = new System.Windows.Forms.Padding(4);
            this.txtbrowsefilepath.Name = "txtbrowsefilepath";
            this.txtbrowsefilepath.Size = new System.Drawing.Size(288, 22);
            this.txtbrowsefilepath.TabIndex = 2;
            this.txtbrowsefilepath.TextChanged += new System.EventHandler(this.txtbrowsefilepath_TextChanged);
            // 
            // btnbrowseimage
            // 
            this.btnbrowseimage.Image = global::LabelConnector.Properties.Resources.openfile;
            this.btnbrowseimage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbrowseimage.Location = new System.Drawing.Point(440, 91);
            this.btnbrowseimage.Margin = new System.Windows.Forms.Padding(4);
            this.btnbrowseimage.Name = "btnbrowseimage";
            this.btnbrowseimage.Size = new System.Drawing.Size(96, 30);
            this.btnbrowseimage.TabIndex = 3;
            this.btnbrowseimage.Text = "       Browse";
            this.btnbrowseimage.UseVisualStyleBackColor = true;
            this.btnbrowseimage.Click += new System.EventHandler(this.btnbrowseimage_Click);
            // 
            // lblseltemplate
            // 
            this.lblseltemplate.AutoSize = true;
            this.lblseltemplate.Location = new System.Drawing.Point(44, 94);
            this.lblseltemplate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblseltemplate.Name = "lblseltemplate";
            this.lblseltemplate.Size = new System.Drawing.Size(93, 17);
            this.lblseltemplate.TabIndex = 122;
            this.lblseltemplate.Text = "Select Image:";
            // 
            // lblaspectratio
            // 
            this.lblaspectratio.AutoSize = true;
            this.lblaspectratio.Location = new System.Drawing.Point(45, 172);
            this.lblaspectratio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblaspectratio.Name = "lblaspectratio";
            this.lblaspectratio.Size = new System.Drawing.Size(92, 17);
            this.lblaspectratio.TabIndex = 121;
            this.lblaspectratio.Text = "Aspect Ratio:";
            // 
            // chkaspectratio
            // 
            this.chkaspectratio.AutoSize = true;
            this.chkaspectratio.Checked = true;
            this.chkaspectratio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkaspectratio.Location = new System.Drawing.Point(145, 172);
            this.chkaspectratio.Margin = new System.Windows.Forms.Padding(4);
            this.chkaspectratio.Name = "chkaspectratio";
            this.chkaspectratio.Size = new System.Drawing.Size(18, 17);
            this.chkaspectratio.TabIndex = 5;
            this.chkaspectratio.UseVisualStyleBackColor = true;
            // 
            // txtaddimgheight
            // 
            this.txtaddimgheight.Location = new System.Drawing.Point(145, 228);
            this.txtaddimgheight.Margin = new System.Windows.Forms.Padding(4);
            this.txtaddimgheight.MaxLength = 6;
            this.txtaddimgheight.Name = "txtaddimgheight";
            this.txtaddimgheight.Size = new System.Drawing.Size(113, 22);
            this.txtaddimgheight.TabIndex = 7;
            this.txtaddimgheight.TextChanged += new System.EventHandler(this.txtaddimgheight_TextChanged);
            this.txtaddimgheight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaddimgheight_KeyPress);
            this.txtaddimgheight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtaddimgheight_KeyUp);
            // 
            // lbladdimgheight
            // 
            this.lbladdimgheight.AutoSize = true;
            this.lbladdimgheight.Location = new System.Drawing.Point(85, 232);
            this.lbladdimgheight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbladdimgheight.Name = "lbladdimgheight";
            this.lbladdimgheight.Size = new System.Drawing.Size(53, 17);
            this.lbladdimgheight.TabIndex = 119;
            this.lbladdimgheight.Text = "Height:";
            // 
            // txtaddimgwidth
            // 
            this.txtaddimgwidth.Location = new System.Drawing.Point(145, 196);
            this.txtaddimgwidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtaddimgwidth.MaxLength = 6;
            this.txtaddimgwidth.Name = "txtaddimgwidth";
            this.txtaddimgwidth.Size = new System.Drawing.Size(113, 22);
            this.txtaddimgwidth.TabIndex = 6;
            this.txtaddimgwidth.TextChanged += new System.EventHandler(this.txtaddimgwidth_TextChanged);
            this.txtaddimgwidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaddimgwidth_KeyPress);
            this.txtaddimgwidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtaddimgwidth_KeyUp);
            // 
            // lbladdimgwidth
            // 
            this.lbladdimgwidth.AutoSize = true;
            this.lbladdimgwidth.Location = new System.Drawing.Point(85, 200);
            this.lbladdimgwidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbladdimgwidth.Name = "lbladdimgwidth";
            this.lbladdimgwidth.Size = new System.Drawing.Size(48, 17);
            this.lbladdimgwidth.TabIndex = 117;
            this.lbladdimgwidth.Text = "Width:";
            // 
            // btnaddimgcancel
            // 
            this.btnaddimgcancel.Image = ((System.Drawing.Image)(resources.GetObject("btnaddimgcancel.Image")));
            this.btnaddimgcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddimgcancel.Location = new System.Drawing.Point(282, 361);
            this.btnaddimgcancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnaddimgcancel.Name = "btnaddimgcancel";
            this.btnaddimgcancel.Size = new System.Drawing.Size(100, 36);
            this.btnaddimgcancel.TabIndex = 10;
            this.btnaddimgcancel.Text = "      Close";
            this.btnaddimgcancel.UseVisualStyleBackColor = true;
            this.btnaddimgcancel.Click += new System.EventHandler(this.btnaddimgcancel_Click);
            // 
            // btnaddimages
            // 
            this.btnaddimages.Image = ((System.Drawing.Image)(resources.GetObject("btnaddimages.Image")));
            this.btnaddimages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnaddimages.Location = new System.Drawing.Point(167, 361);
            this.btnaddimages.Margin = new System.Windows.Forms.Padding(4);
            this.btnaddimages.Name = "btnaddimages";
            this.btnaddimages.Size = new System.Drawing.Size(100, 36);
            this.btnaddimages.TabIndex = 9;
            this.btnaddimages.Text = "     Save";
            this.btnaddimages.UseVisualStyleBackColor = true;
            this.btnaddimages.Click += new System.EventHandler(this.btnaddimages_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(267, 334);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 113;
            this.label1.Text = "In.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // lblYposimg
            // 
            this.lblYposimg.AutoSize = true;
            this.lblYposimg.Location = new System.Drawing.Point(59, 329);
            this.lblYposimg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYposimg.Name = "lblYposimg";
            this.lblYposimg.Size = new System.Drawing.Size(76, 17);
            this.lblYposimg.TabIndex = 112;
            this.lblYposimg.Text = "Y-Position:";
            // 
            // txtxopos
            // 
            this.txtxopos.Location = new System.Drawing.Point(144, 293);
            this.txtxopos.Name = "txtxopos";
            this.txtxopos.Size = new System.Drawing.Size(113, 22);
            this.txtxopos.TabIndex = 112;
            this.txtxopos.Visible = false;
            this.txtxopos.TextChanged += new System.EventHandler(this.txtxopos_TextChanged);
            // 
            // txtyopos
            // 
            this.txtyopos.Location = new System.Drawing.Point(144, 325);
            this.txtyopos.Name = "txtyopos";
            this.txtyopos.Size = new System.Drawing.Size(113, 22);
            this.txtyopos.TabIndex = 110;
            this.txtyopos.Visible = false;
            this.txtyopos.TextChanged += new System.EventHandler(this.txtyopos_TextChanged);
            // 
            // txtyposimg
            // 
            this.txtyposimg.Enabled = false;
            this.txtyposimg.Location = new System.Drawing.Point(144, 325);
            this.txtyposimg.Margin = new System.Windows.Forms.Padding(4);
            this.txtyposimg.Name = "txtyposimg";
            this.txtyposimg.Size = new System.Drawing.Size(113, 22);
            this.txtyposimg.TabIndex = 7;
            this.txtyposimg.TextChanged += new System.EventHandler(this.txtyposimg_TextChanged);
            this.txtyposimg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtyposimg_KeyPress);
            // 
            // gbaddimg
            // 
            this.gbaddimg.Controls.Add(this.pnladdimages);
            this.gbaddimg.Controls.Add(this.lbllabeladdimges);
            this.gbaddimg.Location = new System.Drawing.Point(16, 15);
            this.gbaddimg.Margin = new System.Windows.Forms.Padding(4);
            this.gbaddimg.Name = "gbaddimg";
            this.gbaddimg.Padding = new System.Windows.Forms.Padding(4);
            this.gbaddimg.Size = new System.Drawing.Size(634, 467);
            this.gbaddimg.TabIndex = 113;
            this.gbaddimg.TabStop = false;
            // 
            // FrmAddImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 495);
            this.Controls.Add(this.gbaddimg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddImages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Images";
            this.Load += new System.EventHandler(this.FrmAddImages_Load);
            this.pnladdimages.ResumeLayout(false);
            this.pnladdimages.PerformLayout();
            this.gbaddimg.ResumeLayout(false);
            this.gbaddimg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtimagename;
        private System.Windows.Forms.Label lblimagename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblxposimg;
        private System.Windows.Forms.TextBox txtxposimg;
        private System.Windows.Forms.Label lbllabeladdimges;
        private System.Windows.Forms.Panel pnladdimages;
        private System.Windows.Forms.TextBox txtyposimg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblYposimg;
        private System.Windows.Forms.Button btnaddimgcancel;
        private System.Windows.Forms.Button btnaddimages;
        private System.Windows.Forms.TextBox txtaddimgheight;
        private System.Windows.Forms.Label lbladdimgheight;
        private System.Windows.Forms.TextBox txtaddimgwidth;
        private System.Windows.Forms.Label lbladdimgwidth;
        private System.Windows.Forms.Label lblaspectratio;
        private System.Windows.Forms.CheckBox chkaspectratio;
        private System.Windows.Forms.Button btnbrowseimage;
        private System.Windows.Forms.Label lblseltemplate;
        private System.Windows.Forms.GroupBox gbaddimg;
        private System.Windows.Forms.TextBox txtbrowsefilepath;
        private System.Windows.Forms.ComboBox cmborientation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtxopos;
        private System.Windows.Forms.TextBox txtyopos;
        private System.Windows.Forms.TextBox txtdesignerheght;
        private System.Windows.Forms.ComboBox cmbdatasource;
        private System.Windows.Forms.Label lblDatasource;
        private System.Windows.Forms.RadioButton RadioVariableImage;
        private System.Windows.Forms.RadioButton RadioUseFixedImage;
    }
}