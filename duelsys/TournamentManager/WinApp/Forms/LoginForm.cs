using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BLL.Registries;
using BLL.Objects.Users;
using DAL.Repositories;
using DAL;

namespace WinApp.Forms
{
    public partial class LoginForm : Form
    {
        private LoginHandler loginHandler;
        private MainForm? mainForm;

        public LoginForm()
        {
            InitializeComponent();
            loginHandler = new LoginHandler(new LoginRepository(new DbContext()));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Credentials creds = new Credentials()
            {
                Email = inputEmail.Text,
                Password = inputPassword.Text
            };
            try
            {
                User? user = loginHandler.VerifyCredentials(creds);

                if (user != null)
                {
                    mainForm ??= new MainForm();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
