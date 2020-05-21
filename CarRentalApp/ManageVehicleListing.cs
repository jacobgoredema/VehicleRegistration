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
    public partial class frmManageVehicleListing : Form
    {
        private readonly CarRentalEntity db;

        public frmManageVehicleListing()
        {
            InitializeComponent();
            db = new CarRentalEntity();
        }

        private void frmManageVehicleListing_Load(object sender, EventArgs e)
        {
            //var cars = db.CarTypes.ToList();
            var cars = db.CarTypes.Select(x => new
            {
                CarTypeId = x.CarTypeId,
                Name = x.Name,
                VPN = x.VIN,
                model = x.Model,
                RegistrationMumber = x.LicensePlateNumber
            }).ToList();

            dgvVehicleListing.DataSource = cars;
            dgvVehicleListing.Columns[0].Visible = false;
            dgvVehicleListing.Columns[0].HeaderText= "CarTypeId";
            dgvVehicleListing.Columns[1].HeaderText = "Name";
            dgvVehicleListing.Columns[2].HeaderText = "Model";
            dgvVehicleListing.Columns[3].HeaderText = "VIN";
            dgvVehicleListing.Columns[4].HeaderText = "Number Plate";

        }

        private void btnAddNewCar_Click(object sender, EventArgs e)
        {
            var mainWindow = new frmMainWindow();
            var manageCars = new frmAddEditVehicle(this);
            manageCars.MdiParent = this.MdiParent;
            manageCars.Show();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {          
            // get id of selected row
            var id = (int)dgvVehicleListing.SelectedRows[0].Cells["CarTypeId"].Value;
            //query database for record
            var car = db.CarTypes.FirstOrDefault(x => x.CarTypeId == id);
            // launch Edit Window
            var manageVehicle = new frmAddEditVehicle(this);
            manageVehicle.MdiParent = this.MdiParent;
            manageVehicle.Show();

        }

        private void RefreshGrid()
        {
            dgvVehicleListing.Refresh();
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            var id = (int)dgvVehicleListing.SelectedRows[0].Cells["CarTypeId"].Value;
            var car = db.CarTypes.FirstOrDefault(x => x.CarTypeId == id);
            db.CarTypes.Remove(car);
            db.SaveChanges();
            dgvVehicleListing.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvVehicleListing.Refresh();
        }

        public void PopulateGrid()
        {
            // select a custom model collection of cars from database
            var cars = db.CarTypes.Select(q => new
            {
                Make = q.Name,
                Model = q.Model,
                VIN = q.VIN,
                Year = q.Year,
                LicensePlate = q.LicensePlateNumber,
                q.CarTypeId
            }).ToList();

            dgvVehicleListing.DataSource = cars;
            dgvVehicleListing.Columns[4].HeaderText = "Number Plate";
            dgvVehicleListing.Columns["Id"].Visible = false;
        }
    }
}
