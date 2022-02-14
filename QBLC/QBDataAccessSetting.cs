using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabelConnector
{
    public partial class QBDataAccessSetting : Form
    {
        QBConfiguration lobjQBConfiguration;
        string lstrQBFileMode = string.Empty;
        public QBDataAccessSetting()
        {
            InitializeComponent();
        }

        
        // to save in confing file
        private void btnQBDataSaved_Click(object sender, EventArgs e)
        {
            try
            {
                lobjQBConfiguration = new QBConfiguration();
                if (rdoqbopen.Checked == true)
                {

                    lobjQBConfiguration.SaveQBDataAccessSettings("Open");

                }
                else if (rdoqbclose.Checked == true)
                {
                    lobjQBConfiguration.SaveQBDataAccessSettings("Close");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
               
        }

        private void btnQBDataCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QBDataAccessSetting_Load(object sender, EventArgs e)
        {
            try
            {
                lobjQBConfiguration = new QBConfiguration();
                lstrQBFileMode = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("FileMode");
                if (lstrQBFileMode == "Open")
                    rdoqbopen.Checked = true;
                else
                    rdoqbclose.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }

        }

        private void rdoqbopen_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}