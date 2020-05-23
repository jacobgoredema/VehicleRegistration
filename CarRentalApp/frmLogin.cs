using CarRentalApp.Data;
using CarRentalApp.Framework.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class frmLogin : Form
    {
        private CarRentalEntity db;

        public frmLogin()
        {
            InitializeComponent();
            db = new CarRentalEntity();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SHA256 sha = SHA256.Create();

                var username = txtUsername.Text.Trim();
                var password = txtUsername.Text;

                var hashed_password = Utils.HashPassword(password);

                var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password && x.IsActive == true);

                if (user==null)
                {
                    MessageBox.Show("Please provide valid credentials");
                }
                else
                {
                    var role = user.UserRoles.FirstOrDefault();
                    var roleName=role.Role.Name;
                    var mainWindow = new frmMainWindow(this, user);
                    mainWindow.Show();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Please try again");
            }

        }
    }
}
