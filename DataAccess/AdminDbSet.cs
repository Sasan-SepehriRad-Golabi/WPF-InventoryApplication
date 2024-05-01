using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;

namespace InventoryApplication.DataAccess
{
    public class AdminDbSet<T> where T:class,new()
    {
        string myconnectionstring;
        public IEnumerable<T> SetOfOurType { get; set; }
        public AdminDbSet()
        {
            myconnectionstring = ConfigurationManager.ConnectionStrings["InventoryAdminContext"].ConnectionString;
            SetOfOurType = getAll<T>();
        }
        public IEnumerable<T> getAll<T>() where T : class,new()
        {
            try
            {
                SqlConnection con = new SqlConnection(myconnectionstring);
                SqlCommand cmd = new SqlCommand("getall", con);
                cmd.Parameters.Add("@tablenme", SqlDbType.NVarChar, -1);
                cmd.Parameters["@tablenme"].Value = typeof(T).Name;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                Type t = typeof(T);
                SqlDataReader rdr = cmd.ExecuteReader();
                List<T> AdminList = new List<T>();
                while (rdr.Read())
                {
                    PropertyInfo[] props = t.GetProperties();
                    T tobj = new T();
                    for (int i = 0; i < props.Length; i++)
                    {
                        if (i == 0)
                        {
                            props[i].SetValue(tobj, Convert.ToInt32(rdr.GetValue(i)));
                        }
                        else
                        {
                            props[i].SetValue(tobj, rdr.GetValue(i));
                        }
                    }
                    AdminList.Add(tobj);
                }
                con.Close();
                return AdminList;
            }
            catch (Exception ex)
            {
                List<T> AdminList = new List<T>();
                return AdminList;
            }

        }
        public IEnumerable<T> FindAdmins(Func<T,bool> predicate)
        {
           
            IEnumerable<T> result= SetOfOurType.Where(predicate);
            return result;
        }
        public T InsertAdmins<T>(T Tentity) where T : class, new()
        {

            try
            {
                SqlConnection con = new SqlConnection(myconnectionstring);
                SqlCommand cmd = new SqlCommand("InsertAdmins", con);
                cmd.Parameters.Add("@tablename", SqlDbType.NVarChar, -1);
                cmd.Parameters["@tablename"].Value = typeof(T).Name;
                cmd.Parameters.Add("@userName", SqlDbType.NVarChar, -1);
                var x= Tentity.GetType().GetProperty("UserName").GetValue(Tentity);
                cmd.Parameters["@userName"].Value = Tentity.GetType().GetProperty("UserName").GetValue(Tentity);
                cmd.Parameters.Add("@pass", SqlDbType.NVarChar, -1);
                cmd.Parameters["@pass"].Value = Tentity.GetType().GetProperty("Password").GetValue(Tentity);
                cmd.Parameters.Add("@IsPrimary", SqlDbType.NVarChar, -1);
                cmd.Parameters["@IsPrimary"].Value = Tentity.GetType().GetProperty("IsAdmin").GetValue(Tentity);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                Type t = typeof(T);
                cmd.ExecuteNonQuery();
                con.Close();
                return Tentity;
            }
            catch (Exception ex)
            {
                return new T();
            }
        }
    }
}
