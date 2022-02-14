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
   // public delegate void showinvoiceflipQty();
    public delegate void delginvoicesetting();
    public partial class frmInvoicePrintModeConfig : Form
    {
        QBConfiguration lobjQBConfiguration;

        public delginvoicesetting objdelinvoicesetting;

        private static frmInvoicePrintModeConfig objfrminvoiceconfig;

        clsInvoiceGroupingByCustomField lobjInvoiceGroupByCustomField = new clsInvoiceGroupingByCustomField();
        clsTemplateLabelXmlwork lobjTemplate = new clsTemplateLabelXmlwork();
        string strTransItemCustompath = string.Empty;
        string strTransCustompath = string.Empty;
        
        public static frmInvoicePrintModeConfig GetInstance()
        {

            if (objfrminvoiceconfig == null)
            {
                objfrminvoiceconfig = new frmInvoicePrintModeConfig();
            }
            return objfrminvoiceconfig;
        }
        //public showinvoiceflipQty flipQty;

        //private static frmInvoicePrintModeConfig objfrmLabelConfig1;
        //public static frmInvoicePrintModeConfig GetInstance()
        //{

        //    if (objfrmLabelConfig1 == null)
        //    {
        //        objfrmLabelConfig1 = new frmInvoicePrintModeConfig();
        //    }
        //    return objfrmLabelConfig1;
        //}
      
        public frmInvoicePrintModeConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();

            if (rdoprintmultiple.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("M", "MultiInvoiceMode");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("S", "MultiInvoiceMode");
            }

            //Date: 27-Feb-2017 save pack per unit option
            if (rdbwithpackperunits.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("Y", "PackperUnits");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("N", "PackperUnits");
            }

            if (chkInvcustomfields.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("1", "InvEnablecustomfields");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "InvEnablecustomfields");
            }

            if (chkInvEnableothercharges.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("1", "InvEnableotherchargesfields");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "InvEnableotherchargesfields");
            }

            if (chkenableparentwithitemname.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("1", "EnableInvParentwithItemName");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "EnableInvParentwithItemName");
            }

            if (chkenablesubitemofcolumn.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("1", "EnableInvSubItemof");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "EnableInvSubItemof");
            }


            //save print label item custom field value: 19-aug-2019
            // if (cmbtxtsingleinvoicesearch.SelectedValue != null)
            // {
            lobjQBConfiguration.SaveCustomFields(Convert.ToString(cmbtxtsingleinvoicesearch.SelectedValue.ToString()), "singleinvoiceprintlabel");
           // }
            // lobjQBConfiguration.SaveCustomFields(cmbtxtsingleinvoicesearch.Text.ToString(), "singleinvoiceItemCustomFieldText");
            //save print job count:23-aug-2019
            lobjQBConfiguration.SaveCustomFields(txtprintjobcount.Text.ToString(), "invoiceprintbatch");
                     
            lobjQBConfiguration.SaveCustomFields(txtdelay.Text.ToString(), "invoiceprintdelay");
            //save pack/unit custom field
            lobjQBConfiguration.SaveLabelFilePathSettings(Convert.ToString(txtpackperunitscustomfield.Text), "PackUnitsCustomField");
            //save customer/item cutom field to config file
            lobjQBConfiguration.SaveCustomFields(cmbgroupbyoption1.SelectedValue.ToString(), "CustomerCustomField"); //store vaue
            lobjQBConfiguration.SaveCustomFields(cmbgroupbyoption1.Text.ToString(), "CustomerCustomFieldText"); //store customer custom text
            lobjQBConfiguration.SaveCustomFields(cmbgroupbyoption2.SelectedValue.ToString(), "ItemCustomField");
            lobjQBConfiguration.SaveCustomFields(cmbgroupbyoption2.Text.ToString(), "ItemCustomFieldText");

            objdelinvoicesetting();

           // DialogResult dlResult = MessageBox.Show("Multiple invoice print mode option saved successfully!!", "Settings Saved", MessageBoxButtons.OKCancel);
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

        private void frmInvoicePrintModeConfig_Load(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                { 
                    lobjQBConfiguration = new QBConfiguration();
                if ((lobjQBConfiguration.GetLabelConfigSettings("MultiInvoiceMode").ToString() == "M"))
                {
                    rdoprintmultiple.Checked = true;

                }
                else
                {
                    rdoprintsingle.Checked = true;
                }

                if ((lobjQBConfiguration.GetLabelConfigSettings("PackperUnits").ToString() == "Y"))
                {
                    rdbwithpackperunits.Checked = true;
                    // gbinvoiceprintqty.Visible = false;
                }
                else
                {
                    rdbwithoutpackperunits.Checked = true;
                    // gbinvoiceprintqty.Visible = true;

                }

                if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("PackUnitsCustomField")))
                {
                    txtpackperunitscustomfield.Text = Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("PackUnitsCustomField"));

                }

                    if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("invoiceprintbatch")))
                    {
                    txtprintjobcount.Text = Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("invoiceprintbatch"));

                    }
                    if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("invoiceprintdelay")))
                    {
                       txtdelay.Text = Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("invoiceprintdelay"));

                    }


                    if ((lobjQBConfiguration.GetLabelConfigSettings("InvEnablecustomfields").ToString() == "1") )
                    {
                        chkInvcustomfields.Checked = true;
                    }
                    else
                    {
                        chkInvcustomfields.Checked = false;
                    }

                    if ((lobjQBConfiguration.GetLabelConfigSettings("EnableInvParentwithItemName").ToString() == "1"))
                    {
                        chkenableparentwithitemname.Checked = true;
                    }
                    else
                    {
                        chkenableparentwithitemname.Checked = false;
                    }
                    if ((lobjQBConfiguration.GetLabelConfigSettings("EnableInvSubItemof").ToString() == "1"))
                    {
                        chkenablesubitemofcolumn.Checked = true;
                    }
                    else
                    {
                        chkenablesubitemofcolumn.Checked = false;
                    }

                    if ((lobjQBConfiguration.GetLabelConfigSettings("InvEnableotherchargesfields").ToString() == "1") )
                    {
                        chkInvEnableothercharges.Checked = true;
                    }
                    else
                    {
                        chkInvEnableothercharges.Checked = false;
                    }

                    //fill customer custom field: for first filter invoice by customer custom field:Date 06-Jun-2019
                    //cmbgroupbyoption1.DataSource = null;
                    //cmbgroupbyoption1.Items.Clear();
                    //// cmbgroupbyoption1.Items.Add("Select Label");
                    //cmbgroupbyoption1.DataSource = lobjInvoiceGroupByCustomField.GetCustomerCustomFieldList().ToArray();

                    //cmbgroupbyoption1.DisplayMember = "Key";
                    //cmbgroupbyoption1.ValueMember = "Value";

                    //    //fill item custom field: for second filter invoice items:Date 06-Jun-2019
                    //cmbgroupbyoption2.DataSource = null;
                    //cmbgroupbyoption2.Items.Clear();
                    //// cmbgroupbyoption1.Items.Add("Select Label");
                    //cmbgroupbyoption2.DataSource = lobjInvoiceGroupByCustomField.GetAllItemCustomFields().ToArray();

                    //cmbgroupbyoption2.DisplayMember = "Key";
                    //cmbgroupbyoption2.ValueMember = "Value";

                    // Dictionary<string, string> lobjCustomerFieldList = new Dictionary<string, string>();
                    // Dictionary<string, string> lobjItemFieldList = new Dictionary<string, string>();



                    //commented below code to replace new code:02-July-2019
                    //var AllCustomFieldList = lobjInvoiceGroupByCustomField.GetAllItems_Customers_CustomFiledList();

                    ////fill customer custom field: for first filter invoice by customer custom field:Date 06-Jun-2019
                    //cmbgroupbyoption1.DataSource = null;
                    //cmbgroupbyoption1.Items.Clear();
                    //cmbgroupbyoption1.DataSource = AllCustomFieldList.Item1.ToArray();

                    //cmbgroupbyoption1.DisplayMember = "Key";
                    //cmbgroupbyoption1.ValueMember = "Value";

                    ////fill item custom field
                    //cmbgroupbyoption2.DataSource = null;
                    //cmbgroupbyoption2.Items.Clear();
                    //cmbgroupbyoption2.DataSource = AllCustomFieldList.Item2.ToArray();

                    //cmbgroupbyoption2.DisplayMember = "Key";
                    //cmbgroupbyoption2.ValueMember = "Value";



                    //fill customer custom field
                    System.IO.DirectoryInfo dirtranscustxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXml" + "\\"));
                    if (dirtranscustxml.Exists)
                    {
                        strTransCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXml" + "\\" + "CustomCustomer list" + ".xml");
                    }
                    else
                    {
                        strTransCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXmlWrite" + "\\" + "CustomCustomer list" + ".xml");
                    }
                    List<QuickBooksField> Customfieldlist = lobjTemplate.FillCustomfieldListfromxml(strTransCustompath);
                    cmbgroupbyoption1.DataSource = Customfieldlist;
                    cmbgroupbyoption1.DisplayMember = "ItemFieldValue";
                    cmbgroupbyoption1.ValueMember = "ItemFieldName";

                    //fill item custom fields
                    System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXml" + "\\"));
                    if (dirtransxml.Exists)
                    {
                        strTransItemCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXml" + "\\" + "CustomItem list" + ".xml");
                    }
                    else
                    {
                        strTransItemCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXmlWrite" + "\\" + "CustomItem list" + ".xml");
                    }
                    List<QuickBooksField> Itemfieldlist = lobjTemplate.FillCustomfieldListfromxml(strTransItemCustompath);
                    cmbgroupbyoption2.DataSource = Itemfieldlist;
                    cmbgroupbyoption2.DisplayMember = "ItemFieldValue";
                    cmbgroupbyoption2.ValueMember = "ItemFieldName";
                    //bind item list to single invoice search printlabel yes/no
                    List<QuickBooksField> Itemfieldlistnew = lobjTemplate.FillCustomfieldListSingleInvoice(strTransItemCustompath);
                    cmbtxtsingleinvoicesearch.DataSource = Itemfieldlistnew;
                    cmbtxtsingleinvoicesearch.DisplayMember = "ItemFieldNameinvsingle";
                    cmbtxtsingleinvoicesearch.ValueMember = "ItemFieldInvValue";


                    //show custom field selected
                    if (Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("CustomerCustomField")) != "")
                    {
                        cmbgroupbyoption1.SelectedValue = Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("CustomerCustomField"));
                    }

                    if (Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("ItemCustomField")) != "")
                    {
                        cmbgroupbyoption2.SelectedValue = Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("ItemCustomField"));
                    }

                    //fill single invoice search value
                    if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("singleinvoiceprintlabel")))
                    {
                        cmbtxtsingleinvoicesearch.SelectedValue = Convert.ToString(lobjQBConfiguration.GetLabelConfigSettings("singleinvoiceprintlabel"));
                        
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
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

        private void btnSyncCustom_Click(object sender, EventArgs e)
        {
            //Sync Item and customer  custom field

            string strStartupPath = string.Empty;
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            List<QuickBooksField> lobjcustomfieldlist = new List<QuickBooksField>();

            string strfilepath = string.Empty;
            strfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXml" + "\\");
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

            File.Copy(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXmlWrite" + "\\" + "CustomItem list.xml"), strfilepath + "CustomItem list.xml", true);
            File.Copy(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXmlWrite" + "\\" + "CustomCustomer list.xml"), strfilepath + "CustomCustomer list.xml", true);

            try
            {
                using (new HourGlass())
                {
                    for (int ifields = 0; ifields < 2; ifields++)
                    {
                        switch (ifields)
                        {
                            case 0: //Item list
                                strStartupPath = strfilepath + "CustomItem list.xml";
                                lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);

                                lobjcustomfieldlist = lobjTemplatexml.GetItemCustomForInvoiceSetting();

                                lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);
                                break;
                            case 1:
                                strStartupPath = strfilepath + "CustomCustomer list.xml";
                                lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);

                                lobjcustomfieldlist = lobjTemplatexml.GetCustomCustomForInvoiceSetting();

                                lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);
                                break;
                            default:
                                break;
                        }
                    }


                    //display field list after sync from quickbooks

                    //fill customer custom field
                    System.IO.DirectoryInfo dirtranscustxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXml" + "\\"));
                    if (dirtranscustxml.Exists)
                    {
                        strTransCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXml" + "\\" + "CustomCustomer list" + ".xml");
                    }
                    else
                    {
                        strTransCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXmlWrite" + "\\" + "CustomCustomer list" + ".xml");
                    }
                    List<QuickBooksField> Customfieldlist = lobjTemplate.FillCustomfieldListfromxml(strTransCustompath);
                    cmbgroupbyoption1.DataSource = Customfieldlist;
                    cmbgroupbyoption1.DisplayMember = "ItemFieldValue";
                    cmbgroupbyoption1.ValueMember = "ItemFieldName";

                    //fill item custom fields
                    System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXml" + "\\"));
                    if (dirtransxml.Exists)
                    {
                        strTransItemCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXml" + "\\" + "CustomItem list" + ".xml");
                    }
                    else
                    {
                        strTransItemCustompath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "CustomFieldXmlWrite" + "\\" + "CustomItem list" + ".xml");
                    }
                    List<QuickBooksField> Itemfieldlist = lobjTemplate.FillCustomfieldListfromxml(strTransItemCustompath);
                    cmbgroupbyoption2.DataSource = Itemfieldlist;
                    cmbgroupbyoption2.DisplayMember = "ItemFieldValue";
                    cmbgroupbyoption2.ValueMember = "ItemFieldName";

                    //bind item list to single invoice search printlabel yes/no
                    List<QuickBooksField> Itemfieldlistnew = lobjTemplate.FillCustomfieldListSingleInvoice(strTransItemCustompath);
                    cmbtxtsingleinvoicesearch.DataSource = Itemfieldlistnew;
                    cmbtxtsingleinvoicesearch.DisplayMember = "ItemFieldNameinvsingle";
                    cmbtxtsingleinvoicesearch.ValueMember = "ItemFieldInvValue";





                }

                MessageBox.Show("Custom Field Sync Sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);





            }
            catch (Exception ex)
            {

            }



        }

        private void txtdelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtprintjobcount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

       
    }
}
