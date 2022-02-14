using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelConnector
{
    public class QuickBooksField
    {
        int lntItemColumnskey;
        string lstrItemFieldValue = string.Empty;
        string lstrItemFieldName = string.Empty;
        string lstrItemFieldinvName = string.Empty;
        string lstrItemFieldInvValue = string.Empty;



        public string ItemFieldValue
        {
            get {
                return lstrItemFieldValue;
            }
            set {
                lstrItemFieldValue = value;
            }
        }


        public int ItemFieldId
        {
            get
            {
                return lntItemColumnskey;
            }
            set
            {
                lntItemColumnskey = value;
            }
        }

        public string ItemFieldName
        {
            get
            {
                return lstrItemFieldName;
            }
            set
            {
                lstrItemFieldName = value;
            }
        }
        public string ItemFieldNameinvsingle
        {
            get
            {
                return lstrItemFieldinvName;
            }
            set
            {
                lstrItemFieldinvName = value;
            }
        }
        public string ItemFieldInvValue
        {
            get
            {
                return lstrItemFieldInvValue;
            }
            set
            {
                lstrItemFieldInvValue = value;
            }
        }

        public QuickBooksField(int Key, string Value)
        {

            ItemFieldId = Key;
            ItemFieldName = Value;

        }

        public QuickBooksField(string strKey, string Value)
        {

          
            ItemFieldName = strKey;
            ItemFieldValue = Value;

        }
        public QuickBooksField(string strKey, string Value,string newvalue)
        {


            ItemFieldNameinvsingle = strKey;
            ItemFieldInvValue = Value;

        }






    };
}
