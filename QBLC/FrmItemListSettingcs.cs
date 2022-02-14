using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LabelConnector
{
    public delegate void ItemPrint();
    public partial class FrmItemListSettingcs : Form
    {
        string strStartupPath = string.Empty;
        string strTransItemCustompath = string.Empty;
        QBConfiguration lobjQBConfiguration;
        clsItemDetails lobjItemsData = new clsItemDetails();
        clsTemplateLabelXmlwork lobjTemplate = new clsTemplateLabelXmlwork();
        private static FrmItemListSettingcs objfrmLabelConfig;
        public ItemPrint objItemPrint;
        public static FrmItemListSettingcs GetInstance()
        {
            if (objfrmLabelConfig == null)
            {
                objfrmLabelConfig = new FrmItemListSettingcs();
            }
            return objfrmLabelConfig;
        }
        public FrmItemListSettingcs()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();



            //switch Item on hand qty to print and default 1 
            if (rdoPrintOneQty.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("Y", "FlipItemQty");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("N", "FlipItemQty");

            }
            if (objItemPrint != null)
            {
                objItemPrint();
            }
            this.Close();
        }

        private void btnSyncItem_Click(object sender, EventArgs e)
        {
                       
            clsItemDetails lobjconnection = new clsItemDetails();
            lobjQBConfiguration = new QBConfiguration();
            strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "QuickBookItems.xml");
            string lstrProductDownCount = string.Empty;
            //Download Inventory,NonInventory,Assembly Items from QuickBooks

            if (chkInvItem.Checked == true || chkassembly.Checked == true || chknoninventory.Checked == true || chkgroupitem.Checked == true)
            {

                using (new HourGlass())
                {
                    this.btnSyncItem.Enabled = false;
                    if (lobjconnection.CheckQuickBooksConnection() == true)
                    {
                        lstrProductDownCount = lobjItemsData.WriteQuickBookItemToXml(strStartupPath, chkInvItem.Checked, chkassembly.Checked, chknoninventory.Checked, chkgroupitem.Checked);
                    }

                    else
                    {
                        btnSyncItem.Enabled = true;
                        MessageBox.Show("Please Open QuickBooks Company file", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                   
                }
            }
            else
            {
                MessageBox.Show("Please select Item Type", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (Convert.ToInt32(lstrProductDownCount) > 0)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings(DateTime.Now.ToShortDateString(), "ItemSyncDate");
                MessageBox.Show("Items Sync Count is " + lstrProductDownCount, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                if(!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("ItemSyncDate")))
                {
                  lblSyncItemDate.Text = "Sync Date : " + lobjQBConfiguration.GetLabelConfigSettings("ItemSyncDate");
                }
                this.btnSyncItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Items not found in QuickBooks", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnSyncItem.Enabled = true;

            }
              
        }

        private void FrmItemListSettingcs_Load(object sender, EventArgs e)
        {
            long length = 0;
            string showItemflipvalue = string.Empty;
            string lstrLotColValue = string.Empty;
            lobjQBConfiguration = new QBConfiguration();
            chkInvItem.Checked = false;
            chkassembly.Checked = false;
            chknoninventory.Checked = false;
            chkgroupitem.Checked = false;
            if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("ItemSyncDate")))
            {
                lblSyncItemDate.Text = "Last Sync Date : " + lobjQBConfiguration.GetLabelConfigSettings("ItemSyncDate");
            }
            else
            {
                lblSyncItemDate.Text = "";
            }
            showItemflipvalue = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FlipItemQty");
            if (showItemflipvalue == "Y")
            {
                rdoPrintOneQty.Checked = true;
            }
            else
            {
                rdoPrintItemQty.Checked = true;

            }
            //Get Lot col Name : 28-Aug-18
            lstrLotColValue= lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("LotColumnName");
            if(lstrLotColValue !="")
            {
                txtLotColumn.Text = lstrLotColValue;
            }


            //Added by srinivas on 21-Feb-2018 to retrive FTP server and user credentials 
            if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("FTPServerPath")))
            {
                txtFTPServerPath.Text = lobjQBConfiguration.GetLabelConfigSettings("FTPServerPath");
            }
            else
            {
                txtFTPServerPath.Text = "";
            }
            if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("LoginID")))
            {
                txtLoginID.Text = lobjQBConfiguration.GetLabelConfigSettings("LoginID");
            }
            else
            {
                txtLoginID.Text = "";
            }
            if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("Password")))
            {
                txtPassword.Text = lobjQBConfiguration.GetLabelConfigSettings("Password");
            }
            else
            {
                txtPassword.Text = "";
            }

            //fill item custom fields
            System.IO.DirectoryInfo diritemtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ItemListCustomField" + "\\"));
            if (diritemtransxml.Exists)
            {
                strTransItemCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ItemListCustomField" + "\\" + "customfieldlist" + ".xml");
            }
            else
            {
                strTransItemCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ItemListCustomFieldWrite" + "\\" + "customfieldlist" + ".xml");
            }
            List<QuickBooksField> Itemfieldlist = lobjTemplate.FillCustomfieldListfromxml(strTransItemCustompath);
            drpitemcustomfield.DataSource = Itemfieldlist;
            drpitemcustomfield.DisplayMember = "ItemFieldValue";
            drpitemcustomfield.ValueMember = "ItemFieldName";

            if (Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("multiItemCustomField")) != "")
            {
               drpitemcustomfield.SelectedValue = Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("multiItemCustomField"));
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

        private void btnPrintOption_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();

            //save lot number column name: 28-Aug-2018
            if(txtLotColumn.Text !="")
            {
                lobjQBConfiguration.SaveLabelFilePathSettings(txtLotColumn.Text.ToString(), "LotColumnName");
            }

            //switch Item on hand qty to print and default 1 
            if (rdoPrintOneQty.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("Y", "FlipItemQty");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("N", "FlipItemQty");

            }
            if (objItemPrint != null) 
                {
                objItemPrint();
            }
            DialogResult dlResult = MessageBox.Show("Settings saved successfully!!", "Settings Saved", MessageBoxButtons.OKCancel);
            
        }
        //Added by srinivas on 21-Feb-2018 to save FTP server and user credentials 
        private void btnFTPSave_Click(object sender, EventArgs e)
        {
            string strShowMSG = "true";
            string sourcefilepath = string.Empty;
            string strStartupPath = string.Empty;
            string strtestfilename = string.Empty;
            bool isFileupload = false;

            lobjQBConfiguration = new QBConfiguration();

            //check ftp connection before saving conn info
            strStartupPath = System.Windows.Forms.Application.StartupPath;
            sourcefilepath = Path.Combine(strStartupPath, @"NWN_Files");
            strtestfilename = Directory.GetFiles(sourcefilepath, "*.txt").FirstOrDefault();
            isFileupload = FTPFileUpload(strtestfilename);
            //save ftp upload info if test file is uploaded sucessfully
            if (isFileupload == true)
            {
                if (!string.IsNullOrEmpty(txtFTPServerPath.Text) && !string.IsNullOrWhiteSpace(txtFTPServerPath.Text))  //saving FTP server path
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings(txtFTPServerPath.Text.ToString(), "FTPServerPath");
                    strShowMSG = "false";
                }
                else
                {
                    strShowMSG = "true";
                }

                if (!string.IsNullOrEmpty(txtLoginID.Text) && !string.IsNullOrWhiteSpace(txtLoginID.Text)) //saving Login ID
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings(txtLoginID.Text.ToString(), "LoginID");
                    strShowMSG = "false";
                }
                else
                {
                    strShowMSG = "true";
                }

                if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text)) //saving password
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings(txtPassword.Text.ToString(), "Password");
                    strShowMSG = "false";
                }
                else
                {
                    strShowMSG = "true";
                }

                if (strShowMSG == "true")
                {
                    MessageBox.Show("FTP data cannot be blank", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("FTP Data saved sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private bool FTPFileUpload(string fileNamepath)
        {
            lobjQBConfiguration = new QBConfiguration();
            string errorstring = string.Empty;
            bool blnupload = false;
            string ftpurl = string.Empty;
            string ftpusername = string.Empty;
            string ftppassword = string.Empty;


             ftpurl = Convert.ToString(txtFTPServerPath.Text); 
             ftpusername =  Convert.ToString(txtLoginID.Text);
             ftppassword = Convert.ToString(txtPassword.Text);  

            try
            {
                string filename = Path.GetFileName(fileNamepath);
                //string ftpfullpath = Path.Combine(ftpurl, filename); 
                Uri ftpfullpath = new Uri(new Uri(ftpurl), filename); //-- Updated correct code by TamilRk 12/21/2020
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                FileStream fs = File.OpenRead(fileNamepath);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
                blnupload = true;

            }
            catch (Exception ex)
            {
                blnupload = false;

                if (ex.Message.ToString().Contains("Not logged in"))
                {
                    MessageBox.Show("Invalid FTP LoginID/Password", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ex.Message.ToString().Contains("Invalid URI"))
                {
                    MessageBox.Show("FTP URL not in correct Format" + Environment.NewLine + "Format should be :ftp://192.168.0.7//accuware//", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                //throw ex;
            }
            return blnupload;
        }

        private void btnSyncCustom_Click(object sender, EventArgs e)
        {

            //Sync Item  custom field

            string strStartupPath = string.Empty;
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            List<QuickBooksField> lobjcustomfieldlist = new List<QuickBooksField>();

            string strfilepath = string.Empty;
            strfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ItemListCustomField" + "\\");
            //Delete existing files from Transxml folder
            System.IO.DirectoryInfo di = new DirectoryInfo(strfilepath);
            if (di.Exists)
            {
                if (di.GetFiles().Length > 0)
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }


            if (!Directory.Exists(strfilepath))
            {
                Directory.CreateDirectory(strfilepath);
            }

            File.Copy(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ItemListCustomFieldWrite" + "\\" + "customfieldlist.xml"), strfilepath + "customfieldlist.xml", true);
           
            try
            {
                using (new HourGlass())
                {
                     //Item list
                      strStartupPath = strfilepath + "customfieldlist.xml";
                      lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);
                      lobjcustomfieldlist = lobjTemplatexml.GetItemCustomForInvoiceSetting();
                      lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);
                            
                    //display field list after sync from quickbooks
                    
                    //fill item custom fields
                    System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ItemListCustomField" + "\\"));
                    if (dirtransxml.Exists)
                    {
                        strTransItemCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ItemListCustomField" + "\\" + "customfieldlist" + ".xml");
                    }
                    else
                    {
                        strTransItemCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ItemListCustomFieldWrite" + "\\" + "customfieldlist" + ".xml");
                    }
                    List<QuickBooksField> Itemfieldlist = lobjTemplate.FillCustomfieldListfromxml(strTransItemCustompath);
                    drpitemcustomfield.DataSource = Itemfieldlist;
                    drpitemcustomfield.DisplayMember = "ItemFieldValue";
                    drpitemcustomfield.ValueMember = "ItemFieldName";
                    

                }

                MessageBox.Show("Item Custom Fields Sync Sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {

            }



        }

        private void btncustomfieldsave_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            lobjQBConfiguration.SaveCustomFields(drpitemcustomfield.SelectedValue.ToString(), "multiItemCustomField"); //store vaue
            DialogResult dlResult = MessageBox.Show("Settings saved successfully!!", "Settings Saved", MessageBoxButtons.OKCancel);

        }
    }
}
