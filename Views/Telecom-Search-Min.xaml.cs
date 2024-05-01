using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryApplication.Views
{
    /// <summary>
    /// Interaction logic for Telecom_Search_Min.xaml
    /// </summary>
    public partial class Telecom_Search_Min : UserControl
    {
        public AuthenticatedUserView myauthview { get; set; }
        public Telecom_Search_Min(AuthenticatedUserView vm)
        {
            InitializeComponent();
            myauthview = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myauthview.myregisterview.MyViewModel.getNameofStoresandcompanies();
            AuthenticatedUserView.trans2.SelectedIndex = 1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myauthview.mysearchview.mysearchnewmaterialviewmodel.getNameofStoresandcompanies();
            myauthview.mysearchview.mysearchnewmaterialviewmodel.getnameofMaterialsGrouped(null);
            AuthenticatedUserView.trans2.SelectedIndex = 2;

        }

       
    }
}
