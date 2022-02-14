namespace LabelConnector
{
    partial class FrmPrintWeatherOnlyTouchScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintWeatherOnlyTouchScreen));
            this.DataGVOrders = new System.Windows.Forms.DataGridView();
            this.pnlOrdernum = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbLabelPrinter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.gbprintweatheronlytouchscreen = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVOrders)).BeginInit();
            this.pnlOrdernum.SuspendLayout();
            this.gbprintweatheronlytouchscreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGVOrders
            // 
            this.DataGVOrders.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGVOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGVOrders.Location = new System.Drawing.Point(41, 159);
            this.DataGVOrders.MultiSelect = false;
            this.DataGVOrders.Name = "DataGVOrders";
            this.DataGVOrders.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGVOrders.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGVOrders.RowTemplate.Height = 55;
            this.DataGVOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGVOrders.Size = new System.Drawing.Size(743, 141);
            this.DataGVOrders.TabIndex = 43;
            // 
            // pnlOrdernum
            // 
            this.pnlOrdernum.Controls.Add(this.btnClose);
            this.pnlOrdernum.Controls.Add(this.cmbLabelPrinter);
            this.pnlOrdernum.Controls.Add(this.label2);
            this.pnlOrdernum.Controls.Add(this.txtOrderNumber);
            this.pnlOrdernum.Controls.Add(this.lblOrderNo);
            this.pnlOrdernum.Location = new System.Drawing.Point(41, 23);
            this.pnlOrdernum.Name = "pnlOrdernum";
            this.pnlOrdernum.Size = new System.Drawing.Size(875, 110);
            this.pnlOrdernum.TabIndex = 42;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(748, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 90);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbLabelPrinter
            // 
            this.cmbLabelPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLabelPrinter.FormattingEnabled = true;
            this.cmbLabelPrinter.Location = new System.Drawing.Point(389, 42);
            this.cmbLabelPrinter.Name = "cmbLabelPrinter";
            this.cmbLabelPrinter.Size = new System.Drawing.Size(323, 37);
            this.cmbLabelPrinter.TabIndex = 12;
            this.cmbLabelPrinter.SelectedIndexChanged += new System.EventHandler(this.cmbLabelPrinter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Select Printer :";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNumber.Location = new System.Drawing.Point(171, 42);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(82, 35);
            this.txtOrderNumber.TabIndex = 1;
            this.txtOrderNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderNumber_KeyPress);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNo.Location = new System.Drawing.Point(16, 52);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(149, 20);
            this.lblOrderNo.TabIndex = 0;
            this.lblOrderNo.Text = "Scan Invoice No :";
            // 
            // gbprintweatheronlytouchscreen
            // 
            this.gbprintweatheronlytouchscreen.Controls.Add(this.DataGVOrders);
            this.gbprintweatheronlytouchscreen.Controls.Add(this.pnlOrdernum);
            this.gbprintweatheronlytouchscreen.Location = new System.Drawing.Point(27, 44);
            this.gbprintweatheronlytouchscreen.Name = "gbprintweatheronlytouchscreen";
            this.gbprintweatheronlytouchscreen.Size = new System.Drawing.Size(922, 317);
            this.gbprintweatheronlytouchscreen.TabIndex = 44;
            this.gbprintweatheronlytouchscreen.TabStop = false;
            // 
            // FrmPrintWeatherOnlyTouchScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 661);
            this.Controls.Add(this.gbprintweatheronlytouchscreen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrintWeatherOnlyTouchScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Weather Only";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrintWeatherOnlyTouchScreen_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrintWeatherOnlyTouchScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGVOrders)).EndInit();
            this.pnlOrdernum.ResumeLayout(false);
            this.pnlOrdernum.PerformLayout();
            this.gbprintweatheronlytouchscreen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGVOrders;
        internal System.Windows.Forms.Panel pnlOrdernum;
        internal System.Windows.Forms.TextBox txtOrderNumber;
        internal System.Windows.Forms.Label lblOrderNo;
        internal System.Windows.Forms.ComboBox cmbLabelPrinter;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbprintweatheronlytouchscreen;
        internal System.Windows.Forms.Button btnClose;
    }
}