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
    public partial class ImportTemplate : Form
    {
        public delegate void PassHeaderControlImporttemplate(String lstrImportFileName);
        // Create instance (null)
        public PassHeaderControlImporttemplate passheadercontrolimporttemplate;
        string lstrgettargetfile = string.Empty;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public ImportTemplate()
        {
            InitializeComponent();
        }

        private void btnimporttemplate_Click(object sender, EventArgs e)
        {
            bool istemplateexist = false;
            if (passheadercontrolimporttemplate != null)
            {

                //string filepath = string.Empty;
                ////const string targetDir = @"C:\ONL";
                //string targetDir = System.Windows.Forms.Application.StartupPath + @"\" + "TemplateImageslist" + "\\" ;
                //OpenFileDialog openFileDialog1 = new OpenFileDialog();
                //openFileDialog1.Title = "Browse xml Files";
                //openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
                //openFileDialog1.FilterIndex = 0;
                //openFileDialog1.DefaultExt = "xml";

                //if (openFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    if (!String.Equals(Path.GetExtension(openFileDialog1.FileName), ".xml", StringComparison.OrdinalIgnoreCase))
                //    {
                //        // Invalid file type selected; display an error.
                //        MessageBox.Show("The type of the selected file is not supported by this application. You must select an XML file.",
                //                        "Invalid File Type",
                //                        MessageBoxButtons.OK,
                //                        MessageBoxIcon.Error);

                //        // Optionally, force the user to select another file.
                //        // ...
                //    }
                //    else
                //    {
                //        File.Copy(openFileDialog1.FileName, Path.Combine(targetDir, Path.GetFileName(openFileDialog1.FileName)), true);
                //    }
                //    lstrgettargetfile = System.Windows.Forms.Application.StartupPath + @"\" + "TemplateImageslist" + "\\" + openFileDialog1.FileName.ToString() + ".xml";
                //        passheadercontrolimporttemplate(lstrgettargetfile);
                //        {
                //            this.Close();
                //        }




                //}

                // lstrgettargetfile = System.Windows.Forms.Application.StartupPath + @"\" + "TemplateImageslist" + "\\" + openFileDialog1.FileName.ToString() + ".xml";
                clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
                var templatenodecount = lobjtemplatenames.CheckImportXmlFormat(Path.GetFileNameWithoutExtension(openFileDialog1.FileName.ToString()));
                //istemplateexist = lobjtemplatenames.IsTemplateFieldInXml(Path.GetFileNameWithoutExtension(openFileDialog1.FileName.ToString()));
                //if(!istemplateexist) //template name attr not exist
                //{
                //    MessageBox.Show("Invalid Template Format", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                if (templatenodecount.Count < 18)
                {
                    MessageBox.Show("Invalid Template Format", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                passheadercontrolimporttemplate(Path.GetFileNameWithoutExtension(openFileDialog1.FileName.ToString()));
                {
                   
                    
                    this.Close();
                }

            }

        }

        private void btnimportClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbrowsexml_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            //const string targetDir = @"C:\ONL";
            string defaultpath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Label Connector Templates";
            string targetDir = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TemplateImageslist" + "\\");
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse xml Files";
            if (!Directory.Exists(defaultpath))
            {
                Directory.CreateDirectory(defaultpath);

            }
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);

            }
            openFileDialog1.InitialDirectory = defaultpath;
            openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.DefaultExt = "xml";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!String.Equals(Path.GetExtension(openFileDialog1.FileName), ".xml", StringComparison.OrdinalIgnoreCase))
                {
                    // Invalid file type selected; display an error.
                    MessageBox.Show("The type of the selected file is not supported by this application. You must select an XML file.",
                                    "Invalid File Type",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    // Optionally, force the user to select another file.
                    // ...
                }
                else
                {
                    File.Copy(openFileDialog1.FileName, Path.Combine(targetDir, Path.GetFileName(openFileDialog1.FileName)), true);
                    btnimporttemplate.Enabled = true;
                    lblfilepath.Text = Path.GetFileName(openFileDialog1.FileName.ToString());

                    lblfilepath.MaximumSize = new Size(200, 0);
                    lblfilepath.AutoSize = true;


                }
            }
            }

        private void ImportTemplate_Load(object sender, EventArgs e)
        {
            lblfilepath.Text = "";
        }

        private void btnopen_Click(object sender, EventArgs e)
        {            
            bool istemplateexist = false;
            clsTemplateStatus tempstatus = new clsTemplateStatus();
            clsTemplateLabelXmlwork lobjtemplatenames = new clsTemplateLabelXmlwork();
            if (passheadercontrolimporttemplate != null)
            {
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
                passheadercontrolimporttemplate((Path.GetFileNameWithoutExtension(tempstatus.TempTemplatePath)));
                {


                    this.Close();
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Browse xml Files";
            lblfilepath.Text = "";
            btnopen.Enabled = false;
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "TempPath" + "\\" + "TempLastPath" + ".xml");
            if (File.Exists(strStartupPath))            {
                clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
                var tempStatus = lobjTemplatexml.GetTemplateStatus();
                if (tempStatus.TemplatePath != "")
                {
                    openFileDialog1.InitialDirectory = tempStatus.TemplatePath.Replace(tempStatus.TemplatePath, Path.GetDirectoryName(tempStatus.TemplatePath));
                    openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
                    openFileDialog1.FilterIndex = 0;
                    openFileDialog1.DefaultExt = "xml";

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        UpdateFilePath(openFileDialog1.FileName.ToString());
                    }
                }
                else
                {
                    openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
                    openFileDialog1.FilterIndex = 0;
                    openFileDialog1.DefaultExt = "xml";

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        UpdateFilePath(openFileDialog1.FileName.ToString());
                    }
                }
            }

            else
            {
                openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.DefaultExt = "xml";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    UpdateFilePath( openFileDialog1.FileName.ToString());
                }

            }
        }
        public void UpdateFilePath(string filepath)
        {
            clsTemplateLabelXmlwork lobjTemplatexml = new clsTemplateLabelXmlwork();
            clsTemplateStatus tempstatus = new clsTemplateStatus();
            tempstatus.TemplatePath = Convert.ToString(filepath);
            tempstatus.TemplateSave = "1";
            tempstatus.TemplateMode = "Edit";
            tempstatus.TemplateStatus = "1";
            tempstatus.TempTemplatePath = "";
            lobjTemplatexml.SaveTemplateStatus(tempstatus);
            btnopen.Enabled = true;
            lblfilepath.Text = Path.GetFileName(filepath);

            lblfilepath.MaximumSize = new Size(200, 0);
            lblfilepath.AutoSize = true;
        }
    }
}
