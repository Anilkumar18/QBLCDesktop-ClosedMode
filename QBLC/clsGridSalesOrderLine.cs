using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelConnector
{
    public class clsGridSalesOrderLine
    {

        double _dblSalesOrderLineQuantity;
        string _strSalesOrderLineUnitOfMeasure;
        string _strSalesOrderLineItemRefFullName;
        string _strSalesOrderLineDesc;
        string _strSalesPrice;
        string _strSalesOrderLineTxnLineID;
        string _strOther1L;
        string _strOther2L;
        string _strclass;
        string _strAmount;
        string _strCost;
        string _strPONumber;
        string _strShipMethod;
        string _strSalesOrderCustomer;
        string _strsalesorderitemname;
        string _strMarkUpPrice;
        string _strCustomerPOLineNo;
        string _strSOOther2;
        string _CustNo;
        string _strManufacturerPartNumber;
        string _strSubItemof;

        public double SalesOrderLineQuantity
        {
            get
            {
                return _dblSalesOrderLineQuantity;
            }
            set
            {
                _dblSalesOrderLineQuantity = value;
            }
        }
        public string SubItemof
        {
            get
            {
                return _strSubItemof;
            }

            set
            {
                
                _strSubItemof = value.IndexOf(':') > -1 ? value.Substring(0, value.LastIndexOf(':')) : "";
            }
        }
        public string SalesOrderLineUnitOfMeasure
        {
            get
            {
                return _strSalesOrderLineUnitOfMeasure;
            }

            set
            {
                _strSalesOrderLineUnitOfMeasure = value == null ? "" : value;
            }
        }
        public string CustNo
        {
            get { return _CustNo; }
            set { _CustNo = value; }
        }

        public string SalesOrderLineItemRefFullName
        {
            get
            {
                return _strSalesOrderLineItemRefFullName;
            }
            set
            {
                _strSalesOrderLineItemRefFullName = value.Substring(value.LastIndexOf(':') + 1);
            }
        }
        public string SalesPrice
        {
            get
            {
                return _strSalesPrice;
            }
            set
            {
                _strSalesPrice = value;
            }
        }
        public string SalesOrderLineDesc
        {
            get
            {
                return _strSalesOrderLineDesc;
            }
            set
            {
                _strSalesOrderLineDesc = value;
            }
        }
        public string SalesOrderLineTxnLineID
        {
            get
            {
                return _strSalesOrderLineTxnLineID;
            }
            set
            {
                _strSalesOrderLineTxnLineID = value;
            }
        }
        public string GroupItemType
        {
            get; set;
        }
        public string Other1L
        {
            get
            {
                return _strOther1L;
            }
            set
            {
                _strOther1L = value;
            }
        }

        public string Other2L
        {
            get
            {
                return _strOther2L;
            }
            set
            {
                _strOther2L = value;
            }
        }

        public string Class
        {
            get { return _strclass; }
            set { _strclass = value; }
        }
        public string Amount
        {
            get
            {
                return _strAmount;
            }
            set
            {
                _strAmount = value;
            }

        }
        public string Cost
        {
            get { return _strCost; }
            set { _strCost = value; }
        }
        public string PONumber
        {
            get { return _strPONumber; }
            set { _strPONumber = value; }
        }
        public string SalesOrderShipMethod
        {
            get { return _strShipMethod; }
            set { _strShipMethod = value; }
        }
        public string SalesOrdrCustomer
        {
            get { return _strSalesOrderCustomer; }
            set { _strSalesOrderCustomer = value; }

        }
        public string SalesORderItemName
        {
            get { return _strsalesorderitemname; }
            set { _strsalesorderitemname = value; }
        }
        public string MarkUpPrice
        {
            get
            {
                return _strMarkUpPrice;
            }
            set
            {
                _strMarkUpPrice = value;
            }
        }
        public string CustomerPOLineNo
        {
            get { return _strCustomerPOLineNo; }
            set { _strCustomerPOLineNo = value; }
        }
        public string SOOther2
        {
            get { return _strSOOther2; }
            set { _strSOOther2 = value; }
        }
        public string MPN
        {
            get { return _strManufacturerPartNumber; }
            set { _strManufacturerPartNumber = value; }
        }
    }

    public class GetclassHeaderSalesOrder
    {
        string _TxnID;
        DateTime _dtTxnDate;
        string _strRefNumber;
        string _strCustomerRefFullName;
        string _strShipDate;
        string _strShipAddressAddr1;
        string _strFOB;

        public string TxnID
        {
            get
            {
                return _TxnID;
            }
            set
            {
                _TxnID = value;
            }
        }

        public DateTime TxnDate
        {
            get
            {
                return Convert.ToDateTime(_dtTxnDate.ToShortDateString());
            }

            set
            {
                _dtTxnDate = value;
            }
        }


        public string RefNumber
        {
            get
            {
                return _strRefNumber;
            }
            set
            {
                _strRefNumber = value;
            }
        }
        public string CustomerRefFullName
        {
            get
            {
                return _strCustomerRefFullName;
            }
            set
            {
                _strCustomerRefFullName = value;
            }
        }
        public string ShipAddressAddr1
        {
            get
            {
                return _strShipAddressAddr1;

            }
            set
            {
                _strShipAddressAddr1 = value;
            }
        }
        public string FOB
        {
            get
            {
                return _strFOB;
            }
            set
            {
                _strFOB = value;
            }
        }
        public string ShipDate
        {
            get { return _strShipDate; }
            set { _strShipDate = value; }

        }
    }

    public class clsEditedsalesorderLine
    {

        public int SalesOrderLineQuantityToPrint { get; set; }
        public string SalesOrderLineDesc { get; set; }
        public int SalesOrderLineQuantity { get; set; }
        public string Barcode { get; set; }
        public string labelName{get; set; }
        public string PrinterName { get; set; }
        public string lstrdecnumber { get; set; }
        public string lstrcarrier { get; set; }
        public string SetValuesForTransType { get; set; }
        public string SetTemplatewidth { get; set; }
        public string SetTemplateheight { get; set; }
        public string SalesPrice { get; set; }
        public string MarkUpPrice { get; set; }
        public string SalesOrderLineItemRefFullName { get; set; }
        public string SalesOrderLineQuantityonLabel { get; set; }
        public string OrderNumber { get; set; }
        public string SalesOrderLineTxnLineID { get; set; }
        public string GridSecondvalue { get; set; }
        public string CompanyName { get; set; }
        public DateTime GridFirstvalue { get; set; }
        public int EditedsalesorderLineCount { get; set; }
        public string SubItemof { get; set; }

    }


    public class clsItemLine
    {
        public string SalesOrderLineItemRefFullName { get; set; }
        
    }

}
