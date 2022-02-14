using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LabelConnector;

namespace QBLC
{
    public partial class frmAbout : Form
    {
        clsTrialApplication lobjclsTrialApplication = new clsTrialApplication();
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            // lbltrialremaining.Visible = false;
            // lbltrialdays.Visible = false;
            label2.Visible = false;
           
            lblCopyright.Text = "©" + " " + DateTime.Now.Year.ToString() + " " + "Accuware Incorporated";

            //show status as activated once authenticate is done : 27-Apr-2018 : CO108
            if (lobjQBConfiguration.GetLabelConfigSettings("License").ToUpper().Trim() == "LICENSE_OK")
            {
                lbltrialdays.Text = "Activated";
            }
            else
            {
               // lbltrialdays.Text = "Not Activated";
            }
           
            //lbltrialdays.Text = frmPrintLabel.GetRemainingDays; //shows trial days remaining

            //lblActivationStatus.Text = frmPrintLabel.ActivationStatus;
            //if (frmPrintLabel.ActivationStatus == "Active")
            //{
            //    lbltrialremaining.Visible = false;
            //    lbltrialdays.Visible = false;
            //}
            //else
            //{
            //    lbltrialremaining.Visible = true;
            //    lbltrialdays.Visible = true;
            //}
        }
    }
}