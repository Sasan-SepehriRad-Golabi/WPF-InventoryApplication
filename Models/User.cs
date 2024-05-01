using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication.Models
{
    public class User:INotifyPropertyChanged
    {
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
        public event PropertyChangedEventHandler PropertyChanged;
        private string _First_Name;

        public string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("First_Name")); }
        }

        private string _Last_Name;

        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Last_Name")); }
        }

        private string _User_Name;

        public string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("User_Name")); }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value;PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Password")); }
        }

        private bool _IsAdmin;

        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set { _IsAdmin = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsAdmin")); }
        }

        private int _Access_Level;

        public int Access_Level
        {
            get { return _Access_Level; }
            set { _Access_Level = value;PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Access_Level")); }
        }

    }
}
