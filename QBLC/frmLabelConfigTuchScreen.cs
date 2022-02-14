using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LabelConnector
{
    public delegate void delLabel();
    public partial class frmLabelConfigTuchScreen : Form
    {
        QBConfiguration lobjQBConfiguration;
        public frmLabelConfigTuchScreen()
        {
            InitializeComponent();
        }

        public delLabel objdelLabel;

        private static frmLabelConfigTuchScreen objfrmLabelConfig;
        public static frmLabelConfigTuchScreen GetInstance()
        {

            if (objfrmLabelConfig == null)
            {
                objfrmLabelConfig = new frmLabelConfigTuchScreen();
            }
            return objfrmLabelConfig;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            lobjQBConfiguration.SaveLabelFilePathSettings(txtLabelFolder.Text.Trim(), "LabelPath");
            objdelLabel();
            //weather label option commented date:01/13/2015
           // lobjQBConfiguration.SaveLabelFilePathSettings(txtboxWeatherlabelPath.Text.Trim(), "WeatherLabelPath");

            MessageBox.Show("LabelPath is saved.", "Label Connector");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);

            if (folderBrowserDialog1.SelectedPath != "") txtLabelFolder.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLabelConfig_Load(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            txtLabelFolder.Text = lobjQBConfiguration.GetLabelConfigSettings("LabelPath");
            //weather label option commented date:01/13/2015
           // txtboxWeatherlabelPath.Text = lobjQBConfiguration.GetLabelConfigSettings("WeatherLabelPath");
            txtboxWeatherlabelPath.Visible = false;
            label2.Visible = false;
            btnWeatherLabelPath.Visible = false;
        }

        private void btnWeatherLabelPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);

            if (openFileDialog1.FileName != "") txtboxWeatherlabelPath.Text = openFileDialog1.FileName;
        }
    }
}