using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    public class MyCommandTestPersonel : ICommand
    {
        public MyCommandTestPersonel(RegisterNewMaterialViewModel vm)
        {
            myregisterveiwmode = vm;
        }
        public RegisterNewMaterialViewModel myregisterveiwmode { get; set; }
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
            return myregisterveiwmode.CanExecuteMyCommandTestReceipt(parameter);
        }

        public void Execute(object parameter)
        {
            myregisterveiwmode.MyCommandTestPersonel(parameter);
        }
    }
}
