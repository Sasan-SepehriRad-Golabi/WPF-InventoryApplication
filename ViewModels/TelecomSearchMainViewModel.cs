using InventoryApplication.DataAccess;
using InventoryApplication.Models;
using InventoryApplication.ViewModels.Commands;
using InventoryApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InventoryApplication.ViewModels
{
    public class TelecomSearchMainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ChangeListVisibility { get; set; }
        private System.Windows.Visibility _ListVisiblity;
        public ICommand OpenSearchWindow { get; set; }
        public ICommand openregisterwindow { get; set; }
        public System.Windows.Visibility ListVisiblity
        {
            get
            {
                return _ListVisiblity;
            }
            set
            {
                _ListVisiblity = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ListVisiblity"));
            }
        }
        public void setlistvisibility(object parameter)
        {
            Debug.WriteLine("test");
            Debug.WriteLine(parameter);
            if ((System.Windows.Visibility)parameter == System.Windows.Visibility.Visible)
            {
                ListVisiblity = System.Windows.Visibility.Hidden;
            }
            else
            {
                ListVisiblity = System.Windows.Visibility.Visible;
            }
        }
        public TelecomSearchMainViewModel()
        {
            ChangeListVisibility = new ChangeListVisibility(this);
            openregisterwindow = new OpenRegisterWindowCommand(this);
            OpenSearchWindow = new OpenSearchWindowCommand(this);

        }
        private TextBlock _MySelectedItem;
        public TextBlock MySelectedItem
        {
            get
            {
                return _MySelectedItem;
            }
            set
            {
                _MySelectedItem = value;
                PropertyChanged(this,new PropertyChangedEventArgs("MySelectedItem"));
            }
        }
        public void ShowReport(string NameofModel)
        {

        }    
    }
}
