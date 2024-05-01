using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    class ChangeListVisibility : ICommand
    {
        private TelecomSearchMainViewModel _TelecomSearchMainViewModel;
        public ChangeListVisibility(TelecomSearchMainViewModel mm)
        {
            _TelecomSearchMainViewModel = mm;
        }
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

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _TelecomSearchMainViewModel.setlistvisibility(parameter);
        }
    }
}
