using InventoryApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.Models
{
    public class Receipt:INotifyPropertyChanged,IDataErrorInfo
    {
        InventoryApplicationContext ctx;
        public Receipt()
        {
             ctx = new InventoryApplicationContext();
        }
        private int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
              
                _Id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id"));
            }
        }
        private string _ReceiptNumber;
        public string ReceiptNumber
        {
            get { return _ReceiptNumber; }
            set { 
                _ReceiptNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceiptNumber"));
            }
        }
        private bool _ProperReceipt1;
        public bool ProperReceipt1
        {
            get { return _ProperReceipt1; }
            set { _ProperReceipt1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperReceipt1")); }
        }
        private bool _ProperReceipt2;
        public bool ProperReceipt2
        {
            get { return _ProperReceipt2; }
            set { _ProperReceipt2 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperReceipt2")); }
        }
        private bool _ProperReceipt3;
        public bool ProperReceipt3
        {
            get { return _ProperReceipt3; }
            set { _ProperReceipt3 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperReceipt3")); }
        }
        private bool _ProperReceipt4;
        public bool ProperReceipt4
        {
            get { return _ProperReceipt4; }
            set { _ProperReceipt4 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperReceipt4")); }
        }
        private bool _ProperReceipt5;
        public bool ProperReceipt5
        {
            get { return _ProperReceipt5; }
            set { _ProperReceipt5 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperReceipt5")); }
        }
        private string _CostValue;
        public string CostValue
        {
            get { return _CostValue; }
            set { _CostValue = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CostValue")); }
        }

        private int _IsPayed;

        public int IsPayed
        {
            get { return _IsPayed; }
            set { _IsPayed = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsPayed")); }
        }

        private string _Issuer;
        public string Issuer
        {
            get { return _Issuer; }
            set {
                _Issuer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Issuer"));

            }
        }

        private int _TheProviderCompanyid;
        public int TheProviderCompanyid
        {
            get { return _TheProviderCompanyid; }
            set
            {
                _TheProviderCompanyid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TheProviderCompanyid")); 
            }
        }

        private string _DateofIssue;

        public string DateofIssue
        {
            get { return _DateofIssue; }
            set 
            {
                _DateofIssue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateofIssue")); }
        }
        
       public string Error { get { return null; } }

        public string this[string columnName]
        {
            get
            {
                string err="";
                switch (columnName)
                {
                    case "ReceiptNumber":
                        if (string.IsNullOrEmpty(ReceiptNumber))
                        {
                            err = "";
                            ProperReceipt1 = false;
                        }
                        else
                        {
                            ProperReceipt1 = true;
                            int res;
                            if(!int.TryParse(ReceiptNumber,out res))
                            {
                                err = "فرمت صحیح نیست";
                                ProperReceipt1 = false;
                            }
                            else
                            {
                                UnitOfWork myunit = new UnitOfWork(ctx);
                                ProperReceipt5 = true;
                                ProperReceipt1 = true;
                                int numofpreviousreceipts = myunit.MyReceiptsRep.find(x => x.ReceiptNumber == ReceiptNumber).Count();
                                if (numofpreviousreceipts <= 0)
                                {
                                    err = "شماره فاکتور جدید است. ";
                                    ProperReceipt5 = false;
                                    ProperReceipt1 = true;
                                }
                                else if (numofpreviousreceipts>1)
                                {
                                    err = "شماره فاکتور تکراری است. ";
                                    ProperReceipt5 = false;
                                    ProperReceipt1 = false;
                                }
                                else
                                {
                                    ProperReceipt5 = true;
                                    ProperReceipt1 = true;
                                }
                            }
                        }
                        break;
                    case "CostValue":
                        if (string.IsNullOrEmpty(CostValue))
                        {
                            err = "";
                            ProperReceipt2 = false;
                        }
                        else
                        {
                            ProperReceipt2 = true;
                            int res;
                            if (!int.TryParse(CostValue, out res))
                            {
                                err = "فرمت صحیح نیست";
                                ProperReceipt1 = false;
                            }
                        }
                        break;
                    case "Issuer":
                        if (string.IsNullOrEmpty(Issuer))
                        {
                            err = "";
                            ProperReceipt3 = false;
                        }
                        else
                        {
                            ProperReceipt3 = true;
                        }
                        break; 
                             case "DateofIssue":
                        if (string.IsNullOrEmpty(DateofIssue))
                        {
                            err = "";
                            ProperReceipt4 = false;
                        }
                        else
                        {
                            ProperReceipt4 = true;
                        }
                        break;
                    default:
                        break;
                }
                return err;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
