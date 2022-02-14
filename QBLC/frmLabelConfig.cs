using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using LabelConnector;
using System.Diagnostics;
using System.IO;

namespace QBLC
{
    public delegate void delLabel();
    public delegate void delOrderType();
    public delegate void deldatefilterType();
    public partial class frmLabelConfig : Form
    {
        QBConfiguration lobjQBConfiguration;
        public delLabel objdelLabel;
        public delOrderType objdelOrderType;
       // public deldatefilterType objdeldatefilterType;
        public string GetConfigval { get; set; }

        private static frmLabelConfig objfrmLabelConfig;
        public static frmLabelConfig GetInstance()
        {

            if (objfrmLabelConfig == null)
            {
                objfrmLabelConfig = new frmLabelConfig();
            }
            return objfrmLabelConfig;
        }

        public frmLabelConfig()
        {
            InitializeComponent();
        }
        void AddFormatData()
        {
      
            //DateTime july28 =  DateTime.Now;

            //string[] july28Formats = july28.GetDateTimeFormats();

            //// Print out july28 in all DateTime formats using the default culture.
            //foreach (string format in july28Formats)
            //{
            //    lstForamt.Items.Add(format);
            //}
            //Boolean hasDate = false;
            //DateTime dateTime = new DateTime();
            //String[] inputText = "MMddyyy".Split(' ');//split on a whitespace

            //foreach (String text in inputText)
            //{
            //    //Use the Parse() method
            //    try
            //    {
            //        dateTime = DateTime.Parse(text);
            //        hasDate = true;
            //        break;//no need to execute/loop further if you have your date
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}

            ////after breaking from the foreach loop, you can check if hasDate=true
            ////if it is, then your user entered a date and you can retrieve it from the dateTime 

            //if (hasDate)
            //{
            //    //user entered a date, get it from dateTime
            //}
            //else
            //{
            //    //user didn't enter any date
            //}

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /* Variable declaration for setting default label path for first time ***Start*** by Srinivas 10-Jan-2018 */
            string strFolderpathStatus = string.Empty;

            /* Variable declaration for setting default label path for first time ***End*** by Srinivas 10-Jan-2018 */
            lobjQBConfiguration = new QBConfiguration();  
            //save Template Label Path
            lobjQBConfiguration.SaveLabelFilePathSettings(txtTemplateLabelPath.Text.Trim(), "TempLabelPath");
            //objdelLabel();
            //set label path for multiple option
            //save Static Label Path
            lobjQBConfiguration.SaveLabelFilePathSettings(txtStaticLabelPath.Text.Trim(), "LabelPath");

            strFolderpathStatus = lobjQBConfiguration.GetLabelConfigSettings("FolderpathStatus");

            if (strFolderpathStatus.ToUpper().ToString() == "ONE")
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("Two", "FolderpathStatus");

            }

            if (rdomanual.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("Manual", "AutoManualCheck");
            }
            else
            {
              
                lobjQBConfiguration.SaveLabelFilePathSettings("Auto", "AutoManualCheck");
            }

            if (!string.IsNullOrWhiteSpace(txtSelectedDirectory.Text))
             {
                lobjQBConfiguration.SaveLabelFilePathSettings(txtSelectedDirectory.Text.ToString().Trim(), "SelectedCustomImageDirectoryPath");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("", "SelectedCustomImageDirectoryPath");
            }

            //check print label type
            if(rdbtypebartederlabel.Checked==true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("B", "PrintLabelType"); //bartender label
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("U", "PrintLabelType"); //UDF label
            }

            //Configure print option/type from app.config:Date 30-03-2016
            if (rdbPO.Checked == true)
            {
                if (rdbA.Checked == true)
                {

                    lobjQBConfiguration.SaveLabelFilePathSettings("PoMultiple", "OrderType");

                }
                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("PoSingle", "OrderType");
                }

            }

            if (rdbSO.Checked == true)
            {
                if (rdbA.Checked == true)
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("SoMultiple", "OrderType");

                }
                else if (rdbC.Checked == true)
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("SoPackage", "OrderType");
                }
                else if (rdbd.Checked == true)
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("SoScan", "OrderType");
                }
                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("SoSingle", "OrderType");
                }
            }
            if (rdbSR.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("SrMultiple", "OrderType");
            }


            if (rdbInvoice.Checked == true)
            {
                if (rdbA.Checked == true)
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("InvMultiple", "OrderType");

                }
                else if (rdbC.Checked == true)
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("InvPackage", "OrderType");
                }

                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("InvSingle", "OrderType");
                }


            }

            if (rdbInvPackaging.Checked == true)
            {
                if (rdbA.Checked == true)
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("InvPackA", "OrderType"); //multiple

                }
                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("InvPackB", "OrderType"); //single
                }
            }


            if (chkEnableVariableImageCustCF.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("1", "EnableCustomerCustomImage");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "EnableCustomerCustomImage");
            }

            //printer setting saved
            if (radioButton1.Checked == true) //screen printer
            {

                lobjQBConfiguration = new QBConfiguration();

                lobjQBConfiguration.SaveLabelFilePathSettings("Screen", "CurrentPrinter");
               
            }
            else
            {

                if (cmbLabelPrinter.Text != "Select Printer") //common printer
                {
                    lobjQBConfiguration = new QBConfiguration();

                    lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelPrinter.Text.ToString(), "CurrentPrinter");
                    
                }
                else
                {
                    MessageBox.Show("Please select printer name.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if(!(string.IsNullOrEmpty(txtDateStamp.Text) || string.IsNullOrWhiteSpace(txtDateStamp.Text)))
            {
                lobjQBConfiguration.SaveLabelFilePathSettings(txtDateStamp.Text.ToString(), "DateFormate");
                //Added by TamilRk (10/12/2020)
                ModGlobal.DataStamp = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("DateFormate").ToString();
            }
            else
            {
                MessageBox.Show("Please enter the Date Stamp format.", "Label Connector");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtdataShift.Text))
            {

                lobjQBConfiguration = new QBConfiguration();
                //save Template Label Path
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "DateShift");

                //Added by TamilRk (11/10/2020)
                ModGlobal.DateShift = Convert.ToDouble(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("DateShift").ToString());                

            }
            else
            {
                lobjQBConfiguration = new QBConfiguration();
                //save Template Label Path
                lobjQBConfiguration.SaveLabelFilePathSettings(txtdataShift.Text, "DateShift");

                //Added by TamilRk (11/10/2020)
                ModGlobal.DateShift = Convert.ToDouble(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("DateShift").ToString());
            }

            if (!(string.IsNullOrEmpty(txtTimeFormat.Text) || string.IsNullOrWhiteSpace(txtTimeFormat.Text)))
            {
                lobjQBConfiguration.SaveLabelFilePathSettings(txtTimeFormat.Text.ToString(), "TimeFormate");
                //Added by TamilRk (10/12/2020)
                ModGlobal.TimeStamp = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("TimeFormate").ToString();
            }
            else
            {
                MessageBox.Show("Please enter the Time Stamp format.", "Label Connector");
                return;
            }


            objdelLabel();
            objdelOrderType();
            //objdeldatefilterType();
          
            MessageBox.Show("Configuration setting saved successfully.", "Label Connector");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);

            if (folderBrowserDialog1.SelectedPath != "") txtTemplateLabelPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLabelConfig_Load(object sender, EventArgs e)
        {
            string strAutoManualopt = string.Empty;
            string strdaterangevalue = string.Empty;

            /* Variable declaration for setting default label path for first time ***Start*** by Srinivas 10-Jan-2018 */
            string strLabelPathStatus = string.Empty;
            string strMyDocBTWFilesFolder = string.Empty;
            string strFolderpathStatus = string.Empty;
            string Folderpath = string.Empty;
            string strLabelPath = string.Empty;
            /* Variable declaration for setting default label path for first time ***End*** by Srinivas 10-Jan-2018 */
        

            try
            {
                //lstForamt.SelectedIndex = 0;
                lobjQBConfiguration = new QBConfiguration();

                // ***Start***Old commented by Srinivas for implementing Default Path setting Logic on 17-Jan-2018
                //get TemplateLabel path
                //txtTemplateLabelPath.Text = lobjQBConfiguration.GetLabelConfigSettings("TempLabelPath");
                //get static label path
                //txtStaticLabelPath.Text = lobjQBConfiguration.GetLabelConfigSettings("LabelPath");
                // ***Start***Old commented by Srinivas for implementing Default Path setting Logic on 17-Jan-2018

                /* Code ***Start*** for setting folder path by Srinivas 17-Jan-2018*/
                //get BTW file folder from my documents folder
                strMyDocBTWFilesFolder = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Label Connector Templates");
                //get Label Path
                strLabelPath = lobjQBConfiguration.GetLabelConfigSettings("LabelPath");
                //get status of Label path 
                strFolderpathStatus = lobjQBConfiguration.GetLabelConfigSettings("FolderpathStatus");

                //get data format - by TamilRk 10/12/2020
                txtDateStamp.Text = lobjQBConfiguration.GetLabelConfigSettings("DateFormate");
                lblDateFormat.Text = DateTime.Now.ToString(txtDateStamp.Text.ToString());

                txtTimeFormat.Text = lobjQBConfiguration.GetLabelConfigSettings("TimeFormate");
                lblTimeFormat.Text = DateTime.Now.ToString(txtTimeFormat.Text.ToString());

                txtdataShift.Text = lobjQBConfiguration.GetLabelConfigSettings("DateShift");
                lbldtatshift.Text = DateTime.Now.AddDays(Convert.ToDouble(txtdataShift.Text)).ToString(txtDateStamp.Text.ToString());

                txtSelectedDirectory.Text = lobjQBConfiguration.GetLabelConfigSettings("SelectedCustomImageDirectoryPath");


                if ((lobjQBConfiguration.GetLabelConfigSettings("EnableCustomerCustomImage").ToString() == "1"))
                {
                    chkEnableVariableImageCustCF.Checked = true;
                }
                else
                {
                    chkEnableVariableImageCustCF.Checked = false;
                }

                if (strFolderpathStatus.ToUpper().ToString() == "ONE")
                {
                    Folderpath = strMyDocBTWFilesFolder;

                }
                else
                {
                    Folderpath = strLabelPath;
                }
                txtStaticLabelPath.Text = Folderpath;

                txtTemplateLabelPath.Text = lobjQBConfiguration.GetLabelConfigSettings("TempLabelPath");
                /* Code ***End*** for setting folder path by Srinivas 17-Jan-2018*/


                strAutoManualopt = lobjQBConfiguration.GetLabelConfigSettings("AutoManualCheck");

                if (strAutoManualopt.ToUpper().Trim() == "AUTO")
                {
                    rdoauto.Checked = true;
                }
                else
                {
                   
                    rdomanual.Checked = true;
                }
                //set print label type Bartder or UDF: Date 30-Jan-2019
                if (lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "B")
                {
                    rdbtypebartederlabel.Checked = true;
                }
                else
                {
                    rdbtypebartederlabel.Checked = false;
                }
                if(lobjQBConfiguration.GetLabelConfigSettings("PrintLabelType") == "U")
                {
                    rdbtypeudlabel.Checked = true;

                    btnWeatherLabelPath.Enabled = false;
                    btnBrowse.Enabled = false;
                    txtStaticLabelPath.Enabled = false;
                    txtTemplateLabelPath.Enabled = false;
                    checkmultidefault.Enabled = false;
                }
                else
                {
                    rdbtypeudlabel.Checked = false;

                    //btnWeatherLabelPath.Enabled = true;
                    //btnBrowse.Enabled = true;
                    //txtStaticLabelPath.Enabled = true;
                    //txtTemplateLabelPath.Enabled = true;
                }

                    //Printer Setting

                    if (lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter") == "Screen")
                {
                    //from screen
                    radioButton1.Checked = true;
                    lblprintername.Visible = false;
                    cmbLabelPrinter.Visible = false;

                }
                else
                {
                    //from setting
                    radioButton2.Checked = true;
                    lblprintername.Visible = true;
                    cmbLabelPrinter.Visible = true;
                    GetPrinters();

                }
                
                GetOrderTypeSetting();
               // lblWeatherLabelPath.Visible = false;
               // txtboxWeatherlabelPath.Visible = false;
              //  btnWeatherLabelPath.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }

        }
        ////private void getdataformat()
        ////{
        ////    AutoCompleteStringCollection lststringcollection = new AutoCompleteStringCollection();         

        ////    lststringcollection.Add("MM/DD/YY");
        ////    lststringcollection.Add("DD/MM/YY");
        ////    lststringcollection.Add("YY/MM/DD");
        ////    lststringcollection.Add("Month D, Yr");
        ////    lststringcollection.Add("M/D/YY");
        ////    lststringcollection.Add("D/M/YY");
        ////    lststringcollection.Add("YY/M/D");
        ////    lststringcollection.Add("bM/bD/YY");
        ////    lststringcollection.Add("bD/bM/YY");
        ////    lststringcollection.Add("YY/bM/bD");
        ////    lststringcollection.Add("MMDDYY");
        ////    lststringcollection.Add("DDMMYY");
        ////    lststringcollection.Add("YYMMDD");
        ////    lststringcollection.Add("MonDDYY");
        ////    lststringcollection.Add("DDMonYY");
        ////    lststringcollection.Add("YYMonDD");
        ////    lststringcollection.Add("day/YY");
        ////    lststringcollection.Add("YY/day");
        ////    lststringcollection.Add("D Month, Yr");
        ////    lststringcollection.Add("Yr, Month D");
        ////    lststringcollection.Add("Mon-DD-YYYY");
        ////    lststringcollection.Add("DD-Mon-YYYY");
        ////    lststringcollection.Add("YYYYY-Mon-DD");
        ////    lststringcollection.Add("Mon DD, YYYY");
        ////    lststringcollection.Add("DDMonYY");
        ////    lststringcollection.Add("DDMonYY");

        ////    txtDateStamp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

        ////    txtDateStamp.AutoCompleteSource = AutoCompleteSource.CustomSource;

        ////    txtDateStamp.AutoCompleteCustomSource = lststringcollection;
        ////}
        private void GetPrinters()
        {
            lobjQBConfiguration = new QBConfiguration();
            if (cmbLabelPrinter.Items.Count == 0)
            {
                cmbLabelPrinter.Items.Add("Select Printer");
                foreach (string strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cmbLabelPrinter.Items.Add(strPrinter);
                }
            }

            if (!string.IsNullOrEmpty(lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter")))
            {
                if (lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter") == "Screen")
                {
                    cmbLabelPrinter.SelectedIndex = 0;
                }
                else
                {
                    cmbLabelPrinter.SelectedItem = lobjQBConfiguration.GetLabelConfigSettings("CurrentPrinter");
                }
            }
            else
            {
                cmbLabelPrinter.SelectedIndex = 0;
            }


        }

        private void GetOrderTypeSetting()
        {
            GetConfigval = lobjQBConfiguration.GetLabelConfigSettings("OrderType");
            switch (GetConfigval)
            {
                //Invoice
                case "InvSingle":
                    rdbInvoice.Checked = true;
                    rdbB.Checked = true;
                    rdbd.Enabled = false;
                    break;
                case "InvMultiple":
                    rdbInvoice.Checked = true;
                    rdbA.Checked = true;
                    rdbd.Enabled = false;
                    break;
                //case "InvPackage":
                //    rdbInvoice.Checked = true;
                //    rdbC.Checked = true;
                //    rdbd.Enabled = false;
                //    break;
                case "InvPackA":
                    rdbInvPackaging.Checked = true;
                    rdbA.Checked = true;
                    rdbd.Enabled = false;
                    break;

                case "InvPackB":
                    rdbInvPackaging.Checked = true;
                    rdbB.Checked = true;
                    rdbd.Enabled = false;
                    break;

                //sales order
                case "SoSingle":
                    rdbSO.Checked = true;
                    rdbB.Checked = true;
                    break;
                case "SoMultiple":
                    rdbSO.Checked = true;
                    rdbA.Checked = true;
                    break;
                case "SoPackage":
                    rdbSO.Checked = true;
                    rdbC.Checked = true;
                    break;
                case "SoScan":
                    rdbSO.Checked = true;
                    rdbd.Checked = true;
                    break;
                //Purchase Order
                case "PoMultiple":
                    rdbPO.Checked = true;
                    rdbA.Checked = true;
                    break;
                case "PoSingle":
                    rdbPO.Checked = true;
                    rdbB.Checked = true;
                    break;
                case "SrMultiple":
                    rdbSR.Checked = true;
                    rdbA.Checked = true;
                    break;

                default:
                    rdbInvoice.Checked = true;
                    rdbA.Checked = true;
                    break;
            }
        }

        private void btnWeatherLabelPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog(this);

            if (folderBrowserDialog2.SelectedPath != "") txtStaticLabelPath.Text = folderBrowserDialog2.SelectedPath;
        }

        private void rdbPO_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            rdbB.Checked = true;
            rdbC.Enabled = false;


        }

        private void rdbSO_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            rdbA.Checked = true;
           // rdbC.Enabled = true; // make packaging option available for sales order :Date :04/27/2015
           // rdbB.Checked = true;



        }

        private void rdbInvoice_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            rdbC.Enabled = false;
            rdbB.Checked = true;


        }

        private void Clear()
        {
            try
            {
                if (rdbPO.Checked == true || rdbInvoice.Checked == true || rdbInvPackaging.Checked == true|| rdbSR.Checked == true)
                    rdbd.Enabled = false;
                else
                    rdbd.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbInvPackaging_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            rdbC.Enabled = false;
            rdbB.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lblprintername.Visible = false;
            cmbLabelPrinter.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lblprintername.Visible = true;
            cmbLabelPrinter.Visible = true;
            GetPrinters();
        }

        private void rdbtypeudlabel_CheckedChanged(object sender, EventArgs e)
        {
            btnWeatherLabelPath.Enabled = false;
            btnBrowse.Enabled = false;
            txtStaticLabelPath.Enabled = false;
            txtTemplateLabelPath.Enabled = false;
            checkmultidefault.Enabled = false;



        }

        private void rdbtypebartederlabel_CheckedChanged(object sender, EventArgs e)
        {
            btnWeatherLabelPath.Enabled = true;
            btnBrowse.Enabled =true;
            txtStaticLabelPath.Enabled = true;
            txtTemplateLabelPath.Enabled = true;
            checkmultidefault.Enabled = true;
        }

        private void rdbSR_CheckedChanged(object sender, EventArgs e)
        {
            Clear();          
            rdbA.Checked = true;
        }

        private void lstForamt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lstForamt.SelectedIndex >= 0)
            //{
            //    lblFormat.Text =DateTime. (lstForamt.SelectedItem).ToString();
            //}
        }

        private void txtDateStamp_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDateStamp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 'd')||(e.KeyChar == 'y') || (e.KeyChar == 'm')|| (e.KeyChar == 'D') || (e.KeyChar == 'Y') || (e.KeyChar == 'M') || (e.KeyChar==8) || (e.KeyChar == 32))
            {
                e.Handled = false;
            }else if ((e.KeyChar == '.') || (e.KeyChar == '/') || (e.KeyChar == ',') || (e.KeyChar == '-'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnApplay_Click(object sender, EventArgs e)
        {
            string dataFormat = txtDateStamp.Text.ToString();
            if (string.IsNullOrEmpty(dataFormat) || string.IsNullOrWhiteSpace(dataFormat))
            {
                lblDateFormat.Text = "";
                MessageBox.Show("Please enter the Date Stamp format.", "Label Connector");
                return;
            }
            string dataUpdateFormat = "";
           
           int mCount = dataFormat.Split('m').Length - 1;
             mCount = mCount + dataFormat.Split('M').Length - 1;

            int dCount = dataFormat.Split('d').Length - 1;
            dCount = dCount + dataFormat.Split('D').Length - 1;

            int yCount = dataFormat.Split('y').Length - 1;
            yCount = yCount + dataFormat.Split('Y').Length - 1;

            foreach (char c in dataFormat )
            {
                var dd = c.ToString();
                if (dd == "m" || dd == "M")
                {
                    if (mCount == 1)
                    {
                        dataUpdateFormat = dataUpdateFormat + "MM";
                    }
                    else
                    {
                        dataUpdateFormat = dataUpdateFormat + "M";
                    }
                }else if (dd == "d" || dd == "D")
                {
                    if (dCount == 1)
                    {
                        dataUpdateFormat = dataUpdateFormat + "dd";
                    }
                    else
                    {
                        dataUpdateFormat = dataUpdateFormat + "d";
                    }
                }else if (dd == "y" || dd == "Y")
                {
                    if (yCount == 1)
                    {
                        dataUpdateFormat = dataUpdateFormat + "yy";
                    }
                    else
                    {
                        dataUpdateFormat = dataUpdateFormat + "y";
                    }
                }else
                {
                    dataUpdateFormat = dataUpdateFormat + dd;
                }
            }
            if (dataUpdateFormat.Split('d').Length - 1 > 1 || dataUpdateFormat.Split('y').Length - 1 > 1 || dataUpdateFormat.Split('M').Length - 1 > 1)
            {
                lblDateFormat.Text = DateTime.Now.ToString(dataUpdateFormat);
                txtDateStamp.Text = dataUpdateFormat;
                lobjQBConfiguration = new QBConfiguration();
                //save Template Label Path
                lobjQBConfiguration.SaveLabelFilePathSettings(dataUpdateFormat, "DateFormate");

                //Added by TamilRk (10/12/2020)
                ModGlobal.DataStamp = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("DateFormate").ToString();
            }
            else
            {
                lblDateFormat.Text = "";
                txtDateStamp.Text = "";
            }
        }

        private void txtTimeFormat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 'H') || (e.KeyChar == 'h') || (e.KeyChar == 'm') || (e.KeyChar == 'M') || (e.KeyChar == 's') || (e.KeyChar == 't') || (e.KeyChar == 'S') || (e.KeyChar == 'T') || (e.KeyChar == 8) || (e.KeyChar == 32))            {
                e.Handled = false;
            }
            else if ((e.KeyChar == '.') || (e.KeyChar == '/') || (e.KeyChar == ',') || (e.KeyChar == '-') || (e.KeyChar == ':'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnApplyTime_Click(object sender, EventArgs e)
        {
            string timeFormat = txtTimeFormat.Text.ToString();
            if (string.IsNullOrEmpty(timeFormat) || string.IsNullOrWhiteSpace(timeFormat))
            {
                lblTimeFormat.Text = "";              
                MessageBox.Show("Please enter the Time Stamp format.", "Label Connector");              
                return;
            }
            string timeUpdateFormat = "";

            int mCount = timeFormat.Split('m').Length - 1;
            mCount = mCount + timeFormat.Split('M').Length - 1;

            int hCount = timeFormat.Split('h').Length - 1;
            int HCount = timeFormat.Split('H').Length - 1;

            int sCount = timeFormat.Split('s').Length - 1;
            sCount = sCount + timeFormat.Split('S').Length - 1;

            int tCount = timeFormat.Split('t').Length - 1;
            tCount = tCount + timeFormat.Split('T').Length - 1;

            foreach (char c in timeFormat)
            {
                var dd = c.ToString();
                if (dd == "m" || dd == "M")
                {
                    if (mCount == 1)
                    {
                        timeUpdateFormat = timeUpdateFormat + "mm";
                    }
                    else
                    {
                        timeUpdateFormat = timeUpdateFormat + "m";
                    }
                }
                else if (dd == "h")
                {
                    if (hCount == 1)
                    {
                        timeUpdateFormat = timeUpdateFormat + "hh";
                    }
                    else
                    {
                        timeUpdateFormat = timeUpdateFormat + "h";
                    }
                    
                }
                else if (dd == "H")
                {
                    if (HCount == 1)
                    {
                        timeUpdateFormat = timeUpdateFormat + "HH";
                    }
                    else
                    {
                        timeUpdateFormat = timeUpdateFormat + "H";
                    }

                }
                else if (dd == "s" || dd == "S")
                {
                    if (sCount == 1)
                    {
                        timeUpdateFormat = timeUpdateFormat + "ss";
                    }
                    else
                    {
                        timeUpdateFormat = timeUpdateFormat + "s";
                    }
                }
                else if (dd == "t" || dd == "T")
                {
                    if (sCount == 1)
                    {
                        timeUpdateFormat = timeUpdateFormat + "tt";
                    }
                    else
                    {
                        timeUpdateFormat = timeUpdateFormat + "t";
                    }
                }
                else
                {
                    timeUpdateFormat = timeUpdateFormat + dd;
                }
            }
            if (timeUpdateFormat.Split('h').Length - 1 > 1 || timeUpdateFormat.Split('H').Length - 1 > 1 || timeUpdateFormat.Split('s').Length - 1 > 1 || timeUpdateFormat.Split('m').Length - 1 > 1 || timeUpdateFormat.Split('t').Length - 1 > 1)
            {
                lblTimeFormat.Text = DateTime.Now.ToString(timeUpdateFormat);
                txtTimeFormat.Text = timeUpdateFormat;
                lobjQBConfiguration = new QBConfiguration();
                //save Template Label Path
                lobjQBConfiguration.SaveLabelFilePathSettings(timeUpdateFormat, "TimeFormate");

                //Added by TamilRk (10/12/2020)
                ModGlobal.TimeStamp = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("TimeFormate").ToString();
            }
            else
            {
                lblTimeFormat.Text = "";
                txtTimeFormat.Text = "";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtTimeFormat_Leave(object sender, EventArgs e)
        {

        }

        private void txtDateStamp_Leave(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtdataShift.Text))
            {

                lobjQBConfiguration = new QBConfiguration();
                //save Template Label Path
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "DateShift");

                //Added by TamilRk (11/10/2020)
                ModGlobal.DateShift = Convert.ToDouble(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("DateShift").ToString());
                lbldtatshift.Text = DateTime.Now.AddDays(ModGlobal.DateShift).ToString(lobjQBConfiguration.GetLabelConfigSettings("DateFormate"));

            }
            else
            {               
                lobjQBConfiguration = new QBConfiguration();
                //save Template Label Path
                lobjQBConfiguration.SaveLabelFilePathSettings(txtdataShift.Text, "DateShift");

                //Added by TamilRk (11/10/2020)
                ModGlobal.DateShift = Convert.ToDouble(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("DateShift").ToString());
                lbldtatshift.Text = DateTime.Now.AddDays(ModGlobal.DateShift).ToString(lobjQBConfiguration.GetLabelConfigSettings("DateFormate"));
            }

        }
                    
        private void txtdataShift_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtdataShift.Text))
            {
                txtdataShift.Text = "0";
            }

        }

        private void btnSelectDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
                string templatepath = "";
                
                FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();

                    if (openFolderDialog.ShowDialog() == DialogResult.OK)
                    {
                            txtSelectedDirectory.Text = openFolderDialog.SelectedPath;
                    }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSelectedDirectory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
    }
}