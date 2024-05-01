using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    public class RegisterNewMaterialCommand : ICommand
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
        public RegisterNewMaterialViewModel MyViewModel { get; set; }

        public RegisterNewMaterialCommand(RegisterNewMaterialViewModel vm)
        {
            MyViewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return MyViewModel.CanRegisterNewMaterial(parameter);
        }

        public void Execute(object parameter)
        {
            MyViewModel.RegisterNewMaterial(parameter);
        }
    }
}
