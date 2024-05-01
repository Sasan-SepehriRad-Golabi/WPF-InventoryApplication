using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.Models
{
    public class Material :INotifyPropertyChanged,IDataErrorInfo,ICloneable
    {
        public override string ToString()
        {
            return Name;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
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
        public int RefId { get; set; }
        private string _Name;
        public string Name
        {
            get 
            { 
                return _Name; 
            }
            set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
        private bool _ProperMaterial1;
        public bool ProperMaterial1
        {
            get { return _ProperMaterial1; }
            set { _ProperMaterial1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperMaterial1")); }
        }
        private bool _ProperMaterial2;
        public bool ProperMaterial2
        {
            get { return _ProperMaterial2; }
            set { _ProperMaterial2 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperMaterial2")); }
        }
        private bool _ProperMaterial3;
        public bool ProperMaterial3
        {
            get { return _ProperMaterial3; }
            set { _ProperMaterial3 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperMaterial3")); }
        }
        private bool _ProperMaterial4;
        public bool ProperMaterial4
        {
            get { return _ProperMaterial4; }
            set { _ProperMaterial4 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperMaterial4")); }
        }
        private bool _ProperMaterial5;
        public bool ProperMaterial5
        {
            get { return _ProperMaterial5; }
            set { _ProperMaterial5 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperMaterial5")); }
        }
        private bool _testProperMaterial;
        public bool testProperMaterial
        {
            get { return _testProperMaterial; }
            set { _testProperMaterial = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("testProperMaterial")); }
        }
        private bool _notifyuser;

        public bool notifyuser
        {
            get { return _notifyuser; }
            set { _notifyuser = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("notifyuser")); }
        }

        private string _DateofEntrancetoStore;

        public string DateofEntrancetoStore
        {
            get { return _DateofEntrancetoStore; }
            set
            {
             
                    _DateofEntrancetoStore = value;
              
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateofEntrancetoStore"));
            }
        }
        private string _TimeofEntrancetoStore;

        public string TimeofEntrancetoStore
        {
            get { return _TimeofEntrancetoStore; }
            set
            {
               
                    _TimeofEntrancetoStore = value;
            
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TimeofEntrancetoStore"));
            }
        }
        private string _DateofBuying;

        public string DateofBuying
        {
            get { return _DateofBuying; }
            set
            {
               
                    _DateofBuying = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateofBuying"));
            }
        }
        private string _TimeofBuying;

        public string TimeofBuying
        {
            get { return _TimeofBuying; }
            set
            {
              
                    _TimeofBuying = value;
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TimeofBuying"));
            }
        }
        private string _DateofExitofStore;

        public string DateofExitofStore
        {
            get { return _DateofExitofStore; }
            set
            {
                
                    _DateofExitofStore = value;
              
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateofExitofStore"));
            }
        }
        private string _TimeofExitofStore;

        public string TimeofExitofStore
        {
            get { return _TimeofExitofStore; }
            set
            {
              
                    _TimeofExitofStore = value;
              
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TimeofExitofStore"));
            }
        }
        private bool _IfUsed;

        public bool IfUsed
        {
            get { return _IfUsed; }
            set { _IfUsed = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IfUsed")); }
        }

        private string _MaterialGiverToUserSecondary;

        public string MaterialGiverToUserSecondary
        {
            get { return _MaterialGiverToUserSecondary; }
            set { _MaterialGiverToUserSecondary = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialGiverToUserSecondary")); }
        }
        private string _MaterialUser;

        public string MaterialUser
        {
            get { return _MaterialUser; }
            set { _MaterialUser = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialUser")); }
        }
        private int _MaterialUserRequestNumber;

        public int MaterialUserRequestNumber
        {
            get { return _MaterialUserRequestNumber; }
            set { _MaterialUserRequestNumber = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialUserRequestNumber")); }
        }

        private string _MaterialRequester;

        public string MaterialRequester
        {
            get { return _MaterialRequester; }
            set { _MaterialRequester = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialRequester")); }
        }
        private string _InstalledLocation;

        public string InstalledLocation
        {
            get { return _InstalledLocation; }
            set { _InstalledLocation = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InstalledLocation")); }
        }
        private string _DateofDelivertoUser;

        public string DateofDelivertoUser
        {
            get
            {
                return _DateofDelivertoUser;
            }
            set
            {
                _DateofDelivertoUser = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateofDelivertoUser"));
            }
        }
        private int _RemainedNumber;

        public int RemainedNumber
        {
            get
            {
                return _RemainedNumber;
            }
            set
            {
                _RemainedNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RemainedNumber"));
            }
        }
        private String _MinimumAcceptableDevices;

        public String MinimumAcceptableDevices
        {
            get
            {
                return _MinimumAcceptableDevices;
            }
            set
            {
                _MinimumAcceptableDevices = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinimumAcceptableDevices"));
            }
        }
        
        private String _NumberofMaterial;

        public String NumberofMaterial
        {
            get
            {
                return _NumberofMaterial;
            }
            set
            {
                _NumberofMaterial = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumberofMaterial"));
            }
        }
        private String _PrivateNumberofMaterial;

        public String PrivateNumberofMaterial
        {
            get
            {
                return _PrivateNumberofMaterial;
            }
            set
            {
                _PrivateNumberofMaterial = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PrivateNumberofMaterial"));
            }
        }
        private int _IsAccessory;

        public int IsAccessory
        {
            get
            {
                return _IsAccessory;
            }
            set
            {
                _IsAccessory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsAccessory"));
            }
        }

        private int _ICTSection;

        public int ICTSection
        {
            get
            {
                return _ICTSection;
            }
            set
            {
                _ICTSection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ICTSection"));
            }
        }

        private byte[] _MaterialImage;

        public byte[] MaterialImage
        {
            get
            {
                return _MaterialImage;
            }
            set
            {
                _MaterialImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialImage"));
            }
        }
        private string _MaterialReceiptnumber;
        public string MaterialReceiptnumber
        {
            get
            {
                return _MaterialReceiptnumber;
            }
            set
            {
                _MaterialReceiptnumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialReceiptnumber"));
            }
        }
        private string _ICT_Tag;
        public string ICT_Tag
        {
            get
            {
                return _ICT_Tag;
            }
            set
            {
                _ICT_Tag = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ICT_Tag"));
            }
        }
        private int _MaterialInventoryid;

        public int MaterialInventoryid
        {
            get 
            { 
                return _MaterialInventoryid; 
            }
            set
            {
                _MaterialInventoryid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialInventoryid"));
            }
        }

        private int _MaterialCompanyid;

        public int MaterialCompanyid
        {
            get { return _MaterialCompanyid; }
            set
            {
                _MaterialCompanyid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialCompanyid"));
            }
        }
        private string _MaterialBarCode;
        public string MaterialBarCode
        {
            get
            {
                return _MaterialBarCode;
            }
            set
            {
                _MaterialBarCode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialBarCode"));
            }
        }
        private string _MaterialGiverToUserMain;

        public string MaterialGiverToUserMain
        {
            get { return _MaterialGiverToUserMain; }
            set { _MaterialGiverToUserMain = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaterialGiverToUserMain")); }
        }
        private string _OtherDetails;

        public string OtherDetails
        {
            get { return _OtherDetails; }
            set { _OtherDetails = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OtherDetails")); }
        }

        public string Error { get { return null; } }

        public string this[string columnName]
        {
            get
            {
                string err = "";
                switch (columnName)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(Name)) { 
                        err="";
                            ProperMaterial1 = false;
                        }
                        else
                        {
                            ProperMaterial1 = true;
                        }
                        break;
                    case "DateofBuying":
                        if (string.IsNullOrEmpty(DateofBuying))
                        {
                            err = "";
                            ProperMaterial2 = false;
                        }
                        else
                        {
                            ProperMaterial2 = true;
                        }
                        break;
                    case "MaterialRequester":
                        if (string.IsNullOrEmpty(MaterialRequester))
                        {
                            err = "";
                            ProperMaterial3 = false;
                        }
                        else
                        {
                            ProperMaterial3 = true;
                        }
                        break; 
                    case "MinimumAcceptableDevices":
                        if (string.IsNullOrEmpty(MinimumAcceptableDevices))
                        {
                            err = "";
                            ProperMaterial4 = false;
                        }
                        else
                        {
                            ProperMaterial4 = true;
                            int res;
                            if (!int.TryParse(MinimumAcceptableDevices,out res))
                            {
                                err = "فرمت وارد شده صحیح نیست";
                                ProperMaterial4 = false;
                            }
                        }
                        break;
                    case "MaterialReceiptnumber":
                        if (string.IsNullOrEmpty(MaterialReceiptnumber))
                        {
                            err = "";
                        }
                        else
                        {
                            int res;
                            if (!int.TryParse(MaterialReceiptnumber, out res))
                            {
                                err = "فرمت وارد شده صحیح نیست";
                            }
                        }
                        break;
                    case "NumberofMaterial":
                        if (string.IsNullOrEmpty(NumberofMaterial))
                        {
                            err = "";
                            ProperMaterial5 = false;
                        }
                        else
                        {
                            ProperMaterial5 = true;
                            int res;
                            if (!int.TryParse(NumberofMaterial, out res) || res<=0)
                            {
                                err = "فرمت وارد شده صحیح نیست";
                                ProperMaterial5 = false;
                            }
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
