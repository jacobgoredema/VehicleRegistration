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
    public partial class frmManageRentalRecord : Form
    {
        private readonly CarRentalEntity db;

        public frmManageRentalRecord()
        {
            InitializeComponent();
            db = new CarRentalEntity();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)dgvRentalRecord.SelectedRows[0].Cells["RentalId"].Value;
                var record = db.CarRentalRecords.FirstOrDefault(x => x.RentalId == id);
                db.CarRentalRecords.Remove(record);

                db.SaveChanges();
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {
                // get id of selected row
                var id = (int)dgvRentalRecord.SelectedRows[0].Cells["RentalId"].Value;
                //query the database for record
                var record = db.CarRentalRecords.FirstOrDefault(x => x.RentalId == id);

                //launch Edit window
                var addEdirRentalRecord = new frmAddEditRentalRecord(record);
                addEdirRentalRecord.MdiParent = this.MdiParent;
                addEdirRentalRecord.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            var addRentalRecord = new frmAddEditRentalRecord();
            addRentalRecord.MdiParent = this.MdiParent;
            addRentalRecord.Show();
        }

        private void frmManageRentalRecord_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void PopulateGrid()
        {
            var records = db.CarRentalRecords.Select(q => new
            {
                Customer = q.Name,
                DateOut = q.RentalDate,
                DateIn = q.ReturnDate,
                RentalId = q.RentalId,
                Cost = q.Cost,
                Car = q.CarType.Model + " " + q.CarType.Name
            }).ToList();

            dgvRentalRecord.DataSource = records;
            dgvRentalRecord.Columns["DateIn"].HeaderText = "Return Date";
            dgvRentalRecord.Columns["DateOut"].HeaderText = "Date Out";
            dgvRentalRecord.Columns["RentalId"].Visible = false;
        }
    }
}
