using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LabelConnector
{
    public partial class FrmTemplateOperation : Form
    {
        string slectedPath = string.Empty;
        public delegate void PassHeaderControlOpentemplate(String pstrTemplate);
        // Create instance (null)
        public PassHeaderControlOpentemplate passheadercontrolopentemplate;

        public delegate void PassHeadersaveasControl(String pstrTemplate);
        // Create instance (null)
        public PassHeadersaveasControl passheadersaveascontrol;
        public FrmTemplateOperation()
        {

            InitializeComponent();
            //if (headertype != null)
            //{
            //    this.Text = "SaveAs";
            //}
            //else
            //{
            //    this.Text = "Open";
            //}
        }
        public void funsaveasData(String lstrPopupType, String lstrTemplateName)
        {
            headertype = lstrPopupType;
            this.SetTemplateName = lstrTemplateName;
        }
        public string headertype { get; set; }
        string cmbselectedvalue = string.Empty;

        string SetTemplateName = string.Empty;
        private void btnsavetemplateop_Click(object sender, EventArgs e)
        {
            clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
            if (headertype != null)
            {
                if (headertype.ToLower().Trim() == "&saveas")
                {
                    //save as file
                    string pdfoldfilepath = string.Empty;
                    string pdfnewfilepath = string.Empty;
                    string xmloldfilepath = string.Empty;
                    string xmlnewfilepath = string.Empty;
                    string saveasimgoldpath = string.Empty;
                    string saveasimgnewpath = string.Empty;

                    pdfoldfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat" + "\\" + cmbtemplate.Text.ToString() + ".pdf");
                    pdfnewfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat" + "\\" + txttemplate.Text.ToString().Trim() + ".pdf");

                    xmloldfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\" + cmbtemplate.Text.ToString() + ".xml");
                    xmlnewfilepath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\" + txttemplate.Text.ToString().Trim() + ".xml");

                    DirectoryInfo di = new DirectoryInfo(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfImagesList"));

                    // Create the directory only if it does not already exist.
                    if (di.Exists == false)
                        di.Create();

                    // Create a subdirectory in the directory just created.
                    DirectoryInfo dis = di.CreateSubdirectory(txttemplate.Text.ToString().Trim());

                    saveasimgoldpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfImagesList" + "\\" + cmbtemplate.Text.ToString() + "\\" + cmbtemplate.Text.ToString() + ".Tiff");
                    saveasimgnewpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "PdfImagesList" + "\\" + txttemplate.Text.ToString().Trim() + "\\" + txttemplate.Text.ToString().Trim() + ".Tiff");




                    if (!string.IsNullOrWhiteSpace(pdfnewfilepath))
                    {
                        if (File.Exists(pdfnewfilepath))
                        {
                            File.Delete(pdfnewfilepath);
                        }

                        System.IO.File.Copy(pdfoldfilepath, pdfnewfilepath);
                        if (!File.Exists(xmlnewfilepath))
                        {

                            System.IO.File.Copy(xmloldfilepath, xmlnewfilepath); //save as pdf
                            System.IO.File.Copy(saveasimgoldpath, saveasimgnewpath); //save as image
                                                                                     //update attr to template
                            lobjtemplatenames.UpdateTemplateAttribute(txttemplate.Text.ToString().Trim());
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
                        }
                        // MessageBox.Show("Save as template sucessfully", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    }
                    if (passheadersaveascontrol != null)
                    {
                        passheadersaveascontrol(txttemplate.Text.ToString().Trim());
                        {
                            this.Close();
                        }
                    }

                }
            }
            else if (headertype == null) //show open form
            {
                if (passheadercontrolopentemplate != null)
                {
                    passheadercontrolopentemplate(cmbtemplate.Text.ToString());
                    {
                        this.Close();
                    }
                }
            }
        }

        private void FrmTemplateOperation_Load(object sender, EventArgs e)
        {
            if (headertype != null)
            {
                if (headertype.ToLower().Trim() == "&saveas")// save as mode
                {
                    clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                    string saveimgpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "SaveAs.png");

                    cmbtemplate.DataSource = lobjtemplatenames.GetTemplateNameList();
                    cmbtemplate.DisplayMember = "ItemFieldName";
                    cmbtemplate.ValueMember = "ItemFieldId";
                    lbltemplateheadertext.Text = "SaveAs Template";
                    cmbtemplate.Text = this.SetTemplateName;
                    txtTewmpName.Visible = true;
                    txtTewmpName.Enabled = false;
                    if (this.SetTemplateName.ToLower() == "TempTemplate".ToLower())
                    {
                        txtTewmpName.Text = "UnSaved";
                    }
                    else
                    {
                        txtTewmpName.Text = this.SetTemplateName;
                    }
                    cmbtemplate.Enabled = false;
                    this.btnsavetemplateop.Image = Image.FromFile(saveimgpath);
                    btnsavetemplateop.ImageAlign = ContentAlignment.MiddleLeft;
                    //btnsavetemplateop.Text = "Save";


                }
            }
            else if (headertype == null) //open button mode
            {
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                string openimgpath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Images" + "\\" + "open.png");
                cmbtemplate.DataSource = lobjtemplatenames.GetTemplateNameList();
                cmbtemplate.DisplayMember = "ItemFieldName";
                cmbtemplate.ValueMember = "ItemFieldId";
                lbltemplateheadertext.Text = "Open Template";
                cmbtemplate.Enabled = true;
                lbltemplatename.Visible = false;
                txttemplate.Visible = false;               
                btnsavetemplateop.Image = Image.FromFile(openimgpath);
                btnsavetemplateop.ImageAlign = ContentAlignment.MiddleLeft;
                btnsavetemplateop.Text = "Open".PadLeft(13);

            }
        }

        public void ControlsValidate()
        {

            btnsavetemplateop.Enabled = !String.IsNullOrWhiteSpace(txttemplate.Text) && !String.IsNullOrWhiteSpace(lbltemp.Text) && cmbtemplate.SelectedValue.ToString() != "0";

        }

        private void txttemplate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txttemplate.Text))
            {
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
            }
            ControlsValidate();
        }

        private void cmbtemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (headertype == null)
            {

                cmbselectedvalue = cmbtemplate.Text.ToString();
                if (cmbselectedvalue.ToLower().Trim() != "---select template---")
                {
                    btnsavetemplateop.Enabled = true;
                }
                else
                {
                    btnsavetemplateop.Enabled = false;
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

            clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
            lbltemp.Text = "";
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            clsTemplateLabelXmlwork objtemp = new clsTemplateLabelXmlwork();
            clsTemplateStatus objTemp = new clsTemplateStatus();
            objTemp = objtemp.GetTemplateStatus();
            openFileDialog1.InitialDirectory = objTemp.TemplatePath.Replace(objTemp.TemplatePath, Path.GetDirectoryName(objTemp.TemplatePath)) + "\\";
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
                slectedPath = openFileDialog1.FileName.ToString();
                lbltemp.Text = Path.GetFileName(openFileDialog1.FileName);
                txttemplate.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                ControlsValidate();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
