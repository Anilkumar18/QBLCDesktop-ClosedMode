using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabelConnector
{
    public partial class FrmConnectQuickBooks : Form
    {
        QBConfiguration lobjQBConfiguration = new QBConfiguration();
        clsItemDetails lobjitem = new clsItemDetails();    
        public FrmConnectQuickBooks()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

            Dictionary<string, bool> MultiSite = new Dictionary<string, bool>();
            this.Cursor = Cursors.WaitCursor;
            Globalvariables.CreatedNewConnection = "1";
            if (chkEnableOpenMode.Checked)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("Open", "FileMode");
               string OpenConnectionMsg = lobjitem.CheckQuickBooksOpenConnection();
                if(OpenConnectionMsg != "Success")
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(OpenConnectionMsg, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
            }
            else if(ChkEnablePOCloseMode.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtCompanyfilePath.Text))
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Please, select the company file path location", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lobjQBConfiguration.SaveLabelFilePathSettings("", "CompanyFilePath");
                    return;
                }
                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings(txtCompanyfilePath.Text, "CompanyFilePath");
                }
              
                lobjQBConfiguration.SaveLabelFilePathSettings("Close", "FileMode");
                if (File.Exists(lobjQBConfiguration.GetLabelConfigSettings("CompanyFilePath")))
                {
                   string ClosedConnectionMsg = LabelConnector.QBHelper.ClosedQBConnection(lobjQBConfiguration.GetLabelConfigSettings("CompanyFilePath"));
                    if(ClosedConnectionMsg != "Success")
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(ClosedConnectionMsg, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    } 
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Company file path not exists.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            this.Cursor = Cursors.Default;
            this.Close();
        }

        private void FrmConnectQuickBooks_Load(object sender, EventArgs e)
        {
           if(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Open")
            {
                chkEnableOpenMode.Checked = true;
                txtCompanyfilePath.Enabled = false;
                btnOpenCompanyPath.Enabled = false;
            }
            else
            {
                ChkEnablePOCloseMode.Checked = true;
                txtCompanyfilePath.Enabled = true;
                btnOpenCompanyPath.Enabled = true;
            }

            txtCompanyfilePath.Text = lobjQBConfiguration.GetLabelConfigSettings("CompanyFilePath");
        }

        private void chkEnableOpenMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableOpenMode.Checked)
            {
                ChkEnablePOCloseMode.Checked = false;
                txtCompanyfilePath.Enabled = false;
                btnOpenCompanyPath.Enabled = false;
            }
            else
            {
                ChkEnablePOCloseMode.Checked = true;
                txtCompanyfilePath.Enabled = true;
                btnOpenCompanyPath.Enabled = true;
            }
        }

        private void ChkEnablePOCloseMode_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkEnablePOCloseMode.Checked)
            {
                chkEnableOpenMode.Checked = false;
                txtCompanyfilePath.Enabled = true;
                btnOpenCompanyPath.Enabled = true;
            }
            else
            {
                chkEnableOpenMode.Checked = true;
                txtCompanyfilePath.Enabled = false;
                btnOpenCompanyPath.Enabled = false;
            }
        }

        private void btnOpenCompanyPath_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.RestoreDirectory = true;

                openFileDialog1.Filter = "QuickBook File (*.QBW,*.QBA)|*.QBW;*.QBA";

                openFileDialog1.Multiselect = false;

                openFileDialog1.Title = "Open a Company";

                openFileDialog1.ValidateNames = false;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtCompanyfilePath.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtCompanyfilePath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
    }
}
