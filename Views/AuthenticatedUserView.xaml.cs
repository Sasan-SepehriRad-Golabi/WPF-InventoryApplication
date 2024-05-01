using InventoryApplication.ViewModels;
using InventoryApplication.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryApplication.Views
{
    /// <summary>
    /// Interaction logic for AuthenticatedUserView.xaml
    /// </summary>
    public partial class AuthenticatedUserView : UserControl
    {
        public static MaterialDesignThemes.Wpf.Transitions.Transitioner trans2 { get; set; }
        public SearchNewMaterial mysearchview { get; set; }
        public RegisterNewMaterialView myregisterview { get; set; }
        public Telecom_Search_Min myfirstpageauthenticated { get; set; }
        bool StateClosed = true;
        public AuthenticatedUserView()
        {
            InitializeComponent();
            trans2 = MainTransitioner1;
            mysearchview = new SearchNewMaterial(this);
            myregisterview = new RegisterNewMaterialView(this);
            myfirstpageauthenticated = new Telecom_Search_Min(this);
            trans2.Items.Add(myfirstpageauthenticated);
            trans2.Items.Add(myregisterview);
            trans2.Items.Add(mysearchview);
            MyExitOfApplication = new ExitOfApplication(this);
            this.DataContext = this;
        }
        public void exitofapp()
        {
            Application.Current.Shutdown();
        }
        public ICommand MyExitOfApplication { get; set; }
        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            if (StateClosed)
            {
              
                Storyboard sb = this.FindResource("OpenMenu") as Storyboard;
                sb.Begin();
            }
            else
            {
               
                Storyboard sb = this.FindResource("CloseMenu") as Storyboard;
                sb.Begin();
            }

            StateClosed = !StateClosed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            trans2.SelectedIndex = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (myregisterview.MyViewModel.NameOFStores, myregisterview.MyViewModel.ListofCompanies) = myregisterview.MyViewModel.getNameofStoresandcompanies();
            myregisterview.MyViewModel.NameofPersonels = new ObservableCollection<Models.Peronel>(myregisterview.MyViewModel.getNameofPersonels());
            trans2.SelectedIndex = 1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            (mysearchview.mysearchnewmaterialviewmodel.NameOFStores, mysearchview.mysearchnewmaterialviewmodel.ListofCompanies) = mysearchview.mysearchnewmaterialviewmodel.getNameofStoresandcompanies();
            mysearchview.mysearchnewmaterialviewmodel.NamesofMaterials = mysearchview.mysearchnewmaterialviewmodel.getnameofMaterialsGrouped(null);
            trans2.SelectedIndex = 2;
        }

       

        private void MainTransitioner1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (trans2?.SelectedIndex == 1)
            {
                (mysearchview.mysearchnewmaterialviewmodel.NameOFStores, mysearchview.mysearchnewmaterialviewmodel.ListofCompanies) = mysearchview.mysearchnewmaterialviewmodel.getNameofStoresandcompanies();
            }
            else if (trans2?.SelectedIndex == 2)
            {
                (myregisterview.MyViewModel.NameOFStores, myregisterview.MyViewModel.ListofCompanies) = myregisterview.MyViewModel.getNameofStoresandcompanies();
            }
            else
            {
                
            }
        }
    }
}
