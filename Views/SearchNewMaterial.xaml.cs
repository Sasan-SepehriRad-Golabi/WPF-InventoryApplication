using InventoryApplication.DataAccess;
using InventoryApplication.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryApplication.Views
{
    public partial class SearchNewMaterial : UserControl
    {
        public AuthenticatedUserView myauthenticatedUserView { get; set; }
        public SearchNewMaterialViewModel mysearchnewmaterialviewmodel { get; set; }
        public SubSearchPageView MySubSearchPageView { get; set; }
        public SubReportPageView MySubReportPageView { get; set; }
        public SearchNewMaterial(AuthenticatedUserView vv)
        {
            InitializeComponent();
            myauthenticatedUserView = vv;
            mysearchnewmaterialviewmodel = new SearchNewMaterialViewModel(this);
            MySubSearchPageView = new SubSearchPageView(this);
            MySubReportPageView = new SubReportPageView(this);
            subsearchtransitioner.Items.Add(MySubSearchPageView);
            subsearchtransitioner.Items.Add(MySubReportPageView);
            subsearchtransitioner.SelectedIndex = 0;
            this.DataContext = mysearchnewmaterialviewmodel;
        }
        private void changebetweensearchandreport(object sender, RoutedEventArgs e)
        {
            int indx = int.Parse(((Button)e.Source).Uid);
            switch (indx)
            {
                case 0:
                    underlinegrid.Margin = new Thickness(270, 0, 0, 0);
                    subsearchtransitioner.SelectedIndex = 0;
                    break;
                case 1:
                    underlinegrid.Margin = new Thickness(400, 0, 0, 0);
                    subsearchtransitioner.SelectedIndex = 1;
                    break;
                default:
                    underlinegrid.Margin = new Thickness(270, 0, 0, 0);
                    break;
            }
        }
    }
}
