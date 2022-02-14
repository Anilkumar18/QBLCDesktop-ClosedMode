using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using LabelConnector;
using MyProg;
using System.Globalization;
using Interop.QBFC13;
using System.Diagnostics;

namespace QBLC
{
    static class Program
    {
        private static System.Threading.Mutex mutex = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string appName = "LabelConnector";
            bool createdNew;
            mutex = new System.Threading.Mutex(true, appName, out createdNew);
            if (!createdNew)
            {
                //app is already running! Exiting the application
                MessageBox.Show("The Application Is Already Running", "LabelConnector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NReco.PdfRenderer.License.SetLicenseKey(
        "PDF_Renderer_Bin_Pack_250074291197",
        "JDrgh8PMwfWabwRjIUfDHNL49H1Dw8f5rKfpl3Hy1xUH5jmSh96aTSXPKqmvKU97y6WxJnSG0MQYKHJiTwQX59oUnR+LFVpyQum+UYNxf1545CUmiK9BsV+8dIJWCioFLvrySmx6PsjTZAxbSn41PS/eva6+Yg9ZXWmVA7w2PQ4="
);

            //Read active status from config file :Date 27-Apr-2018 : CO108
            QBConfiguration lobjQBConfiguration;
            lobjQBConfiguration = new QBConfiguration();
            // if (lobjQBConfiguration.GetLabelConfigSettings("License").ToUpper().Trim() == "LICENSE_OK")
            //{
            try
            {
                QBSessionManager sessionManager =new QBSessionManager();
                ModGlobal.QBGlobalSessionManager = sessionManager;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmPrintLabel(false));
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Retrieving the COM class factory for component with CLSID"))
                {
                    MessageBox.Show("Label Connector required a QBFC13 application for connecting the QuickBooks. Please press 'OK' to install the QBFC13 application. It is a one-time process.", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var folderpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                    var path = System.IO.Path.Combine(folderpath, "QBFC13_0Installer.exe");
                    if (System.IO.File.Exists(path))
                    {
                        System.Diagnostics.Process P=  System.Diagnostics.Process.Start(path);
                        P.WaitForExit();
                    }

                    try
                    {
                        QBSessionManager sessionManager =new QBSessionManager();
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmPrintLabel(false));
                    }
                    catch (Exception ex1)
                    {
                        if (ex1.Message.StartsWith("Retrieving the COM class factory for component with CLSID"))
                        {
                            MessageBox.Show("There was an issue in connecting the QBFC13 application.");
                        }
                    }
                }
            }
                    // return;
                    //}

                    //Added by srinivas on 25-Jan-2018
                    // SetTrailDays(); #1

                    //Added below code by Srinivas on 27-Nov-2017
                    // AppDomain currentDomain = AppDomain.CurrentDomain;
                    //currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledHandler);


                    //license_state licenseState = license_state.LICENSE_UNKNOW;
                    //try
                    //{
                    //    licenseState = clsLicenseChecker.checkLicense(true);
                    //    // checking Licence key on proactive server once authentication is done &
                    //    //save activated license status in  config file: Date 27-APR-2018 :CO108

                    //    if (licenseState.ToString().ToUpper().Trim() == license_state.LICENSE_OK.ToString().ToUpper().Trim())
                    //    {

                    //        lobjQBConfiguration.SaveLabelFilePathSettings("LICENSE_OK", "License");

                    //    }


                    //}
                    //catch (Exception e)
                    //{
                    //    MessageBox.Show(e.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                    //bool flTrial = false;

                    //switch (licenseState)
                    //{
                    //    case license_state.LICENSE_ERROR_MAIN:
                    //        MessageBox.Show("The license is not confirmed. The program will be closed.", "Error of lnsMain.dll", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    case license_state.LICENSE_ERROR:
                    //        MessageBox.Show("The license is not confirmed. The program will be closed.", "Error of lns.dll", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    case license_state.LICENSE_EXPIRED:
                    //        MessageBox.Show("The license has expired. The program will be closed.", "License expired!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    case license_state.LICENSE_OK:
                    //        break;
                    //    case license_state.LICENSE_TRIAL:
                    //        flTrial = true;
                    //        break;
                    //    case license_state.LICENSE_FREE:
                    //        MessageBox.Show("The license has been successfully undocked. The next application run with the same license key will attach this license to another computer, on which the program will be launched.", "License status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    case license_state.LICENSE_UNKNOW:
                    //        MessageBox.Show("Failed license status determination.", "License status unknown", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //}


                    //clsLicenseWatcher watcher = null;

                    //Application.EnableVisualStyles();
                    //Application.SetCompatibleTextRenderingDefault(false);

                    //XmlDocument xmlDoc = new XmlDocument();
                    //// Uses reflection to find the location of the config file.
                    //System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                    //System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                    //xmlDoc.Load(FileInfo.FullName);

                    //// Finds the right node and change it to the new value.
                    //System.Xml.XmlNode Node = null;
                    //Node = xmlDoc.SelectSingleNode("configuration/appSettings/add[@key='DisplayOption']/@value");
                    //// commented below code by srinivas on 27-Nov-2017
                    ////if ((!object.ReferenceEquals(Node, "")))
                    ////{
                    ////    if ("PC" == Node.InnerText)
                    ////    {

                    ////        Application.Run(new frmPrintLabel());
                    ////    }
                    ////    else
                    ////        Application.Run(new frmPrintLabelTuchScreen());
                    ////}
                    ////End

                    ////Added below code by srinivas on 27-Nov-2017
                    //if ((!object.ReferenceEquals(Node, "")))
                    //{
                    //    Form mainForm = null;
                    //    bool flTuch = false;
                    //    if ("PC" == Node.InnerText)
                    //    {
                    //        mainForm = new frmPrintLabel(flTrial);
                    //    }
                    //    else
                    //    {
                    //        mainForm = new frmPrintLabelTuchScreen(flTrial);
                    //        flTuch = true;
                    //    }
                    //    watcher = new clsLicenseWatcher(mainForm, flTuch);
                    //    Application.Run(mainForm);
                    //    watcher.Stop();
                    //}
                    //End 

                }


        //Added below code by srinivas on 27-Nov-2017
        //static void UnhandledHandler(object sender, UnhandledExceptionEventArgs args)
        //{
        //    Exception e = (Exception)args.ExceptionObject;
        //    MessageBox.Show("MyHandler caught : " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    MessageBox.Show($"Runtime terminating: {args.IsTerminating}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //}
        //End

        /****Start***  Function for setting trail days on load this function only runs once by serinivas 22-Jan-2018*/
        //static void SetTrailDays()
        //{
        //    try
        //    {
        //        QBConfiguration lobjQBConfiguration = new QBConfiguration();
        //        string strTrailStatus = lobjQBConfiguration.GetLabelConfigSettings("trailDays");


        //        //var MyIni = new IniFile();
        //        //Int64 int15 = 1296000000;
        //        //Int64 traildays = 0;
        //        //var status = MyIni.Read("trial-status", "trailstatus");

        //        //if (status == "false")
        //        //{
        //        //    Int64 unixTimestamp = (Int64)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
        //        //    traildays = int15 + unixTimestamp;
        //        //    MyIni.Write("trial-expiration", Convert.ToString(traildays), "lns");
        //        //    MyIni.Write("trial-status", "true", "trailstatus");
        //        //}
        //        var MyIni = new IniFile();
        //        Int64 int15 = 1296000000;
        //        Int64 traildays = 0;
        //        //var status = MyIni.Read("trial-status", "trailstatus");

        //        if (strTrailStatus == "false")
        //        {
        //            Int64 unixTimestamp = (Int64)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
        //            traildays = int15 + unixTimestamp;
        //            MyIni.Write("trial-expiration", Convert.ToString(traildays), "lns");
        //            //MyIni.Write("trial-status", "true", "trailstatus");
        //            lobjQBConfiguration.SaveLabelFilePathSettings("true", "trailDays");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Label Connector");
        //        //return string.Empty;
        //    }

        //}
        /****End***  Function for setting trail days on load this function only runs once by serinivas 22-Jan-2018*/
    }
}