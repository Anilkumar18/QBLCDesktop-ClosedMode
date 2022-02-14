using Interop.QBFC13;
using QBLC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace LabelConnector
{
   public  class ModGlobal
    {
        public static string DataStamp { get; set; }
        public static string TimeStamp { get; set; }
        public static Double DateShift { get; set; }

        public static ArrayList salesorder = new ArrayList();
        
        public static QBSessionManager QBGlobalSessionManager = null;

        public static string ProcessorID()
        {
            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorID"].ToString();
            }
            return id;
    }
}
}
