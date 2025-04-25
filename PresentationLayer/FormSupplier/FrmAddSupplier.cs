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
using TransferObject;
using BusinessLayer;
namespace PresentationLayer.FormSupplier
{
    public partial class FrmAddSupplier : Form
    {
        private SupplierBL supplierBL;
        public FrmAddSupplier()
        {
            InitializeComponent();
            supplierBL = new SupplierBL();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id, name, address;
            id = txtId.Text.Trim();
            name = txtName.Text.Trim();
            address = txtAddress.Text.Trim();

            if (id == string.Empty || name == string.Empty || address == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            try
            {
                int rowAffected =  supplierBL.Insert(new Supplier(id, name, address));
                if (rowAffected > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                    this.DialogResult = DialogResult.Cancel;
                txtAddress.Clear();
                txtId.Focus();
                txtId.Clear();
                txtName.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmAddSupplier_Load(object sender, EventArgs e)
        {

        }
    }
}
