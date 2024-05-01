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
    public class CompanyIdToCompanyConvertor : IValueConverter
    {
        public InventoryApplicationContext ctx { get; set; }
        public CompanyIdToCompanyConvertor()
        {
            ctx = new InventoryApplicationContext();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            UnitOfWork uni = new UnitOfWork(ctx);
            int res;
            if(int.TryParse(value.ToString(),out res))
            {
                Models.ProviderCompany mycomp= uni.MyProviderCompaniesRep.find(x => x.Id == res).FirstOrDefault<Models.ProviderCompany>();
                return mycomp;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            UnitOfWork uni = new UnitOfWork(ctx);
            Models.ProviderCompany res;
            if (((Models.ProviderCompany)value)!=null)
            {
                res = (Models.ProviderCompany)value;
                return res.Id;
            }
            else
            {
                return -1;
            }
        }
    }
}
