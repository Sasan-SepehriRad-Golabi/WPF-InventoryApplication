using InventoryApplication.DataAccess;
using System;
using System.Collections.Generic;
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

namespace InventoryApplication.Views
{

    public partial class SubSearchPageView : UserControl
    {
        public SearchNewMaterial MySearchNewMaterial { get; set; }
        public RegisterNewMaterialView myregisterview { get; set; }
        InventoryApplicationContext ctx;
        public SubSearchPageView(SearchNewMaterial myview)
        {
            InitializeComponent();
            MySearchNewMaterial = myview;
            ctx = new InventoryApplicationContext();
            this.DataContext = MySearchNewMaterial.mysearchnewmaterialviewmodel;
        }
        private void Button_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }

        private void Companysearchkeyup(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(((ComboBox)sender).Text);
            Debug.WriteLine(e.Key);
            Debug.WriteLine("#################");
            if (((ComboBox)sender).Text == "")
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.MyCompanysearchkeyup(((ComboBox)sender).Text);
                ((ComboBox)sender).SelectedValue = null;
                ((ComboBox)sender).SelectedItem = null;
                ((ComboBox)sender).Text = "";
            }
            else
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.MyCompanysearchkeyup(((ComboBox)sender).Text);
            }
        }
        private void Inventorysearchkeyup(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(((ComboBox)sender).Text);
            Debug.WriteLine(e.Key);
            Debug.WriteLine("#################");
            if (((ComboBox)sender).Text == "")
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.MyInventorysearchkeyup(((ComboBox)sender).Text);
                ((ComboBox)sender).SelectedValue = null;
                ((ComboBox)sender).SelectedItem = null;
                ((ComboBox)sender).Text = "";
            }
            else
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.MyInventorysearchkeyup(((ComboBox)sender).Text);
            }
        }

        private void Companysearch_GotFocus(object sender, RoutedEventArgs e)
        {
            Companysearch.IsDropDownOpen = true;
        }

        private void Companysearch_KeyDown(object sender, KeyEventArgs e)
        {
            Companysearch.IsDropDownOpen = true;
        }

        private void Inventorysearch_GotFocus(object sender, RoutedEventArgs e)
        {
            Inventorysearch.IsDropDownOpen = true;
        }

        private void Inventorysearch_KeyDown(object sender, KeyEventArgs e)
        {
            Inventorysearch.IsDropDownOpen = true;
        }

        private void nameofmaterialforsearch_KeyDown(object sender, KeyEventArgs e)
        {
            nameofmaterialforsearch.IsDropDownOpen = true;
        }

        private void nameofmaterialforsearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (((ComboBox)sender).Text == "")
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.MyMaterialsearchkeyup(((ComboBox)sender).Text);
                ((ComboBox)sender).SelectedValue = null;
                ((ComboBox)sender).SelectedItem = null;
                ((ComboBox)sender).Text = "";
            }
            else
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.MyMaterialsearchkeyup(((ComboBox)sender).Text);
            }
        }

        private void nameofmaterialforsearch_GotFocus(object sender, RoutedEventArgs e)
        {
            nameofmaterialforsearch.IsDropDownOpen = true;
        }

        private void OpenMoreDitailsofofMaterialBuyingDialog(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.OpenMoreDitailsofofMaterialBuyingDialog(sender, e);
        }

        private void OpenDetailsofMaterialBuying(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.OpenDetailsofMaterialBuying(sender, e);
            
        }

        private void closeDitailsofofMaterialBuyingDialog(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.closeDitailsofofMaterialBuyingDialog(sender, e);
        }

        private void closeMoreDitailsofofMaterialBuyingDialog(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.closeMoreDitailsofofMaterialBuyingDialog(sender, e);
        }

        private void CloseExitMaterialDialog(object sender, RoutedEventArgs e)
        {
            ExitMaterialDialog.IsOpen = false;
        }

        private void OpenExitMaterialDialogGeneral(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.OpenExitMaterialDialogGeneral(sender, e);
        }
        private void OpenExitMaterialDialogParticular(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.OpenExitMaterialDialogParticular(sender, e);
        }
        private void PersonelKeyUp1(object sender, KeyEventArgs e)
        {
            UnitOfWork uni = new UnitOfWork(ctx);
            PersonelKeyUpname1.IsDropDownOpen = true;
            string tt = ((ComboBox)sender).Text;
            if (((ComboBox)sender).Text == "")
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.NameofPersonels1 = new System.Collections.ObjectModel.ObservableCollection<Models.Peronel>(uni.MyPersonRep.GetAll());
                ((ComboBox)sender).SelectedValue = null;
                ((ComboBox)sender).SelectedItem = null;
                ((ComboBox)sender).Text = "";
            }
            else
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.NameofPersonels1 = new System.Collections.ObjectModel.ObservableCollection<Models.Peronel>(uni.MyPersonRep.find(x => x.FirstName.Contains(tt) || x.LastName.Contains(tt)));
            }
        }

        private void PersonelKeyUpname1_GotFocus(object sender, RoutedEventArgs e)
        {
            PersonelKeyUpname1.IsDropDownOpen = true;
        }

        private void PersonelKeyUpname1_KeyDown(object sender, KeyEventArgs e)
        {
            PersonelKeyUpname1.IsDropDownOpen = true;
        }



        private void PersonelKeyUp2(object sender, KeyEventArgs e)
        {
            UnitOfWork uni = new UnitOfWork(ctx);
            PersonelKeyUpname2.IsDropDownOpen = true;
            string tt = ((ComboBox)sender).Text;
            if (((ComboBox)sender).Text == "")
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.NameofPersonels2 = new System.Collections.ObjectModel.ObservableCollection<Models.Peronel>(uni.MyPersonRep.GetAll());
                ((ComboBox)sender).SelectedValue = null;
                ((ComboBox)sender).SelectedItem = null;
                ((ComboBox)sender).Text = "";
            }
            else
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.NameofPersonels2 = new System.Collections.ObjectModel.ObservableCollection<Models.Peronel>(uni.MyPersonRep.find(x => x.FirstName.Contains(tt) || x.LastName.Contains(tt)));
            }
        }

        private void PersonelKeyUpname2_GotFocus(object sender, RoutedEventArgs e)
        {
            PersonelKeyUpname2.IsDropDownOpen = true;
        }

        private void PersonelKeyUpname2_KeyDown(object sender, KeyEventArgs e)
        {
            PersonelKeyUpname2.IsDropDownOpen = true;
        }

        private void PersonelKeyUp3(object sender, KeyEventArgs e)
        {
            UnitOfWork uni = new UnitOfWork(ctx);
            PersonelKeyUpname3.IsDropDownOpen = true;
            string tt = ((ComboBox)sender).Text;
            if (((ComboBox)sender).Text == "")
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.NameofPersonels3 = new System.Collections.ObjectModel.ObservableCollection<Models.Peronel>(uni.MyPersonRep.GetAll());
                ((ComboBox)sender).SelectedValue = null;
                ((ComboBox)sender).SelectedItem = null;
                ((ComboBox)sender).Text = "";
            }
            else
            {
                MySearchNewMaterial.mysearchnewmaterialviewmodel.NameofPersonels3 = new System.Collections.ObjectModel.ObservableCollection<Models.Peronel>(uni.MyPersonRep.find(x => x.FirstName.Contains(tt) || x.LastName.Contains(tt)));
            }
        }

        private void PersonelKeyUpname3_GotFocus(object sender, RoutedEventArgs e)
        {
            PersonelKeyUpname3.IsDropDownOpen = true;
        }

        private void PersonelKeyUpname3_KeyDown(object sender, KeyEventArgs e)
        {
            PersonelKeyUpname3.IsDropDownOpen = true;
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
                        MySearchNewMaterial.mysearchnewmaterialviewmodel.GetPictureFromDropPersonel(MyResultImage_personel);
                    }
                    else
                    {
                        MessageBox.Show("فرمت فایل وارد شده صحیح نمی باشد");
                    }
                }
            }
        }
        private void closeNewPersonelDialog(object sender, RoutedEventArgs e)
        {
            RegisterPersonelDialog.IsOpen = false;
        }

        private void RemoveAllAtOnce(object sender, RoutedEventArgs e)
        {
            MySearchNewMaterial.mysearchnewmaterialviewmodel.removeTheWholeMaterialCommand(sender, e);
        }
    }
}
