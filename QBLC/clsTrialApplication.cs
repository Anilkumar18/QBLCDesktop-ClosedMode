using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace LabelConnector
{
   public class clsTrialApplication
    {
       public clsTrialApplication() { }
       QBConfiguration lobjQBConfiguration = new QBConfiguration();
       //int enumappstatusActive = 0;
       int enumappstatusTrail = 0;
       int enumappstatusDeactive = 0;
       string EncryptedDate = string.Empty;
       string DecryptDate = string.Empty;
       string Encryptetrialappmode = string.Empty;
       string EncryptExpDuration = string.Empty;
       string strTrailDays = string.Empty;

       private void firstTime()
       {
          string lstrappstusmode = string.Empty;
         
          enumappstatusTrail = (int)appStatus.Trail;
          DateTime dt = DateTime.Now;
          string onlyDate = dt.ToShortDateString(); // get only date not time
          lstrappstusmode =lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("appStatus");

          if (string.IsNullOrEmpty(lstrappstusmode))
              lobjQBConfiguration.SaveLabelFilePathSettings(this.Encrypt(enumappstatusTrail.ToString()), "appStatus");
                 

           //save Install Date and use Date
          //using  AES Algorithm
          EncryptedDate = this.Encrypt(onlyDate);

          lobjQBConfiguration.SaveLabelFilePathSettings(EncryptedDate, "installDate");
          lobjQBConfiguration.SaveLabelFilePathSettings(EncryptedDate, "useDate");

           //set initially app mode 0 for trial version for activated version set it to 1
          //Encryptetrialappmode = this.Encrypt("0");
          //lobjQBConfiguration.SaveLabelFilePathSettings(Encryptetrialappmode, "appMode");

         //set Trial period duration initially
          strTrailDays = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("TrialPeriod");
          if (string.IsNullOrEmpty(strTrailDays))
          {
              EncryptExpDuration = this.Encrypt("14");
              lobjQBConfiguration.SaveLabelFilePathSettings(EncryptExpDuration, "TrialPeriod");
          }
          else
          {
              //EncryptExpDuration = this.Encrypt(strTrailDays);
              lobjQBConfiguration.SaveLabelFilePathSettings(strTrailDays, "TrialPeriod"); 
          }
          

                  
       }

       private String checkfirstDate()
       {
           string DecryptFirstDate = string.Empty;
           string lstrFirstDate = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("installDate");
           DecryptFirstDate = this.Decrypt(lstrFirstDate);
           if (string.IsNullOrEmpty(DecryptFirstDate))
               return "First";
           else
               return DecryptFirstDate;
       }

       public String daysDifference()
       {
           int lntExpiryDuration = Convert.ToInt32(this.Decrypt(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("TrialPeriod")));
           // get present date from system
           DateTime dt = DateTime.Now;
           string today = dt.ToShortDateString();
           DateTime presentDate = Convert.ToDateTime(today);

           // get instalation date
           string lstrFirstDate = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("installDate");
           DateTime installationDate = Convert.ToDateTime(this.Decrypt(lstrFirstDate));

           TimeSpan diff = presentDate.Subtract(installationDate);
           int totaldays = (int)diff.TotalDays;

           // special check if user chenge date in system
           string usd = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("useDate");
           DateTime lastUse = Convert.ToDateTime(this.Decrypt(usd));
           TimeSpan diff1 = presentDate.Subtract(lastUse); //first.Subtract(second);
           int useBetween = (int)diff1.TotalDays;

           // put next use day in config file
           lobjQBConfiguration.SaveLabelFilePathSettings("useDate", this.Encrypt(today));

           if (useBetween >= 0)
           {
               if (totaldays < 0)
                   return "Error"; // if user change date in system like date set before installation
               else if (totaldays >= 0 && totaldays <= lntExpiryDuration)
                   if ((lntExpiryDuration - totaldays) > 0)
                       return Convert.ToString(lntExpiryDuration - totaldays); //how many days remaining
                   else
                       return "Expired"; //Expired

               else
                   return "Expired"; //Expired
           }
           else
               return "Error"; // if user change date in system
       }



       public String GetRemainingdays()
       {

           int lntExpiryDuration = Convert.ToInt32(this.Decrypt(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("TrialPeriod")));
           // get present date from system
           DateTime dt = DateTime.Now;
           string today = dt.ToShortDateString();
           DateTime presentDate = Convert.ToDateTime(today);

           // get instalation date
           string lstrFirstDate = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("installDate");
           DateTime installationDate = Convert.ToDateTime(this.Decrypt(lstrFirstDate));

           TimeSpan diff = presentDate.Subtract(installationDate);
           int totaldays = (int)diff.TotalDays;

           // special check if user chenge date in system
           string usd = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("useDate");
           DateTime lastUse = Convert.ToDateTime(this.Decrypt(usd));
           TimeSpan diff1 = presentDate.Subtract(lastUse); //first.Subtract(second);
           int useBetween = (int)diff1.TotalDays;

           // put next use day in config file
           lobjQBConfiguration.SaveLabelFilePathSettings("useDate", this.Encrypt(today));

           if (useBetween >= 0)
           {
               if (totaldays >= 0 && totaldays <= lntExpiryDuration)
                   //if ((lntExpiryDuration - totaldays) > 0)
                       if ((lntExpiryDuration - totaldays) > 0)
                           return Convert.ToString(lntExpiryDuration - totaldays); //how many days remaining
                       else
                           return "Expired";

                   else
                       return "Expired";
               //else
               //    return "Expired"; //Expired
           }
           else
               return string.Empty;
           
       }

       private void blackList()
       {
           //save black date as true
           lobjQBConfiguration.SaveLabelFilePathSettings("BlackDate", this.Encrypt("1"));

       }

       private bool blackListCheck()
       {

           string lstrBlacklistDate = lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("BlackDate");
           if (string.IsNullOrEmpty(this.Decrypt(lstrBlacklistDate)))
               return false; //No
           else
               return true;//Yes
       }


       public Tuple<string,string,int> ProductTrial()
       {
           string lstrtrialmessage = string.Empty;
           string lstrappmode = string.Empty;
           string status = string.Empty;
           int appactivestatus=0;
           string activeappstatus = string.Empty;
          
           bool block = blackListCheck();
           if (block == false)
           {
               
               //lstrappmode = this.Decrypt(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("appMode"));

               //check appmode is set to 1 to activate product
              // if (lstrappmode.Trim() == "1")
               //{
                  // enumappstatusActive = (int)appStatus.Active;
                  // lobjQBConfiguration.SaveLabelFilePathSettings(this.Encrypt(enumappstatusActive.ToString()), "appMode");
                   activeappstatus = this.Decrypt(lobjQBConfiguration.GetQuickBooksDataAccessConfigSettings("appStatus"));
                   if (activeappstatus == "2")
                   {
                       appactivestatus = (int)appStatus.Active;
                   }
              // }

               string chinstall = checkfirstDate();
               if (chinstall == "First")
               {
                   firstTime();// installation date
                   //lstrtrialmessage = "You are using trial Pack!";
                  // status = daysDifference();
                   status = GetRemainingdays();
               }
               else
               {
                   status = daysDifference();
                   if (status == "Error")
                   {
                       blackList();
                       lstrtrialmessage = "Application Can't be loaded, Unauthorized Date Interrupt Occurred! Without activation it can't run! ";

                   }
                   else if (status == "Expired")
                   {
                       lstrtrialmessage = "The trial version is now expired!.Please Contact Accuware";
                     
                        enumappstatusDeactive = (int)appStatus.Deactive;
                        lobjQBConfiguration.SaveLabelFilePathSettings(this.Encrypt(enumappstatusDeactive.ToString()), "appStatus");

                   }
                   //else // execute with how many day remaining
                   //{
                   //    lstrtrialmessage = "You are using trial Pack, you have " + status + " days left to Activate!";

                   //}
               }
           }
           else
           {
               lstrtrialmessage = "Application Can't be loaded, Unauthorized Date Interrupt Occurred! Without activation it can't run!";
           }
           //return lstrtrialmessage;
           return new Tuple<string, string,int>(status, lstrtrialmessage, appactivestatus); 
       }


       //AES Encryption
       private string Encrypt(string clearText)
       {
           string EncryptionKey = "MAKV2SPBNI99212";
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

       //AES Decryption
       private string Decrypt(string cipherText)
       {
           string EncryptionKey = "MAKV2SPBNI99212";
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
      
       public enum appStatus
       {
           Trail=1,
           Active=2,
           Deactive=3
       }

       public class clsDateDifference
       {

           public string DaysRemaining { get; set; }
           public string DateChangeError { get; set; }
          
       
       }

    }
}
