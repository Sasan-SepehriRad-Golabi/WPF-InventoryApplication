using InventoryApplication.DataAccess;
using InventoryApplication.Models;
using InventoryApplication.ViewModels.Commands;
using InventoryApplication.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace InventoryApplication.ViewModels
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand RegisterCommand { get; set; }
        public bool messagequeueactive { get; set; }
        public SolidColorBrush AlarmBackground { get; set; }
        public SolidColorBrush AlarmForeground { get; set; }
        public string ErrorMessage { get; set; }
        private AdminUser _NewUser;
        private string _ConfirmPass;
        public string ConfirmPass
        {
            get
            {
                return _ConfirmPass;
            }
            set
            {
                _ConfirmPass = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConfirmPass"));
            }
        }
        public AdminUser NewUser {
            get
            {
                return _NewUser;
            } 
            set 
            {
                _NewUser = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewUser"));
            }
        }
        public RegisterViewModel()
        {
            RegisterCommand = new UserRegisterCommand(this);
            NewUser = new AdminUser();
        }
        public bool canExecutee(object parameter)
        {
            try
            {
                if (parameter == null || parameter.GetType() != typeof(AdminUser))
                {
                    return false;

                }
                else
                {
                    string pass = ((AdminUser)parameter)?.Password?.Trim();
                    string un = ((AdminUser)parameter)?.UserName?.Trim();
                    if (!string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(un))
                    {
                        if (ConfirmPass == pass)
                        {
                            Task.Delay(new TimeSpan(0, 0, 1)).ContinueWith(t =>
                            {
                                messagequeueactive = false;
                            });
                            ErrorMessage = "رمز و تکرار آن یکسان هستند";
                            AlarmBackground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(26, 118, 7));
                            AlarmForeground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(5, 5, 5));
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AlarmBackground"));
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AlarmForeground"));
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorMessage"));
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("messagequeueactive"));
                            return true;
                        }
                        else
                        {
                            ErrorMessage = "رمز و تکرار آن یکسان نیستند";
                            AlarmBackground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(171, 49, 75));
                            AlarmForeground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(5, 5, 5));
                            messagequeueactive = true;
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AlarmBackground"));
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AlarmForeground"));
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorMessage"));
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("messagequeueactive"));
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public void Registerr(object parameter)
        {
            try
            {
                if (parameter.GetType() == typeof(AdminUser))
                {
                    Debug.WriteLine(parameter.ToString());
                    if (parameter != null && parameter.GetType() == typeof(AdminUser))
                    {
                        AdminUser NewUser = ((AdminUser)parameter);
                        if (NewUser != null)
                        {
                            var userName = NewUser.UserName;
                            var password = NewUser.Password;
                            Debug.WriteLine("UserName is: " + userName + " and Password is: " + password);
                            using (var myUnitofWork = new AdminUnitofWork(new InventoryAdminContext()))
                            {
                                Debug.WriteLine("UserName issssssss: " + userName + " and Password is: " + password);
                                List<Models.AdminUser> users = myUnitofWork.AdminRepos.find(x => x.UserName == userName && x.Password == password).ToList();
                                if (users.Count == 0)
                                {
                                    Debug.WriteLine("New User");
                                    Models.AdminUser MyUser = new AdminUser()
                                    {
                                        Password = NewUser.Password,
                                        UserName = NewUser.UserName,
                                        IsAdmin = NewUser.IsAdmin
                                    };
                                    myUnitofWork.AdminRepos.Add(MyUser);
                                    myUnitofWork.complete();
                                    MainWindow.mytrans.SelectedIndex = (int)MainWindow.pages.LoginView;
                                }
                                else if (users.Count == 1)
                                {
                                    MainWindow.mytrans.SelectedIndex = (int)MainWindow.pages.LoginView;
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
                                }
                            }
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("خطا در سیستم");
            }
        }
       

    }
}
