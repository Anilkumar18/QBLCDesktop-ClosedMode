using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabelConnector
{
    public partial class LabelConnectorSettingsTuchScreen : Form
    {
        public LabelConnectorSettingsTuchScreen()
        {
            InitializeComponent();
        }
        string mstrExistingQBFile = string.Empty;
        QuickBooksAccount moQuickBooksAccountConfig = new QuickBooksAccount();
        private void btn_browse_Click(object sender, EventArgs e)
        {
            DialogResult loResult;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (mstrExistingQBFile != string.Empty && mstrExistingQBFile != openFileDialog1.FileName)
                {
                    loResult = MessageBox.Show("You are about to change QuickBooks company file, if you continue you need to reconfigure the preferences settings. Click Yes to continue changing company file. Click No to not change company file.",
                                     "Label Connector", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (loResult == DialogResult.Yes)
                        txt_filenm.Text = openFileDialog1.FileName;

                }
                else
                    txt_filenm.Text = openFileDialog1.FileName;
            }
        }
        private bool CheckMandetory()
        {
            if (txt_filenm.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please select QuickBooks Company (.QBW) file.", "Label Connector");
                txt_filenm.Focus();
                return false;
            }
            else if (cb_mode.SelectedIndex == -1)
            {
                MessageBox.Show("Please select file mode.", "Label Connector");
                cb_mode.Focus();
                return false;
            }
            else
                return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckMandetory())
            {
                if (SaveQBSettings())
                {
                    MessageBox.Show("QuickBooks account settings saved successfully!" + Environment.NewLine + "Exit Application and Exit QuickBooks and then restart the application to reflect the settings.","Label Connector");
                }
                else
                    MessageBox.Show("Error while saving QuickBooks account settings!");
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (CheckMandetory())
            {
                QBAuthentication lQBAuthentication = new QBAuthentication(txt_filenm.Text, cb_mode.Text);

                if (rbPersonalDataYes.Checked)
                {
                    lQBAuthentication.PersonalDataPref = QBAuthentication.PersonalDataPreference.Required;
                }
                else if (rbPersonalDataLater.Checked)
                {
                    lQBAuthentication.PersonalDataPref = QBAuthentication.PersonalDataPreference.Optional;
                }
                else
                {
                    lQBAuthentication.PersonalDataPref = QBAuthentication.PersonalDataPreference.NotNeeded;
                }

                if (rbRunModeYes.Checked)
                {
                    lQBAuthentication.UnAttendedModePref = QBAuthentication.UnAttendedModePreference.Required;
                }
                else
                {
                    lQBAuthentication.UnAttendedModePref = QBAuthentication.UnAttendedModePreference.Optional;
                }

                if (lQBAuthentication.AuthenticateQBUser())
                {
                    btnSave.Enabled = true;
                }
            }
        }
        
        private bool SaveQBSettings()
        {
            Serializer loSerializer;

            if (txt_filenm.Text == "" || Convert.ToString(cb_mode.SelectedValue) == "")
            {
                MessageBox.Show("QuickBooks: please enter values for mandatory fields");
                return false;
            }
            else
            {
                moQuickBooksAccountConfig = new QuickBooksAccount();
                moQuickBooksAccountConfig.UserName= string.Empty;
                moQuickBooksAccountConfig.Password = string.Empty;
                moQuickBooksAccountConfig.CompanyFile = txt_filenm.Text;
                moQuickBooksAccountConfig.FileOpenMode = Convert.ToString(cb_mode.SelectedValue);
                moQuickBooksAccountConfig.QBVersion = Convert.ToString(cbVersion.SelectedItem);
                moQuickBooksAccountConfig.ConnectionType = Convert.ToString(cmbConnectionType.SelectedValue);

                if (rbPersonalDataYes.Checked)
                {
                    moQuickBooksAccountConfig.PersonalDataPref = "Required";
                }
                else if (rbPersonalDataLater.Checked)
                {
                    moQuickBooksAccountConfig.PersonalDataPref = "Optional";
                }
                else
                {
                    moQuickBooksAccountConfig.PersonalDataPref = "NotNeeded";
                }

                if (rbRunModeYes.Checked)
                {
                    moQuickBooksAccountConfig.UnattendedModePref = "Required";
                }
                else
                {
                    moQuickBooksAccountConfig.UnattendedModePref = "Optional";
                }
                
                moQuickBooksAccountConfig.QBCountry = "US";
                moQuickBooksAccountConfig.QBMajorVersion = "8";
                moQuickBooksAccountConfig.QBMinorVersion = "0";


                loSerializer = new Serializer();

                if (loSerializer.SaveQuickBooksAccountConfig(moQuickBooksAccountConfig, loSerializer.GetQuickBooksAccountConfigFile()))
                {
                    return true;
                }
                else
                    return false;
            }
        }

        
        private void LabelConnectorSettings_Load(object sender, EventArgs e)
        {
            BindFileMode();
            BindConnectionType();
            GetConfigData();
            cbVersion.SelectedIndex = 0;
        }

        private void GetConfigData()
        {
            
            Serializer loSerializer = new Serializer();
            string lstrFileName = loSerializer.GetQuickBooksAccountConfigFile();
            moQuickBooksAccountConfig = loSerializer.ReadQuickBooksAccountConfig(lstrFileName);
            if (moQuickBooksAccountConfig != null)
            {
                txt_filenm.Text = moQuickBooksAccountConfig.CompanyFile;
                cbVersion.SelectedText = moQuickBooksAccountConfig.QBVersion;
                cb_mode.SelectedValue = moQuickBooksAccountConfig.FileOpenMode;
                cmbConnectionType.SelectedValue = moQuickBooksAccountConfig.ConnectionType;
                if (moQuickBooksAccountConfig.PersonalDataPref == "Required")
                {
                    rbPersonalDataYes.Checked = true;
                }
                else if (moQuickBooksAccountConfig.PersonalDataPref == "Optional")
                {
                    rbPersonalDataLater.Checked = true;
                }
                else
                {
                    rbPersonalDataNo.Checked = true;
                }

                if (moQuickBooksAccountConfig.UnattendedModePref == "Required")
                {
                    rbRunModeYes.Checked = true;
                }
                else
                {
                    rbRunModeLater.Checked = true;
                }
            }
        }

        public void BindFileMode()
        {
            BindingList<CBItem> items = new BindingList<CBItem>();
            items.Add(new CBItem("Single User", @"omSingleUser"));
            items.Add(new CBItem("Multi User", @"omMultiUser"));
            items.Add(new CBItem("Dont Care", @"omDontCare"));

            cb_mode.DisplayMember = "DisplayValue";
            cb_mode.ValueMember = "RealValue";
            cb_mode.DataSource = items;

        }

        public void BindConnectionType()
        {
            BindingList<CBItem> items = new BindingList<CBItem>();
            items.Add(new CBItem("Local File", @"ctLocalQBD"));
            items.Add(new CBItem("Local File Launch UI", @"ctLocalQBDLaunchUI"));
            items.Add(new CBItem("Remote File", @"ctRemoteQBD"));
            items.Add(new CBItem("Remote QBOE File", @"ctRemoteQBOE"));
            items.Add(new CBItem("Unknown", @"ctUnknown"));

            cmbConnectionType.DisplayMember = "DisplayValue";
            cmbConnectionType.ValueMember = "RealValue";
            cmbConnectionType.DataSource = items;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}