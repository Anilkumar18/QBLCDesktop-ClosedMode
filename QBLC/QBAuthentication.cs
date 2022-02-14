using System;
using System.Collections.Generic;
using System.Text;
//using Interop.QBFC10;
using Interop.QBFC13;
using System.Xml;
using System.Windows.Forms;

namespace LabelConnector
{
    public class QBConfiguration
    {
        public string GetLabelConfigSettings(string strLabel)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                // Uses reflection to find the location of the config file.
                System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                xmlDoc.Load(FileInfo.FullName);

                // Finds the right node and change it to the new value.
                System.Xml.XmlNode Node = null;
                //System.Xml.XmlNode NodeWeather = null;
                //Node = xmlDoc.SelectSingleNode("configuration/appSettings/add[@key='LabelPath']/@value");
                //NodeWeather = xmlDoc.SelectSingleNode("configuration/appSettings/add[@key='LabelPath']/@value");
                //if ((!object.ReferenceEquals(Node, "")))
                //{
                //    return Node.InnerText;
                //}
                //else
                //{
                //    return string.Empty;
                //}

                XmlNode appsettingNodes = xmlDoc.SelectSingleNode("configuration/appSettings");
                string strLabelPath = string.Empty;

                foreach (XmlNode Node_loopVariable in appsettingNodes)
                {
                    Node = Node_loopVariable;
                    // skip any comments
                    if (Node.Name == "add")
                    {
                        if (Node.Attributes.GetNamedItem("key").Value == strLabel)
                        {
                            strLabelPath = Node.Attributes.GetNamedItem("value").Value;
                            break;
                        }
                    }
                }
                return strLabelPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                return string.Empty;
            }
        }
        public string GetQuickBooksDataAccessConfigSettings(string pstrMode)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                // Uses reflection to find the location of the config file.
                System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                xmlDoc.Load(FileInfo.FullName);

                // Finds the right node and change it to the new value.
                System.Xml.XmlNode Node = null;
                Node = xmlDoc.SelectSingleNode("configuration/appSettings/add[@key='" + pstrMode + "']/@value");
                if ((!object.ReferenceEquals(Node, "")))
                {
                    return Node.InnerText;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                return string.Empty;
            }
        }
        public static bool GetIsPCScreenSettings()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                // Uses reflection to find the location of the config file.
                System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                xmlDoc.Load(FileInfo.FullName);
                System.Xml.XmlNode Node = null;
                Node = xmlDoc.SelectSingleNode("configuration/appSettings/add[@key='DisplayOption']/@value");
                if ((!object.ReferenceEquals(Node, "")))
                {
                    if (Node.InnerText == "PC")
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                return false;
            }
        }
        public void SaveScreenSettings(bool pblnIsPCScreen)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                // Uses reflection to find the location of the config file.
                System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                if (!FileInfo.Exists)
                {
                    throw new Exception("Missing config file");
                }

                xmlDoc.Load(FileInfo.FullName);

                // Finds the right node and change it to the new value.
                System.Xml.XmlNode Node = null;
                bool FoundIt = false;
                XmlNode appsettingNodes = xmlDoc.SelectSingleNode("configuration/appSettings");
                //foreach (System.Xml.XmlNode Node_loopVariable in xmlDoc.Item("configuration").Item("appSettings"))
                foreach (XmlNode Node_loopVariable in appsettingNodes)
                {
                    Node = Node_loopVariable;
                    // skip any comments
                    if (Node.Name == "add")
                    {
                        if (Node.Attributes.GetNamedItem("key").Value == "DisplayOption")
                        {
                            if (pblnIsPCScreen)
                                Node.Attributes.GetNamedItem("value").Value = "PC";
                            else
                                Node.Attributes.GetNamedItem("value").Value = "TuchScreen";

                            break;
                        }
                    }
                }
                xmlDoc.Save(FileInfo.FullName);

                MessageBox.Show("Screen setting is saved. Please restart the application to reflect display settings.", "Label Connector");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
        }
        public void SaveLabelFilePathSettings(string pstrLabelFolder,string strLabel)
        {
            try
            {
                if (pstrLabelFolder !=null)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    // Uses reflection to find the location of the config file.
                    System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                    System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                    if (!FileInfo.Exists)
                    {
                        throw new Exception("Missing config file");
                    }

                    xmlDoc.Load(FileInfo.FullName);

                    // Finds the right node and change it to the new value.
                    System.Xml.XmlNode Node = null;
                    bool FoundIt = false;
                    XmlNode appsettingNodes = xmlDoc.SelectSingleNode("configuration/appSettings");
                    //foreach (System.Xml.XmlNode Node_loopVariable in xmlDoc.Item("configuration").Item("appSettings"))
                    foreach (XmlNode Node_loopVariable in appsettingNodes)
                    {
                        Node = Node_loopVariable;
                        // skip any comments
                        if (Node.Name == "add")
                        {
                            if (Node.Attributes.GetNamedItem("key").Value == strLabel)
                            {
                                Node.Attributes.GetNamedItem("value").Value = pstrLabelFolder;
                                break;
                            }
                            else
                            { 
                            
                            }
                        }
                    }
                    xmlDoc.Save(FileInfo.FullName);

                    //MessageBox.Show("LabelPath is saved.", "Label Connector");
                }
                else
                {
                    
                        MessageBox.Show("No Path is selected", "Label Connector");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
        }

        public void SaveCustomFields(string pstrLabelFolder, string strLabel)
        {
            try
            {
               // if (!string.IsNullOrEmpty(pstrLabelFolder))
               // {
                    XmlDocument xmlDoc = new XmlDocument();
                    // Uses reflection to find the location of the config file.
                    System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                    System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                    if (!FileInfo.Exists)
                    {
                        throw new Exception("Missing config file");
                    }

                    xmlDoc.Load(FileInfo.FullName);

                    // Finds the right node and change it to the new value.
                    System.Xml.XmlNode Node = null;
                    bool FoundIt = false;
                    XmlNode appsettingNodes = xmlDoc.SelectSingleNode("configuration/appSettings");
                    //foreach (System.Xml.XmlNode Node_loopVariable in xmlDoc.Item("configuration").Item("appSettings"))
                    foreach (XmlNode Node_loopVariable in appsettingNodes)
                    {
                        Node = Node_loopVariable;
                        // skip any comments
                        if (Node.Name == "add")
                        {
                            if (Node.Attributes.GetNamedItem("key").Value == strLabel)
                            {
                                Node.Attributes.GetNamedItem("value").Value = pstrLabelFolder;
                                break;
                            }
                            else
                            {

                            }
                        }
                    }
                    xmlDoc.Save(FileInfo.FullName);

                    //MessageBox.Show("LabelPath is saved.", "Label Connector");
                //}
                //else
                //{
                //    MessageBox.Show("No Path is selected", "Label Connector");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
        }

        public void SavePOHeaderTextSettings(string pstrexpdate,string pstrSN, string pstrexpdateval,string pstrSNvalue)
       // public void SavePOHeaderTextSettings(string pstrSN, string pstrexpdate, string pstrSNvalue, string pstrexpdateval)
        {
            try
            {
               // if (!string.IsNullOrEmpty(pstrexpdateval) || !string.IsNullOrEmpty(pstrSNvalue))
               // {
                    XmlDocument xmlDoc = new XmlDocument();
                    // Uses reflection to find the location of the config file.
                    System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                    System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                    if (!FileInfo.Exists)
                    {
                        throw new Exception("Missing config file");
                    }

                    xmlDoc.Load(FileInfo.FullName);

                    // Finds the right node and change it to the new value.
                    System.Xml.XmlNode Node = null;
                   // bool FoundIt = false;
                    XmlNode appsettingNodes = xmlDoc.SelectSingleNode("configuration/appSettings");
                    //foreach (System.Xml.XmlNode Node_loopVariable in xmlDoc.Item("configuration").Item("appSettings"))
                    foreach (XmlNode Node_loopVariable in appsettingNodes)
                    {
                        Node = Node_loopVariable;
                        // skip any comments
                        if (Node.Name == "add")
                        {
                            if (Node.Attributes.GetNamedItem("key").Value == pstrexpdate)
                            {
                                Node.Attributes.GetNamedItem("value").Value = pstrexpdateval;
                               // break;
                            }
                            else if (Node.Attributes.GetNamedItem("key").Value == pstrSN)
                            {
                                Node.Attributes.GetNamedItem("value").Value = pstrSNvalue;
                               // break;
                            }
                        }
                    }
                    xmlDoc.Save(FileInfo.FullName);

                    //MessageBox.Show("LabelPath is saved.", "Label Connector");
                //}
                //else
                //{
                //    MessageBox.Show("Please enter header text", "Label Connector");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
        }

        public void SaveQBDataAccessSettings(string pstrFilemode)
        {
            try
            {
                if (!string.IsNullOrEmpty(pstrFilemode))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    // Uses reflection to find the location of the config file.
                    System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                    System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                    if (!FileInfo.Exists)
                    {
                        throw new Exception("Missing config file");
                    }

                    xmlDoc.Load(FileInfo.FullName);

                    // Finds the right node and change it to the new value.
                    System.Xml.XmlNode Node = null;
                    bool FoundIt = false;
                    XmlNode appsettingNodes = xmlDoc.SelectSingleNode("configuration/appSettings");
                    //foreach (System.Xml.XmlNode Node_loopVariable in xmlDoc.Item("configuration").Item("appSettings"))
                    foreach (XmlNode Node_loopVariable in appsettingNodes)
                    {
                        Node = Node_loopVariable;
                        // skip any comments
                        if (Node.Name == "add")
                        {
                            if (Node.Attributes.GetNamedItem("key").Value == "FileMode")
                            {
                                Node.Attributes.GetNamedItem("value").Value = pstrFilemode;
                                break;
                            }
                        }
                    }
                    xmlDoc.Save(FileInfo.FullName);

                    MessageBox.Show("QuickBooks Data Access Setting is saved.", "Label Connector");
                }
                else
                {
                    MessageBox.Show("No Path is selected", "Label Connector");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
        }
        //Div by quantity per container Date:05-21-2016
        public Dictionary<string, string> GetQuantityPerContainterConfigSettings()
        {
            Dictionary<string, string> pobjdata = new Dictionary<string, string>();
            List<string> lstdata = new List<string>();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                // Uses reflection to find the location of the config file.
                System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                xmlDoc.Load(FileInfo.FullName);

                // Finds the right node and change it to the new value.
                System.Xml.XmlNode Node = null;

                lstdata.Add("QtyPerContainer");
                lstdata.Add("DCNumber");
                lstdata.Add("Carrier");

                lstdata.Add("Entryonetext");
                lstdata.Add("Entrytwotext");
                lstdata.Add("QtyPerContainerField");
                lstdata.Add("MarkUpPriceField");

                foreach (var lboj in lstdata)
                {

                    Node = xmlDoc.SelectSingleNode("configuration/appSettings/add[@key='" + lboj.ToString() + "']/@value");
                    if ((!object.ReferenceEquals(Node, "")))
                    {

                        switch (lboj.ToString().ToUpper())
                        {
                            case "QTYPERCONTAINER":
                                pobjdata["QtyPerContainer"] = Node.InnerText == "1" ? "1" : "0";
                                break;
                            case "DCNUMBER":
                                pobjdata["DCNumber"] = Node.InnerText == "1" ? "1" : "0";
                                break;
                            case "CARRIER":
                                pobjdata["Carrier"] = Node.InnerText == "1" ? "1" : "0";
                                break;
                            case "ENTRYONETEXT":
                                pobjdata["Entryonetext"] = Node.InnerText !="" ?  Node.InnerText :string.Empty;
                                break;

                            case "ENTRYTWOTEXT":
                                pobjdata["Entrytwotext"] = Node.InnerText != "" ? Node.InnerText : string.Empty;
                                break;

                            case "QTYPERCONTAINERFIELD":
                                pobjdata["QtyPerContainerField"] = Node.InnerText != "" ? Node.InnerText : string.Empty;
                                break;

                            case "MARKUPPRICEFIELD":
                                pobjdata["MarkUpPriceField"] = Node.InnerText != "" ? Node.InnerText : string.Empty;
                                break;

                            default:
                                break;

                        }

                    }
                    else
                    {
                        return pobjdata;
                    }
                }

                return pobjdata;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                return pobjdata;
            }
        }

        public void SaveQuantyPerContainerSettings(bool blnwithQtyperContainer, bool blnEntry1, bool blnEntry2,string strEntryonetext,string strEntrytwotext,string strQtypercontainercustomfield,string strtxtmarkupfield)
        {
            try
            {

                XmlDocument xmlDoc = new XmlDocument();
                // Uses reflection to find the location of the config file.
                System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                if (!FileInfo.Exists)
                {
                    throw new Exception("Missing config file");
                }

                xmlDoc.Load(FileInfo.FullName);

                // Finds the right node and change it to the new value.
                System.Xml.XmlNode Node = null;
                //bool FoundIt = false;
                XmlNode appsettingNodes = xmlDoc.SelectSingleNode("configuration/appSettings");
                //foreach (System.Xml.XmlNode Node_loopVariable in xmlDoc.Item("configuration").Item("appSettings"))
                foreach (XmlNode Node_loopVariable in appsettingNodes)
                {
                    Node = Node_loopVariable;
                    // skip any comments
                    if (Node.Name == "add")
                    {
                       
                        switch (Node.Attributes.GetNamedItem("key").Value.ToString().ToUpper())
                        {

                            case "QTYPERCONTAINER":
                                Node.Attributes.GetNamedItem("value").Value = blnwithQtyperContainer ? "1" : "0";
                               //Node.Attributes.GetNamedItem("value").Value = blnwithQtyperContainer ? "1" : "1";
                                break;
                            case "DCNUMBER":
                               
                                Node.Attributes.GetNamedItem("value").Value = blnEntry1 ? "1" : "0";
                               
                                break;
                            case "CARRIER":
                                Node.Attributes.GetNamedItem("value").Value = blnEntry2 ? "1" : "0";
                              
                                break;
                            case "ENTRYONETEXT":
                                Node.Attributes.GetNamedItem("value").Value = strEntryonetext != "" ? strEntryonetext : string.Empty;
                                break;
                            case "ENTRYTWOTEXT":
                                Node.Attributes.GetNamedItem("value").Value = strEntrytwotext != "" ? strEntrytwotext : string.Empty;
                                break;
                            case "QTYPERCONTAINERFIELD":
                                Node.Attributes.GetNamedItem("value").Value = strQtypercontainercustomfield != "" ? strQtypercontainercustomfield : string.Empty;
                                break;
                            case "MARKUPPRICEFIELD":
                                Node.Attributes.GetNamedItem("value").Value = strtxtmarkupfield != "" ? strtxtmarkupfield : string.Empty;
                                break;

                            default:
                                break;
                        }


                    }
                }
                xmlDoc.Save(FileInfo.FullName);

                //MessageBox.Show("LabelPath is saved.", "Label Connector");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
        }


        public void SavePOReceiptDataAccessSettings(string pstrFilemode)
        {
            try
            {
                if (!string.IsNullOrEmpty(pstrFilemode))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    // Uses reflection to find the location of the config file.
                    System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
                    System.IO.FileInfo FileInfo = new System.IO.FileInfo(Asm.Location + ".config");
                    if (!FileInfo.Exists)
                    {
                        throw new Exception("Missing config file");
                    }

                    xmlDoc.Load(FileInfo.FullName);

                    // Finds the right node and change it to the new value.
                    System.Xml.XmlNode Node = null;
                    bool FoundIt = false;
                    XmlNode appsettingNodes = xmlDoc.SelectSingleNode("configuration/appSettings");
                    //foreach (System.Xml.XmlNode Node_loopVariable in xmlDoc.Item("configuration").Item("appSettings"))
                    foreach (XmlNode Node_loopVariable in appsettingNodes)
                    {
                        Node = Node_loopVariable;
                        // skip any comments
                        if (Node.Name == "add")
                        {
                            if (Node.Attributes.GetNamedItem("key").Value == "ShowPo")
                            {
                                Node.Attributes.GetNamedItem("value").Value = pstrFilemode;
                                break;
                            }
                        }
                    }
                    xmlDoc.Save(FileInfo.FullName);

                   // MessageBox.Show("Setting saved sucessfully", "Label Connector");
                }
                else
                {
                    MessageBox.Show("select any option", "Label Connector");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
        }

    }

    public class QBAuthentication
    {
        public enum UnAttendedModePreference
        {
            Required,
            Optional
        }


        public enum PersonalDataPreference
        {
            Required,
            Optional,
            NotNeeded
        }
        /// <summary>
        /// Default constructor need to set all the properties to work on
        /// </summary>
        /// <initiated by>Amit Chavan</initiated by>
        /// <creation date>05/08/2011</creation date>
        public QBAuthentication()
        {
        }


        /// <summary>
        /// Parameterized constructor with three parameter
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="CompanyFile"></param>
        /// <initiated by>Amit Chavan</initiated by>
        /// <creation date>05/08/2011</creation date>
        public QBAuthentication(string UserName, string Password, string CompanyFile)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.CompanyFile = CompanyFile;
        }

        /// <summary>
        /// Parameterized constructor with three parameter
        /// </summary>
        /// <param name="OpenMode"></param>
        /// <param name="CompanyFile"></param>
        /// <initiated by>Amit Chavan</initiated by>
        /// <creation date>05/08/2011</creation date>
        public QBAuthentication(string CompanyFile, string OpenMode)
        {
            this.CompanyFile = CompanyFile;
            switch (OpenMode)
            {
                case "omMultiUser":
                    this.OpenMode = ENOpenMode.omMultiUser;
                    break;
                case "omSingleUser":
                    this.OpenMode = ENOpenMode.omSingleUser;
                    break;
                default:
                    this.OpenMode = ENOpenMode.omDontCare;
                    break;
            }
        }


        /// <summary>
        /// Parameterized constructor with five parameter
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="CompanyFile"></param>
        /// <param name="ConnectionType"></param>
        /// <param name="OpenMode"></param>
        public QBAuthentication(string UserName, string Password, string CompanyFile, ENConnectionType ConnectionType, ENOpenMode OpenMode)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.CompanyFile = CompanyFile;
            this.ConnectionType = ConnectionType;
            this.OpenMode = OpenMode;
        }

        private string lsUserName;
        /// <summary>
        /// Get or Set the QB user name
        /// </summary>
        /// <initiated by>Amit Chavan</initiated by>
        /// <creation date>05/08/2011</creation date>
        public string UserName
        {
            get
            {
                return lsUserName;
            }
            set
            {
                lsUserName = value;
            }
        }


        private string lsPassword;
        /// <summary>
        /// Get or Set the QB Password
        /// </summary>
        /// <initiated by>Amit Chavan</initiated by>
        /// <creation date>05/08/2011</creation date>
        public string Password
        {
            get
            {
                return lsPassword;
            }
            set
            {
                lsPassword = value;
            }
        }


        private string lsCompanyFile;
        /// <summary>
        /// Get or Set the QB CompanyFile
        /// </summary>
        /// <initiated by>Amit Chavan</initiated by>
        /// <creation date>05/08/2011</creation date>
        public string CompanyFile
        {
            get
            {
                return lsCompanyFile;
            }
            set
            {
                lsCompanyFile = value;
            }
        }



        private Interop.QBFC13.ENConnectionType loConnetionType;
        /// <summary>
        /// Get or Set the QB ConnectionType
        /// </summary>
        /// <initiated by>Amit Chavan</initiated by>
        /// <creation date>05/08/2011</creation date>
        public Interop.QBFC13.ENConnectionType ConnectionType
        {
            get
            {
                return loConnetionType;
            }
            set
            {
                loConnetionType = value;
            }
        }


        private Interop.QBFC13.ENOpenMode loOpenMode;
        /// <summary>
        /// Get or Set the QB File Open Mode
        /// </summary>
        /// <initiated by>Amit Chavan</initiated by>
        /// <creation date>05/08/2011</creation date>
        public Interop.QBFC13.ENOpenMode OpenMode
        {
            get
            {
                return loOpenMode;
            }
            set
            {
                loOpenMode = value;
            }
        }

        PersonalDataPreference _PersonalDataPref;
        public PersonalDataPreference PersonalDataPref
        {
            get
            {
                return _PersonalDataPref;
            }
            set
            {
                _PersonalDataPref= value;
            }
        }

        UnAttendedModePreference _UnAttendedModePref;
        public UnAttendedModePreference UnAttendedModePref
        {
            get
            {
                return _UnAttendedModePref;
            }
            set
            {
                _UnAttendedModePref =value;
            }
        }

        /// <summary>
        /// Authenticate UserName and password 
        /// </summary>
        /// <returns>True if Autheticate / False for invalid user</returns>
        public bool AuthenticateQBUser()
        {
            bool bAuthPreferenceStatus = false;
            QBSessionManager sessManager = default(QBSessionManager);
           // sessManager = new QBSessionManagerClass();
            sessManager = ModGlobal.QBGlobalSessionManager;

            IQBAuthPreferences QBAuthPreference = default(IQBAuthPreferences);
            QBAuthPreference = sessManager.QBAuthPreferences;

            switch (PersonalDataPref)
            {
                case PersonalDataPreference.Required:
                    QBAuthPreference.PutPersonalDataPref(ENPersonalDataPrefType.pdptRequired);
                    break;
                case PersonalDataPreference.NotNeeded:
                    QBAuthPreference.PutPersonalDataPref(ENPersonalDataPrefType.pdptNotNeeded);
                    break;
                case PersonalDataPreference.Optional:
                    QBAuthPreference.PutPersonalDataPref(ENPersonalDataPrefType.pdptOptional);
                    break;
            }

            switch (UnAttendedModePref)
            {
                case UnAttendedModePreference.Required:
                    QBAuthPreference.PutUnattendedModePref(ENUnattendedModePrefType.umptRequired);
                    break;
                case UnAttendedModePreference.Optional:
                    QBAuthPreference.PutUnattendedModePref(ENUnattendedModePrefType.umptOptional);
                    break;
            }

            //Write code here to authenticate User for QuickBooks
            try
            {
                OpenConnection(sessManager, CompanyFile, OpenMode);
                bAuthPreferenceStatus = QBAuthPreference.WasAuthPreferencesObeyed();
                sessManager.CloseConnection();
            }
            catch (Exception Ex)
            {
                
            }
            return bAuthPreferenceStatus;
        }
        public static void OpenConnection(QBSessionManager poQBSessionManager, string pstrFileName, ENOpenMode poOpenMode)
        {
            try
            {
                poQBSessionManager.OpenConnection("Application", "LabelConnector");
                poQBSessionManager.BeginSession(pstrFileName, poOpenMode);
            }
            catch(Exception Ex)
            {
                string str = Ex.Message;
            }
        }

        
    }
}
