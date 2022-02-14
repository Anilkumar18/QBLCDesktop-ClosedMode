using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace LabelConnector
{
    public class Serializer
    {
        public Serializer()
        {
 
        }
        public bool SaveQuickBooksAccountConfig(QuickBooksAccount pobjQuickBooksAccount, string pstrQuickBookConfigFileName)
        {
            XmlSerializer loSerializer;
            XmlSerializerNamespaces loNameSpaces;
            TextWriter loWriter;
            try
            {
                loSerializer = new XmlSerializer(typeof(QuickBooksAccount));
                loNameSpaces = new XmlSerializerNamespaces();

                loWriter = new StreamWriter(pstrQuickBookConfigFileName);
                loSerializer.Serialize(loWriter, pobjQuickBooksAccount, loNameSpaces);

                loWriter.Flush();
                loWriter.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public QuickBooksAccount ReadQuickBooksAccountConfig(string pstrQuickBooksAccountConfigFileName)
        {
            XmlSerializer loSerializer;
            XmlSerializerNamespaces loNameSpaces;
            QuickBooksAccount loQuickBooksAccountConfig;

            // A FileStream is needed to read the XML document.
            FileStream loFileStream;
            XmlReader loReadrer;

            try
            {
                loSerializer = new XmlSerializer(typeof(QuickBooksAccount));
                loNameSpaces = new XmlSerializerNamespaces();

                loFileStream = new FileStream(pstrQuickBooksAccountConfigFileName, FileMode.Open);
                loReadrer = new XmlTextReader(loFileStream);

                // Use the Deserialize method to restore the object's state.
                loQuickBooksAccountConfig = (QuickBooksAccount)loSerializer.Deserialize(loReadrer);

                loFileStream.Close();

                return loQuickBooksAccountConfig;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"LabelConnector");
                return null;
            }
        }

        public string GetQuickBooksAccountConfigFile()
        {
            return Path.Combine(GetApplicationPath(), "QuickBooksAccount.xml");
        }

        public string GetApplicationPath()
        {
            //return Path.GetDirectoryName(Application.ExecutablePath);
            return AppDomain.CurrentDomain.BaseDirectory;
        }

    }
}
