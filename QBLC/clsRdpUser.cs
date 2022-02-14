using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace LabelConnector
{
    public class clsRdpUser
    {
        public clsRdpUser()
        {

        }
        string lstrUserRdpUserName;
        string lstrLoginCount;
        public string RdpUserName
        {
            get
            {
                return lstrUserRdpUserName;
            }
            set
            {
                lstrUserRdpUserName = value;
            }
        }
        public string UserLoginCount
        {
            get
            {
                return lstrLoginCount;
            }
            set
            {
                lstrLoginCount = value;
            }
        }
        public void testuser(string pstrLoggedUserName)
        {
            //write user name to xml file: Dae 12-08-2017 
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\");
            if (System.IO.File.Exists(strStartupPath + "RdpUsers.xml"))
            {
                // System.IO.File.Delete(strStartupPath + @"\RdpUsers.xml");
            }
            XmlTextWriter objXmlTextWriter = new XmlTextWriter(strStartupPath + "RdpUsers.xml", System.Text.Encoding.UTF8);
            objXmlTextWriter.WriteStartDocument(true);
            objXmlTextWriter.Formatting = Formatting.Indented;
            objXmlTextWriter.Indentation = 2;
            objXmlTextWriter.WriteStartElement("User");
            CreateRdpUserNode(pstrLoggedUserName, objXmlTextWriter);


            //close xmlwriter object
            objXmlTextWriter.WriteEndElement();
            objXmlTextWriter.WriteEndDocument();
            objXmlTextWriter.Flush();
            objXmlTextWriter.Close();

        }
        private void CreateRdpUserNode(string UserName, XmlTextWriter writer)
        {
            writer.WriteStartElement("RdpUser");
            writer.WriteStartElement("UserName"); //1
            writer.WriteString(UserName);  //1
            writer.WriteEndElement(); //1
            writer.WriteStartElement("LoginCount");
            writer.WriteString("1");
            writer.WriteEndElement();

            writer.WriteEndElement();


        }


        public static int RdpUserCount()
        {
            int lntactiveusercount = 0;
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "RdpUsers.xml");
            try
            {
                if (File.Exists(strStartupPath))
                {
                    XDocument xRdpUserDocument = XDocument.Load(strStartupPath);
                    //Get login user count
                    lntactiveusercount = xRdpUserDocument.Descendants("users").Descendants("user").Distinct().Count();
                }
            }
            catch (XmlException Exp)
            {
                lntactiveusercount = 0;

            }
            return lntactiveusercount;
        }
        public void WriteRdpUsers(string pstrRdpuser)
        {

            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "RdpUsers.xml");
           // int usercount = 0;
           // usercount = RdpUserCount() + 1;

            if (File.Exists(strStartupPath))
            {
                if (IsXmlEmpty(strStartupPath))
                {

                    XmlTextWriter objXmlTextWriter = new XmlTextWriter(strStartupPath, System.Text.Encoding.UTF8);
                    objXmlTextWriter.WriteStartDocument(true);
                    objXmlTextWriter.Formatting = Formatting.Indented;
                    objXmlTextWriter.Indentation = 2;

                    objXmlTextWriter.WriteStartElement("users");

                    objXmlTextWriter.WriteStartElement("user");

                    objXmlTextWriter.WriteAttributeString("Id",  AutoIncrement().ToString());
                    objXmlTextWriter.WriteString(pstrRdpuser);


                    objXmlTextWriter.WriteEndElement();

                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteEndDocument();
                    objXmlTextWriter.Flush();
                    objXmlTextWriter.Close();


                    // XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    //xmlWriterSettings.Indent = true;

                    // using (XmlWriter xmlWriter = XmlWriter.Create(strStartupPath, xmlWriterSettings))
                    // {
                    //     xmlWriter.WriteStartDocument();
                    //     xmlWriter.WriteStartElement("users");

                    //     xmlWriter.WriteStartElement("user");

                    //     xmlWriter.WriteAttributeString("Id", usercount.ToString());
                    //     xmlWriter.WriteString(pstrRdpuser);


                    //         xmlWriter.WriteEndElement();

                    //      xmlWriter.WriteEndElement();
                    //     xmlWriter.WriteEndDocument();
                    //     xmlWriter.Flush();
                    //     xmlWriter.Close();

                    // }
                }
                else
                {
                    XDocument xDocument = XDocument.Load(strStartupPath);
                   // if (RdpUserCount() > 0)
                   // {

                        //var Isrdpuserexist = from rdpuser in xDocument.Descendants("users") //.Descendants("user")
                        //                                                                    // where rdpuser.Attribute("Id").Value.ToLower() == pstrRdpuser.ToLower()
                        //                     where rdpuser.Element("user").Value.ToLower() == pstrRdpuser.ToLower()
                        //                     select rdpuser;

                        if (IsRdpUserExistInXml(pstrRdpuser)) //check node is exist
                        {
                            //foreach (XElement itemElement in checkuser) //update
                            //{
                            //    itemElement.SetElementValue("username", pstrRdpuser);
                            //    xDocument.Save(strStartupPath);
                            //}

                        }
                        else
                        {

                        //Add element to the last

                        //XElement root = xDocument.Element("users");
                        //IEnumerable<XElement> rows = root.Descendants("user");
                        //XElement lastRow = rows.Last();
                        //lastRow.AddAfterSelf(
                        //   new XElement("user",
                        //   new XAttribute("Id",  AutoIncrement().ToString()), pstrRdpuser)

                        //   );

                        //xDocument.Save(strStartupPath);

                        ////////working code above////////

                        XmlDocument doc = new XmlDocument();
                        
                        //load from file

                        doc.Load(strStartupPath);
                        
                        //select your specific node ..

                        XmlElement el = (XmlElement)doc.SelectSingleNode("/users/user");



                        //create node and add value
                        
                        XmlElement node = doc.CreateElement("user");
                        node.InnerText = pstrRdpuser;
                        node.SetAttribute("Id", AutoIncrement().ToString());
                        
                       //add to elements collection
                        doc.DocumentElement.AppendChild(node);
                        
                        //save back
                        doc.Save(strStartupPath);
                       
                    }

                    //  }
                    //else
                    //{

                    ////if no node is exist
                    //XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    //xmlWriterSettings.Indent = true;
                    //// xmlWriterSettings.NewLineOnAttributes = true;
                    //using (XmlWriter xmlWriter = XmlWriter.Create(strStartupPath, xmlWriterSettings))
                    //{
                    //    xmlWriter.WriteStartDocument();
                    //    xmlWriter.WriteStartElement("users");

                    //    xmlWriter.WriteStartElement("user");
                    //    // xmlWriter.WriteElementString("username", pstrRdpuser);
                    //    xmlWriter.WriteAttributeString("Id", usercount.ToString());
                    //    xmlWriter.WriteString(pstrRdpuser);

                    //    // xmlWriter.WriteElementString("logincount", logincount);
                    //    xmlWriter.WriteEndElement();

                    //    xmlWriter.WriteEndElement();
                    //    xmlWriter.WriteEndDocument();
                    //    xmlWriter.Flush();
                    //    xmlWriter.Close();
                    //}


                    // }


                    //check if give user is exist then update login count

                    //var userquery = from t in xDocument.Descendants("user").Descendants("rdpuser")
                    //            where t.Element("username").Value.ToLower() == pstrRdpuser.ToLower()

                    //            select new
                    //            {

                    //                username = t.Element("username").Value,
                    //                logincount = t.Element("logincount").Value
                    //            };

                    //foreach (var item in userquery)
                    //{
                    //    item.logincount;
                    //}



                    //update username
                    //    var Isrdpuserexist = from rdpuser in xDocument.Descendants("users") //.Descendants("user")
                    //                     // where rdpuser.Attribute("Id").Value.ToLower() == pstrRdpuser.ToLower()
                    //                     where rdpuser.Element("user").Value.ToLower() == pstrRdpuser.ToLower()
                    //                     select rdpuser;
                    //if (Isrdpuserexist.Any())
                    //{
                    //    //foreach (XElement itemElement in checkuser) //update
                    //    //{
                    //    //    itemElement.SetElementValue("username", pstrRdpuser);
                    //    //    xDocument.Save(strStartupPath);
                    //    //}

                    //}
                    //else
                    //{


                    //    //Add element to the last

                    //    XElement root = xDocument.Element("users");
                    //    IEnumerable<XElement> rows = root.Descendants("user");
                    //    XElement lastRow = rows.Last();
                    //    lastRow.AddAfterSelf(
                    //       new XElement("user",
                    //       new XAttribute("Id", usercount.ToString()), pstrRdpuser)

                    //       );
                    //    // new XElement("logincount", logincount)));
                    //    xDocument.Save(strStartupPath);
                    //}


                }
            }

        }


        public static void DeleteXmlNode(string path, string searchconditionAttributevalue)
        {


            XmlDocument XMLDoc = new XmlDocument();
            try
            {
                if (!string.IsNullOrEmpty(searchconditionAttributevalue))
                {
                    XMLDoc.Load(path);
                    XmlElement el = (XmlElement)XMLDoc.SelectSingleNode("/users/user[@Id=" + searchconditionAttributevalue + "]");
                    if (el != null) { el.ParentNode.RemoveChild(el); }
                    XMLDoc.Save(path);
                }
            }
            catch(XmlException xmlexp)
            {

            }

            //XmlDocument doc = new XmlDocument();
            //doc.Load(path);
            //XmlNodeList nodes = doc.GetElementsByTagName(tagname);

            //foreach (XmlNode node in nodes)
            //    {
            //        foreach (XmlAttribute attribute in node.Attributes)
            //        {
            //            if ((attribute.Name == "Id") && (attribute.Value == "1"))
            //            //if ((attribute.Name == "name") && (attribute.Value == "aaa"))
            //            {
            //                //delete.
            //                node.RemoveAll();
            //                break;
            //            }
            //        }
            //    }
            ////save xml file.
            //doc.Save(path);


        }


        public bool IsXmlEmpty(string pstrfilepath)
        {
            bool isempty = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pstrfilepath);
            }
            catch (XmlException exc)
            {
                //invalid file
                isempty = true;
            }
            return isempty;

        }
       public static int AutoIncrement()
       {
            //string strStartupPath = System.Windows.Forms.Application.StartupPath + @"\RdpUsers.xml";
           // userId:
            int num = 0;
            Random rndtext = new Random();
            num = rndtext.Next();
            //if(IsUserIdExistInXml(num.ToString(),strStartupPath))
            //{
            //    goto userId;
            //}
            return num;

        }
        public static bool IsUserIdExistInXml(string pstrUserId,string pstrFilePath)
        {
            bool blnuserid = false;
            string lstUserName = string.Empty;
            try
            {
               
                XmlDocument objuseridxml = new XmlDocument();
                objuseridxml.Load(pstrFilePath);
           
                XmlElement elt = objuseridxml.SelectSingleNode("//user[@Id='"+ pstrUserId + "']") as XmlElement;
                if (elt != null)
                {
                    lstUserName = elt.GetAttribute("Id");
                    blnuserid = true;
                }
                
            }
            catch(XmlException exxml)
            {
                blnuserid = false;
            }
            return blnuserid;
        }

        public static bool IsRdpUserExistInXml(string pstrRdpUserName)
        {
            bool IsRdpUserExist = false;
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\"+"RdpUsers.xml");
            if (File.Exists(strStartupPath))
            {
                try
                {
                    // XDocument xDocument = XDocument.Load(strStartupPath);
                    //var rdpusername = from rdpuser in xDocument.Descendants("users")//.Descendants("user")
                    //                  where rdpuser.Element("user").Value.ToLower().Trim() == pstrRdpUserName.ToLower().Trim()
                    //                  select rdpuser;
                    //if (rdpusername.Any())
                    //{
                    //    IsRdpUserExist = true;
                    //}
                    //var rdpusername = from rdpuser in xDocument.Descendants("user")
                    //                  select rdpuser.Element("user").Value;



                    //foreach (var objuser in rdpusername)
                    //{
                    //    if(objuser.ToString().ToLower().Trim()== pstrRdpUserName.ToLower().Trim())
                    //    {
                    //        IsRdpUserExist = true;
                    //    }
                    //}

                   
                    XmlDocument xml = new XmlDocument();

                    xml.Load(strStartupPath);

                    XmlNodeList xnList = xml.SelectNodes("/users/user");
                    foreach (XmlNode xn in xnList)
                    { 
                        if(xn.InnerText.ToString().ToLower()== pstrRdpUserName.ToLower())
                        {
                            IsRdpUserExist = true;
                            break;
                        }
                        
                    }





                }
                catch (XmlException exc)
                {
                    IsRdpUserExist = false;
                }
            }

            return IsRdpUserExist;
            

        }


        //Get Id from UserName
        public static string GetUserId(string pstrRdpUserName)
        {
            string  UserId = string.Empty;
           // string atrrId = string.Empty;
            string strStartupPath = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "RdpUsers.xml");
            if (File.Exists(strStartupPath))
            {
                try
                {
                    XmlDocument xml = new XmlDocument();

                    xml.Load(strStartupPath);

                    XmlNodeList xnList = xml.SelectNodes("/users/user");
                    foreach (XmlNode xn in xnList)
                    {
                        if (xn.InnerText.ToString().ToLower() == pstrRdpUserName.ToLower())
                        {
                            UserId = xn.Attributes["Id"].Value.ToString();
                        }

                    }


                    //////////////////////////
                    //XDocument xDocument = XDocument.Load(strStartupPath);
                   
                    //IEnumerable<XElement> rows = from rdpuser in xDocument.Descendants("users")
                    //                             where rdpuser.Element("user").Value.ToLower() == pstrRdpUserName.ToLower()
                    //                             select rdpuser;

                    ////looping through the XElement details one by one
                    //foreach (XElement ele in rows)
                    //{
                    //    //for the current xElement retrieving all the Attributes details
                    //    IEnumerable<XAttribute> attList =
                    //                   from att in ele.DescendantsAndSelf().Attributes()
                    //                   select att;

                    //    //Looping through attributes list and displaying it on the screen
                    //    foreach (XAttribute att in attList)
                    //    {
                    //       UserId=att.Value.ToString();
                    //    }


                    //}
                    
                }
                catch (XmlException exc)
                {
                    UserId = string.Empty;
                }
            }

            return UserId;


        }


        public ArrayList ReadRdpUsers(string pstrStartupPath)
        {
            clsRdpUser objrdpuser = new clsRdpUser();
            ArrayList arrRdpUserList = new ArrayList();
            long length = 0;
            XmlTextReader tr = new XmlTextReader(pstrStartupPath + @"\RdpUsers.xml");

            length = new System.IO.FileInfo(pstrStartupPath + @"\RdpUsers.xml").Length;
            if (length == 0)
            {
                return arrRdpUserList;
            }
            
            while (tr.Read())
            {

                if (tr.IsStartElement())
                {

                    
                    if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "UserName")
                    {

                        objrdpuser.lstrUserRdpUserName = tr.ReadElementString();
                    }
                     if (tr.MoveToContent() == XmlNodeType.Element && tr.Name == "LoginCount")
                    {

                        objrdpuser.lstrLoginCount = tr.ReadElementString();
                    }
                   
                   
                }

            } //end while
            tr.Close();
            if (!string.IsNullOrEmpty(objrdpuser.lstrUserRdpUserName))
             arrRdpUserList.Add(objrdpuser);
            return arrRdpUserList;


        }



        public static string GetRdpUserName()
        {
            IntPtr accountToken = WindowsIdentity.GetCurrent().Token;
            WindowsIdentity windowsIdentity = new WindowsIdentity(accountToken);
            return windowsIdentity.Name;
            //return Environment.UserName;
        }

        public static string NumberToWords(int Number)
        {
          
            string name = "";
            switch (Number)
            {

                case 1:
                    name = "one";
                    break;
                case 2:
                    name = "two";
                    break;
                case 3:
                    name = "three";
                    break;
                case 4:
                    name = "four";
                    break;
                case 5:
                    name = "five";
                    break;
                case 6:
                    name = "six";
                    break;
                case 7:
                    name = "seven";
                    break;
                case 8:
                    name = "eight";
                    break;
                case 9:
                    name = "nine";
                    break;
                default:
                    name = string.Empty;
                    break;
            }
            return name;
        }



    }
}
