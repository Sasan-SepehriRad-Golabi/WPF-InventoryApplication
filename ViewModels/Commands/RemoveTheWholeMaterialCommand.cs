using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    public class RemoveTheWholeMaterialCommand : ICommand
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
        public SearchNewMaterialViewModel myviewmode { get; set; }
        public RemoveTheWholeMaterialCommand(SearchNewMaterialViewModel vm)
        {
            myviewmode = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
        }
    }
}
