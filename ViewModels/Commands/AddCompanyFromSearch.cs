using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    public class AddCompanyFromSearch : ICommand
    {
        public SearchNewMaterialViewModel MySearchViewModel { get; set; }
        public AddCompanyFromSearch(SearchNewMaterialViewModel vm)
        {
            MySearchViewModel = vm;
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
            return MySearchViewModel.CanExecuteRegisterNewCompanyFromSearch(parameter);
        }

        public void Execute(object parameter)
        {
            MySearchViewModel.ExecuteRegisterNewCompanyFromSearch();
        }
    }
}
