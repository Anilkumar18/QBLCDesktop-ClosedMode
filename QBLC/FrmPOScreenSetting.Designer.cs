namespace LabelConnector
{
    partial class FrmPOScreenSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPOScreenSetting));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rdbwithPO = new System.Windows.Forms.RadioButton();
            this.rdbWithPoreceipt = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.poreceiptitle = new System.Windows.Forms.GroupBox();
            this.poheadercusttitile = new System.Windows.Forms.GroupBox();
            this.pnlDCNumbervisible = new System.Windows.Forms.Panel();
            this.bgpackperunits = new System.Windows.Forms.GroupBox();
            this.txtpackperunitscustomfield = new System.Windows.Forms.TextBox();
            this.lblpackunit = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbwithpackperunits = new System.Windows.Forms.RadioButton();
            this.rdbwithoutpackperunits = new System.Windows.Forms.RadioButton();
            this.poqtypanel = new System.Windows.Forms.Panel();
            this.rdoprintpolblqty = new System.Windows.Forms.RadioButton();
            this.rdoprintpoqty = new System.Windows.Forms.RadioButton();
            this.txtSN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExpDate = new System.Windows.Forms.TextBox();
            this.lblentryone = new System.Windows.Forms.Label();
            this.lblwarng = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbreceiptoneqty = new System.Windows.Forms.RadioButton();
            this.rbreceiptpoqty = new System.Windows.Forms.RadioButton();
            this.gbreceiptprintqty = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.poreceiptitle.SuspendLayout();
            this.poheadercusttitile.SuspendLayout();
            this.pnlDCNumbervisible.SuspendLayout();
            this.bgpackperunits.SuspendLayout();
            this.panel2.SuspendLayout();
            this.poqtypanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbreceiptprintqty.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(339, 343);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(124, 33);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(210, 343);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 33);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rdbwithPO
            // 
            this.rdbwithPO.AutoSize = true;
            this.rdbwithPO.Checked = true;
            this.rdbwithPO.Location = new System.Drawing.Point(52, 12);
            this.rdbwithPO.Margin = new System.Windows.Forms.Padding(4);
            this.rdbwithPO.Name = "rdbwithPO";
            this.rdbwithPO.Size = new System.Drawing.Size(130, 21);
            this.rdbwithPO.TabIndex = 12;
            this.rdbwithPO.TabStop = true;
            this.rdbwithPO.Text = "Purchase Order";
            this.rdbwithPO.UseVisualStyleBackColor = true;
            this.rdbwithPO.CheckedChanged += new System.EventHandler(this.rdbwithPO_CheckedChanged);
            // 
            // rdbWithPoreceipt
            // 
            this.rdbWithPoreceipt.AutoSize = true;
            this.rdbWithPoreceipt.Location = new System.Drawing.Point(252, 12);
            this.rdbWithPoreceipt.Margin = new System.Windows.Forms.Padding(4);
            this.rdbWithPoreceipt.Name = "rdbWithPoreceipt";
            this.rdbWithPoreceipt.Size = new System.Drawing.Size(77, 21);
            this.rdbWithPoreceipt.TabIndex = 13;
            this.rdbWithPoreceipt.Text = "Receipt";
            this.rdbWithPoreceipt.UseVisualStyleBackColor = true;
            this.rdbWithPoreceipt.CheckedChanged += new System.EventHandler(this.rdbWithPoreceipt_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbwithPO);
            this.panel1.Controls.Add(this.rdbWithPoreceipt);
            this.panel1.Location = new System.Drawing.Point(24, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 42);
            this.panel1.TabIndex = 14;
            // 
            // poreceiptitle
            // 
            this.poreceiptitle.Controls.Add(this.panel1);
            this.poreceiptitle.Location = new System.Drawing.Point(32, 15);
            this.poreceiptitle.Margin = new System.Windows.Forms.Padding(4);
            this.poreceiptitle.Name = "poreceiptitle";
            this.poreceiptitle.Padding = new System.Windows.Forms.Padding(4);
            this.poreceiptitle.Size = new System.Drawing.Size(655, 78);
            this.poreceiptitle.TabIndex = 15;
            this.poreceiptitle.TabStop = false;
            this.poreceiptitle.Text = "Pull Data From";
            // 
            // poheadercusttitile
            // 
            this.poheadercusttitile.Controls.Add(this.pnlDCNumbervisible);
            this.poheadercusttitile.Location = new System.Drawing.Point(32, 95);
            this.poheadercusttitile.Margin = new System.Windows.Forms.Padding(4);
            this.poheadercusttitile.Name = "poheadercusttitile";
            this.poheadercusttitile.Padding = new System.Windows.Forms.Padding(4);
            this.poheadercusttitile.Size = new System.Drawing.Size(655, 237);
            this.poheadercusttitile.TabIndex = 16;
            this.poheadercusttitile.TabStop = false;
            this.poheadercusttitile.Text = " Custom  Header Field ";
            // 
            // pnlDCNumbervisible
            // 
            this.pnlDCNumbervisible.Controls.Add(this.bgpackperunits);
            this.pnlDCNumbervisible.Controls.Add(this.poqtypanel);
            this.pnlDCNumbervisible.Controls.Add(this.txtSN);
            this.pnlDCNumbervisible.Controls.Add(this.label1);
            this.pnlDCNumbervisible.Controls.Add(this.txtExpDate);
            this.pnlDCNumbervisible.Controls.Add(this.lblentryone);
            this.pnlDCNumbervisible.Location = new System.Drawing.Point(12, 23);
            this.pnlDCNumbervisible.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDCNumbervisible.Name = "pnlDCNumbervisible";
            this.pnlDCNumbervisible.Size = new System.Drawing.Size(608, 206);
            this.pnlDCNumbervisible.TabIndex = 11;
            // 
            // bgpackperunits
            // 
            this.bgpackperunits.Controls.Add(this.txtpackperunitscustomfield);
            this.bgpackperunits.Controls.Add(this.lblpackunit);
            this.bgpackperunits.Controls.Add(this.panel2);
            this.bgpackperunits.Location = new System.Drawing.Point(37, 80);
            this.bgpackperunits.Margin = new System.Windows.Forms.Padding(4);
            this.bgpackperunits.Name = "bgpackperunits";
            this.bgpackperunits.Padding = new System.Windows.Forms.Padding(4);
            this.bgpackperunits.Size = new System.Drawing.Size(557, 120);
            this.bgpackperunits.TabIndex = 46;
            this.bgpackperunits.TabStop = false;
            this.bgpackperunits.Text = "Purchase Order Quantity Division  by Quantity/Container";
            // 
            // txtpackperunitscustomfield
            // 
            this.txtpackperunitscustomfield.Location = new System.Drawing.Point(319, 81);
            this.txtpackperunitscustomfield.Margin = new System.Windows.Forms.Padding(4);
            this.txtpackperunitscustomfield.Name = "txtpackperunitscustomfield";
            this.txtpackperunitscustomfield.Size = new System.Drawing.Size(230, 22);
            this.txtpackperunitscustomfield.TabIndex = 42;
            // 
            // lblpackunit
            // 
            this.lblpackunit.AutoSize = true;
            this.lblpackunit.Location = new System.Drawing.Point(9, 85);
            this.lblpackunit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpackunit.Name = "lblpackunit";
            this.lblpackunit.Size = new System.Drawing.Size(309, 17);
            this.lblpackunit.TabIndex = 41;
            this.lblpackunit.Text = "Quantity/Container Custom Field in QuickBooks:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdbwithpackperunits);
            this.panel2.Controls.Add(this.rdbwithoutpackperunits);
            this.panel2.Location = new System.Drawing.Point(9, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(541, 37);
            this.panel2.TabIndex = 40;
            // 
            // rdbwithpackperunits
            // 
            this.rdbwithpackperunits.AutoSize = true;
            this.rdbwithpackperunits.Location = new System.Drawing.Point(15, 6);
            this.rdbwithpackperunits.Margin = new System.Windows.Forms.Padding(4);
            this.rdbwithpackperunits.Name = "rdbwithpackperunits";
            this.rdbwithpackperunits.Size = new System.Drawing.Size(179, 21);
            this.rdbwithpackperunits.TabIndex = 36;
            this.rdbwithpackperunits.Text = "With Quantity/Container";
            this.rdbwithpackperunits.UseVisualStyleBackColor = true;
            // 
            // rdbwithoutpackperunits
            // 
            this.rdbwithoutpackperunits.AutoSize = true;
            this.rdbwithoutpackperunits.Checked = true;
            this.rdbwithoutpackperunits.Location = new System.Drawing.Point(215, 6);
            this.rdbwithoutpackperunits.Margin = new System.Windows.Forms.Padding(4);
            this.rdbwithoutpackperunits.Name = "rdbwithoutpackperunits";
            this.rdbwithoutpackperunits.Size = new System.Drawing.Size(199, 21);
            this.rdbwithoutpackperunits.TabIndex = 37;
            this.rdbwithoutpackperunits.TabStop = true;
            this.rdbwithoutpackperunits.Text = "Without Quantity/Container";
            this.rdbwithoutpackperunits.UseVisualStyleBackColor = true;
            // 
            // poqtypanel
            // 
            this.poqtypanel.Controls.Add(this.rdoprintpolblqty);
            this.poqtypanel.Controls.Add(this.rdoprintpoqty);
            this.poqtypanel.Location = new System.Drawing.Point(37, 12);
            this.poqtypanel.Margin = new System.Windows.Forms.Padding(4);
            this.poqtypanel.Name = "poqtypanel";
            this.poqtypanel.Size = new System.Drawing.Size(444, 43);
            this.poqtypanel.TabIndex = 19;
            // 
            // rdoprintpolblqty
            // 
            this.rdoprintpolblqty.AutoSize = true;
            this.rdoprintpolblqty.Location = new System.Drawing.Point(227, 16);
            this.rdoprintpolblqty.Margin = new System.Windows.Forms.Padding(4);
            this.rdoprintpolblqty.Name = "rdoprintpolblqty";
            this.rdoprintpolblqty.Size = new System.Drawing.Size(175, 21);
            this.rdoprintpolblqty.TabIndex = 4;
            this.rdoprintpolblqty.Text = "Print 1 Label by default";
            this.rdoprintpolblqty.UseVisualStyleBackColor = true;
            // 
            // rdoprintpoqty
            // 
            this.rdoprintpoqty.AutoSize = true;
            this.rdoprintpoqty.Checked = true;
            this.rdoprintpoqty.Location = new System.Drawing.Point(27, 16);
            this.rdoprintpoqty.Margin = new System.Windows.Forms.Padding(4);
            this.rdoprintpoqty.Name = "rdoprintpoqty";
            this.rdoprintpoqty.Size = new System.Drawing.Size(174, 21);
            this.rdoprintpoqty.TabIndex = 3;
            this.rdoprintpoqty.TabStop = true;
            this.rdoprintpoqty.Text = "Print PO Qty by default";
            this.rdoprintpoqty.UseVisualStyleBackColor = true;
            // 
            // txtSN
            // 
            this.txtSN.Location = new System.Drawing.Point(196, 50);
            this.txtSN.Margin = new System.Windows.Forms.Padding(4);
            this.txtSN.Name = "txtSN";
            this.txtSN.Size = new System.Drawing.Size(252, 22);
            this.txtSN.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Entry Field 2:";
            // 
            // txtExpDate
            // 
            this.txtExpDate.Location = new System.Drawing.Point(196, 4);
            this.txtExpDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtExpDate.Name = "txtExpDate";
            this.txtExpDate.Size = new System.Drawing.Size(252, 22);
            this.txtExpDate.TabIndex = 8;
            // 
            // lblentryone
            // 
            this.lblentryone.AutoSize = true;
            this.lblentryone.Location = new System.Drawing.Point(47, 7);
            this.lblentryone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblentryone.Name = "lblentryone";
            this.lblentryone.Size = new System.Drawing.Size(91, 17);
            this.lblentryone.TabIndex = 7;
            this.lblentryone.Text = "Entry Field 1:";
            // 
            // lblwarng
            // 
            this.lblwarng.AutoSize = true;
            this.lblwarng.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwarng.ForeColor = System.Drawing.Color.Red;
            this.lblwarng.Location = new System.Drawing.Point(5, 324);
            this.lblwarng.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblwarng.Name = "lblwarng";
            this.lblwarng.Size = new System.Drawing.Size(362, 15);
            this.lblwarng.TabIndex = 17;
            this.lblwarng.Text = "Both the above option applicable for multilple po option";
            this.lblwarng.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbreceiptoneqty);
            this.panel3.Controls.Add(this.rbreceiptpoqty);
            this.panel3.Location = new System.Drawing.Point(49, 21);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(444, 43);
            this.panel3.TabIndex = 19;
            // 
            // rbreceiptoneqty
            // 
            this.rbreceiptoneqty.AutoSize = true;
            this.rbreceiptoneqty.Location = new System.Drawing.Point(227, 18);
            this.rbreceiptoneqty.Margin = new System.Windows.Forms.Padding(4);
            this.rbreceiptoneqty.Name = "rbreceiptoneqty";
            this.rbreceiptoneqty.Size = new System.Drawing.Size(175, 21);
            this.rbreceiptoneqty.TabIndex = 4;
            this.rbreceiptoneqty.Text = "Print 1 Label by default";
            this.rbreceiptoneqty.UseVisualStyleBackColor = true;
            // 
            // rbreceiptpoqty
            // 
            this.rbreceiptpoqty.AutoSize = true;
            this.rbreceiptpoqty.Checked = true;
            this.rbreceiptpoqty.Location = new System.Drawing.Point(27, 18);
            this.rbreceiptpoqty.Margin = new System.Windows.Forms.Padding(4);
            this.rbreceiptpoqty.Name = "rbreceiptpoqty";
            this.rbreceiptpoqty.Size = new System.Drawing.Size(174, 21);
            this.rbreceiptpoqty.TabIndex = 3;
            this.rbreceiptpoqty.TabStop = true;
            this.rbreceiptpoqty.Text = "Print PO Qty by default";
            this.rbreceiptpoqty.UseVisualStyleBackColor = true;
            // 
            // gbreceiptprintqty
            // 
            this.gbreceiptprintqty.Controls.Add(this.panel3);
            this.gbreceiptprintqty.Location = new System.Drawing.Point(43, 574);
            this.gbreceiptprintqty.Margin = new System.Windows.Forms.Padding(4);
            this.gbreceiptprintqty.Name = "gbreceiptprintqty";
            this.gbreceiptprintqty.Padding = new System.Windows.Forms.Padding(4);
            this.gbreceiptprintqty.Size = new System.Drawing.Size(655, 71);
            this.gbreceiptprintqty.TabIndex = 20;
            this.gbreceiptprintqty.TabStop = false;
            this.gbreceiptprintqty.Text = "Receipt Print Qty";
            this.gbreceiptprintqty.Visible = false;
            // 
            // FrmPOScreenSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 394);
            this.Controls.Add(this.gbreceiptprintqty);
            this.Controls.Add(this.lblwarng);
            this.Controls.Add(this.poheadercusttitile);
            this.Controls.Add(this.poreceiptitle);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPOScreenSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Label Connector - Purchase Order Setting";
            this.Load += new System.EventHandler(this.FrmPOScreenSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.poreceiptitle.ResumeLayout(false);
            this.poheadercusttitile.ResumeLayout(false);
            this.pnlDCNumbervisible.ResumeLayout(false);
            this.pnlDCNumbervisible.PerformLayout();
            this.bgpackperunits.ResumeLayout(false);
            this.bgpackperunits.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.poqtypanel.ResumeLayout(false);
            this.poqtypanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gbreceiptprintqty.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rdbwithPO;
        private System.Windows.Forms.RadioButton rdbWithPoreceipt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox poreceiptitle;
        private System.Windows.Forms.GroupBox poheadercusttitile;
        private System.Windows.Forms.Label lblwarng;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbreceiptoneqty;
        private System.Windows.Forms.RadioButton rbreceiptpoqty;
        private System.Windows.Forms.GroupBox gbreceiptprintqty;
        private System.Windows.Forms.Panel pnlDCNumbervisible;
        private System.Windows.Forms.GroupBox bgpackperunits;
        private System.Windows.Forms.TextBox txtpackperunitscustomfield;
        private System.Windows.Forms.Label lblpackunit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbwithpackperunits;
        private System.Windows.Forms.RadioButton rdbwithoutpackperunits;
        private System.Windows.Forms.Panel poqtypanel;
        private System.Windows.Forms.RadioButton rdoprintpolblqty;
        private System.Windows.Forms.RadioButton rdoprintpoqty;
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExpDate;
        private System.Windows.Forms.Label lblentryone;
    }
}