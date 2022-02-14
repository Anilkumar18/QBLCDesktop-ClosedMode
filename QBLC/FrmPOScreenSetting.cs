using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabelConnector
{
    public delegate void showHeader();
    public partial class FrmPOScreenSetting : Form
    {
        QBConfiguration lobjQBConfiguration;
        public showHeader objshowheader;
        private static FrmPOScreenSetting objfrmLabelConfig;
        public static FrmPOScreenSetting GetInstance()
        {

            if (objfrmLabelConfig == null)
            {
                objfrmLabelConfig = new FrmPOScreenSetting();
            }
            return objfrmLabelConfig;
        }
        public FrmPOScreenSetting()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();

            using (new HourGlass())
            {

               
                lobjQBConfiguration.SavePOHeaderTextSettings("PoExpDateHeader", "PoSNHeader", txtExpDate.Text.ToString(), txtSN.Text.ToString());
               
                if (rdbwithPO.Checked == true)
                {
                    lobjQBConfiguration.SavePOReceiptDataAccessSettings("1");


                }
                else
                {
                    lobjQBConfiguration.SavePOReceiptDataAccessSettings("0");

                }

                //switch po qty to print and quantity on lable: 16-Feb-2017
                if (rdoprintpoqty.Checked == true)
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("Y", "FlipPOQty");
                }
                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("N", "FlipPOQty");
                }
                //save print label setting for receipt
                if (rbreceiptpoqty.Checked == true)
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("Y", "FlipReceiptQty");
                }
                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("N", "FlipReceiptQty");
                }

                if (rdbwithpackperunits.Checked == true)
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("Y", "POQtyPercontainer");
                }
                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("N", "POQtyPercontainer");
                }

                lobjQBConfiguration.SaveLabelFilePathSettings(Convert.ToString(txtpackperunitscustomfield.Text), "QtyPerCaseCustomField");

                //poqtypercase :Date 11-Dec-2018

                //check if itemcustomfield is already exist in QuickBooks
                clsItemDetails objclsAllItems = new clsItemDetails();
                ArrayList lstitemfieldlist = new ArrayList();

               
               

                    objshowheader();
                    DialogResult dlResult = MessageBox.Show("Settings saved successfully!!", "Settings Saved", MessageBoxButtons.OKCancel);
                    if (dlResult == DialogResult.OK)
                    {
                        this.Close();
                    }
             
            }

        }

       
        public class HourGlass : IDisposable
        {
            public HourGlass()
            {
                Enabled = true;
            }
            public void Dispose()
            {
                Enabled = false;
            }
            public static bool Enabled
            {
                get { return System.Windows.Forms.Application.UseWaitCursor; }
                set
                {
                    if (value == System.Windows.Forms.Application.UseWaitCursor) return;
                    System.Windows.Forms.Application.UseWaitCursor = value;
                    Form f = Form.ActiveForm;
                    if (f != null && f.Handle != IntPtr.Zero)   // Send WM_SETCURSOR
                        SendMessage(f.Handle, 0x20, f.Handle, (IntPtr)1);
                }
            }
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        }

        private void FrmPOScreenSetting_Load(object sender, EventArgs e)
        {
            try
            {
                string expheadervalue=string.Empty;
                string Snheadervalue = string.Empty;
                string showpovalue = string.Empty;
                string shopoflipvalue = string.Empty;
                //string receiptpoqty = string.Empty;
                lobjQBConfiguration = new QBConfiguration();
                expheadervalue = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("PoExpDateHeader");
                txtExpDate.Text = expheadervalue;
                Snheadervalue = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("PoSNHeader");
                txtSN.Text = Snheadervalue;

                showpovalue = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("ShowPo");
                if (showpovalue == "1")
                {
                    rdbwithPO.Checked = true;
                }
                else
                {
                    rdbWithPoreceipt.Checked = true;
                }

                shopoflipvalue = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FlipPOQty");
                if (shopoflipvalue == "Y")
                {
                    rdoprintpoqty.Checked = true;
                }
                else
                {
                    rdoprintpolblqty.Checked = true;

                }
                if ((lobjQBConfiguration.GetLabelConfigSettings("POQtyPercontainer").ToString() == "Y"))
                {
                    rdbwithpackperunits.Checked = true;
                }
                else
                {
                    rdbwithoutpackperunits.Checked = true;

                }

                if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("QtyPerCaseCustomField")))
                {
                    txtpackperunitscustomfield.Text = Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("QtyPerCaseCustomField"));

                }

                //receiptpoqty = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FlipReceiptQty");
                //if (receiptpoqty == "Y")
                //{

                //   rbreceiptpoqty.Checked=true;
                //}
                //else
                //{

                //    rbreceiptoneqty.Checked = true;
                //}

                //make default PO option visible : Date 16-Feb-2017
                if (rdbwithPO.Checked == true)
                {
                   // poprintorder.Visible = true; //purchase order set visilble : Date 16-Feb-2017
                   // popanel1.Visible = true;
                    //poheadercusttitile.Visible = false; //receipt option set visible false
                   // lblwarng.Visible = false; //receipt option set visible false

                    lblentryone.Visible=false;
                    label1.Visible=false;
                    txtExpDate.Visible=false;
                    txtSN.Visible=false;
                    //lblwarng.Visible = false;
                    poqtypanel.Visible = true;
                    //rdoprintpoqty.Visible = true;
                   // rdoprintpolblqty.Visible = true;
                    poheadercusttitile.Text = "Purchase Order Print Quantity";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
        }

        private void rdbwithPO_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbwithPO.Checked == true)
            {
                //poprintorder.Visible = true; //purchase order set visilble : Date 16-Feb-2017
                // poheadercusttitile.Visible = false; //receipt option set visible false
                poqtypanel.Visible = true;
                //lblwarng.Visible = false; //receipt option set visible false
                lblentryone.Visible = false;
                label1.Visible = false;
                txtExpDate.Visible = false;
                txtSN.Visible = false;
                //gbreceiptprintqty.Visible = false;
                poheadercusttitile.Text = "Purchase Order Print Quantity";
            }
        }

        private void rdbWithPoreceipt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbWithPoreceipt.Checked == true)
            {
                lblentryone.Visible = true;
                label1.Visible = true;
                txtExpDate.Visible = true;
                txtSN.Visible = true;
               // lblwarng.Visible = true;
                poqtypanel.Visible = false;
               // gbreceiptprintqty.Visible = true;
                poheadercusttitile.Text = "Custom  Header Field";
            
            }
        }


        //private void txtdivisor1_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    onlynumwithsinglepoint(sender, e);

        //}
        //public void onlynumwithsinglepoint(object sender, KeyPressEventArgs e)
        //{
        //    if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
        //    { e.Handled = true; }
        //    TextBox txtDecimal = sender as TextBox;
        //    if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
        //    {
        //        e.Handled = true;
        //    }
        //}
        //private void txtdivisor2_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    onlynumwithsinglepoint(sender, e);
        //}

        //private void txtdivisor3_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    onlynumwithsinglepoint(sender, e);
        //}
    }
}
