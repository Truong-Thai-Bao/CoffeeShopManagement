using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
namespace DataLayer
{
    public class SupplierDL : DataProvider
    {
        public List<Supplier> GetSuppliers()
        {
            string sql = "select * from Supplier";
            List<Supplier> suppliers = new List<Supplier>();
            try
            {
                Connect();
                SqlDataReader reader = MyExcuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    suppliers.Add(new Supplier(reader[0].ToString(), 
                                                reader[1].ToString(), 
                                                reader[2].ToString()));
                }
                reader.Close();
                return suppliers;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //Cách thông thường
        public int Insert(Supplier supplier)
        {
            string sql = $"insert into Supplier values('{supplier.id}','{supplier.name}','{supplier.address}')";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        ///Cách truyền theo biến
        //public int Insert(Supplier supplier)
        //{
        //    string sql = "uspInsertSupplier";
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@id", supplier.id));
        //    parameters.Add(new SqlParameter("@name", supplier.name));
        //    parameters.Add(new SqlParameter("@address", supplier.address));
        //    try
        //    {
        //        return MyExecuteNonQuery(sql, CommandType.StoredProcedure,parameters);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }

        //}
    }
}
