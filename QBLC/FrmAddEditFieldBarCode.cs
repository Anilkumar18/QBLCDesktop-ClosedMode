using iTextSharp.text;
using iTextSharp.text.pdf;
using NReco.PdfRenderer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabelConnector
{
    public delegate void ItemPrint2();
    public partial class FrmAddEditFieldBarCode : Form
    {
        List<QuickBooksField> MultiDataSourceLsit = new List<QuickBooksField>();
        clsTemplateLabelXmlwork lobjTemplate = new clsTemplateLabelXmlwork();
        List<clsTemplateLabelXmlwork> objStaticfieldlist = new List<clsTemplateLabelXmlwork>();
        clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
        string SetValuesForTransType = string.Empty;
        string SetValuesForTemplate = string.Empty;
        string Id = string.Empty;
        string SetFieldName = string.Empty;
        string Setgridfieldname = string.Empty;
        string SetTemplatewidth = string.Empty;
        string SetTemplateheight = string.Empty;
        string SetFieldType = string.Empty;
        string readfieldType = string.Empty;
        string lstrdelimeter = string.Empty;
        string lstrqrbarcodetext = string.Empty;
        float X = 0;
        float Y = 0;
        string xOriginal = "";
        string yOriginal = "";
        public string designerHeight = "";
        // public static string updatefieldname = string.Empty;
        // Define delegate
        public delegate void PassControl(String pstrTemplate, String pcmbTransType);
        // Create instance (null)
        public PassControl passControl;

        public FrmAddEditFieldBarCode()
        {
            InitializeComponent();
        }
        public FrmAddEditFieldBarCode(string pstrtemplate,string Id, string pstrtransactiontype,string pstrfieldname=null,string pstrgridselectedfieldname=null,string strfieldtype=null)
        {
            this.SetValuesForTemplate = pstrtemplate;
            this.Id = Id;
            this.SetValuesForTransType = pstrtransactiontype;
            this.SetFieldName = pstrfieldname;
            this.Setgridfieldname = pstrgridselectedfieldname;
            this.readfieldType = strfieldtype;
            InitializeComponent();
           
        }
        public FrmAddEditFieldBarCode(string pstrtemplate, string pstrtransactiontype, float lntPositionX, float lntPositionY, string OriginalPositionX, string OriginalPositionY, string pstrfieldname = null) //new#
        {
            this.SetValuesForTemplate = pstrtemplate;
            this.SetValuesForTransType = pstrtransactiontype;
            this.X = lntPositionX;
            this.Y = lntPositionY;
            this.SetFieldName = pstrfieldname;
            this.xOriginal = OriginalPositionX;
            this.yOriginal = OriginalPositionY;
            InitializeComponent();

        }
        public FrmAddEditFieldBarCode(string pstrtemplate, string pstrtransactiontype, string pstrfieldname = null) 
        {
            this.SetValuesForTemplate = pstrtemplate;
            this.SetValuesForTransType = pstrtransactiontype;
            this.SetFieldName = pstrfieldname;
           
            InitializeComponent();
         
            }
        private void FrmAddEditField_Load(object sender, EventArgs e)
        {
            txtdesignerheght.Text = this.designerHeight;
            string strTransTypeFilePath = string.Empty;
            List<string> dsdatasourcetext = null;
            cmbFieldType.DataSource = GetFieldTypeList();
            cmbFieldType.DisplayMember = "ItemFieldName";
            cmbFieldType.ValueMember = "ItemFieldId";
            //fill orientation list
            cmborientation.DataSource = GetOrientationList();
            cmborientation.DisplayMember = "ItemFieldName";
            cmborientation.ValueMember = "ItemFieldId";
            dsMultiDataSourceList.Visible = false;
            ////lbldelimeter.Visible = false;
            ////txtdelimeter.Visible = false;
            //commond by tamil - adding multi data source
            // pnlotherctrls.Location = new Point(14, 109);
            cmbDataCharView.SelectedIndex = 1;
            cmbDataCharAlign.SelectedIndex = 1;

            //pnldatamatrix.Visible = false;

            objStaticfieldlist = lobjTemplatexml.GetFieldPropertiesList(SetValuesForTemplate, string.Empty);

            // strTransTypeFilePath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + SetValuesForTransType + ".xml";

            System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
            if (dirtransxml.Exists)
            {
                strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + SetValuesForTransType + ".xml");
            }
            else
            {
                strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + SetValuesForTransType + ".xml");
            }
            List<QuickBooksField> Itemfieldlist = lobjTemplate.GetItemFieldListfromxml(strTransTypeFilePath);
            cmbdatasource.DataSource = Itemfieldlist;
            cmbdatasource.DisplayMember = "ItemFieldValue";
            cmbdatasource.ValueMember = "ItemFieldName";
            pnlfieldlist1.Visible = true;
            //pnlfieldlist2.Visible = false;           


            dsMultiDataSourceList.DataSource =  Itemfieldlist.Skip(1).ToList();
            dsMultiDataSourceList.DisplayMember = "ItemFieldValue";
            dsMultiDataSourceList.ValueMember = "ItemFieldName";

            //fill barcodetypes
            cmbbarcodetype.DataSource = GetBarCodeTypeList();
            cmbbarcodetype.DisplayMember = "ItemFieldName";
            cmbbarcodetype.ValueMember = "ItemFieldId";


            //show edit field properties window
            if (this.SetFieldName != null)
            {
                //edit mode
                var objfieldlist = lobjTemplate.GetFieldPropertiesList(this.SetValuesForTemplate, this.Id);//this.SetFieldName
                foreach (clsTemplateLabelXmlwork itemfield in objfieldlist)
                {
                    //show records for selected fieldname
                    cmbFieldType.Text = itemfield.fieldtype;
                    txtfieldname.Text = itemfield.fieldname;
                    
                        cmbdatasource.Text = itemfield.datasource;
                   
                    txttestdata.Text = itemfield.testdata;
                    cmbbarcodetype.Text= itemfield.barcodetype;
                    if (itemfield.DataCharView != "")
                    {
                        cmbDataCharView.SelectedIndex = Convert.ToInt16(itemfield.DataCharView);
                    }
                    if (itemfield.DataCharAlign != "")
                    {
                        cmbDataCharAlign.SelectedIndex = Convert.ToInt16(itemfield.DataCharAlign);
                    }
                    if (itemfield.barcharvisible != "")
                    {
                        chkbarfountstates.Checked = Convert.ToBoolean(itemfield.barcharvisible);
                    }
                    if (itemfield.barcodetype != null)
                    {
                        if(!(itemfield.barcodetype.ToString().ToLower().Trim()== "UPC-A".ToLower()) && !string.IsNullOrWhiteSpace(itemfield.delimiter))
                        {
                            //dsdatasourcetext = new List<string>();
                            //char charArr = itemfield.delimiter.ToString().ToCharArray()[0];
                            //dsdatasourcetext = itemfield.datasourcetext.Split(charArr).ToList();

                            dsdatasourcetext = new List<string>();
                            string chart = itemfield.datasourcetext.ToString().Replace(itemfield.delimiter, "~");
                            dsdatasourcetext = chart.Split('~').ToList();
                            foreach (string DataVal in dsdatasourcetext)
                            {

                                for (int count = 0; count < dsMultiDataSourceList.Items.Count; count++)
                                {
                                    var fieldnames = (LabelConnector.QuickBooksField)dsMultiDataSourceList.Items[count];
                                    string dataSource = "";
                                    
                                        dataSource = Convert.ToString(fieldnames.ItemFieldValue);

                                    var Itemstatic = DataVal.Split('∬');
                                    if (dataSource == DataVal)
                                    {
                                        MultiDataSourceLsit.Add(fieldnames);
                                    }
                                    else if (Itemstatic.Length > 1)
                                    {
                                        QuickBooksField objitem = new QuickBooksField("Static1", DataVal);
                                        MultiDataSourceLsit.Add(objitem);
                                        break;
                                    }
                                }
                            }
                            chkMSelect.Checked = true;
                            txtdelimeter.Text = itemfield.delimiter.ToString();

                        }
                        //if (itemfield.barcodetype.ToString().ToLower() == "datamatrix")
                        //{
                        //    cmbdatamatrixheight.Text = itemfield.imgheight;
                        //    cmbdatamatrixwidth.Text = itemfield.imgwidth;
                        //    txtimagewidth.Text = itemfield.imgnewwidth;
                        //}
                        //else
                        //{
                        txtbarcodeheight.Text = itemfield.imgheight;
                            txtbarcodewidth.Text = itemfield.imgwidth;
                          
                       // }
                    }
                  
                   // txtwordwrap.Text = itemfield.wordwrap;
                    cmborientation.Text = itemfield.orientation;
                    txtxpos.Text = itemfield.xposition;
                    txtypos.Text = itemfield.yposition;
                    txtxopos.Text = itemfield.xoriginalposition;
                    txtyopos.Text = itemfield.yoriginalposition;
        
                    txtfontsize.Text = itemfield.fontsize;
                    // updatefieldname = this.SetFieldName; //used in upating
                    // readfieldType= itemfield.fieldtype; //22-APR-2019

                    if (itemfield.barcodetype != null) //09-oct-2019
                    {
                        checknull();
          ////              if (itemfield.barcodetype.ToString().ToLower().Trim() == "qrcode")
          ////              {
          ////                  btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
          ////   !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;

                        ////              }
                        ////              else
                        ////              {
                        ////                  btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
                        ////!String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text);

                        ////              }
                    }


                        }
                lblfieldpropertytext.Text = "Edit Field Properties";
                cmbFieldType.Enabled = false;
                //comment on 9-oct-2019
              //  btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
              //!String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;

            }

             if(this.SetFieldType == "BarCode")
            {
                cmbFieldType.Text = "BarCode";
                cmbFieldType.Enabled = false;

                txtfieldname.TabIndex = 0;
                cmbbarcodetype.TabIndex = 1;

                txttestdata.TabIndex = 2;
                cmbdatasource.TabIndex = 3;
                btnMultiSelect.TabIndex = 3;
                txtdelimeter.TabIndex = 4;
                txtbarcodeheight.TabIndex = 5;
                txtbarcodewidth.TabIndex = 6;

                cmborientation.TabIndex = 7;
                txtxpos.TabIndex = 8;
                txtypos.TabIndex = 9;
                txtfontsize.TabIndex = 10;
                btncreatetemplateheader.TabIndex = 11;

                txtxpos.Text = this.X.ToString(); //new#
                txtypos.Text = this.Y.ToString();
                txtxopos.Text = this.xOriginal.ToString();
                txtyopos.Text = this.yOriginal.ToString();



            }
            

        }

        public void funData(String lstrTemplateName, String lstrTransType,String lstrwidth,String lstrheight,String lstrfieldtype)
        {
            // label1.Text = txtForm1.Text;
            //Display all fieldname for template
            //var objfieldlist = lobjTemplate.GetFieldPropertiesList(lstrTemplateName, lstrTransType);
            //foreach (clsTemplateLabelXmlwork itemfield in objfieldlist)
            //{

            //}
            this.SetTemplatewidth = lstrwidth;
            this.SetTemplateheight = lstrheight;
            this.SetFieldType = lstrfieldtype;     


        }

        public void TextFieldControlsValidate(string strfieldtype)
        {
            if (strfieldtype == "Text" || this.readfieldType=="Text")
            {
                btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtfieldname.Text) &&
                      !String.IsNullOrWhiteSpace(txttestdata.Text) &&
                      // !String.IsNullOrWhiteSpace(txtorientation.Text) &&
                      !String.IsNullOrWhiteSpace(txtxpos.Text) &&
                      !String.IsNullOrWhiteSpace(txtypos.Text) &&
                      !String.IsNullOrWhiteSpace(txtfontsize.Text) &&
                      // !String.IsNullOrWhiteSpace(txtwordwrap.Text) &&
                      //cmbdatasource.SelectedValue.ToString() != "0";
                      cmbdatasource.SelectedIndex != 0;
            }
            else
            {
                btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtfieldname.Text) &&
                     !String.IsNullOrWhiteSpace(txttestdata.Text) &&
                     !String.IsNullOrWhiteSpace(txtxpos.Text) &&
                     !String.IsNullOrWhiteSpace(txtypos.Text) &&
                     !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) &&
                     !String.IsNullOrWhiteSpace(txtbarcodeheight.Text) &&
                     cmbdatasource.SelectedIndex != 0;
            }


        }

       
        public void  BarCodeFieldControlValidate()
        {
            
            btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtfieldname.Text) &&
                !String.IsNullOrWhiteSpace(txttestdata.Text) &&
                 !String.IsNullOrWhiteSpace(txtxpos.Text) &&
                  !String.IsNullOrWhiteSpace(txtypos.Text) &&
                !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) &&
                 !String.IsNullOrWhiteSpace(txtbarcodeheight.Text) &&
                 cmbdatasource.SelectedIndex != 0;

            //btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtfieldname.Text) &&
            //       !String.IsNullOrWhiteSpace(txttestdata.Text) &&
            //       !String.IsNullOrWhiteSpace(txtxpos.Text) &&
            //       !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //       // !String.IsNullOrWhiteSpace(txtfontsize.Text) &&
            //       cmbdatasource.SelectedIndex != 0;


        }

        public List<QuickBooksField> GetFieldTypeList()
        {

            //Trans  Standard Fields
            List<QuickBooksField> objFieldTypevalues = new List<QuickBooksField>();
            //objFieldTypevalues.Add(new QuickBooksField(0, "---Select Field Type---"));
            objFieldTypevalues.Add(new QuickBooksField(1, "Text"));
            objFieldTypevalues.Add(new QuickBooksField(2, "BarCode"));
           
            return objFieldTypevalues;
        }
        public List<QuickBooksField> GetOrientationList()
        {

            //Trans  Standard Fields
            List<QuickBooksField> objorientationvalues = new List<QuickBooksField>();
            objorientationvalues.Add(new QuickBooksField(0, "0"));
            objorientationvalues.Add(new QuickBooksField(4, "90"));
            objorientationvalues.Add(new QuickBooksField(5, "180"));
            objorientationvalues.Add(new QuickBooksField(6, "270"));
            return objorientationvalues;
        }

        public List<QuickBooksField> GetBarCodeTypeList()
        {

            //Trans  Standard Fields
            List<QuickBooksField> objBarcodeTypevalues = new List<QuickBooksField>();
           // objBarcodeTypevalues.Add(new QuickBooksField(0, "---Select Field Type---"));
            objBarcodeTypevalues.Add(new QuickBooksField(1, "Code128"));
            objBarcodeTypevalues.Add(new QuickBooksField(2, "UPC-A"));
            objBarcodeTypevalues.Add(new QuickBooksField(3, "Code39"));
            //objBarcodeTypevalues.Add(new QuickBooksField(4, "DataMatrix"));
            objBarcodeTypevalues.Add(new QuickBooksField(4, "QRCode"));

            return objBarcodeTypevalues;
        }
        public List<QuickBooksField> DataMatrixWidthValuePairs1()
        {

           
            List<QuickBooksField> objDatamatrixTypevalues = new List<QuickBooksField>();
            
            objDatamatrixTypevalues.Add(new QuickBooksField(1, "18"));
            objDatamatrixTypevalues.Add(new QuickBooksField(2, "32"));
           
          

            return objDatamatrixTypevalues;
        }

        public List<QuickBooksField> DataMatrixWidthValuePairs2()
        {


            List<QuickBooksField> objDatamatrixTypevalues = new List<QuickBooksField>();

            objDatamatrixTypevalues.Add(new QuickBooksField(1, "26"));
            objDatamatrixTypevalues.Add(new QuickBooksField(2, "36"));

            return objDatamatrixTypevalues;
        }
        public List<QuickBooksField> DataMatrixWidthValuePairs3()
        {


            List<QuickBooksField> objDatamatrixTypevalues = new List<QuickBooksField>();
            
            objDatamatrixTypevalues.Add(new QuickBooksField(1, "36"));
            objDatamatrixTypevalues.Add(new QuickBooksField(2, "48"));

            return objDatamatrixTypevalues;
        }

        public List<QuickBooksField> DataMatrixWidth()
        {


            List<QuickBooksField> objDatamatrixTypevalues = new List<QuickBooksField>();

            objDatamatrixTypevalues.Add(new QuickBooksField(1, "36"));
            objDatamatrixTypevalues.Add(new QuickBooksField(2, "48"));

            return objDatamatrixTypevalues;
        }
        public List<QuickBooksField> DataMatrixHeight()
        {


            List<QuickBooksField> objDatamatrixHeightTypevalues = new List<QuickBooksField>();

            objDatamatrixHeightTypevalues.Add(new QuickBooksField(1, "10"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(2, "12"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(3, "8"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(4, "14"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(5, "8"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(6, "16"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(7, "12"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(8, "18"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(9, "20"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(10, "12"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(11, "22"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(12, "16"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(13, "24"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(14, "26"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(15, "16"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(16, "32"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(17, "36"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(18, "40"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(19, "44"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(20, "48"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(21, "52"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(22, "64"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(23, "72"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(24, "80"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(25, "88"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(26, "96"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(27, "104"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(28, "120"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(29, "132"));
            objDatamatrixHeightTypevalues.Add(new QuickBooksField(30, "144"));
            
            return objDatamatrixHeightTypevalues;
        }

        public List<QuickBooksField> bcXMultiplier()
        {
            List<QuickBooksField> objoneDXmultipliervalues = new List<QuickBooksField>();

            objoneDXmultipliervalues.Add(new QuickBooksField(1, "10"));
            objoneDXmultipliervalues.Add(new QuickBooksField(2, "15"));
            objoneDXmultipliervalues.Add(new QuickBooksField(3, "20"));
            return objoneDXmultipliervalues;
        }

        public List<QuickBooksField> DataMatrixWeight()
        {


            List<QuickBooksField> objDatamatrixWidthTypevalues = new List<QuickBooksField>();

            objDatamatrixWidthTypevalues.Add(new QuickBooksField(1, "10"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(2, "12"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(3, "18"));

            objDatamatrixWidthTypevalues.Add(new QuickBooksField(4, "14"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(5, "32"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(6, "16"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(7, "26"));

            objDatamatrixWidthTypevalues.Add(new QuickBooksField(8, "18"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(9, "20"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(10, "36"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(11, "22"));

            objDatamatrixWidthTypevalues.Add(new QuickBooksField(12, "36"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(13, "24"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(14, "26"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(15, "48"));

            objDatamatrixWidthTypevalues.Add(new QuickBooksField(16, "32"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(17, "36"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(18, "40"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(19, "44"));

            objDatamatrixWidthTypevalues.Add(new QuickBooksField(20, "48"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(21, "52"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(22, "64"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(23, "72"));

            objDatamatrixWidthTypevalues.Add(new QuickBooksField(24, "80"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(25, "88"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(26, "96"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(27, "104"));

            objDatamatrixWidthTypevalues.Add(new QuickBooksField(28, "120"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(29, "132"));
            objDatamatrixWidthTypevalues.Add(new QuickBooksField(30, "144"));
           return objDatamatrixWidthTypevalues;
        }


        private void btncreatetemplateheader_Click(object sender, EventArgs e)
        {
            //Add template field details
            string strTransTypeFilePath = string.Empty;
            string assignHeight = string.Empty;
            string assignWidth = string.Empty;
            string strimagexwidth = string.Empty;
            clsTemplateLabelXmlwork lobjTemplatexml = null;

            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            try
            {
            using (new HourGlass())
            {
                    
                        assignHeight = Convert.ToString(txtbarcodeheight.Text).Trim();
                        assignWidth = Convert.ToString(txtbarcodewidth.Text).Trim();

                    //foreach (string item in this.dsMultiDataSourceList.CheckedItems)
                    //{
                    //   // this.lstSelected.Items.Add(item.ToString());
                    //}
                   
                   
                    StringBuilder checkListvalue = new StringBuilder();
                    StringBuilder checkListtext = new StringBuilder();
                    lstrdelimeter = txtdelimeter.Text.ToString();
                    lstrqrbarcodetext = cmbbarcodetype.Text.ToString().ToLower().Trim();
                    string dscheckedvalues = string.Empty;
                    string dscheckedtext = string.Empty;
                    double lfltwarngwidth =0;
                    double lfltwarnheight =0;

                    if (!(lstrqrbarcodetext.ToLower() == "UPC-A".ToLower()) && chkMSelect.Checked)
                    {
                        if (MultiDataSourceLsit.Count > 1)
                        {
                            foreach (LabelConnector.QuickBooksField checkeditem in MultiDataSourceLsit)
                            {
                                string DataSource = "";                               
                                DataSource = Convert.ToString(checkeditem.ItemFieldValue);                                
                                checkListvalue.Append(DataSource.ToString());
                                checkListvalue.Append(lstrdelimeter);
                                checkListtext.Append(checkeditem.ItemFieldName.ToString());
                                checkListtext.Append(lstrdelimeter);


                            }
                        }
                        else
                        {
                             foreach (LabelConnector.QuickBooksField checkeditem in MultiDataSourceLsit)
                            {
                                checkListvalue.Append(checkeditem.ItemFieldValue.ToString());
                                checkListvalue.Append(lstrdelimeter);
                                checkListtext.Append(checkeditem.ItemFieldName.ToString());
                                checkListtext.Append(lstrdelimeter);


                            }

                        }
                        dscheckedvalues = checkListvalue.ToString().Remove(checkListvalue.Length - lstrdelimeter.Length, lstrdelimeter.Length);
                        dscheckedtext = checkListtext.ToString().Remove(checkListtext.Length - lstrdelimeter.Length, lstrdelimeter.Length);
                        lobjTemplatexml = new clsTemplateLabelXmlwork(this.SetValuesForTemplate, this.Id, Convert.ToString(cmbFieldType.Text), Convert.ToString(txtfieldname.Text).Trim(), dscheckedtext, dscheckedvalues, Convert.ToString(txttestdata.Text).Trim(), Convert.ToString(cmbbarcodetype.Text), string.Empty,string.Empty, Convert.ToString(cmborientation.Text).Trim(), assignWidth, assignHeight, strimagexwidth, Convert.ToString(txtxpos.Text).Trim(), Convert.ToString(txtypos.Text).Trim(), Convert.ToString(txtfontsize.Text).Trim(), lstrdelimeter, Convert.ToString(txtxopos.Text).Trim(), Convert.ToString(txtyopos.Text).Trim(), "", chkbarfountstates.Checked.ToString(),cmbDataCharView.SelectedIndex.ToString(), cmbDataCharAlign.SelectedIndex.ToString(),"","");
                        //show alert when location is less than 1/4 from edge of label
                        //if X + barcode width + 0.25 > Width of the label                       

                    }
                    else
                    {
                    
                        dscheckedvalues = Convert.ToString(cmbdatasource.SelectedValue);

                        String DataSource = "";
                        
                            DataSource = Convert.ToString(cmbdatasource.Text);
                        dscheckedtext = DataSource;
                         lstrdelimeter = "";

                        lobjTemplatexml = new clsTemplateLabelXmlwork(this.SetValuesForTemplate, this.Id, Convert.ToString(cmbFieldType.Text), Convert.ToString(txtfieldname.Text).Trim(), dscheckedtext, dscheckedvalues, Convert.ToString(txttestdata.Text).Trim(), Convert.ToString(cmbbarcodetype.Text), string.Empty, string.Empty, Convert.ToString(cmborientation.Text).Trim(), assignWidth, assignHeight, strimagexwidth, Convert.ToString(txtxpos.Text).Trim(), Convert.ToString(txtypos.Text).Trim(), Convert.ToString(txtfontsize.Text).Trim(), lstrdelimeter, Convert.ToString(txtxopos.Text).Trim(), Convert.ToString(txtyopos.Text).Trim(), "", chkbarfountstates.Checked.ToString(), cmbDataCharView.SelectedIndex.ToString(), cmbDataCharAlign.SelectedIndex.ToString(), "","");

                    }
                    if (lstrqrbarcodetext.ToLower() == "qrcode")
                    {
                        lfltwarngwidth = Convert.ToSingle(txtxpos.Text) + Convert.ToSingle(txtbarcodewidth.Text) + 0.25;
                        lfltwarnheight = Convert.ToSingle(txtypos.Text) + Convert.ToSingle(txtbarcodewidth.Text) + 0.25;
                        var obtemplateparam = lobjTemplate.GetTemplateHeaderInfo(this.SetValuesForTemplate);
                        foreach (QuickBooksField itemfield in obtemplateparam)
                        {

                            if (itemfield.ItemFieldId == 2)
                            {
                                this.SetTemplatewidth = itemfield.ItemFieldName;
                            }
                            else if (itemfield.ItemFieldId == 3)
                            {
                                this.SetTemplateheight = itemfield.ItemFieldName;
                            }
                        }


                        if ((Convert.ToSingle(txtxpos.Text) < 0.25 || Convert.ToSingle(txtypos.Text) < 0.25) || (lfltwarngwidth > Convert.ToSingle(this.SetTemplatewidth)) || (lfltwarnheight > Convert.ToSingle(this.SetTemplateheight)))
                        {
                            MessageBox.Show("You have specified a Barcode location less than 1/4 from edge of the label , the QR code will be adjusted in position to allow for space to ensure scan ability", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }

                    if (cmbbarcodetype.Visible == true)
                    {
                        if (cmbbarcodetype.Text.ToString().ToLower() == "upc-a")
                        {
                            int lntchecksumdigit;
                            //Get UPC A code length
                            //if(txttestdata.Text.ToString().Trim().Length ==11)
                            //{
                            //   if (!lobjTemplatexml.GetChecksumDigit(txttestdata.Text.Trim() ,out lntchecksumdigit))
                            //    {
                            //        MessageBox.Show("Invalid Test Data for UPC A code", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //        txttestdata.Focus();
                            //        return;

                            //    }
                            //}
                            Dictionary<string, bool> openWith = new Dictionary<string, bool>();
                            lobjTemplatexml.GetUPCDigit(lobjTemplatexml.testdata.Trim(), openWith);
                            if (!openWith["Digit"])
                            {
                                if (!lobjTemplatexml.ValidateChecksumDigit(lobjTemplatexml.testdata.Trim())) //check upa code is valid or not
                                {
                                    MessageBox.Show("Invalid Test Data for UPC A code", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // txttestdata.Text = "";
                                    txttestdata.Focus();
                                    return;

                                }
                            }
                            
                        }
                    }

                    if (lblfieldpropertytext.Text.ToString().ToLower().Trim() == "add field properties")
                {
                   if (lobjTemplatexml.fontsize == "0")
                      {
                            MessageBox.Show("Font size can not be zero", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                      }
                      if (lobjTemplatexml.AddTemplateDetails(lobjTemplatexml, lstrqrbarcodetext,string.Empty))
                    {
                       // MessageBox.Show("Template field details added sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // txtfieldname.Text = "";
                        cmbdatasource.SelectedIndex = 0;
                        txttestdata.Text = "";
                        cmbbarcodetype.SelectedIndex = 0;
                        txtbarcodeheight.Text = "";
                        txtbarcodewidth.Text = "";
                        //txtwordwrap.Text = "";
                        cmborientation.Text = "";
                        txtxpos.Text = "";
                        txtypos.Text = "";
                        txtfontsize.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Fieldname exist already", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }
                }
                else if (lblfieldpropertytext.Text.ToString().ToLower().Trim() == "edit field properties")
                {
                    if(lobjTemplatexml.fontsize== "0")
                     {
                            MessageBox.Show("Font size can not be zero", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                     }
                    if (lobjTemplatexml.UpdateTemplateDetails(lobjTemplatexml, this.Setgridfieldname, lstrqrbarcodetext,string.Empty))
                    {
                       // MessageBox.Show("Template field details updated sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //txtfieldname.Text = "";
                        cmbdatasource.SelectedIndex = 0;
                        txttestdata.Text = "";
                        cmbbarcodetype.SelectedIndex = 0;
                        txtbarcodeheight.Text = "";
                        txtbarcodewidth.Text = "";
                        //txtwordwrap.Text = "";
                        cmborientation.Text = "";
                        txtxpos.Text = "";
                        txtypos.Text = "";
                        txtfontsize.Text = "";
                        //
                    }
                    else
                    {
                        MessageBox.Show("Fieldname exist already", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }


                //if (passControl != null)
                //{
                      
                //        if(this.SetFieldName == null)
                //        {
                //            this.SetFieldName = txtfieldname.Text.ToString();
                //        }
                //    passControl(this.SetValuesForTemplate, this.SetFieldName); //txtfieldname.Text.ToString();
                //        {
                //            if (lblfieldpropertytext.Text.ToString().ToLower().Trim() == "edit field properties")
                //            {
                //                this.Close();
                //            }
                //            else
                //            {
                //                txtfieldname.Text = "";
                //            }
                       
                //    }
                //}

                //Create Template Pdf from data
                List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
               // List<string> dsdatasource = null;
                //List<string> dsdatasourcetext = null;
                List<QuickBooksField> objheaderfield = new List<QuickBooksField>();
                objfieldlist = lobjTemplatexml.GetFieldPropertiesList(this.SetValuesForTemplate, string.Empty);
                  //if(lstrqrbarcodetext == "qrcode")
                  // {
                  //      //store datasource and datasourcetext in  datadictionary
                  //      foreach (clsTemplateLabelXmlwork item in objfieldlist)
                  //      {
                  //          dsdatasource = new List<string>();
                  //          dsdatasourcetext = new List<string>();
                  //          //char[] charArr = lstrdelimeter.ToCharArray();
                  //          char charArr = lstrdelimeter.ToCharArray()[0];
                  //          dsdatasource = item.datasource.Split(charArr).ToList();
                  //          dsdatasourcetext = item.datasourcetext.Split(charArr).ToList();


                  //      }
                  //  }
                        //Get property fields list
                        List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();
                    //strTransTypeFilePath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + this.SetValuesForTransType + ".xml";

                System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
                  if(dirtransxml.Exists)
                   {
                        strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + this.SetValuesForTransType + ".xml");
                   }
                   else
                  {
                        strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + this.SetValuesForTransType + ".xml");
                  }
                if (File.Exists(strTransTypeFilePath))
                {
                    Itemfieldlist = lobjTemplate.GetItemFieldListfromxml(strTransTypeFilePath); //Get field list
                }


                objheaderfield = lobjTemplate.GetTemplateHeaderInfo(this.SetValuesForTemplate);
                foreach (QuickBooksField itemfield in objheaderfield)
                {
                    if (itemfield.ItemFieldId == 1)
                    {
                        this.SetValuesForTransType = itemfield.ItemFieldName;
                    }
                    else if (itemfield.ItemFieldId == 2)
                    {
                        this.SetTemplatewidth = itemfield.ItemFieldName;
                    }
                    else if (itemfield.ItemFieldId == 3)
                    {
                        this.SetTemplateheight = itemfield.ItemFieldName;
                    }
                }
                //string lstrerror;
                lobjTemplate.CreateUpdateTemplatePDF(this.SetValuesForTemplate, this.SetTemplatewidth, this.SetTemplateheight, lobjTemplatexml.fieldtype, this.SetValuesForTransType, objfieldlist, Itemfieldlist);

                    if (lobjTemplatexml.fieldtype.ToLower().Trim() == "barcode")
                    {
                        objfieldlist = lobjTemplatexml.GetFieldPropertiesList(this.SetValuesForTemplate, string.Empty);
                        clsTemplateLabelXmlwork objTemp = objfieldlist.Where(i => i.fieldname == lobjTemplatexml.fieldname).FirstOrDefault();
                        string imgpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TempImage" + "\\" + this.SetValuesForTemplate + "\\" + "BarCode" + "\\" + lobjTemplatexml.barcodetype + "\\" + lobjTemplatexml.fieldname + ".Tiff");
                        //System.Drawing.Image original = System.Drawing.Image.FromFile(imgpath);
                        //TypeConverter converter = TypeDescriptor.GetConverter(typeof(System.Drawing.Image));

                        //String TheImageAsString = Convert.ToBase64String((Byte[])converter.ConvertTo(original, typeof(Byte[])));
                        //dd.barcodestring = TheImageAsString;

                        using (var FileStream = new System.IO.FileStream(imgpath, System.IO.FileMode.Open))
                        {
                            var original = System.Drawing.Image.FromStream(FileStream);
                            TypeConverter converter = TypeDescriptor.GetConverter(typeof(System.Drawing.Image));

                            String TheImageAsString = Convert.ToBase64String((Byte[])converter.ConvertTo(original, typeof(Byte[])));
                            objTemp.barcodestring = TheImageAsString;
                        }

                    lobjTemplatexml.UpdateTemplateDetails(objTemp, objTemp.fieldname, objTemp.barcodetype, this.SetValuesForTransType.ToLower().Trim());
                        var dirpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TempImage");
                        if (Directory.Exists(dirpath))
                        {
                            Directory.Delete(dirpath, true);
                        }
                       
                    }

                    if (passControl != null)
                    {

                        if (this.SetFieldName == null)
                        {
                            this.SetFieldName = txtfieldname.Text.ToString();
                        }
                        passControl(this.SetValuesForTemplate, this.SetFieldName); //txtfieldname.Text.ToString();
                        {
                           

                                this.Close();
                            
                        }
                    }


                } //end of hourglass
        }
        catch(Exception ex)
        {
        }
            //if (!String.IsNullOrWhiteSpace(lstrerror))
            //{
            //    MessageBox.Show("Invalid Test Data for UPC A code", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //comment start
            ////convert pdf to image
            //string imgpath = System.Windows.Forms.Application.StartupPath + @"\" + "PdfImagesList" + "\\" + this.SetValuesForTemplate + "\\" + this.SetValuesForTemplate + ".Jpeg";

            //if (File.Exists(imgpath))
            //{
            //    System.GC.Collect();
            //    System.GC.WaitForPendingFinalizers();
            //    File.Delete(imgpath);
            //}

            //CreateTemplatePDF(this.SetValuesForTemplate,this.SetTemplatewidth, this.SetTemplateheight, this.SetValuesForTransType,objfieldlist);

            //// Create a reference to a directory.
            //DirectoryInfo di = new DirectoryInfo("PdfImagesList");

            //// Create the directory only if it does not already exist.
            //if (di.Exists == false)
            //    di.Create();

            //// Create a subdirectory in the directory just created.
            //DirectoryInfo dis = di.CreateSubdirectory(this.SetValuesForTemplate);


            //string  Filepath = System.Windows.Forms.Application.StartupPath + @"\" + "ZPLFormat" + "\\" + this.SetValuesForTemplate + ".pdf";
            //if (!string.IsNullOrWhiteSpace(Filepath))
            //{

            //    //image with full size
            //    var pdfToImage = new PdfToImageConverter();

            //    var thumbImg = pdfToImage.GenerateImage(Filepath, 1);

            //    var thumbImgH600 = ResizeImage(thumbImg, thumbImg.Width, thumbImg.Height);

            //    System.Threading.Thread.Sleep(3000);
            //   thumbImgH600.Save(System.Windows.Forms.Application.StartupPath + @"\" + "PdfImagesList" + "\\" + this.SetValuesForTemplate + "\\" + this.SetValuesForTemplate +  ".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            //    thumbImg.Dispose();
            //    thumbImgH600.Dispose();

            //}
            //comment end


        }

        public static System.Drawing.Image ResizeImage(System.Drawing.Image img, int maxWidth, int maxHeight)
        {
            if (img.Size.Width == 0 || img.Size.Height == 0)
                return img;

            var sizeIsWidthOk = (maxWidth <= 0 || img.Size.Width <= maxWidth);
            var sizeIsHeightOk = (maxHeight <= 0 || img.Size.Height <= maxHeight);
            var sizeIsOk = sizeIsWidthOk && sizeIsHeightOk;

            if (sizeIsOk)
                return img;

            var newWidth = img.Size.Width;
            var newHeight = img.Size.Height;
            if (!sizeIsWidthOk)
            {
                newWidth = maxWidth;
                newHeight = (int)Math.Floor(((double)img.Size.Height) * (((double)maxWidth) / ((double)img.Size.Width)));
                if (maxHeight < 0 || newHeight <= maxHeight)
                    sizeIsHeightOk = true;
            }
            if (!sizeIsHeightOk)
            {
                newHeight = maxHeight;
                newWidth = (int)Math.Floor(((double)img.Size.Width) * (((double)maxHeight) / ((double)img.Size.Height)));
            }

            var resizedBitmap = new Bitmap(newWidth, newHeight);
            var resizedRect = new System.Drawing.Rectangle(0, 0, newWidth, newHeight);

            using (var graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(img, resizedRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return resizedBitmap;
        }
       
        public string CreateTemplatePDF(string Templatename, string templateheaderwidth, string templateheaderheight, string TransType, List<clsTemplateLabelXmlwork> objfieldlist)
        {

            float fltWidth = '0';
            float fltHeight = '0';
            float constval = (float)0.014;
            float divX;
            float divY;
            float fontSize;
            float? ImageHeight;
            float? ImageWidth;
            string path = string.Empty;
            string strfilename = string.Empty;
            string wraptext = string.Empty;
            double Num;
            string datasourcevalue = string.Empty;
            bool isNum;


            path = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat" + "\\" + Templatename + ".pdf");


            if (!Directory.Exists(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat")))
                Directory.CreateDirectory(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat"));

            fltWidth = Convert.ToSingle(templateheaderwidth) * 96;

            fltHeight = Convert.ToSingle(templateheaderheight) * 96;


            var doc = new Document(new iTextSharp.text.Rectangle(fltWidth, fltHeight), 0f, 0f, 0f, 0f);


            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

            doc.Open();

            PdfContentByte cb = writer.DirectContent;


            //****Start **** code for border
            var pageBorderRect = new iTextSharp.text.Rectangle(doc.PageSize);

            pageBorderRect.Left += doc.LeftMargin;
            pageBorderRect.Right -= doc.RightMargin;
            pageBorderRect.Top -= doc.TopMargin;
            pageBorderRect.Bottom += doc.BottomMargin;

                     
            //****Start **** code for Barcode

            //Loop through Template Field Names

            foreach (clsTemplateLabelXmlwork DetailItem in objfieldlist)
            {

                divX = (Convert.ToSingle(DetailItem.xposition) / constval);
                divY = (Convert.ToSingle(DetailItem.yposition) / constval);
                fontSize = Convert.ToSingle(DetailItem.fontsize);
                ImageHeight = ((Convert.ToSingle(DetailItem.imgheight) / constval)); 
                ImageWidth = ((Convert.ToSingle(DetailItem.imgwidth) / constval)); 


                if (DetailItem.fieldtype.ToLower().Trim() == "barcode")
                {

                    if (DetailItem.barcodetype.ToString().ToLower() == "code128" || DetailItem.barcodetype.ToString().ToLower() == "code39") //BarcodeType Added upc-A,code 39
                    {
                        iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                        //Generate UPC-A barcode

                        bc.TextAlignment = Element.ALIGN_CENTER;
                        bc.Size =fontSize;
                        bc.Font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                        for (int i = 0; i < cmbdatasource.Items.Count; i++)
                        {
                            datasourcevalue = cmbdatasource.GetItemText(((LabelConnector.QuickBooksField)(cmbdatasource.Items[i])).ItemFieldName.ToLower().Trim());


                            if (DetailItem.datasource.ToLower().Trim() == datasourcevalue)
                            {
                                if (datasourcevalue == "sales price")
                                {
                                    isNum = double.TryParse(DetailItem.testdata.Trim(), out Num);
                                    if (isNum)
                                    {
                                        bc.Code = Convert.ToDouble(DetailItem.testdata).ToString("N2");
                                    }
                                    else
                                    {
                                        bc.Code = DetailItem.testdata;
                                    }
                                }
                                else if (datasourcevalue == "purchase information" || datasourcevalue == "item description")
                                {
                                    wraptext = WordWrap(DetailItem.testdata, Convert.ToInt32(DetailItem.wordwrap));

                                    Phrase p = new Phrase(wraptext, FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1252, true, fontSize));
                                    ColumnText ct = new ColumnText(cb);
                                    ct.SetSimpleColumn(p, divX, divY, fltWidth, Convert.ToSingle(templateheaderwidth), 10, Element.ALIGN_LEFT);
                                    ct.Go();

                                }
                                else
                                {
                                    bc.Code = DetailItem.testdata;
                                }
                            }

                        }
                            bc.StartStopText = false;

                            bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                            bc.Extended = true;
                            iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
                            iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);


                            img.ScaleAbsolute((float)ImageWidth, (float)ImageHeight);
                            img.SetAbsolutePosition(divX, divY);
                            // img.RotationDegrees = 360;
                            img.RotationDegrees = DetailItem.orientation !="" ? Convert.ToSingle(DetailItem.orientation): 0; //rotate barcode image by degree
                            cb.AddImage(img);
                       // }

                    } //code 128 end
                      //upc-a
                    else if (DetailItem.barcodetype.ToString().ToLower() == "upc-a") //BarcodeType Added upc-A
                    {
                        //Generate UPC-A barcode
                        BarcodeEAN bc = new BarcodeEAN();


                        bc.TextAlignment = Element.ALIGN_CENTER;
                        bc.Size = fontSize;
                        bc.Font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                        for (int i = 0; i < cmbdatasource.Items.Count; i++)
                        {
                            datasourcevalue = cmbdatasource.GetItemText(((LabelConnector.QuickBooksField)(cmbdatasource.Items[i])).ItemFieldName.ToLower().Trim());


                            if (DetailItem.datasource.ToLower().Trim() == datasourcevalue)
                            {


                                if (datasourcevalue == "sales price")
                                {
                                    isNum = double.TryParse(DetailItem.testdata.Trim(), out Num);
                                    if (isNum)
                                    {
                                        bc.Code = Convert.ToDouble(DetailItem.testdata).ToString("N2");
                                    }
                                    else
                                    {
                                        bc.Code = DetailItem.testdata;
                                    }
                                }
                                else
                                {
                                    bc.Code = DetailItem.testdata;//"Item Name" 
                                }

                            }
                        }
                                    bc.StartStopText = false;

                                    bc.CodeType = Barcode.UPCA;
                                    bc.Extended = true;

                                    iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb,
                                    iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);


                                    img.ScaleAbsolute((float)ImageWidth, (float)ImageHeight);
                                    img.SetAbsolutePosition(divX, divY);
                                    // img.RotationDegrees = 360;
                                    img.RotationDegrees = DetailItem.orientation != "" ? Convert.ToSingle(DetailItem.orientation) : 0; //rotate barcode image by degree
                                    cb.AddImage(img);


                                
                        //}
                    }//end upc-a
                 
                }
                else //Field Type is Text Field
                {
                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb.SetFontAndSize(bf, fontSize);
                    cb.BeginText();


                    cb.SetTextMatrix(divX, divY);
                    for (int i = 0; i < cmbdatasource.Items.Count; i++)
                    {
                        datasourcevalue = cmbdatasource.GetItemText(((LabelConnector.QuickBooksField)(cmbdatasource.Items[i])).ItemFieldName.ToLower().Trim());
                        

                        if (DetailItem.datasource.ToLower().Trim() == datasourcevalue)
                        {
                            if (datasourcevalue == "sales price")
                            {
                                isNum = double.TryParse(DetailItem.testdata.Trim(), out Num);
                                if (isNum)
                                {
                                    cb.ShowTextAligned(Element.ALIGN_LEFT, Convert.ToDouble(DetailItem.testdata).ToString("N2"), divX, divY, DetailItem.orientation != "0" ? Convert.ToSingle(DetailItem.orientation) : 0);
                                }
                                else
                                {
                                    cb.ShowTextAligned(Element.ALIGN_LEFT, DetailItem.testdata, divX, divY, DetailItem.orientation != "" ? Convert.ToSingle(DetailItem.orientation) : 0);
                                }
                            }
                            else if (datasourcevalue == "purchase information" || datasourcevalue == "item description")
                            {
                                wraptext = WordWrap(DetailItem.testdata, Convert.ToInt32(DetailItem.wordwrap));

                                Phrase p = new Phrase(wraptext, FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1252, true, fontSize));
                                ColumnText ct = new ColumnText(cb);
                                ct.SetSimpleColumn(p, divX, divY, fltWidth, Convert.ToSingle(templateheaderwidth), 10, Element.ALIGN_LEFT);
                                ct.Go();

                            }
                            else
                            {
                                cb.ShowTextAligned(Element.ALIGN_LEFT, DetailItem.testdata, divX, divY, DetailItem.orientation != "" ? Convert.ToSingle(DetailItem.orientation) : 0);//rotate text by degree
                            }
                        }
                    }
                    
                    cb.EndText();

                }//end text type

            }



            doc.Close();


            return strfilename;


        }

        public static string WordWrap(string text, int width)
        {
            int pos, next;
            StringBuilder sb = new StringBuilder();

            // Lucidity check
            if (width < 1)
                return text;

            // Parse each line of text
            for (pos = 0; pos < text.Length; pos = next)
            {
                // Find end of line
                int eol = text.IndexOf(Environment.NewLine, pos);
                if (eol == -1)
                    next = eol = text.Length;
                else
                    next = eol + Environment.NewLine.Length;

                // Copy this line of text, breaking into smaller lines as needed
                if (eol > pos)
                {
                    do
                    {
                        int len = eol - pos;
                        if (len > width)
                            len = BreakLine(text, pos, width);
                        sb.Append(text, pos, len);
                        sb.Append(Environment.NewLine);

                        // Trim whitespace following break
                        pos += len;
                        while (pos < eol && Char.IsWhiteSpace(text[pos]))
                            pos++;
                    } while (eol > pos);
                }
                else sb.Append(Environment.NewLine); // Empty line
            }
            return sb.ToString();
        }
        private static int BreakLine(string text, int pos, int max)
        {
            // Find last whitespace in line
            int i = max;
            while (i >= 0 && !Char.IsWhiteSpace(text[pos + i]))
                i--;

            // If no whitespace found, break at maximum length
            if (i < 0)
                return max;

            // Find start of whitespace
            while (i >= 0 && Char.IsWhiteSpace(text[pos + i]))
                i--;

            // Return length of text before whitespace
            return i + 1;
        }
        private void ClearFields()
        {
            txtfieldname.Text = "";
            cmbdatasource.Text = "---Select field---";
            txtbarcodeheight.Text = "";
            txtbarcodewidth.Text = "";
            txtfontsize.Text = "";
            txttestdata.Text = "";
            //txtwordwrap.Text = "";
            cmborientation.Text = "";
            txtxpos.Text = "";
            txtypos.Text = "";
            cmbbarcodetype.Text = "Code128";
        }

        private void cmbFieldType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFieldType.Text=="Text")
            {
                ClearFields();
                //pnlwraptext.Visible = true;
               // pnllowerctrl.Location = new Point(14,113);
               // pnlwraptext.Location = new Point(14, 83);
               // pnlfieldlist2.Visible = false;
                // pnldatamatrix.Visible = false;
               // cmb1D.Visible = false;
                
               
            }
            else if(cmbFieldType.Text=="BarCode")
            {
                ClearFields();
               // pnlfieldlist2.Visible = true;
               // pnllowerctrl.Location = new Point(14, 167);//195
               // pnlwraptext.Visible = false;
                //pnldatamatrix.Visible = true;
               // cmb1D.Visible = true;

            }
           
              //  pnldatamatrix.Visible = false;
             //  txtimagewidth.Enabled = false;
            //  lblimgwid.Enabled = false;

        }

        private void btntemplateheadercancel_Click(object sender, EventArgs e)
        {
             this.Close();
            if (passControl != null)
            {
                passControl(this.SetValuesForTemplate, txtfieldname.Text.ToString());
                {
                    this.Close();
                }
            }

        }

        private void txtfieldname_TextChanged(object sender, EventArgs e)
        {
            checknull();
            // TextFieldControlsValidate();
            ////if (cmbbarcodetype.Text.ToString().ToLower().Trim() != "qrcode")
            ////{
            ////    TextFieldControlsValidate(this.SetFieldType);
            ////}
            ////else
            ////{
            ////    if (txtdelimeter.Enabled == true)
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////   !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;
            ////    }
            ////    else
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////        !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;

            ////    }

            ////}
        }

        private void txttestdata_TextChanged(object sender, EventArgs e)
        {
            checknull();


            //////// TextFieldControlsValidate();
            //////if (cmbbarcodetype.Text.ToString().ToLower().Trim() != "qrcode")
            //////{
            //////    TextFieldControlsValidate(this.SetFieldType);
            //////}
            //////else
            //////{
            //////    // btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //////    //!String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && cmbdatasource.SelectedIndex != 0;
            //////    if (txtdelimeter.Enabled == true)
            //////    {
            //////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //////   !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;
            //////    }
            //////    else
            //////    {
            //////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //////  !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;

            //////    }

            ////// }
        }

        private void txtwordwrap_TextChanged(object sender, EventArgs e)
        {
            //TextFieldControlsValidate(this.SetFieldType);
        }

        private void txtorientation_TextChanged(object sender, EventArgs e)
        {
            TextFieldControlsValidate(this.SetFieldType);
        }

        private void txtxpos_TextChanged(object sender, EventArgs e)
        {
            checknull();
            ////if (cmbbarcodetype.Text.ToString().ToLower().Trim() != "qrcode")
            ////{
            ////    TextFieldControlsValidate(this.SetFieldType);
            ////}
            ////else
            ////{

            ////    //btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////    //  !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && cmbdatasource.SelectedIndex != 0;
            ////    if (txtdelimeter.Enabled==true)
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////      !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;
            ////    }
            ////    else
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////       !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text)  && dsMultiDataSourceList.CheckedItems.Count != 0;

            ////    }

            ////}
        }

        private void txtypos_TextChanged(object sender, EventArgs e)
        {
            checknull();
            ////if (cmbbarcodetype.Text.ToString().ToLower().Trim() != "qrcode")
            ////{
            ////    TextFieldControlsValidate(this.SetFieldType);
            ////}
            ////else
            ////{
            ////    //btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////    //!String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && cmbdatasource.SelectedIndex != 0;
            ////    if (txtdelimeter.Enabled == true)
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////      !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;
            ////    }
            ////    else
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////     !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;

            ////    }

            ////}
        }

        private void txtfontsize_TextChanged(object sender, EventArgs e)
        {
            //22-APR-2019
          
           //TextFieldControlsValidate(this.SetFieldType);
            
        }

        private void cmbdatasource_SelectedIndexChanged(object sender, EventArgs e)
        {
            checknull();
            //if (cmbbarcodetype.Text.ToString().ToLower().Trim() != "qrcode")
            //{
            //    TextFieldControlsValidate(this.SetFieldType);
            //}
            //else
            //{
            //   // btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //   //!String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text)  && cmbdatasource.SelectedIndex != 0;

            //}
        }

        private void txtbarcodeheight_TextChanged(object sender, EventArgs e)
        {
            checknull();
            //if (cmbbarcodetype.Text.ToString().ToLower().Trim() != "qrcode")
            //{

            //    BarCodeFieldControlValidate();
            //}
            //else
            //{
            //    btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //  !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;

            //}

        }

        private void txtbarcodewidth_TextChanged(object sender, EventArgs e)
     {
            checknull();
            ////BarCodeFieldControlValidate();
            //if (cmbbarcodetype.Text.ToString().ToLower().Trim() != "qrcode")
            //{

            //    BarCodeFieldControlValidate();
            //}
            //else
            //{
            //    // btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //    //!String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && cmbdatasource.SelectedIndex != 0;
            //    if (txtdelimeter.Enabled == true)
            //    {
            //        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //       !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;
            //    }
            //    else
            //    {
            //        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //       !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text)  && dsMultiDataSourceList.CheckedItems.Count != 0;

            //    }

            //}
        }

        private void txtbarcodeheight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtbarcodewidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtxpos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtypos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtwordwrap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtorientation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

           
        }

        private void txtfontsize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
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

        private void FrmAddEditField_FormClosed(object sender, FormClosedEventArgs e)
        {
           

        }

        private void cmbbarcodetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //QRCode
            if (cmbbarcodetype.Text.ToString() == "QRCode")
            {
                lblbcwidth.Visible = true;
                lbDimension.Visible = false;
                chkbarfountstates.Enabled = false;
                txtfontsize.Enabled = false;
                cmbDataCharView.Enabled = false;
                cmbDataCharAlign.Enabled = false;
                lblDataCharAlign.Enabled = false;
                lblDataCharView.Enabled = false;
                lblfontsize.Enabled = false;
                txtdelimeter.Enabled = true;
                txtdelimeter.Text = "\"";

            }
            else
            {
                lbDimension.Visible = true;
                lblbcwidth.Visible = false;
                txtfontsize.Enabled = true;
                chkbarfountstates.Enabled = true;
                cmbDataCharView.Enabled = true;
                cmbDataCharAlign.Enabled = true;
                lblDataCharAlign.Enabled = true;
                lblDataCharView.Enabled = true;
                lblfontsize.Enabled = true;
                txtdelimeter.Enabled = false;
                txtdelimeter.Text = "";
            }
            

                //if(cmbbarcodetype.Text.ToString().ToLower().Trim()=="datamatrix")  //#1
                //{
                //    txtfontsize.Enabled = false;
                //     txtbarcodewidth.Enabled = false;
                //     txtbarcodeheight.Enabled = false;
                //    lblbcheight.Enabled = false;
                //    lblbcwidth.Enabled = false;

                //    txtimagewidth.Enabled = true;
                //    lblimgwid.Enabled = true;


                //    cmbdatamatrixheight.DataSource = DataMatrixHeight();
                //    cmbdatamatrixheight.DisplayMember = "ItemFieldName";
                //    cmbdatamatrixheight.ValueMember = "ItemFieldId";

                //    cmbdatamatrixwidth.DataSource = DataMatrixWeight();
                //    cmbdatamatrixwidth.DisplayMember = "ItemFieldName";
                //    cmbdatamatrixwidth.ValueMember = "ItemFieldId";



                //    cmbdatamatrixheight.SelectedIndex = 0;
                //    cmbdatamatrixwidth.SelectedIndex = 0;



                //}
                //else
                //{
                if (cmbbarcodetype.Text.ToString().ToLower().Trim() == "qrcode")
            {
                txtbarcodewidth.Enabled = true;
                txtbarcodeheight.Enabled = false;
                lblbcheight.Enabled = false;
                txtfontsize.Enabled = false;
                lblfontsize.Enabled = false;
                //dsMultiDataSourceList.Visible = true;
               // lblDatasource.Visible = false;
                cmbdatasource.Enabled = false;
                lbldelimeter.Visible = true;
                txtdelimeter.Visible = true;
                //set TabIndex
                txtfieldname.TabIndex = 1;
                cmbbarcodetype.TabIndex = 2;

                txttestdata.TabIndex = 3;
                //dsMultiDataSourceList.TabIndex = 4;
                txtdelimeter.TabIndex = 5;

                txtbarcodeheight.TabIndex = 6;
                txtbarcodewidth.TabIndex = 7;

                cmborientation.TabIndex = 8;
                txtxpos.TabIndex = 9;
                txtypos.TabIndex = 10;
               
                btncreatetemplateheader.TabIndex = 11;
                //commond by tamil - adding multi data source
                //pnlotherctrls.Location = new Point(12, 211);
                

            }
            else if (cmbbarcodetype.Text.ToString().ToLower().Trim() == "code128" || cmbbarcodetype.Text.ToString().ToLower().Trim() == "code39" || cmbbarcodetype.Text.ToString().ToLower().Trim() == "upc-a")
            {
                if (lstrqrbarcodetext != "qrcode")
                {
                    txtfontsize.Enabled = true;
                    // cmb1D.Visible = true;
                    txtbarcodewidth.Enabled = true;
                    txtbarcodeheight.Enabled = true;
                    //dsMultiDataSourceList.Visible = false;
                    // lblDatasource.Visible = true;
                    cmbdatasource.Enabled = true;
                    // pnldatamatrix.Visible = false;
                    // txtimagewidth.Enabled = false;
                    //  lblimgwid.Enabled = false;
                    //  txtimagewidth.Text = "";
                    //lbldelimeter.Visible = false;
                    //txtdelimeter.Visible = false;
                    lblbcheight.Enabled = true;
                    lbDimension.Enabled = true;
                    lblfontsize.Enabled = true;

                    txtfieldname.TabIndex = 0;
                    cmbbarcodetype.TabIndex = 1;

                    txttestdata.TabIndex = 2;
                    cmbdatasource.TabIndex = 3;
                    btnMultiSelect.TabIndex = 3;
                    txtdelimeter.TabIndex = 4;
                    txtbarcodeheight.TabIndex = 5;
                    txtbarcodewidth.TabIndex = 6;

                    cmborientation.TabIndex = 7;
                    txtxpos.TabIndex = 8;
                    txtypos.TabIndex = 9;
                    txtfontsize.TabIndex = 10;
                    btncreatetemplateheader.TabIndex = 11;
                    //commond by tamil - adding multi data source
                    //pnlotherctrls.Location = new Point(14, 109);
                }
            }
            
            if (cmbbarcodetype.Text.ToString() == "UPC-A")
            {
                btnMultiSelect.Enabled = false;
                chkMSelect.Enabled = false;
                chkMSelect.Checked = false;
                //cmbdatasource.Visible = true;
                cmbdatasource.Enabled = true;
                txtdelimeter.Enabled = false;
                txtdelimeter.Text = "";
            }
            else
            {
                btnMultiSelect.Visible = true;       
                chkMSelect.Enabled = true;
                if(chkMSelect.Checked)
                {
                    btnMultiSelect.Enabled = true;
                    txtdelimeter.Enabled = true;
                    cmbdatasource.Enabled = false;
                }else
                {
                    btnMultiSelect.Enabled = false;
                    txtdelimeter.Enabled = false;
                    cmbdatasource.Enabled = true;
                }
                //cmbdatasource.Visible = false;
                txtdelimeter.Text = "\"";
            }
            checknull();
            ////if (cmbbarcodetype.Text.ToString().ToLower().Trim() != "qrcode")
            ////{
            ////    TextFieldControlsValidate(this.SetFieldType);
            ////}
            ////else
            ////{
            ////    //btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////    //!String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && cmbdatasource.SelectedIndex != 0;
            ////    if (txtdelimeter.Enabled == true)
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////      !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtxopos.Text) && !String.IsNullOrWhiteSpace(txtyopos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;
            ////    }
            ////    else
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////     !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtxopos.Text) && !String.IsNullOrWhiteSpace(txtyopos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;

            ////    }

            ////}



            //}
        }

        private void txtimagewidth_TextChanged(object sender, EventArgs e)
        {
            //btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            // !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtbarcodeheight.Text) && cmbdatasource.SelectedIndex != 0;

        }

        //private void cmbdatamatrixheight_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    cmbdatamatrixwidth.Enabled = true;
        //    if (cmbdatamatrixheight.Text=="8")
        //    {

        //        cmbdatamatrixwidth.DataSource = DataMatrixWidthValuePairs1();
        //        cmbdatamatrixwidth.DisplayMember = "ItemFieldName";
        //        cmbdatamatrixwidth.ValueMember = "ItemFieldId";

        //    }
        //   else if(cmbdatamatrixheight.Text=="12")
        //    {
        //        cmbdatamatrixwidth.DataSource = DataMatrixWidthValuePairs2();
        //        cmbdatamatrixwidth.DisplayMember = "ItemFieldName";
        //        cmbdatamatrixwidth.ValueMember = "ItemFieldId";

        //    }
        //   else if(cmbdatamatrixheight.Text == "16")
        //    {
        //        cmbdatamatrixwidth.DataSource = DataMatrixWidthValuePairs3();
        //        cmbdatamatrixwidth.DisplayMember = "ItemFieldName";
        //        cmbdatamatrixwidth.ValueMember = "ItemFieldId";
        //    }
        //   else
        //    {
        //        cmbdatamatrixwidth.DataSource = DataMatrixWeight();
        //        cmbdatamatrixwidth.DisplayMember = "ItemFieldName";
        //        cmbdatamatrixwidth.ValueMember = "ItemFieldId";

        //        // cmbdatamatrixwidth.SelectedIndex = cmbdatamatrixheight.Items.IndexOf(cmbdatamatrixheight.Text);
        //         int index = cmbdatamatrixheight.FindString(cmbdatamatrixheight.Text);
        //         cmbdatamatrixwidth.SelectedIndex = index;
        //        cmbdatamatrixwidth.Enabled = false;
        //    }

        //}

        private void txtimagewidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
       
        private void dsMultiDataSourceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bool isiSelectedIndex = false;
            //if (dsMultiDataSourceList.CheckedItems.Count != 0)
            //{
            //    isiSelectedIndex = true;
               
            //}
            //btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //     !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && isiSelectedIndex;

            
        }

        private void txtdelimeter_TextChanged(object sender, EventArgs e)
        {
            checknull();
            //btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //     !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;

        }

        private void dsMultiDataSourceList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<string> checkedItemslist = new List<string>();
            foreach (var item in dsMultiDataSourceList.CheckedItems)
                checkedItemslist.Add(item.ToString());

            if (e.NewValue == CheckState.Checked)
                checkedItemslist.Add(dsMultiDataSourceList.Items[e.Index].ToString());
            else
                checkedItemslist.Remove(dsMultiDataSourceList.Items[e.Index].ToString());

            // MessageBox.Show(checkedItemslist.Count.ToString());
            if (checkedItemslist.Count > 1)
            {
                txtdelimeter.Enabled = true;
                btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
             !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text);
             }
            else
            {
                txtdelimeter.Enabled = false;
                btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
                          !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && checkedItemslist.Count != 0;

            }

            // else if (checkedItemslist.Count == 1)
            // {
            //     txtdelimeter.Enabled = false;
            //     btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //!String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text);

            // }
            // else {

            //     btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            //               !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && checkedItemslist.Count !=0;

            // }



        }

        private void txtxopos_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(txtxopos.Text.Trim()) != "")
            {
                var widthmeasure = (Convert.ToInt32(txtxopos.Text) / 2);
                var wd = 0.010416f * widthmeasure;
                txtxpos.Text = Math.Round(wd, 2).ToString();
            }
            else
            {
                txtxpos.Text = "";
            }
            checknull();
            ////if (cmbbarcodetype.Text.ToString().ToLower().Trim() != "qrcode")
            ////{
            ////    TextFieldControlsValidate(this.SetFieldType);
            ////}
            ////else
            ////{

            ////    //btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////    //  !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && cmbdatasource.SelectedIndex != 0;
            ////    if (txtdelimeter.Enabled == true)
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////      !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtxopos.Text) && !String.IsNullOrWhiteSpace(txtyopos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;
            ////    }
            ////    else
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////       !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtxopos.Text) && !String.IsNullOrWhiteSpace(txtyopos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;

            ////    }

            ////}

        }

        private void txtyopos_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(txtxopos.Text.Trim()) != "")
            {
                var heightmeasure = (Convert.ToInt32(txtdesignerheght.Text) - Convert.ToInt32(txtyopos.Text)) / 2;
                var hd = 0.010416f * heightmeasure;
                txtypos.Text = Math.Round(hd, 2).ToString();
            }
            else
            {
                txtypos.Text = "";
            }
            checknull();
            ////if (cmbbarcodetype.Text.ToString().ToLower().Trim() != "qrcode")
            ////{
            ////    TextFieldControlsValidate(this.SetFieldType);
            ////}
            ////else
            ////{
            ////    //btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////    //!String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && cmbdatasource.SelectedIndex != 0;
            ////    if (txtdelimeter.Enabled == true)
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////      !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text) && !String.IsNullOrWhiteSpace(txtxopos.Text) && !String.IsNullOrWhiteSpace(txtyopos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && !String.IsNullOrWhiteSpace(txtdelimeter.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;
            ////    }
            ////    else
            ////    {
            ////        btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtypos.Text) &&
            ////     !String.IsNullOrWhiteSpace(txttestdata.Text) && !String.IsNullOrWhiteSpace(txtxpos.Text)  && !String.IsNullOrWhiteSpace(txtxopos.Text) && !String.IsNullOrWhiteSpace(txtyopos.Text) && !String.IsNullOrWhiteSpace(txtfieldname.Text) && !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) && dsMultiDataSourceList.CheckedItems.Count != 0;

            ////    }

            ////}

        }

        private void chkbarfountstates_CheckedChanged(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.CheckBox)sender).Checked)
            {
                txtfontsize.Enabled = true;
                cmbDataCharView.Enabled = true;
                cmbDataCharAlign.Enabled = true;
                lblDataCharAlign.Enabled = true;
                lblDataCharView.Enabled = true;
                lblfontsize.Enabled = true;
            }
            else
            {
                txtfontsize.Enabled = false;
                cmbDataCharView.Enabled = false;
                cmbDataCharAlign.Enabled = false;
                lblDataCharAlign.Enabled = false;
                lblDataCharView.Enabled = false;
                lblfontsize.Enabled = false;
            }
        }

        private void btnMultiSelect_Click(object sender, EventArgs e)
        {
            
                if (System.Windows.Forms.Application.OpenForms["frmMultiselect"] == null)
                {
                    string strTransTypeFilePath = "";
                    System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
                    if (dirtransxml.Exists)
                    {
                        strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + SetValuesForTransType + ".xml");
                    }
                    else
                    {
                        strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + SetValuesForTransType + ".xml");
                    }


                if (this.SetFieldName == null)
                    {
                        LabelConnector.frmMultiselect lobjLabelConnectorSettingsBarCode = new LabelConnector.frmMultiselect(strTransTypeFilePath, MultiDataSourceLsit, SetValuesForTemplate, objStaticfieldlist);
                        lobjLabelConnectorSettingsBarCode.Text = "Multi Select - New";
                        lobjLabelConnectorSettingsBarCode.ShowInTaskbar = false;
                        lobjLabelConnectorSettingsBarCode.ShowDialog();
                        MultiDataSourceLsit = new List<QuickBooksField>();
                        MultiDataSourceLsit = lobjLabelConnectorSettingsBarCode.selectedDataSourceLsit;
                    }
                    else
                    {
                        LabelConnector.frmMultiselect lobjLabelConnectorSettingsBarCode = new LabelConnector.frmMultiselect(strTransTypeFilePath, MultiDataSourceLsit, SetValuesForTemplate, objStaticfieldlist);
                        lobjLabelConnectorSettingsBarCode.Text = "Multi Select - Edit";
                        lobjLabelConnectorSettingsBarCode.ShowInTaskbar = false;
                        lobjLabelConnectorSettingsBarCode.ShowDialog();
                        MultiDataSourceLsit = new List<QuickBooksField>();
                        MultiDataSourceLsit = lobjLabelConnectorSettingsBarCode.selectedDataSourceLsit;
                    }

                }
                checknull();
            
        }

        private void chkMSelect_CheckedChanged(object sender, EventArgs e)
        {
         
                if (chkMSelect.Checked)
                {
                    btnMultiSelect.Enabled = true;
                    txtdelimeter.Enabled = true;
                    cmbdatasource.Enabled = false;
                }
                else
                {
                    cmbdatasource.Enabled = true;
                    txtdelimeter.Enabled = false;
                    btnMultiSelect.Enabled = false;
                }
                checknull();


        }
        private void checknull()
        {
            if (txtdelimeter.Enabled == true)
            {
                if (cmbbarcodetype.Text == "QRCode")
                {
                    btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtfieldname.Text) &&
                   !String.IsNullOrWhiteSpace(txttestdata.Text) &&
                   !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) &&
                   !String.IsNullOrWhiteSpace(txtdelimeter.Text) &&
                   MultiDataSourceLsit.Count > 0;
                }
                else
                {
                   btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtfieldname.Text) &&
                   !String.IsNullOrWhiteSpace(txttestdata.Text) &&
                   !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) &&
                   !String.IsNullOrWhiteSpace(txtbarcodeheight.Text) &&
                   !String.IsNullOrWhiteSpace(txtdelimeter.Text) &&
                   MultiDataSourceLsit.Count > 0;
                }
            }
            else
            {
                if(cmbbarcodetype.Text == "QRCode")
                {
                  btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtfieldname.Text) &&
                  !String.IsNullOrWhiteSpace(txttestdata.Text) &&
                  !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) &&
                  cmbdatasource.SelectedIndex != 0;
                }
                else
                {
                    btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txtfieldname.Text) &&
                    !String.IsNullOrWhiteSpace(txttestdata.Text) &&
                    !String.IsNullOrWhiteSpace(txtbarcodewidth.Text) &&
                    !String.IsNullOrWhiteSpace(txtbarcodeheight.Text) &&
                    cmbdatasource.SelectedIndex != 0;
                }

            }
        }
    }
}
