using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    public class OpenExitMaterialDialogParticularCommand : ICommand
    {
        public SearchNewMaterialViewModel mysearchviewmodel { get; set; }

        public OpenExitMaterialDialogParticularCommand(SearchNewMaterialViewModel vm)
        {
            mysearchviewmodel = vm;
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
            return mysearchviewmodel.CanExitMaterialParticular(parameter);
        }

        public void Execute(object parameter)
        {
             mysearchviewmodel.ExitMaterialParticular(parameter);
        }
    }
}
