using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Coffee : Form
    {
        public Coffee()
        {
            InitializeComponent();
        }

        private void Coffee_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Enabled = false;
            LoginForm login = new LoginForm();
            DialogResult result = login.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Enabled = true;
                label1.Text = "Welcome " + "Admin";
            }
            else
            {
                Application.Exit();
            }
        }

        public void addForm(Form form)
        {
            form.TopLevel = false;
            pnMain.Controls.Clear();
            pnMain.Controls.Add(form);

            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            addForm(new FormSupplier.FrmSupplier());
        }
    }
}
