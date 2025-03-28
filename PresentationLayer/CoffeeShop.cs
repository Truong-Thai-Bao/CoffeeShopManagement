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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Enabled = false;
            LoginForm login = new LoginForm();
            DialogResult result =  login.ShowDialog();
            if(result == DialogResult.OK)
            {
                this.Enabled = true;
                label1.Text = "Welcome " + "XXX";
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
