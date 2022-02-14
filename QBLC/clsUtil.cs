using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace LabelConnector
{
    public static class clsUtil
    {
        public static string Encrypt(string clearText)
        {
            // string EncryptionKey = "MAKV2SPBNI99212";
            string EncryptionKey = "#!EV2SPZNI1326&";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


        public static string Decrypt(string cipherText)
        {
            // string EncryptionKey = "MAKV2SPBNI99212";
            string EncryptionKey = "#!EV2SPZNI1326&";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        //check if print label is exist in folder
        public static bool IsUDFLabelExist()
        {
            string lstrUDFolder = string.Empty;
            bool islabelexist = false;
            lstrUDFolder = Environment.ExpandEnvironmentVariables(@"%appdata%\" + "QuickBooks Label Connector" + "\\" + "ZPLFormat" + "\\");
            try
            {
                if (Directory.Exists(lstrUDFolder))
                {
                    string[] filenames = Directory.GetFiles(lstrUDFolder, "*.pdf");
                    if (filenames.Length > 0)
                    {
                        islabelexist = true;
                    }
                }
            }
            catch (Exception ex)
            {
                islabelexist = false;
            }
            return islabelexist;

        }


    }
}
