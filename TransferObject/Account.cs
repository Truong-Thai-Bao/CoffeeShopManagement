using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Account
    {
        private string username { get; set; }
        private string password { get; set; }
        public Account(string user, string pass)
        {
            this.username = user;
            this.password = pass;
        }
    }
    

}
