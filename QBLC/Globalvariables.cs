using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LabelConnector
{
   public class Globalvariables
    {
        public static string LoginMailID;
        public static string LoginPassword;
        public static int SessionReference;
        public static string DownloadLink;
        public static string ReleaseNotes;
        public static string EncryptLoginMailID;
        public static string EncryptLoginPassword;
        public static string PrintTemplateName;
        public static string PrintTemplateStatus= "0";
        public static string PrintTemplateGOStatus = "0";
        public static string CreatedNewConnection = "0";

        public class EncrytPassword
        {
            public static string EncryptString(string plainText)
            {
                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(plainText);
                string encrypted = Convert.ToBase64String(b);
                return encrypted;
            }
        }


    }
}
