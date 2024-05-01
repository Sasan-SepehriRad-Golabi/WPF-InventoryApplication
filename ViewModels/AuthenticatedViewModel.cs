using InventoryApplication.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InventoryApplication.ViewModels
{
    public class AuthenticatedViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ExitOfApplication { get; set; }
        public AuthenticatedViewModel()
        {
            //ExitOfApplication = new ExitOfApplication(this);
        }
     
        public void exitofapp()
        {
            Application.Current.Shutdown();
        }
    }
}
