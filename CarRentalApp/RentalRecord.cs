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
    public partial class frmAddEditRental : Form
    {
        private readonly CarRentalEntity db;

        public frmAddEditRental()
        {
            InitializeComponent();
            db = new CarRentalEntity();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                DateTime dateOut = dpDateRented.Value;
                DateTime dateIn = dpDateReturned.Value;
                double cost = Convert.ToDouble(txtCost.Text);
                var carType = cboCarType.Text;
                bool isValid = true;
                string errorMessage = string.Empty;

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(carType))
                {
                    isValid = false;
                    errorMessage += "Error: Please enter the missing data. \n\n";
                }

                if (dateOut > dateIn)
                {
                    isValid = false;
                    errorMessage += "Illegal Date Selection.\n\n";
                }

                if (isValid == true)
                {
                    int id;
                    var rentalRecord = new CarRentalRecord();
                    rentalRecord.Name = name;
                    rentalRecord.RentalDate = dateOut;
                    rentalRecord.ReturnDate = dateIn;
                    rentalRecord.Cost = (decimal)cost;
                    rentalRecord.TypeOfCarId = (int)cboCarType.SelectedValue;

                    db.CarRentalRecords.Add(rentalRecord);
                    db.SaveChanges();
                    MessageBox.Show("Record updated successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //populate carType dropdownlist
            var cars = db.CarTypes.ToList();
            cboCarType.DisplayMember = "Name";
            cboCarType.ValueMember = "CarTypeId";
            //cboCarType.SelectedIndex = -1;
            cboCarType.DataSource = cars;
        }
    }
}
