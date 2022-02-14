namespace LabelConnector
{
    partial class FrmPrintByItemSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintByItemSearch));
            this.DataGVSearchItem = new System.Windows.Forms.DataGridView();
            this.chkItemselect = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbOrderDetail = new System.Windows.Forms.GroupBox();
            this.lblTempName = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbLabelName = new System.Windows.Forms.ComboBox();
            this.cmbLabelPrinter = new System.Windows.Forms.ComboBox();
            this.lblSelectPrinter = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnclosed = new System.Windows.Forms.Button();
            this.gbsearch = new System.Windows.Forms.GroupBox();
            this.btnUpdateWebPrices = new System.Windows.Forms.Button();
            this.btngotoSyncItem = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnSearchReset = new System.Windows.Forms.Button();
            this.cmbserach = new System.Windows.Forms.ComboBox();
            this.lblin = new System.Windows.Forms.Label();
            this.btnSearchItemDetails = new System.Windows.Forms.Button();
            this.txtItemSearch = new System.Windows.Forms.TextBox();
            this.lbllookfor = new System.Windows.Forms.Label();
            this.btnBin = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlpaging = new System.Windows.Forms.Panel();
            this.pnluppaging = new System.Windows.Forms.Panel();
            this.btnupfirst = new System.Windows.Forms.Button();
            this.lblupstatus = new System.Windows.Forms.Label();
            this.btnupnext = new System.Windows.Forms.Button();
            this.btnuplast = new System.Windows.Forms.Button();
            this.btnupprev = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVSearchItem)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbOrderDetail.SuspendLayout();
            this.gbsearch.SuspendLayout();
            this.pnlpaging.SuspendLayout();
            this.pnluppaging.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGVSearchItem
            // 
            this.DataGVSearchItem.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            this.DataGVSearchItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGVSearchItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVSearchItem.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataGVSearchItem.Location = new System.Drawing.Point(6, 3);
            this.DataGVSearchItem.MultiSelect = false;
            this.DataGVSearchItem.Name = "DataGVSearchItem";
            this.DataGVSearchItem.ReadOnly = true;
            this.DataGVSearchItem.RowHeadersWidth = 51;
            this.DataGVSearchItem.Size = new System.Drawing.Size(1134, 529);
            this.DataGVSearchItem.TabIndex = 28;
            this.DataGVSearchItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGVSearchItem_CellClick);
            this.DataGVSearchItem.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGVSearchItem_DataError);
            this.DataGVSearchItem.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGVSearchItem_EditingControlShowing);
            // 
            // chkItemselect
            // 
            this.chkItemselect.AutoSize = true;
            this.chkItemselect.Location = new System.Drawing.Point(59, 23);
            this.chkItemselect.Name = "chkItemselect";
            this.chkItemselect.Size = new System.Drawing.Size(15, 14);
            this.chkItemselect.TabIndex = 49;
            this.chkItemselect.UseVisualStyleBackColor = true;
            this.chkItemselect.Visible = false;
            this.chkItemselect.Click += new System.EventHandler(this.chkItemselect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkItemselect);
            this.panel1.Controls.Add(this.DataGVSearchItem);
            this.panel1.Location = new System.Drawing.Point(24, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 535);
            this.panel1.TabIndex = 50;
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
            this.gbOrderDetail.Location = new System.Drawing.Point(49, 747);
            this.gbOrderDetail.Name = "gbOrderDetail";
            this.gbOrderDetail.Size = new System.Drawing.Size(1115, 55);
            this.gbOrderDetail.TabIndex = 51;
            this.gbOrderDetail.TabStop = false;
            this.gbOrderDetail.Text = "Print Label";
            this.gbOrderDetail.Visible = false;
            // 
            // lblTempName
            // 
            this.lblTempName.AutoSize = true;
            this.lblTempName.Location = new System.Drawing.Point(498, 26);
            this.lblTempName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTempName.Name = "lblTempName";
            this.lblTempName.Size = new System.Drawing.Size(0, 13);
            this.lblTempName.TabIndex = 58;
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(401, 18);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 29);
            this.btnSelect.TabIndex = 57;
            this.btnSelect.Text = "      Select...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(326, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(72, 13);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Select Label :";
            // 
            // cmbLabelName
            // 
            this.cmbLabelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelName.FormattingEnabled = true;
            this.cmbLabelName.Location = new System.Drawing.Point(401, 23);
            this.cmbLabelName.Name = "cmbLabelName";
            this.cmbLabelName.Size = new System.Drawing.Size(181, 21);
            this.cmbLabelName.TabIndex = 7;
            this.cmbLabelName.Visible = false;
            // 
            // cmbLabelPrinter
            // 
            this.cmbLabelPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabelPrinter.FormattingEnabled = true;
            this.cmbLabelPrinter.Location = new System.Drawing.Point(98, 19);
            this.cmbLabelPrinter.Name = "cmbLabelPrinter";
            this.cmbLabelPrinter.Size = new System.Drawing.Size(181, 21);
            this.cmbLabelPrinter.TabIndex = 10;
            // 
            // lblSelectPrinter
            // 
            this.lblSelectPrinter.AutoSize = true;
            this.lblSelectPrinter.Location = new System.Drawing.Point(20, 23);
            this.lblSelectPrinter.Name = "lblSelectPrinter";
            this.lblSelectPrinter.Size = new System.Drawing.Size(76, 13);
            this.lblSelectPrinter.TabIndex = 9;
            this.lblSelectPrinter.Text = "Select Printer :";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(742, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(637, 21);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(471, 21);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(124, 20);
            this.lblSearch.TabIndex = 52;
            this.lblSearch.Text = "Item List Print";
            // 
            // btnclosed
            // 
            this.btnclosed.Location = new System.Drawing.Point(906, 18);
            this.btnclosed.Name = "btnclosed";
            this.btnclosed.Size = new System.Drawing.Size(92, 23);
            this.btnclosed.TabIndex = 53;
            this.btnclosed.Text = "Close";
            this.btnclosed.UseVisualStyleBackColor = true;
            this.btnclosed.Click += new System.EventHandler(this.btnclosed_Click);
            // 
            // gbsearch
            // 
            this.gbsearch.Controls.Add(this.btnUpdateWebPrices);
            this.gbsearch.Controls.Add(this.btngotoSyncItem);
            this.gbsearch.Controls.Add(this.btnShowAll);
            this.gbsearch.Controls.Add(this.btnSearchReset);
            this.gbsearch.Controls.Add(this.btnclosed);
            this.gbsearch.Controls.Add(this.cmbserach);
            this.gbsearch.Controls.Add(this.lblin);
            this.gbsearch.Controls.Add(this.btnSearchItemDetails);
            this.gbsearch.Controls.Add(this.txtItemSearch);
            this.gbsearch.Controls.Add(this.lbllookfor);
            this.gbsearch.Location = new System.Drawing.Point(30, 71);
            this.gbsearch.Name = "gbsearch";
            this.gbsearch.Size = new System.Drawing.Size(1141, 60);
            this.gbsearch.TabIndex = 55;
            this.gbsearch.TabStop = false;
            this.gbsearch.Text = "Search Items";
            // 
            // btnUpdateWebPrices
            // 
            this.btnUpdateWebPrices.Location = new System.Drawing.Point(1006, 18);
            this.btnUpdateWebPrices.Name = "btnUpdateWebPrices";
            this.btnUpdateWebPrices.Size = new System.Drawing.Size(111, 23);
            this.btnUpdateWebPrices.TabIndex = 58;
            this.btnUpdateWebPrices.Text = "Update Web Prices";
            this.btnUpdateWebPrices.UseVisualStyleBackColor = true;
            this.btnUpdateWebPrices.Click += new System.EventHandler(this.btnUpdateWebPrices_Click);
            // 
            // btngotoSyncItem
            // 
            this.btngotoSyncItem.Location = new System.Drawing.Point(805, 18);
            this.btngotoSyncItem.Name = "btngotoSyncItem";
            this.btngotoSyncItem.Size = new System.Drawing.Size(92, 23);
            this.btngotoSyncItem.TabIndex = 58;
            this.btngotoSyncItem.Text = "Sync Items";
            this.btngotoSyncItem.UseVisualStyleBackColor = true;
            this.btngotoSyncItem.Click += new System.EventHandler(this.btngotoSyncItem_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(703, 17);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(92, 23);
            this.btnShowAll.TabIndex = 57;
            this.btnShowAll.Text = "Show all";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSearchReset
            // 
            this.btnSearchReset.Location = new System.Drawing.Point(601, 17);
            this.btnSearchReset.Name = "btnSearchReset";
            this.btnSearchReset.Size = new System.Drawing.Size(92, 23);
            this.btnSearchReset.TabIndex = 28;
            this.btnSearchReset.Text = "Reset";
            this.btnSearchReset.UseVisualStyleBackColor = true;
            this.btnSearchReset.Click += new System.EventHandler(this.btnSearchReset_Click);
            // 
            // cmbserach
            // 
            this.cmbserach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbserach.FormattingEnabled = true;
            this.cmbserach.Location = new System.Drawing.Point(292, 18);
            this.cmbserach.Name = "cmbserach";
            this.cmbserach.Size = new System.Drawing.Size(187, 21);
            this.cmbserach.TabIndex = 56;
            // 
            // lblin
            // 
            this.lblin.AutoSize = true;
            this.lblin.Location = new System.Drawing.Point(267, 21);
            this.lblin.Name = "lblin";
            this.lblin.Size = new System.Drawing.Size(19, 13);
            this.lblin.TabIndex = 2;
            this.lblin.Text = "In:";
            // 
            // btnSearchItemDetails
            // 
            this.btnSearchItemDetails.Location = new System.Drawing.Point(499, 17);
            this.btnSearchItemDetails.Name = "btnSearchItemDetails";
            this.btnSearchItemDetails.Size = new System.Drawing.Size(92, 23);
            this.btnSearchItemDetails.TabIndex = 16;
            this.btnSearchItemDetails.Text = "Search";
            this.btnSearchItemDetails.UseVisualStyleBackColor = true;
            this.btnSearchItemDetails.Click += new System.EventHandler(this.btnSearchItemDetails_Click);
            // 
            // txtItemSearch
            // 
            this.txtItemSearch.Location = new System.Drawing.Point(70, 19);
            this.txtItemSearch.Name = "txtItemSearch";
            this.txtItemSearch.Size = new System.Drawing.Size(183, 20);
            this.txtItemSearch.TabIndex = 1;
            this.txtItemSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemSearch_KeyPress);
            // 
            // lbllookfor
            // 
            this.lbllookfor.AutoSize = true;
            this.lbllookfor.Location = new System.Drawing.Point(14, 24);
            this.lbllookfor.Name = "lbllookfor";
            this.lbllookfor.Size = new System.Drawing.Size(52, 13);
            this.lbllookfor.TabIndex = 1;
            this.lbllookfor.Text = "Look For:";
            // 
            // btnBin
            // 
            this.btnBin.Location = new System.Drawing.Point(30, 144);
            this.btnBin.Name = "btnBin";
            this.btnBin.Size = new System.Drawing.Size(115, 23);
            this.btnBin.TabIndex = 59;
            this.btnBin.Text = "Get Bin";
            this.btnBin.UseVisualStyleBackColor = true;
            this.btnBin.Click += new System.EventHandler(this.btnBin_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(59, 9);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(48, 22);
            this.btnFirst.TabIndex = 56;
            this.btnFirst.Text = "|<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(255, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(48, 22);
            this.btnNext.TabIndex = 57;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(107, 9);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(51, 22);
            this.btnPrevious.TabIndex = 58;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(303, 8);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(45, 22);
            this.btnLast.TabIndex = 59;
            this.btnLast.Text = ">|";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Enabled = false;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(164, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(85, 20);
            this.lblStatus.TabIndex = 60;
            this.lblStatus.Text = "0 / 0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlpaging
            // 
            this.pnlpaging.Controls.Add(this.btnFirst);
            this.pnlpaging.Controls.Add(this.lblStatus);
            this.pnlpaging.Controls.Add(this.btnNext);
            this.pnlpaging.Controls.Add(this.btnLast);
            this.pnlpaging.Controls.Add(this.btnPrevious);
            this.pnlpaging.Location = new System.Drawing.Point(793, 711);
            this.pnlpaging.Name = "pnlpaging";
            this.pnlpaging.Size = new System.Drawing.Size(371, 34);
            this.pnlpaging.TabIndex = 50;
            // 
            // pnluppaging
            // 
            this.pnluppaging.Controls.Add(this.btnupfirst);
            this.pnluppaging.Controls.Add(this.lblupstatus);
            this.pnluppaging.Controls.Add(this.btnupnext);
            this.pnluppaging.Controls.Add(this.btnuplast);
            this.pnluppaging.Controls.Add(this.btnupprev);
            this.pnluppaging.Location = new System.Drawing.Point(800, 137);
            this.pnluppaging.Name = "pnluppaging";
            this.pnluppaging.Size = new System.Drawing.Size(371, 34);
            this.pnluppaging.TabIndex = 56;
            // 
            // btnupfirst
            // 
            this.btnupfirst.Location = new System.Drawing.Point(59, 9);
            this.btnupfirst.Name = "btnupfirst";
            this.btnupfirst.Size = new System.Drawing.Size(48, 22);
            this.btnupfirst.TabIndex = 56;
            this.btnupfirst.Text = "|<";
            this.btnupfirst.UseVisualStyleBackColor = true;
            this.btnupfirst.Click += new System.EventHandler(this.btnupfirst_Click);
            // 
            // lblupstatus
            // 
            this.lblupstatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblupstatus.Enabled = false;
            this.lblupstatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblupstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblupstatus.Location = new System.Drawing.Point(164, 10);
            this.lblupstatus.Name = "lblupstatus";
            this.lblupstatus.Size = new System.Drawing.Size(85, 20);
            this.lblupstatus.TabIndex = 60;
            this.lblupstatus.Text = "0 / 0";
            this.lblupstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnupnext
            // 
            this.btnupnext.Location = new System.Drawing.Point(255, 8);
            this.btnupnext.Name = "btnupnext";
            this.btnupnext.Size = new System.Drawing.Size(48, 22);
            this.btnupnext.TabIndex = 57;
            this.btnupnext.Text = ">";
            this.btnupnext.UseVisualStyleBackColor = true;
            this.btnupnext.Click += new System.EventHandler(this.btnupnext_Click);
            // 
            // btnuplast
            // 
            this.btnuplast.Location = new System.Drawing.Point(303, 8);
            this.btnuplast.Name = "btnuplast";
            this.btnuplast.Size = new System.Drawing.Size(45, 22);
            this.btnuplast.TabIndex = 59;
            this.btnuplast.Text = ">|";
            this.btnuplast.UseVisualStyleBackColor = true;
            this.btnuplast.Click += new System.EventHandler(this.btnuplast_Click);
            // 
            // btnupprev
            // 
            this.btnupprev.Location = new System.Drawing.Point(107, 9);
            this.btnupprev.Name = "btnupprev";
            this.btnupprev.Size = new System.Drawing.Size(51, 22);
            this.btnupprev.TabIndex = 58;
            this.btnupprev.Text = "<";
            this.btnupprev.UseVisualStyleBackColor = true;
            this.btnupprev.Click += new System.EventHandler(this.btnupprev_Click);
            // 
            // FrmPrintByItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1235, 596);
            this.Controls.Add(this.btnBin);
            this.Controls.Add(this.pnluppaging);
            this.Controls.Add(this.pnlpaging);
            this.Controls.Add(this.gbsearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.gbOrderDetail);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrintByItemSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item List Print";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrintByItemSearch_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrintByItemSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGVSearchItem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbOrderDetail.ResumeLayout(false);
            this.gbOrderDetail.PerformLayout();
            this.gbsearch.ResumeLayout(false);
            this.gbsearch.PerformLayout();
            this.pnlpaging.ResumeLayout(false);
            this.pnluppaging.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGVSearchItem;
        private System.Windows.Forms.CheckBox chkItemselect;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.GroupBox gbOrderDetail;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbLabelName;
        internal System.Windows.Forms.ComboBox cmbLabelPrinter;
        internal System.Windows.Forms.Label lblSelectPrinter;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnclosed;
        private System.Windows.Forms.GroupBox gbsearch;
        internal System.Windows.Forms.Button btnSearchReset;
        internal System.Windows.Forms.ComboBox cmbserach;
        internal System.Windows.Forms.Label lblin;
        internal System.Windows.Forms.Button btnSearchItemDetails;
        internal System.Windows.Forms.TextBox txtItemSearch;
        internal System.Windows.Forms.Label lbllookfor;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btngotoSyncItem;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlpaging;
        private System.Windows.Forms.Panel pnluppaging;
        private System.Windows.Forms.Button btnupfirst;
        private System.Windows.Forms.Label lblupstatus;
        private System.Windows.Forms.Button btnupnext;
        private System.Windows.Forms.Button btnuplast;
        private System.Windows.Forms.Button btnupprev;
        private System.Windows.Forms.Button btnUpdateWebPrices;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label lblTempName;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnBin;
    }
}