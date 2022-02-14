namespace LabelConnector
{
    partial class frmInvoicePrintModeConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoicePrintModeConfig));
            this.pnlprintmode = new System.Windows.Forms.Panel();
            this.rdoprintmultiple = new System.Windows.Forms.RadioButton();
            this.rdoprintsingle = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.bgpackperunits = new System.Windows.Forms.GroupBox();
            this.txtpackperunitscustomfield = new System.Windows.Forms.TextBox();
            this.lblpackunit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbwithpackperunits = new System.Windows.Forms.RadioButton();
            this.rdbwithoutpackperunits = new System.Windows.Forms.RadioButton();
            this.gbinvoiceprintqty = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbgroupbyoption2 = new System.Windows.Forms.ComboBox();
            this.lblgroupopt2 = new System.Windows.Forms.Label();
            this.cmbgroupbyoption1 = new System.Windows.Forms.ComboBox();
            this.lblopt1 = new System.Windows.Forms.Label();
            this.btnSyncCustom = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbtxtsingleinvoicesearch = new System.Windows.Forms.ComboBox();
            this.lblsingleinvoicearch = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtdelay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtprintjobcount = new System.Windows.Forms.TextBox();
            this.lbldelay = new System.Windows.Forms.Label();
            this.lblprintjobcount = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkInvEnableothercharges = new System.Windows.Forms.CheckBox();
            this.chkInvcustomfields = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkenableparentwithitemname = new System.Windows.Forms.CheckBox();
            this.chkenablesubitemofcolumn = new System.Windows.Forms.CheckBox();
            this.pnlprintmode.SuspendLayout();
            this.bgpackperunits.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbinvoiceprintqty.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlprintmode
            // 
            this.pnlprintmode.Controls.Add(this.rdoprintmultiple);
            this.pnlprintmode.Controls.Add(this.rdoprintsingle);
            this.pnlprintmode.Location = new System.Drawing.Point(46, 25);
            this.pnlprintmode.Margin = new System.Windows.Forms.Padding(4);
            this.pnlprintmode.Name = "pnlprintmode";
            this.pnlprintmode.Size = new System.Drawing.Size(220, 56);
            this.pnlprintmode.TabIndex = 40;
            // 
            // rdoprintmultiple
            // 
            this.rdoprintmultiple.AutoSize = true;
            this.rdoprintmultiple.Checked = true;
            this.rdoprintmultiple.Location = new System.Drawing.Point(4, 2);
            this.rdoprintmultiple.Margin = new System.Windows.Forms.Padding(4);
            this.rdoprintmultiple.Name = "rdoprintmultiple";
            this.rdoprintmultiple.Size = new System.Drawing.Size(200, 21);
            this.rdoprintmultiple.TabIndex = 36;
            this.rdoprintmultiple.TabStop = true;
            this.rdoprintmultiple.Text = "Print Invoice Qty by Default";
            this.rdoprintmultiple.UseVisualStyleBackColor = true;
            // 
            // rdoprintsingle
            // 
            this.rdoprintsingle.AutoSize = true;
            this.rdoprintsingle.Location = new System.Drawing.Point(4, 31);
            this.rdoprintsingle.Margin = new System.Windows.Forms.Padding(4);
            this.rdoprintsingle.Name = "rdoprintsingle";
            this.rdoprintsingle.Size = new System.Drawing.Size(175, 21);
            this.rdoprintsingle.TabIndex = 37;
            this.rdoprintsingle.Text = "Print 1 Label by default";
            this.rdoprintsingle.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(324, 694);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(124, 28);
            this.btnExit.TabIndex = 42;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(192, 694);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 28);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bgpackperunits
            // 
            this.bgpackperunits.Controls.Add(this.txtpackperunitscustomfield);
            this.bgpackperunits.Controls.Add(this.lblpackunit);
            this.bgpackperunits.Controls.Add(this.panel1);
            this.bgpackperunits.Location = new System.Drawing.Point(23, 28);
            this.bgpackperunits.Margin = new System.Windows.Forms.Padding(4);
            this.bgpackperunits.Name = "bgpackperunits";
            this.bgpackperunits.Padding = new System.Windows.Forms.Padding(4);
            this.bgpackperunits.Size = new System.Drawing.Size(630, 136);
            this.bgpackperunits.TabIndex = 45;
            this.bgpackperunits.TabStop = false;
            this.bgpackperunits.Text = "Invoice Quantity Division  by Quantity/Container";
            // 
            // txtpackperunitscustomfield
            // 
            this.txtpackperunitscustomfield.Location = new System.Drawing.Point(332, 89);
            this.txtpackperunitscustomfield.Margin = new System.Windows.Forms.Padding(4);
            this.txtpackperunitscustomfield.Name = "txtpackperunitscustomfield";
            this.txtpackperunitscustomfield.Size = new System.Drawing.Size(220, 22);
            this.txtpackperunitscustomfield.TabIndex = 42;
            // 
            // lblpackunit
            // 
            this.lblpackunit.AutoSize = true;
            this.lblpackunit.Location = new System.Drawing.Point(12, 93);
            this.lblpackunit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpackunit.Name = "lblpackunit";
            this.lblpackunit.Size = new System.Drawing.Size(309, 17);
            this.lblpackunit.TabIndex = 41;
            this.lblpackunit.Text = "Quantity/Container Custom Field in QuickBooks:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbwithpackperunits);
            this.panel1.Controls.Add(this.rdbwithoutpackperunits);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 37);
            this.panel1.TabIndex = 40;
            // 
            // rdbwithpackperunits
            // 
            this.rdbwithpackperunits.AutoSize = true;
            this.rdbwithpackperunits.Location = new System.Drawing.Point(4, 2);
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
            this.rdbwithoutpackperunits.Location = new System.Drawing.Point(241, 4);
            this.rdbwithoutpackperunits.Margin = new System.Windows.Forms.Padding(4);
            this.rdbwithoutpackperunits.Name = "rdbwithoutpackperunits";
            this.rdbwithoutpackperunits.Size = new System.Drawing.Size(199, 21);
            this.rdbwithoutpackperunits.TabIndex = 37;
            this.rdbwithoutpackperunits.TabStop = true;
            this.rdbwithoutpackperunits.Text = "Without Quantity/Container";
            this.rdbwithoutpackperunits.UseVisualStyleBackColor = true;
            // 
            // gbinvoiceprintqty
            // 
            this.gbinvoiceprintqty.Controls.Add(this.pnlprintmode);
            this.gbinvoiceprintqty.Location = new System.Drawing.Point(23, 172);
            this.gbinvoiceprintqty.Margin = new System.Windows.Forms.Padding(4);
            this.gbinvoiceprintqty.Name = "gbinvoiceprintqty";
            this.gbinvoiceprintqty.Padding = new System.Windows.Forms.Padding(4);
            this.gbinvoiceprintqty.Size = new System.Drawing.Size(309, 102);
            this.gbinvoiceprintqty.TabIndex = 46;
            this.gbinvoiceprintqty.TabStop = false;
            this.gbinvoiceprintqty.Text = "Invoice Print Quantity";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Location = new System.Drawing.Point(15, 154);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(549, 134);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grouping Option for Multi-Invoice Mode";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbgroupbyoption2);
            this.panel2.Controls.Add(this.lblgroupopt2);
            this.panel2.Controls.Add(this.cmbgroupbyoption1);
            this.panel2.Controls.Add(this.lblopt1);
            this.panel2.Location = new System.Drawing.Point(7, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(527, 101);
            this.panel2.TabIndex = 40;
            // 
            // cmbgroupbyoption2
            // 
            this.cmbgroupbyoption2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbgroupbyoption2.FormattingEnabled = true;
            this.cmbgroupbyoption2.Location = new System.Drawing.Point(233, 55);
            this.cmbgroupbyoption2.Margin = new System.Windows.Forms.Padding(4);
            this.cmbgroupbyoption2.Name = "cmbgroupbyoption2";
            this.cmbgroupbyoption2.Size = new System.Drawing.Size(240, 24);
            this.cmbgroupbyoption2.TabIndex = 44;
            // 
            // lblgroupopt2
            // 
            this.lblgroupopt2.AutoSize = true;
            this.lblgroupopt2.Location = new System.Drawing.Point(36, 55);
            this.lblgroupopt2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblgroupopt2.Name = "lblgroupopt2";
            this.lblgroupopt2.Size = new System.Drawing.Size(190, 17);
            this.lblgroupopt2.TabIndex = 43;
            this.lblgroupopt2.Text = "Group by Item Custom Field :";
            // 
            // cmbgroupbyoption1
            // 
            this.cmbgroupbyoption1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbgroupbyoption1.FormattingEnabled = true;
            this.cmbgroupbyoption1.Location = new System.Drawing.Point(233, 10);
            this.cmbgroupbyoption1.Margin = new System.Windows.Forms.Padding(4);
            this.cmbgroupbyoption1.Name = "cmbgroupbyoption1";
            this.cmbgroupbyoption1.Size = new System.Drawing.Size(240, 24);
            this.cmbgroupbyoption1.TabIndex = 42;
            // 
            // lblopt1
            // 
            this.lblopt1.AutoSize = true;
            this.lblopt1.Location = new System.Drawing.Point(8, 14);
            this.lblopt1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblopt1.Name = "lblopt1";
            this.lblopt1.Size = new System.Drawing.Size(224, 17);
            this.lblopt1.TabIndex = 41;
            this.lblopt1.Text = "Group by Customer Custom Field :";
            // 
            // btnSyncCustom
            // 
            this.btnSyncCustom.Location = new System.Drawing.Point(367, 23);
            this.btnSyncCustom.Margin = new System.Windows.Forms.Padding(4);
            this.btnSyncCustom.Name = "btnSyncCustom";
            this.btnSyncCustom.Size = new System.Drawing.Size(127, 30);
            this.btnSyncCustom.TabIndex = 48;
            this.btnSyncCustom.Text = "&Sync Fields";
            this.btnSyncCustom.UseVisualStyleBackColor = true;
            this.btnSyncCustom.Click += new System.EventHandler(this.btnSyncCustom_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbtxtsingleinvoicesearch);
            this.groupBox2.Controls.Add(this.lblsingleinvoicearch);
            this.groupBox2.Location = new System.Drawing.Point(15, 60);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(549, 86);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Single Invoice Search";
            // 
            // cmbtxtsingleinvoicesearch
            // 
            this.cmbtxtsingleinvoicesearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtxtsingleinvoicesearch.FormattingEnabled = true;
            this.cmbtxtsingleinvoicesearch.Location = new System.Drawing.Point(277, 31);
            this.cmbtxtsingleinvoicesearch.Margin = new System.Windows.Forms.Padding(4);
            this.cmbtxtsingleinvoicesearch.Name = "cmbtxtsingleinvoicesearch";
            this.cmbtxtsingleinvoicesearch.Size = new System.Drawing.Size(204, 24);
            this.cmbtxtsingleinvoicesearch.TabIndex = 45;
            // 
            // lblsingleinvoicearch
            // 
            this.lblsingleinvoicearch.Location = new System.Drawing.Point(16, 31);
            this.lblsingleinvoicearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblsingleinvoicearch.Name = "lblsingleinvoicearch";
            this.lblsingleinvoicearch.Size = new System.Drawing.Size(269, 48);
            this.lblsingleinvoicearch.TabIndex = 43;
            this.lblsingleinvoicearch.Text = "Designate this Item custom field to use Yes/ No logic to appear for Printing";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSyncCustom);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(23, 282);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(630, 294);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sync  Fields";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtdelay);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtprintjobcount);
            this.groupBox4.Controls.Add(this.lbldelay);
            this.groupBox4.Controls.Add(this.lblprintjobcount);
            this.groupBox4.Location = new System.Drawing.Point(23, 583);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(329, 93);
            this.groupBox4.TabIndex = 50;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Multiple Invoice Print Setting";
            // 
            // txtdelay
            // 
            this.txtdelay.Location = new System.Drawing.Point(135, 54);
            this.txtdelay.Margin = new System.Windows.Forms.Padding(4);
            this.txtdelay.Name = "txtdelay";
            this.txtdelay.Size = new System.Drawing.Size(154, 22);
            this.txtdelay.TabIndex = 56;
            this.txtdelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdelay_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 57;
            this.label4.Text = "sec";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtprintjobcount
            // 
            this.txtprintjobcount.Location = new System.Drawing.Point(135, 25);
            this.txtprintjobcount.Margin = new System.Windows.Forms.Padding(4);
            this.txtprintjobcount.Name = "txtprintjobcount";
            this.txtprintjobcount.Size = new System.Drawing.Size(154, 22);
            this.txtprintjobcount.TabIndex = 42;
            this.txtprintjobcount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprintjobcount_KeyPress);
            // 
            // lbldelay
            // 
            this.lbldelay.Location = new System.Drawing.Point(15, 55);
            this.lbldelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldelay.Name = "lbldelay";
            this.lbldelay.Size = new System.Drawing.Size(121, 25);
            this.lbldelay.TabIndex = 55;
            this.lbldelay.Text = "Print Delay Time :";
            this.lbldelay.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblprintjobcount
            // 
            this.lblprintjobcount.AutoSize = true;
            this.lblprintjobcount.Location = new System.Drawing.Point(27, 27);
            this.lblprintjobcount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblprintjobcount.Name = "lblprintjobcount";
            this.lblprintjobcount.Size = new System.Drawing.Size(109, 17);
            this.lblprintjobcount.TabIndex = 41;
            this.lblprintjobcount.Text = "Print Job Count:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkInvEnableothercharges);
            this.groupBox5.Controls.Add(this.chkInvcustomfields);
            this.groupBox5.Location = new System.Drawing.Point(355, 172);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(298, 102);
            this.groupBox5.TabIndex = 52;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Enable fields";
            // 
            // chkInvEnableothercharges
            // 
            this.chkInvEnableothercharges.AutoSize = true;
            this.chkInvEnableothercharges.Checked = true;
            this.chkInvEnableothercharges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvEnableothercharges.Location = new System.Drawing.Point(49, 31);
            this.chkInvEnableothercharges.Margin = new System.Windows.Forms.Padding(4);
            this.chkInvEnableothercharges.Name = "chkInvEnableothercharges";
            this.chkInvEnableothercharges.Size = new System.Drawing.Size(171, 21);
            this.chkInvEnableothercharges.TabIndex = 16;
            this.chkInvEnableothercharges.Text = "Enable Other Charges";
            this.chkInvEnableothercharges.UseVisualStyleBackColor = true;
            // 
            // chkInvcustomfields
            // 
            this.chkInvcustomfields.AutoSize = true;
            this.chkInvcustomfields.Checked = true;
            this.chkInvcustomfields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvcustomfields.Location = new System.Drawing.Point(49, 59);
            this.chkInvcustomfields.Margin = new System.Windows.Forms.Padding(4);
            this.chkInvcustomfields.Name = "chkInvcustomfields";
            this.chkInvcustomfields.Size = new System.Drawing.Size(199, 21);
            this.chkInvcustomfields.TabIndex = 15;
            this.chkInvcustomfields.Text = "Enable Print Custom Fields";
            this.chkInvcustomfields.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkenableparentwithitemname);
            this.groupBox6.Controls.Add(this.chkenablesubitemofcolumn);
            this.groupBox6.Location = new System.Drawing.Point(360, 584);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(293, 92);
            this.groupBox6.TabIndex = 53;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Customize Columns";
            // 
            // chkenableparentwithitemname
            // 
            this.chkenableparentwithitemname.AutoSize = true;
            this.chkenableparentwithitemname.Location = new System.Drawing.Point(49, 31);
            this.chkenableparentwithitemname.Margin = new System.Windows.Forms.Padding(4);
            this.chkenableparentwithitemname.Name = "chkenableparentwithitemname";
            this.chkenableparentwithitemname.Size = new System.Drawing.Size(217, 21);
            this.chkenableparentwithitemname.TabIndex = 16;
            this.chkenableparentwithitemname.Text = "Enable Parent with Item name";
            this.chkenableparentwithitemname.UseVisualStyleBackColor = true;
            // 
            // chkenablesubitemofcolumn
            // 
            this.chkenablesubitemofcolumn.AutoSize = true;
            this.chkenablesubitemofcolumn.Location = new System.Drawing.Point(49, 59);
            this.chkenablesubitemofcolumn.Margin = new System.Windows.Forms.Padding(4);
            this.chkenablesubitemofcolumn.Name = "chkenablesubitemofcolumn";
            this.chkenablesubitemofcolumn.Size = new System.Drawing.Size(208, 21);
            this.chkenablesubitemofcolumn.TabIndex = 15;
            this.chkenablesubitemofcolumn.Text = "Enable \"Sub item of\" column";
            this.chkenablesubitemofcolumn.UseVisualStyleBackColor = true;
            // 
            // frmInvoicePrintModeConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 743);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbinvoiceprintqty);
            this.Controls.Add(this.bgpackperunits);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvoicePrintModeConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Label Connector - Invoice Settings";
            this.Load += new System.EventHandler(this.frmInvoicePrintModeConfig_Load);
            this.pnlprintmode.ResumeLayout(false);
            this.pnlprintmode.PerformLayout();
            this.bgpackperunits.ResumeLayout(false);
            this.bgpackperunits.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbinvoiceprintqty.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlprintmode;
        private System.Windows.Forms.RadioButton rdoprintmultiple;
        private System.Windows.Forms.RadioButton rdoprintsingle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox bgpackperunits;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbwithpackperunits;
        private System.Windows.Forms.RadioButton rdbwithoutpackperunits;
        private System.Windows.Forms.GroupBox gbinvoiceprintqty;
        private System.Windows.Forms.TextBox txtpackperunitscustomfield;
        private System.Windows.Forms.Label lblpackunit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.ComboBox cmbgroupbyoption2;
        internal System.Windows.Forms.Label lblgroupopt2;
        internal System.Windows.Forms.ComboBox cmbgroupbyoption1;
        internal System.Windows.Forms.Label lblopt1;
        private System.Windows.Forms.Button btnSyncCustom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblsingleinvoicearch;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ComboBox cmbtxtsingleinvoicesearch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtprintjobcount;
        private System.Windows.Forms.Label lblprintjobcount;
        internal System.Windows.Forms.TextBox txtdelay;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label lbldelay;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkInvEnableothercharges;
        private System.Windows.Forms.CheckBox chkInvcustomfields;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkenableparentwithitemname;
        private System.Windows.Forms.CheckBox chkenablesubitemofcolumn;
    }
}