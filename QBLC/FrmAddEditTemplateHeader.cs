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
using System.Xml;

namespace LabelConnector
{
    public partial class FrmAddEditTemplateHeader : Form
    {
        public delegate void PassHeaderControl(String pstrTemplate, String pstrtemplateheaderwidth, String pstrtemplateheaderheight, String pcmbTransType);
        // Create instance (null)
        public PassHeaderControl passheadercontrol;
        public string headertype { get; set; }

        string SetTemplateName = string.Empty;
        string SetTemplatewidth = string.Empty;
        string SetTemplateheight = string.Empty;
        string SetcmbTransType = string.Empty;
        QBConfiguration lobjQBConfiguration = new QBConfiguration();
        public FrmAddEditTemplateHeader()
        {
            InitializeComponent();
        }

        private void btncreatetemplateheader_Click(object sender, EventArgs e)
        {
            //QBConfiguration lobjQBConfiguration = new QBConfiguration();
            string strTransTypeFilePath = string.Empty;
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\" + txttemplatename.Text.ToString().Trim() + ".xml");
            try
            {
                using (new HourGlass())
                {
                    if (headertype.ToLower() == "&new")
                    {

                        clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork(txttemplatename.Text.ToString().Trim(), Convert.ToString(txttemplatename.Text).Trim(), Convert.ToString(cmbTransType.Text), Convert.ToString(txttemplateheaderwidth.Text), Convert.ToString(txttemplateheaderheight.Text));
                        if (File.Exists(strStartupPath))
                        {
                            File.Delete(strStartupPath);
                            //MessageBox.Show("Template name already exist", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //txttemplatename.Text = "";
                            //txttemplatename.Focus();
                            //return;
                        }
                        //Add/update Tempate Header info
                        if (lobjTemplatexml.AddUpdateTemplateHeader(lobjTemplatexml))
                        {
                            clsTemplateStatus template = new clsTemplateStatus();
                            template.TemplatePath = "";
                            template.TemplateSave = "1";
                            template.TemplateMode = "New";
                            template.TemplateStatus = "1";
                            template.TempTemplatePath = strStartupPath;
                            lobjTemplatexml.SaveTemplateStatus(template);
                        }
                        else
                        {
                            MessageBox.Show("Template failed to insert", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else if (headertype.ToLower().Trim() == "&edit") //edit mode save
                    {
                        clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork(cmbtemplatelist.Text.ToString(), Convert.ToString(txttemplatename.Text), Convert.ToString(cmbTransType.Text), Convert.ToString(txttemplateheaderwidth.Text), Convert.ToString(txttemplateheaderheight.Text));

                        if (File.Exists(strStartupPath))
                        {
                            if (cmbtemplatelist.Text.ToString().ToLower().Trim() != txttemplatename.Text.ToString().ToLower().Trim())
                            {
                                //File.Delete(strStartupPath);
                                //MessageBox.Show("Template name already in used", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //txttemplatename.Text = "";
                                //txttemplatename.Focus();
                                //return;
                            }
                        }
                        //update Tempate Header info
                        if (lobjTemplatexml.AddUpdateTemplateHeader(lobjTemplatexml))
                        {
                            clsTemplateStatus template = new clsTemplateStatus();
                            clsTemplateLabelXmlwork lobjTemplatexml1 = new clsTemplateLabelXmlwork();
                            template = lobjTemplatexml1.GetTemplateStatus();
                            template.TemplateSave = "1";
                            template.TempTemplatePath = strStartupPath;
                            lobjTemplatexml.SaveTemplateStatus(template);
                            //lobjQBConfiguration.SaveCustomFields(txtdpi.Text.ToString().Trim(), "dpi");
                            //lobjQBConfiguration.SaveCustomFields(txtscalex.Text.ToString().Trim(), "scaleX");
                            //lobjQBConfiguration.SaveCustomFields(txtscaley.Text.ToString().Trim(), "scaleY");

                            // MessageBox.Show("Template header updated sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Get Template name list and bind combobox
                            if (lobjTemplatexml.TemplateName.ToLower().Trim() != lobjTemplatexml.cmbTemplateName.ToLower().Trim())
                            {
                                cmbtemplatelist.DataSource = lobjTemplatexml.GetTemplateNameList();
                                cmbtemplatelist.DisplayMember = "ItemFieldName";
                                cmbtemplatelist.ValueMember = "ItemFieldId";
                            }

                        }
                        else
                        {
                            MessageBox.Show("Template failed to update", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        //cmbtemplatelist.SelectedIndex = 0;//clear rec after saving
                        cmbtemplatelist.Text = lobjTemplatexml.TemplateName;

                    }
                    ////create TemplatePdf
                    clsTemplateLabelXmlwork lobjTemplate = new clsTemplateLabelXmlwork();
                    List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();
                    //Get Template TransType:15-APR-2019
                    //var headerTransType = lobjTemplate.GetTemplateHeaderInfo(Convert.ToString(txttemplatename.Text));

                    System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));

                    //add mode
                    if (dirtransxml.Exists)
                    {

                        strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + cmbTransType.Text.ToString() + ".xml");
                    }
                    else
                    {

                        strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + cmbTransType.Text.ToString() + ".xml");

                    }
                    if (File.Exists(strTransTypeFilePath))
                    {
                        Itemfieldlist = lobjTemplate.GetItemFieldListfromxml(strTransTypeFilePath); //Get field list
                    }


                    List<clsTemplateLabelXmlwork> objtemplatedetailslist = lobjTemplate.GetFieldPropertiesList(txttemplatename.Text.ToString(), string.Empty); //Get template details record
                                                                                                                                                               //string lstrerror;
                    lobjTemplate.CreateUpdateTemplatePDF(txttemplatename.Text.ToString().Trim(), txttemplateheaderwidth.Text.ToString().Trim(), txttemplateheaderheight.Text.ToString(), string.Empty, cmbTransType.Text.ToString(), objtemplatedetailslist, Itemfieldlist);

                    clsTemplateStatus objTemplateStatus = new clsTemplateStatus();
                    objTemplateStatus = lobjTemplate.GetTemplateStatus();
                    objTemplateStatus.TemplateSave ="1";
                    objTemplateStatus.TemplatePath = objTemplateStatus.TemplatePath;
                    objTemplateStatus.TemplateMode = objTemplateStatus.TemplateMode;
                    objTemplateStatus.TemplateStatus = objTemplateStatus.TemplateStatus;
                    objTemplateStatus.TempTemplatePath = objTemplateStatus.TempTemplatePath;
                    lobjTemplate.SaveTemplateStatus(objTemplateStatus);
                    if (passheadercontrol != null)
                    {
                        passheadercontrol(txttemplatename.Text.ToString().Trim(), txttemplateheaderwidth.Text.ToString().Trim(), txttemplateheaderheight.Text.ToString(), cmbTransType.Text);
                        {
                            this.Close();
                        }
                    }
                }//hour glass end
            }//try end
            catch (Exception ex)
            {

            }
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
        public string CreateTemplatePDF(string Templatename, string templateheaderwidth, string templateheaderheight, string TransType, List<clsTemplateLabelXmlwork> objtemplatedetailslist, List<QuickBooksField> objdatasource)
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

            foreach (clsTemplateLabelXmlwork DetailItem in objtemplatedetailslist)
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
                        bc.Size = 10f;
                        bc.Font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                        for (int i = 0; i < objdatasource.Count; i++)
                        {
                            datasourcevalue = objdatasource[i].ItemFieldName.ToLower().Trim();


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
                        img.RotationDegrees = DetailItem.orientation != "" ? Convert.ToSingle(DetailItem.orientation) : 0; //rotate barcode image by degree
                        cb.AddImage(img);
                        // }

                    } //code 128 end
                      //upc-a
                    else if (DetailItem.barcodetype.ToString().ToLower() == "upc-a") //BarcodeType Added upc-A
                    {
                        //Generate UPC-A barcode
                        BarcodeEAN bc = new BarcodeEAN();


                        bc.TextAlignment = Element.ALIGN_CENTER;
                        bc.Size = 10f;
                        bc.Font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                        for (int i = 0; i < objdatasource.Count; i++)
                        {
                            datasourcevalue = objdatasource[i].ItemFieldName.ToLower().Trim();


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
                    for (int i = 0; i < objdatasource.Count; i++)
                    {
                        datasourcevalue = objdatasource[i].ItemFieldName.ToLower().Trim();


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

            if (objtemplatedetailslist.Count == 0)
            {
                cb.BeginText();
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bf, 9);
                cb.ShowText(string.Empty);
                cb.EndText();
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

        public void funheaderData(String lstrPopupType)
        {

            headertype = lstrPopupType;

        }


        public void funheaderEditData(String lstrPopupType, String lstrTemplateName, String TransType, String lstrTemplateWidth, String lstrTemplateHeight)
        {


            headertype = lstrPopupType;
            this.SetTemplateName = lstrTemplateName;
            this.SetTemplatewidth = lstrTemplateWidth;
            this.SetTemplateheight = lstrTemplateHeight;
            this.SetcmbTransType = TransType;
            pnlselecttemplate.Visible = true;

        }

        private void FrmAddEditTemplateHeader_Load(object sender, EventArgs e)
        {

            if (headertype.ToLower() == "&new") //add mode
            {
                pnlselecttemplate.Visible = false;
                //cmbTransType.Enabled = true; //15-APR-2019
                txttemplatename.Enabled = true; //25-APR-2019
                cmbTransType.DataSource = GetTransactionTypeList();
                cmbTransType.DisplayMember = "ItemFieldName";
                cmbTransType.ValueMember = "ItemFieldId";
                cmbTransType.SelectedIndex = 0;
                lbltemplateheadertext.Text = "Add Template";
                txttemplatename.Text = "TempTemplate";
                txttemplatename.Focus();
                pnlheadercontrols.Location = new Point(17, 61);
                pnlheadercontrols.Visible = true;
            }
            else if (headertype.ToLower().Trim() == "&edit")// edit mode
            {

                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                cmbtemplatelist.DataSource = lobjtemplatenames.GetTemplateNameList();
                cmbtemplatelist.DisplayMember = "ItemFieldName";
                cmbtemplatelist.ValueMember = "ItemFieldId";
                lbltemplateheadertext.Text = "Edit Template";                
                cmbTransType.DataSource = GetTransactionTypeList();
                cmbTransType.DisplayMember = "ItemFieldName";
                cmbTransType.ValueMember = "ItemFieldId";
                // cmbTransType.Enabled = false; //15-APR-2019
                txttemplatename.Enabled = false; //25-APR-2019
                cmbtemplatelist.Enabled = false;
                cmbtemplatelist.Visible = false;
                cmbTransType.Text = this.SetcmbTransType;
                txtTempName.Visible = true;
                txtTempName.Enabled = false;
                cmbtemplatelist.Text = this.SetTemplateName;
                if (this.SetTemplateName.ToLower()== "TempTemplate".ToLower())
                {
                    txtTempName.Text = "UnSaved";
                }
                else
                {
                    txtTempName.Text = this.SetTemplateName;
                }
                txttemplatename.Text= this.SetTemplateName;
                txttemplateheaderwidth.Text = this.SetTemplatewidth;
                txttemplateheaderheight.Text = this.SetTemplateheight;
                // txtdpi.Text = lobjQBConfiguration.GetLabelConfigSettings("dpi"); //18-Mar-2019
                //txtscalex.Text = lobjQBConfiguration.GetLabelConfigSettings("scaleX");
                //txtscaley.Text = lobjQBConfiguration.GetLabelConfigSettings("scaleY");


                txttemplatename.Focus();
                // pnlheadercontrols.Location = new Point(17, 61);
                pnlheadercontrols.Visible = true;
            }



        }

        public List<QuickBooksField> GetTransactionTypeList()
        {

            //Trans  Standard Fields
            List<QuickBooksField> objTransTypevalues = new List<QuickBooksField>();
            objTransTypevalues.Add(new QuickBooksField(0, "---Select Transaction Type---"));
            objTransTypevalues.Add(new QuickBooksField(1, "Item List"));
            objTransTypevalues.Add(new QuickBooksField(2, "Invoice"));
            objTransTypevalues.Add(new QuickBooksField(3, "Sales Order"));
            objTransTypevalues.Add(new QuickBooksField(4, "Purchase Order"));
            objTransTypevalues.Add(new QuickBooksField(5, "Receipts"));
            objTransTypevalues.Add(new QuickBooksField(5, "Sales Receipts"));
            return objTransTypevalues;
        }

        private void txttemplatename_TextChanged(object sender, EventArgs e)
        {
            ControlsValidate();
        }
        public void ControlsValidate()
        {
            btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txttemplatename.Text) &&
                              !String.IsNullOrWhiteSpace(txttemplateheaderwidth.Text) &&
                              !String.IsNullOrWhiteSpace(txttemplateheaderheight.Text) && cmbTransType.SelectedValue.ToString() != "0";

        }

        private void txttemplateheaderwidth_TextChanged(object sender, EventArgs e)
        {
            ControlsValidate();
        }

        private void txttemplateheaderheight_TextChanged(object sender, EventArgs e)
        {
            ControlsValidate();
        }

        private void cmbTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlsValidate();
        }

        private void txttemplateheaderwidth_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txttemplateheaderheight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtdpi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtscalex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtscaley_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
