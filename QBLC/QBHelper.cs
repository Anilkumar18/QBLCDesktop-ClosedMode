using System;
using System.Collections.Generic;
using System.Text;
//using Interop.QBFC10;
using Interop.QBFC13;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace LabelConnector
{
    public class QBHelper
    {
        public QBHelper()
        {
        }

        public static QBSessionManager OpenQBConnection(string pstrcompanyfilename, string pstrfileopenmode)
        {
            QBSessionManager lQBSessionManager = null;
            try
            {
                lQBSessionManager = ModGlobal.QBGlobalSessionManager;
                lQBSessionManager.OpenConnection("Application", "LabelConnector");

                if (ENOpenMode.omSingleUser.ToString() == pstrfileopenmode)
                    lQBSessionManager.BeginSession(pstrcompanyfilename, ENOpenMode.omSingleUser);
                else if (ENOpenMode.omMultiUser.ToString() == pstrfileopenmode)
                    lQBSessionManager.BeginSession(pstrcompanyfilename, ENOpenMode.omMultiUser);
                else
                    lQBSessionManager.BeginSession(pstrcompanyfilename, ENOpenMode.omDontCare);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "LabelConnector");
            }
            return lQBSessionManager;
        }
        public static void CloseQBConnection(QBSessionManager lQBSessionManager)
        {
            if ((lQBSessionManager != null))
            {
                lQBSessionManager.EndSession();
                lQBSessionManager.CloseConnection();
            }
        }

        public static string ClosedQBConnection(string QBFilePath)
        {
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            QBSessionManager sessionManager = null;

            try
            {
                sessionManager = new QBSessionManager();
                if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("CompanyFilePath")))
                {
                    IMsgSetRequest requestMsgSet = sessionManager.CreateMsgSetRequest("US", 13, 0);
                    requestMsgSet.Attributes.OnError = ENRqOnError.roeContinue;
                    sessionManager.OpenConnection2("", "Label Connector", ENConnectionType.ctLocalQBD);
                    sessionManager.BeginSession(QBFilePath, ENOpenMode.omDontCare);
                }

                return "Success";
            }
            catch (Exception ex)
            {

                if (ex.Message == "A QuickBooks company data file is already open and it is different from the one requested or there are multiple company files open.")
                {
                    return ("Another company data file is opened, please close the company data file or try to connect the opened company data file.");
                }
                else if (ex.Message == "This application is unable to log into this QuickBooks company data file automatically. The QuickBooks administrator must grant permission for an automatic login through the Integrated Application preferences.  If such permission was already granted, the administrator must revoke permission, save preferences, then grant the permission again.")
                {
                    return ("To continue please open QuickBooks and grant permission for the selected company data");
                }
                else if (ex.Message == "A model dialog box is showing in the QuickBooks user interface. your application cannot access QuickBooks until the user dismisses the dialog box.")
                {
                    return ("To continue please open QuickBooks and grant permission for the selected company data");
                }
                else if (ex.Message == "This application has not accessed this QuickBooks company data file before. The QuickBooks administrator must grant an application permission to access a QuickBooks company data file for the first time.")
                {
                    return ("Your permission might be revoked, so please reconnect the quickbooks again");
                }
                else
                {
                    return (ex.Message);
                }
            }
        }


        public static QBSessionManager ConnectQBCloseMode(string QBFilePath)
        {
            QBConfiguration lobjQBConfiguration = new QBConfiguration();
            QBSessionManager sessionManager = null;
            try
            {
                sessionManager = new QBSessionManager();
                if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("CompanyFilePath")))
                {
                    sessionManager.OpenConnection2("", "Label Connector", ENConnectionType.ctLocalQBD);

                    sessionManager.BeginSession(QBFilePath, ENOpenMode.omDontCare);
                }
               
            }
            catch (Exception ex) { throw ex; }
            return sessionManager;
        }
        

        public static void WriteLog(string pstrLogingText)
        {
            
            if(!System.IO.Directory.Exists(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Log")))
            {
                System.IO.Directory.CreateDirectory(Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "Log"));
            }
            string strFileName = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "/Log/LabelConnectorLog_" + DateTime.Now.ToString("MM_dd_yyyy") + ".txt");
            StreamWriter lobjStreamWriter = new StreamWriter(strFileName,true);
            lobjStreamWriter.WriteLine(pstrLogingText);
            lobjStreamWriter.Close();
        }
    }
}
