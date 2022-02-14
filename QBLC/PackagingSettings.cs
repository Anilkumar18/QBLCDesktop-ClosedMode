using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace LabelConnector
{
    public static class PackagingSettings
    {
        public static int QuantityToPrint()
        {
            int quantityToPrint = 0;
            string applicationDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            string packagingfile = "PackagingSettings.xml";
            string flToRead = applicationDomainPath + packagingfile;
            FileInfo fl = new FileInfo(flToRead);
            if (fl.Exists)
            {
                XmlTextReader xTr = new XmlTextReader(flToRead);
                XmlDocument xdc = new XmlDocument();
                xdc.Load(xTr);
                quantityToPrint = Convert.ToInt32(xdc.SelectSingleNode("PackagingSetting/Number").InnerText);
                xTr.Close();                
            }
            
            return quantityToPrint;
        }


       public static int GetPrintPageCount(int pintreccount, int pintgvrecordcount)
        {
            int totalpagescount = 0;
            double quotient = 0;
            double ceiling = 0;
            quotient = pintgvrecordcount / (double)pintreccount;
            ceiling = Math.Ceiling(quotient);
            totalpagescount = (int)ceiling;
            return totalpagescount;

        }

  
         


      
    }
}
