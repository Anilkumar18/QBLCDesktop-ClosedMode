using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelConnector
{
    public partial class frmSalesReceiptSetting : Form
    {
        QBConfiguration lobjQBConfiguration;
        private static frmSalesReceiptSetting objfrmLabelConfig;
        public static frmSalesReceiptSetting GetInstance()
        {

            if (objfrmLabelConfig == null)
            {
                objfrmLabelConfig = new frmSalesReceiptSetting();
            }
            return objfrmLabelConfig;
        }
        public frmSalesReceiptSetting()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            if (rdoprintsoqty.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("M", "MultiSRMode");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("S", "MultiSRMode");
            }

            if (chkCustom.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("S", "CustomField");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("N", "CustomField");
            }
            if (chkCustomerPhone.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("S", "CustomerPhone");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("N", "CustomerPhone");
            }

            if (chkcustomfields.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("1", "SREnablecustomfields");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "SREnablecustomfields");
            }

            if (chkEnableothercharges.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("1", "SREnableotherchargesfields");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "SREnableotherchargesfields");
            }


            DialogResult dlResult = MessageBox.Show("Settings saved successfully!!", "Settings Saved", MessageBoxButtons.OKCancel);
            if (dlResult == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSalesReceiptSetting_Load(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("MultiSRMode") == "M")
            {
                rdoprintsoqty.Checked = true;
                rdoprintlblqty.Checked = false;
            }
            else
            {
                rdoprintsoqty.Checked = false;
                rdoprintlblqty.Checked = true;
            }

            if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("CustomField") == "S")
            {
                chkCustom.Checked = true;
            }
            else
            {
                chkCustom.Checked = false;
            }
            if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("CustomerPhone") == "S")
            {
                chkCustomerPhone.Checked = true;
            }
            else
            {
                chkCustomerPhone.Checked = false;
            }

            if ((lobjQBConfiguration.GetLabelConfigSettings("SREnablecustomfields").ToString() == "1") )
            {
                chkcustomfields.Checked = true;
            }
            else
            {
                chkcustomfields.Checked = false;
            }


            if ((lobjQBConfiguration.GetLabelConfigSettings("SREnableotherchargesfields").ToString() == "1") )
            {
                chkEnableothercharges.Checked = true;
            }
            else
            {
                chkEnableothercharges.Checked = false;
            }
        }

        private void chkEnableothercharges_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
