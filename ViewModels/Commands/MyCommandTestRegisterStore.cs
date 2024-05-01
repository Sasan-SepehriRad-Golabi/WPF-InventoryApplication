using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    public class MyCommandTestRegisterStore : ICommand
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
        public RegisterNewMaterialViewModel Myviewmodel { get; set; }
        public MyCommandTestRegisterStore(RegisterNewMaterialViewModel vm)
        {
            Myviewmodel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return Myviewmodel.CanExecuteCommandTestRegisterStore(parameter); ;
        }

        public void Execute(object parameter)
        {
            Myviewmodel.ExecuteCommandTestRegisterStore(parameter);
        }
    }
}
