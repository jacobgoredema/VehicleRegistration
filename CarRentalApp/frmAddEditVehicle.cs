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
    public partial class frmAddEditVehicle : Form
    {
        private readonly CarRentalEntity db;
        private bool isEditMode;
        private frmManageVehicleListing _manageVehicleListing;

        public frmAddEditVehicle(frmManageVehicleListing manageVehicleListing=null)
        {
            InitializeComponent();
            db = new CarRentalEntity();
            isEditMode = false;
            _manageVehicleListing = manageVehicleListing;
        }

        public frmAddEditVehicle(CarType carToEdit, frmManageVehicleListing manageVehicleListing=null)
        {
            InitializeComponent();
            isEditMode = true;
            PopulateFields(carToEdit);
            _manageVehicleListing = manageVehicleListing;
        }

        private void PopulateFields(CarType car)
        {
            lblId.Text = car.CarTypeId.ToString();
            txtModel.Text = car.Model;
            txtName.Text = car.Name;
            txtVin.Text = car.VIN;
            txtYear.Text = car.Year;
            txtNumberPlate.Text = car.LicensePlateNumber;
        }

        private void frmAddEditVehicle_Load(object sender, EventArgs e)
        {
            var cars = db.CarTypes.ToList();
            // populate cboMake
            //cboMake.DisplayMember = "Name";
            //cboMake.ValueMember = "CarTypeId";
            //cboMake.DataSource = cars;

            //// populate cboModel
            //cboModel.DisplayMember = "Model";
            //cboModel.ValueMember = "CarTypeId";
            //cboModel.DataSource = cars;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                // code for edit record.
                var id = int.Parse(lblId.Text);
                var car = db.CarTypes.FirstOrDefault(x => x.CarTypeId == id);
                car.Model = txtModel.Text;
                car.Name = txtName.Text;
                car.VIN = txtVin.Text;
                car.Year = (txtYear.Text);
                car.LicensePlateNumber = txtNumberPlate.Text;

                db.SaveChanges();
                MessageBox.Show("Current record successfully updated.");

            }
            else
            {
                // code insert new record.
                var newCar = new CarType();
                newCar.Model = txtModel.Text;
                newCar.Name = txtName.Text;
                newCar.VIN = txtVin.Text;
                newCar.Year = txtYear.Text;
                newCar.LicensePlateNumber = txtNumberPlate.Text;

                db.CarTypes.Add(newCar);
                db.SaveChanges();
                MessageBox.Show("New record successfully added.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
