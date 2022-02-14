
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LabelConnector
{

    public class clsLogin
    {

        public string EncryptPassword(string password)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
            return Convert.ToBase64String(b);
        }
        public string DecryptPassword(string password)
        {
            byte[] b;
            string decrypted = "";
            try
            {
                b = Convert.FromBase64String(password);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
                return decrypted;
            }
            catch (FormatException fe)
            {
                decrypted = "";
                return decrypted;
            }
        }

       
    }

    public static class Session
    {
        private static string _Session = "";

        public static string Sessions
        {
            get { return _Session; }
            set { _Session = value; }
        }
    }
}
