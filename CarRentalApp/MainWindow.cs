using CarRentalApp.Data;
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
    public partial class frmMainWindow : Form
    {
        private frmLogin _login;
        public string _roleName;
        public User _user;

        public frmMainWindow()
        {
            InitializeComponent();
        }

        public frmMainWindow(frmLogin login, User user)
        {
            InitializeComponent();
            _login = login;
            _user = user;
            _roleName = user.UserRoles.FirstOrDefault().Role.Name;
        }

        private void addRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rentalRecord = new frmAddEditRentalRecord();
            rentalRecord.MdiParent = this;
            rentalRecord.Show();
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var vehicleListing = new frmManageVehicleListing();
            vehicleListing.MdiParent = this;
            vehicleListing.Show();
        }

        private void manageVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open 1 form at a time
            var openForms = Application.OpenForms.Cast<Form>();
            var isOpen = openForms.Any(q => q.Name == "frmAddEditVehicle");
            if (!isOpen)
            {
                var manageVehicles = new frmAddEditVehicle();
                manageVehicles.MdiParent = this;
                manageVehicles.Show();
            }
        }

        private void viewArchivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageRentalRecords = new frmManageRentalRecord();
            manageRentalRecords.MdiParent = this;
            manageRentalRecords.Show();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmMainWindow_Load(object sender, EventArgs e)
        {
            var login = new frmLogin();
            login.Close();

            var userName = _user.Username;
            toolStripStatusLabel1.Text = $"Logged in As: {userName}";

            if(_roleName != "admin")
            {
                manageUsersToolStripMenuItem.Visible = false;
            }
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openForms = Application.OpenForms.Cast<Form>();
            var isOpen = openForms.Any(x => x.Name == "frmManageUsers");
            if (!isOpen)
            {
                var manageUser = new frmManageUsers();
                manageUser.MdiParent = this;
                manageUser.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
