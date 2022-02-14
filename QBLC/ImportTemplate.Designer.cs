namespace LabelConnector
{
    partial class ImportTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportTemplate));
            this.gbsaveas = new System.Windows.Forms.GroupBox();
            this.lblfilepath = new System.Windows.Forms.Label();
            this.btnbrowsexml = new System.Windows.Forms.Button();
            this.btnimportClose = new System.Windows.Forms.Button();
            this.btnimporttemplate = new System.Windows.Forms.Button();
            this.lblseltemplate = new System.Windows.Forms.Label();
            this.lbltemplatimportheader = new System.Windows.Forms.Label();
            this.btnopen = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.gbsaveas.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbsaveas
            // 
            this.gbsaveas.Controls.Add(this.btnSelect);
            this.gbsaveas.Controls.Add(this.lblfilepath);
            this.gbsaveas.Controls.Add(this.btnbrowsexml);
            this.gbsaveas.Controls.Add(this.btnimportClose);
            this.gbsaveas.Controls.Add(this.lblseltemplate);
            this.gbsaveas.Controls.Add(this.btnopen);
            this.gbsaveas.Controls.Add(this.btnimporttemplate);
            this.gbsaveas.Location = new System.Drawing.Point(16, 46);
            this.gbsaveas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbsaveas.Name = "gbsaveas";
            this.gbsaveas.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbsaveas.Size = new System.Drawing.Size(556, 160);
            this.gbsaveas.TabIndex = 28;
            this.gbsaveas.TabStop = false;
            // 
            // lblfilepath
            // 
            this.lblfilepath.AutoSize = true;
            this.lblfilepath.Location = new System.Drawing.Point(293, 33);
            this.lblfilepath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfilepath.Name = "lblfilepath";
            this.lblfilepath.Size = new System.Drawing.Size(36, 17);
            this.lblfilepath.TabIndex = 28;
            this.lblfilepath.Text = "path";
            // 
            // btnbrowsexml
            // 
            this.btnbrowsexml.Image = global::LabelConnector.Properties.Resources.openfile;
            this.btnbrowsexml.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbrowsexml.Location = new System.Drawing.Point(160, 23);
            this.btnbrowsexml.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnbrowsexml.Name = "btnbrowsexml";
            this.btnbrowsexml.Size = new System.Drawing.Size(125, 36);
            this.btnbrowsexml.TabIndex = 27;
            this.btnbrowsexml.Text = "      Select...";
            this.btnbrowsexml.UseVisualStyleBackColor = true;
            this.btnbrowsexml.Visible = false;
            this.btnbrowsexml.Click += new System.EventHandler(this.btnbrowsexml_Click);
            // 
            // btnimportClose
            // 
            this.btnimportClose.Image = ((System.Drawing.Image)(resources.GetObject("btnimportClose.Image")));
            this.btnimportClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnimportClose.Location = new System.Drawing.Point(284, 90);
            this.btnimportClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnimportClose.Name = "btnimportClose";
            this.btnimportClose.Size = new System.Drawing.Size(99, 36);
            this.btnimportClose.TabIndex = 26;
            this.btnimportClose.Text = "     Close";
            this.btnimportClose.UseVisualStyleBackColor = true;
            this.btnimportClose.Click += new System.EventHandler(this.btnimportClose_Click);
            // 
            // btnimporttemplate
            // 
            this.btnimporttemplate.Enabled = false;
            this.btnimporttemplate.Image = global::LabelConnector.Properties.Resources.import16_x161;
            this.btnimporttemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnimporttemplate.Location = new System.Drawing.Point(160, 90);
            this.btnimporttemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnimporttemplate.Name = "btnimporttemplate";
            this.btnimporttemplate.Size = new System.Drawing.Size(99, 36);
            this.btnimporttemplate.TabIndex = 25;
            this.btnimporttemplate.Text = "    Import";
            this.btnimporttemplate.UseVisualStyleBackColor = true;
            this.btnimporttemplate.Visible = false;
            this.btnimporttemplate.Click += new System.EventHandler(this.btnimporttemplate_Click);
            // 
            // lblseltemplate
            // 
            this.lblseltemplate.AutoSize = true;
            this.lblseltemplate.Location = new System.Drawing.Point(19, 27);
            this.lblseltemplate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblseltemplate.Name = "lblseltemplate";
            this.lblseltemplate.Size = new System.Drawing.Size(133, 17);
            this.lblseltemplate.TabIndex = 22;
            this.lblseltemplate.Text = "Select xml template:";
            // 
            // lbltemplatimportheader
            // 
            this.lbltemplatimportheader.AutoSize = true;
            this.lbltemplatimportheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltemplatimportheader.Location = new System.Drawing.Point(184, 21);
            this.lbltemplatimportheader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltemplatimportheader.Name = "lbltemplatimportheader";
            this.lbltemplatimportheader.Size = new System.Drawing.Size(136, 20);
            this.lbltemplatimportheader.TabIndex = 27;
            this.lbltemplatimportheader.Text = "Open Template";
            // 
            // btnopen
            // 
            this.btnopen.Enabled = false;
            this.btnopen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnopen.Location = new System.Drawing.Point(160, 90);
            this.btnopen.Margin = new System.Windows.Forms.Padding(4);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(99, 36);
            this.btnopen.TabIndex = 29;
            this.btnopen.Text = "    Open";
            this.btnopen.UseVisualStyleBackColor = true;
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::LabelConnector.Properties.Resources.openfile;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(160, 23);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(125, 36);
            this.btnSelect.TabIndex = 30;
            this.btnSelect.Text = "      Select...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ImportTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 254);
            this.Controls.Add(this.gbsaveas);
            this.Controls.Add(this.lbltemplatimportheader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Template";
            this.Load += new System.EventHandler(this.ImportTemplate_Load);
            this.gbsaveas.ResumeLayout(false);
            this.gbsaveas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbsaveas;
        private System.Windows.Forms.Button btnbrowsexml;
        private System.Windows.Forms.Button btnimportClose;
        private System.Windows.Forms.Button btnimporttemplate;
        private System.Windows.Forms.Label lblseltemplate;
        private System.Windows.Forms.Label lbltemplatimportheader;
        private System.Windows.Forms.Label lblfilepath;
        private System.Windows.Forms.Button btnopen;
        private System.Windows.Forms.Button btnSelect;
    }
}