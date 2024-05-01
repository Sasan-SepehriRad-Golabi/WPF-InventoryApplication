using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    class UserRegisterCommand : ICommand
    {
        public RegisterViewModel myRegisterViewModel { get; set; }

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
        public UserRegisterCommand(RegisterViewModel rvm)
        {
            myRegisterViewModel = rvm;
        }
        public bool CanExecute(object parameter)
        {
            return myRegisterViewModel.canExecutee(parameter);
        }

        public void Execute(object parameter)
        {
            myRegisterViewModel.Registerr(parameter);
        }
    }
}
