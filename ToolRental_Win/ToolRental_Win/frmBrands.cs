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
    public partial class frmBrands : Form
    {
                
        #region VariableDeclarations

        DataView _BrandTable = null;


        #endregion

        #region Consrtructors

        public frmBrands()
        {
            InitializeComponent();
            PopulateGrid();
        }

        #endregion

        #region Events

        private void frmBrands_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            frmAddBrand frm = new frmAddBrand();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteEntry();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _BrandTable.RowFilter = $"BrandName LIKE '%{txtSearch.Text}%'";
        }

        private void dgvBrands_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBrands.CurrentCell == null)
            {
                return;
            }

            long PKID = long.Parse(dgvBrands[0, dgvBrands.CurrentCell.RowIndex].Value.ToString());
            frmAddBrand frm = new frmAddBrand(PKID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateGrid();
            }
        }

        #endregion

        #region AccessorMethods

        private void PopulateGrid()
        {
            String sqlQuery = "SELECT * FROM Brands ORDER BY BrandName ASC";

            DataTable dtb = Context.GetDataTable(sqlQuery, "Brands");

            _BrandTable = new DataView(dtb);

            dgvBrands.DataSource = _BrandTable;
            dgvBrands.Columns["BrandID"].Visible = false;
            dgvBrands.Columns["Brandname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        #endregion

        #region MutatorMethods

        private void DeleteEntry()
        {
            if (dgvBrands.CurrentCell == null)
            {
                return;
            }
            if (MessageBox.Show("Delete This Brand?", "Delete Brand", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                long PKID = long.Parse(dgvBrands[0, dgvBrands.CurrentCell.RowIndex].Value.ToString());
                Context.DeleteRecord("Brands", "BrandID", $"{PKID}");

                PopulateGrid();
            }
        }

        #endregion


    }
}
