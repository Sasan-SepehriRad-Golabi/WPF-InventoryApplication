using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    public class GetPictureFromWebCamPersonel : ICommand
    {
        public RegisterNewMaterialViewModel mymodel { get; set; }
        public GetPictureFromWebCamPersonel(RegisterNewMaterialViewModel vm)
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
