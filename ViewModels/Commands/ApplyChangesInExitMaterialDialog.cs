using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    public class ApplyChangesInExitMaterialDialog : ICommand
    {
        public SearchNewMaterialViewModel myviewmodel { get; set; }
        public ApplyChangesInExitMaterialDialog(SearchNewMaterialViewModel vm)
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
            return myviewmodel.MyApplyChangesInExitMaterialDialogCanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            myviewmodel.MyApplyChangesInExitMaterialDialogExecute(parameter);
        }
    }
}
