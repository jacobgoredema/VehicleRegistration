using CarRentalApp.Data;
using CarRentalApp.Framework.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class frmAddUser : Form
    {
        private CarRentalEntity db;

        public frmAddUser()
        {
            InitializeComponent();
            db = new CarRentalEntity();
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            var roles = db.Roles.ToList();
            cboRole.DataSource = roles;
            cboRole.ValueMember = "RoleId";
            cboRole.DisplayMember = "Name";

        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var roleId = (int)cboRole.SelectedValue;
            var password = Utils.DefaultPassword();

            try
            {
                var user = new User
                {
                    Username = username,
                    Password = password,
                    IsActive = true
                };

                db.Users.Add(user);
                db.SaveChanges();

                var userId = user.UserId;
                var userRole = new UserRole
                {
                    RoleId = roleId,
                    UserId = userId
                };

                db.UserRoles.Add(userRole);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: { ex.Message}");
            }

        }
    }
}
