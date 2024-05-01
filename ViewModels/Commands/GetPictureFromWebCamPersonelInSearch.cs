using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    class GetPictureFromWebCamPersonelInSearch:ICommand
    {
        public SearchNewMaterialViewModel mymodel { get; set; }
        public GetPictureFromWebCamPersonelInSearch(SearchNewMaterialViewModel vm)
        {
            mymodel = vm;
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
            mymodel.GetPictureFromWebCamPersonel();
        }
    }
}
