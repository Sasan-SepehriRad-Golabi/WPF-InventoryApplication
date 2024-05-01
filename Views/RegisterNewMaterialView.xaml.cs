using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
using AForge.Video;
using AForge.Video.DirectShow;
using InventoryApplication.DataAccess;
using InventoryApplication.ViewModels;

namespace InventoryApplication.Views
{
    /// <summary>
    /// Interaction logic for RegisterNewMaterialView.xaml
    /// </summary>
    public partial class RegisterNewMaterialView : UserControl,INotifyPropertyChanged
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        InventoryApplicationContext ctx;

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterNewMaterialViewModel MyViewModel { get; set; }
        public AuthenticatedUserView myauthenticatedUserView { get; set; }
        delegate void xx(int pp);
        public void testc(int param1)
        {
            xx newXX = new xx((int param2) =>
            {
                param2++;
                System.Console.WriteLine(param2);
            });

        }
        public RegisterNewMaterialView(AuthenticatedUserView vv)
        {
            InitializeComponent();
            
            myauthenticatedUserView = vv;
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            MyViewModel = new RegisterNewMaterialViewModel(this);
            ctx = new InventoryApplicationContext();
            MainGrid.DataContext = MyViewModel;
        }
        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            BitmapImage MyResultImage;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                using (MemoryStream memory = new MemoryStream())
                {
                    File.OpenRead(files[files.Length - 1]).CopyTo(memory);
                    string xx = System.IO.Path.GetExtension(files[files.Length - 1]);
                    if(xx.ToLower()==".jpg"|| xx.ToLower() == ".jpeg"|| xx.ToLower()==".tiff"|| xx.ToLower() == ".png")
                    {
                        memory.Position = 0;
                        BitmapImage bitmapimage = new BitmapImage();
                        bitmapimage.BeginInit();
                        bitmapimage.StreamSource = memory;
                        bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapimage.EndInit();
                        bitmapimage.Freeze();
                        MyResultImage = bitmapimage;
                        MyViewModel.GetPictureFromDrop(MyResultImage);
                    }
                    else
                    {
                        MessageBox.Show("فرمت فایل وارد شده صحیح نمی باشد");
                    }
                }
            }
        }
        private void Button_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            Debug.WriteLine("testinggggg");
        }
        private void StackPanel_DropPersonel(object sender, DragEventArgs e)
        {
            BitmapImage MyResultImage_personel;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                using (MemoryStream memory = new MemoryStream())
                {
                    File.OpenRead(files[files.Length - 1]).CopyTo(memory);
                    string xx = System.IO.Path.GetExtension(files[files.Length - 1]);
                    if (xx.ToLower() == ".jpg" || xx.ToLower() == ".jpeg" || xx.ToLower() == ".tiff" || xx.ToLower() == ".png")
                    {
                        memory.Position = 0;
                        BitmapImage bitmapimage = new BitmapImage();
                        bitmapimage.BeginInit();
                        bitmapimage.StreamSource = memory;
                        bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapimage.EndInit();
                        bitmapimage.Freeze();
                        MyResultImage_personel = bitmapimage;
                        MyViewModel.GetPictureFromDropPersonel(MyResultImage_personel);
                    }
                    else
                    {
                        MessageBox.Show("فرمت فایل وارد شده صحیح نمی باشد");
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void closeNewPersonelDialog(object sender, RoutedEventArgs e)
        {
            RegisterPersonelDialog.IsOpen = false;
        }

        private void PersonelKeyUp(object sender, KeyEventArgs e)
        {
            UnitOfWork uni = new UnitOfWork(ctx);
            PersonelKeyUpname.IsDropDownOpen = true;
            string tt = ((ComboBox)sender).Text;
            if (((ComboBox)sender).Text=="")
            {
                MyViewModel.NameofPersonels = new System.Collections.ObjectModel.ObservableCollection<Models.Peronel>(uni.MyPersonRep.GetAll());
                ((ComboBox)sender).SelectedValue = null;
                ((ComboBox)sender).SelectedItem = null;
                ((ComboBox)sender).Text = "";
            }
            else
            {
                MyViewModel.NameofPersonels = new System.Collections.ObjectModel.ObservableCollection<Models.Peronel>(uni.MyPersonRep.find(x => x.FirstName.Contains(tt) || x.LastName.Contains(tt)));
            }
        }

        private void PersonelKeyUpname_GotFocus(object sender, RoutedEventArgs e)
        {
            PersonelKeyUpname.IsDropDownOpen = true;
        }

        private void PersonelKeyUpname_KeyDown(object sender, KeyEventArgs e)
        {
            PersonelKeyUpname.IsDropDownOpen = true;
        }
        private void MaterialKeyup(object sender, KeyEventArgs e)
        {
            MaterialTosearchName.IsDropDownOpen = true;
            UnitOfWork uni = new UnitOfWork(ctx);
            string tt = ((ComboBox)sender).Text;
            if (tt== "")
            {
                MyViewModel.NamesofMaterialsob = MyViewModel.getNamesofMaterials(null);
                ((ComboBox)sender).SelectedValue = null;
                ((ComboBox)sender).SelectedItem = null;
                ((ComboBox)sender).Text = "";
            }
            else
            {
                MyViewModel.NamesofMaterialsob = MyViewModel.getNamesofMaterials(tt);
            }
        }

        private void MaterialGotFocus(object sender, RoutedEventArgs e)
        {
            MyViewModel.NamesofMaterialsob = MyViewModel.getNamesofMaterials(null);
            MaterialTosearchName.IsDropDownOpen = true;
        }

        private void MaterialTosearchName_KeyDown(object sender, KeyEventArgs e)
        {
            //MaterialTosearchName.IsDropDownOpen = false;
        }
    }
}
