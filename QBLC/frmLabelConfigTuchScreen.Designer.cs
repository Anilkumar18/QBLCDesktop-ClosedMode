namespace LabelConnector
{
    partial class frmLabelConfigTuchScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabelConfigTuchScreen));
            this.pnlFolderSelection = new System.Windows.Forms.Panel();
            this.btnWeatherLabelPath = new System.Windows.Forms.Button();
            this.txtboxWeatherlabelPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtLabelFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlFolderSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFolderSelection
            // 
            this.pnlFolderSelection.Controls.Add(this.btnWeatherLabelPath);
            this.pnlFolderSelection.Controls.Add(this.txtboxWeatherlabelPath);
            this.pnlFolderSelection.Controls.Add(this.label2);
            this.pnlFolderSelection.Controls.Add(this.label1);
            this.pnlFolderSelection.Controls.Add(this.btnBrowse);
            this.pnlFolderSelection.Controls.Add(this.txtLabelFolder);
            this.pnlFolderSelection.Location = new System.Drawing.Point(12, 23);
            this.pnlFolderSelection.Name = "pnlFolderSelection";
            this.pnlFolderSelection.Size = new System.Drawing.Size(820, 103);
            this.pnlFolderSelection.TabIndex = 11;
            // 
            // btnWeatherLabelPath
            // 
            this.btnWeatherLabelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeatherLabelPath.Location = new System.Drawing.Point(614, 120);
            this.btnWeatherLabelPath.Name = "btnWeatherLabelPath";
            this.btnWeatherLabelPath.Size = new System.Drawing.Size(192, 89);
            this.btnWeatherLabelPath.TabIndex = 15;
            this.btnWeatherLabelPath.Text = "Select Weather Label ";
            this.btnWeatherLabelPath.UseVisualStyleBackColor = true;
            this.btnWeatherLabelPath.Click += new System.EventHandler(this.btnWeatherLabelPath_Click);
            // 
            // txtboxWeatherlabelPath
            // 
            this.txtboxWeatherlabelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxWeatherlabelPath.Location = new System.Drawing.Point(193, 144);
            this.txtboxWeatherlabelPath.Name = "txtboxWeatherlabelPath";
            this.txtboxWeatherlabelPath.Size = new System.Drawing.Size(415, 35);
            this.txtboxWeatherlabelPath.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Weather Label Path :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Label Folder Path :";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(614, 7);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(192, 89);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Select Label Folder";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtLabelFolder
            // 
            this.txtLabelFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelFolder.Location = new System.Drawing.Point(193, 31);
            this.txtLabelFolder.Name = "txtLabelFolder";
            this.txtLabelFolder.Size = new System.Drawing.Size(415, 35);
            this.txtLabelFolder.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(434, 132);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(111, 79);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(297, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 79);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmLabelConfigTuchScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 237);
            this.Controls.Add(this.pnlFolderSelection);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLabelConfigTuchScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accuware - Label Connector";
            this.Load += new System.EventHandler(this.frmLabelConfig_Load);
            this.pnlFolderSelection.ResumeLayout(false);
            this.pnlFolderSelection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFolderSelection;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtLabelFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWeatherLabelPath;
        private System.Windows.Forms.TextBox txtboxWeatherlabelPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}