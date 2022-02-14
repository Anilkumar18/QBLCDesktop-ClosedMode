using NReco.PdfRenderer;
using QBLC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using Telerik.WinControls.UI;

namespace LabelConnector
{
    public partial class FrmLabelDesign : Form
    {
        //FrmAddEditField objfrmaddeditproperties = FrmAddEditField.GetInstance();
        public string lstrtemplateparam = string.Empty;
        string mnunewimgpath = string.Empty;
        string mnuopenimgpath = string.Empty;
        string mnusyncimagepath = string.Empty;
        string mnuimgimportpath = string.Empty;
        string mnusaveaspath = string.Empty;
        string mnusavepath = string.Empty;
        string mnueditpath = string.Empty;
        string mnudeletetpath = string.Empty;
        string mnupreviewpath = string.Empty;
        string mnupclosepath = string.Empty;
        string Activefield = string.Empty;
        string mnupclosedesignerpath = string.Empty;
        private bool btnTextType = false;
        private bool btnBarcodeType = false;
        private bool btnImageType = false;
        private bool btnLineType = false;
        QBConfiguration lobjQBConfiguration;
        public delegate void delPassData(String lstrTemplateName, String lstrTransType, String lstrwidth, String lstrheight, String FieldType);
        public delegate void delHeaderPassData(String lstrTemplateName);
        public delegate void delHeaderPassEditData(String lstrmode, String lstrTemplateName, String lstrTransType, String lstrwidth, String lstrheight);
        public delegate void delSaveasData(String lstrmode, String lstrTemplateName);
        public delegate void delImageData(String lstrTemplateName, String lstreditmode, String lstrwidth, String lstrheight);
        public int openLabelStatus = 0;
        private static bool _moving;
        private static bool _moveIsInterNal;
        private static Point _cursorStartPoint;
        private static bool _resizing;
        private static Size _currentControlStartSize;
        internal static bool MouseIsInLeftEdge { get; set; }
        internal static bool MouseIsInRightEdge { get; set; }
        internal static bool MouseIsInTopEdge { get; set; }
        internal static bool MouseIsInBottomEdge { get; set; }
        internal enum MoveOrResize
        {
            Move,
            Resize,
            MoveAndResize
        }
        internal static MoveOrResize WorkType { get; set; }
        public FrmLabelDesign()
        {
            InitializeComponent();
           
            //New
            //mnunewimgpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "New.png");
            //this.toolStripButton1.Image = Bitmap.FromFile(mnunewimgpath);
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Text = "&New";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            //resize the image of the button to the new size
            int sourceWidth = toolStripButton1.Image.Width;
            int sourceHeight = toolStripButton1.Image.Height;
            Bitmap b = new Bitmap(24, 24);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(toolStripButton1.Image, 0, 0, 24, 24);
            }
            Image NewResizedImg = (Image)b;

            //put the resized image back to the button and change toolstrip's ImageScalingSize property 
            toolStripButton1.Image = NewResizedImg;
            toolStrip1.ImageScalingSize = new Size(24, 24);

            //Open
            //mnuopenimgpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "open.png");
            //this.toolStripButton2.Image = Bitmap.FromFile(mnuopenimgpath);
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Text = "&Open";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            //resize the image of the button to the new size
            int sourceWidth1 = toolStripButton2.Image.Width;
            int sourceHeight1 = toolStripButton2.Image.Height;
            Bitmap c = new Bitmap(24, 24);
            using (Graphics gopen = Graphics.FromImage((Image)c))
            {
                gopen.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gopen.DrawImage(toolStripButton2.Image, 0, 0, 24, 24);
            }
            Image OpenResizedImg = (Image)c;

            //put the resized image back to the button and change toolstrip's ImageScalingSize property 
            toolStripButton2.Image = OpenResizedImg;
            toolStrip1.ImageScalingSize = new Size(24, 24);

            //import button
            //mnuimgimportpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "open.png");
            // mnuimgimportpath = System.Windows.Forms.Application.StartupPath + @"\" + "Images" + "\\" + "import.png";
            //this.toolStripButton10.Image = Bitmap.FromFile(mnuimgimportpath);
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolStripButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Text = "&Open";
            this.toolStripButton10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //resize the image of the button to the new size
            int sourceWidthimport = toolStripButton10.Image.Width;
            int sourceHeightimport = toolStripButton10.Image.Height;
            Bitmap bimport = new Bitmap(24, 24);
            using (Graphics gimp = Graphics.FromImage((Image)bimport))
            {
                gimp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gimp.DrawImage(toolStripButton10.Image, 0, 0, 24, 24);
            }
            Image NewResizedImgimport = (Image)bimport;

            //put the resized image back to the button and change toolstrip's ImageScalingSize property 
            toolStripButton10.Image = NewResizedImgimport;
            toolStrip1.ImageScalingSize = new Size(24, 24);


            //Sync
            //mnusyncimagepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "SyncFields.png");
            //this.toolStripButton3.Image = Bitmap.FromFile(mnusyncimagepath);
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolStripButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Text = "&Sync Fields";
            this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // resize the image of the button to the new size
            int syncsourceWidth = toolStripButton3.Image.Width;
            int syncsourceHeight = toolStripButton3.Image.Height;
            Bitmap d = new Bitmap(24, 24);
            using (Graphics gsync = Graphics.FromImage((Image)d))
            {
                gsync.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gsync.DrawImage(toolStripButton3.Image, 0, 0, 24, 24);
            }
            Image SyncResizedImgopen = (Image)d;

            //put the resized image back to the button and change toolstrip's ImageScalingSize property 
            toolStripButton3.Image = SyncResizedImgopen;
            toolStrip1.ImageScalingSize = new Size(24, 24);

            if (txtdispname.Text == "")
            {
                toolStripButton11.Visible = false;
                toolStripButton4.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = false;
                toolStripButton7.Visible = false;
            }

            //clear
            //mnupclosepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "close.png");
            //this.toolStripButton8.Image = Bitmap.FromFile(mnupclosepath);
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolStripButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Text = "&Close";
            this.toolStripButton8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // resize the image of the button to the new size
            // int syncsaveasWidth = toolStripButton4.Image.Width;
            // int synsaveasHeight = toolStripButton4.Image.Height;
            Bitmap j = new Bitmap(24, 24);
            using (Graphics gclose = Graphics.FromImage((Image)j))
            {
                gclose.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gclose.DrawImage(toolStripButton8.Image, 0, 0, 24, 24);
            }
            Image SyncResizedImgclose = (Image)j;

            //put the resized image back to the button and change toolstrip's ImageScalingSize property 
            toolStripButton8.Image = SyncResizedImgclose;
            toolStrip1.ImageScalingSize = new Size(24, 24);

            //close designer

            //mnupclosedesignerpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "CloseDesigner.png");
            //this.toolStripButton9.Image = Bitmap.FromFile(mnupclosedesignerpath);
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.toolStripButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Text = "&Close Designer";
            this.toolStripButton9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // resize the image of the button to the new size

            Bitmap k = new Bitmap(24, 24);
            using (Graphics gclosedesign = Graphics.FromImage((Image)k))
            {
                gclosedesign.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gclosedesign.DrawImage(toolStripButton9.Image, 0, 0, 24, 24);
            }
            Image SyncResizedImgclosedesigner = (Image)k;

            //put the resized image back to the button and change toolstrip's ImageScalingSize property 
            toolStripButton9.Image = SyncResizedImgclosedesigner;
            toolStrip1.ImageScalingSize = new Size(24, 24);


        }

   
        public FrmLabelDesign(string pstrtemplatename)
        {
            InitializeComponent();
            this.lstrtemplateparam = pstrtemplatename;
        }



        private void btntemplateheadercancel_Click(object sender, EventArgs e)
        {
            //gbcreatetemplate.Visible = false;
            //txttemplatename.Text = "";
            //cmbTransType.SelectedIndex = 0;
            //cmbtemplatelist.SelectedIndex = 0;
            //txttemplateheaderwidth.Text = "";
            //txttemplateheaderheight.Text = "";
            //btnopenAddFielddialog.Visible = false;
            //gvfieldview.Visible = false;
            //txttemplatename.Focus();
        }


        private void FrmLabelDesign_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsTemplateStatus objTemplateStatus = new clsTemplateStatus();
            clsTemplateLabelXmlwork objTemplateXML = new clsTemplateLabelXmlwork();
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TempPath" + "\\" + "TempLastPath" + ".xml");
            if (File.Exists(strStartupPath))
            {
                CheckTemplateSave();
                objTemplateStatus = objTemplateXML.GetTemplateStatus();
                objTemplateStatus.TemplateSave = "0";
                objTemplateStatus.TemplateStatus = "0";
                objTemplateStatus.TemplatePath = objTemplateStatus.TemplatePath;
                objTemplateStatus.TempTemplatePath = objTemplateStatus.TempTemplatePath;
                objTemplateStatus.TemplateMode = objTemplateStatus.TemplateMode;
                objTemplateXML.SaveTemplateStatus(objTemplateStatus);
                if(Globalvariables.PrintTemplateName == Path.GetFileName(objTemplateStatus.TempTemplatePath) && Globalvariables.PrintTemplateStatus == "1")
                {
                    Globalvariables.PrintTemplateStatus = "2";
                    //Globalvariables.PrintTemplateName = "";
                }
                if(! String.IsNullOrWhiteSpace(objTemplateStatus.TempTemplatePath.ToString()))
                {
                    objTemplateXML.DeleteAppTemplate(Path.GetFileNameWithoutExtension(objTemplateStatus.TempTemplatePath));
                    objTemplateXML.DeleteAppTemplate("TempTemplate");
                }                
            }
            
                frmPrintLabel parentForm = (frmPrintLabel)this.MdiParent;
                parentForm.GridPanel = true;
                ((frmPrintLabel)System.Windows.Forms.Application.OpenForms["frmPrintLabel"]).Text = "Accuware-Label Connector";
                this.Hide();
                this.Close();
       

        }


        private void btnopentemplateheaderpart_Click(object sender, EventArgs e)
        {

            //open create new header popup
            //if (ActiveMdiChild != null)
            //    ActiveMdiChild.Close();

            //if (System.Windows.Forms.Application.OpenForms["FrmAddEditTemplateHeader"] == null)
            //{

            //    LabelConnector.FrmAddEditTemplateHeader lobjLabelConnectorSettings = new LabelConnector.FrmAddEditTemplateHeader();

            //    // Create an instance of the delegate
            //    lobjLabelConnectorSettings.passheadercontrol = new FrmAddEditTemplateHeader.PassHeaderControl(PassheaderData);

            //    delHeaderPassData delheader = new delHeaderPassData(lobjLabelConnectorSettings.funheaderData);
            //    delheader(btnopentemplateheaderpart.Text.ToString()); //for add mode

            //    lobjLabelConnectorSettings.ShowInTaskbar = false;

            //    lobjLabelConnectorSettings.ShowDialog();
            //}


        }
        private void PassheaderData(String lstrTemplateName, String pstrtemplateheaderwidth, String pstrtemplateheaderheight, String lstrTransType)
        {
            //display data after saving from poppup
            txtdispname.Text = lstrTemplateName;
            txtdistranstype.Text = lstrTransType;
            txtdispwidth.Text = pstrtemplateheaderwidth;
            txtdispheight.Text = pstrtemplateheaderheight;
            gbshowheaderdata.Visible = true;
            // pnlbtnarray1.Visible = true;
            btnaddtext.Visible = true;
            btnaddbarcode.Visible = true;
            btnAddImage.Visible = true;
            btnAddLine.Visible = true;
            btntestprint.Visible = true;
            gvfieldview.Visible = false; //for test
                                         // gbbuttonlist.Visible = true;
            gbtemplatepreview.Visible = false;
            btntestprint.Visible = true;
            // pnlbtnarray1.Location = new Point(6, 145);

            //show menu when template is visible
            if (txtdispname.Text != "")
            {
                toolStripButton4.Visible = true;
                //SaveAs
               // mnusaveaspath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "saveas24.png");
               // this.toolStripButton4.Image = Bitmap.FromFile(mnusaveaspath);
                this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton4.Name = "toolStripButton4";
                this.toolStripButton4.Text = "&SaveAs";
                this.toolStripButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;         

                // resize the image of the button to the new size
                int syncsaveasWidth = toolStripButton4.Image.Width;
                int synsaveasHeight = toolStripButton4.Image.Height;
                Bitmap e = new Bitmap(24, 24);
                using (Graphics gsync = Graphics.FromImage((Image)e))
                {
                    gsync.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gsync.DrawImage(toolStripButton4.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgsaveas = (Image)e;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton4.Image = SyncResizedImgsaveas;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton4.Visible = false;
            }
            if (txtdispname.Text != "")
            {
                toolStripButton11.Visible = true;
                //SaveAs
                //mnusavepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "save24.png");
                //this.toolStripButton11.Image = Bitmap.FromFile(mnusavepath);
                this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton11.Name = "toolStripButton11";
                this.toolStripButton11.Text = "&Save";
                this.toolStripButton11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                // resize the image of the button to the new size
                int syncsaveasWidth = toolStripButton11.Image.Width;
                int synsaveasHeight = toolStripButton11.Image.Height;
                Bitmap e = new Bitmap(24, 24);
                using (Graphics gsync = Graphics.FromImage((Image)e))
                {
                    gsync.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gsync.DrawImage(toolStripButton11.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgsaveas = (Image)e;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton11.Image = SyncResizedImgsaveas;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton11.Visible = false;
            }
            if (txtdispname.Text != "")
            {
                toolStripButton5.Visible = true;
                //Edit
                // mnueditpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "edit.png");
                //this.toolStripButton5.Image = Bitmap.FromFile(mnueditpath);
                this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton5.Name = "toolStripButton5";
                this.toolStripButton5.Text = "&Edit";
                this.toolStripButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                // resize the image of the button to the new size
                // int syncsaveasWidth = toolStripButton4.Image.Width;
                // int synsaveasHeight = toolStripButton4.Image.Height;
                Bitmap f = new Bitmap(24, 24);
                using (Graphics gedit = Graphics.FromImage((Image)f))
                {
                    gedit.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gedit.DrawImage(toolStripButton5.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgedit = (Image)f;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton5.Image = SyncResizedImgedit;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton5.Visible = false;
            }

            //delete
            if (txtdispname.Text != "")
            {
                toolStripButton6.Visible = true;
                // mnudeletetpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "delete.png");
                //this.toolStripButton6.Image = Bitmap.FromFile(mnudeletetpath);
                this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton6.Name = "toolStripButton6";
                this.toolStripButton6.Text = "&Delete";
                this.toolStripButton6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                // resize the image of the button to the new size
                // int syncsaveasWidth = toolStripButton4.Image.Width;
                // int synsaveasHeight = toolStripButton4.Image.Height;
                Bitmap h = new Bitmap(24, 24);
                using (Graphics gdelete = Graphics.FromImage((Image)h))
                {
                    gdelete.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gdelete.DrawImage(toolStripButton6.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgedelete = (Image)h;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton6.Image = SyncResizedImgedelete;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton6.Visible = false;
            }

            //preview
            //if (txtdispname.Text != "")
            //{
            //    toolStripButton7.Visible = true;
            //    mnupreviewpath = System.Windows.Forms.Application.StartupPath + @"\" + "Images" + "\\" + "preview.png";
            //    this.toolStripButton7.Image = Bitmap.FromFile(mnupreviewpath);
            //    this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            //    this.toolStripButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //    this.toolStripButton7.Name = "toolStripButton7";
            //    this.toolStripButton7.Text = "&Preview";
            //    this.toolStripButton7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //    // resize the image of the button to the new size
            //    // int syncsaveasWidth = toolStripButton4.Image.Width;
            //    // int synsaveasHeight = toolStripButton4.Image.Height;
            //    Bitmap i = new Bitmap(24, 24);
            //    using (Graphics gpreview = Graphics.FromImage((Image)i))
            //    {
            //        gpreview.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //        gpreview.DrawImage(toolStripButton7.Image, 0, 0, 24, 24);
            //    }
            //    Image SyncResizedImgepreview = (Image)i;

            //    //put the resized image back to the button and change toolstrip's ImageScalingSize property 
            //    toolStripButton7.Image = SyncResizedImgepreview;
            //    toolStrip1.ImageScalingSize = new Size(24, 24);
            //}
            //else
            //{
            //    toolStripButton7.Visible = false;
            //}

            //toolStripButton7.PerformClick(); //preview
            if (txtdispname.Text != "")
            {
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
                ShowTemplatePdf(objfieldlist);
            }

        }

        private void PassheadereditData(String lstrTemplateName, String pstrtemplateheaderwidth, String pstrtemplateheaderheight, String lstrTransType)
        {
            //display data after saving from poppup
            txtdispname.Text = lstrTemplateName;
            txtdistranstype.Text = lstrTransType;
            txtdispwidth.Text = pstrtemplateheaderwidth;
            txtdispheight.Text = pstrtemplateheaderheight;
            gbshowheaderdata.Visible = true;
            // pnlbtnarray1.Visible = true; //12
            btnaddtext.Visible = true;
            btnaddbarcode.Visible = true;
            btnAddImage.Visible = true;
            btnAddLine.Visible = true;
            btntestprint.Visible = true;
          
            //gbtemplatepreview.Visible = false;
            //show template
            //toolStripButton7.PerformClick(); //preview
            if (txtdispname.Text != "")
            {
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
                ShowTemplatePdf(objfieldlist);
            }

        }

        private void PassheadersaveasData(String lstrTemplateName)
        {
            clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
            var headerfieldlist = lobjtemplatenames.GetTemplateHeaderInfo(lstrTemplateName);

            foreach (QuickBooksField fields in headerfieldlist)
            {
                txtdispname.Text = lstrTemplateName;
                if (fields.ItemFieldId == 1)
                {
                    txtdistranstype.Text = fields.ItemFieldName;
                }
                else if (fields.ItemFieldId == 2)
                {
                    txtdispwidth.Text = fields.ItemFieldName;
                }
                else if (fields.ItemFieldId == 3)
                {
                    txtdispheight.Text = fields.ItemFieldName;
                }

            }
            gvfieldview.Visible = true; //for test
            if (!gvfieldview.Columns.Contains("FieldName") && !gvfieldview.Columns.Contains("delete") && !gvfieldview.Columns.Contains("edit") && !gvfieldview.Columns.Contains("Duplicate"))
            {
                InitGrid();
            }
            gvfieldview.AutoGenerateColumns = false;
            fillpropertyfieldgrid(lstrTemplateName);
            //display data after saving from poppup
            gbshowheaderdata.Visible = true;
            // pnlbtnarray1.Visible = true;
            btnaddtext.Visible = true;
            btnaddbarcode.Visible = true;
            btnAddImage.Visible = true;
            btnAddLine.Visible = true;
            btntestprint.Visible = true;
           
            //gbtemplatepreview.Visible = false;
            //show template
            //toolStripButton7.PerformClick(); //preview
            if (txtdispname.Text != "")
            {
                List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
                ShowTemplatePdf(objfieldlist);
            }
        }


        private void FrmLabelDesign_Load(object sender, EventArgs e)
        {          
             pnlselecttemplate.Visible = false;
            gbtemplatepreview.Visible = false;
            btnopenAddFielddialog.Visible = false;
            gvfieldview.Visible = false;
            // gbbuttonlist.Visible = false;
            clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
            // string lsp= clsTemplateLabelXmlwork.SetValuesForTransTypetest;
            if (!string.IsNullOrWhiteSpace(this.lstrtemplateparam))
            {

                cmbTransType.DataSource = GetTransactionTypeList();
                cmbTransType.DisplayMember = "ItemFieldName";
                cmbTransType.ValueMember = "ItemFieldId";
                var headerfieldlist = lobjtemplatenames.GetTemplateHeaderInfo(this.lstrtemplateparam);
                txttemplatename.Text = this.lstrtemplateparam;
                foreach (QuickBooksField fields in headerfieldlist)
                {
                    //txttemplatename.Text = cmbtemplatelist.Text.ToString();
                    if (fields.ItemFieldId == 1)
                    {
                        cmbTransType.Text = fields.ItemFieldName;
                    }
                    else if (fields.ItemFieldId == 2)
                    {
                        txttemplateheaderwidth.Text = fields.ItemFieldName;
                    }
                    else if (fields.ItemFieldId == 3)
                    {
                        txttemplateheaderheight.Text = fields.ItemFieldName;
                    }

                }

                gbcreatetemplate.Visible = true;
                pnlheadercontrols.Location = new Point(17, 61);
                pnlheadercontrols.Visible = true;

                //if (gvfieldview.Rows.Count == 0)
                if (!gvfieldview.Columns.Contains("FieldName") && !gvfieldview.Columns.Contains("delete") && !gvfieldview.Columns.Contains("edit") && !gvfieldview.Columns.Contains("Duplicate"))
                {
                    InitGrid();
                }
                gvfieldview.AutoGenerateColumns = false;
                fillpropertyfieldgrid(this.lstrtemplateparam); //show template field records


            }


        }
        private void InitGrid()
        {
            //DataGridViewLinkColumn col = new DataGridViewLinkColumn();
            //col.DataPropertyName = "FieldName";
            //col.Name = "FieldName";
            //col.HeaderText = "Field Name";

            //gvfieldview.Columns.Add(col);

            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "FieldName";
            col.Name = "FieldName";
            col.Width = 129;
            col.HeaderText = "Field Name";

            gvfieldview.Columns.Add(col);


            DataGridViewTextBoxColumn colfieldtype = new DataGridViewTextBoxColumn();

            colfieldtype.DataPropertyName = "fieldtype";
            colfieldtype.Name = "fieldtype";
            colfieldtype.HeaderText = "Field Type";
            colfieldtype.Width = 50;
            gvfieldview.Columns.Add(colfieldtype);


            DataGridViewTextBoxColumn colfieldtypex = new DataGridViewTextBoxColumn();

            colfieldtypex.DataPropertyName = "xposition";
            colfieldtypex.Name = "xposition";
            colfieldtypex.HeaderText = "X";
            colfieldtypex.Width = 30;
            gvfieldview.Columns.Add(colfieldtypex);
            colfieldtypex.Visible = false;

            DataGridViewTextBoxColumn colfieldtypey = new DataGridViewTextBoxColumn();
            colfieldtypey.DataPropertyName = "yposition";
            colfieldtypey.Name = "yposition";
            colfieldtypey.HeaderText = "Y";
            colfieldtypey.Width = 30;
            gvfieldview.Columns.Add(colfieldtypey);
            colfieldtypey.Visible = false;

            DataGridViewTextBoxColumn colfielddatasource = new DataGridViewTextBoxColumn();
            colfielddatasource.DataPropertyName = "datasource";
            colfielddatasource.Name = "datasource";
            colfielddatasource.HeaderText = "Data Source";
            colfielddatasource.Width = 90;
            gvfieldview.Columns.Add(colfielddatasource);
     

            //DataGridViewLinkColumn coldel = new DataGridViewLinkColumn();
            //coldel.DataPropertyName = "delete";
            //coldel.Name = "delete";
            //gvfieldview.Columns.Add(coldel);
            ///////
            //DataGridViewCustomButtonColumn coldelete = new DataGridViewCustomButtonColumn();
            //coldelete.Width = 30;
            //coldelete.Name = "delete";
            //coldelete.HeaderText = "";
            //coldelete.CellTemplate.Style.Font = new Font("Verdana", 28);

            //coldelete.Text = "Delete";
            //gvfieldview.Columns.Add(coldelete);

            //coldelete.UseColumnTextForButtonValue = true;

            DataGridViewImageColumn imgedit = new DataGridViewImageColumn();
            imgedit.Name = "edit";
            imgedit.HeaderText = "";

            imgedit.Width = 30;
            Image imageeditnew  =  new Bitmap(Properties.Resources.editfield);
            //Image imageeditnew = Image.FromFile(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "editfield.png"));
            //Image imageeditnew = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "editfield.png");
            imgedit.Image = imageeditnew;

            imgedit.ToolTipText = "edit field";
            gvfieldview.Columns.Add(imgedit);


            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "delete";
            img.HeaderText = "";

            img.Width = 30;
            Image image = new Bitmap(Properties.Resources.Trash);
           // Image image = Image.FromFile(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "Trash.png"));
            img.Image = image;

            img.ToolTipText = "Delete field";
            gvfieldview.Columns.Add(img);



            DataGridViewLinkColumn colid = new DataGridViewLinkColumn();
            colid.DataPropertyName = "Id";
            colid.Name = "Id";
            gvfieldview.Columns.Add(colid);
            colid.Visible = false;

            DataGridViewImageColumn imgcopy = new DataGridViewImageColumn();
            imgcopy.Name = "Duplicate";
            imgcopy.HeaderText = "";
            imgcopy.Width = 30;
            Image imagecopy = new Bitmap(Properties.Resources.copy);
          //  Image imagecopy = Image.FromFile(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "copy.png"));
            imgcopy.Image = imagecopy;
            imgcopy.ToolTipText = "Duplicate field";
            gvfieldview.Columns.Add(imgcopy);
        }

        private void fillpropertyfieldgrid(string pstrtemplatename)
        {
            gvfieldview.Visible = true;
            clsTemplateLabelXmlwork lobjtemplatenames1 = new clsTemplateLabelXmlwork();
            var objfieldlist = lobjtemplatenames1.GetFieldPropertiesList(pstrtemplatename, string.Empty);

            gvfieldview.Rows.Clear();
            //gvfieldview.AutoGenerateColumns = false;
            //DataGridViewLinkColumn col = new DataGridViewLinkColumn();
            //col.DataPropertyName = "FieldName";
            //col.Name = "FieldName";
            //gvfieldview.Columns.Add(col);

            int i = 0;
            if (objfieldlist.Count > 0)
            {

                foreach (clsTemplateLabelXmlwork objclsfield in objfieldlist)
                {
                    gvfieldview.Rows.Add();
                    gvfieldview.Rows[i].Cells["fieldname"].Value = objclsfield.fieldname.ToString();
                    gvfieldview.Rows[i].Cells["fieldtype"].Value = objclsfield.fieldtype.ToString();          
                    if (objclsfield.fieldtype.ToString().ToLower()== "text")
                    {
                        gvfieldview.Rows[i].Cells["datasource"].Value = Convert.ToString(objclsfield.datasource);
                    }else
                    {
                        gvfieldview.Rows[i].Cells["datasource"].Value = Convert.ToString(objclsfield.datasourcetext);
                    }
                    

                    gvfieldview.Rows[i].Cells["xposition"].Value = objclsfield.xoriginalposition.ToString();
                    gvfieldview.Rows[i].Cells["yposition"].Value = objclsfield.yoriginalposition.ToString();
                    //Image img = Properties.Resources.Trash;
                    // gvfieldview.Rows[i].Cells["delete"].Value = img;
                    gvfieldview.Rows[i].Cells["Id"].Value = objclsfield.Id.ToString();

                    i++;
                }
            }
            else
            {
                gvfieldview.Visible = false;
            }
        }

        private void fillcopypropertyfieldgrid(string pstrtemplatename)
        {
            gvfieldview.Visible = true;
            clsTemplateLabelXmlwork lobjtemplatenames1 = new clsTemplateLabelXmlwork();
            var objfieldlist = lobjtemplatenames1.GetFieldPropertiesList(pstrtemplatename, string.Empty);

            gvfieldview.Rows.Clear();
            //gvfieldview.AutoGenerateColumns = false;
            //DataGridViewLinkColumn col = new DataGridViewLinkColumn();
            //col.DataPropertyName = "FieldName";
            //col.Name = "FieldName";
            //gvfieldview.Columns.Add(col);

            int i = 0;
            if (objfieldlist.Count > 0)
            {

                foreach (clsTemplateLabelXmlwork objclsfield in objfieldlist)
                {
                    gvfieldview.Rows.Add();
                    gvfieldview.Rows[i].Cells["fieldname"].Value = objclsfield.fieldname.ToString();
                    gvfieldview.Rows[i].Cells["fieldtype"].Value = objclsfield.fieldtype.ToString();
                    if (objclsfield.fieldtype.ToString().ToLower() == "text")
                    {
                        gvfieldview.Rows[i].Cells["datasource"].Value = Convert.ToString(objclsfield.datasource);
                    }
                    else
                    {
                        gvfieldview.Rows[i].Cells["datasource"].Value = Convert.ToString(objclsfield.datasourcetext);
                    }


                    gvfieldview.Rows[i].Cells["xposition"].Value = objclsfield.xoriginalposition.ToString();
                    gvfieldview.Rows[i].Cells["yposition"].Value = objclsfield.yoriginalposition.ToString();
                    //Image img = Properties.Resources.Trash;
                    // gvfieldview.Rows[i].Cells["delete"].Value = img;
                    gvfieldview.Rows[i].Cells["Id"].Value = objclsfield.Id.ToString();

                    i++;
                }
            }
            else
            {
                gvfieldview.Visible = false;
            }
        }

        private void btntemplateheaderedit_Click(object sender, EventArgs e)
        {
            //clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
            //string strStartupPath = System.Windows.Forms.Application.StartupPath + @"\" + "TemplateImageslist" + "\\";

            //pnlselecttemplate.Visible = true;
            //pnlheadercontrols.Visible = false;
            //gbcreatetemplate.Visible = true;
            //pnlheadercontrols.Location = new Point(17, 107);

            ////Get Template name list and bind combobox
            //cmbtemplatelist.DataSource =lobjtemplatenames.GetTemplateNameList();
            //cmbtemplatelist.DisplayMember = "ItemFieldName";
            //cmbtemplatelist.ValueMember = "ItemFieldId";pri

            //cmbTransType.DataSource = GetTransactionTypeList();
            //cmbTransType.DisplayMember = "ItemFieldName";
            //cmbTransType.ValueMember = "ItemFieldId";

            //lbltemplateheadertext.Text = "Edit Template";


            //cmbtemplatelist.SelectedIndex = 0;
            //txttemplatename.Text = "";
            //txttemplateheaderwidth.Text = "";
            //txttemplateheaderheight.Text = "";
            //txttemplatename.Focus();
            //////
            //label4.Visible = true;
            //cmbTransType.Visible = true;
            //lbltemplateheaderwidth.Visible = true;
            //txttemplateheaderheight.Visible = true;
            //txttemplateheaderwidth.Visible = true;
            //lbltemplateheaderheight.Visible = true;
            //btnopenAddFielddialog.Visible = true;
            //gvfieldview.Rows.Clear();
            //gvfieldview.Visible = false;

            //open header data form in edit view

            //if (ActiveMdiChild != null)
            //    ActiveMdiChild.Close();

            //if (System.Windows.Forms.Application.OpenForms["FrmAddEditTemplateHeader"] == null)
            //{

            //    LabelConnector.FrmAddEditTemplateHeader lobjLabelConnectorSettings = new LabelConnector.FrmAddEditTemplateHeader();

            //    // Create an instance of the delegate
            //    lobjLabelConnectorSettings.passheadercontrol = new FrmAddEditTemplateHeader.PassHeaderControl(PassheadereditData);

            //    delHeaderPassEditData deleditheader = new delHeaderPassEditData(lobjLabelConnectorSettings.funheaderEditData);
            //    deleditheader(btntemplateheaderedit.Text.ToString(),txtdispname.Text.ToString(),txtdistranstype.Text.ToString(),txtdispwidth.Text.ToString(),txtdispheight.Text.ToString()); //for edit mode

            //    lobjLabelConnectorSettings.ShowInTaskbar = false;
            //    lobjLabelConnectorSettings.Text = "Edit Template";

            //    lobjLabelConnectorSettings.ShowDialog();
            //}




        }



        public List<QuickBooksField> GetTransactionTypeList()
        {

            //Trans  Standard Fields
            List<QuickBooksField> objTransTypevalues = new List<QuickBooksField>();
            objTransTypevalues.Add(new QuickBooksField(0, "---Select Transaction Type---"));
            objTransTypevalues.Add(new QuickBooksField(1, "Item list"));
            objTransTypevalues.Add(new QuickBooksField(2, "Invoice"));
            objTransTypevalues.Add(new QuickBooksField(3, "Sales Order"));
            objTransTypevalues.Add(new QuickBooksField(4, "Purchase Order"));
            return objTransTypevalues;
        }
        //public List<QuickBooksField> GetTemplateList()
        //{

        //    //Trans  Standard Fields
        //    List<QuickBooksField> objTemplatelistvalues = new List<QuickBooksField>();
        //    objTemplatelistvalues.Add(new QuickBooksField(0, "---Select Template---"));
        //    objTemplatelistvalues.Add(new QuickBooksField(1, "Alyx Testing"));

        //    return objTemplatelistvalues;
        //}

        private void cmbtemplatelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsTemplateLabelXmlwork lobjtemplateheaderdetails = new clsTemplateLabelXmlwork();
            List<QuickBooksField> objTemplateInfo = new List<QuickBooksField>();
            if (cmbtemplatelist.SelectedIndex > 0)
            {
                pnlheadercontrols.Visible = true;
                objTemplateInfo = lobjtemplateheaderdetails.GetTemplateHeaderInfo(cmbtemplatelist.Text.ToString());
                if (lbltemplateheadertext.Text.ToString().ToLower() == "edit template" || lbltemplateheadertext.Text.ToString().ToLower() == "add new template")
                {
                    lbltemplatename.Text = "Name:";
                }
                else
                {
                    lbltemplatename.Text = "Save As Name:";

                }

                foreach (QuickBooksField templateinfo in objTemplateInfo)
                {
                    txttemplatename.Text = cmbtemplatelist.Text.ToString();
                    if (templateinfo.ItemFieldId == 1)
                    {
                        cmbTransType.Text = templateinfo.ItemFieldName;
                    }
                    else if (templateinfo.ItemFieldId == 2)
                    {
                        txttemplateheaderwidth.Text = templateinfo.ItemFieldName;
                    }
                    else if (templateinfo.ItemFieldId == 3)
                    {
                        txttemplateheaderheight.Text = templateinfo.ItemFieldName;
                    }

                }

                if (lbltemplateheadertext.Text.ToString().ToLower() == "edit template")
                {
                    var objfieldexist = lobjtemplateheaderdetails.GetFieldPropertiesList(cmbtemplatelist.Text.ToString(), string.Empty);
                    if (objfieldexist.Count > 0)
                    {
                        if (!gvfieldview.Columns.Contains("FieldName") && !gvfieldview.Columns.Contains("delete") && !gvfieldview.Columns.Contains("edit"))
                        {

                            InitGrid();
                        }
                        gvfieldview.AutoGenerateColumns = false;
                        //bind grid with data
                        fillpropertyfieldgrid(cmbtemplatelist.Text.ToString());
                    }
                    else
                    {
                        gvfieldview.Visible = false;
                    }
                }
                else if (lbltemplateheadertext.Text.ToString().ToLower() == "save as template")
                {
                    txttemplatename.Text = "";
                }



            }
            else
            {
                pnlheadercontrols.Visible = false;
                gvfieldview.Visible = false;
            }

        }




        private void btnopenAddFielddialog_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            if (System.Windows.Forms.Application.OpenForms["FrmAddEditField"] == null)
            {

                // LabelConnector.FrmAddEditField lobjLabelConnectorSettings = new LabelConnector.FrmAddEditField(txttemplatename.Text.ToString().Trim(),cmbTransType.Text.ToString());
                LabelConnector.FrmAddEditField lobjLabelConnectorSettings = new LabelConnector.FrmAddEditField(txttemplatename.Text.ToString().Trim(), cmbTransType.Text.ToString());


                // Create an instance of the delegate
                lobjLabelConnectorSettings.passControl = new FrmAddEditField.PassControl(PassData);
                //PassTemplateVal = txtForm1.Text.ToString();

                delPassData del = new delPassData(lobjLabelConnectorSettings.funData);
                del(txttemplatename.Text.ToString().Trim(), cmbTransType.Text.ToString(), txttemplateheaderwidth.Text.ToString(), txttemplateheaderheight.Text.ToString(), "");
                //clsTemplateLabelXmlwork.SetValuesForTransType = "homescreen";
                lobjLabelConnectorSettings.ShowInTaskbar = false;
                lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();
                lobjLabelConnectorSettings.ShowDialog();
            }
        }

        //show image on pdf
        private void PassDataimg(String lstrTemplateName, String lstrTransType)
        {

            // pnlbtnarray1.Visible = false;
            btnaddtext.Visible = false;
            btnaddbarcode.Visible = false;
            btnAddImage.Visible = false;
            btnAddLine.Visible = false;
            btntestprint.Visible = false;
            gvfieldview.Visible = true; //for test

            if (!gvfieldview.Columns.Contains("FieldName") && !gvfieldview.Columns.Contains("delete") && !gvfieldview.Columns.Contains("edit") && !gvfieldview.Columns.Contains("Duplicate"))
            {
                InitGrid();
            }
            gvfieldview.AutoGenerateColumns = false;
            fillpropertyfieldgrid(lstrTemplateName);
            // pnlbtnarray1.Visible = true;
            btnaddtext.Visible = true;
            btnaddbarcode.Visible = true;
            btnAddImage.Visible = true;
            btnAddLine.Visible = true;
            btntestprint.Visible = true;
           
            btntestprint.Visible = true; // show testprint button

            if (txtdispname.Text != "")
            {
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
                ShowTemplatePdf(objfieldlist);
            }

        }

        private void PassData(String lstrTemplateName, String lstrTransType)
        {
            
            //  pnlbtnarray1.Visible = false;
            btnaddtext.Visible = false;
            btnaddbarcode.Visible = false;
            btnAddImage.Visible = false;
            btnAddLine.Visible = false;
            btntestprint.Visible = false;
            gvfieldview.Visible = true; //for test

            if (!gvfieldview.Columns.Contains("FieldName") && !gvfieldview.Columns.Contains("delete") && !gvfieldview.Columns.Contains("edit") && !gvfieldview.Columns.Contains("Duplicate"))
            {
                InitGrid();
            }
            gvfieldview.AutoGenerateColumns = false;
            fillpropertyfieldgrid(lstrTemplateName);
            // pnlbtnarray1.Visible = true;

            btnaddtext.Visible = true;
            btnaddbarcode.Visible = true;
            btnAddImage.Visible = true;
            btnAddLine.Visible = true;
            btntestprint.Visible = true;
           

            //pnlbtnarray1.Location = new Point(10, 300);
            //btnpreview.Enabled = true;

            // ShowTemplatePdf();

            btntestprint.Visible = true; // show testprint button

            //  toolStripButton7.PerformClick(); //preview
            if (txtdispname.Text != "")
            {
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
                ShowTemplatePdf(objfieldlist);
            }

           
        }

        private void PasscopyData()
        {

            //  pnlbtnarray1.Visible = false;
            btnaddtext.Visible = false;
            btnaddbarcode.Visible = false;
            btnAddImage.Visible = false;
            btnAddLine.Visible = false;
            btntestprint.Visible = false;
            gvfieldview.Visible = true; //for test

            if (!gvfieldview.Columns.Contains("FieldName") && !gvfieldview.Columns.Contains("delete") && !gvfieldview.Columns.Contains("edit") && !gvfieldview.Columns.Contains("Duplicate"))
            {
                InitGrid();
            }
            gvfieldview.AutoGenerateColumns = false;
            fillcopypropertyfieldgrid(txtdispname.Text);
            // pnlbtnarray1.Visible = true;

            btnaddtext.Visible = true;
            btnaddbarcode.Visible = true;
            btnAddImage.Visible = true;
            btnAddLine.Visible = true;
            btntestprint.Visible = true;


            //pnlbtnarray1.Location = new Point(10, 300);
            //btnpreview.Enabled = true;

            // ShowTemplatePdf();

            btntestprint.Visible = true; // show testprint button

            //  toolStripButton7.PerformClick(); //preview
            if (txtdispname.Text != "")
            {
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
                ShowTemplatePdf(objfieldlist);
            }


        }


        //private void btnpreview_Click(object sender, EventArgs e)
        //{
        //    //gbtemplatepreview.Visible = !gbtemplatepreview.Visible;
        //    gbtemplatepreview.Visible = true;
        //    //Image image = Image.FromFile(@"C:\Accuware\Blue Wire2.jpeg");
        //    //// Set the PictureBox image property to this image.

        //    //pictureBox1.Image = image;
        //    //pictureBox1.Height = image.Height;
        //    //pictureBox1.Width = image.Width;

        //    //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        //    //////////////////////
        //    //string Filepath = Application.StartupPath + "\\" + "Blue Wire1.pdf";

        //    //var pdfToImg = new NReco.PdfRenderer.PdfToImageConverter();
        //    //pdfToImg.ScaleTo = 400; // fit 200x200 box
        //    //pdfToImg.GenerateImage(Filepath, 1, ImageFormat.Jpeg, "Sample1.jpg");

        //    //----------Convert Pdf to Image and show Image in PictureBox
        //    //string Filepath = string.Empty;


        //    // if (!Directory.Exists("PdfImagesList"))
        //    //    Directory.CreateDirectory("PdfImagesList");
        //    //if(File.Exists(System.Windows.Forms.Application.StartupPath + @"\" + "PdfImagesList" + "\\" + txttemplatename.Text.ToString().Trim() + ".Jpeg"))
        //    //{
        //    //    File.Delete(System.Windows.Forms.Application.StartupPath + @"\" + "PdfImagesList" + "\\" + txttemplatename.Text.ToString().Trim() + ".Jpeg");
        //    //}
        //    //if (cmbtemplatelist.SelectedIndex > 0)
        //    //{
        //    //    Filepath = System.Windows.Forms.Application.StartupPath + @"\" + "ZPLFormat" + "\\" + cmbtemplatelist.Text.ToString() + ".pdf";
        //    //}
        //    //else
        //    //{
        //    //    Filepath = System.Windows.Forms.Application.StartupPath + @"\" + "ZPLFormat" + "\\" + txttemplatename.Text.ToString().Trim() + ".pdf";
        //    //}
        //    //if (!string.IsNullOrWhiteSpace(Filepath))
        //    //{
        //    //    //image with full size
        //    //    var pdfToImage = new PdfToImageConverter();
        //    //    var thumbImg = pdfToImage.GenerateImage(Filepath, 1);
        //    //    // Console.WriteLine("Done: resulting image size is {0}x{1}", thumbImg.Width, thumbImg.Height);

        //    //    var thumbImgH600 = ResizeImage(thumbImg, thumbImg.Width, thumbImg.Height);
        //    //    thumbImgH600.Save(System.Windows.Forms.Application.StartupPath + @"\" + "PdfImagesList" + "\\" +  txttemplatename.Text.ToString().Trim() + ".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        //    //}

        //    // string imgpath = Application.StartupPath + @"\" + "PdfImagesList" + "\\" + txtdispname.Text.ToString().Trim() + ".Jpeg";
        //    string imgpath = System.Windows.Forms.Application.StartupPath + @"\" + "PdfImagesList" + "\\" + txtdispname.Text.ToString().Trim() + "\\" + txtdispname.Text.ToString().Trim() + ".Tiff";

        //    try
        //    {
        //        //pictureBox1.Image = null;
        //        if (File.Exists(imgpath))
        //        {
        //            Image image = Image.FromFile(imgpath);
        //            // Set the PictureBox image property to this image.
        //            //radDiagram1 = new Telerik.WinControls.UI.RadDiagram();
        //            radDiagram1.Height = image.Height;
        //            radDiagram1.Width = image.Width;

        //            for (int i = 0; 1 <= radDiagram1.Controls.Count; i++)
        //            {
        //                radDiagram1.Controls.RemoveAt(radDiagram1.Controls.Count - 1);
        //            }

        //            //foreach (clsTemplateLabelXmlwork item in objfieldlist)
        //            //{
        //            //    AddNewLabel(item);
        //            //}

        //            //panel1.AutoScrollPosition = new Point(Math.Abs(300), Math.Abs(400));
        //        }
        //        else
        //        {
        //            gbtemplatepreview.Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    //File.Delete(imgpath);  //works


        //    //if (File.Exists(imgpath))
        //    //{
        //    //    pictureBox1.Image = null;
        //    //    gbtemplatepreview.Visible = !gbtemplatepreview.Visible;
        //    //    Image im = GetCopyImage(imgpath);
        //    //    pictureBox1.Image = im;
        //    //    File.Delete(imgpath);
        //    //}
        //    // btnpreview.Enabled = false;





        //    //---------
        //    //Get no of page of pdf & print multiple pages in pdf
        //    //        var pdfInfo = new PdfInfo();
        //    //        var testPdfInfo = pdfInfo.GetPdfInfo(Filepath);
        //    //        int pagecount;
        //    //        pagecount = testPdfInfo.Pages;
        //    //        var pdfToImage = new PdfToImageConverter();
        //    //        var fileNames = pdfToImage.GenerateImages(Filepath,
        //    //1, pagecount,  // render from pages 1-7
        //    //ImageFormat.Png, @"C:\\Accuware\\");


        //}

        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }

        public static Image ResizeImage(Image img, int maxWidth, int maxHeight)
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
            var resizedRect = new Rectangle(0, 0, newWidth, newHeight);

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

        public void ControlsValidate()
        {
            btncreatetemplateheader.Enabled = !String.IsNullOrWhiteSpace(txttemplatename.Text) &&
                              !String.IsNullOrWhiteSpace(txttemplateheaderwidth.Text) &&
                              !String.IsNullOrWhiteSpace(txttemplateheaderheight.Text) && cmbTransType.SelectedValue.ToString() != "0";

        }

        private void btncreatetemplateheader_Click(object sender, EventArgs e)
        {
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\" + txttemplatename.Text.ToString().Trim() + ".xml");

            //if (cmbtemplatelist.SelectedIndex == 0 || cmbtemplatelist.SelectedIndex == -1)
            if (lbltemplateheadertext.Text.ToString().ToLower() == "add new template")
            {

                clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork(txttemplatename.Text.ToString(), Convert.ToString(txttemplatename.Text), Convert.ToString(cmbTransType.Text), Convert.ToString(txttemplateheaderwidth.Text), Convert.ToString(txttemplateheaderheight.Text));
                if (File.Exists(strStartupPath))
                {
                    MessageBox.Show("Template name already exist", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttemplatename.Text = "";
                    txttemplatename.Focus();
                    return;
                }
                //Add/update Tempate Header info
                if (lobjTemplatexml.AddUpdateTemplateHeader(lobjTemplatexml))
                {

                    // MessageBox.Show("Template header created sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Read QuickBooks TransType field file

                    //string strTransTypeFilePath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + cmbTransType.Text.ToString()+ ".xml";
                    //List<QuickBooksField> lobjcustomfieldlist = new List<QuickBooksField>();

                    // lobjTemplatexml.Deletecustomfieldxmlnode(strTransTypeFilePath);
                    //lobjcustomfieldlist = lobjTemplatexml.GetItemCustomFieldsList();

                    //lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strTransTypeFilePath);
                    //txttemplatename.Enabled = false;
                    //cmbTransType.Enabled = false;
                    //txttemplateheaderwidth.Enabled = false;
                    //txttemplateheaderheight.Enabled = false;

                    btnopenAddFielddialog.Visible = true;
                }
                else
                {
                    MessageBox.Show("Template failed to insert", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //txttemplatename.Text = "";
                //cmbTransType.SelectedIndex = 0;
                //txttemplateheaderwidth.Text = "";
                //txttemplateheaderheight.Text = "";
                //txttemplatename.Focus();
            }
            else if (lbltemplateheadertext.Text.ToString().ToLower() == "edit template")
            {
                clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork(cmbtemplatelist.Text.ToString(), Convert.ToString(txttemplatename.Text), Convert.ToString(cmbTransType.Text), Convert.ToString(txttemplateheaderwidth.Text), Convert.ToString(txttemplateheaderheight.Text));

                if (File.Exists(strStartupPath))
                {
                    if (cmbtemplatelist.Text.ToString().ToLower().Trim() != txttemplatename.Text.ToString().ToLower().Trim())
                    {
                        MessageBox.Show("Template name already in used", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txttemplatename.Text = "";
                        txttemplatename.Focus();
                        return;
                    }
                }
                //update Tempate Header info
                if (lobjTemplatexml.AddUpdateTemplateHeader(lobjTemplatexml))
                {

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
            else if (lbltemplateheadertext.Text.ToString().ToLower() == "save as template")
            {
                //save as file
                string pdfoldfilepath = string.Empty;
                string pdfnewfilepath = string.Empty;
                pdfoldfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat" + "\\" + cmbtemplatelist.Text.ToString() + ".pdf");
                pdfnewfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat" + "\\" + txttemplatename.Text.ToString().Trim() + ".pdf");
                if (!string.IsNullOrWhiteSpace(pdfnewfilepath))
                {
                    if (!File.Exists(pdfnewfilepath))
                    {
                        System.IO.File.Copy(pdfoldfilepath, pdfnewfilepath);
                        // MessageBox.Show("Save as template sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }

        }

        private void txttemplatename_TextChanged(object sender, EventArgs e)
        {
            ControlsValidate();
        }

        private void cmbTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlsValidate();
        }

        private void txttemplateheaderwidth_TextChanged(object sender, EventArgs e)
        {
            ControlsValidate();
        }

        private void txttemplateheaderheight_TextChanged(object sender, EventArgs e)
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


        private void gvfieldview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string strTransTypeFilePath = string.Empty;
            if (gvfieldview.CurrentCell != null)
            {
                btnTextType = false;
                btnBarcodeType = false;
                btnImageType = false;
                btnLineType = false;
                if (gvfieldview.CurrentCell.ColumnIndex.Equals(6) && e.RowIndex != -1)
                {
                    //delete property field node
                    string lstrcolname = string.Empty;
                    string lstrimgcolname = string.Empty;
                    string delimage = string.Empty;
                    string delresizeimage = string.Empty;
                    string lstrtemplatename = string.Empty;

                    clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
                    DialogResult dr = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        using (new HourGlass())
                        {
                            lstrcolname = Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentCell.RowIndex].Cells["Id"].Value);
                         
                            lobjTemplatexml.DeletePropertiesField(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\" + txtdispname.Text.ToString() + ".xml"), lstrcolname);

                            //Delete Resized images:02-Apr-2019
                            if (Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentCell.RowIndex].Cells["fieldtype"].Value) == "Image" || Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentCell.RowIndex].Cells["fieldtype"].Value) == "Line")
                            {
                                lstrimgcolname = Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentCell.RowIndex].Cells["FieldName"].Value);

                                delimage = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "OriginalImages" + "\\" + txtdispname.Text.ToString());
                                //check dir and image file is exist:Date 14-Oct-2019
                                if (Directory.Exists(delimage))
                                {
                                    string[] files = System.IO.Directory.GetFiles(delimage, "" + lstrimgcolname + ".*");
                                    if (files.Length > 0)
                                    {
                                        foreach (string f in files)
                                        {
                                            System.GC.Collect();
                                            System.GC.WaitForPendingFinalizers();
                                            System.IO.File.Delete(f);
                                        }
                                    }
                                }


                                delresizeimage = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ResizeImages" + "\\" + txtdispname.Text.ToString());
                                if (Directory.Exists(delresizeimage))
                                {
                                    string[] resizefiles = System.IO.Directory.GetFiles(delresizeimage, "" + lstrimgcolname + ".*");
                                    if (resizefiles.Length > 0)
                                    {
                                        foreach (string delfiles in resizefiles)
                                        {
                                            System.GC.Collect();
                                            System.GC.WaitForPendingFinalizers();
                                            System.IO.File.Delete(delfiles);
                                        }
                                    }
                                }

                            }
                            //pdf creatation and image convertion
                            List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                            objfieldlist = lobjTemplatexml.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);

                            //Get property fields list
                            List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();
                            System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
                            if (dirtransxml.Exists)
                            {
                                strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + txtdistranstype.Text.ToString() + ".xml");
                            }
                            else
                            {
                                strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + txtdistranstype.Text.ToString() + ".xml");
                            }
                            if (File.Exists(strTransTypeFilePath))
                            {
                                Itemfieldlist = lobjTemplatexml.GetItemFieldListfromxml(strTransTypeFilePath); //Get field list
                            }
                            //string lstrerror;
                            lobjTemplatexml.CreateUpdateTemplatePDF(txtdispname.Text.ToString(), txtdispwidth.Text.ToString(), txtdispheight.Text.ToString(), string.Empty, txtdistranstype.Text.ToString(), objfieldlist, Itemfieldlist);
                            
                            //bind grid
                            fillpropertyfieldgrid(txtdispname.Text.ToString());

                            //show pdf
                         
                            if (txtdispname.Text != "")
                            {
                                ShowTemplatePdf(objfieldlist);
                            }
                        }

                    }
                    else if (dr == DialogResult.No)
                    {
                        //Nothing to do
                    }
                }
                else if (gvfieldview.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1) //edit
                {

                    if (gvfieldview.CurrentCell != null && gvfieldview.CurrentCell.Value != null)
                        // MessageBox.Show(gvfieldview.CurrentCell.Value.ToString());
                        if (ActiveMdiChild != null)
                            ActiveMdiChild.Close();
                    string lstrcoltype = string.Empty;

                    lstrcoltype = Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentCell.RowIndex].Cells["fieldtype"].Value.ToString().ToLower().Trim());
                    if (lstrcoltype == "image")
                    {
                        //open image edit popup
                        if (System.Windows.Forms.Application.OpenForms["FrmAddImages"] == null)
                        {
                            //Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["Id"].Value);

                            LabelConnector.FrmAddImages lobjLabelConnectorSettings = new LabelConnector.FrmAddImages(txtdispname.Text.ToString().Trim(), Convert.ToDouble(txtdispwidth.Text), Convert.ToDouble(txtdispheight.Text), Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["Id"].Value), txtdistranstype.Text.ToString(), gvfieldview.CurrentCell.Value.ToString(), Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value));
                            // Create an instance of the delegate

                            lobjLabelConnectorSettings.passControlimg = new FrmAddImages.PassControlimg(PassDataimg);
                            lobjLabelConnectorSettings.ShowInTaskbar = false;
                            lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();
                            lobjLabelConnectorSettings.ShowDialog();

                        }

                    }
                    else if (lstrcoltype == "barcode")
                    {
                        if (System.Windows.Forms.Application.OpenForms["FrmAddEditFieldBarCode"] == null)
                        {
                            //Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["Id"].Value);

                            LabelConnector.FrmAddEditFieldBarCode lobjLabelConnectorSettingsBarCode = new LabelConnector.FrmAddEditFieldBarCode(txtdispname.Text.ToString().Trim(), Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["Id"].Value), txtdistranstype.Text.ToString(), gvfieldview.CurrentCell.Value.ToString(), Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value), Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldtype"].Value));
                            // Create an instance of the delegate

                            lobjLabelConnectorSettingsBarCode.passControl = new FrmAddEditFieldBarCode.PassControl(PassData);
                            lobjLabelConnectorSettingsBarCode.ShowInTaskbar = false;
                            lobjLabelConnectorSettingsBarCode.designerHeight = radDiagram1.Height.ToString();
                            lobjLabelConnectorSettingsBarCode.ShowDialog();

                        }
                    }
                    else if (lstrcoltype == "text")
                    {

                        LabelConnector.FrmAddEditField lobjLabelConnectorSettings = new LabelConnector.FrmAddEditField(txtdispname.Text.ToString().Trim(), Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["Id"].Value), txtdistranstype.Text.ToString(), gvfieldview.CurrentCell.Value.ToString(), Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value), Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldtype"].Value));
                        // Create an instance of the delegate

                        lobjLabelConnectorSettings.passControl = new FrmAddEditField.PassControl(PassData);
                        lobjLabelConnectorSettings.ShowInTaskbar = false;
                        lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();
                        lobjLabelConnectorSettings.ShowDialog();


                    }
                    else if (lstrcoltype == "line")
                    {
                        //open image edit popup
                        if (System.Windows.Forms.Application.OpenForms["FrmAddLineProperty"] == null)
                        {
                            LabelConnector.FrmAddLineProperty lobjLabelConnectorSettings = new LabelConnector.FrmAddLineProperty(txtdispname.Text.ToString().Trim(), Convert.ToDouble(txtdispwidth.Text), Convert.ToDouble(txtdispheight.Text), Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["Id"].Value), txtdistranstype.Text.ToString(), gvfieldview.CurrentCell.Value.ToString(), Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value));
                           
                            lobjLabelConnectorSettings.passControl = new FrmAddLineProperty.PassControl(PassDataimg);
                            lobjLabelConnectorSettings.ShowInTaskbar = false;
                            lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();
                            lobjLabelConnectorSettings.ShowDialog();

                        }

                    }


                }

                else if (gvfieldview.CurrentCell.ColumnIndex.Equals(8) && e.RowIndex != -1)
                {
                    clsTemplateLabelXmlwork lobjTemplate = new clsTemplateLabelXmlwork();
                    clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
                    string NewFieldName = "";

                    if (gvfieldview.CurrentCell != null && gvfieldview.CurrentCell.Value != null)
                        // MessageBox.Show(gvfieldview.CurrentCell.Value.ToString());
                        if (ActiveMdiChild != null)
                            ActiveMdiChild.Close();
                    string lstrcoltype = string.Empty;

                    lstrcoltype = Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentCell.RowIndex].Cells["fieldtype"].Value.ToString().ToLower().Trim());
                   

                    List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                    objfieldlist = lobjTemplatexml.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);

           

                    if (lstrcoltype == "image")
                    {
                        //open image edit popup
                        if (System.Windows.Forms.Application.OpenForms["FrmAddImages"] == null)
                        {
                            foreach (clsTemplateLabelXmlwork objfieldvalues in objfieldlist)
                            {
                                if (objfieldvalues.fieldname == Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value))
                                {
                                    
                                    lobjTemplatexml.DuplicateTemplateDetails(objfieldvalues, Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value), string.Empty, string.Empty);
                                }
                                   
                            }
                         
                        }

                    }
                    else if (lstrcoltype == "barcode")
                    {
                        if (System.Windows.Forms.Application.OpenForms["FrmAddEditFieldBarCode"] == null)
                        {
                            foreach (clsTemplateLabelXmlwork objfieldvalues in objfieldlist)
                            {
                                if (objfieldvalues.fieldname == Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value))
                                {
                                    lobjTemplatexml.DuplicateTemplateDetails(objfieldvalues, Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value), objfieldvalues.barcodetype, string.Empty);

                                }
                               
                            }
                        }
                    }
                    else if (lstrcoltype == "text")
                    {
                        foreach (clsTemplateLabelXmlwork objfieldvalues in objfieldlist)
                        {
                            if(objfieldvalues.fieldname == Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value))
                            {
                                lobjTemplatexml.DuplicateTemplateDetails(objfieldvalues, Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value), string.Empty, txtdistranstype.Text.ToLower().Trim());
                            }
                            
                        }
                    }
                    else if (lstrcoltype == "line")
                    {
                        //open image edit popup
                        if (System.Windows.Forms.Application.OpenForms["FrmAddLineProperty"] == null)
                        {
                            foreach (clsTemplateLabelXmlwork objfieldvalues in objfieldlist)
                            {
                                if (objfieldvalues.fieldname == Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value))
                                {

                                    lobjTemplatexml.DuplicateTemplateDetails(objfieldvalues, Convert.ToString(gvfieldview.Rows[gvfieldview.CurrentRow.Index].Cells["fieldname"].Value), string.Empty, string.Empty);
                                }

                            }

                        }

                    }
                    PasscopyData();

                }
            }

        }

        //public string AutoGenerateQuoteNumber()
        //{
        //    string splitQuoteNumber = ""; string newQuoteNumber = "";

        //    var getQuoteNumber = _db.Quotationinfo.OrderByDescending(q => q.QuotationId).FirstOrDefault();
        //    if (getQuoteNumber != null)
        //    {
        //        string getlatestQuoteNumber = Convert.ToString(getQuoteNumber.QuotationName);

        //        char[] chararray = getlatestQuoteNumber.ToCharArray();

        //        for (int i = 5; i < chararray.Length; i++)
        //        {
        //            splitQuoteNumber = splitQuoteNumber + chararray[i];
        //        }
        //        int nextnum = Convert.ToInt32(splitQuoteNumber) + 1;

        //        newQuoteNumber = ("Quote" + nextnum);
        //    }
        //    else
        //    {
        //        newQuoteNumber = "Quote1";
        //    }

        //    return newQuoteNumber;
        //}

    
        private void btnSyncFields_Click(object sender, EventArgs e)
        {
            //string strStartupPath = string.Empty;
            //clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            //List<QuickBooksField> lobjcustomfieldlist = new List<QuickBooksField>();
            //try
            //{
            //    using (new HourGlass())
            //    {

            //       // lobjcustomfieldlist = lobjTemplatexml.GetItemCustomFieldsList();
            //        for (int ifields = 0; ifields < 4; ifields++)
            //        {
            //            switch (ifields)
            //            {
            //                case 0: //Item list
            //                    strStartupPath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + "Item list.xml";
            //                    lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);
            //                    lobjcustomfieldlist = lobjTemplatexml.GetItemCustomFieldsList();
            //                    lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);

            //                    break;
            //                case 1: // Invoice
            //                    strStartupPath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + "Invoice.xml";
            //                    lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);
            //                    lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);

            //                    break;
            //                case 2:  //Sales Order
            //                    strStartupPath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + "Sales Order.xml";
            //                    lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);
            //                    lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);
            //                    break;
            //                case 3: //Purchase Order
            //                    strStartupPath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + "Purchase Order.xml";
            //                    lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);
            //                    lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);
            //                    break;

            //                default:
            //                    break;
            //            }


            //        }

            //    }
            //    MessageBox.Show("Properties Field Sync Sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch(Exception ex)
            //{

            //}

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

        public class DataGridViewCustomButtonColumn : DataGridViewButtonColumn
        {
            public DataGridViewCustomButtonColumn()
            {
                this.CellTemplate = new DataGridViewCustomButtonCell();

            }
        }


        public class DataGridViewCustomButtonCell : DataGridViewButtonCell
        {
            private bool enabledValue;
            public bool Enabled
            {
                get
                {
                    return enabledValue;
                }
                set
                {
                    enabledValue = value;
                }
            }

            // Override the Clone method so that the Enabled property is copied. 
            public override object Clone()
            {
                DataGridViewCustomButtonCell cell =
                    (DataGridViewCustomButtonCell)base.Clone();
                cell.Enabled = this.Enabled;
                return cell;
            }

            // By default, enable the button cell. 
            public DataGridViewCustomButtonCell()
            {
                this.enabledValue = true;
            }

            protected override void Paint(Graphics graphics,
                Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
                DataGridViewElementStates elementState, object value,
                object formattedValue, string errorText,
                DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle,
                DataGridViewPaintParts paintParts)
            {
                // The button cell is disabled, so paint the border,   
                // background, and disabled button for the cell. 
                if (!this.enabledValue)
                {
                    // Draw the cell background, if specified. 
                    if ((paintParts & DataGridViewPaintParts.Background) ==
                        DataGridViewPaintParts.Background)
                    {
                        SolidBrush cellBackground =
                            new SolidBrush(cellStyle.BackColor);
                        graphics.FillRectangle(cellBackground, cellBounds);
                        cellBackground.Dispose();
                    }

                    // Draw the cell borders, if specified. 
                    if ((paintParts & DataGridViewPaintParts.Border) ==
                        DataGridViewPaintParts.Border)
                    {
                        PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                            advancedBorderStyle);
                    }

                    // Calculate the area in which to draw the button.
                    Rectangle buttonArea = cellBounds;
                    Rectangle buttonAdjustment =
                        this.BorderWidths(advancedBorderStyle);
                    buttonArea.X += buttonAdjustment.X;
                    buttonArea.Y += buttonAdjustment.Y;
                    buttonArea.Height -= buttonAdjustment.Height;
                    buttonArea.Width -= buttonAdjustment.Width;

                    // Draw the disabled button.                
                    ButtonRenderer.DrawButton(graphics, buttonArea,
                        PushButtonState.Disabled);

                    // Draw the disabled button text.  
                    if (this.FormattedValue is String)
                    {
                        TextRenderer.DrawText(graphics,
                            (string)this.FormattedValue,
                            this.DataGridView.Font,
                            buttonArea, SystemColors.GrayText);
                    }
                }
                else
                {

                    cellStyle.Font = new Font("Verdana", 9);
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                        elementState, value, formattedValue, errorText,
                        cellStyle, advancedBorderStyle, paintParts);
                }
            }
        }

        private void btnaddtext_Click(object sender, EventArgs e)
        {
            this.btnaddtext.Select();
            btnTextType = true;
            btnBarcodeType = false;
            btnImageType = false;
            btnLineType = false;
            //this.Focus();
            //btnaddbarcode.FlatStyle = FlatStyle.Standard;
            //btnaddbarcode.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnaddbarcode.FlatAppearance.BorderSize = 0;

            //btnAddImage.FlatStyle = FlatStyle.Standard;
            //btnAddImage.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnAddImage.FlatAppearance.BorderSize = 0;

            //btnaddtext.FlatStyle = FlatStyle.Flat;
            //btnaddtext.FlatAppearance.BorderColor = Color.SlateBlue;
            //btnaddtext.FlatAppearance.BorderSize = 1;
            lobjQBConfiguration = new QBConfiguration();
            if ((lobjQBConfiguration.GetLabelConfigSettings("isShowDesignPopup").ToString().ToLower() == "false"))
            {
                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                if (System.Windows.Forms.Application.OpenForms["FrmConfirmPopup"] == null)
                {

                    LabelConnector.FrmConfirmPopup lobjLabelConnectorSettings = new LabelConnector.FrmConfirmPopup();
                    lobjLabelConnectorSettings.ShowInTaskbar = false;

                    lobjLabelConnectorSettings.ShowDialog();

                }
            }


            /////////////////
            //B4 Popup x,y
            //if (ActiveMdiChild != null)
            //    ActiveMdiChild.Close();

            //if (System.Windows.Forms.Application.OpenForms["FrmAddEditField"] == null)
            //{

            //    LabelConnector.FrmAddEditField lobjLabelConnectorSettings = new LabelConnector.FrmAddEditField(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString());


            //    // Create an instance of the delegate
            //    lobjLabelConnectorSettings.passControl = new FrmAddEditField.PassControl(PassData);

            //    delPassData del = new delPassData(lobjLabelConnectorSettings.funData);
            //    del(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), txtdispwidth.Text.ToString(), txtdispheight.Text.ToString(),"Text");

            //    lobjLabelConnectorSettings.ShowInTaskbar = false;

            //    lobjLabelConnectorSettings.ShowDialog();

            //}
        }

        private void btnaddbarcode_Click(object sender, EventArgs e)
        {
            btnBarcodeType = true;
            btnTextType = false;
            btnImageType = false;
            btnLineType = false;
            this.btnaddbarcode.Select();


            lobjQBConfiguration = new QBConfiguration();
            if ((lobjQBConfiguration.GetLabelConfigSettings("isShowDesignPopup").ToString().ToLower() == "false"))
            {
                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                if (System.Windows.Forms.Application.OpenForms["FrmConfirmPopup"] == null)
                {

                    LabelConnector.FrmConfirmPopup lobjLabelConnectorSettings = new LabelConnector.FrmConfirmPopup();
                    lobjLabelConnectorSettings.ShowInTaskbar = false;

                    lobjLabelConnectorSettings.ShowDialog();

                }
            }

            //btnaddtext.FlatStyle = FlatStyle.Standard;
            //btnaddtext.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnaddtext.FlatAppearance.BorderSize = 0;

            //btnAddImage.FlatStyle = FlatStyle.Standard;
            //btnAddImage.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnAddImage.FlatAppearance.BorderSize = 0;

            //btnaddbarcode.FlatStyle = FlatStyle.Flat;
            //btnaddbarcode.FlatAppearance.BorderColor = Color.SlateBlue;
            //btnaddbarcode.FlatAppearance.BorderSize = 1;
            //if (ActiveMdiChild != null)
            //    ActiveMdiChild.Close();

            //if (System.Windows.Forms.Application.OpenForms["FrmAddEditFieldBarCode"] == null)
            //{

            //    LabelConnector.FrmAddEditFieldBarCode lobjLabelConnectorSettingsBarCode = new LabelConnector.FrmAddEditFieldBarCode(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString());


            //    // Create an instance of the delegate
            //    lobjLabelConnectorSettingsBarCode.passControl = new FrmAddEditFieldBarCode.PassControl(PassData);

            //    delPassData del = new delPassData(lobjLabelConnectorSettingsBarCode.funData);
            //    del(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), txtdispwidth.Text.ToString(), txtdispheight.Text.ToString(), "BarCode");

            //    lobjLabelConnectorSettingsBarCode.ShowInTaskbar = false;

            //    lobjLabelConnectorSettingsBarCode.ShowDialog();

            //}
        }

        private void btndeleteheader_Click(object sender, EventArgs e)
        {
            string strxmlStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\" + txtdispname.Text.ToString() + ".xml");
            string strpdfStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat" + "\\" + txtdispname.Text.ToString() + ".pdf");
            // string strpdfImgStartupPath = System.Windows.Forms.Application.StartupPath + @"\" + "PdfImagesList" + "\\" + txtdispname.Text.ToString() + ".jpeg";
            string strpdfImgStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfImagesList" + "\\" + txtdispname.Text.ToString() + "\\" + txtdispname.Text.ToString() + ".Tiff");


            DialogResult dr = MessageBox.Show("Are you sure to delete this template?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (File.Exists(strxmlStartupPath))
                {
                    File.Delete(strxmlStartupPath); //delete xml file
                }
                if (File.Exists(strpdfStartupPath))
                {
                    File.Delete(strpdfStartupPath); //delete pdf file
                }
                if (File.Exists(strpdfImgStartupPath))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(strpdfImgStartupPath); //delete pdfimage file
                }

                gbshowheaderdata.Visible = false;
                gvfieldview.Visible = false; //for test
                gbtemplatepreview.Visible = false;
                // pnlbtnarray1.Visible = false;
                btnaddtext.Visible = false;
                btnaddbarcode.Visible = false;
                btnAddImage.Visible = false;
                btnAddLine.Visible = false;
                btntestprint.Visible = false;


            }
            else if (dr == DialogResult.No)
            {

            }

        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            //if (ActiveMdiChild != null)
            //    ActiveMdiChild.Close();

            //if (System.Windows.Forms.Application.OpenForms["FrmTemplateOperation"] == null)
            //{

            //    LabelConnector.FrmTemplateOperation lobjLabelConnectorSettings = new LabelConnector.FrmTemplateOperation();

            //    // Create an instance of the delegate
            //     lobjLabelConnectorSettings.passheadercontrolopentemplate = new FrmTemplateOperation.PassHeaderControlOpentemplate(PassheaderTemplateData);


            //    lobjLabelConnectorSettings.ShowInTaskbar = false;

            //    lobjLabelConnectorSettings.ShowDialog();
            //}
        }
        private void PassheaderTemplateData(String lstrTemplateName)
        {
            clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
            var headerfieldlist = lobjtemplatenames.GetTemplateHeaderInfo(lstrTemplateName);

            foreach (QuickBooksField fields in headerfieldlist)
            {
                txtdispname.Text = lstrTemplateName;
                if (fields.ItemFieldId == 1)
                {
                    txtdistranstype.Text = fields.ItemFieldName;
                }
                else if (fields.ItemFieldId == 2)
                {
                    txtdispwidth.Text = fields.ItemFieldName;
                }
                else if (fields.ItemFieldId == 3)
                {
                    txtdispheight.Text = fields.ItemFieldName;
                }

            }
            gvfieldview.Visible = true; //for test
            if (!gvfieldview.Columns.Contains("FieldName") && !gvfieldview.Columns.Contains("delete") && !gvfieldview.Columns.Contains("edit"))
            {
                InitGrid();
            }
            gvfieldview.AutoGenerateColumns = false;
            fillpropertyfieldgrid(lstrTemplateName);
            //display data after saving from poppup
            gbshowheaderdata.Visible = true;
            // pnlbtnarray1.Visible = true;
            btnaddtext.Visible = true;
            btnaddbarcode.Visible = true;
            btnAddImage.Visible = true;
            btnAddLine.Visible = true;
            btntestprint.Visible = true;
            // gbbuttonlist.Visible = true;
            //show menu when template is visible
            if (txtdispname.Text != "")
            {
                toolStripButton4.Visible = true;
                //SaveAs
               // mnusaveaspath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "saveas24.png");
               // this.toolStripButton4.Image = Bitmap.FromFile(mnusaveaspath);
                this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton4.Name = "toolStripButton4";
                this.toolStripButton4.Text = "&SaveAs";
                this.toolStripButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                // resize the image of the button to the new size
                int syncsaveasWidth = toolStripButton4.Image.Width;
                int synsaveasHeight = toolStripButton4.Image.Height;
                Bitmap e = new Bitmap(24, 24);
                using (Graphics gsync = Graphics.FromImage((Image)e))
                {
                    gsync.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gsync.DrawImage(toolStripButton4.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgsaveas = (Image)e;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton4.Image = SyncResizedImgsaveas;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton4.Visible = false;
            }
            if (txtdispname.Text != "")
            {
                toolStripButton11.Visible = true;
                //SaveAs
               // mnusavepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "save24.png");
               // this.toolStripButton11.Image = Bitmap.FromFile(mnusavepath);
                this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton11.Name = "toolStripButton11";
                this.toolStripButton11.Text = "&Save";
                this.toolStripButton11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                // resize the image of the button to the new size
                int syncsaveasWidth = toolStripButton11.Image.Width;
                int synsaveasHeight = toolStripButton11.Image.Height;
                Bitmap e = new Bitmap(24, 24);
                using (Graphics gsync = Graphics.FromImage((Image)e))
                {
                    gsync.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gsync.DrawImage(toolStripButton11.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgsaveas = (Image)e;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton11.Image = SyncResizedImgsaveas;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton11.Visible = false;
            }

            if (txtdispname.Text != "")
            {
                toolStripButton5.Visible = true;
                //Edit
               // mnueditpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "edit.png");
               // this.toolStripButton5.Image = Bitmap.FromFile(mnueditpath);
                this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton5.Name = "toolStripButton5";
                this.toolStripButton5.Text = "&Edit";
                this.toolStripButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                // resize the image of the button to the new size
                // int syncsaveasWidth = toolStripButton4.Image.Width;
                // int synsaveasHeight = toolStripButton4.Image.Height;
                Bitmap f = new Bitmap(24, 24);
                using (Graphics gedit = Graphics.FromImage((Image)f))
                {
                    gedit.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gedit.DrawImage(toolStripButton5.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgedit = (Image)f;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton5.Image = SyncResizedImgedit;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton5.Visible = false;
            }

            //delete
            if (txtdispname.Text != "")
            {
                // toolStripButton6.Visible = true;
                //mnudeletetpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "delete.png");
                this.toolStripButton6.Image = Bitmap.FromFile(mnudeletetpath);
                this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton6.Name = "toolStripButton6";
                this.toolStripButton6.Text = "&Delete";
                this.toolStripButton6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                // resize the image of the button to the new size
                // int syncsaveasWidth = toolStripButton4.Image.Width;
                // int synsaveasHeight = toolStripButton4.Image.Height;
                Bitmap h = new Bitmap(24, 24);
                using (Graphics gdelete = Graphics.FromImage((Image)h))
                {
                    gdelete.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gdelete.DrawImage(toolStripButton6.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgedelete = (Image)h;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton6.Image = SyncResizedImgedelete;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton6.Visible = false;
            }

            //preview
            //if (txtdispname.Text != "")
            //{
            //    toolStripButton7.Visible = true;
            //    mnupreviewpath = System.Windows.Forms.Application.StartupPath + @"\" + "Images" + "\\" + "preview.png";
            //    this.toolStripButton7.Image = Bitmap.FromFile(mnupreviewpath);
            //    this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            //    this.toolStripButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //    this.toolStripButton7.Name = "toolStripButton7";
            //    this.toolStripButton7.Text = "&Preview";
            //    this.toolStripButton7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //    // resize the image of the button to the new size
            //    // int syncsaveasWidth = toolStripButton4.Image.Width;
            //    // int synsaveasHeight = toolStripButton4.Image.Height;
            //    Bitmap i = new Bitmap(24, 24);
            //    using (Graphics gpreview = Graphics.FromImage((Image)i))
            //    {
            //        gpreview.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //        gpreview.DrawImage(toolStripButton7.Image, 0, 0, 24, 24);
            //    }
            //    Image SyncResizedImgepreview = (Image)i;

            //    //put the resized image back to the button and change toolstrip's ImageScalingSize property 
            //    toolStripButton7.Image = SyncResizedImgepreview;
            //    toolStrip1.ImageScalingSize = new Size(24, 24);
            //}
            //else
            //{
            //    toolStripButton7.Visible = false;
            //}

            //show template pdf
            //toolStripButton7.PerformClick(); //preview
            if (txtdispname.Text != "")
            {
                List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
                ShowTemplatePdf(objfieldlist);
            }
        }

        private void PassheaderTemplateImportData(String lstrImportFileName)
        {
            string strTransTypeFilePath = string.Empty;
            //process xml to pdf and image show in preiew
            clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
            List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
            List<QuickBooksField> objheaderfield = new List<QuickBooksField>();

            var headerfieldlist = lobjtemplatenames.GetTemplateHeaderInfo(lstrImportFileName);

            foreach (QuickBooksField fields in headerfieldlist)
            {
                txtdispname.Text = lstrImportFileName;
                if (fields.ItemFieldId == 1)
                {
                    txtdistranstype.Text = fields.ItemFieldName;
                }
                else if (fields.ItemFieldId == 2)
                {
                    txtdispwidth.Text = fields.ItemFieldName;
                }
                else if (fields.ItemFieldId == 3)
                {
                    txtdispheight.Text = fields.ItemFieldName;
                }

            }
            objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
            //Get property fields list
            List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();
            System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
            if (dirtransxml.Exists)
            {
                strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + txtdistranstype.Text.ToString() + ".xml");
            }
            else
            {
                strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + txtdistranstype.Text.ToString() + ".xml");
            }
            //strTransTypeFilePath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + txtdistranstype.Text.ToString() + ".xml";
            if (File.Exists(strTransTypeFilePath))
            {
                Itemfieldlist = lobjtemplatenames.GetItemFieldListfromxml(strTransTypeFilePath); //Get field list
            }
            //create pdf from xml
            lobjtemplatenames.CreateUpdateTemplatePDF(lstrImportFileName, txtdispwidth.Text.ToString(), txtdispheight.Text.ToString(), txtdispheight.Text.ToString(), string.Empty, objfieldlist, Itemfieldlist);

            gvfieldview.Visible = true; //for test
            if (!gvfieldview.Columns.Contains("FieldName") && !gvfieldview.Columns.Contains("delete") && !gvfieldview.Columns.Contains("edit"))
            {
                InitGrid();
            }
            gvfieldview.AutoGenerateColumns = false;
            fillpropertyfieldgrid(lstrImportFileName);
            //display data after saving from poppup
            gbshowheaderdata.Visible = true;
            // pnlbtnarray1.Visible = true;
            btnaddtext.Visible = true;
            btnaddbarcode.Visible = true;
            btnAddImage.Visible = true;
            btnAddLine.Visible = true;
            btntestprint.Visible = true;
            // gbbuttonlist.Visible = true;
            //show menu when template is visible
            if (txtdispname.Text != "")
            {
                toolStripButton4.Visible = true;
                //SaveAs
                //mnusaveaspath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "saveas24.png");
                //this.toolStripButton4.Image = Bitmap.FromFile(mnusaveaspath);
                this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton4.Name = "toolStripButton4";
                this.toolStripButton4.Text = "&SaveAs";
                this.toolStripButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                // resize the image of the button to the new size
                int syncsaveasWidth = toolStripButton4.Image.Width;
                int synsaveasHeight = toolStripButton4.Image.Height;
                Bitmap e = new Bitmap(24, 24);
                using (Graphics gsync = Graphics.FromImage((Image)e))
                {
                    gsync.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gsync.DrawImage(toolStripButton4.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgsaveas = (Image)e;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton4.Image = SyncResizedImgsaveas;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton4.Visible = false;
            }
            if (txtdispname.Text != "")
            {
                toolStripButton11.Visible = true;
                //SaveAs
                //mnusavepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "save24.png");
                //this.toolStripButton11.Image = Bitmap.FromFile(mnusavepath);
                this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton11.Name = "toolStripButton11";
                this.toolStripButton11.Text = "&Save";
                this.toolStripButton11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                // resize the image of the button to the new size
                int syncsaveasWidth = toolStripButton11.Image.Width;
                int synsaveasHeight = toolStripButton11.Image.Height;
                Bitmap e = new Bitmap(24, 24);
                using (Graphics gsync = Graphics.FromImage((Image)e))
                {
                    gsync.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gsync.DrawImage(toolStripButton11.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgsaveas = (Image)e;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton11.Image = SyncResizedImgsaveas;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton11.Visible = false;
            }
            if (txtdispname.Text != "")
            {
                toolStripButton5.Visible = true;
                //Edit
                //mnueditpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "edit.png");
                //this.toolStripButton5.Image = Bitmap.FromFile(mnueditpath);
                this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton5.Name = "toolStripButton5";
                this.toolStripButton5.Text = "&Edit";
                this.toolStripButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                // int syncsaveasWidth = toolStripButton4.Image.Width;
                // int synsaveasHeight = toolStripButton4.Image.Height;
                Bitmap f = new Bitmap(24, 24);
                using (Graphics gedit = Graphics.FromImage((Image)f))
                {
                    gedit.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gedit.DrawImage(toolStripButton5.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgedit = (Image)f;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton5.Image = SyncResizedImgedit;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton5.Visible = false;
            }

            //delete
            if (txtdispname.Text != "")
            {
                toolStripButton6.Visible = true;
              //  mnudeletetpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "delete.png");
               // this.toolStripButton6.Image = Bitmap.FromFile(mnudeletetpath);
                this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                this.toolStripButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.toolStripButton6.Name = "toolStripButton6";
                this.toolStripButton6.Text = "&Delete";
                this.toolStripButton6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                // resize the image of the button to the new size
                // int syncsaveasWidth = toolStripButton4.Image.Width;
                // int synsaveasHeight = toolStripButton4.Image.Height;
                Bitmap h = new Bitmap(24, 24);
                using (Graphics gdelete = Graphics.FromImage((Image)h))
                {
                    gdelete.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    gdelete.DrawImage(toolStripButton6.Image, 0, 0, 24, 24);
                }
                Image SyncResizedImgedelete = (Image)h;

                //put the resized image back to the button and change toolstrip's ImageScalingSize property 
                toolStripButton6.Image = SyncResizedImgedelete;
                toolStrip1.ImageScalingSize = new Size(24, 24);
            }
            else
            {
                toolStripButton6.Visible = false;
            }

            //preview
            //if (txtdispname.Text != "")
            //{
            //    toolStripButton7.Visible = true;
            //    mnupreviewpath = System.Windows.Forms.Application.StartupPath + @"\" + "Images" + "\\" + "preview.png";
            //    this.toolStripButton7.Image = Bitmap.FromFile(mnupreviewpath);
            //    this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            //    this.toolStripButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //    this.toolStripButton7.Name = "toolStripButton7";
            //    this.toolStripButton7.Text = "&Preview";
            //    this.toolStripButton7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            //    // resize the image of the button to the new size
            //    // int syncsaveasWidth = toolStripButton4.Image.Width;
            //    // int synsaveasHeight = toolStripButton4.Image.Height;
            //    Bitmap i = new Bitmap(24, 24);
            //    using (Graphics gpreview = Graphics.FromImage((Image)i))
            //    {
            //        gpreview.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //        gpreview.DrawImage(toolStripButton7.Image, 0, 0, 24, 24);
            //    }
            //    Image SyncResizedImgepreview = (Image)i;

            //    //put the resized image back to the button and change toolstrip's ImageScalingSize property 
            //    toolStripButton7.Image = SyncResizedImgepreview;
            //    toolStrip1.ImageScalingSize = new Size(24, 24);
            //}
            //else
            //{
            //    toolStripButton7.Visible = false;
            //}

            //show template pdf 
            //toolStripButton7.PerformClick(); //preview
            if (txtdispname.Text != "")
            {
                ShowTemplatePdf(objfieldlist);
            }

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           bool status= CheckTemplateSave();            

                if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            if (System.Windows.Forms.Application.OpenForms["FrmAddEditTemplateHeader"] == null)
            {

                LabelConnector.FrmAddEditTemplateHeader lobjLabelConnectorSettings = new LabelConnector.FrmAddEditTemplateHeader();

                // Create an instance of the delegate
                lobjLabelConnectorSettings.passheadercontrol = new FrmAddEditTemplateHeader.PassHeaderControl(PassheaderData);

                delHeaderPassData delheader = new delHeaderPassData(lobjLabelConnectorSettings.funheaderData);
                delheader(toolStripButton1.Text.ToString()); //for add mode

                lobjLabelConnectorSettings.ShowInTaskbar = false;
                lobjLabelConnectorSettings.Text = "Add Template";
                lobjLabelConnectorSettings.ShowDialog();
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //open Existing Template

            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            if (System.Windows.Forms.Application.OpenForms["FrmTemplateOperation"] == null)
            {

                LabelConnector.FrmTemplateOperation lobjLabelConnectorSettings = new LabelConnector.FrmTemplateOperation();

                // Create an instance of the delegate
                // lobjLabelConnectorSettings.passheadercontrolopentemplate = new FrmAddEditTemplateHeader.PassHeaderControl(PassheaderData);
                lobjLabelConnectorSettings.passheadercontrolopentemplate = new FrmTemplateOperation.PassHeaderControlOpentemplate(PassheaderTemplateData);
                // delSaveasData delsaveastheader = new delSaveasData(lobjLabelConnectorSettings.funsaveasData);
                // delsaveastheader(btntemplatesaveas.Text.ToString(), txtdispname.Text.ToString()); //for edit mode

                lobjLabelConnectorSettings.ShowInTaskbar = false;
                lobjLabelConnectorSettings.Text = "Open";
                lobjLabelConnectorSettings.ShowDialog();
            }

        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           
            //Sync Fields from QuickBooks
            string strStartupPath = string.Empty;
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            List<QuickBooksField> lobjcustomfieldlist = new List<QuickBooksField>();
            List<QuickBooksField> lobjcustomCustomerfieldlist = new List<QuickBooksField>();
            QBConfiguration lobjQBConfiguration = new QBConfiguration();

            if (lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode") == "Close")
            {
                MessageBox.Show("Your current Label connector QB connection is in closed mode. Please, enable the open mode in 'Connect QuickBooks' Label connector settings.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string strfilepath = string.Empty;
            strfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\");
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
            //DirectoryInfo dInfo = new DirectoryInfo(strfilepath);
            //DirectorySecurity dSecurity = dInfo.GetAccessControl();
            //dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            //dInfo.SetAccessControl(dSecurity);
            File.Copy(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + "Item list.xml"), strfilepath + "Item list.xml", true);
            File.Copy(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + "Invoice.xml"), strfilepath + "Invoice.xml", true);
            File.Copy(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + "Sales Order.xml"), strfilepath + "Sales Order.xml", true);
            File.Copy(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + "Purchase Order.xml"), strfilepath + "Purchase Order.xml", true);
            File.Copy(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + "Sales Receipts.xml"), strfilepath + "Sales Receipts.xml", true);
            File.Copy(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + "Receipts.xml"), strfilepath + "Receipts.xml", true);
            try
            {
                using (new HourGlass())
                {

                    for (int ifields = 0; ifields < 6; ifields++)
                    {
                        switch (ifields)
                        {
                            case 0: //Item list
                                    // strStartupPath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + "Item list.xml";
                                strStartupPath = strfilepath + "Item list.xml";
                                lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);

                                lobjcustomfieldlist = lobjTemplatexml.GetItemCustomFieldsList();

                                lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);

                                break;
                            case 1: // Invoice
                                //strStartupPath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + "Invoice.xml";
                                strStartupPath = strfilepath + "Invoice.xml";
                                lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);
                                lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);

                                break;
                            case 2:  //Sales Order
                                     // strStartupPath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + "Sales Order.xml";
                                strStartupPath = strfilepath + "Sales Order.xml";
                                lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);
                                lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);
                                break;
                            case 3: //Purchase Order
                                //strStartupPath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + "Purchase Order.xml";
                                strStartupPath = strfilepath + "Purchase Order.xml";
                                lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);
                                lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);
                                break;
                            case 4:  
                                strStartupPath = strfilepath + "Sales Receipts.xml";
                                lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);
                                lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);
                                break;
                            case 5:
                                strStartupPath = strfilepath + "Receipts.xml";
                                lobjTemplatexml.Deletecustomfieldxmlnode(strStartupPath);
                                lobjTemplatexml.ItemFieldList(lobjcustomfieldlist, strStartupPath);
                                break;

                            default:
                                break;
                        }


                    }

                }
                MessageBox.Show("Properties Field Sync Sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }

        }

        private void btnfrmclosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            bool status = CheckTemplateSave("SaveAs");
            if(status)
            { 
            if (txtdispname.Text != "")
            {
                //saveAs
                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();


                String tempname = "";
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                SaveFileDialog openFileDialog1 = new SaveFileDialog();
                clsTemplateLabelXmlwork objtemp = new clsTemplateLabelXmlwork();
                clsTemplateStatus objTemp = new clsTemplateStatus();
                objTemp = objtemp.GetTemplateStatus();
                    string Labelpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Label Connector Documents";

                    if (!Directory.Exists(Labelpath))
                        Directory.CreateDirectory(Labelpath);
                    //openFileDialog1.InitialDirectory = objTemp.TemplatePath.Replace(objTemp.TemplatePath, Path.GetDirectoryName(objTemp.TemplatePath)) + "\\";
                    openFileDialog1.InitialDirectory = Labelpath;
                    openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.DefaultExt = "xml";
          
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    objTemp.TemplatePath = openFileDialog1.FileName.ToString();
                    objTemp.TemplateSave = "0";
                    objTemp.TemplateMode = "Edit";
                    objTemp.TemplateStatus = "0";
                    objTemp.TempTemplatePath = "";
                    lobjtemplatenames.SaveTemplateStatus(objTemp);
                    //slectedPath = openFileDialog1.FileName.ToString();
                    //lbltemp.Text = Path.GetFileName(openFileDialog1.FileName);
                    tempname = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    ControlsValidate();
                }
                else
                {
                    return;
                }


                //save as file
                string pdfoldfilepath = string.Empty;
                string pdfnewfilepath = string.Empty;
                string xmloldfilepath = string.Empty;
                string xmlnewfilepath = string.Empty;
                string saveasimgoldpath = string.Empty;
                string saveasimgnewpath = string.Empty;

                pdfoldfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat" + "\\" + txtdispname.Text.ToString() + ".pdf");
                pdfnewfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat" + "\\" + tempname.ToString().Trim() + ".pdf");

                xmloldfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\" + txtdispname.Text.ToString() + ".xml");
                xmlnewfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\" + tempname.ToString().Trim() + ".xml");

                DirectoryInfo di = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfImagesList"));

                // Create the directory only if it does not already exist.
                if (di.Exists == false)
                    di.Create();

                // Create a subdirectory in the directory just created.
                DirectoryInfo dis = di.CreateSubdirectory(tempname.ToString().Trim());

                saveasimgoldpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfImagesList" + "\\" + txtdispname.Text.ToString() + "\\" + txtdispname.Text.ToString() + ".Tiff");
                saveasimgnewpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfImagesList" + "\\" + tempname.ToString().Trim() + "\\" + tempname.ToString().Trim() + ".Tiff");


                    try
                    {
                        if (!string.IsNullOrWhiteSpace(pdfnewfilepath))
                        {
                            if (pdfoldfilepath != pdfnewfilepath)
                            {
                                if (File.Exists(pdfnewfilepath))
                                {
                                    File.Delete(pdfnewfilepath);
                                }

                                System.IO.File.Copy(pdfoldfilepath, pdfnewfilepath);
                            }
                            if (!File.Exists(xmlnewfilepath))
                            {

                                System.IO.File.Copy(xmloldfilepath, xmlnewfilepath); //save as pdf
                                System.IO.File.Copy(saveasimgoldpath, saveasimgnewpath); //save as image
                            }                                                      //update attr to template
                                lobjtemplatenames.UpdateTemplateAttribute(tempname.ToString().Trim());
                                clsTemplateStatus objTempStatus = new clsTemplateStatus();
                                objTempStatus = lobjtemplatenames.GetTemplateStatus();
                                objTempStatus.TempTemplatePath = xmlnewfilepath;
                                objTempStatus.TemplateSave = "1";
                                objTempStatus.TemplateMode = "Edit";
                                objTempStatus.TemplateStatus = "1";
                                objTempStatus.TemplatePath = objTempStatus.TemplatePath;
                                lobjtemplatenames.SaveTemplateStatus(objTempStatus);
                                SaveAsTemplate();
                                //    bool result = lobjtemplatenames.SaveTemplate(xmlnewfilepath);
                                //    if (result)
                                //    {

                                //}
                            
                            // MessageBox.Show("Save as template sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                        }

                        PassheadersaveasData(tempname.ToString().Trim());

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }



                    ////////    if (System.Windows.Forms.Application.OpenForms["FrmTemplateOperation"] == null)
                    ////////    {

                    ////////        LabelConnector.FrmTemplateOperation lobjLabelConnectorSettings = new LabelConnector.FrmTemplateOperation();

                    ////////        // Create an instance of the delegate
                    ////////        lobjLabelConnectorSettings.passheadersaveascontrol = new FrmTemplateOperation.PassHeadersaveasControl(PassheadersaveasData);

                    ////////        delSaveasData delsaveastheader = new delSaveasData(lobjLabelConnectorSettings.funsaveasData);
                    ////////        delsaveastheader(toolStripButton4.Text.ToString(), txtdispname.Text.ToString()); //for edit mode

                    ////////        lobjLabelConnectorSettings.ShowInTaskbar = false;
                    ////////        lobjLabelConnectorSettings.Text = "SaveAs";
                    ////////        lobjLabelConnectorSettings.ShowDialog();
                    ////////    }
                    ////////}
                    ////////else
                    ////////{
                    ////////    MessageBox.Show("Template does not exist", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ////////}
                }
            }
        }
        public bool SaveAsTemplate()
        {
            clsTemplateLabelXmlwork ObjtemXML = new clsTemplateLabelXmlwork();
            clsTemplateStatus tempstatus = new clsTemplateStatus();
            tempstatus = ObjtemXML.GetTemplateStatus();
            string oldPath = Path.GetFileNameWithoutExtension(tempstatus.TempTemplatePath);
            if (File.Exists(tempstatus.TemplatePath))
            {
                File.Delete(tempstatus.TemplatePath);

            }
            File.Copy(tempstatus.TempTemplatePath, Path.Combine((tempstatus.TemplatePath).Replace(tempstatus.TemplatePath, Path.GetDirectoryName(tempstatus.TemplatePath)) + "\\", Path.GetFileName(tempstatus.TempTemplatePath)), true);
            tempstatus.TemplateSave = "1";
            tempstatus.TemplateMode = "Edit";
            tempstatus.TemplateStatus = "1";
            tempstatus.TemplatePath = tempstatus.TemplatePath;
            tempstatus.TempTemplatePath = tempstatus.TempTemplatePath;
            ObjtemXML.SaveTemplateStatus(tempstatus);

            return true;
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //open header data form in edit view

            if (txtdispname.Text != "")
            {

                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                if (System.Windows.Forms.Application.OpenForms["FrmAddEditTemplateHeader"] == null)
                {

                    LabelConnector.FrmAddEditTemplateHeader lobjLabelConnectorSettings = new LabelConnector.FrmAddEditTemplateHeader();

                    // Create an instance of the delegate
                    lobjLabelConnectorSettings.passheadercontrol = new FrmAddEditTemplateHeader.PassHeaderControl(PassheadereditData);

                    delHeaderPassEditData deleditheader = new delHeaderPassEditData(lobjLabelConnectorSettings.funheaderEditData);
                    deleditheader(toolStripButton5.Text.ToString(), txtdispname.Text.ToString(), txtdistranstype.Text.ToString(), txtdispwidth.Text.ToString(), txtdispheight.Text.ToString()); //for edit mode

                    lobjLabelConnectorSettings.ShowInTaskbar = false;
                    lobjLabelConnectorSettings.Text = "Edit Template";

                    lobjLabelConnectorSettings.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Template does not exist", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //delete
            if (txtdispname.Text != "")
            {
                string strxmlStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\" + txtdispname.Text.ToString() + ".xml");
                string strpdfStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat" + "\\" + txtdispname.Text.ToString() + ".pdf");
                // string strpdfImgStartupPath = System.Windows.Forms.Application.StartupPath + @"\" + "PdfImagesList" + "\\" + txtdispname.Text.ToString() + ".jpeg";
                string strpdfImgStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfImagesList" + "\\" + txtdispname.Text.ToString() + "\\" + txtdispname.Text.ToString() + ".Tiff");

                string originalimagepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "OriginalImages" + "\\" + txtdispname.Text.ToString());
                string resizeimagepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" +"\\"+"ResizeImages" + "\\" + txtdispname.Text.ToString());
                clsTemplateStatus objTemplateStatus = new clsTemplateStatus();
                clsTemplateLabelXmlwork objTemplate = new clsTemplateLabelXmlwork();
                objTemplateStatus = objTemplate.GetTemplateStatus();
                     DialogResult dr = MessageBox.Show("Are you sure to delete this template?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(strxmlStartupPath))
                    {
                        File.Delete(strxmlStartupPath); //delete xml file
                    }                    
                    if (File.Exists(objTemplateStatus.TemplatePath))
                    {
                        File.Delete(objTemplateStatus.TemplatePath); //delete xml file
                    }
                    if (File.Exists(strpdfStartupPath))
                    {
                        File.Delete(strpdfStartupPath); //delete pdf file
                    }
                    if (File.Exists(strpdfImgStartupPath))
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        File.Delete(strpdfImgStartupPath); //delete pdfimage file
                    }
                    if (Directory.Exists(originalimagepath))
                    {
                        Directory.Delete(originalimagepath, true);
                    }
                    if (Directory.Exists(resizeimagepath))
                    {
                        Directory.Delete(resizeimagepath, true);
                    }
                    gbshowheaderdata.Visible = false;
                    gvfieldview.Visible = false; //for test
                    gbtemplatepreview.Visible = false;
                    //pnlbtnarray1.Visible = false;
                    btnaddtext.Visible = false;
                    btnaddbarcode.Visible = false;
                    btnAddImage.Visible = false;
                    btnAddLine.Visible = false;
                    btntestprint.Visible = false;
                    txttemplatename.Text = "";
                    cmbtemplatelist.Text = "";
                    txttemplateheaderwidth.Text = "";
                    txttemplateheaderheight.Text = "";
                    txtdispname.Text = "";
                    objTemplateStatus.TemplateSave = "0";
                    objTemplateStatus.TemplateStatus = "Close";
                    objTemplate.SaveTemplateStatus(objTemplateStatus);
                }
                else if (dr == DialogResult.No)
                {

                }

            }
            else
            {
                MessageBox.Show("Template does not exist", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //preveiw
            if (txtdispname.Text != "")
            {
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
                objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
                ShowTemplatePdf(objfieldlist);
                //gbtemplatepreview.Visible = true;
                //string imgpath = System.Windows.Forms.Application.StartupPath + @"\" + "PdfImagesList" + "\\" + txtdispname.Text.ToString().Trim() + "\\" + txtdispname.Text.ToString().Trim() + ".Jpeg";

                //try
                //{
                //    if (File.Exists(imgpath))
                //    {
                //        Image image = Image.FromFile(imgpath);
                //        // Set the PictureBox image property to this image.

                //        pictureBox1.Image = image;
                //        pictureBox1.Height = image.Height;
                //        pictureBox1.Width = image.Width;

                //        pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

                //        //Image image;
                //        using (Stream stream = File.OpenRead(imgpath))
                //        {
                //            image = System.Drawing.Image.FromStream(stream);
                //        }
                //        pictureBox1.Image = image;
                //    }
                //    else
                //    {
                //        gbtemplatepreview.Visible = false;
                //    }
                //}
                //catch (Exception ex)
                //{

                //}
            }
            else
            {
                MessageBox.Show("Template does not exist", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void radLabel_LocationChanged(object sender, EventArgs e)
        {
            if (Activefield != "")
            {
                int rowIndex = -1;
                foreach (DataGridViewRow row in gvfieldview.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(Activefield))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                RadLabel labelfield = sender as RadLabel;
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();

                objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
                List<clsTemplateLabelXmlwork> results = objfieldlist.FindAll(x => x.fieldname == labelfield.Name);
                Point coordinates = new Point(0, 0);
                if (results[0].fieldtype == "Text")
                {
                    RadLabel BarLabel = new RadLabel();
                    BarLabel.Text = results[0].testdata;
                    BarLabel.Font = new System.Drawing.Font("Arial", Convert.ToInt32(results[0].fontsize) + (float)(Convert.ToInt32(results[0].fontsize) / 2.5), FontStyle.Bold);
                    coordinates = new Point(labelfield.Location.X, labelfield.Location.Y + BarLabel.Height - 4);
                }
                else
                {
                    coordinates = new Point(labelfield.Location.X, labelfield.Location.Y + labelfield.Height - 4);
                }
                gvfieldview.Rows[rowIndex].Cells["xposition"].Value = coordinates.X.ToString();
                gvfieldview.Rows[rowIndex].Cells["yposition"].Value = coordinates.Y.ToString();
            }
            }
        int A = 0;
        public RadLabel AddNewLabel(clsTemplateLabelXmlwork item)
        {
            if (item.fieldtype == "Text")
            {
                RadLabel BarLabel = new RadLabel();
                //System.Windows.Forms.Label abc = new System.Windows.Forms.Label();
                BarLabel.AutoSize = false;
                if(string.IsNullOrEmpty(item.textAlign))
                {
                    BarLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
                }else if(Convert.ToInt16(item.textAlign)==1)
                {
                    BarLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
                }
                else if (Convert.ToInt16(item.textAlign) == 2)
                {
                    BarLabel.TextAlignment = System.Drawing.ContentAlignment.TopRight;
                }else
                {
                    BarLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
                }
                BarLabel.AutoSize = true;
                //BarLabel.LabelElement.LabelBorder.Margin = new Padding(2, 0, 4, 0);
                radDiagram1.Controls.Add(BarLabel);
                
                string wraptext = "";
                var orientationVall = item.orientation;
                int labelPointY = 0;
                int labelPointX = 0;
                if (Convert.ToInt32(item.orientation) == 0)
                {
                    if (string.IsNullOrWhiteSpace(item.linebreak))
                    {
                        wraptext = clsTemplateLabelXmlwork.WordWrapDG(item.testdata, Convert.ToInt32(item.wordwrap), Convert.ToInt32(item.fontsize));
                        if (Convert.ToInt32(item.wordwrap) > 0)
                        {
                            wraptext = wraptext.Remove(wraptext.Length-2, 2);
                        }
                    }
                    else
                    {
                        wraptext = clsTemplateLabelXmlwork.LineBreakByChar(Regex.Replace(Convert.ToString(item.testdata), @"\s", ""), Convert.ToString(item.linebreak), Convert.ToInt32(item.fontsize));
                    }
                    BarLabel.Text = item.testdata;
                    if(!string.IsNullOrWhiteSpace(item.fontbold))
                    {
                        if(Convert.ToBoolean(item.fontbold))
                        {
                            BarLabel.Font = new System.Drawing.Font("Arial", Convert.ToInt32(item.fontsize) + (float)(Convert.ToInt32(item.fontsize)/2.5), FontStyle.Bold);
                        }
                        else
                        {
                            BarLabel.Font = new System.Drawing.Font("Arial", Convert.ToInt32(item.fontsize) + (float)(Convert.ToInt32(item.fontsize) / 2.5), FontStyle.Regular);
                        }
                    }else
                    {
                        BarLabel.Font = new System.Drawing.Font("Arial", Convert.ToInt32(item.fontsize) + (float)(Convert.ToInt32(item.fontsize) / 2.5), FontStyle.Bold);
                    }                    
                    BarLabel.Name = item.fieldname;
                    BarLabel.Text = wraptext;
                    BarLabel.TextWrap = true;
                    labelPointY = BarLabel.Height;
                    BarLabel.Tag = labelPointY;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(item.linebreak))
                    {
                        wraptext = clsTemplateLabelXmlwork.WordWrapDG(item.testdata, Convert.ToInt32(0), Convert.ToInt32(item.fontsize));
                        BarLabel.Text = item.testdata; 
                        if (!string.IsNullOrWhiteSpace(item.fontbold))
                        {
                            if (Convert.ToBoolean(item.fontbold))
                            {
                                BarLabel.Font = new System.Drawing.Font("Arial", Convert.ToInt32(item.fontsize) + (float)(Convert.ToInt32(item.fontsize) / 2.5), FontStyle.Bold);
                            }
                            else
                            {
                                BarLabel.Font = new System.Drawing.Font("Arial", Convert.ToInt32(item.fontsize) + (float)(Convert.ToInt32(item.fontsize) / 2.5), FontStyle.Regular);
                            }
                        }
                        else
                        {
                            BarLabel.Font = new System.Drawing.Font("Arial", Convert.ToInt32(item.fontsize) + (float)(Convert.ToInt32(item.fontsize) / 2.5), FontStyle.Bold);
                        }
                        BarLabel.Name = item.fieldname;
                        BarLabel.Text = wraptext;
                        BarLabel.TextWrap = true;
                        BarLabel.LayoutManager.UpdateLayout();
                        //wraptext = clsTemplateLabelXmlwork.WordWrap(item.testdata, Convert.ToInt32(item.wordwrap), Convert.ToInt32(item.fontsize));
                        //BarLabel.Text = wraptext;
                        if (item.orientation.ToString() == "90")
                        {
                            orientationVall = "270";
                            labelPointY = BarLabel.Width;
                            BarLabel.Tag = labelPointY;
                        }
                        else if (item.orientation.ToString() == "270")
                        {
                            orientationVall = "90";
                            labelPointY = BarLabel.Height;
                            BarLabel.Tag = labelPointY;
                        }
                        else
                        {
                            labelPointX = BarLabel.Width;
                            labelPointY = BarLabel.Height;
                            BarLabel.Tag = labelPointY + "X" + labelPointX;
                        }
                    }
                    else
                    {
                        wraptext = clsTemplateLabelXmlwork.WordWrapDG(item.testdata, Convert.ToInt32(item.wordwrap), Convert.ToInt32(item.fontsize));
                        BarLabel.Text = item.testdata;
                        if (!string.IsNullOrWhiteSpace(item.fontbold))
                        {
                            if (Convert.ToBoolean(item.fontbold))
                            {
                                BarLabel.Font = new System.Drawing.Font("Arial", Convert.ToInt32(item.fontsize) + (float)(Convert.ToInt32(item.fontsize) / 2.5), FontStyle.Bold);
                            }
                            else
                            {
                                BarLabel.Font = new System.Drawing.Font("Arial", Convert.ToInt32(item.fontsize) + (float)(Convert.ToInt32(item.fontsize) / 2.5), FontStyle.Regular);
                            }
                        }
                        else
                        {
                            BarLabel.Font = new System.Drawing.Font("Arial", Convert.ToInt32(item.fontsize) + (float)(Convert.ToInt32(item.fontsize) / 2.5), FontStyle.Bold);
                        }
                        BarLabel.Name = item.fieldname;
                        BarLabel.Text = wraptext;
                        BarLabel.TextWrap = true;
                        if (item.orientation.ToString() == "90")
                        {
                            orientationVall = "270";
                            BarLabel.LayoutManager.UpdateLayout();
                            labelPointY = BarLabel.Width;
                            BarLabel.Tag = labelPointY + "X" + labelPointX;
                        }
                        else if (item.orientation.ToString() == "270")
                        {
                            orientationVall = "90";
                            BarLabel.LayoutManager.UpdateLayout();
                            labelPointX = BarLabel.Height;                           
                            BarLabel.Tag = labelPointY + "X" + labelPointX;
                        }
                        else
                        {
                            BarLabel.LayoutManager.UpdateLayout();
                            labelPointX = BarLabel.Width;
                            BarLabel.Tag = labelPointY + "X" + labelPointX;
                        }
                    }

                   
                }
                
                int X = Convert.ToInt32(item.xoriginalposition)- labelPointX;
                int Y = Convert.ToInt32(item.yoriginalposition) - labelPointY;                
              
                BarLabel.LabelElement.AngleTransform =Convert.ToInt32(orientationVall); 
                BarLabel.Location = new Point(X, Y);
                BarLabel.MouseLeave += label_MouseLeave;
                BarLabel.MouseEnter += label_MouseEnter;
                BarLabel.LocationChanged += radLabel_LocationChanged;
                BarLabel.ContextMenuStrip = panelcontent;
                ControlExtension.Draggable(BarLabel, true);
                A = A + 1;
                BarLabel.BringToFront();
                return BarLabel;
            }
            else if (item.fieldtype == "BarCode")
            {
                RadLabel BarLabel = new RadLabel();

                Byte[] TheImageAsBytes = Convert.FromBase64String(item.barcodestring);

                MemoryStream MemStr = new MemoryStream(TheImageAsBytes);

                //string imgpath = System.Windows.Forms.Application.StartupPath + @"\" + "TempImage" + "\\" + txtdispname.Text + "\\" + "BarCode" + "\\" + item.barcodetype + "\\" + item.fieldname + ".Tiff";

                if (MemStr != null)
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(MemStr);
                    // System.Drawing.Image image = System.Drawing.Image.FromFile(imgpath);
                    // Set the PictureBox image property to this image.
                    BarLabel.AutoSize = false;
                    BarLabel.Image = image;
                    BarLabel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    var orientationVall = item.orientation;
                    if (item.orientation.ToString() == "90")
                    {
                        orientationVall = "270";
                        BarLabel.Height = image.Width + 4;
                        BarLabel.Width = image.Height + 4;
                    }
                    else if (item.orientation.ToString() == "270")
                    {
                        orientationVall = "90";
                        BarLabel.Height = image.Width + 4;
                        BarLabel.Width = image.Height + 4;
                    }                    
                    else
                    {
                        BarLabel.Height = image.Height + 4;
                        BarLabel.Width = image.Width + 4;
                    }
                   

                    //pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

                    //Image image;
                    ////using (Stream stream = File.OpenRead(imgpath))
                    ////{
                    ////    image = System.Drawing.Image.FromStream(stream);
                    ////}
                    BarLabel.Image = image;

                    radDiagram1.Controls.Add(BarLabel);
                    BarLabel.LabelElement.AngleTransform = Convert.ToInt32(orientationVall);
                    int X = Convert.ToInt32(item.xoriginalposition);
                    int Y = Convert.ToInt32(item.yoriginalposition) - (BarLabel.Height - 4);
                    BarLabel.Name = item.fieldname;
                    BarLabel.Location = new Point(X, Y);
                    BarLabel.MouseLeave += label_MouseLeave;
                    BarLabel.MouseEnter += label_MouseEnter;
                    BarLabel.LocationChanged += radLabel_LocationChanged;
                    BarLabel.ContextMenuStrip = panelcontent;
                    ControlExtension.Draggable(BarLabel, true);
                    A = A + 1;

                }
                BarLabel.BringToFront();
                return BarLabel;
            }
            else if (item.fieldtype == "Line")
            {
                RadLabel BarLabel = new RadLabel();
               

                if (!string.IsNullOrWhiteSpace(item.imagestring))
                {
                    Byte[] TheImageAsBytes = Convert.FromBase64String(item.imagestring);

                    MemoryStream MemStr = new MemoryStream(TheImageAsBytes);

                    System.Drawing.Image image = System.Drawing.Image.FromStream(MemStr);
                    BarLabel.AutoSize = false;
                    BarLabel.Image = image;
                    BarLabel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    var orientationVall = "";
                    if (item.orientation.ToString() == "90" || item.orientation.ToString() == "270")
                    {
                        BarLabel.Height = image.Width + 4;
                        BarLabel.Width = image.Height + 4;
                        if (item.orientation.ToString() == "90")
                        {
                            orientationVall = "270";
                        }
                        else
                        {
                            orientationVall = "90";
                        }
                    }
                    else
                    {
                        BarLabel.Height = image.Height + 4;
                        BarLabel.Width = image.Width + 4;
                        orientationVall = item.orientation;
                    }
                    BarLabel.LabelElement.AngleTransform = Convert.ToInt32(orientationVall);
                    BarLabel.Image = image;

                    radDiagram1.Controls.Add(BarLabel);

                    int X = Convert.ToInt32(item.xoriginalposition) + 4;
                    int Y = Convert.ToInt32(item.yoriginalposition) - (BarLabel.Height - 4);
                    BarLabel.Name = item.fieldname;
                    BarLabel.Location = new Point(X, Y);
                    _moving = false;
                    _resizing = false;
                    _moveIsInterNal = false;
                    _cursorStartPoint = Point.Empty;
                    MouseIsInLeftEdge = false;
                    MouseIsInLeftEdge = false;
                    MouseIsInRightEdge = false;
                    MouseIsInTopEdge = false;
                    MouseIsInBottomEdge = false;
                    WorkType = MoveOrResize.MoveAndResize;
                    BarLabel.MouseMove += label_MouseMove;
                    BarLabel.MouseEnter += label_MouseEnter;
                    BarLabel.MouseDown += label_MouseDown;
                    BarLabel.MouseUp += label_MouseUp;
                    BarLabel.LocationChanged += radLabel_LocationChanged;
                    BarLabel.ContextMenuStrip = panelcontent;
                    A = A + 1;

                }
                BarLabel.BringToFront();
                return BarLabel;
            }
            else
            {
                RadLabel BarLabel = new RadLabel();

                if (!string.IsNullOrWhiteSpace(item.imagestring))
                {
                    Byte[] TheImageAsBytes = Convert.FromBase64String(item.imagestring);

                    MemoryStream MemStr = new MemoryStream(TheImageAsBytes);

                    System.Drawing.Image image = System.Drawing.Image.FromStream(MemStr);


                    // Set the PictureBox image property to this image.
                    BarLabel.AutoSize = false;
                    BarLabel.Image = image;
                    BarLabel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                    var orientationVall ="";
                    if (item.orientation.ToString() == "90" || item.orientation.ToString() == "270")
                    {
                        BarLabel.Height = image.Width + 4;
                        BarLabel.Width = image.Height + 4;
                        if (item.orientation.ToString() == "90")
                        {
                            orientationVall = "270";
                        }
                        else
                        {
                            orientationVall = "90";
                        }
                    }
                    else
                    {
                        BarLabel.Height = image.Height + 4;
                        BarLabel.Width = image.Width + 4;
                        orientationVall = item.orientation;
                    }
                    BarLabel.LabelElement.AngleTransform = Convert.ToInt32(orientationVall);
                    BarLabel.Image = image;

                    radDiagram1.Controls.Add(BarLabel);

                    int X = Convert.ToInt32(item.xoriginalposition)+4;
                    int Y = Convert.ToInt32(item.yoriginalposition) - (BarLabel.Height - 4);
                    BarLabel.Name = item.fieldname;
                    BarLabel.Location = new Point(X, Y);
                    BarLabel.MouseLeave += label_MouseLeave;
                    BarLabel.MouseEnter += label_MouseEnter;
                    BarLabel.LocationChanged += radLabel_LocationChanged;
                    BarLabel.ContextMenuStrip = panelcontent;
                    ControlExtension.Draggable(BarLabel, true);
                    A = A + 1;

                }
                BarLabel.BringToFront();
                return BarLabel;
            }
        }
        
        private void label_MouseEnter(object sender, EventArgs e)
        {
            ((RadLabel)sender).BorderVisible = true;
            Activefield = ((System.Windows.Forms.Control)sender).Name;
            //if(Activefield.Substring(0, 4) == "Line")
            //    ((RadLabel)sender).BorderVisible = false;
        }
        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            RadLabel labelfield = sender as RadLabel;
            if (_moving || _resizing)
            {
                return;
            }
            if (WorkType != MoveOrResize.Move &&
                 (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
            {
                _resizing = true;
                _currentControlStartSize = labelfield.Size;
            }
            else if (WorkType != MoveOrResize.Resize)
            {
                _moving = true;
                labelfield.Cursor = Cursors.Hand;
            }
            _cursorStartPoint = new Point(e.X, e.Y);
            labelfield.Capture = true;
        }
        private  void label_MouseUp(object sender, MouseEventArgs e)
        {
            RadLabel labelfield = sender as RadLabel;
          
           
            labelfield.Capture = false;

            clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
            List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();

            objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
            List<clsTemplateLabelXmlwork> results = objfieldlist.FindAll(x => x.fieldname == labelfield.Name);
            if (results.Count > 0)
            {
                Point coordinates = new Point(0, 0);

                coordinates = new Point(labelfield.Location.X - 4, labelfield.Location.Y + labelfield.Height - 4);

                if ( _moving == true)
                {
                    _moving = false;
               
                    clsTemplateLabelXmlwork lobjTemplate = new clsTemplateLabelXmlwork();
                    string strTransTypeFilePath = string.Empty;
                    string SetValuesForTransType = string.Empty;
                    string SetTemplatewidth = string.Empty;
                    string SetTemplateheight = string.Empty;
                    var widthmeasure = (coordinates.X / 2);
                    var heightmeasure = ((this.radDiagram1.Height) - coordinates.Y) / 2;

                    var wd = 0.010416f * widthmeasure;
                    var hd = 0.010416f * heightmeasure;

                    // MessageBox.Show("X-Cordinates" + xt, "Y-Cordinates" + yp);
                    double xdoclocation = Math.Round(wd, 2);
                    double ydoclocation = Math.Round(hd, 2);

                    if (results[0].fieldtype == "Line")
                    {
                        clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork(
                             txtdispname.Text.ToString(),
                            Convert.ToString(results[0].Id),
                            "Line",
                            Convert.ToString(results[0].fieldname).Trim(),
                            results[0].originimgpath.ToString(),
                            results[0].resizeimgpath,
                            Convert.ToString(results[0].orientation).Trim(),
                            Convert.ToString(results[0].imgwidth).Trim(),
                            Convert.ToString(results[0].imgheight).Trim(),
                            Convert.ToString(xdoclocation).Trim(),
                            Convert.ToString(ydoclocation).Trim(),
                            Convert.ToString(coordinates.X).Trim(),
                            Convert.ToString(coordinates.Y).Trim(),
                            Convert.ToString(results[0].imagestring));

                        if (lobjTemplatexml.UpdateTemplateDetails(lobjTemplatexml, Convert.ToString(labelfield.Name), string.Empty, string.Empty))
                        {

                        }
                        else
                        {
                            MessageBox.Show("Line name exist already", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        List<clsTemplateLabelXmlwork> objfieldlist2 = new List<clsTemplateLabelXmlwork>();
                        List<QuickBooksField> objheaderfield = new List<QuickBooksField>();
                        objfieldlist2 = lobjTemplate.GetFieldPropertiesList(txtdispname.Text, string.Empty);
                        //Get property fields list
                        List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();
                        // strTransTypeFilePath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + this.SetValuesForTransType + ".xml";

                        System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
                        if (dirtransxml.Exists)
                        {
                            strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + txtdistranstype.Text + ".xml");
                        }
                        else
                        {
                            strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + txtdistranstype.Text + ".xml");
                        }
                        if (File.Exists(strTransTypeFilePath))
                        {
                            Itemfieldlist = lobjTemplate.GetItemFieldListfromxml(strTransTypeFilePath); //Get field list
                        }


                        objheaderfield = lobjTemplate.GetTemplateHeaderInfo(txtdispname.Text);
                        foreach (QuickBooksField itemfield in objheaderfield)
                        {
                            if (itemfield.ItemFieldId == 1)
                            {
                                SetValuesForTransType = itemfield.ItemFieldName;
                            }
                            else if (itemfield.ItemFieldId == 2)
                            {
                                SetTemplatewidth = itemfield.ItemFieldName;
                            }
                            else if (itemfield.ItemFieldId == 3)
                            {
                                SetTemplateheight = itemfield.ItemFieldName;
                            }
                        }

                        //string lstrerror;
                        lobjTemplate.InsertImageToPDF(txtdispname.Text.ToString(),
                            SetTemplatewidth,
                            SetTemplateheight,
                            SetValuesForTransType,
                            lobjTemplatexml.resizeimgpath,
                            Convert.ToSingle(lobjTemplatexml.imgwidth),
                            Convert.ToSingle(lobjTemplatexml.imgheight),
                            Convert.ToSingle(lobjTemplatexml.xposition),
                            Convert.ToSingle(lobjTemplatexml.yposition),
                            objfieldlist2,
                            Itemfieldlist);

                        if (txtdispname.Text != "")
                        {
                            ShowTemplatePdf(objfieldlist2);
                        }

                          ((RadLabel)sender).BorderVisible = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Image file", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else if(_resizing == true)
                {
                    _resizing = false;
                    
                        string targetDir = string.Empty;
                        string originalimagepath = string.Empty;
                        var width = "1";
                        var height = "1";
                        string resizeimagepath = string.Empty;
                        string ext = string.Empty;
                        clsTemplateLabelXmlwork lobjTemplateresize = new clsTemplateLabelXmlwork();

                        if (results[0].orientation == "0" )
                        {
                            if (labelfield.Height <= 55 && Convert.ToDouble(labelfield.Width) <= (Convert.ToDouble(txtdispwidth.Text) * 2 * 96))
                            {
                                width = labelfield.Width < 1 ? "3" : Convert.ToString(labelfield.Width);
                                height = labelfield.Height < 1 ? "3" : Convert.ToString(labelfield.Height);
                            }
                            else
                            {
                                width = results[0].imgwidth;
                                height = results[0].imgheight;
                            }
                        }

                        else
                        {
                            var constheight = labelfield.Height;
                            var constwidth = labelfield.Width;

                            labelfield.Width = labelfield.Height;
                            labelfield.Height = constwidth;
                            coordinates = new Point(labelfield.Location.X - 4, labelfield.Location.Y + labelfield.Width - 4);
                            if (labelfield.Height <= 55 && Convert.ToDouble(labelfield.Height) <= (Convert.ToDouble(txtdispheight.Text) * 2 * 96))
                            {
                                width = labelfield.Width < 1 ? "3" : Convert.ToString(labelfield.Width);
                                height = labelfield.Height < 1 ? "3" : Convert.ToString(labelfield.Height);
                            }
                            else
                            {
                                width = results[0].imgwidth;
                                height = results[0].imgheight;
                            }

                        }

                        var Linefilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\bar.jpg");
                        lobjTemplateresize.DeleteResizeImage(Path.GetFileNameWithoutExtension(labelfield.Name), txtdispname.Text.ToString().Trim());
                        ext = ".png";

                        DirectoryInfo di = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "OriginalImages" + "\\"));

                        // Create the directory only if it does not already exist.
                        if (di.Exists == false)
                            di.Create();

                        // Create a subdirectory in the directory just created.
                        DirectoryInfo dis = di.CreateSubdirectory(txtdispname.Text.ToString().Trim());

                        targetDir = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "OriginalImages" + "\\" + dis.Name.ToString());

                        File.Copy(Linefilepath.ToString(), Path.Combine(targetDir, Path.GetFileNameWithoutExtension(labelfield.Name.ToString())) + ext, true);

                        originalimagepath = Path.Combine(targetDir, Path.GetFileNameWithoutExtension(labelfield.Name.ToString())) + ext;

                        DirectoryInfo diresize = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ResizeImages" + "\\"));
                        // Create the directory only if it does not already exist.
                        if (diresize.Exists == false)
                            diresize.Create();

                        // Create a subdirectory in the directory just created.
                        DirectoryInfo dirimgresize = diresize.CreateSubdirectory(txtdispname.Text.ToString().Trim());
                        resizeimagepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ResizeImages" + "\\" + dirimgresize.Name.ToString() + "\\" + Path.GetFileNameWithoutExtension(labelfield.Name.ToString()) + ext);

                        //Resize Image..
                        Image original = Image.FromFile(originalimagepath);

                        Image resized = ResizeImage(original, new Size(Convert.ToInt32(width), Convert.ToInt32(height)));

                        //MemoryStream memStream = new MemoryStream();
                        resized.Save(resizeimagepath, GetImageFormat(originalimagepath));
                        //write image to pdf at x,y location
                        Image original1 = Image.FromFile(resizeimagepath);
                        TypeConverter converter = TypeDescriptor.GetConverter(typeof(Image));

                        String TheImageAsString = Convert.ToBase64String((Byte[])converter.ConvertTo(original1, typeof(Byte[])));


                        clsTemplateLabelXmlwork lobjTemplate = new clsTemplateLabelXmlwork();
                        string strTransTypeFilePath = string.Empty;
                        string SetValuesForTransType = string.Empty;
                        string SetTemplatewidth = string.Empty;
                        string SetTemplateheight = string.Empty;
                        var widthmeasure = (coordinates.X / 2);
                        var heightmeasure = ((this.radDiagram1.Height) - coordinates.Y) / 2;

                        var wd = 0.010416f * widthmeasure;
                        var hd = 0.010416f * heightmeasure;

                        // MessageBox.Show("X-Cordinates" + xt, "Y-Cordinates" + yp);
                        double xdoclocation = Math.Round(wd, 2);
                        double ydoclocation = Math.Round(hd, 2);

                        if (results[0].fieldtype == "Line")
                        {
                            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork(
                                 txtdispname.Text.ToString(),
                                Convert.ToString(results[0].Id),
                                "Line",
                                Convert.ToString(results[0].fieldname).Trim(),
                                results[0].originimgpath.ToString(),
                                results[0].resizeimgpath,
                                Convert.ToString(results[0].orientation).Trim(),
                                Convert.ToString(width).Trim(),
                                Convert.ToString(height).Trim(),
                                Convert.ToString(xdoclocation).Trim(),
                                Convert.ToString(ydoclocation).Trim(),
                                Convert.ToString(coordinates.X).Trim(),
                                Convert.ToString(coordinates.Y).Trim(),
                                Convert.ToString(TheImageAsString));

                            if (lobjTemplatexml.UpdateTemplateDetails(lobjTemplatexml, Convert.ToString(labelfield.Name), string.Empty, string.Empty))
                            {

                            }
                            else
                            {
                                MessageBox.Show("Line name exist already", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            List<clsTemplateLabelXmlwork> objfieldlist2 = new List<clsTemplateLabelXmlwork>();
                            List<QuickBooksField> objheaderfield = new List<QuickBooksField>();
                            objfieldlist2 = lobjTemplate.GetFieldPropertiesList(txtdispname.Text, string.Empty);
                            //Get property fields list
                            List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();
                            // strTransTypeFilePath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + this.SetValuesForTransType + ".xml";

                            System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
                            if (dirtransxml.Exists)
                            {
                                strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + txtdistranstype.Text + ".xml");
                            }
                            else
                            {
                                strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + txtdistranstype.Text + ".xml");
                            }
                            if (File.Exists(strTransTypeFilePath))
                            {
                                Itemfieldlist = lobjTemplate.GetItemFieldListfromxml(strTransTypeFilePath); //Get field list
                            }


                            objheaderfield = lobjTemplate.GetTemplateHeaderInfo(txtdispname.Text);
                            foreach (QuickBooksField itemfield in objheaderfield)
                            {
                                if (itemfield.ItemFieldId == 1)
                                {
                                    SetValuesForTransType = itemfield.ItemFieldName;
                                }
                                else if (itemfield.ItemFieldId == 2)
                                {
                                    SetTemplatewidth = itemfield.ItemFieldName;
                                }
                                else if (itemfield.ItemFieldId == 3)
                                {
                                    SetTemplateheight = itemfield.ItemFieldName;
                                }
                            }

                            //string lstrerror;
                            lobjTemplate.InsertImageToPDF(txtdispname.Text.ToString(),
                                SetTemplatewidth,
                                SetTemplateheight,
                                SetValuesForTransType,
                                lobjTemplatexml.resizeimgpath,
                                Convert.ToSingle(lobjTemplatexml.imgwidth),
                                Convert.ToSingle(lobjTemplatexml.imgheight),
                                Convert.ToSingle(lobjTemplatexml.xposition),
                                Convert.ToSingle(lobjTemplatexml.yposition),
                                objfieldlist2,
                                Itemfieldlist);

                            if (txtdispname.Text != "")
                            {
                                ShowTemplatePdf(objfieldlist2);
                            }


                        }
                        else
                        {
                            MessageBox.Show("Invalid Image file", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                          ((RadLabel)sender).BorderVisible = true;

                }

            }
            UpdateMouseCursor(labelfield);
        }


        private  void label_MouseMove(object sender, MouseEventArgs e)
        {
            RadLabel labelfield = sender as RadLabel;
          
            if (!_resizing && !_moving)
            {
                UpdateMouseEdgeProperties(labelfield, new Point(e.X, e.Y));
                UpdateMouseCursor(labelfield);
            }
            if (_resizing)
            {
                labelfield.BackColor = Color.Black;
                if (MouseIsInLeftEdge)
                        {
                            if (MouseIsInTopEdge)
                            {
                                labelfield.Width -= (e.X - _cursorStartPoint.X);
                                labelfield.Left += (e.X - _cursorStartPoint.X);
                                labelfield.Height -= (e.Y - _cursorStartPoint.Y);
                                labelfield.Top += (e.Y - _cursorStartPoint.Y);
                            }
                            else if (MouseIsInBottomEdge)
                            {
                                labelfield.Width -= (e.X - _cursorStartPoint.X);
                                labelfield.Left += (e.X - _cursorStartPoint.X);
                                labelfield.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                            }
                            else
                            {
                                labelfield.Width -= (e.X - _cursorStartPoint.X);
                                labelfield.Left += (e.X - _cursorStartPoint.X);
                            }
                        }
                        else if (MouseIsInRightEdge)
                        {
                            if (MouseIsInTopEdge)
                            {
                                labelfield.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                                labelfield.Height -= (e.Y - _cursorStartPoint.Y);
                                labelfield.Top += (e.Y - _cursorStartPoint.Y);

                            }
                            else if (MouseIsInBottomEdge)
                            {
                                labelfield.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                                labelfield.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                            }
                            else
                            {
                                labelfield.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                            }
                        }
                        else if (MouseIsInTopEdge)
                        {
                            labelfield.Height -= (e.Y - _cursorStartPoint.Y);
                            labelfield.Top += (e.Y - _cursorStartPoint.Y);
                        }
                        else if (MouseIsInBottomEdge)
                        {
                            labelfield.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                        }
                        else
                        {
                            _moving = false;
                            labelfield.Capture = false;
                            UpdateMouseCursor(labelfield);
                        }
                    
             
            }
            else if (_moving)
            {
                _moveIsInterNal = !_moveIsInterNal;
                if (!_moveIsInterNal)
                {
                    int x = (e.X - _cursorStartPoint.X) + labelfield.Left;
                    int y = (e.Y - _cursorStartPoint.Y) + labelfield.Top;
                    labelfield.Location = new Point(x, y);
                }
            }
        }
        private static void UpdateMouseEdgeProperties(Control control, Point mouseLocationInControl)
        {
            if (WorkType == MoveOrResize.Move)
            {
                return;
            }
            MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= 2;
            MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - control.Width) <= 2;
            MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= 2;
            MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - control.Height) <= 2;
        }

        public static Image ResizeImage(Image image, Size size)
        {
            int newWidth = (Convert.ToInt32(size.Width));
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

        private static System.Drawing.Imaging.ImageFormat GetImageFormat(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(extension))
                throw new ArgumentException(
                    string.Format("Unable to determine file extension for fileName: {0}", fileName));

            switch (extension.ToLower())
            {
                case @".bmp":
                    return System.Drawing.Imaging.ImageFormat.Bmp;

                case @".gif":
                    return System.Drawing.Imaging.ImageFormat.Gif;

                case @".ico":
                    return System.Drawing.Imaging.ImageFormat.Icon;

                case @".jpg":
                case @".jpeg":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;

                case @".png":
                    return System.Drawing.Imaging.ImageFormat.Png;

                case @".tif":
                case @".tiff":
                    return System.Drawing.Imaging.ImageFormat.Tiff;

                case @".wmf":
                    return System.Drawing.Imaging.ImageFormat.Wmf;

                default:
                    throw new NotImplementedException();
            }
        }
       

        private static void UpdateMouseCursor(Control control)
        {
            if (MouseIsInLeftEdge)
            {
                if (MouseIsInTopEdge)
                {
                    control.Cursor = Cursors.SizeNWSE;
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Cursor = Cursors.SizeNESW;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInRightEdge)
            {
                if (MouseIsInTopEdge)
                {
                    control.Cursor = Cursors.SizeNESW;
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInTopEdge || MouseIsInBottomEdge)
            {
                control.Cursor = Cursors.SizeNS;
            }
            else
            {
                control.Cursor = Cursors.Default;
            }
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            RadLabel labelfield = sender as RadLabel;
            clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
            List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();

            objfieldlist = lobjtemplatenames.GetFieldPropertiesList(txtdispname.Text.ToString(), string.Empty);
            List<clsTemplateLabelXmlwork> results = objfieldlist.FindAll(x => x.fieldname == labelfield.Name);
            if (results.Count > 0)
            {
                Point coordinates = new Point(0, 0);
                if (results[0].fieldtype == "Text")
                {
                    var wraptext = clsTemplateLabelXmlwork.LineBreakByChar(Regex.Replace(Convert.ToString(labelfield.Tag), @"\s", ""), "X", 12);

                    string[] stringSeparators = new string[] { "\r\n" };
                    string[] lines = wraptext.Split(stringSeparators, StringSplitOptions.None);
                    if (Convert.ToString(lines[1].Trim()) == "")
                    {
                        coordinates = new Point(labelfield.Location.X, labelfield.Location.Y + Convert.ToInt32(lines[0]));
                    }
                    else
                    {
                        coordinates = new Point(labelfield.Location.X + Convert.ToInt32(lines[1]), labelfield.Location.Y + Convert.ToInt32(lines[0]));
                    }
                }
                else if (results[0].fieldtype == "BarCode")
                {
                     coordinates = new Point(labelfield.Location.X, labelfield.Location.Y + labelfield.Height - 4);
                }
                else
                {
                    coordinates = new Point(labelfield.Location.X-4, labelfield.Location.Y + labelfield.Height - 4);
                }
                
                if (results[0].xoriginalposition != coordinates.X.ToString() || results[0].yoriginalposition != coordinates.Y.ToString())
                {
                    clsTemplateLabelXmlwork lobjTemplate = new clsTemplateLabelXmlwork();
                    string strTransTypeFilePath = string.Empty;
                    string SetValuesForTransType = string.Empty;
                    string SetTemplatewidth = string.Empty;
                    string SetTemplateheight = string.Empty;
                    var widthmeasure = (coordinates.X / 2);
                    var heightmeasure = ((this.radDiagram1.Height) - coordinates.Y) / 2;

                    var wd = 0.010416f * widthmeasure;
                    var hd = 0.010416f * heightmeasure;

                    // MessageBox.Show("X-Cordinates" + xt, "Y-Cordinates" + yp);
                    double xdoclocation = Math.Round(wd, 2);
                    double ydoclocation = Math.Round(hd, 2);
                    if (results[0].fieldtype == "Text" || results[0].fieldtype == "BarCode")
                    {
                        clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork(
                            txtdispname.Text.ToString(),
                            Convert.ToString(results[0].Id),
                            Convert.ToString(results[0].fieldtype),
                            Convert.ToString(results[0].fieldname).Trim(),
                            Convert.ToString(results[0].datasource) == null ? "" : Convert.ToString(results[0].datasource),
                            Convert.ToString(results[0].datasourcetext) == null ? "" : Convert.ToString(results[0].datasourcetext),
                            Convert.ToString(results[0].testdata) == null ? "" : Convert.ToString(results[0].testdata).Trim(),
                            results[0].barcodetype == null ? "" : results[0].barcodetype.ToString(),
                            results[0].wordwrap == null ? "" : results[0].wordwrap.Trim().ToString(),
                            results[0].linebreak == null ? "" : results[0].linebreak.Trim().ToString(),
                            Convert.ToString(results[0].orientation) == null ? "" : Convert.ToString(results[0].orientation).Trim(),
                            results[0].imgwidth == null ? "" : results[0].imgwidth.ToString(),
                            results[0].imgheight == null ? "" : results[0].imgheight.ToString(),
                            results[0].imgnewwidth == null ? "" : results[0].imgnewwidth.ToString(),
                            Convert.ToString(xdoclocation).Trim(),
                            Convert.ToString(ydoclocation).Trim(),
                            Convert.ToString(results[0].fontsize) == null ? "" : Convert.ToString(results[0].fontsize).Trim(),
                            Convert.ToString(results[0].delimiter),
                            Convert.ToString(coordinates.X).Trim(),
                            Convert.ToString(coordinates.Y).Trim(),
                            Convert.ToString(results[0].barcodestring),
                            Convert.ToString(results[0].barcharvisible),
                            Convert.ToString(results[0].DataCharView),
                            Convert.ToString(results[0].DataCharAlign),
                            Convert.ToString(results[0].fontbold),
                            Convert.ToString(results[0].textAlign));

                        var rr = lobjTemplatexml.UpdateTemplateDetails(lobjTemplatexml, Convert.ToString(labelfield.Name), string.Empty, Convert.ToString(txtdistranstype.Text.ToLower().Trim()));

                        List<clsTemplateLabelXmlwork> objfieldlist1 = new List<clsTemplateLabelXmlwork>();
                        List<QuickBooksField> objheaderfield = new List<QuickBooksField>();
                        objfieldlist = lobjTemplatexml.GetFieldPropertiesList(txtdispname.Text, string.Empty);
                        //Get property fields list
                        List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();
                        //strTransTypeFilePath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + this.SetValuesForTransType + ".xml";

                        System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
                        if (dirtransxml.Exists)
                        {
                            strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + txtdistranstype.Text + ".xml");
                        }
                        else
                        {
                            strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + txtdistranstype.Text + ".xml");
                        }
                        if (File.Exists(strTransTypeFilePath))
                        {
                            Itemfieldlist = lobjTemplate.GetItemFieldListfromxml(strTransTypeFilePath); //Get field list
                        }


                        objheaderfield = lobjTemplate.GetTemplateHeaderInfo(txtdispname.Text);
                        foreach (QuickBooksField itemfield in objheaderfield)
                        {
                            if (itemfield.ItemFieldId == 1)
                            {
                                SetValuesForTransType = itemfield.ItemFieldName;
                            }
                            else if (itemfield.ItemFieldId == 2)
                            {
                                SetTemplatewidth = itemfield.ItemFieldName;
                            }
                            else if (itemfield.ItemFieldId == 3)
                            {
                                SetTemplateheight = itemfield.ItemFieldName;
                            }
                        }
                        //string lstrerror;
                        lobjTemplate.CreateUpdateTemplatePDF(txtdispname.Text, SetTemplatewidth, SetTemplateheight, lobjTemplatexml.fieldtype, SetValuesForTransType, objfieldlist, Itemfieldlist);
                    }
                    else if (results[0].fieldtype == "Image")
                    {
                        clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork(
                             txtdispname.Text.ToString(),
                            Convert.ToString(results[0].Id),
                            "Image",
                            Convert.ToString(results[0].fieldname).Trim(),
                            results[0].originimgpath.ToString(),
                            results[0].resizeimgpath,
                            Convert.ToBoolean(results[0].aspectratio).ToString(),
                            Convert.ToString(results[0].orientation).Trim(),
                            Convert.ToString(results[0].imgwidth).Trim(),
                            Convert.ToString(results[0].imgheight).Trim(),
                            Convert.ToString(xdoclocation).Trim(),
                            Convert.ToString(ydoclocation).Trim(),
                            Convert.ToString(coordinates.X).Trim(),
                            Convert.ToString(coordinates.Y).Trim(),
                            Convert.ToString(results[0].imagestring),
                            Convert.ToString(results[0].datasource),
                            Convert.ToString(results[0].datasourcetext),
                              Convert.ToBoolean(results[0].UseFixedImage).ToString(),
                                Convert.ToBoolean(results[0].UseVariableImage).ToString());

                        if (lobjTemplatexml.UpdateTemplateDetails(lobjTemplatexml, Convert.ToString(labelfield.Name), string.Empty, string.Empty))
                        {

                        }
                        else
                        {
                            MessageBox.Show("ImageName exist already", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        List<clsTemplateLabelXmlwork> objfieldlist2 = new List<clsTemplateLabelXmlwork>();
                        List<QuickBooksField> objheaderfield = new List<QuickBooksField>();
                        objfieldlist2 = lobjTemplate.GetFieldPropertiesList(txtdispname.Text, string.Empty);
                        //Get property fields list
                        List<QuickBooksField> Itemfieldlist = new List<QuickBooksField>();
                        // strTransTypeFilePath = System.Windows.Forms.Application.StartupPath + @"\" + "FieldPropertiesxml" + "\\" + this.SetValuesForTransType + ".xml";

                        System.IO.DirectoryInfo dirtransxml = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\"));
                        if (dirtransxml.Exists)
                        {
                            strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Transxml" + "\\" + txtdistranstype.Text + ".xml");
                        }
                        else
                        {
                            strTransTypeFilePath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "FieldPropertiesxml" + "\\" + txtdistranstype.Text + ".xml");
                        }
                        if (File.Exists(strTransTypeFilePath))
                        {
                            Itemfieldlist = lobjTemplate.GetItemFieldListfromxml(strTransTypeFilePath); //Get field list
                        }


                        objheaderfield = lobjTemplate.GetTemplateHeaderInfo(txtdispname.Text);
                        foreach (QuickBooksField itemfield in objheaderfield)
                        {
                            if (itemfield.ItemFieldId == 1)
                            {
                                SetValuesForTransType = itemfield.ItemFieldName;
                            }
                            else if (itemfield.ItemFieldId == 2)
                            {
                                SetTemplatewidth = itemfield.ItemFieldName;
                            }
                            else if (itemfield.ItemFieldId == 3)
                            {
                                SetTemplateheight = itemfield.ItemFieldName;
                            }
                        }

                        //string lstrerror;
                        lobjTemplate.InsertImageToPDF(txtdispname.Text.ToString(),
                            SetTemplatewidth,
                            SetTemplateheight,
                            SetValuesForTransType,
                            lobjTemplatexml.resizeimgpath,
                            Convert.ToSingle(lobjTemplatexml.imgwidth),
                            Convert.ToSingle(lobjTemplatexml.imgheight),
                            Convert.ToSingle(lobjTemplatexml.xposition),
                            Convert.ToSingle(lobjTemplatexml.yposition),
                            objfieldlist2,
                            Itemfieldlist);

                        if (txtdispname.Text != "")
                        {
                            ShowTemplatePdf(objfieldlist2);
                        }


                    }
                   
                    else
                    {
                        MessageBox.Show("Invalid Image file", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }

            }
            Cursor.Current = Cursors.Default;
            labelfield.BorderVisible = false;
        }

        public void ShowTemplatePdf(List<clsTemplateLabelXmlwork> objfieldlist)
        {
            gbtemplatepreview.Visible = true;
            string imgpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfImagesList" + "\\" + txtdispname.Text.ToString().Trim() + "\\" + txtdispname.Text.ToString().Trim() + ".Tiff");

            try
            {
                //pictureBox1.Image = null;
                if (File.Exists(imgpath))
                {
                    Image image = Image.FromFile(imgpath);
                    // Set the PictureBox image property to this image.
                    //radDiagram1 = new Telerik.WinControls.UI.RadDiagram();
                    radDiagram1.Height = image.Height;
                    radDiagram1.Width = image.Width-20;

                    for (int i = 0; 1 <= radDiagram1.Controls.Count; i++)
                    {
                        radDiagram1.Controls.RemoveAt(radDiagram1.Controls.Count - 1);
                    }

                    foreach (clsTemplateLabelXmlwork item in objfieldlist)
                    {
                        AddNewLabel(item);
                    }

                    //panel1.AutoScrollPosition = new Point(Math.Abs(300), Math.Abs(400));
                }
                else
                {
                    gbtemplatepreview.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            CheckTemplateSave();
            gbshowheaderdata.Visible = false;
            btnaddtext.Visible = false;
            btnaddbarcode.Visible = false;
            btnAddImage.Visible = false;
            btnAddLine.Visible = false;
            btntestprint.Visible = false;
            gbtemplatepreview.Visible = false;
            gvfieldview.Visible = false;
            toolStripButton7.Visible = false;
            toolStripButton6.Visible = false;
            toolStripButton5.Visible = false;
            toolStripButton4.Visible = false;
            toolStripButton11.Visible = false;
            if ( Globalvariables.PrintTemplateStatus == "1")
            {
                Globalvariables.PrintTemplateStatus = "2";
            }
        }

        private void gvfieldview_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            //  if (e.ColumnIndex == 1  &&  e.RowIndex >= 0)
            //  {

            //      e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            //      Image img = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\" + "Images" + "\\" + "Trash24.png" ); //write your own path!

            //      e.Graphics.DrawImage(img, e.CellBounds.Left + 10, e.CellBounds.Top + 5, 24, 24);

            //      e.Handled = true;

            //}

        }

        private void gvfieldview_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == gvfieldview.Columns["edit"].Index)
            {
                var cell = gvfieldview.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Set the Cell's ToolTipText.  In this case we're retrieving the value stored in 

                cell.ToolTipText = "edit";
            }
            else if (e.ColumnIndex == gvfieldview.Columns["delete"].Index)
            {
                var cell = gvfieldview.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Set the Cell's ToolTipText.  In this case we're retrieving the value stored in 

                cell.ToolTipText = "delete";
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.Close(); //close window
        }        
        private void btntestprint_Click(object sender, EventArgs e)
        {
            if(!CheckTemplateSave())
            {
                return;
            }
            
            clsTemplateLabelXmlwork objtemplate = new clsTemplateLabelXmlwork();
            clsTemplateStatus objtemp =new clsTemplateStatus();
            objtemp = objtemplate.GetTemplateStatus();
            txtdispname.Text = Path.GetFileNameWithoutExtension(objtemp.TempTemplatePath);

            string strtestprintfilepath = string.Empty;
            btnTextType = false;
            btnBarcodeType = false;
            btnImageType = false;
            btnLineType = false;
            //btnaddtext.FlatStyle = FlatStyle.Standard;
            //btnaddtext.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnaddtext.FlatAppearance.BorderSize = 0;

            //btnAddImage.FlatStyle = FlatStyle.Standard;
            //btnAddImage.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnAddImage.FlatAppearance.BorderSize = 0;


            //btnaddbarcode.FlatStyle = FlatStyle.Standard;
            //btnaddbarcode.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnaddbarcode.FlatAppearance.BorderSize = 0;



            //test print
            strtestprintfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TestPrint" + "\\" + txtdispname.Text.ToString() + ".Tiff");

            //if (gbtemplatepreview.Visible == true)
            //{

            if (File.Exists(strtestprintfilepath))
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete(strtestprintfilepath);

            }
            //create test print
            objtemplate.CreateTestTemplate(txtdispname.Text.ToString());

            // }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            CheckTemplateSave();

            //open import template
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();


            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse xml Files";          
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TempPath" + "\\" + "TempLastPath" + ".xml");


            if (File.Exists(strStartupPath))
            {
                clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
                var tempStatus = lobjTemplatexml.GetTemplateStatus();
                if (tempStatus.TemplatePath != "")
                {
                    //string Labelpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Label Connector Documents";

                    //if (!Directory.Exists(Labelpath))
                    //    Directory.CreateDirectory(Labelpath);
                    openFileDialog1.InitialDirectory = tempStatus.TemplatePath.Replace(tempStatus.TemplatePath, Path.GetDirectoryName(tempStatus.TemplatePath));
                    openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
                    openFileDialog1.FilterIndex = 0;
                    openFileDialog1.DefaultExt = "xml";
                    //openFileDialog1.InitialDirectory = Labelpath;

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        openLabelStatus = 1;
                        UpdateFilePath(openFileDialog1.FileName.ToString());
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {

                    string Labelpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Label Connector Documents";

                    if (!Directory.Exists(Labelpath))
                        Directory.CreateDirectory(Labelpath);
               
                    openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
                    openFileDialog1.FilterIndex = 0;
                    openFileDialog1.DefaultExt = "xml";
                    openFileDialog1.InitialDirectory = Labelpath;

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        openLabelStatus = 1;
                        UpdateFilePath(openFileDialog1.FileName.ToString());
                    }
                    else
                    {
                        return;
                    }
                }
            }

            else
            {
                string Labelpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Label Connector Documents";

                if (!Directory.Exists(Labelpath))
                    Directory.CreateDirectory(Labelpath);
                openFileDialog1.InitialDirectory = Labelpath;
                openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.DefaultExt = "xml";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    openLabelStatus = 1;
                    UpdateFilePath(openFileDialog1.FileName.ToString());
                }
                else
                {
                    return;
                }

            }

            bool istemplateexist = false;
            clsTemplateStatus tempstatus = new clsTemplateStatus();
            clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
         
                tempstatus = lobjtemplatenames.GetTemplateStatus();
                string targetDir = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\");
                if (!Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);

                }
                if (File.Exists(targetDir + Path.GetFileName(tempstatus.TemplatePath)))
                {
                    File.Delete(targetDir + Path.GetFileName(tempstatus.TemplatePath));

                }
                File.Copy(tempstatus.TemplatePath, Path.Combine(targetDir, Path.GetFileName(tempstatus.TemplatePath)), true);
                tempstatus.TempTemplatePath = targetDir + Path.GetFileName(tempstatus.TemplatePath);
                lobjtemplatenames.SaveTemplateStatus(tempstatus);
                // lstrgettargetfile = System.Windows.Forms.Application.StartupPath + @"\" + "TemplateImageslist" + "\\" + openFileDialog1.FileName.ToString() + ".xml";
                lobjtemplatenames = new clsTemplateLabelXmlwork();
                var templatenodecount = lobjtemplatenames.CheckImportXmlFormat(Path.GetFileNameWithoutExtension(tempstatus.TempTemplatePath));
                //istemplateexist = lobjtemplatenames.IsTemplateFieldInXml(Path.GetFileNameWithoutExtension(tempstatus.TempTemplatePath));
                //if (!istemplateexist) //template name attr not exist
                //{
                //    MessageBox.Show("Invalid Template Format", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                if (templatenodecount.Count != 4)
                {
                    MessageBox.Show("Invalid Template Format", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                PassheaderTemplateImportData((Path.GetFileNameWithoutExtension(tempstatus.TempTemplatePath)));


            ////if (System.Windows.Forms.Application.OpenForms["ImportTemplate"] == null)
            ////{

            ////    LabelConnector.ImportTemplate lobjLabelConnectorSettings = new LabelConnector.ImportTemplate();

            ////    // Create an instance of the delegate
            ////    lobjLabelConnectorSettings.passheadercontrolimporttemplate = new ImportTemplate.PassHeaderControlImporttemplate(PassheaderTemplateImportData);

            ////    lobjLabelConnectorSettings.ShowInTaskbar = false;
            ////    lobjLabelConnectorSettings.Text = "Open";
            ////    lobjLabelConnectorSettings.ShowDialog();
            ////}



            openLabelStatus = 0;
        }
        public void UpdateFilePath(string filepath)
        {
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            clsTemplateStatus tempstatus = new clsTemplateStatus();
            tempstatus.TemplatePath = Convert.ToString(filepath);
            tempstatus.TemplateSave = "0";
            tempstatus.TemplateMode = "Edit";
            tempstatus.TemplateStatus = "1";
            tempstatus.TempTemplatePath = "";
            lobjTemplatexml.SaveTemplateStatus(tempstatus);         
        }
        private void btnAddImage_Click(object sender, EventArgs e)
        {

            btnImageType = true;
            btnBarcodeType = false;
            btnTextType = false;
            btnLineType = false;
            this.btnAddImage.Select();

            lobjQBConfiguration = new QBConfiguration();
            if ((lobjQBConfiguration.GetLabelConfigSettings("isShowDesignPopup").ToString().ToLower() == "false"))
            {
                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                if (System.Windows.Forms.Application.OpenForms["FrmConfirmPopup"] == null)
                {

                    LabelConnector.FrmConfirmPopup lobjLabelConnectorSettings = new LabelConnector.FrmConfirmPopup();
                    lobjLabelConnectorSettings.ShowInTaskbar = false;

                    lobjLabelConnectorSettings.ShowDialog();

                }
            }
            //btnAddImage.FlatStyle = FlatStyle.Flat;
            //btnAddImage.FlatAppearance.BorderColor = Color.SlateBlue;
            //btnAddImage.FlatAppearance.BorderSize = 1;

            //btnaddtext.FlatStyle = FlatStyle.Standard;
            //btnaddtext.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnaddtext.FlatAppearance.BorderSize = 0;

            //btnaddbarcode.FlatStyle = FlatStyle.Standard;
            //btnaddbarcode.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnaddbarcode.FlatAppearance.BorderSize = 0;



            //Add image to pdf preview:Date 30-Mar-2019
            //if (ActiveMdiChild != null)
            //    ActiveMdiChild.Close();

            //if (System.Windows.Forms.Application.OpenForms["FrmAddImages"] == null)
            //{

            //    LabelConnector.FrmAddImages lobjLabelConnectorSettings = new LabelConnector.FrmAddImages(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString());

            //    // Create an instance of the delegate
            //     lobjLabelConnectorSettings.passControlimg = new FrmAddImages.PassControlimg(PassDataimg);

            //    delImageData delimg = new delImageData(lobjLabelConnectorSettings.funDataimg);
            //    delimg(txtdispname.Text.ToString().Trim(), "image");
            //    lobjLabelConnectorSettings.ShowInTaskbar = false;

            //    lobjLabelConnectorSettings.ShowDialog();


            //}

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (btnTextType == true || btnBarcodeType == true || btnImageType == true || btnLineType == true)
            // if (btnAddImage.FlatStyle == FlatStyle.Flat || btnaddtext.FlatStyle == FlatStyle.Flat || btnaddbarcode.FlatStyle== FlatStyle.Flat)
            {

               
                 this.Cursor = Cursors.Cross;
                
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            var widthmeasure = (coordinates.X / 2);
            var heightmeasure = ((this.pictureBox1.Height) - coordinates.Y) / 2;

            var wd = 0.010416f * widthmeasure;
            var hd = 0.010416f * heightmeasure;

            // MessageBox.Show("X-Cordinates" + xt, "Y-Cordinates" + yp);
            double xdoclocation = Math.Round(wd, 2);
            double ydoclocation = Math.Round(hd, 2);


            if (btnTextType == false && btnBarcodeType == false && btnImageType == false && btnLineType == false)
            {
                MessageBox.Show("Please Select Field Type(Text,BarCode,Image,Line)", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            if (btnImageType == false)
            // if (btnAddImage.FlatStyle == FlatStyle.Standard)
            {
                //code first text type
                if (btnTextType == true)
                {
                    if (System.Windows.Forms.Application.OpenForms["FrmAddEditField"] == null)
                    {

                        LabelConnector.FrmAddEditField lobjLabelConnectorSettings = new LabelConnector.FrmAddEditField(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), Convert.ToSingle(xdoclocation), Convert.ToSingle(ydoclocation), coordinates.X.ToString(), coordinates.Y.ToString(), null);


                        // Create an instance of the delegate
                        lobjLabelConnectorSettings.passControl = new FrmAddEditField.PassControl(PassData);

                        delPassData del = new delPassData(lobjLabelConnectorSettings.funData);
                        if (btnTextType == true) //open text dialogue
                                                 // if(btnaddtext.FlatStyle == FlatStyle.Flat)
                        {
                            del(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), xdoclocation.ToString(), ydoclocation.ToString(), "Text"); //txtdispwidth.Text.ToString(), txtdispheight.Text.ToString()

                        }
                        else if (btnBarcodeType == true) //open barcode dialogue
                                                         // if(btnaddbarcode.FlatStyle == FlatStyle.Flat)
                        {
                            del(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), xdoclocation.ToString(), ydoclocation.ToString(), "BarCode"); //txtdispwidth.Text.ToString(), txtdispheight.Text.ToString()
                                                                                                                                                                   // btnBarcodeType = false;
                        }


                        lobjLabelConnectorSettings.ShowInTaskbar = false;
                        lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();
                        lobjLabelConnectorSettings.ShowDialog();


                    }
                }
                else if (btnBarcodeType==true)
                {
                    //second code for test for barcode type
                    if (System.Windows.Forms.Application.OpenForms["FrmAddEditFieldBarCode"] == null)
                    {

                        LabelConnector.FrmAddEditFieldBarCode lobjLabelConnectorSettings = new LabelConnector.FrmAddEditFieldBarCode(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), Convert.ToSingle(xdoclocation), Convert.ToSingle(ydoclocation), coordinates.X.ToString(), coordinates.Y.ToString(), null);


                        // Create an instance of the delegate
                        lobjLabelConnectorSettings.passControl = new FrmAddEditFieldBarCode.PassControl(PassData);

                        delPassData del = new delPassData(lobjLabelConnectorSettings.funData);
                        if (btnTextType == true) //open text dialogue
                                                 // if(btnaddtext.FlatStyle == FlatStyle.Flat)
                        {
                            del(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), xdoclocation.ToString(), ydoclocation.ToString(), "Text"); //txtdispwidth.Text.ToString(), txtdispheight.Text.ToString()

                        }
                        else if (btnBarcodeType == true) //open barcode dialogue
                                                         // if(btnaddbarcode.FlatStyle == FlatStyle.Flat)
                        {
                            del(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), xdoclocation.ToString(), ydoclocation.ToString(), "BarCode"); //txtdispwidth.Text.ToString(), txtdispheight.Text.ToString()
                                                                                                                                                                   // btnBarcodeType = false;
                        }


                        lobjLabelConnectorSettings.ShowInTaskbar = false;
                        lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();

                        lobjLabelConnectorSettings.ShowDialog();


                    }
                }
                else if (btnLineType == true)
                {
                    if (System.Windows.Forms.Application.OpenForms["FrmAddLineProperty"] == null)
                    {

                        LabelConnector.FrmAddLineProperty lobjLabelConnectorSettings = new LabelConnector.FrmAddLineProperty(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), Convert.ToSingle(xdoclocation), Convert.ToSingle(ydoclocation), coordinates.X.ToString(), coordinates.Y.ToString(),Convert.ToDouble(txtdispwidth.Text), Convert.ToDouble(txtdispheight.Text));

                        // Create an instance of the delegate
                        lobjLabelConnectorSettings.passControl = new FrmAddLineProperty.PassControl(PassData);

                        delImageData del = new delImageData(lobjLabelConnectorSettings.funData);
                        del(txtdispname.Text.ToString().Trim(), xdoclocation.ToString(), ydoclocation.ToString(), "Line");
                        lobjLabelConnectorSettings.ShowInTaskbar = false;
                        lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();
                        lobjLabelConnectorSettings.ShowDialog();


                    }
                }

            }
            else
            {
                if (System.Windows.Forms.Application.OpenForms["FrmAddImages"] == null)
                {
        
                    LabelConnector.FrmAddImages lobjLabelConnectorSettings = new LabelConnector.FrmAddImages(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), Convert.ToSingle(xdoclocation), Convert.ToSingle(ydoclocation), coordinates.X.ToString(), coordinates.Y.ToString(), Convert.ToDouble(txtdispwidth.Text), Convert.ToDouble(txtdispheight.Text)); //Convert.ToInt32(widthmeasure), Convert.ToInt32(heightmeasure)

                    // Create an instance of the delegate
                    lobjLabelConnectorSettings.passControlimg = new FrmAddImages.PassControlimg(PassDataimg);

                    delImageData delimg = new delImageData(lobjLabelConnectorSettings.funDataimg);
                    delimg(txtdispname.Text.ToString().Trim(), xdoclocation.ToString(), ydoclocation.ToString(), "image");
                    lobjLabelConnectorSettings.ShowInTaskbar = false;
                    lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();
                    lobjLabelConnectorSettings.ShowDialog();


                }
            }

        }

        private void FrmLabelDesign_MouseClick(object sender, MouseEventArgs e)
        {
            //  btnTextType = false;
            // btnBarcodeType = false;
            // btnImageType = false;
            //btnaddtext.TabStop = false;
            //button1.FlatStyle = FlatStyle.Flat;
            //button1.FlatAppearance.BorderSize = 0;

            //btnaddtext.FlatStyle = FlatStyle.Standard;
            //btnaddtext.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnaddtext.FlatAppearance.BorderSize = 0;

            //btnaddbarcode.FlatStyle = FlatStyle.Standard;
            //btnaddbarcode.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnaddbarcode.FlatAppearance.BorderSize = 0;

            //btnAddImage.FlatStyle = FlatStyle.Standard;
            //btnAddImage.FlatAppearance.BorderColor = Color.LightSlateGray;
            //btnAddImage.FlatAppearance.BorderSize = 0;
            //btnTextType = false;
            //btnBarcodeType = false;
            //btnImageType = false;
            //// btntestprint.Focus();
            //gvfieldview.Focus();
            //btnTextType = false;
            //btnBarcodeType = false;
            //btnImageType = false;

        }


        private void FrmLabelDesign_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //btnTextType = false;
            //btnBarcodeType = false;
            //btnImageType = false;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            //btnTextType = false;
            //btnBarcodeType = false;
            //btnImageType = false;
            //btnTextType = false;
            //btnBarcodeType = false;
            //btnImageType = false;
            //// btntestprint.Focus();
            //gvfieldview.Focus();


        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            btnTextType = false;
            btnBarcodeType = false;
            btnImageType = false;
            btnLineType = false;
            //// btntestprint.Focus();
            // gvfieldview.Focus();
            // btnaddtext.FlatAppearance.BorderSize = 0;
            // btnaddbarcode.FlatAppearance.BorderSize = 0;
            //btnAddImage.FlatAppearance.BorderSize = 0;
            //btnaddtext.TabStop = false;
            //btnaddbarcode.TabStop = false;
            //btnaddbarcode.TabStop = false;
        }

        private void radDiagram1_MouseClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            var widthmeasure = (coordinates.X / 2);
            var heightmeasure = ((this.radDiagram1.Height) - coordinates.Y) / 2;

            var wd = 0.010416f * widthmeasure;
            var hd = 0.010416f * heightmeasure;

            // MessageBox.Show("X-Cordinates" + xt, "Y-Cordinates" + yp);
            double xdoclocation = Math.Round(wd, 2);
            double ydoclocation = Math.Round(hd, 2);


            if (btnTextType == false && btnBarcodeType == false && btnImageType == false && btnLineType == false)
            {
                MessageBox.Show("Please Select Field Type(Text,BarCode,Image,Line)", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            if (btnImageType == false)
            // if (btnAddImage.FlatStyle == FlatStyle.Standard)
            {
                //code first text type
                if (btnTextType == true)
                {
                    if (System.Windows.Forms.Application.OpenForms["FrmAddEditField"] == null)
                    {                

                        LabelConnector.FrmAddEditField lobjLabelConnectorSettings = new LabelConnector.FrmAddEditField(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), Convert.ToSingle(xdoclocation), Convert.ToSingle(ydoclocation), coordinates.X.ToString(), coordinates.Y.ToString(), null);
                  
                        // Create an instance of the delegate
                        lobjLabelConnectorSettings.passControl = new FrmAddEditField.PassControl(PassData);

                        delPassData del = new delPassData(lobjLabelConnectorSettings.funData);
                        if (btnTextType == true) //open text dialogue
                                                 // if(btnaddtext.FlatStyle == FlatStyle.Flat)
                        {
                            del(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), xdoclocation.ToString(), ydoclocation.ToString(), "Text"); //txtdispwidth.Text.ToString(), txtdispheight.Text.ToString()

                        }
                        else if (btnBarcodeType == true) //open barcode dialogue
                                                         // if(btnaddbarcode.FlatStyle == FlatStyle.Flat)
                        {
                            del(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), xdoclocation.ToString(), ydoclocation.ToString(), "BarCode"); //txtdispwidth.Text.ToString(), txtdispheight.Text.ToString()
                                                                                                                                                                   // btnBarcodeType = false;
                        }                        
                        lobjLabelConnectorSettings.ShowInTaskbar = false;
                        lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();
                        lobjLabelConnectorSettings.ShowDialog();              


                    }
                }
                else if (btnBarcodeType == true)
                {
                    //second code for test for barcode type
                    if (System.Windows.Forms.Application.OpenForms["FrmAddEditFieldBarCode"] == null)
                    {

                        LabelConnector.FrmAddEditFieldBarCode lobjLabelConnectorSettings = new LabelConnector.FrmAddEditFieldBarCode(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), Convert.ToSingle(xdoclocation), Convert.ToSingle(ydoclocation), coordinates.X.ToString(), coordinates.Y.ToString(), null);


                        // Create an instance of the delegate
                        lobjLabelConnectorSettings.passControl = new FrmAddEditFieldBarCode.PassControl(PassData);

                        delPassData del = new delPassData(lobjLabelConnectorSettings.funData);
                        if (btnTextType == true) //open text dialogue
                                                 // if(btnaddtext.FlatStyle == FlatStyle.Flat)
                        {
                            del(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), xdoclocation.ToString(), ydoclocation.ToString(), "Text"); //txtdispwidth.Text.ToString(), txtdispheight.Text.ToString()

                        }
                        else if (btnBarcodeType == true) //open barcode dialogue
                                                         // if(btnaddbarcode.FlatStyle == FlatStyle.Flat)
                        {
                            del(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), xdoclocation.ToString(), ydoclocation.ToString(), "BarCode"); //txtdispwidth.Text.ToString(), txtdispheight.Text.ToString()
                                                                                                                                                                   // btnBarcodeType = false;
                        }


                        lobjLabelConnectorSettings.ShowInTaskbar = false;
                        lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();
                        lobjLabelConnectorSettings.ShowDialog();


                    }
                }

                else if (btnLineType == true)
                {
                    if (System.Windows.Forms.Application.OpenForms["FrmAddLineProperty"] == null)
                    {

                        LabelConnector.FrmAddLineProperty lobjLabelConnectorSettings = new LabelConnector.FrmAddLineProperty(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), Convert.ToSingle(xdoclocation), Convert.ToSingle(ydoclocation), coordinates.X.ToString(), coordinates.Y.ToString(), Convert.ToDouble(txtdispwidth.Text), Convert.ToDouble(txtdispheight.Text));

                        // Create an instance of the delegate
                        lobjLabelConnectorSettings.passControl = new FrmAddLineProperty.PassControl(PassData);

                        delImageData del = new delImageData(lobjLabelConnectorSettings.funData);
                        del(txtdispname.Text.ToString().Trim(), xdoclocation.ToString(), ydoclocation.ToString(), "Line");
                        lobjLabelConnectorSettings.ShowInTaskbar = false;
                        lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();
                        lobjLabelConnectorSettings.ShowDialog();


                    }
                }

            }
            else
            {
                if (System.Windows.Forms.Application.OpenForms["FrmAddImages"] == null)
                {

                    LabelConnector.FrmAddImages lobjLabelConnectorSettings = new LabelConnector.FrmAddImages(txtdispname.Text.ToString().Trim(), txtdistranstype.Text.ToString(), Convert.ToSingle(xdoclocation), Convert.ToSingle(ydoclocation), coordinates.X.ToString(), coordinates.Y.ToString(), Convert.ToDouble(txtdispwidth.Text), Convert.ToDouble(txtdispheight.Text)); //Convert.ToInt32(widthmeasure), Convert.ToInt32(heightmeasure)

                    // Create an instance of the delegate
                    lobjLabelConnectorSettings.passControlimg = new FrmAddImages.PassControlimg(PassDataimg);

                    delImageData delimg = new delImageData(lobjLabelConnectorSettings.funDataimg);
                    delimg(txtdispname.Text.ToString().Trim(), xdoclocation.ToString(), ydoclocation.ToString(), "image");
                    lobjLabelConnectorSettings.ShowInTaskbar = false;

                    lobjLabelConnectorSettings.designerHeight = radDiagram1.Height.ToString();
                    lobjLabelConnectorSettings.ShowDialog();

                        
                }
            }
        }

        private void radDiagram1_MouseEnter(object sender, EventArgs e)
        {
            if (btnTextType == true || btnBarcodeType == true || btnImageType == true || btnLineType == true)
            // if (btnAddImage.FlatStyle == FlatStyle.Flat || btnaddtext.FlatStyle == FlatStyle.Flat || btnaddbarcode.FlatStyle== FlatStyle.Flat)
            {


                this.Cursor = Cursors.Cross;

            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void radDiagram1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void property_Click(object sender, EventArgs e)
        {
            if (Activefield != "")
            {
                int rowIndex = -1;
                foreach (DataGridViewRow row in gvfieldview.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(Activefield))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                gvfieldview.CurrentCell = gvfieldview.Rows[rowIndex].Cells[5];
                var arg = new DataGridViewCellEventArgs(5, rowIndex);
                gvfieldview_CellContentClick(gvfieldview, arg);
            }
        }

        private void cntxtdelete_Click(object sender, EventArgs e)
        {
            if (Activefield != "")
            {
                int rowIndex = -1;
                foreach (DataGridViewRow row in gvfieldview.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(Activefield))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                gvfieldview.CurrentCell = gvfieldview.Rows[rowIndex].Cells[6];
                var arg = new DataGridViewCellEventArgs(6, rowIndex);
                gvfieldview_CellContentClick(gvfieldview, arg);
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            bool result = false;
            clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
            clsTemplateStatus templateStatus = new clsTemplateStatus();
            templateStatus= lobjtemplatenames.GetTemplateStatus();
            if (templateStatus.TemplateMode.ToLower() == "New".ToLower())
            {
                result=lobjtemplatenames.SaveNewTemplate();
                lobjtemplatenames = new clsTemplateLabelXmlwork();
                templateStatus = lobjtemplatenames.GetTemplateStatus();
                txtdispname.Text = Path.GetFileNameWithoutExtension(templateStatus.TempTemplatePath);
            }
            else
            {
                result=lobjtemplatenames.UpdateTemplate();
            }            
            
            if (result)
            {
                Globalvariables.PrintTemplateStatus = "1";
                MessageBox.Show("Saved Successfully.", "Template Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Error on Save", "Template Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvfieldview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            clsTemplateLabelXmlwork objtemplate = new clsTemplateLabelXmlwork();
            clsTemplateStatus objTempStatus = new clsTemplateStatus();
            objTempStatus = objtemplate.GetTemplateStatus();
            if(openLabelStatus == 1)
            {
                objTempStatus.TemplateSave = "0";
                
            }
            else
            {
                objTempStatus.TemplateSave = "1";
            }
           
            objtemplate.SaveTemplateStatus(objTempStatus);

        }

        private void radDiagram1_ControlAdded(object sender, ControlEventArgs e)
        {
            clsTemplateLabelXmlwork objtemplate = new clsTemplateLabelXmlwork();
            clsTemplateStatus objTempStatus = new clsTemplateStatus();
            objTempStatus = objtemplate.GetTemplateStatus();
            if (openLabelStatus == 1)
            {
                objTempStatus.TemplateSave = "0";
            }
            else
            {
                objTempStatus.TemplateSave = "1";
            }
            
            objtemplate.SaveTemplateStatus(objTempStatus);
        }

        private void txtdispwidth_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtdispheight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdispname_TextChanged(object sender, EventArgs e)
        {
           if (txtdispname.Text.ToLower()=="TempTemplate".ToLower())
            {
                txtdispname1.Text = "UnSaved";
            }
            else
            {
                txtdispname1.Text = txtdispname.Text;
            }
        }
        public bool CheckTemplateSave(string saveAs ="")
        {
            clsTemplateStatus tempstatus = new clsTemplateStatus();
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TempPath" + "\\" + "TempLastPath" + ".xml");
            if (File.Exists(strStartupPath))
            {
               
                tempstatus = lobjTemplatexml.GetTemplateStatus();
                if (tempstatus.TemplateMode.ToLower() == "New".ToLower() && tempstatus.TemplateSave == "1")
                {
                    if (saveAs != "SaveAs")
                    {
                        var dilogdialogue = MessageBox.Show("The 'Current Template' is not saved. Do you want to save the template?", "Save Template", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        switch (dilogdialogue)
                        {
                            case (DialogResult.Yes):
                                {

                                    return lobjTemplatexml.SaveNewTemplate();
                                    //gbshowheaderdata.Visible = false;
                                    ////pnlbtnarray1.Visible = false;
                                    //btnaddtext.Visible = false;
                                    //btnaddbarcode.Visible = false;
                                    //btnAddImage.Visible = false;
                                    //btntestprint.Visible = false;
                                    //gbtemplatepreview.Visible = false;
                                    //gvfieldview.Visible = false;
                                    ////txtdispname.Text = "";
                                    //toolStripButton7.Visible = false;
                                    //toolStripButton6.Visible = false;
                                    //toolStripButton5.Visible = false;
                                    //toolStripButton4.Visible = false;
                                    //toolStripButton11.Visible = false;

                                }
                            case (DialogResult.No):
                                {

                                    //gbshowheaderdata.Visible = false;
                                    //btnaddtext.Visible = false;
                                    //btnaddbarcode.Visible = false;
                                    //btnAddImage.Visible = false;
                                    //btntestprint.Visible = false;
                                    //gbtemplatepreview.Visible = false;
                                    //gvfieldview.Visible = false;
                                    //toolStripButton7.Visible = false;
                                    //toolStripButton6.Visible = false;
                                    //toolStripButton5.Visible = false;
                                    //toolStripButton4.Visible = false;
                                    //toolStripButton11.Visible = false;

                                    //tempstatus.TemplatePath = Convert.ToString(tempstatus.TemplatePath);
                                    //tempstatus.TemplateSave = "0";
                                    //tempstatus.TemplateMode = "Edit";
                                    //tempstatus.TemplateStatus = "0";
                                    //tempstatus.TempTemplatePath = "";
                                    //lobjTemplatexml.SaveTemplateStatus(tempstatus);
                                    return false;
                                }
                        }
                    }
                    else
                    {
                        var dilogdialogue = MessageBox.Show("The 'Current Template' is not saved, and you must save it.", "Save Template", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        switch (dilogdialogue)
                        {
                            case (DialogResult.OK):
                                {

                                    return lobjTemplatexml.SaveNewTemplate();                                

                                }
                            case (DialogResult.Cancel):
                                {                                   
                                    return false;
                                }
                        }

                    }
                    return false;
                }
                else if (tempstatus.TemplateMode.ToLower() == "Edit".ToLower() && tempstatus.TemplateSave == "1")
                {
                   
                    if (saveAs !="SaveAs")
                    {
                        var dilogdialogue = MessageBox.Show("You have 'Unrecorded' Changes. Do you want to save them?", "Save Template", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        switch (dilogdialogue)
                        {
                            case (DialogResult.Yes):
                                {
                                    Globalvariables.PrintTemplateStatus = "1";

                                    lobjTemplatexml.UpdateTemplate();
                                    return true;
                                }
                            case (DialogResult.No):
                                {
                                    //gbshowheaderdata.Visible = false;
                                    //btnaddtext.Visible = false;
                                    //btnaddbarcode.Visible = false;
                                    //btnAddImage.Visible = false;
                                    //btntestprint.Visible = false;
                                    //gbtemplatepreview.Visible = false;
                                    //gvfieldview.Visible = false;
                                    //toolStripButton7.Visible = false;
                                    //toolStripButton6.Visible = false;
                                    //toolStripButton5.Visible = false;
                                    //toolStripButton4.Visible = false;
                                    //toolStripButton11.Visible = false;
                                    //tempstatus = lobjTemplatexml.GetTemplateStatus();
                                    //if (!string.IsNullOrWhiteSpace(tempstatus.TempTemplatePath))
                                    //{
                                    //    lobjTemplatexml.DeleteAppTemplate(Path.GetFileNameWithoutExtension(tempstatus.TempTemplatePath));

                                    //}
                                    //tempstatus.TemplatePath = Convert.ToString(tempstatus.TemplatePath);
                                    //tempstatus.TemplateSave = "0";
                                    //tempstatus.TemplateMode = "Edit";
                                    //tempstatus.TemplateStatus = "0";
                                    //tempstatus.TempTemplatePath = "";
                                    //lobjTemplatexml.SaveTemplateStatus(tempstatus);
                                    return false;
                                }

                        }
                    }
                    else
                    {
                       var  dilogdialogue = MessageBox.Show("You have 'Unrecorded' Changes, and must save it.", "Save Template", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        switch (dilogdialogue)
                        {
                            case (DialogResult.OK):
                                {


                                    lobjTemplatexml.UpdateTemplate();
                                    return true;
                                }
                            case (DialogResult.Cancel):
                                {                                   
                                    return false;
                                }
                        }
                    }
                    
                   

                }
                return true;
            }
            else
            {
                tempstatus.TemplatePath = "";
                tempstatus.TemplateSave = "0";
                tempstatus.TemplateMode = "";
                tempstatus.TemplateStatus = "0";
                tempstatus.TempTemplatePath = "";
                lobjTemplatexml.SaveTemplateStatus(tempstatus);
                return true;
            }
           

        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {

        }

      
        private void cntxtCopy_Click(object sender, EventArgs e)
        {
            if (Activefield != "")
            {
                int rowIndex = -1;
                foreach (DataGridViewRow row in gvfieldview.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(Activefield))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                gvfieldview.CurrentCell = gvfieldview.Rows[rowIndex].Cells[8];
                var arg = new DataGridViewCellEventArgs(8, rowIndex);
                gvfieldview_CellContentClick(gvfieldview, arg);
            }
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            this.btnAddLine.Select();
            btnTextType = false;
            btnBarcodeType = false;
            btnImageType = false;
            btnLineType = true;

            lobjQBConfiguration = new QBConfiguration();
            if ((lobjQBConfiguration.GetLabelConfigSettings("isShowDesignPopup").ToString().ToLower() == "false"))
            {
                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();

                if (System.Windows.Forms.Application.OpenForms["FrmConfirmPopup"] == null)
                {

                    LabelConnector.FrmConfirmPopup lobjLabelConnectorSettings = new LabelConnector.FrmConfirmPopup();
                    lobjLabelConnectorSettings.ShowInTaskbar = false;

                    lobjLabelConnectorSettings.ShowDialog();

                }
            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
