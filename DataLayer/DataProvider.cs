using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProvider
    {
        private SqlConnection cn;

        public DataProvider()
        {
            string cnStr = "Data Source=.;Initial Catalog=CoffeeShop;Integrated Security=True";
            cn = new SqlConnection(cnStr);
        }

        public void Connect()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }

        public void Disconnect()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        public object MyExecutaScalar(string sql,CommandType type)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;

                return (cmd.ExecuteScalar());
            }catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }

        public SqlDataReader MyExcuteReader(string sql, CommandType type)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                return cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //insert, delete, update
        public int MyExecuteNonQuery(string sql, CommandType type, List<SqlParameter> parameters = null)
        {
            try
            {
                Connect();

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;

                if(parameters != null)
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}   
