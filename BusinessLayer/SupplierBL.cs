using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;
namespace BusinessLayer
{
    public class SupplierBL
    {
        private SupplierDL supplierDL;

        public SupplierBL()
        {
            supplierDL = new SupplierDL();
        }

        public List<Supplier> GetSuppliers()
        {
            try
            {
                return supplierDL.GetSuppliers();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
