using InventoryApplication.Models;
using InventoryApplication.ViewModels;
using System;
using System.Collections;
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
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }
        
        private void UserNameTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!String.IsNullOrEmpty(this.UserNameTxt.Text) && !String.IsNullOrEmpty(passwordBox.Password))
                {
                    AdminUser parameter = new AdminUser()
                    {
                        UserName = this.UserNameTxt.Text,
                        Password = passwordBox.Password
                    };
                    LoginViewModel logvm = (LoginViewModel)this.FindResource("myvm");
                    logvm.ExecuteLoginMethod(parameter);
                }
            }
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                if (!String.IsNullOrEmpty(this.UserNameTxt.Text) && !String.IsNullOrEmpty(passwordBox.Password))
                {
                    AdminUser parameter = new AdminUser()
                    {
                        UserName = this.UserNameTxt.Text,
                        Password = passwordBox.Password
                    };
                    LoginViewModel logvm = (LoginViewModel)this.FindResource("myvm");
                    logvm.ExecuteLoginMethod(parameter);
                }
            }
            
        }
    }
}
