using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace InventoryApplication.Models
{
    public class Peronel:INotifyPropertyChanged,IDataErrorInfo
    {
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        
        private string _JobTitle;
        public string JobTitle
        {
            get { return _JobTitle; }
            set { _JobTitle = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("JobTitle")); }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstName")); }
        }
        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName")); }
        }
        private string _PersonelyNumber;
        public string PersonelyNumber
        {
            get { return _PersonelyNumber; }
            set { _PersonelyNumber = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PersonelyNumber")); }
        }
        private string _Company;
        public string Company
        {
            get { return _Company; }
            set { _Company = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Company")); }
        }
        private string _Department;
        public string Department
        {
            get { return _Department; }
            set { _Department = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Department")); }
        }
        private string _DateOfGettingHired;
        public string DateOfGettingHired
        {
            get { return _DateOfGettingHired; }
            set { _DateOfGettingHired = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateOfGettingHired")); }
        }
        private string _TitleInReal;
        public string TitleInReal
        {
            get { return _TitleInReal; }
            set { _TitleInReal = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TitleInReal")); }
        }
        private string _OtherPoints;
        public string OtherPoints
        {
            get { return _OtherPoints; }
            set { _OtherPoints = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OtherPoints")); }
        }
        private byte[] _PersonelImage;

        public byte[] PersonelImage
        {
            get { return _PersonelImage; }
            set { _PersonelImage = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PersonelImage")); }
        }
        private bool _correctpersonelynumber;

        public bool correctpersonelynumber
        {
            get { return _correctpersonelynumber; }
            set { _correctpersonelynumber = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("correctpersonelynumber")); }
        } 

        public string Error { get { return null; } }

        public string this[string columnName]
        {
            get
            {
                string res="";
                switch (columnName)
                {
                    case "FirstName":
                        if(string.IsNullOrEmpty(FirstName) )
                        {
                            res = "حتما باید وارد شود";
                        }
                        else if (columnName.Length > 12)
                        {
                            res = "حداکثر 12 حرف قابل قبول است";
                        }
                        else
                        {
                            res = "";
                        }
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName))
                        {
                            res = "حتما باید وارد شود";
                        }
                        else if (columnName.Length > 12)
                        {
                            res = "حداکثر 12 حرف قابل قبول است";
                        }
                        else
                        {
                            res = "";
                        }
                        break;
                    case "PersonelyNumber":
                        correctpersonelynumber = true;
                        if (string.IsNullOrEmpty(PersonelyNumber))
                        {
                            res = "حتما باید وارد شود";
                            correctpersonelynumber = false;
                        }
                        else
                        {
                            correctpersonelynumber = true;
                            int rr;
                            if(int.TryParse(PersonelyNumber, out rr))
                            {
                                correctpersonelynumber = true;
                                res = "";
                            }
                            else
                            {
                                correctpersonelynumber = false;
                                res = "فرمت صحیح نیست";
                            }
                        }
                        break;
                    case "Company":
                        if (string.IsNullOrEmpty(Company))
                        {
                            res = "حتما باید وارد شود";
                        }
                        else if (Company.Length > 12)
                        {
                            res = "حداکثر 12 حرف قابل قبول است";
                        }
                        else
                        {
                            res = "";
                        }
                        break;
                    default:
                        break;
                }
                return res;
            }
        }
    }
}
