using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
namespace PresentationLayer.FormSupplier
{
    public partial class FrmSupplier : Form
    {
        private SupplierBL supplierBL;

        public FrmSupplier()
        {
            InitializeComponent();
            supplierBL = new SupplierBL();
        }

        private void FrmSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                dgvSupplier.DataSource = supplierBL.GetSuppliers();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
