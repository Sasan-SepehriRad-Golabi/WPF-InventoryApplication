using InventoryApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    class LoginCommand : ICommand
    {
        public LoginViewModel loginviewmodel { get; set; }
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
        public LoginCommand(LoginViewModel myLoginViewModel)
        {
            loginviewmodel = myLoginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return loginviewmodel.EnableLoginButton(parameter);
        }

        public void Execute(object parameter)
        {
            loginviewmodel.ExecuteLoginMethod(parameter);
        }
    }
}
