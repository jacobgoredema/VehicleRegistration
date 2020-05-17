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
    public partial class frmAddEditRentalRecord : Form
    {
        private bool isValid;
        private bool isEditMode;
        private readonly CarRentalEntity db;
        private string errorMessage;

        public frmAddEditRentalRecord()
        {
            InitializeComponent();
            db = new CarRentalEntity();
            isEditMode = false;
        }

        public frmAddEditRentalRecord(CarRentalRecord recordToEdit)
        {
            InitializeComponent();
            if (recordToEdit==null)
            {
                MessageBox.Show("Please ensure that you selected a valid record to edit.");
                isValid = false;
                Close();
            }
            else
            {
                isEditMode = true;
                db = new CarRentalEntity();
                PopulateFileds(recordToEdit);




            }

        }

        private void PopulateFileds(CarRentalRecord recordToEdit)
        {
            lblId.Text = recordToEdit.RentalId.ToString();
            txtName.Text = recordToEdit.Name;
            dpDateRented.Value = (DateTime)recordToEdit.RentalDate;
            dpDateReturned.Value =(DateTime)recordToEdit.ReturnDate;
            txtCost.Text = recordToEdit.Cost.ToString();
            //cboCarType.Text = recordToEdit.CarType.Name;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            DateTime dateOut = dpDateRented.Value;
            DateTime dateIn = dpDateReturned.Value;
            double cost = Convert.ToDouble(txtCost.Text);
            var carType = cboCarType.Text;
            //bool isValid = true;
            string errorMessage = string.Empty;
            isValid = true;

            if (isValid)
            {
                var rentalRecord = new CarRentalRecord();

                if (isEditMode)
                {
                    var id = int.Parse(lblId.Text);
                    rentalRecord = db.CarRentalRecords.FirstOrDefault(q => q.RentalId == id);
                }

                rentalRecord.Name = name;
                rentalRecord.RentalDate = dateOut;
                rentalRecord.ReturnDate = dateIn;
                rentalRecord.Cost = (decimal)cost;
                rentalRecord.TypeOfCarId = (int)cboCarType.SelectedValue;

                if (!isEditMode)
                    db.CarRentalRecords.Add(rentalRecord);

                db.SaveChanges();
                MessageBox.Show("Record updated successfully.");
                Close();                
            }
            else
            {
                MessageBox.Show(errorMessage);
            }

            try
            {
                

                //if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(carType))
                //{
                //    isValid = false;
                //    errorMessage += "Error: Please enter the missing data. \n\n";
                //}

                //if (dateOut > dateIn)
                //{
                //    isValid = false;
                //    errorMessage += "Illegal Date Selection.\n\n";
                //}

                //if (isValid == true)
                //{
                    
                //}
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
            cboCarType.DataSource = cars;
        }
    }
}
