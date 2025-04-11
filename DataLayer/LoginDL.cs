using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TransferObject;
namespace DataLayer
{
    public class LoginDL : DataProvider
    {
        public bool Login(Account account)
        {
            string sql = "Select Count(Username) from Users where Username='" + account.username + "' and password='"+account.password+"'";
            try
            {
                return (int)MyExecutaScalar(sql, CommandType.Text) > 0;
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }
    }
}
