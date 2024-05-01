using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    public class CancelDialogPersonel : ICommand
    {
        public RegisterNewMaterialViewModel myviewmodel { get; set; }
        public CancelDialogPersonel(RegisterNewMaterialViewModel vm)
        {
            myviewmodel = vm;
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
            myviewmodel.executeCancelbuttonpersonel();
        }
    }
}
