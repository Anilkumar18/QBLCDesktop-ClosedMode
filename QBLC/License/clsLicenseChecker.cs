using System;
using System.Runtime.InteropServices;




namespace QBLC
{

    public enum license_state { LICENSE_UNKNOW = -3, LICENSE_ERROR_MAIN = -2, LICENSE_ERROR = -1, LICENSE_EXPIRED = 0, LICENSE_OK = 1,  LICENSE_FREE = 2, LICENSE_TRIAL = 3 };
    public enum trial_state { TRIAL = 0, ACTIVE = 1};

    static class clsLicenseChecker
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int GetLicenseInfo(bool flSilence);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int GetCheckInterval();

        const string dllPath = @"lnsMain.dll";
        //const string dllPath = @"D:\Users10\Dmytro_Klochko\Documents\Visual Studio 2015\Projects\license_special\lnsMain\Release\lnsMain.dll";
        //const string dllPath = @"C:\Accuware\QBLC_AIT - MergeCode\QBLC\bin\Release\lnsMain.dll";
        const string processInfoName = "getLicenseInfo";
        const string processIntervalName = "getCheckInterval";

        const int defaultCheckInterval = 900; //sec (15 min)
        private static bool isRun = false;
        
        public static int getCheckInterval()
        {
            IntPtr pDll = NativeMethods.LoadLibrary(dllPath);
            if (pDll == IntPtr.Zero)
                return defaultCheckInterval;

            IntPtr pProcessAddress = NativeMethods.GetProcAddress(pDll, processIntervalName);

            if (pProcessAddress == IntPtr.Zero)
            {
                NativeMethods.FreeLibrary(pDll);
                return defaultCheckInterval;
            }

            GetCheckInterval getCheckInterval = (GetCheckInterval)Marshal.GetDelegateForFunctionPointer(pProcessAddress, typeof(GetCheckInterval));

            int checkInterval = getCheckInterval();

            bool result = NativeMethods.FreeLibrary(pDll);
            if (!result)
                throw new Exception($"Library  [{dllPath}] not release.");

            return (checkInterval > 0)?(checkInterval) :(defaultCheckInterval);
        }


        public static license_state checkLicense(bool flSilence)
        {
          
            isRun = true;
            IntPtr pDll = NativeMethods.LoadLibrary(dllPath);
            if (pDll == IntPtr.Zero)
                throw new Exception($"Error loading dll [{dllPath}]");
            

            IntPtr pProcessAddress = NativeMethods.GetProcAddress(pDll, processInfoName);

           
           
            if (pProcessAddress == IntPtr.Zero)
            {
                NativeMethods.FreeLibrary(pDll);
                throw new Exception($"Failed to get process address[{processInfoName}]");
            }

            GetLicenseInfo getLicenseInfo = (GetLicenseInfo)Marshal.GetDelegateForFunctionPointer(pProcessAddress, typeof(GetLicenseInfo));
            license_state resultInt = (license_state)getLicenseInfo(flSilence);
           
         
            bool result = NativeMethods.FreeLibrary(pDll);
            if (!result)
                throw new Exception($"Library  [{dllPath}] not release.");

            isRun = false;
            return resultInt; //{ LICENSE_UNKNOW = -3, LICENSE_ERROR_MAIN = -2, LICENSE_ERROR = -1, LICENSE_EXPIRED = 0, LICENSE_OK = 1,  LICENSE_FREE = 2, LICENSE_TRIAL = 3}; 
        }

        public static bool IsRun()
        {
            return isRun;
        }
    }

    static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);
    }
}
