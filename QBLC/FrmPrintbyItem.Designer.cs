namespace LabelConnector
{
    partial class FrmPrintbyItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintbyItem));
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.txtItemDescription = new System.Windows.Forms.TextBox();
            this.txtQuantitytoprint = new System.Windows.Forms.TextBox();
            this.lblquantitytoprint = new System.Windows.Forms.Label();
            this.btnPrintItemDetail = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQtyOnHand = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBin = new System.Windows.Forms.ComboBox();
            this.lblBin = new System.Windows.Forms.Label();
            this.lblTempName = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btngotoSyncItem = new System.Windows.Forms.Button();
            this.txtQtyOnLabel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLabelName = new System.Windows.Forms.ComboBox();
            this.lblselectlabel = new System.Windows.Forms.Label();
            this.btnclosed = new System.Windows.Forms.Button();
            this.lblprintername = new System.Windows.Forms.Label();
            this.cmbLabelPrinter = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(57, 89);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(112, 13);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Item Name / Number :";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(175, 87);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(246, 20);
            this.txtItemName.TabIndex = 0;
            this.txtItemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyUp);
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.AutoSize = true;
            this.lblItemDesc.Location = new System.Drawing.Point(100, 120);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.Size = new System.Drawing.Size(66, 13);
            this.lblItemDesc.TabIndex = 2;
            this.lblItemDesc.Text = "Description :";
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.BackColor = System.Drawing.SystemColors.Window;
            this.txtItemDescription.Location = new System.Drawing.Point(175, 118);
            this.txtItemDescription.Multiline = true;
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.ReadOnly = true;
            this.txtItemDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtItemDescription.Size = new System.Drawing.Size(246, 41);
            this.txtItemDescription.TabIndex = 1;
            // 
            // txtQuantitytoprint
            // 
            this.txtQuantitytoprint.Location = new System.Drawing.Point(175, 297);
            this.txtQuantitytoprint.Name = "txtQuantitytoprint";
            this.txtQuantitytoprint.Size = new System.Drawing.Size(100, 20);
            this.txtQuantitytoprint.TabIndex = 5;
            this.txtQuantitytoprint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantitytoprint_KeyPress);
            this.txtQuantitytoprint.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQtyOnLabel_KeyUp);
            // 
            // lblquantitytoprint
            // 
            this.lblquantitytoprint.AutoSize = true;
            this.lblquantitytoprint.Location = new System.Drawing.Point(98, 299);
            this.lblquantitytoprint.Name = "lblquantitytoprint";
            this.lblquantitytoprint.Size = new System.Drawing.Size(68, 13);
            this.lblquantitytoprint.TabIndex = 5;
            this.lblquantitytoprint.Text = "Qty to Print : ";
            // 
            // btnPrintItemDetail
            // 
            this.btnPrintItemDetail.Location = new System.Drawing.Point(143, 414);
            this.btnPrintItemDetail.Name = "btnPrintItemDetail";
            this.btnPrintItemDetail.Size = new System.Drawing.Size(87, 29);
            this.btnPrintItemDetail.TabIndex = 8;
            this.btnPrintItemDetail.Text = "&Print";
            this.btnPrintItemDetail.UseVisualStyleBackColor = true;
            this.btnPrintItemDetail.Click += new System.EventHandler(this.btnPrintItemDetail_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtQtyOnHand);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboBin);
            this.groupBox1.Controls.Add(this.lblBin);
            this.groupBox1.Controls.Add(this.lblTempName);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.btngotoSyncItem);
            this.groupBox1.Controls.Add(this.txtQtyOnLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLotNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbLabelName);
            this.groupBox1.Controls.Add(this.lblselectlabel);
            this.groupBox1.Controls.Add(this.btnclosed);
            this.groupBox1.Controls.Add(this.lblprintername);
            this.groupBox1.Controls.Add(this.cmbLabelPrinter);
            this.groupBox1.Controls.Add(this.txtItemDescription);
            this.groupBox1.Controls.Add(this.btnPrintItemDetail);
            this.groupBox1.Controls.Add(this.txtQuantitytoprint);
            this.groupBox1.Controls.Add(this.txtItemName);
            this.groupBox1.Controls.Add(this.lblItemName);
            this.groupBox1.Controls.Add(this.lblItemDesc);
            this.groupBox1.Controls.Add(this.lblquantitytoprint);
            this.groupBox1.Location = new System.Drawing.Point(286, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 579);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 31);
            this.label1.TabIndex = 62;
            this.label1.Text = "Print Item Label";
            // 
            // txtQtyOnHand
            // 
            this.txtQtyOnHand.Location = new System.Drawing.Point(175, 204);
            this.txtQtyOnHand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtQtyOnHand.Name = "txtQtyOnHand";
            this.txtQtyOnHand.ReadOnly = true;
            this.txtQtyOnHand.Size = new System.Drawing.Size(100, 20);
            this.txtQtyOnHand.TabIndex = 3;
            this.txtQtyOnHand.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 206);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Qty On Hand :";
            // 
            // cboBin
            // 
            this.cboBin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBin.FormattingEnabled = true;
            this.cboBin.Location = new System.Drawing.Point(175, 171);
            this.cboBin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboBin.Name = "cboBin";
            this.cboBin.Size = new System.Drawing.Size(246, 21);
            this.cboBin.TabIndex = 2;
            this.cboBin.SelectedIndexChanged += new System.EventHandler(this.cboBin_SelectedIndexChanged);
            // 
            // lblBin
            // 
            this.lblBin.AutoSize = true;
            this.lblBin.Location = new System.Drawing.Point(58, 174);
            this.lblBin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBin.Name = "lblBin";
            this.lblBin.Size = new System.Drawing.Size(108, 13);
            this.lblBin.TabIndex = 58;
            this.lblBin.Text = "Bin:Site:QtyOnHand :";
            // 
            // lblTempName
            // 
            this.lblTempName.AutoSize = true;
            this.lblTempName.Location = new System.Drawing.Point(273, 366);
            this.lblTempName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTempName.Name = "lblTempName";
            this.lblTempName.Size = new System.Drawing.Size(0, 13);
            this.lblTempName.TabIndex = 57;
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(175, 360);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 29);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "      &Select...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btngotoSyncItem
            // 
            this.btngotoSyncItem.Location = new System.Drawing.Point(330, 414);
            this.btngotoSyncItem.Name = "btngotoSyncItem";
            this.btngotoSyncItem.Size = new System.Drawing.Size(87, 29);
            this.btngotoSyncItem.TabIndex = 10;
            this.btngotoSyncItem.Text = "Sync &Items";
            this.btngotoSyncItem.UseVisualStyleBackColor = true;
            this.btngotoSyncItem.Click += new System.EventHandler(this.btngotoSyncItem_Click);
            // 
            // txtQtyOnLabel
            // 
            this.txtQtyOnLabel.Location = new System.Drawing.Point(175, 266);
            this.txtQtyOnLabel.Name = "txtQtyOnLabel";
            this.txtQtyOnLabel.Size = new System.Drawing.Size(100, 20);
            this.txtQtyOnLabel.TabIndex = 4;
            this.txtQtyOnLabel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQtyOnLabel_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Qty On Label :";
            // 
            // txtLotNo
            // 
            this.txtLotNo.AllowDrop = true;
            this.txtLotNo.Location = new System.Drawing.Point(175, 235);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(100, 20);
            this.txtLotNo.TabIndex = 3;
            this.txtLotNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLotNo_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lot No. :";
            // 
            // cmbLabelName
            // 
            this.cmbLabelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelName.FormattingEnabled = true;
            this.cmbLabelName.Location = new System.Drawing.Point(178, 364);
            this.cmbLabelName.Name = "cmbLabelName";
            this.cmbLabelName.Size = new System.Drawing.Size(243, 21);
            this.cmbLabelName.TabIndex = 7;
            this.cmbLabelName.Visible = false;
            // 
            // lblselectlabel
            // 
            this.lblselectlabel.AutoSize = true;
            this.lblselectlabel.Location = new System.Drawing.Point(95, 370);
            this.lblselectlabel.Name = "lblselectlabel";
            this.lblselectlabel.Size = new System.Drawing.Size(72, 13);
            this.lblselectlabel.TabIndex = 9;
            this.lblselectlabel.Text = "Select Label :";
            // 
            // btnclosed
            // 
            this.btnclosed.Location = new System.Drawing.Point(236, 414);
            this.btnclosed.Name = "btnclosed";
            this.btnclosed.Size = new System.Drawing.Size(87, 29);
            this.btnclosed.TabIndex = 9;
            this.btnclosed.Text = "&Exit";
            this.btnclosed.UseVisualStyleBackColor = true;
            this.btnclosed.Click += new System.EventHandler(this.btnclosed_Click);
            // 
            // lblprintername
            // 
            this.lblprintername.AutoSize = true;
            this.lblprintername.Location = new System.Drawing.Point(90, 330);
            this.lblprintername.Name = "lblprintername";
            this.lblprintername.Size = new System.Drawing.Size(76, 13);
            this.lblprintername.TabIndex = 8;
            this.lblprintername.Text = "Select Printer :";
            // 
            // cmbLabelPrinter
            // 
            this.cmbLabelPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelPrinter.FormattingEnabled = true;
            this.cmbLabelPrinter.Location = new System.Drawing.Point(175, 327);
            this.cmbLabelPrinter.Name = "cmbLabelPrinter";
            this.cmbLabelPrinter.Size = new System.Drawing.Size(246, 21);
            this.cmbLabelPrinter.TabIndex = 6;
            // 
            // FrmPrintbyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 596);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1182, 1632);
            this.MinimizeBox = false;
            this.Name = "FrmPrintbyItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Label Connector - Print By Item";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrintbyItem_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrintbyItem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemDesc;
        private System.Windows.Forms.TextBox txtItemDescription;
        private System.Windows.Forms.TextBox txtQuantitytoprint;
        private System.Windows.Forms.Label lblquantitytoprint;
        private System.Windows.Forms.Button btnPrintItemDetail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblprintername;
        private System.Windows.Forms.ComboBox cmbLabelPrinter;
        private System.Windows.Forms.Button btnclosed;
        internal System.Windows.Forms.ComboBox cmbLabelName;
        internal System.Windows.Forms.Label lblselectlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQtyOnLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLotNo;
        private System.Windows.Forms.Button btngotoSyncItem;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblTempName;
        private System.Windows.Forms.ComboBox cboBin;
        private System.Windows.Forms.Label lblBin;
        private System.Windows.Forms.TextBox txtQtyOnHand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}