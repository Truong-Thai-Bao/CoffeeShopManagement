using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
namespace PresentationLayer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool UserLogin(Account account)
        {
            //return false;
            return true;
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
