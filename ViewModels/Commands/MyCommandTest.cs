using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    public class MyCommandTest : ICommand
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

        public bool CanExecute(object parameter)
        {
            return Myviewmodel.CanExecuteCommandTest(parameter);
        }
        public RegisterNewMaterialViewModel Myviewmodel { get; set; }
        public MyCommandTest(RegisterNewMaterialViewModel vm)
        {
            Myviewmodel = vm;
        }

        public void Execute(object parameter)
        {
            Myviewmodel.ExecuteCommandTest(parameter);
        }
    }
}
