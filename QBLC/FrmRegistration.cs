using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LabelConnector
{

    public partial class FrmRegistration : Form
    {

        QBConfiguration lobjQBConfiguration = new QBConfiguration();
        clsLogin loginclass = new clsLogin();
        Panel timerpanel = new Panel();
        int screenload = 0;
        int setwidth = 0;
        public FrmRegistration()
        {
            InitializeComponent();
        }
        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            pnlSignIn.Visible = true;
            pnlSendEmail.Visible = false;
            pnlOtpcode.Visible = false;
            pnlResetPassword.Visible = false;
           
            if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("EmailLoginId").ToString()))
            {
                txtsUsername.Text = lobjQBConfiguration.GetLabelConfigSettings("EmailLoginId").ToString();
                if (lobjQBConfiguration.GetLabelConfigSettings("RememberPassword").ToString() == "1")
                {
                    chkRememberMe.Checked = true;
                    txtspassword.Text = lobjQBConfiguration.GetLabelConfigSettings("ShownPassword").ToString();
                    txtspassword.Focus();
                }
                else
                {
                    txtspassword.Text = "";
                    chkRememberMe.Checked = false;
                    txtspassword.Focus();
                }
                    
            }
            else
            {
                txtsUsername.Text = "";
                txtspassword.Text = "";
                chkRememberMe.Checked = false;
                txtsUsername.Focus();
            }
        }
        private void btnsclose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            WebReference.LicenseService licenseService = new WebReference.LicenseService();
            string CurrentVersion = "390";
            btnSignIn.Text = "Loading..";
            this.Cursor = Cursors.WaitCursor;
            if (txtsUsername.Text == "")
            {
                lblSUserName.Text = "Enter the User Name";
                txtsUsername.Focus();
                btnSignIn.Text = "Sign In ->";
                this.Cursor = Cursors.Default;
                return;
            }

            if (txtspassword.Text == "")
            {
                lblspasswordmsg.Text = "Enter the password";
                lblspasswordmsg.Location = new System.Drawing.Point(57, 173);
                chkRememberMe.Location = new System.Drawing.Point(54, 189);
                linkforgetpassword.Location = new System.Drawing.Point(180, 189);
                txtspassword.Focus();
                btnSignIn.Text = "Sign In ->";
                this.Cursor = Cursors.Default;
                return;
            }

            try
            {
                
                    licenseService = new WebReference.LicenseService();
                Globalvariables.EncryptLoginMailID = Globalvariables.EncrytPassword.EncryptString(txtsUsername.Text.ToString().Trim().ToLower());
                Globalvariables.EncryptLoginPassword = Globalvariables.EncrytPassword.EncryptString(txtspassword.Text.ToString());
                var LoginDetails = licenseService.GetCustomersDetails(Globalvariables.EncryptLoginMailID.Trim(), Globalvariables.EncryptLoginPassword.Trim(), "QBLC2021",1);
                Globalvariables.LoginMailID = txtsUsername.Text.ToString().Trim();
                Globalvariables.LoginPassword = txtspassword.Text.ToString();
                if (LoginDetails == "Email")
                {
                    MessageBox.Show("Please check your Mail Id.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSignIn.Text = "Sign In ->";
                    this.Cursor = Cursors.Default;
                    return;
                }
                
                var upgradeLoginDetails = licenseService.GetCustomersUpgradeDetails(Globalvariables.EncryptLoginMailID, "QBLC2021");
                Globalvariables.DownloadLink = upgradeLoginDetails.DownloadLink;
                Globalvariables.ReleaseNotes = upgradeLoginDetails.Reference;
                if (upgradeLoginDetails.UpgradeVersion == "1")
                {
                    if (Convert.ToInt32(CurrentVersion) <= Convert.ToInt32(upgradeLoginDetails.CurrentVersion))
                    {
                        
                        if (System.Windows.Forms.Application.OpenForms["FrmUpgradePopup"] == null)
                        {
                            FrmUpgradePopup Upgradepopup = new FrmUpgradePopup();
                            Upgradepopup.ShowDialog();
                        }
                        Environment.Exit(0);
                    }
                    else if(Convert.ToInt32(CurrentVersion) > Convert.ToInt32(upgradeLoginDetails.CurrentVersion)  )
                    {
                        licenseService.UpdateCustomersVersionUpgrade(Globalvariables.EncryptLoginMailID, "", "QBLC2021", 2);
                    }
                }
                else if(upgradeLoginDetails.UpgradeVersion == "2")
                {
                    if ( Convert.ToInt32(CurrentVersion) <= Convert.ToInt32(upgradeLoginDetails.CurrentVersion))
                    {
                       
                        //if ((lobjQBConfiguration.GetLabelConfigSettings("isShowReleaseNotePopup").ToString().ToLower() == "false"))
                        //{
                        if (System.Windows.Forms.Application.OpenForms["FrmReleaseNotes"] == null)
                        {
                            FrmReleaseNotes lobjLabelConnectorSettings = new FrmReleaseNotes();
                            lobjLabelConnectorSettings.ShowDialog();
                            btnSignIn.Text = "Loading..";
                            
                        }

                        //}

                    }
                    else if (Convert.ToInt32(CurrentVersion) > Convert.ToInt32(upgradeLoginDetails.CurrentVersion) )
                    {
                        licenseService.UpdateCustomersVersionUpgrade(Globalvariables.EncryptLoginMailID, "", "QBLC2021", 2);
                    }
                }

                 if (LoginDetails == "Password")
                {
                    MessageBox.Show("Please check your Password", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSignIn.Text = "Sign In ->";
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (LoginDetails == "DateExpired")
                {
                    MessageBox.Show("Your trial version was expired.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSignIn.Text = "Sign In ->";
                    this.Cursor = Cursors.Default;
                    return;
                }

                //if (LoginDetails == "Session")
                //{
                    //dialog = MessageBox.Show("You have already connected to another session, would you like to close and continue the connection?", "Label Connector", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //if (dialog == DialogResult.Yes)
                    //{
                    //    licenseService.UpdateLogOutDetails(Globalvariables.EncryptLoginMailID, "QBLC2021");

                    //    var LoginDetails1 = licenseService.GetCustomersDetails(Globalvariables.EncryptLoginMailID.Trim(), Globalvariables.EncryptLoginPassword.Trim(), "QBLC2021", 1);
                    //    if (LoginDetails1 == "DateExpired")
                    //    {
                    //        MessageBox.Show("Your trial version was expired.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        btnSignIn.Text = "Sign In ->";
                    //        return;
                    //    }

                    //    else if (LoginDetails1 == "Success")
                    //    {
                    //        Globalvariables.SessionReference = licenseService.GenerateOTPcode();
                    //        licenseService.UpdateSessionReferenceDetail(Globalvariables.EncryptLoginMailID, Globalvariables.SessionReference, "QBLC2021");
                    //        licenseService.UpdateCustomersVersionUpgrade(Globalvariables.EncryptLoginMailID, CurrentVersion, "QBLC2021",1);
                    //lobjQBConfiguration.SaveLabelFilePathSettings(txtsUsername.Text.ToString().Trim(), "EmailLoginId");
                    //        lobjQBConfiguration.SaveLabelFilePathSettings(txtspassword.Text.ToString().Trim(), "ShownPassword");
                    //        screenload = 1;
                    //        this.Close();
                    //    }
                    //    else if (LoginDetails == "Error")
                    //    {
                    //        MessageBox.Show("Please again login your credentials.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        btnSignIn.Text = "Sign In ->";
                    //        return;
                    //    }

                    //}
                    //else
                    //{
                    //    btnSignIn.Text = "Sign In ->";
                    //    return;
                    //}

                //}
                

                 if (LoginDetails == "Success" || LoginDetails == "Session")
                {
                    Globalvariables.SessionReference = licenseService.GenerateOTPcode();
                    licenseService.UpdateSessionReferenceDetail(Globalvariables.EncryptLoginMailID, Globalvariables.SessionReference, "QBLC2021");
                    licenseService.UpdateCustomersVersionUpgrade(Globalvariables.EncryptLoginMailID, CurrentVersion, "QBLC2021",1); 
                    lobjQBConfiguration.SaveLabelFilePathSettings(txtsUsername.Text.ToString().Trim(), "EmailLoginId");
                    lobjQBConfiguration.SaveLabelFilePathSettings(txtspassword.Text.ToString(), "ShownPassword");
                    screenload = 1;
                    this.Close();
                }
                 if (LoginDetails == "Error")
                {
                    MessageBox.Show("Please again login your credentials.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSignIn.Text = "Sign In ->";
                    this.Cursor = Cursors.Default;
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The remote name could not be resolved: 'www.myproactivesoftware.com'")
                {
                    MessageBox.Show("Please check your Internet connection.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSignIn.Text = "Sign In ->";
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show(ex.Message, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSignIn.Text = "Sign In ->";
                    this.Cursor = Cursors.Default;
                }
            }


        }

        private void txtspassword_TextChanged(object sender, EventArgs e)
        {
            lblspasswordmsg.Text = "";
            chkRememberMe.Location = new System.Drawing.Point(55, 177);
            linkforgetpassword.Location = new System.Drawing.Point(180, 177);
            lblSUserName.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void linkforgetpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WebReference.LicenseService licenseService = new WebReference.LicenseService();
            if (txtsUsername.Text == "")
            {
                lblSUserName.Text = "Enter the User Name";
                txtsUsername.Focus();
                return;
            }

            try
            {
                Globalvariables.EncryptLoginMailID = Globalvariables.EncrytPassword.EncryptString(txtsUsername.Text.ToString().Trim());
                licenseService = new WebReference.LicenseService();
                var LoginDetails = licenseService.GetCustomersDetails(Globalvariables.EncryptLoginMailID.Trim(), "", "QBLC2021",2);
                if (LoginDetails == "Email")
                {
                    MessageBox.Show("Please, Check your Mail Id.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //else if (LoginDetails == "Session")
                //{
                //    MessageBox.Show("Sorry, Your MailId have already connected to another session.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                else if (LoginDetails == "DateExpired")
                {
                    MessageBox.Show("Your trial version was expired.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                else if (LoginDetails == "Success" || LoginDetails == "Session")
                {
                    pnlSignIn.Visible = true;
                    timerpanel = pnlSignIn;
                    setwidth = timerpanel.Width;
                    pnlSendEmail.SendToBack();
                    timer.Start();
                    pnlSendEmail.Visible = true;
                    lblSendOtpmsg.Text = "";
                    pnlOtpcode.Visible = false;
                    pnlResetPassword.Visible = false;
                    txtTUsername.Text = txtsUsername.Text;
                    txtTUsername.Enabled = false;

                }
                else if (LoginDetails == "Error")
                {
                    MessageBox.Show("Please try again.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The remote name could not be resolved: 'www.myproactivesoftware.com'")
                {
                    MessageBox.Show("Please check your Internet connection.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

          
        }

        private void btnEmailSend_Click(object sender, EventArgs e)
        {
            try
            {
                lblSendOtpmsg.Text = "";
                progressBar1.Value = 30;
                progressBar1.Update();
                var pubstr_Mailid = txtsUsername.Text.ToString().Trim();

                WebReference.LicenseService licenseServiceotp = new WebReference.LicenseService();
                var otpstatuscode = licenseServiceotp.getOtpfromMail(pubstr_Mailid,"QBLC2021");
                progressBar1.Value = 80;
                progressBar1.Update();
               
                 if (otpstatuscode == "Error")
                {
                    progressBar1.Value = 0;
                    progressBar1.Update();
                    lblSendOtpmsg.Text = "Sorry, try again to get the otp code.";
                    btnEmailSend.Text = "Try Again";

                }
                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings(otpstatuscode, "EmailOtpCode");
                    progressBar1.Update();
                    progressBar1.Value = 100;
                    progressBar1.Update();

                    pnlSignIn.Visible = false;
                    pnlSendEmail.Visible = true;
                    timerpanel = pnlSendEmail;
                    setwidth = timerpanel.Width;
                    pnlOtpcode.SendToBack();
                    timer.Start();
                    pnlOtpcode.Visible = true;
                    MaskTxtOtp.Focus();
                    MaskTxtOtp.Text = "";
                    pnlResetPassword.Visible = false;
                }
            }
            catch (Exception ex)
            {

                if (ex.Message == "The remote name could not be resolved: 'www.myproactivesoftware.com'")
                {
                    MessageBox.Show("Please check your Internet connection.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }

        private void btnotpclose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnOtpcode_Click(object sender, EventArgs e)
        {
            var OtpCode = MaskTxtOtp.Text;
            OtpCode = OtpCode.Replace("-", "");
            if (string.IsNullOrWhiteSpace(MaskTxtOtp.Text))
            {
                lblOtpmsg.Text = "Enter the otp code from your Gmail Id.";
                MaskTxtOtp.Focus();
                return;
            }
            if (OtpCode == lobjQBConfiguration.GetLabelConfigSettings("EmailOtpCode").ToString())
            {

                pnlSignIn.Visible = false;
                pnlSendEmail.Visible = false;
                pnlOtpcode.Visible = true;
                timerpanel = pnlOtpcode;
                setwidth = timerpanel.Width;
                pnlResetPassword.SendToBack();
                timer.Start();
                pnlResetPassword.Visible = true;
                txtFUserName.Text = txtsUsername.Text;
                txtFUserName.Enabled = false;
            }
            else
            {
                lblOtpmsg.Text = "Please enter correct otp code.";
            }
        }

        private void MaskTxtOtp_KeyUp(object sender, KeyEventArgs e)
        {
            lblOtpmsg.Text = "";
        }

        private void btnCloseResetPassword_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFPassword.Text))
            {
                lblNewPassmsg.Text = "Enter the password.";
                txtFPassword.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFConfirmPassword.Text))
            {
                lblNewconfirmpassmsg.Text = "Enter the confirm password.";
                txtFConfirmPassword.Focus();
                return;
            }
            if (txtFPassword.Text != "")
            {
                if (txtFPassword.Text.Length < 6)
                {
                    txtFPassword.Focus();
                    lblNewPassmsg.ForeColor = System.Drawing.Color.Red;
                    lblNewPassmsg.Text = "Your password was too short";
                    return;
                }
                var expectedPasswordPattern = new Regex(@"^(?=.*?[a-z] || ?=.*?[A-Z])(?=.*?[0-9]).{8,}$");
                var isValidPassword = expectedPasswordPattern.IsMatch(txtFPassword.Text);
                if (!isValidPassword)
                {
                    txtFPassword.Focus();
                    lblNewPassmsg.ForeColor = System.Drawing.Color.Red;
                    lblNewPassmsg.Text = "Atleast 1 character from [a-z] or [A-Z] and [0-9]";
                    return;
                }
               
            }



            if (txtFPassword.Text == txtFConfirmPassword.Text)
            {
                try
                {
                    var userId = Globalvariables.EncrytPassword.EncryptString(txtFUserName.Text);
                    var password = Globalvariables.EncrytPassword.EncryptString(txtFPassword.Text);
                    WebReference.LicenseService updatepassword = new WebReference.LicenseService();
                    if (updatepassword.UpdateCustomerDetails(userId, password, "QBLC2021") == "1")
                    {
                        txtspassword.Text = "";
                        pnlSendEmail.Visible = false;
                        pnlOtpcode.Visible = false;
                        pnlResetPassword.Visible = true;
                        timerpanel = pnlResetPassword;
                        setwidth = timerpanel.Width;
                        pnlSignIn.SendToBack();
                        timer.Start();
                        pnlSignIn.Visible = true;
                    }
                    else
                    {
                        lblNewconfirmpassmsg.Text = "Sorry your credentials was not updated";
                    }
                }
                catch (Exception Ex)
                {
                    if (Ex.Message == "The remote name could not be resolved: 'www.myproactivesoftware.com'")
                    {
                        MessageBox.Show("Please check your Internet connection.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Ex.Message, "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                lblNewconfirmpassmsg.Text = "Password and confirm password doesn't match.";
            }

        }

        private void txtFPassword_TextChanged(object sender, EventArgs e)
        {
            lblNewPassmsg.Text = "";
            lblNewconfirmpassmsg.Text = "";
        }

        private void txtFConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            lblNewPassmsg.Text = "";
            lblNewconfirmpassmsg.Text = "";
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            {
                try
                {
                    timerpanel.Width = timerpanel.Width - 20;
                    if (timerpanel.Width <= 0)
                    {
                        timer.Stop();
                        timerpanel.Visible = false;
                        timerpanel.Width = setwidth;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        private void btnEmailSendBack_Click(object sender, EventArgs e)
        {

            pnlSendEmail.Visible = true;
            timerpanel = pnlSendEmail;
            setwidth = timerpanel.Width;
            pnlSignIn.SendToBack();
            timer.Start();
            pnlSignIn.Visible = true;
            pnlOtpcode.Visible = false;
            pnlResetPassword.Visible = false;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://accuware-inc.com/quickbooks-barcode-2021/");

        }

        private void txtsUsername_TextChanged(object sender, EventArgs e)
        {
            lblSUserName.Text = "";
            lblspasswordmsg.Text = "";
        }

        private void txtFUserName_Enter(object sender, EventArgs e)
        {
          
        }

        private void txtFUserName_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtsUsername_Enter(object sender, EventArgs e)
        {
            //if (txtsUsername.Text == "From when you registered")
            //{
            //    txtsUsername.Text = "";
            //    txtsUsername.ForeColor = Color.Black;
            //}
        }

        private void txtsUsername_Leave(object sender, EventArgs e)
        {
            //if (txtsUsername.Text == "")
            //{
            //    txtsUsername.Text = "From when you registered";
            //    txtsUsername.ForeColor = Color.Black;
            //}
        }

        private void txtsUsername_Click(object sender, EventArgs e)
        {
            //if (txtsUsername.Text == "From when you registered")
            //{
            //    txtsUsername.Text = "";
            //    txtsUsername.ForeColor = Color.Black;
            //}
        }

        private void txtspassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(sender, e);
            }
        }


        private void checkStrength()
        {
            var password = txtFPassword.Text;
            var expectedPasswordPattern = new Regex(@"^(?=.*?[a-z] || ?=.*?[A-Z])(?=.*?[0-9]).{8,}$");
            var isValidPassword = expectedPasswordPattern.IsMatch(password);
            if (isValidPassword)
            {
                lblNewPassmsg.ForeColor = System.Drawing.Color.Green;
                lblNewPassmsg.Text = "Strong password";
            }
            else
            {
                lblNewPassmsg.ForeColor = System.Drawing.Color.Red;
                lblNewPassmsg.Text = "Please Enter the strong password";
            }
        }

        private void txtFPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtFPassword.Text != "")
            {
                if (txtFPassword.Text.Length < 8)
                {
                    lblNewPassmsg.ForeColor = System.Drawing.Color.Red;
                    lblNewPassmsg.Text = "Your password was too short";
                    return;
                }
                checkStrength();
            }

        }


        private void ShowPasswordTimer_Tick(object sender, EventArgs e)
        {
        
            txtSPasswordshow.Text = txtspassword.Text;
            txtFShowPassword.Text = txtFPassword.Text;
            txtFShowConfirmPassword.Text = txtFConfirmPassword.Text;
        }


        private void pnlResetPassword_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShowSPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtspassword.Hide();


        }

        private void btnShowSPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtspassword.Show();
        }

        private void btnFShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtFPassword.Show();
        }

        private void btnFShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtFPassword.Hide();
        }

        private void btnFConfirmpassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtFConfirmPassword.Show();
        }

        private void btnFConfirmpassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtFConfirmPassword.Hide();
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRememberMe.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("1", "RememberPassword");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "RememberPassword");
            }
        }

        private void FrmRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (screenload == 0)
            {
                Process.GetCurrentProcess().Kill();
                Environment.Exit(0);
            }
        }
    }
}
