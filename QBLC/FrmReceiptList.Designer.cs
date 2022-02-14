namespace LabelConnector
{
    partial class FrmReceiptList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReceiptList));
            this.gbreceiptsearch = new System.Windows.Forms.GroupBox();
            this.btnVendorSync = new System.Windows.Forms.Button();
            this.btnRemoveDays = new System.Windows.Forms.Button();
            this.btnAddDate = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnSearchReset = new System.Windows.Forms.Button();
            this.btnclosed = new System.Windows.Forms.Button();
            this.cmbvendor = new System.Windows.Forms.ComboBox();
            this.lblvendor = new System.Windows.Forms.Label();
            this.btnSearchReceipts = new System.Windows.Forms.Button();
            this.txtponumber = new System.Windows.Forms.TextBox();
            this.lblponumber = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbLabelName = new System.Windows.Forms.ComboBox();
            this.cmbLabelPrinter = new System.Windows.Forms.ComboBox();
            this.lblSelectPrinter = new System.Windows.Forms.Label();
            this.DataGVItems = new System.Windows.Forms.DataGridView();
            this.gbOrderDetail = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblprintheader = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.gbnavigation = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblTempName = new System.Windows.Forms.Label();
            this.gbreceiptsearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVItems)).BeginInit();
            this.gbOrderDetail.SuspendLayout();
            this.gbnavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbreceiptsearch
            // 
            this.gbreceiptsearch.Controls.Add(this.btnVendorSync);
            this.gbreceiptsearch.Controls.Add(this.btnRemoveDays);
            this.gbreceiptsearch.Controls.Add(this.btnAddDate);
            this.gbreceiptsearch.Controls.Add(this.dateTimePicker2);
            this.gbreceiptsearch.Controls.Add(this.label5);
            this.gbreceiptsearch.Controls.Add(this.label3);
            this.gbreceiptsearch.Controls.Add(this.dateTimePicker1);
            this.gbreceiptsearch.Controls.Add(this.btnSearchReset);
            this.gbreceiptsearch.Controls.Add(this.btnclosed);
            this.gbreceiptsearch.Controls.Add(this.cmbvendor);
            this.gbreceiptsearch.Controls.Add(this.lblvendor);
            this.gbreceiptsearch.Controls.Add(this.btnSearchReceipts);
            this.gbreceiptsearch.Controls.Add(this.txtponumber);
            this.gbreceiptsearch.Controls.Add(this.lblponumber);
            this.gbreceiptsearch.Location = new System.Drawing.Point(75, 66);
            this.gbreceiptsearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbreceiptsearch.Name = "gbreceiptsearch";
            this.gbreceiptsearch.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbreceiptsearch.Size = new System.Drawing.Size(1288, 135);
            this.gbreceiptsearch.TabIndex = 56;
            this.gbreceiptsearch.TabStop = false;
            this.gbreceiptsearch.Text = "Search Receipts";
            // 
            // btnVendorSync
            // 
            this.btnVendorSync.Location = new System.Drawing.Point(1024, 17);
            this.btnVendorSync.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVendorSync.Name = "btnVendorSync";
            this.btnVendorSync.Size = new System.Drawing.Size(124, 28);
            this.btnVendorSync.TabIndex = 68;
            this.btnVendorSync.Text = "Sync Vendor";
            this.btnVendorSync.UseVisualStyleBackColor = true;
            this.btnVendorSync.Click += new System.EventHandler(this.btnVendorSync_Click);
            // 
            // btnRemoveDays
            // 
            this.btnRemoveDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDays.Location = new System.Drawing.Point(663, 84);
            this.btnRemoveDays.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveDays.Name = "btnRemoveDays";
            this.btnRemoveDays.Size = new System.Drawing.Size(107, 28);
            this.btnRemoveDays.TabIndex = 67;
            this.btnRemoveDays.Text = " >> 5 Days";
            this.btnRemoveDays.UseVisualStyleBackColor = true;
            this.btnRemoveDays.Click += new System.EventHandler(this.btnRemoveDays_Click);
            // 
            // btnAddDate
            // 
            this.btnAddDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDate.Location = new System.Drawing.Point(545, 82);
            this.btnAddDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddDate.Name = "btnAddDate";
            this.btnAddDate.Size = new System.Drawing.Size(107, 28);
            this.btnAddDate.TabIndex = 66;
            this.btnAddDate.Text = "<< 5 Days";
            this.btnAddDate.UseVisualStyleBackColor = true;
            this.btnAddDate.Click += new System.EventHandler(this.btnAddDate_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(353, 82);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(164, 22);
            this.dateTimePicker2.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 62;
            this.label5.Text = "From :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 65;
            this.label3.Text = "To :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(116, 82);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(164, 22);
            this.dateTimePicker1.TabIndex = 63;
            this.dateTimePicker1.Value = new System.DateTime(2017, 10, 28, 0, 0, 0, 0);
            // 
            // btnSearchReset
            // 
            this.btnSearchReset.Location = new System.Drawing.Point(889, 17);
            this.btnSearchReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearchReset.Name = "btnSearchReset";
            this.btnSearchReset.Size = new System.Drawing.Size(124, 28);
            this.btnSearchReset.TabIndex = 59;
            this.btnSearchReset.Text = "Reset";
            this.btnSearchReset.UseVisualStyleBackColor = true;
            this.btnSearchReset.Click += new System.EventHandler(this.btnSearchReset_Click);
            // 
            // btnclosed
            // 
            this.btnclosed.Location = new System.Drawing.Point(1156, 18);
            this.btnclosed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnclosed.Name = "btnclosed";
            this.btnclosed.Size = new System.Drawing.Size(124, 28);
            this.btnclosed.TabIndex = 60;
            this.btnclosed.Text = "Close";
            this.btnclosed.UseVisualStyleBackColor = true;
            this.btnclosed.Click += new System.EventHandler(this.btnclosed_Click);
            // 
            // cmbvendor
            // 
            this.cmbvendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbvendor.FormattingEnabled = true;
            this.cmbvendor.Location = new System.Drawing.Point(481, 21);
            this.cmbvendor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbvendor.Name = "cmbvendor";
            this.cmbvendor.Size = new System.Drawing.Size(248, 24);
            this.cmbvendor.TabIndex = 56;
            this.cmbvendor.SelectedIndexChanged += new System.EventHandler(this.cmbvendor_SelectedIndexChanged);
            // 
            // lblvendor
            // 
            this.lblvendor.AutoSize = true;
            this.lblvendor.Location = new System.Drawing.Point(400, 27);
            this.lblvendor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblvendor.Name = "lblvendor";
            this.lblvendor.Size = new System.Drawing.Size(58, 17);
            this.lblvendor.TabIndex = 2;
            this.lblvendor.Text = "Vendor:";
            // 
            // btnSearchReceipts
            // 
            this.btnSearchReceipts.Location = new System.Drawing.Point(757, 18);
            this.btnSearchReceipts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearchReceipts.Name = "btnSearchReceipts";
            this.btnSearchReceipts.Size = new System.Drawing.Size(124, 28);
            this.btnSearchReceipts.TabIndex = 16;
            this.btnSearchReceipts.Text = "Search";
            this.btnSearchReceipts.UseVisualStyleBackColor = true;
            this.btnSearchReceipts.Click += new System.EventHandler(this.btnSearchReceipts_Click);
            // 
            // txtponumber
            // 
            this.txtponumber.Location = new System.Drawing.Point(116, 23);
            this.txtponumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtponumber.Name = "txtponumber";
            this.txtponumber.Size = new System.Drawing.Size(243, 22);
            this.txtponumber.TabIndex = 1;
            this.txtponumber.TextChanged += new System.EventHandler(this.txtponumber_TextChanged);
            // 
            // lblponumber
            // 
            this.lblponumber.AutoSize = true;
            this.lblponumber.Location = new System.Drawing.Point(19, 30);
            this.lblponumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblponumber.Name = "lblponumber";
            this.lblponumber.Size = new System.Drawing.Size(58, 17);
            this.lblponumber.TabIndex = 1;
            this.lblponumber.Text = "P O.No:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(435, 34);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(94, 17);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Select Label :";
            // 
            // cmbLabelName
            // 
            this.cmbLabelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelName.FormattingEnabled = true;
            this.cmbLabelName.Location = new System.Drawing.Point(535, 28);
            this.cmbLabelName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbLabelName.Name = "cmbLabelName";
            this.cmbLabelName.Size = new System.Drawing.Size(240, 24);
            this.cmbLabelName.TabIndex = 7;
            this.cmbLabelName.Visible = false;
            // 
            // cmbLabelPrinter
            // 
            this.cmbLabelPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelPrinter.FormattingEnabled = true;
            this.cmbLabelPrinter.Location = new System.Drawing.Point(131, 23);
            this.cmbLabelPrinter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbLabelPrinter.Name = "cmbLabelPrinter";
            this.cmbLabelPrinter.Size = new System.Drawing.Size(240, 24);
            this.cmbLabelPrinter.TabIndex = 10;
            // 
            // lblSelectPrinter
            // 
            this.lblSelectPrinter.AutoSize = true;
            this.lblSelectPrinter.Location = new System.Drawing.Point(27, 28);
            this.lblSelectPrinter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectPrinter.Name = "lblSelectPrinter";
            this.lblSelectPrinter.Size = new System.Drawing.Size(101, 17);
            this.lblSelectPrinter.TabIndex = 9;
            this.lblSelectPrinter.Text = "Select Printer :";
            // 
            // DataGVItems
            // 
            this.DataGVItems.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGVItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGVItems.Location = new System.Drawing.Point(47, 314);
            this.DataGVItems.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGVItems.Name = "DataGVItems";
            this.DataGVItems.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGVItems.RowHeadersWidth = 51;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVItems.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGVItems.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVItems.RowTemplate.Height = 45;
            this.DataGVItems.Size = new System.Drawing.Size(1279, 592);
            this.DataGVItems.TabIndex = 65;
            this.DataGVItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGVItems_CellClick);
            this.DataGVItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGVItems_EditingControlShowing);
            // 
            // gbOrderDetail
            // 
            this.gbOrderDetail.Controls.Add(this.lblTempName);
            this.gbOrderDetail.Controls.Add(this.btnSelect);
            this.gbOrderDetail.Controls.Add(this.Label1);
            this.gbOrderDetail.Controls.Add(this.cmbLabelName);
            this.gbOrderDetail.Controls.Add(this.cmbLabelPrinter);
            this.gbOrderDetail.Controls.Add(this.lblSelectPrinter);
            this.gbOrderDetail.Controls.Add(this.btnClear);
            this.gbOrderDetail.Controls.Add(this.btnPrint);
            this.gbOrderDetail.Location = new System.Drawing.Point(47, 913);
            this.gbOrderDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOrderDetail.Name = "gbOrderDetail";
            this.gbOrderDetail.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOrderDetail.Size = new System.Drawing.Size(1279, 68);
            this.gbOrderDetail.TabIndex = 68;
            this.gbOrderDetail.TabStop = false;
            this.gbOrderDetail.Text = "Print Label";
            this.gbOrderDetail.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(983, 26);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(101, 28);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(843, 26);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(109, 28);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblprintheader
            // 
            this.lblprintheader.AutoSize = true;
            this.lblprintheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprintheader.Location = new System.Drawing.Point(115, 354);
            this.lblprintheader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblprintheader.Name = "lblprintheader";
            this.lblprintheader.Size = new System.Drawing.Size(37, 17);
            this.lblprintheader.TabIndex = 70;
            this.lblprintheader.Text = "Print";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.Location = new System.Drawing.Point(127, 327);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(18, 17);
            this.chkSelectAll.TabIndex = 69;
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Click += new System.EventHandler(this.chkSelectAll_Click);
            // 
            // gbnavigation
            // 
            this.gbnavigation.Controls.Add(this.btnNext);
            this.gbnavigation.Controls.Add(this.btnPrevious);
            this.gbnavigation.Location = new System.Drawing.Point(556, 209);
            this.gbnavigation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbnavigation.Name = "gbnavigation";
            this.gbnavigation.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbnavigation.Size = new System.Drawing.Size(255, 65);
            this.gbnavigation.TabIndex = 71;
            this.gbnavigation.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(8, 23);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(103, 28);
            this.btnNext.TabIndex = 59;
            this.btnNext.Text = "<<";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(135, 23);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(103, 28);
            this.btnPrevious.TabIndex = 59;
            this.btnPrevious.Text = ">>";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::LabelConnector.Properties.Resources.openfile;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(535, 22);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(125, 36);
            this.btnSelect.TabIndex = 58;
            this.btnSelect.Text = "      Select...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblTempName
            // 
            this.lblTempName.AutoSize = true;
            this.lblTempName.Location = new System.Drawing.Point(665, 31);
            this.lblTempName.Name = "lblTempName";
            this.lblTempName.Size = new System.Drawing.Size(0, 17);
            this.lblTempName.TabIndex = 59;
            // 
            // FrmReceiptList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1379, 922);
            this.Controls.Add(this.gbnavigation);
            this.Controls.Add(this.lblprintheader);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.DataGVItems);
            this.Controls.Add(this.gbOrderDetail);
            this.Controls.Add(this.gbreceiptsearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReceiptList";
            this.Text = "Receipts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmReceiptList_FormClosed);
            this.Load += new System.EventHandler(this.FrmReceiptList_Load);
            this.gbreceiptsearch.ResumeLayout(false);
            this.gbreceiptsearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVItems)).EndInit();
            this.gbOrderDetail.ResumeLayout(false);
            this.gbOrderDetail.PerformLayout();
            this.gbnavigation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbreceiptsearch;
        internal System.Windows.Forms.ComboBox cmbvendor;
        internal System.Windows.Forms.Label lblvendor;
        internal System.Windows.Forms.Button btnSearchReceipts;
        internal System.Windows.Forms.TextBox txtponumber;
        internal System.Windows.Forms.Label lblponumber;
        internal System.Windows.Forms.Button btnSearchReset;
        private System.Windows.Forms.Button btnclosed;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbLabelName;
        internal System.Windows.Forms.ComboBox cmbLabelPrinter;
        internal System.Windows.Forms.Label lblSelectPrinter;
        internal System.Windows.Forms.DataGridView DataGVItems;
        internal System.Windows.Forms.GroupBox gbOrderDetail;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Label lblprintheader;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.GroupBox gbnavigation;
        internal System.Windows.Forms.Button btnNext;
        internal System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnVendorSync;
        private System.Windows.Forms.Button btnRemoveDays;
        private System.Windows.Forms.Button btnAddDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblTempName;
        private System.Windows.Forms.Button btnSelect;
    }
}