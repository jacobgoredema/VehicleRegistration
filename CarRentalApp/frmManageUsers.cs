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
    public partial class frmManageUsers : Form
    {
        private CarRentalEntity db;
        private frmManageUsers _manageUsers;
        private frmMainWindow frmMainWindow;

        public frmManageUsers()
        {
            InitializeComponent();
            db = new CarRentalEntity();
            //_manageUsers = manageUsers;
        }

        public frmManageUsers(frmMainWindow frmMainWindow)
        {
            this.frmMainWindow = frmMainWindow;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            var users = db.Users.Select(x => new
            {
                x.UserId,
                x.Username,
                x.UserRoles.FirstOrDefault().Role.Name,
                x.IsActive
            }).ToList();

            dgvUserRecord.DataSource = users;
            dgvUserRecord.Columns["Username"].HeaderText = "User name";
            dgvUserRecord.Columns["Name"].HeaderText = "Role Name";
            dgvUserRecord.Columns["isActive"].HeaderText = "Active";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("AddUser"))
            {
                var addUser = new frmAddUser();
                addUser.MdiParent = this.MdiParent;
                addUser.Show();
            }
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)dgvUserRecord.SelectedRows[0].Cells["id"].Value;
                var user = db.Users.FirstOrDefault(x => x.UserId == id);
                user.IsActive = false;
                db.SaveChanges();
                MessageBox.Show("User deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("user has been deactivated!");
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                // get Id of Selected row
                var id = (int)dgvUserRecord.SelectedRows[0].Cells["UserId"].Value;
                //query database for record
                var user = db.Users.FirstOrDefault(x => x.UserId == id);

                var hashedPassword = Utils.DefaultPassword();
                user.Password = hashedPassword;
                db.SaveChanges();

                MessageBox.Show("Password has been reset");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
