using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace LabelConnector
{
    class GetCustomerConsumerDetails
    {
        public static void GetConsumerDetails(ref string ClientID, ref string ConsumerSecret)
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
            XmlNode appsettingNodes = xmlDoc.SelectSingleNode("configuration/appSettings");

            foreach (XmlNode Node_loopVariable in appsettingNodes)
            {
                Node = Node_loopVariable;
                // skip any comments
                if (Node.Name == "add")
                {
                    if (Node.Attributes.GetNamedItem("key").Value == "ClientID")
                    {
                        ClientID = Node.Attributes.GetNamedItem("value").Value;
                    }
                    if (Node.Attributes.GetNamedItem("key").Value == "ConsumerSecret")
                    {
                        ConsumerSecret = Node.Attributes.GetNamedItem("value").Value;
                    }
                }
            }
        }
    }
}
