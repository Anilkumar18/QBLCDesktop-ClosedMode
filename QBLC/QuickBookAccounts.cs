using System;
using System.Collections.Generic;
using System.Text;

namespace LabelConnector
{
    public class QuickBooksAccount
    {
        string strUserName = string.Empty;
        string strPassword = string.Empty;
        string strCompanyFile = string.Empty;
        string strFileOpenMode = string.Empty;
        string strQBVersion = string.Empty;
        string strConnectionType = string.Empty;
        string strUnattendedModePref = string.Empty;
        string strPersonalDataPref = string.Empty;
        string strQBCountry = string.Empty;
        string strQBMajorVersion = string.Empty;
        string strQBMinorVersion = string.Empty;
        public QuickBooksAccount()
        {
        }

        public string UserName
        {
            get
            {
                return strUserName;
            }
            set
            {
                strUserName = value;
            }
        }

        public string Password
        {
            get
            {
                return strPassword;
            }
            set
            {
                strPassword = value;
            }
        }

        public string CompanyFile
        {
            get
            {
                return strCompanyFile;
            }
            set
            {
                strCompanyFile = value;
            }
        }

        public string FileOpenMode
        {
            get
            {
                return strFileOpenMode;
            }
            set
            {
                strFileOpenMode = value;
            }
        }

        public string QBVersion
        {
            get
            {
                return strQBVersion;
            }
            set
            {
                strQBVersion = value;
            }
        }

        public string ConnectionType
        {
            get
            {
                return strConnectionType;
            }
            set
            {
                strConnectionType = value;
            }
        }

        public string UnattendedModePref
        {
            get
            {
                return strUnattendedModePref;
            }
            set
            {
                strUnattendedModePref = value;
            }
        }

        public string PersonalDataPref
        {
            get
            {
                return strPersonalDataPref;
            }
            set
            {
                strPersonalDataPref = value;
            }
        }


        public string QBCountry
        {
            get
            {
                return strQBCountry;
            }
            set
            {
                strQBCountry = value;
            }
        }


        public string QBMajorVersion
        {
            get
            {
                return strQBMajorVersion;
            }
            set
            {
                strQBMajorVersion=value;
            }
        }


        public string QBMinorVersion
        {
            get
            {
                return strQBMinorVersion;
            }
            set
            {
                strQBMinorVersion = value;
            }
        }

    }
}
