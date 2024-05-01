using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    class OpenSearchWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public TelecomSearchMainViewModel _TelecomSearchMainViewModel { get; set; }
        public OpenSearchWindowCommand(TelecomSearchMainViewModel mm)
        {
            _TelecomSearchMainViewModel = mm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           
        }
    }
}
