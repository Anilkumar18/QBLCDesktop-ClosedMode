namespace LabelConnector
{
    partial class frmSalesReceiptSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesReceiptSetting));
            this.soprintorder = new System.Windows.Forms.GroupBox();
            this.rdoprintlblqty = new System.Windows.Forms.RadioButton();
            this.rdoprintsoqty = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCustomerPhone = new System.Windows.Forms.CheckBox();
            this.chkCustom = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkEnableothercharges = new System.Windows.Forms.CheckBox();
            this.chkcustomfields = new System.Windows.Forms.CheckBox();
            this.soprintorder.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // soprintorder
            // 
            this.soprintorder.Controls.Add(this.rdoprintlblqty);
            this.soprintorder.Controls.Add(this.rdoprintsoqty);
            this.soprintorder.Location = new System.Drawing.Point(23, 18);
            this.soprintorder.Margin = new System.Windows.Forms.Padding(4);
            this.soprintorder.Name = "soprintorder";
            this.soprintorder.Padding = new System.Windows.Forms.Padding(4);
            this.soprintorder.Size = new System.Drawing.Size(643, 74);
            this.soprintorder.TabIndex = 6;
            this.soprintorder.TabStop = false;
            this.soprintorder.Text = "Sales Receipt Print Qty";
            // 
            // rdoprintlblqty
            // 
            this.rdoprintlblqty.AutoSize = true;
            this.rdoprintlblqty.Location = new System.Drawing.Point(238, 38);
            this.rdoprintlblqty.Margin = new System.Windows.Forms.Padding(4);
            this.rdoprintlblqty.Name = "rdoprintlblqty";
            this.rdoprintlblqty.Size = new System.Drawing.Size(175, 21);
            this.rdoprintlblqty.TabIndex = 4;
            this.rdoprintlblqty.Text = "Print 1 Label by default";
            this.rdoprintlblqty.UseVisualStyleBackColor = true;
            // 
            // rdoprintsoqty
            // 
            this.rdoprintsoqty.AutoSize = true;
            this.rdoprintsoqty.Checked = true;
            this.rdoprintsoqty.Location = new System.Drawing.Point(20, 38);
            this.rdoprintsoqty.Margin = new System.Windows.Forms.Padding(4);
            this.rdoprintsoqty.Name = "rdoprintsoqty";
            this.rdoprintsoqty.Size = new System.Drawing.Size(173, 21);
            this.rdoprintsoqty.TabIndex = 3;
            this.rdoprintsoqty.TabStop = true;
            this.rdoprintsoqty.Text = "Print SR Qty by default";
            this.rdoprintsoqty.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(346, 222);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(124, 33);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(196, 222);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 33);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCustomerPhone);
            this.groupBox1.Controls.Add(this.chkCustom);
            this.groupBox1.Location = new System.Drawing.Point(23, 113);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(304, 101);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print Fields";
            // 
            // chkCustomerPhone
            // 
            this.chkCustomerPhone.AutoSize = true;
            this.chkCustomerPhone.Checked = true;
            this.chkCustomerPhone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCustomerPhone.Location = new System.Drawing.Point(20, 61);
            this.chkCustomerPhone.Name = "chkCustomerPhone";
            this.chkCustomerPhone.Size = new System.Drawing.Size(262, 21);
            this.chkCustomerPhone.TabIndex = 13;
            this.chkCustomerPhone.Text = " Include Customer tables in searches";
            this.chkCustomerPhone.UseVisualStyleBackColor = true;
            // 
            // chkCustom
            // 
            this.chkCustom.AutoSize = true;
            this.chkCustom.Checked = true;
            this.chkCustom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCustom.Location = new System.Drawing.Point(20, 33);
            this.chkCustom.Name = "chkCustom";
            this.chkCustom.Size = new System.Drawing.Size(268, 21);
            this.chkCustom.TabIndex = 13;
            this.chkCustom.Text = "Include Item custom fields in searches";
            this.chkCustom.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkEnableothercharges);
            this.groupBox5.Controls.Add(this.chkcustomfields);
            this.groupBox5.Location = new System.Drawing.Point(346, 114);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(320, 100);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Enable fields";
            // 
            // chkEnableothercharges
            // 
            this.chkEnableothercharges.AutoSize = true;
            this.chkEnableothercharges.Checked = true;
            this.chkEnableothercharges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableothercharges.Location = new System.Drawing.Point(49, 29);
            this.chkEnableothercharges.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnableothercharges.Name = "chkEnableothercharges";
            this.chkEnableothercharges.Size = new System.Drawing.Size(171, 21);
            this.chkEnableothercharges.TabIndex = 16;
            this.chkEnableothercharges.Text = "Enable Other Charges";
            this.chkEnableothercharges.UseVisualStyleBackColor = true;
            this.chkEnableothercharges.CheckedChanged += new System.EventHandler(this.chkEnableothercharges_CheckedChanged);
            // 
            // chkcustomfields
            // 
            this.chkcustomfields.AutoSize = true;
            this.chkcustomfields.Checked = true;
            this.chkcustomfields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkcustomfields.Location = new System.Drawing.Point(49, 58);
            this.chkcustomfields.Margin = new System.Windows.Forms.Padding(4);
            this.chkcustomfields.Name = "chkcustomfields";
            this.chkcustomfields.Size = new System.Drawing.Size(199, 21);
            this.chkcustomfields.TabIndex = 15;
            this.chkcustomfields.Text = "Enable Print Custom Fields";
            this.chkcustomfields.UseVisualStyleBackColor = true;
            // 
            // frmSalesReceiptSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 280);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.soprintorder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesReceiptSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Label Connector - Sales Receipt Settings";
            this.Load += new System.EventHandler(this.frmSalesReceiptSetting_Load);
            this.soprintorder.ResumeLayout(false);
            this.soprintorder.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox soprintorder;
        private System.Windows.Forms.RadioButton rdoprintlblqty;
        private System.Windows.Forms.RadioButton rdoprintsoqty;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCustomerPhone;
        private System.Windows.Forms.CheckBox chkCustom;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkEnableothercharges;
        private System.Windows.Forms.CheckBox chkcustomfields;
    }
}