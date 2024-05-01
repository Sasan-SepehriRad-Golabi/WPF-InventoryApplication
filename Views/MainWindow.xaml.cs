using InventoryApplication.DataAccess;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Snackbar snackbar = new Snackbar();
        public static MaterialDesignThemes.Wpf.Transitions.Transitioner mytrans;
        public enum pages
        {
            MainView=0,
            LoginView=1,
            AuthenticatedView=2,
            RegisterView=3,
            ErrorView =4
        }
        public MainWindow()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<InventoryApplicationContext>());
            InitializeComponent();
            mytrans = MainTransitioner; 


        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {

            }
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            mytrans.SelectedIndex = 0;
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            mytrans.SelectedIndex = 1;
        }

        private void ErrorView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
    }
}
