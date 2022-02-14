using LabelConnector;
using System;
using System.Threading;
using System.Windows.Forms;


namespace QBLC
{
    class clsLicenseWatcher
    {
        private Thread thread;
        private int interval;
        bool flDoCheck = true;
        bool flStop = false;
        bool flTuchScreen = false;
        private object mainForm;
        private MessageBoxIcon icon = MessageBoxIcon.Error;
        private string infoString;
        private string titleString;
        public clsLicenseWatcher(object mainForm, bool flTuchScreen)
        {
            this.mainForm = mainForm;
            this.flTuchScreen = flTuchScreen;
            try
            {
                interval = clsLicenseChecker.getCheckInterval(); //sec
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseProgramm();
                MessageBox.Show("Failed license status determination.", "License status unknown", MessageBoxButtons.OK, icon);
                return;    
            }
            
            thread = new Thread(this.Watch);
            thread.Start();
        }

        public void Wait()
        {
            flDoCheck = false;
        }

        public void Proceed()
        {
            flDoCheck = true;
        }

        public void Stop()
        {
            flStop = true;
            thread.Interrupt();
        }
        
        private void Watch()
        {
            while (!flStop)
            {
                if (flDoCheck && !clsLicenseChecker.IsRun())
                {
                    if (!CheckLicense())
                    {
                        CloseProgramm();
                        MessageBox.Show(infoString, titleString, MessageBoxButtons.OK, icon);
                        return;
                    }
                }
                if (!flStop)
                    try
                    {
                        Thread.Sleep(interval * 1000);
                    }
                    catch (System.Threading.ThreadInterruptedException) { }
            }
        }

        private bool CheckLicense()
        {
            license_state licenseState = license_state.LICENSE_UNKNOW;
            try
            {
                licenseState = clsLicenseChecker.checkLicense(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            switch (licenseState)
            {
                case license_state.LICENSE_ERROR_MAIN:
                    
                    infoString = "The license was not confirmed. The application was closed automatically.";
                    titleString = "Error of lnsMain.dll";
                    return false;
                case license_state.LICENSE_ERROR:
                    infoString = "The license was not confirmed. The application was closed automatically.";
                    titleString = "Error of lns.dll";
                    return false;
                case license_state.LICENSE_EXPIRED:
                    infoString = "The license has expired. The application was closed automatically.";
                    titleString = "License expired!";
                    return false;
                case license_state.LICENSE_OK:
                    if (flTuchScreen)
                    {
                        frmPrintLabelTuchScreen form = (frmPrintLabelTuchScreen)mainForm;
                        form.SetTextLicenseMenuItem(false);
                    }
                    else
                    {
                        frmPrintLabel form = (frmPrintLabel)mainForm;
                        form.SetTextLicenseMenuItem(false);
                    }
                    return true;
                case license_state.LICENSE_TRIAL:
                    if (flTuchScreen)
                    {
                        frmPrintLabelTuchScreen form = (frmPrintLabelTuchScreen)mainForm;
                        form.SetTextLicenseMenuItem(true);
                    }
                    else
                    {
                        frmPrintLabel form = (frmPrintLabel)mainForm;
                        form.SetTextLicenseMenuItem(true);
                    }
                    return true;
                case license_state.LICENSE_FREE:
                    infoString = "The license has been successfully undocked. The next application run with the same license key will attach this license to another computer, on which the program will be launched.";
                    titleString = "License status";
                    icon = MessageBoxIcon.Information;
                    return false;
                case license_state.LICENSE_UNKNOW:
                    infoString = "Failed license status determination.";
                    titleString = "License status unknown";
                    return false;
                default:
                    return false;
            }
        }

        private void CloseProgramm()
        {
            if (flTuchScreen)
            {
                frmPrintLabelTuchScreen form = (frmPrintLabelTuchScreen)mainForm;
                form.SetConfirm(false);
            }
            else
            {
                frmPrintLabel form = (frmPrintLabel)mainForm;
                form.SetConfirm(false);
            }
            Application.Exit();
        }
    }
}
