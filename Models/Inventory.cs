using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.Models
{
    public class Inventory:INotifyPropertyChanged,IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return Name;
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
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set 
            {

                    _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name")); }
        }
        private bool _ProperInventory1;
        public bool ProperInventory1
        {
            get { return _ProperInventory1; }
            set { _ProperInventory1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperInventory1")); }
        }

        private bool _ProperInventory2;
        public bool ProperInventory2
        {
            get { return _ProperInventory2; }
            set { _ProperInventory2 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProperInventory2")); }
        }

        private string _Location;

        public string Location
        {
            get { return _Location; }
            set {  _Location = value;  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Location")); }
        }

        private string _Accessors;

        public string Accessors
        {
            get { return _Accessors; }
            set {  _Accessors = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Accessors")); }
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
                        if (string.IsNullOrEmpty(Name))
                        {
                            err = "";
                            ProperInventory1 = false;
                        }
                        else
                        {
                            ProperInventory1 = true;
                        }
                        break;
                    case "Accessors":
                        if (string.IsNullOrEmpty(Accessors))
                        {
                            err = "";
                            ProperInventory2 = false;
                        }
                        else
                        {
                            ProperInventory2 = true;
                        }
                        break;
                    default:
                        break;
                }
                return err;
            }
        }
    }
}
