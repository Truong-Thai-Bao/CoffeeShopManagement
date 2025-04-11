using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using BusinessLayer;
namespace PresentationLayer
{
    public partial class LoginForm : Form
    {
        private LoginBL loginBL;
        public LoginForm()
        {
            InitializeComponent();
            loginBL = new LoginBL();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool UserLogin(Account account)
        {
            try
            {
                return loginBL.Login(account);
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Account account = new Account(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (UserLogin(account))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                string msg = "Your username and password are incorrect!";
                DialogResult result = MessageBox.Show(msg,"Danger", MessageBoxButtons.RetryCancel, 
                    MessageBoxIcon.Error);
                if(result == DialogResult.Retry)
                {
                    txtUsername.Focus();
                    txtPassword.Clear();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
