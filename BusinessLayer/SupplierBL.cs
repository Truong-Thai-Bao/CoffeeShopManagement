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

        public int Insert(Supplier supplier)
        {
            //Nếu muốn xử lí lỗi id.lengh chỉ đc = 5
            if(supplier.id.Length != 5)
            {
                throw new Exception("Id chỉ được phép có 5 kí tự");
            }
            try
            {
                return supplierDL.Insert(supplier);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
