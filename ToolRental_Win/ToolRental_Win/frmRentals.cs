using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolRental_Controller;

namespace ToolRental_Win
{
    public partial class frmRentals : Form
    {
        #region VariableDeclearions

        private DataView _RentalsTable = null;

        #endregion
        
        #region Consctuctors

        public frmRentals()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void frmRentals_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmRentals_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _RentalsTable.RowFilter = $"LastName LIKE '%{txtSearch.Text}%' or ToolType LIKE '%{txtSearch.Text}%'";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteEntry();
        }

        #endregion

        #region AccessorMethods

        private void PopulateGrid()
        {
            String sqlQuery = "SELECT  Rentals.RentalID, Members.LastName, Members.FirstName, " +
                              "Workspaces.WorkspaceName, Tools.ToolType, Brands.BrandName " +
                              "FROM Rentals INNER JOIN " +
                              "Members ON Rentals.MemberID = Members.MemberID INNER JOIN " +
                              "Tools ON Rentals.ToolID = Tools.ToolID INNER JOIN " +
                              "Workspaces ON Rentals.WorkspaceID = Workspaces.WorkspaceID INNER JOIN " +
                              "Brands on Tools.BrandID = Brands.BrandID ";

            DataTable dtb = Context.GetDataTable(sqlQuery, "Rentals");

            _RentalsTable = new DataView(dtb);

            dgvRentals.DataSource = _RentalsTable;
            dgvRentals.Columns["RentalID"].Visible = false;
            dgvRentals.Columns["Comments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        #endregion

        #region MutatorMethods

        private void DeleteEntry()
        {
            if (dgvRentals.CurrentCell == null)
            {
                return;
            }
            if (MessageBox.Show("Delete This Rental Entry?", "Delete Rental Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                long PKID = long.Parse(dgvRentals[0, dgvRentals.CurrentCell.RowIndex].Value.ToString());
                Context.DeleteRecord("Rentals", "RentalID", $"{PKID}");

                PopulateGrid();
            }
        }

        #endregion
    }
}
