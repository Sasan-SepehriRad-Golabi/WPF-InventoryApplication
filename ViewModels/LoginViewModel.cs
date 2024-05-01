using InventoryApplication.ViewModels.Commands;
using InventoryApplication.DataAccess;
using InventoryApplication.Models;
using InventoryApplication.Repositories;
using InventoryApplication.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace InventoryApplication.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand logincommand { get; set; }
        private AdminUser _myuser;

        public AdminUser MyUser
        {
            get 
            {
                return _myuser; 
            }
            set 
            {
                _myuser = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyUser"));
            }
        }

        public LoginViewModel()
        {
            logincommand = new LoginCommand(this);
            MyUser = new AdminUser();
        }

        public bool EnableLoginButton(object parameter)
        {
            if (parameter == null || parameter.GetType() != typeof(AdminUser))
            {
                return false;
                
            }
            else
            {
                if (((AdminUser)parameter)?.Password!=null && !string.IsNullOrEmpty(((AdminUser)parameter)?.UserName.Trim()))
                {
                        return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void ExecuteLoginMethod(object parameter)
        {
            try
            {
                Debug.WriteLine(parameter.ToString());
                if (parameter != null && parameter.GetType() == typeof(AdminUser))
                {
                    var userName = ((AdminUser)parameter).UserName;
                    var password = ((AdminUser)parameter).Password;
                    Debug.WriteLine("UserName is: " + userName + " and Password is: " + password);
                    UnitOfWork uni = new UnitOfWork(new InventoryApplicationContext());
                    List<Models.AdminUser> users = uni.MyAdminUsersRep.find(x => x.UserName == userName && x.Password == password).ToList();
                    if (users.Count == 0 || !(users.Count > 0 && users[0].IsAdmin))
                    {
                        MainWindow.mytrans.SelectedIndex = (int)MainWindow.pages.RegisterView;
                    }
                    else if (users.Count == 1 && (users.Count > 0 && users[0].IsAdmin))
                    {
                        MainWindow.mytrans.SelectedIndex = (int)MainWindow.pages.AuthenticatedView;
                    }
                    else
                    {
                        var mylogg = new Models.Log()
                        {
                            classofDevice = "Error",
                            IsRead = "No",
                            TimeofLog = DateTime.Now,
                            LogReport = "خطایی در دسترسی به کاربر مورد نظر رخ داد",
                            UserInChargeofReading = "NotRead"
                        };
                        MessageBox.Show("خطایی رخ داد");
                    }


                    //Repository<Models.User> MytestUsers = new Repository<Models.User>(new InventoryApplicationContext());
                    //List<Models.User> userlist= MytestUsers.find(x => (x.UserName == userName && x.Password == password)).ToList();
                    //if (userlist.Count == 1)
                    //{
                    //    MainWindow.mytrans.SelectedIndex = 2;
                    //}
                    //else
                    //{

                    //    MainWindow.mytrans.SelectedIndex = 3;
                    //}

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("خطا در سیستم");
            }
        }
    }
}
