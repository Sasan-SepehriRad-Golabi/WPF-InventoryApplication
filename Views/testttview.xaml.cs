using InventoryApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for testttview.xaml
    /// </summary>
    public partial class testttview : UserControl
    {
       
        public testttview()
        {
            InitializeComponent();
            //ctx = new InventoryApplicationContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            InventoryApplicationContext ctx=new InventoryApplicationContext();
            Regex myreg = new Regex(" ");
            var x = mydate.SelectedDate.Value.Date.ToString();
            var y = mydate.SelectedDate.Value.Date.ToString().Substring(0, myreg.Match(mydate.SelectedDate.Value.Date.ToString()).Index);
            var z = mytime.SelectedTime.ToString();
            var z1 = mytime.SelectedTime.ToString().Substring(myreg.Match(mytime.SelectedTime.ToString()).Index + 1);
            Debug.WriteLine(mytime.Text);

            //using (UnitOfWork myunint = new UnitOfWork(ctx))
            //{
            //    Models.testtt mytest = new Models.testtt()
            //    {
            //        MyDate = y + " " + z1
            //    };
            //    myunint.MytestttRep.Add(mytest);
            //    myunint.complete();
            //}
        }
    }
}
