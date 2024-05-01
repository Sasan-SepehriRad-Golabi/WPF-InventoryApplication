using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    public class AddStoreFromSearch : ICommand
    {
        public SearchNewMaterialViewModel Mysearchveiwmode { get; set; }
        public AddStoreFromSearch(SearchNewMaterialViewModel vm)
        {
            Mysearchveiwmode = vm;
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
            return Mysearchveiwmode.CanExecuteAddStoreFromSearch(parameter);
        }

        public void Execute(object parameter)
        {
            Mysearchveiwmode.ExecuteAddStoreFromSearch();
        }
    }
}
