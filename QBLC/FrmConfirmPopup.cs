using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabelConnector
{
    public partial class FrmConfirmPopup : Form
    {
        QBConfiguration lobjQBConfiguration;
        public FrmConfirmPopup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            if (this.checkBox1.Checked == true)
            {
                lobjQBConfiguration.SaveCustomFields("true", "isShowDesignPopup");
            }
            this.Close();

        }

        private void FrmConfirmPopup_Load(object sender, EventArgs e)
        {
            //lobjQBConfiguration = new QBConfiguration();
            //if ((lobjQBConfiguration.GetLabelConfigSettings("isShowDesignPopup").ToString().ToLower() == "true"))
            //{
            //   

            //}
        }

        private void FrmConfirmPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            if (this.checkBox1.Checked == true)
            {
                lobjQBConfiguration.SaveCustomFields("true", "isShowDesignPopup");
            }
           
        }
    }
}
