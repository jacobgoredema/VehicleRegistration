using CarRentalApp.Data;
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

                byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }

                var hashed_password = stringBuilder.ToString();
                var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

                if (user==null)
                {
                    MessageBox.Show("Please provide valid credentials");
                }
                else
                {
                    var role = user.UserRoles.FirstOrDefault();
                    var roleName=role.Role.Name;
                    var mainWindow = new frmMainWindow(this, roleName);
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
