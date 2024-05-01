using InventoryApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InventoryApplication.ViewModels.Convertors
{
    public class InventoryIdToInventoryConvertor : IValueConverter
    {
        InventoryApplicationContext ctx;
        public InventoryIdToInventoryConvertor()
        {
            ctx = new InventoryApplicationContext();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int res;
            Models.Inventory outres=null;
            if(int.TryParse(value.ToString() , out res))
            {
                UnitOfWork myuni = new UnitOfWork(ctx);
                outres = myuni.MyInventoriesRep.find(x => x.Id == res).FirstOrDefault<Models.Inventory>();
            }
            return outres;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            UnitOfWork uni = new UnitOfWork(ctx);
            Models.Inventory res;
            if (((Models.Inventory)value) != null)
            {
                res = (Models.Inventory)value;
                return res.Id;
            }
            else
            {
                return -1;
            }
        }
    }
}
