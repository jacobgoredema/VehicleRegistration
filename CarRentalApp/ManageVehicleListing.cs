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
                Name = x.Name
            }).ToList();

            dgvVehicleListing.DataSource = cars;
            dgvVehicleListing.Columns[0].HeaderText= "CarTypeId";
            dgvVehicleListing.Columns[1].HeaderText = "Name";
        }
    }
}
