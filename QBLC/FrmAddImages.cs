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
    public partial class FrmAddImages : Form
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string SetTemplateName = string.Empty;
        public static double lintActualwidth=0;
        public static double lintActualHeight=0;
        string SetValuesForTransType = string.Empty;
        string Id = string.Empty;
        string SetFieldName = string.Empty;
        string Setgridfieldname = string.Empty;
        string SetTemplatewidth = string.Empty;
        string SetTemplateheight = string.Empty;
        string SetEditMode = string.Empty;
        float X = 0;
        float Y = 0;
        string xOriginal = "";
        string yOriginal = "";
        double labelwidthsize = 0;
        double labelheightsize = 0;
        string imgxlocation = string.Empty;
        string imgylocation = string.Empty;
        public string designerHeight = "";
        clsTemplateLabelXmlwork lobjTemplate = new clsTemplateLabelXmlwork();
        public delegate void PassControlimg(String pstrTemplate,String pcmbTransType);
        // Create instance (null)
        public PassControlimg passControlimg;
        public FrmAddImages()
        {                       
            InitializeComponent();
        }

        public FrmAddImages(string pstrtemplate, string pstrtransactiontype, float lntPositionX, float lntPositionY, string OriginalPositionX, string OriginalPositionY, double labelwidth, double labelheight)
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
        public FrmAddImages(string pstrtemplate, double labelwidth, double labelheight, string Id, string pstrtransactiontype, string pstrfieldname = null, string pstrgridselectedfieldname = null)
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

        private void btnaddimgcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnaddimages_Click(object sender, EventArgs e)
        {
            //Resize image and show to pdf
            string targetDir = string.Empty;
            string originalimagepath = string.Empty;
            string resizeimagepath = string.Empty;
            String DataSource = string.Empty;
            string DataSourcevalue = string.Empty;
            double PixelWidth = 0;
            double PixelHeight = 0;
            string ext = string.Empty;
            string strTransTypeFilePath = string.Empty;
            clsTemplateLabelXmlwork lobjTemplateresize = new clsTemplateLabelXmlwork();
            try
            {
                using (new HourGlass())
                {
                    //check valid file name
                    if (txtbrowsefilepath.Text.ToString().IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                    {
                        if (string.IsNullOrWhiteSpace(txtaddimgheight.Text.Trim('0')) || string.IsNullOrWhiteSpace(txtaddimgwidth.Text.Trim('0')))
                        {
                            MessageBox.Show("Enter image width/height", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        PixelWidth = (Convert.ToDouble(txtaddimgwidth.Text) * 2 * 96);
                           PixelHeight = (Convert.ToDouble(txtaddimgheight.Text) * 2 * 96);

                        if (cmborientation.SelectedIndex == 0 || cmborientation.SelectedIndex == 2)
                        {
                            if (Convert.ToDouble(txtaddimgwidth.Text) > this.labelwidthsize)
                            {
                                MessageBox.Show("Enter the image width below the label template width", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else if (Convert.ToDouble(txtaddimgheight.Text)  > this.labelheightsize)
                            {
                                MessageBox.Show("Enter the image height below the label template height", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else if(cmborientation.SelectedIndex == 1 || cmborientation.SelectedIndex == 3)
                        {
                            if (Convert.ToDouble(txtaddimgwidth.Text) > this.labelheightsize)
                            {
                                MessageBox.Show("Enter the image width below the label template height", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else if (Convert.ToDouble(txtaddimgheight.Text) > this.labelwidthsize)
                            {
                                MessageBox.Show("Enter the image height below the label template width", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }


                        lobjTemplateresize.DeleteResizeImage(Path.GetFileNameWithoutExtension(txtimagename.Text.ToString()),this.SetTemplateName);
                        ext = Path.GetExtension(txtbrowsefilepath.Text.ToString());
                      
                        DirectoryInfo di = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "OriginalImages" + "\\"));
                       
                        // Create the directory only if it does not already exist.
                        if (di.Exists == false)
                            di.Create();
                       
                        // Create a subdirectory in the directory just created.
                        DirectoryInfo dis = di.CreateSubdirectory(this.SetTemplateName);
                       
                        targetDir = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "OriginalImages" + "\\"+ dis.Name.ToString());
                        if (!File.Exists(txtbrowsefilepath.Text.ToString()))
                        {
                            if (string.IsNullOrWhiteSpace(SetEditMode))
                            {
                                MessageBox.Show("The selected image could not be found, so unable to save your changes., ", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show("The selected image could not be found, please select the image again.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }


                            return;
                        }
                        //File.Copy(txtbrowsefilepath.Text.ToString(), Path.Combine(targetDir, Path.GetFileName(txtbrowsefilepath.Text.ToString())), true);
                        File.Copy(txtbrowsefilepath.Text.ToString(), Path.Combine(targetDir, Path.GetFileNameWithoutExtension(txtimagename.Text.ToString())) + ext, true);
                       
                        //originalimagepath = System.Windows.Forms.Application.StartupPath + @"\" + "OriginalImages" + "\\" + dis.Name.ToString() + "\\" + Path.GetFileName(txtbrowsefilepath.Text.ToString());
                        originalimagepath = Path.Combine(targetDir, Path.GetFileNameWithoutExtension(txtimagename.Text.ToString())) + ext;
                       
                        DirectoryInfo diresize = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ResizeImages" + "\\"));
                        // Create the directory only if it does not already exist.
                        if (diresize.Exists == false)
                            diresize.Create();
                        // Create a subdirectory in the directory just created.
                        DirectoryInfo dirimgresize = diresize.CreateSubdirectory(this.SetTemplateName);
                        resizeimagepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ResizeImages" + "\\" + dirimgresize.Name.ToString() + "\\" + Path.GetFileNameWithoutExtension(txtimagename.Text.ToString()) + ext);
                        //resizeimagepath = System.Windows.Forms.Application.StartupPath + @"\" + "ResizeImages" + "\\" + Path.GetFileNameWithoutExtension(txtbrowsefilepath.Text.ToString()) + ext;
                       
                        //Resize Image..
                        Image original = Image.FromFile(originalimagepath);

                       // Image resized = ResizeImage(original, new Size(Convert.ToInt32(txtaddimgwidth.Text), Convert.ToInt32(txtaddimgheight.Text)), chkaspectratio.Checked);

                        Image resized = ResizeImage(original, new Size(Convert.ToInt32(PixelWidth), Convert.ToInt32(PixelHeight)), chkaspectratio.Checked);

                        //MemoryStream memStream = new MemoryStream();
                        resized.Save(resizeimagepath, GetImageFormat(originalimagepath));
                        //write image to pdf at x,y location
                        Image original1 = Image.FromFile(resizeimagepath);
                        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Image));

                        String TheImageAsString = Convert.ToBase64String((Byte[])converter.ConvertTo(original1, typeof(Byte[])));

                        DataSource = Convert.ToString(cmbdatasource.Text);
                        DataSourcevalue = Convert.ToString(cmbdatasource.SelectedValue);

                        //save image data to xml
                        clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork(this.SetTemplateName, this.Id, "Image", Convert.ToString(txtimagename.Text).Trim(), txtbrowsefilepath.Text.ToString(), resizeimagepath, Convert.ToBoolean(chkaspectratio.Checked).ToString(), Convert.ToString(cmborientation.Text).Trim(), Convert.ToString(PixelWidth).Trim(), Convert.ToString(PixelHeight).Trim(), Convert.ToString(txtxposimg.Text).Trim(), Convert.ToString(txtyposimg.Text).Trim(), Convert.ToString(txtxopos.Text).Trim(), Convert.ToString(txtyopos.Text).Trim(), Convert.ToString(TheImageAsString), Convert.ToString(DataSource), Convert.ToString(DataSourcevalue),Convert.ToBoolean(RadioUseFixedImage.Checked).ToString(), Convert.ToBoolean(RadioVariableImage.Checked).ToString());
                        if (lbllabeladdimges.Text.ToString().ToLower() == "add images")
                        {
                            //add image
                            if (lobjTemplatexml.AddTemplateImageDetails(lobjTemplatexml))
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
                            if (lobjTemplatexml.UpdateTemplateDetails(lobjTemplatexml, this.Setgridfieldname,string.Empty,string.Empty))
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
                        // strTransTypeFilePath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + this.SetValuesForTransType + ".xml";

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
                        lobjTemplate.InsertImageToPDF(this.SetTemplateName, this.SetTemplatewidth, this.SetTemplateheight, this.SetValuesForTransType, resizeimagepath, Convert.ToSingle(PixelWidth), Convert.ToSingle(PixelHeight), Convert.ToSingle(txtxposimg.Text), Convert.ToSingle(txtyposimg.Text), objfieldlist, Itemfieldlist);

                        if (passControlimg != null)
                        {

                            passControlimg(this.SetTemplateName, string.Empty);
                            {

                                this.Close();

                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("Invalid Image file", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch(Exception ex)
            {

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
        private void btnbrowseimage_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
           
            string defaultpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Label Connector Documents";
              
            openFileDialog1.Title = "Browse Image";
            if (!Directory.Exists(defaultpath))
                Directory.CreateDirectory(defaultpath);
            openFileDialog1.InitialDirectory = defaultpath;
          
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
            openFileDialog1.FilterIndex = 0;
           // openFileDialog1.DefaultExt = "xml";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtbrowsefilepath.Text = openFileDialog1.FileName.ToString();
                //get default img width and height and put in textbox
               
                Image originalSize = Image.FromFile(openFileDialog1.FileName.ToString());
                //set width & Height value globally
                lintActualwidth = 1;
                lintActualHeight = 1;

                txtaddimgwidth.Text = Convert.ToString(lintActualwidth);
                txtaddimgheight.Text = Convert.ToString(lintActualHeight);

            }
        }

        //Resize Imaage :Date 30-Mar-2019
        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                //int originalWidth = image.Width;
                //int originalHeight = image.Height;
                //float percentWidth = (float)size.Width / (float)originalWidth;
                //float percentHeight = (float)size.Height / (float)originalHeight;
                //float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                //newWidth = (int)(originalWidth * percent);
                //newHeight = (int)(originalHeight * percent);
                newWidth = Convert.ToInt32(size.Width);
                newHeight = Convert.ToInt32(size.Height);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
               // graphicsHandle.CompositingMode = CompositingMode.SourceCopy;
                graphicsHandle.SmoothingMode = SmoothingMode.HighQuality;
               // graphicsHandle.CompositingQuality = CompositingQuality.HighQuality;
                //graphicsHandle.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
            

        }

        public double CalAspectRatioWidth(double pintUserHeight, double pintActualWidth, double pintActualHeight)
        {
            double newWidth = 0;
                        
            newWidth = Convert.ToDouble(((pintUserHeight * pintActualWidth) / pintActualHeight));
            return newWidth;
        }
        public double CalAspectRatioHeight(double pintUserWidth, double pintActualHeight, double pintActualWidth)
        {
             double newHeight = 0;
           
            newHeight = Convert.ToDouble(((pintUserWidth * pintActualHeight) / pintActualWidth));
            return newHeight;
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

        public void AddimageControlsValidate()
        {

            if(cmbdatasource.SelectedIndex == 0)
            {
                btnaddimages.Enabled = !String.IsNullOrWhiteSpace(txtimagename.Text) &&
                 !String.IsNullOrWhiteSpace(txtbrowsefilepath.Text) &&
                 !String.IsNullOrWhiteSpace(txtaddimgwidth.Text) &&
                 !String.IsNullOrWhiteSpace(txtaddimgheight.Text) &&
                 !String.IsNullOrWhiteSpace(txtxposimg.Text) &&
                 !String.IsNullOrWhiteSpace(txtxopos.Text) &&
                 !String.IsNullOrWhiteSpace(txtyopos.Text) &&
                 !String.IsNullOrWhiteSpace(txtyposimg.Text);
            }
            else
            {
                btnaddimages.Enabled = !String.IsNullOrWhiteSpace(txtimagename.Text) &&
        !String.IsNullOrWhiteSpace(txtbrowsefilepath.Text) &&
        !String.IsNullOrWhiteSpace(txtaddimgwidth.Text) &&
        !String.IsNullOrWhiteSpace(txtaddimgheight.Text) &&
        !String.IsNullOrWhiteSpace(txtxposimg.Text) &&
        !String.IsNullOrWhiteSpace(txtxopos.Text) &&
        !String.IsNullOrWhiteSpace(txtyopos.Text) &&
        !String.IsNullOrWhiteSpace(txtyposimg.Text);
            }
  
        }

        private void txtimagename_TextChanged(object sender, EventArgs e)
        {
            AddimageControlsValidate();
        }

        private void txtbrowsefilepath_TextChanged(object sender, EventArgs e)
        {
            AddimageControlsValidate();
        }

        private void txtaddimgwidth_TextChanged(object sender, EventArgs e)
        {
            AddimageControlsValidate();
           
        }

        private void txtaddimgheight_TextChanged(object sender, EventArgs e)
        {
            AddimageControlsValidate();
           
        }

        private void txtxposimg_TextChanged(object sender, EventArgs e)
        {
            AddimageControlsValidate();
        }

        private void txtyposimg_TextChanged(object sender, EventArgs e)
        {
            AddimageControlsValidate();
        }

        private void FrmAddImages_Load(object sender, EventArgs e)
        {
            double Height = 0;
            double inputHeight = 0;
            double width = 0;
            double inputValue = 0;
            AddimageControlsValidate();
            txtdesignerheght.Text = this.designerHeight;
            string strTransTypeFilePath = string.Empty;
            //fill orientation list
            cmborientation.DataSource = GetOrientationList();
            cmborientation.DisplayMember = "ItemFieldName";
            cmborientation.ValueMember = "ItemFieldId";

            RadioUseFixedImage.Checked = true;
            cmbdatasource.Enabled = false;


            System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
            if (dirtransxml.Exists)
            {
                strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + SetValuesForTransType + ".xml");
            }
            else
            {
                strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + SetValuesForTransType + ".xml");
            }
            List<QuickBooksField> Itemfieldlist = lobjTemplate.GetItemCustomFieldListfromxml(strTransTypeFilePath);
            cmbdatasource.DataSource = Itemfieldlist;
            cmbdatasource.DisplayMember = "ItemFieldValue";
            cmbdatasource.ValueMember = "ItemFieldName";

            if (string.IsNullOrWhiteSpace(this.SetEditMode)) //edit mode
            {
                //string tempname = this.SetTemplateName;
               // txtimagename.Text = this.Setgridfieldname;
                var objimagefieldlist = lobjTemplate.GetFieldPropertiesList(this.SetTemplateName, this.Id);
                foreach (clsTemplateLabelXmlwork imagefield in objimagefieldlist)
                {
                    txtimagename.Text = imagefield.fieldname;
                    txtbrowsefilepath.Text = imagefield.originimgpath;
                    chkaspectratio.Checked = imagefield.aspectratio =="True" ? true : false;
                    cmborientation.Text = imagefield.orientation;
                    txtxposimg.Text = imagefield.xposition;
                    txtyposimg.Text = imagefield.yposition;
                    txtxopos.Text = imagefield.xoriginalposition;
                    txtyopos.Text = imagefield.yoriginalposition;

                    RadioUseFixedImage.Checked = imagefield.UseFixedImage == "True" ? true : false;
                    RadioVariableImage.Checked = imagefield.UseVariableImage == "True" ? true : false;



                    cmbdatasource.Text = imagefield.datasourcetext;
                    if (double.TryParse(imagefield.imgwidth, out inputValue))
                        width = Math.Round(inputValue / 2 / 96, 2);
                    txtaddimgwidth.Text = Convert.ToString(width);

                    if (double.TryParse(imagefield.imgheight, out inputHeight))
                        Height = Math.Round(inputHeight / 2 / 96, 2);
                    txtaddimgheight.Text = Convert.ToString(Height);


                }
                lintActualwidth = Convert.ToDouble(txtaddimgwidth.Text);
                lintActualHeight = Convert.ToDouble(txtaddimgheight.Text);
                lbllabeladdimges.Text = "Edit Image";
                txtimagename.Enabled = false;
            }
            else
            {
                txtimagename.Enabled = true;
                txtxposimg.Text = this.imgxlocation;
                txtyposimg.Text = this.imgylocation;
                txtxopos.Text = this.xOriginal;
                txtyopos.Text = this.yOriginal;

            }
        }

        public void funDataimg(String pstrTemplate, String lntPositionX, String lntPositionY, String Imgname)
        {
            this.SetTemplateName = pstrTemplate;
            this.SetEditMode = Imgname;
            this.imgxlocation = lntPositionX;
            this.imgylocation = lntPositionY;

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
        private void txtxposimg_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtyposimg_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtaddimgwidth_KeyUp(object sender, KeyEventArgs e)
        {
            ////Calculate Height
            double lintnewheight = 0;
            if (!string.IsNullOrWhiteSpace(txtaddimgwidth.Text.ToString()))
            {
                if (chkaspectratio.Checked == true && txtaddimgwidth.Text != ".")
                {
                    lintnewheight = CalAspectRatioHeight(Convert.ToDouble(txtaddimgwidth.Text), lintActualHeight, lintActualwidth);
                    txtaddimgheight.Text = Convert.ToString(lintnewheight);
                }
            }
        }

        private void txtaddimgheight_KeyUp(object sender, KeyEventArgs e)
        {
            //Calculate Width
            double lintnewWidth = 0;
                        
            if (!string.IsNullOrWhiteSpace(txtaddimgheight.Text.ToString()))
            {
                if (chkaspectratio.Checked == true && txtaddimgheight.Text == ".")
                {
                    lintnewWidth = CalAspectRatioWidth(Convert.ToDouble(txtaddimgheight.Text), lintActualwidth, lintActualHeight);
                    txtaddimgwidth.Text = Convert.ToString(lintnewWidth);
                }
               
            }
        }

        private void txtxopos_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(txtxopos.Text.Trim()) != "")
            {
                var widthmeasure = (Convert.ToInt32(txtxopos.Text) / 2);
                var wd = 0.010416f * widthmeasure;
                txtxposimg.Text = Math.Round(wd, 2).ToString();           
            }
            else
            {
                txtxposimg.Text = "";
            }
            AddimageControlsValidate();
        }

        private void txtyopos_TextChanged(object sender, EventArgs e)
        {
           if (Convert.ToString(txtyopos.Text.Trim()) !="")
            {
                var heightmeasure = (Convert.ToInt32(txtdesignerheght.Text) - Convert.ToInt32(txtyopos.Text)) / 2;
                var hd = 0.010416f * heightmeasure;
                txtyposimg.Text = Math.Round(hd, 2).ToString();              
            }
           else
            {
                txtyposimg.Text = "";
            }
            AddimageControlsValidate();

        }

        private void cmbdatasource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbdatasource.SelectedIndex == 0)
            {
                txtbrowsefilepath.Enabled = true;
                btnbrowseimage.Enabled = true;
                txtbrowsefilepath.Text = "";
                txtaddimgwidth.Text = "";
                txtaddimgheight.Text = "";
            }
            else
            {
                txtbrowsefilepath.Enabled = false;
                btnbrowseimage.Enabled = false;
                System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\"));
                if (dirtransxml.Exists)
                {
                    txtbrowsefilepath.Text = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "SampleImage.jpg");
                }
                Image originalSize = Image.FromFile(txtbrowsefilepath.Text.ToString());

                lintActualwidth = 1;
                lintActualHeight = 1;

                txtaddimgwidth.Text = Convert.ToString(lintActualwidth);
                txtaddimgheight.Text = Convert.ToString(lintActualHeight);
            }
        }

        private void RadioUseFixedImage_CheckedChanged(object sender, EventArgs e)
        {
            cmbdatasource.Enabled = false;
            txtbrowsefilepath.Enabled = true;
            btnbrowseimage.Enabled = true;
        }

        private void RadioVariableImage_CheckedChanged(object sender, EventArgs e)
        {
            cmbdatasource.Enabled = true;
            txtbrowsefilepath.Enabled = false;
            btnbrowseimage.Enabled = false;
        }
        
    }
}
