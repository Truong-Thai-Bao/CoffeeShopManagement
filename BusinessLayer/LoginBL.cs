﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataLayer;
using TransferObject;
namespace BusinessLayer
{
    public class LoginBL
    {
        private LoginDL loginDL;

        public LoginBL()
        {
            loginDL = new LoginDL();
        }

        public bool Login(Account account)
        {
            try
            {
                return loginDL.Login(account);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}
