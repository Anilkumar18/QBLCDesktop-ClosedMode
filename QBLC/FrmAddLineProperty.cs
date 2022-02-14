using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace LabelConnector
{
    public partial class FrmAddLineProperty : Form
    {
        string lbllabeladdimges = "Add Line";
        string SetTemplateName = string.Empty;
        string SetValuesForTransType = string.Empty;
        string SetValuesForTemplate = string.Empty;
        string SetFieldName = string.Empty;
        float X = 0;
        float Y = 0;
        string xOriginal = "";
        string yOriginal = "";
        string SetTemplatewidth = string.Empty;
        string SetTemplateheight = string.Empty;
        string SetFieldType = string.Empty;
        public string designerHeight = "";
        string SetEditMode = string.Empty;
        string Id = string.Empty;
        string Setgridfieldname = string.Empty;
        string txtxposimg = string.Empty;
        string txtyposimg = string.Empty;
        string txtxopos = string.Empty;
        string txtyopos = string.Empty;
        double labelwidthsize = 0;
        double labelheightsize = 0;
        clsTemplateLabelXmlwork lobjTemplate = new clsTemplateLabelXmlwork();
        public delegate void PassControl(String pstrTemplate, String pcmbTransType);
        public PassControl passControl;
        public FrmAddLineProperty()
        {
            InitializeComponent();
        }
        public FrmAddLineProperty(string pstrtemplate, string pstrtransactiontype, float lntPositionX, float lntPositionY, string OriginalPositionX, string OriginalPositionY,double labelwidth,double labelheight)
        {
            this.SetTemplateName = pstrtemplate;
            this.SetValuesForTransType = pstrtransactiontype;
            this.X = lntPositionX;
            this.Y = lntPositionY;
            this.xOriginal = OriginalPositionX;
            this.yOriginal = OriginalPositionY;
            this.labelwidthsize = labelwidth;
            this.labelheightsize = labelheight;
            InitializeComponent();

        }
        public FrmAddLineProperty(string pstrtemplate, double labelwidth, double labelheight, string Id, string pstrtransactiontype, string pstrfieldname = null, string pstrgridselectedfieldname = null)
        {
            this.SetTemplateName = pstrtemplate;
            this.Id = Id;
            this.SetValuesForTransType = pstrtransactiontype;
            this.SetFieldName = pstrfieldname;
            this.Setgridfieldname = pstrgridselectedfieldname;
            this.labelwidthsize = labelwidth;
            this.labelheightsize = labelheight;
            InitializeComponent();

        }
        public void funData(String pstrTemplate, String lntPositionX, String lntPositionY, String Imgname)
        {
            this.SetTemplateName = pstrTemplate;
            this.SetEditMode = Imgname;

        }
        public List<QuickBooksField> GetOrientationList()
        {
            //Trans  Standard Fields
            List<QuickBooksField> objorientationvalues = new List<QuickBooksField>();
            objorientationvalues.Add(new QuickBooksField(0, "0"));
            objorientationvalues.Add(new QuickBooksField(4, "90"));
            //objorientationvalues.Add(new QuickBooksField(5, "180"));
            //objorientationvalues.Add(new QuickBooksField(6, "270"));
            return objorientationvalues;
        }
      
        private void FrmAddLineProperty_Load(object sender, EventArgs e)
        {
            AddimageControlsValidate();
            //fill orientation list
            cmborientation.DataSource = GetOrientationList();
            cmborientation.DisplayMember = "ItemFieldName";
            cmborientation.ValueMember = "ItemFieldId";



            if (string.IsNullOrWhiteSpace(this.SetEditMode)) //edit mode
            {
                double inputValue = 0;
                double width = 0;
                var objimagefieldlist = lobjTemplate.GetFieldPropertiesList(this.SetTemplateName, this.Id);
                foreach (clsTemplateLabelXmlwork imagefield in objimagefieldlist)
                {
                    txtimagename.Text = imagefield.fieldname;
                    if (double.TryParse(imagefield.imgwidth, out inputValue))
                     width = Math.Round(inputValue / 2 / 96, 2);
                    txtaddimgwidth.Text = Convert.ToString(width);
                    txtaddimgheight.Text = imagefield.imgheight;
                    cmborientation.Text = imagefield.orientation;
                    txtxposimg = imagefield.xposition;
                    txtyposimg = imagefield.yposition;
                    txtxopos = imagefield.xoriginalposition;
                    txtyopos = imagefield.yoriginalposition;
                }
                lbllabeladdimges = "Edit Line";
                txtimagename.Enabled = false;
                btnReposition.Visible = true;
                btnaddimgcancel.Visible = true;
            }
            else
            {
                txtimagename.Enabled = false;
                txtimagename.Text = "Line";
                txtaddimgheight.Text = "3";
                txtxposimg = Convert.ToString(this.X);
                txtyposimg = Convert.ToString(this.Y);
                txtxopos = this.xOriginal;
                txtyopos = this.yOriginal;
                btnReposition.Visible = false;
                btnaddimgcancel.Visible = false;
            }
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            //Resize image and show to pdf
            string targetDir = string.Empty;
            string originalimagepath = string.Empty;
            string resizeimagepath = string.Empty;
            string ext = string.Empty;
            string strTransTypeFilePath = string.Empty;
            clsTemplateLabelXmlwork lobjTemplateresize = new clsTemplateLabelXmlwork();
            try
            {
                using (new HourGlass())
                {
                    
                    var Linefilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\bar.jpg");

                    if (string.IsNullOrWhiteSpace(txtaddimgheight.Text.Trim('0')) || string.IsNullOrWhiteSpace(txtaddimgwidth.Text.Trim('0')))
                    {
                        MessageBox.Show("Enter the line width/thickness", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if(cmborientation.SelectedIndex == 0)
                    {
                        if(Convert.ToDouble(txtaddimgwidth.Text) > this.labelwidthsize)
                        {
                            MessageBox.Show("Enter the line width below the label template width", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if((Convert.ToDouble(txtaddimgheight.Text) / 2) / 96 > this.labelheightsize)
                        {
                            MessageBox.Show("Enter the line thickness below the label template width", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(txtaddimgwidth.Text) > this.labelheightsize)
                        {
                            MessageBox.Show("Enter the line width below the label designer", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if ((Convert.ToDouble(txtaddimgheight.Text) / 2) / 96 > this.labelwidthsize)
                        {
                            MessageBox.Show("Enter the line thickness below the label designer", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
              
                    lobjTemplateresize.DeleteResizeImage(Path.GetFileNameWithoutExtension(txtimagename.Text.ToString()), this.SetTemplateName);
                    ext = ".png";

                    DirectoryInfo di = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "OriginalImages" + "\\"));

                    // Create the directory only if it does not already exist.
                    if (di.Exists == false)
                        di.Create();

                    // Create a subdirectory in the directory just created.
                    DirectoryInfo dis = di.CreateSubdirectory(this.SetTemplateName);

                    targetDir = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "OriginalImages" + "\\" + dis.Name.ToString());
                   
                    File.Copy(Linefilepath.ToString(), Path.Combine(targetDir, Path.GetFileNameWithoutExtension(txtimagename.Text.ToString())) + ext, true);

                    originalimagepath = Path.Combine(targetDir, Path.GetFileNameWithoutExtension(txtimagename.Text.ToString())) + ext;

                    DirectoryInfo diresize = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ResizeImages" + "\\"));
                    // Create the directory only if it does not already exist.
                    if (diresize.Exists == false)
                        diresize.Create();

                    // Create a subdirectory in the directory just created.
                    DirectoryInfo dirimgresize = diresize.CreateSubdirectory(this.SetTemplateName);
                    resizeimagepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ResizeImages" + "\\" + dirimgresize.Name.ToString() + "\\" + Path.GetFileNameWithoutExtension(txtimagename.Text.ToString()) + ext);
                   
                    //Resize Image..
                    Image original = Image.FromFile(originalimagepath);

                    double width = (Convert.ToDouble(txtaddimgwidth.Text) * 2 * 96)-4;
                    Image resized = ResizeImage(original, new Size(Convert.ToInt32(width), Convert.ToInt32(txtaddimgheight.Text)));

                    //MemoryStream memStream = new MemoryStream();
                    resized.Save(resizeimagepath, GetImageFormat(originalimagepath));
                    //write image to pdf at x,y location
                    Image original1 = Image.FromFile(resizeimagepath);
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Image));

                    String TheImageAsString = Convert.ToBase64String((Byte[])converter.ConvertTo(original1, typeof(Byte[])));
                    //save image data to xml
                  
                    clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork(this.SetTemplateName, this.Id, "Line", Convert.ToString(txtimagename.Text).Trim(), Linefilepath, resizeimagepath, Convert.ToString(cmborientation.Text).Trim(), Convert.ToString(width).Trim(), Convert.ToString(txtaddimgheight.Text).Trim(), Convert.ToString(txtxposimg).Trim(), Convert.ToString(txtyposimg).Trim(), Convert.ToString(txtxopos).Trim(), Convert.ToString(txtyopos).Trim(), Convert.ToString(TheImageAsString));


                    if (lbllabeladdimges.ToString().ToLower() == "add line")
                    {
                        //add image
                        if (lobjTemplatexml.AddTemplateLineDetails(lobjTemplatexml))
                        {
                        }
                        else
                        {
                            MessageBox.Show("ImageName exist already", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        //edit template
                        if (lobjTemplatexml.UpdateTemplateDetails(lobjTemplatexml, this.Setgridfieldname, string.Empty, string.Empty))
                        {

                        }
                        else
                        {
                            MessageBox.Show("ImageName exist already", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                    List<QuickBooksField> objheaderfield = new List<QuickBooksField>();
                    objfieldlist = lobjTemplate.GetFieldPropertiesList(this.SetTemplateName, string.Empty);
                    //Get property fields list
                    List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();
                   
                    System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
                    if (dirtransxml.Exists)
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


                    objheaderfield = lobjTemplate.GetTemplateHeaderInfo(this.SetTemplateName);
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
                    lobjTemplate.InsertImageToPDF(this.SetTemplateName, this.SetTemplatewidth, this.SetTemplateheight, this.SetValuesForTransType, resizeimagepath, Convert.ToSingle(txtaddimgwidth.Text), Convert.ToSingle(txtaddimgheight.Text), Convert.ToSingle(txtxposimg), Convert.ToSingle(txtyposimg), objfieldlist, Itemfieldlist);

                    if (passControl != null)
                    {

                        passControl(this.SetTemplateName, string.Empty);
                        {

                            this.Close();

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


         public static Image ResizeImage(Image image, Size size)
        {
            int newWidth = Convert.ToInt32(size.Width);
            int newHeight = Convert.ToInt32(size.Height);
            
            Image newImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.SmoothingMode = SmoothingMode.HighQuality;
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        private static ImageFormat GetImageFormat(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(extension))
                throw new ArgumentException(
                    string.Format("Unable to determine file extension for fileName: {0}", fileName));

            switch (extension.ToLower())
            {
                case @".bmp":
                    return ImageFormat.Bmp;

                case @".gif":
                    return ImageFormat.Gif;

                case @".ico":
                    return ImageFormat.Icon;

                case @".jpg":
                case @".jpeg":
                    return ImageFormat.Jpeg;

                case @".png":
                    return ImageFormat.Png;

                case @".tif":
                case @".tiff":
                    return ImageFormat.Tiff;

                case @".wmf":
                    return ImageFormat.Wmf;

                default:
                    throw new NotImplementedException();
            }
        }

        private void txtaddimgwidth_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtaddimgheight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if(Convert.ToInt32(txtaddimgheight.Text) >= 55)
            {
                txtaddimgheight.Text = "55";
            }
        }

        public void AddimageControlsValidate()
        {
            btnAddLine.Enabled = !String.IsNullOrWhiteSpace(txtaddimgwidth.Text) &&
                  !String.IsNullOrWhiteSpace(txtaddimgheight.Text);
        }

        private void txtaddimgwidth_TextChanged(object sender, EventArgs e)
        {
            AddimageControlsValidate();
        }

        private void txtaddimgheight_TextChanged(object sender, EventArgs e)
        {
            AddimageControlsValidate();
        }

        private void cmborientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.SetEditMode)) //edit mode
            {

                if (cmborientation.SelectedIndex == 0)
                {
                    txtaddimgwidth.Text = "";
                    txtaddimgwidth.Text = Convert.ToString(labelwidthsize);
                }
                else if (cmborientation.SelectedIndex == 1)
                {
                    txtaddimgwidth.Text = "";
                    txtaddimgwidth.Text = Convert.ToString(labelheightsize);
                }
            }
        }

        private void btnaddimgcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReposition_Click(object sender, EventArgs e)
        {
            //Resize image and show to pdf
            string targetDir = string.Empty;
            string originalimagepath = string.Empty;
            string resizeimagepath = string.Empty;
            string ext = string.Empty;
            string strTransTypeFilePath = string.Empty;
            clsTemplateLabelXmlwork lobjTemplateresize = new clsTemplateLabelXmlwork();
            string xpos, Xoriginal,ypos,Yoriginal;
            try
            {
                using (new HourGlass())
                {

                    var Linefilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\bar.jpg");

                    if (string.IsNullOrWhiteSpace(txtaddimgheight.Text.Trim('0')) || string.IsNullOrWhiteSpace(txtaddimgwidth.Text.Trim('0')))
                    {
                        MessageBox.Show("Enter the line width/thickness", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (cmborientation.SelectedIndex == 0)
                    {
                        xpos = "0.01"; Xoriginal = "3"; ypos = "2.3"; Yoriginal="17";
                        if (Convert.ToDouble(txtaddimgwidth.Text) > this.labelwidthsize)
                        {
                            MessageBox.Show("Enter the line width below the label designer", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if ((Convert.ToDouble(txtaddimgheight.Text) / 2) / 96 > this.labelheightsize)
                        {
                            MessageBox.Show("Enter the line thickness below the label designer", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        xpos = "0.05"; Xoriginal = "3"; ypos = "1.35"; Yoriginal = "200";
                        if (Convert.ToDouble(txtaddimgwidth.Text) > this.labelheightsize)
                        {
                            MessageBox.Show("Enter the line width below the label designer", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if ((Convert.ToDouble(txtaddimgheight.Text) / 2) / 96 > this.labelwidthsize)
                        {
                            MessageBox.Show("Enter the line thickness below the label designer", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    lobjTemplateresize.DeleteResizeImage(Path.GetFileNameWithoutExtension(txtimagename.Text.ToString()), this.SetTemplateName);
                    ext = ".png";

                    DirectoryInfo di = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "OriginalImages" + "\\"));

                    // Create the directory only if it does not already exist.
                    if (di.Exists == false)
                        di.Create();

                    // Create a subdirectory in the directory just created.
                    DirectoryInfo dis = di.CreateSubdirectory(this.SetTemplateName);

                    targetDir = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "OriginalImages" + "\\" + dis.Name.ToString());

                    File.Copy(Linefilepath.ToString(), Path.Combine(targetDir, Path.GetFileNameWithoutExtension(txtimagename.Text.ToString())) + ext, true);

                    originalimagepath = Path.Combine(targetDir, Path.GetFileNameWithoutExtension(txtimagename.Text.ToString())) + ext;

                    DirectoryInfo diresize = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ResizeImages" + "\\"));
                    // Create the directory only if it does not already exist.
                    if (diresize.Exists == false)
                        diresize.Create();

                    // Create a subdirectory in the directory just created.
                    DirectoryInfo dirimgresize = diresize.CreateSubdirectory(this.SetTemplateName);
                    resizeimagepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ResizeImages" + "\\" + dirimgresize.Name.ToString() + "\\" + Path.GetFileNameWithoutExtension(txtimagename.Text.ToString()) + ext);

                    //Resize Image..
                    Image original = Image.FromFile(originalimagepath);

                    double width = (Convert.ToDouble(txtaddimgwidth.Text) * 2 * 96)-4;
                    Image resized = ResizeImage(original, new Size(Convert.ToInt32(width), Convert.ToInt32(txtaddimgheight.Text)));

                    //MemoryStream memStream = new MemoryStream();
                    resized.Save(resizeimagepath, GetImageFormat(originalimagepath));
                    //write image to pdf at x,y location
                    Image original1 = Image.FromFile(resizeimagepath);
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(Image));

                    String TheImageAsString = Convert.ToBase64String((Byte[])converter.ConvertTo(original1, typeof(Byte[])));
                    //save image data to xml

                 

                    clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork(this.SetTemplateName, this.Id, "Line", Convert.ToString(txtimagename.Text).Trim(), Linefilepath, resizeimagepath, Convert.ToString(cmborientation.Text).Trim(), Convert.ToString(width).Trim(), Convert.ToString(txtaddimgheight.Text).Trim(), xpos, ypos, Xoriginal, Yoriginal, Convert.ToString(TheImageAsString));

                    //edit template
                   lobjTemplatexml.UpdateTemplateDetails(lobjTemplatexml, this.Setgridfieldname, string.Empty, string.Empty);
                        

                    List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                    List<QuickBooksField> objheaderfield = new List<QuickBooksField>();
                    objfieldlist = lobjTemplate.GetFieldPropertiesList(this.SetTemplateName, string.Empty);
                    //Get property fields list
                    List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();

                    System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
                    if (dirtransxml.Exists)
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


                    objheaderfield = lobjTemplate.GetTemplateHeaderInfo(this.SetTemplateName);
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
                    lobjTemplate.InsertImageToPDF(this.SetTemplateName, this.SetTemplatewidth, this.SetTemplateheight, this.SetValuesForTransType, resizeimagepath, Convert.ToSingle(txtaddimgwidth.Text), Convert.ToSingle(txtaddimgheight.Text), Convert.ToSingle(txtxposimg), Convert.ToSingle(txtyposimg), objfieldlist, Itemfieldlist);

                    if (passControl != null)
                    {

                        passControl(this.SetTemplateName, string.Empty);
                        {

                            this.Close();

                        }
                    }
                }
            }
            catch (Exception ex)
            {

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

   
}
