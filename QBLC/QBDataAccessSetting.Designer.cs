namespace LabelConnector
{
    partial class QBDataAccessSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QBDataAccessSetting));
            this.rdoqbopen = new System.Windows.Forms.RadioButton();
            this.rdoqbclose = new System.Windows.Forms.RadioButton();
            this.btnQBDataSaved = new System.Windows.Forms.Button();
            this.btnQBDataCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoqbopen
            // 
            this.rdoqbopen.AutoSize = true;
            this.rdoqbopen.Location = new System.Drawing.Point(57, 71);
            this.rdoqbopen.Name = "rdoqbopen";
            this.rdoqbopen.Size = new System.Drawing.Size(112, 17);
            this.rdoqbopen.TabIndex = 0;
            this.rdoqbopen.TabStop = true;
            this.rdoqbopen.Text = "QuickBooks Open";
            this.rdoqbopen.UseVisualStyleBackColor = true;
            this.rdoqbopen.CheckedChanged += new System.EventHandler(this.rdoqbopen_CheckedChanged);
            // 
            // rdoqbclose
            // 
            this.rdoqbclose.AutoSize = true;
            this.rdoqbclose.Location = new System.Drawing.Point(211, 71);
            this.rdoqbclose.Name = "rdoqbclose";
            this.rdoqbclose.Size = new System.Drawing.Size(115, 17);
            this.rdoqbclose.TabIndex = 1;
            this.rdoqbclose.TabStop = true;
            this.rdoqbclose.Text = "QuickBooks  Close";
            this.rdoqbclose.UseVisualStyleBackColor = true;
            // 
            // btnQBDataSaved
            // 
            this.btnQBDataSaved.Location = new System.Drawing.Point(115, 149);
            this.btnQBDataSaved.Name = "btnQBDataSaved";
            this.btnQBDataSaved.Size = new System.Drawing.Size(75, 23);
            this.btnQBDataSaved.TabIndex = 2;
            this.btnQBDataSaved.Text = "Save";
            this.btnQBDataSaved.UseVisualStyleBackColor = true;
            this.btnQBDataSaved.Click += new System.EventHandler(this.btnQBDataSaved_Click);
            // 
            // btnQBDataCancel
            // 
            this.btnQBDataCancel.Location = new System.Drawing.Point(214, 149);
            this.btnQBDataCancel.Name = "btnQBDataCancel";
            this.btnQBDataCancel.Size = new System.Drawing.Size(75, 23);
            this.btnQBDataCancel.TabIndex = 3;
            this.btnQBDataCancel.Text = "Cancel";
            this.btnQBDataCancel.UseVisualStyleBackColor = true;
            this.btnQBDataCancel.Click += new System.EventHandler(this.btnQBDataCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdoqbopen);
            this.panel1.Controls.Add(this.btnQBDataSaved);
            this.panel1.Controls.Add(this.btnQBDataCancel);
            this.panel1.Controls.Add(this.rdoqbclose);
            this.panel1.Location = new System.Drawing.Point(25, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 224);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(414, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please close the application and re-open to reflect the setting changes.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "How do you want to access QuickBooks data By:";
            // 
            // QBDataAccessSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 248);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QBDataAccessSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accuware-Lable Connector";
            this.Load += new System.EventHandler(this.QBDataAccessSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoqbopen;
        private System.Windows.Forms.RadioButton rdoqbclose;
        private System.Windows.Forms.Button btnQBDataSaved;
        private System.Windows.Forms.Button btnQBDataCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}