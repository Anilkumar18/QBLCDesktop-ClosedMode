using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace LabelConnector
{
    public delegate void showPrinterName();
    public partial class FrmPrinterSetting : Form
    {
        public showPrinterName objprintername;
        private static FrmPrinterSetting objfrmLabelConfig;
        public static FrmPrinterSetting GetInstance()
        {
            if (objfrmLabelConfig == null)
            {
                objfrmLabelConfig = new FrmPrinterSetting();
            }
            return objfrmLabelConfig;
        }
        public FrmPrinterSetting()
        {
            InitializeComponent();
        }
        QBConfiguration lobjQBConfiguration;

        private void FrmPrinterSetting_Load(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
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



            //GetPrinters();
            //if (radioButton2.Checked == true)
            //{
            //    lblprintername.Visible = true;
            //    cmbLabelPrinter.Visible = true;
               
            //}
            //else
            //{

            //    lblprintername.Visible = false;
            //    cmbLabelPrinter.Visible = false;
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (radioButton1.Checked == true) //screen printer
                {
                   
                    lobjQBConfiguration = new QBConfiguration();

                    lobjQBConfiguration.SaveLabelFilePathSettings("Screen", "CurrentPrinter");
                    DialogResult dlResult = MessageBox.Show("Printer saved successfully.", "Label Connector", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dlResult == DialogResult.OK)
                    {
                        objprintername();
                        this.Close();
                    }

                }
                else
                {
                    
                    if (cmbLabelPrinter.Text != "Select Printer") //common printer
                    {
                        lobjQBConfiguration = new QBConfiguration();

                        lobjQBConfiguration.SaveLabelFilePathSettings(cmbLabelPrinter.Text.ToString(), "CurrentPrinter");
                        DialogResult dlResult = MessageBox.Show("Printer saved successfully.", "Label Connector", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dlResult == DialogResult.OK)
                        {
                            objprintername();
                            this.Close();
                        }


                    }
                    else
                    {
                        MessageBox.Show("Please select printer name.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            
            }

        }
        private void GetPrinters()
        {
            lobjQBConfiguration = new QBConfiguration();
            if (cmbLabelPrinter.Items.Count == 0)
            {
                cmbLabelPrinter.Items.Add("Select Printer");
                foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                {
                    cmbLabelPrinter.Items.Add(strPrinter);
                }
            }

            //PrintDocument lobjDocument = new PrintDocument();

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
