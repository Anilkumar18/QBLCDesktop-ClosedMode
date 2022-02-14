namespace LabelConnector
{
    partial class FrmConnectQuickBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConnectQuickBooks));
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblqbmsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEnableOpenMode = new System.Windows.Forms.CheckBox();
            this.ChkEnablePOCloseMode = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCompanyfilePath = new System.Windows.Forms.TextBox();
            this.btnOpenCompanyPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(293, 165);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(4);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(91, 41);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(407, 165);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 41);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblqbmsg
            // 
            this.lblqbmsg.AutoSize = true;
            this.lblqbmsg.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblqbmsg.Location = new System.Drawing.Point(507, 25);
            this.lblqbmsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblqbmsg.Name = "lblqbmsg";
            this.lblqbmsg.Size = new System.Drawing.Size(58, 19);
            this.lblqbmsg.TabIndex = 2;
            this.lblqbmsg.Text = "Admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(677, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "single user mode.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(426, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "To Continue please  Log into QuickBooks as the QuickBooks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(568, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "and switch to";
            // 
            // chkEnableOpenMode
            // 
            this.chkEnableOpenMode.AutoSize = true;
            this.chkEnableOpenMode.Checked = true;
            this.chkEnableOpenMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableOpenMode.Location = new System.Drawing.Point(235, 78);
            this.chkEnableOpenMode.Name = "chkEnableOpenMode";
            this.chkEnableOpenMode.Size = new System.Drawing.Size(149, 21);
            this.chkEnableOpenMode.TabIndex = 6;
            this.chkEnableOpenMode.Text = "Enable open mode";
            this.chkEnableOpenMode.UseVisualStyleBackColor = true;
            this.chkEnableOpenMode.CheckedChanged += new System.EventHandler(this.chkEnableOpenMode_CheckedChanged);
            // 
            // ChkEnablePOCloseMode
            // 
            this.ChkEnablePOCloseMode.AutoSize = true;
            this.ChkEnablePOCloseMode.Location = new System.Drawing.Point(407, 78);
            this.ChkEnablePOCloseMode.Name = "ChkEnablePOCloseMode";
            this.ChkEnablePOCloseMode.Size = new System.Drawing.Size(197, 21);
            this.ChkEnablePOCloseMode.TabIndex = 7;
            this.ChkEnablePOCloseMode.Text = "Enable Close Mode for PO";
            this.ChkEnablePOCloseMode.UseVisualStyleBackColor = true;
            this.ChkEnablePOCloseMode.CheckedChanged += new System.EventHandler(this.ChkEnablePOCloseMode_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Select Company file path :";
            // 
            // txtCompanyfilePath
            // 
            this.txtCompanyfilePath.Location = new System.Drawing.Point(272, 119);
            this.txtCompanyfilePath.Name = "txtCompanyfilePath";
            this.txtCompanyfilePath.Size = new System.Drawing.Size(444, 22);
            this.txtCompanyfilePath.TabIndex = 9;
            this.txtCompanyfilePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompanyfilePath_KeyPress);
            // 
            // btnOpenCompanyPath
            // 
            this.btnOpenCompanyPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenCompanyPath.Location = new System.Drawing.Point(716, 117);
            this.btnOpenCompanyPath.Name = "btnOpenCompanyPath";
            this.btnOpenCompanyPath.Size = new System.Drawing.Size(53, 27);
            this.btnOpenCompanyPath.TabIndex = 10;
            this.btnOpenCompanyPath.Text = ";;;";
            this.btnOpenCompanyPath.UseVisualStyleBackColor = true;
            this.btnOpenCompanyPath.Click += new System.EventHandler(this.btnOpenCompanyPath_Click);
            // 
            // FrmConnectQuickBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 229);
            this.Controls.Add(this.btnOpenCompanyPath);
            this.Controls.Add(this.txtCompanyfilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ChkEnablePOCloseMode);
            this.Controls.Add(this.chkEnableOpenMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblqbmsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnContinue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConnectQuickBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Label Connector-Connect QuickBooks";
            this.Load += new System.EventHandler(this.FrmConnectQuickBooks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblqbmsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEnableOpenMode;
        private System.Windows.Forms.CheckBox ChkEnablePOCloseMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCompanyfilePath;
        private System.Windows.Forms.Button btnOpenCompanyPath;
    }
}