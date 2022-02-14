namespace LabelConnector
{
    partial class FrmPrintWeatherOnly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintWeatherOnly));
            this.pnlOrdernum = new System.Windows.Forms.Panel();
            this.cmbLabelPrinter = new System.Windows.Forms.ComboBox();
            this.btnweatheronlyclose = new System.Windows.Forms.Button();
            this.lblSelectPrinter = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.DataGVOrders = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlOrdernum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVOrders)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOrdernum
            // 
            this.pnlOrdernum.AutoSize = true;
            this.pnlOrdernum.Controls.Add(this.cmbLabelPrinter);
            this.pnlOrdernum.Controls.Add(this.btnweatheronlyclose);
            this.pnlOrdernum.Controls.Add(this.lblSelectPrinter);
            this.pnlOrdernum.Controls.Add(this.txtOrderNumber);
            this.pnlOrdernum.Controls.Add(this.lblOrderNo);
            this.pnlOrdernum.Location = new System.Drawing.Point(81, 29);
            this.pnlOrdernum.Name = "pnlOrdernum";
            this.pnlOrdernum.Size = new System.Drawing.Size(658, 74);
            this.pnlOrdernum.TabIndex = 28;
            // 
            // cmbLabelPrinter
            // 
            this.cmbLabelPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelPrinter.FormattingEnabled = true;
            this.cmbLabelPrinter.Location = new System.Drawing.Point(293, 25);
            this.cmbLabelPrinter.Name = "cmbLabelPrinter";
            this.cmbLabelPrinter.Size = new System.Drawing.Size(246, 21);
            this.cmbLabelPrinter.TabIndex = 31;
            this.cmbLabelPrinter.SelectedIndexChanged += new System.EventHandler(this.cmbLabelPrinter_SelectedIndexChanged);
            // 
            // btnweatheronlyclose
            // 
            this.btnweatheronlyclose.Location = new System.Drawing.Point(576, 19);
            this.btnweatheronlyclose.Name = "btnweatheronlyclose";
            this.btnweatheronlyclose.Size = new System.Drawing.Size(75, 32);
            this.btnweatheronlyclose.TabIndex = 30;
            this.btnweatheronlyclose.Text = "Close";
            this.btnweatheronlyclose.UseVisualStyleBackColor = true;
            this.btnweatheronlyclose.Click += new System.EventHandler(this.btnweatheronlyclose_Click);
            // 
            // lblSelectPrinter
            // 
            this.lblSelectPrinter.AutoSize = true;
            this.lblSelectPrinter.Location = new System.Drawing.Point(211, 28);
            this.lblSelectPrinter.Name = "lblSelectPrinter";
            this.lblSelectPrinter.Size = new System.Drawing.Size(76, 13);
            this.lblSelectPrinter.TabIndex = 30;
            this.lblSelectPrinter.Text = "Select Printer :";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(108, 26);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(80, 20);
            this.txtOrderNumber.TabIndex = 1;
            this.txtOrderNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderNumber_KeyPress);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Location = new System.Drawing.Point(3, 29);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(99, 13);
            this.lblOrderNo.TabIndex = 0;
            this.lblOrderNo.Text = "Scan Invoice No :";
            this.lblOrderNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DataGVOrders
            // 
            this.DataGVOrders.AllowUserToAddRows = false;
            this.DataGVOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGVOrders.Location = new System.Drawing.Point(81, 127);
            this.DataGVOrders.MultiSelect = false;
            this.DataGVOrders.Name = "DataGVOrders";
            this.DataGVOrders.ReadOnly = true;
            this.DataGVOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGVOrders.Size = new System.Drawing.Size(752, 150);
            this.DataGVOrders.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataGVOrders);
            this.groupBox1.Controls.Add(this.pnlOrdernum);
            this.groupBox1.Location = new System.Drawing.Point(170, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(899, 337);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // FrmPrintWeatherOnly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 448);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrintWeatherOnly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weather Only";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrintWeatherOnly_FormClosed);
            this.Load += new System.EventHandler(this.FrmWeatherOnly_Load);
            this.pnlOrdernum.ResumeLayout(false);
            this.pnlOrdernum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVOrders)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlOrdernum;
        internal System.Windows.Forms.TextBox txtOrderNumber;
        internal System.Windows.Forms.Label lblOrderNo;
        internal System.Windows.Forms.DataGridView DataGVOrders;
        internal System.Windows.Forms.ComboBox cmbLabelPrinter;
        internal System.Windows.Forms.Label lblSelectPrinter;
        private System.Windows.Forms.Button btnweatheronlyclose;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}