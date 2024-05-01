using InventoryApplication.DataAccess;
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
    /// Interaction logic for SubReportPageView.xaml
    /// </summary>
    public partial class SubReportPageView : UserControl
    {
        public SearchNewMaterial MySearchNewMaterial { get; set; }
        public InventoryApplicationContext ctx;
        public SubReportPageView(SearchNewMaterial vm)
        {
            InitializeComponent();
            MySearchNewMaterial = vm;
            ctx = new InventoryApplicationContext();
            this.DataContext = MySearchNewMaterial.mysearchnewmaterialviewmodel;
        }
        private void OpenDetailsofMaterialBuying(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.OpenDetailsofMaterialBuyingInReport(sender, e);
        }
        private void closeDitailsofofMaterialBuyingDialog(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.closeDitailsofofMaterialBuyingDialogInReport(sender, e);
        }
        private void OpenMoreDitailsofofMaterialBuyingDialog(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.OpenMoreDitailsofofMaterialBuyingDialogInReport(sender, e);
        }
        private void closeMoreDitailsofofMaterialBuyingDialog(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.closeMoreDitailsofofMaterialBuyingDialogInReport(sender, e);
        }
        private void OpenExitMaterialDialogParticular(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.OpenExitMaterialDialogParticular(sender, e);
        }
        private void PersonelKeyUpreport(object sender, KeyEventArgs e)
        {
            UnitOfWork uni = new UnitOfWork(ctx);
            PersonelKeyUpnamereport.IsDropDownOpen = true;
            string tt = ((ComboBox)sender).Text;
            if (((ComboBox)sender).Text == "")
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.NameofPersonels0 = new System.Collections.ObjectModel.ObservableCollection<Models.Peronel>(uni.MyPersonRep.GetAll());
                ((ComboBox)sender).SelectedValue = null;
                ((ComboBox)sender).SelectedItem = null;
                ((ComboBox)sender).Text = "";
            }
            else
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.NameofPersonels0 = new System.Collections.ObjectModel.ObservableCollection<Models.Peronel>(uni.MyPersonRep.find(x => x.FirstName.Contains(tt) || x.LastName.Contains(tt)));
            }
        }

        private void PersonelKeyUpnamereport_GotFocus(object sender, RoutedEventArgs e)
        {
            PersonelKeyUpnamereport.IsDropDownOpen = true;
        }

        private void PersonelKeyUpnamereport_KeyDown(object sender, KeyEventArgs e)
        {
            PersonelKeyUpnamereport.IsDropDownOpen = true;
        }

    }
}
