namespace LabelConnector
{
    partial class FrmPrintByItemTouchScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintByItemTouchScreen));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblprintername = new System.Windows.Forms.Label();
            this.cmbLabelPrinter = new System.Windows.Forms.ComboBox();
            this.txtItemDescription = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.lblquantitytoprint = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtQuantitytoprint = new System.Windows.Forms.TextBox();
            this.btnPrintItemDetail = new System.Windows.Forms.Button();
            this.btnclosed = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnclosed);
            this.groupBox1.Controls.Add(this.btnPrintItemDetail);
            this.groupBox1.Controls.Add(this.txtQuantitytoprint);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.lblprintername);
            this.groupBox1.Controls.Add(this.cmbLabelPrinter);
            this.groupBox1.Controls.Add(this.txtItemDescription);
            this.groupBox1.Controls.Add(this.lblItemName);
            this.groupBox1.Controls.Add(this.lblItemDesc);
            this.groupBox1.Controls.Add(this.lblquantitytoprint);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(76, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 454);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Details";
            // 
            // lblprintername
            // 
            this.lblprintername.AutoSize = true;
            this.lblprintername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprintername.Location = new System.Drawing.Point(49, 292);
            this.lblprintername.Name = "lblprintername";
            this.lblprintername.Size = new System.Drawing.Size(118, 20);
            this.lblprintername.TabIndex = 8;
            this.lblprintername.Text = "Select Printer";
            // 
            // cmbLabelPrinter
            // 
            this.cmbLabelPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLabelPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelPrinter.FormattingEnabled = true;
            this.cmbLabelPrinter.ItemHeight = 35;
            this.cmbLabelPrinter.Location = new System.Drawing.Point(197, 294);
            this.cmbLabelPrinter.Name = "cmbLabelPrinter";
            this.cmbLabelPrinter.Size = new System.Drawing.Size(258, 41);
            this.cmbLabelPrinter.TabIndex = 4;
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemDescription.Location = new System.Drawing.Point(197, 114);
            this.txtItemDescription.Multiline = true;
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.ReadOnly = true;
            this.txtItemDescription.Size = new System.Drawing.Size(415, 116);
            this.txtItemDescription.TabIndex = 2;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(81, 62);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(96, 20);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Item Name";
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.AutoSize = true;
            this.lblItemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDesc.Location = new System.Drawing.Point(36, 114);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.Size = new System.Drawing.Size(141, 20);
            this.lblItemDesc.TabIndex = 2;
            this.lblItemDesc.Text = "Item Description";
            // 
            // lblquantitytoprint
            // 
            this.lblquantitytoprint.AutoSize = true;
            this.lblquantitytoprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblquantitytoprint.Location = new System.Drawing.Point(38, 246);
            this.lblquantitytoprint.Name = "lblquantitytoprint";
            this.lblquantitytoprint.Size = new System.Drawing.Size(139, 20);
            this.lblquantitytoprint.TabIndex = 5;
            this.lblquantitytoprint.Text = "Quantity to Print";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(197, 62);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(415, 35);
            this.txtItemName.TabIndex = 12;
            this.txtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyUp);
            // 
            // txtQuantitytoprint
            // 
            this.txtQuantitytoprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantitytoprint.Location = new System.Drawing.Point(197, 246);
            this.txtQuantitytoprint.Name = "txtQuantitytoprint";
            this.txtQuantitytoprint.Size = new System.Drawing.Size(115, 35);
            this.txtQuantitytoprint.TabIndex = 13;
            this.txtQuantitytoprint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantitytoprint_KeyPress);
            // 
            // btnPrintItemDetail
            // 
            this.btnPrintItemDetail.Enabled = false;
            this.btnPrintItemDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintItemDetail.Location = new System.Drawing.Point(197, 346);
            this.btnPrintItemDetail.Name = "btnPrintItemDetail";
            this.btnPrintItemDetail.Size = new System.Drawing.Size(121, 59);
            this.btnPrintItemDetail.TabIndex = 17;
            this.btnPrintItemDetail.Text = "Print";
            this.btnPrintItemDetail.UseVisualStyleBackColor = true;
            this.btnPrintItemDetail.Click += new System.EventHandler(this.btnPrintItemDetail_Click);
            // 
            // btnclosed
            // 
            this.btnclosed.Enabled = false;
            this.btnclosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclosed.Location = new System.Drawing.Point(334, 346);
            this.btnclosed.Name = "btnclosed";
            this.btnclosed.Size = new System.Drawing.Size(121, 59);
            this.btnclosed.TabIndex = 18;
            this.btnclosed.Text = "Close";
            this.btnclosed.UseVisualStyleBackColor = true;
            this.btnclosed.Click += new System.EventHandler(this.btnclosed_Click);
            // 
            // FrmPrintByItemTouchScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 548);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrintByItemTouchScreen";
            this.Text = "Accuware - Label Connector";
            this.Load += new System.EventHandler(this.FrmPrintByItemTouchScreen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblprintername;
        private System.Windows.Forms.ComboBox cmbLabelPrinter;
        private System.Windows.Forms.TextBox txtItemDescription;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemDesc;
        private System.Windows.Forms.Label lblquantitytoprint;
        private System.Windows.Forms.TextBox txtQuantitytoprint;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Button btnclosed;
        private System.Windows.Forms.Button btnPrintItemDetail;
    }
}