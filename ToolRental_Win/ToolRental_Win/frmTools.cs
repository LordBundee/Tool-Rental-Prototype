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
    public partial class frmTools : Form
    {

        #region Variable Declarations

        DataView _dvTools = null;

	    #endregion

        #region Constructors

        public frmTools()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void frmTools_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmTools_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _dvTools.RowFilter = $"Tooltype LIKE '%{txtSearch.Text}%' or BrandName LIKE '%{txtSearch.Text}%'";
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            frmTool frm = new frmTool();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateGrid();
            }
        }

        private void dgvTools_DoubleClick(object sender, EventArgs e)
        {
            if (dgvTools.CurrentCell == null)
            {
                return;
            }

            long PKID = long.Parse(dgvTools[0, dgvTools.CurrentCell.RowIndex].Value.ToString());
            frmTool frm = new frmTool(PKID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateGrid();
            }
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            frmBrands frm = new frmBrands();
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteEntry();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Accessor Methods

        private void PopulateGrid()
        {
            String sqlQuery = "SELECT  Tools.ToolID, Tools.ToolType, Brands.BrandName,  "+
                              "ToolStatusTypes.Status, Tools.Comments " +
                              "FROM Tools " +
                              "INNER JOIN "+
                              "ToolStatusTypes ON Tools.StatusID = ToolStatusTypes.StatusID "+
                              "INNER JOIN Brands ON Tools.BrandID = Brands.BrandID " +
                              "ORDER BY BrandName ASC ";

            DataTable dtb = Context.GetDataTable(sqlQuery, "Tools");

            _dvTools = new DataView(dtb);

            dgvTools.DataSource = _dvTools;
            dgvTools.Columns["ToolID"].Visible = false;
            dgvTools.Columns["Comments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        #endregion

        #region Mutator Methods

        private void DeleteEntry()
        {
            if (dgvTools.CurrentCell == null)
            {
                return;
            }
            if (MessageBox.Show("Delete This Tool?", "Delete Tool", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                long PKID = long.Parse(dgvTools[0, dgvTools.CurrentCell.RowIndex].Value.ToString());
                Context.DeleteRecord("Tools", "ToolID", $"{PKID}");

                PopulateGrid();
            }
        }
        #endregion
    }
}
