
namespace LabelConnector
{
    partial class frmPrintedViewList
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
            this.listprintingItem = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listprintingItem
            // 
            this.listprintingItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listprintingItem.HideSelection = false;
            this.listprintingItem.Location = new System.Drawing.Point(12, 12);
            this.listprintingItem.Margin = new System.Windows.Forms.Padding(5);
            this.listprintingItem.Name = "listprintingItem";
            this.listprintingItem.Size = new System.Drawing.Size(322, 495);
            this.listprintingItem.TabIndex = 0;
            this.listprintingItem.UseCompatibleStateImageBehavior = false;
            this.listprintingItem.View = System.Windows.Forms.View.List;
            // 
            // frmPrintedViewList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 519);
            this.Controls.Add(this.listprintingItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPrintedViewList";
            this.Text = "Printing List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrintedViewList_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listprintingItem;
    }
}