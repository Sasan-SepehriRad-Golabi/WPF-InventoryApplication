using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InventoryApplication.ViewModels.Commands
{
    class GetPictureFromWebCam : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public RegisterNewMaterialViewModel MyViewModel { get; set; }

        public GetPictureFromWebCam(RegisterNewMaterialViewModel vm)
        {
            MyViewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MyViewModel.GetPictureFromWebCam();
        }
    }
}
