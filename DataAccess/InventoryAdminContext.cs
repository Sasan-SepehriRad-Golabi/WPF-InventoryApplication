using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;

namespace InventoryApplication.DataAccess
{
    public interface ParentContext<T> where T:class,new()
    {
       IEnumerable<T> getAll<T>() where T : class, new();
       IEnumerable<T> FindAdmins<T>(Func<T, bool> predicate) where T : class, new();
        T InsertAdmins<T>(T Tentity) where T : class, new();
    }
    public class InventoryAdminContext
    {
        public AdminDbSet<Models.AdminUser> Admins { get; set; }
        public AdminDbSet<T> set<T>() where T:class,new()
        {
            AdminDbSet<T> result=null;
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach(PropertyInfo x in props)
            {
                if (((x.PropertyType).GenericTypeArguments[0]).Name == typeof(T).Name)
                {
                    result=(AdminDbSet<T>)x.GetValue(this);
                    break;
                }
            }
            return result;
        }
        public InventoryAdminContext()
        {
            
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach(PropertyInfo x in props)
            {
                try
                {
                    x.SetValue(this,Activator.CreateInstance(x.PropertyType));
                }
                catch(Exception ex)
                {
                    x.SetValue(this, null);
                }
            }
        }
    }
}
