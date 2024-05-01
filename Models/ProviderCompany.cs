using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.Models
{
    public class ProviderCompany:INotifyPropertyChanged,IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return NameofCompany;
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
        private bool _ProperProviderCompany0;

        public bool ProperProviderCompany0
        {
            get { return _ProperProviderCompany0; }
            set { _ProperProviderCompany0 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperProviderCompany0")); }
        }
        private bool _ProperProviderCompany1;

        public bool ProperProviderCompany1
        {
            get { return _ProperProviderCompany1; }
            set { _ProperProviderCompany1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperProviderCompany1")); }
        }
        private bool _ProperProviderCompany2;

        public bool ProperProviderCompany2
        {
            get { return _ProperProviderCompany2; }
            set { _ProperProviderCompany2 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperProviderCompany2")); }
        }
        private bool _ProperProviderCompany3;

        public bool ProperProviderCompany3
        {
            get { return _ProperProviderCompany3; }
            set { _ProperProviderCompany3 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperProviderCompany3")); }
        }

        private string _NameofCompany;
        public string NameofCompany
        {
            get { return _NameofCompany; }
            set { _NameofCompany = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameofCompany")); }
        }

        private string _LocationAddress;

        public string LocationAddress
        {
            get { return _LocationAddress; }
            set { _LocationAddress = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LocationAddress")); }
        }

        private string _CallNumber;

        public string CallNumber
        {
            get { return _CallNumber; }
            set { _CallNumber = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CallNumber")); }
        }

        private string _FaxNumber;

        public string FaxNumber
        {
            get { return _FaxNumber; }
            set { _FaxNumber = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FaxNumber")); }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email")); }
        }
        private int _Evaluation;

        public int Evaluation
        {
            get { return _Evaluation; }
            set { _Evaluation = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Evaluation")); }
        }

        public string Error { get { return null; } }

        public string this[string columnName]
        {
            get
            {
                string err = "";
                switch (columnName)
                {
                    
                    case "NameofCompany":
                        if (string.IsNullOrEmpty(NameofCompany))
                        {
                            err = "";
                            ProperProviderCompany1 = false;
                        }
                        else
                        {
                            ProperProviderCompany1 = true;
                        }
                            break;
                    case "LocationAddress":
                        if (string.IsNullOrEmpty(LocationAddress))
                        {
                            err = "";
                            ProperProviderCompany2 = false;
                        }
                        else
                        {
                            ProperProviderCompany2 = true;
                        }
                        break;
                    case "CallNumber":
                        if (string.IsNullOrEmpty(CallNumber))
                        {
                            err = "";
                            ProperProviderCompany3 = false;
                        }
                        else
                        {
                            int calnumber;
                            ProperProviderCompany3 = true;
                            if (!int.TryParse(CallNumber,out calnumber))
                            {
                                err = $"فرمت صحیح نیست";
                                ProperProviderCompany3 = false;
                            }
                        }
                        break;
                    default:
                        err = "";
                        break;


                }
                return err;
            }
        }
    }
}
