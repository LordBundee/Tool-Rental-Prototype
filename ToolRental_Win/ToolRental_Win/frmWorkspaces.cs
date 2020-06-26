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
    public partial class frmWorkspaces : Form
    {

        #region variable Declarations

        private DataView _dvWorkspaces = null;

        #endregion

        #region Constructors

        public frmWorkspaces()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void frmWorkspaces_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmWorkspaces_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _dvWorkspaces.RowFilter = $"WorkspaceName LIKE '%{txtSearch.Text}%'";
        }

        private void dgvWorkspaces_DoubleClick(object sender, EventArgs e)
        {
            if (dgvWorkspaces.CurrentCell == null)
            {
                return;
            }

            long PKID = long.Parse(dgvWorkspaces[0, dgvWorkspaces.CurrentCell.RowIndex].Value.ToString());
            frmWorkspace frm = new frmWorkspace(PKID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmWorkspace frm = new frmWorkspace();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateGrid();
            }
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
            string sqlQuery = " SELECT * FROM Workspaces " +
                              " ORDER BY WorkspaceName ASC ";

            DataTable dtb = Context.GetDataTable(sqlQuery, "Workspaces");

            _dvWorkspaces = new DataView(dtb);

            dgvWorkspaces.DataSource = _dvWorkspaces;
            dgvWorkspaces.Columns["WorkspaceID"].Visible = false;
            dgvWorkspaces.RowHeadersVisible = false;
            dgvWorkspaces.ColumnHeadersVisible = false;
            dgvWorkspaces.Columns["WorkspaceName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }



        #endregion

        #region MutatorMethods

        private void DeleteEntry()
        {
            if (dgvWorkspaces.CurrentCell == null)
            {
                return;
            }
            if (MessageBox.Show("Delete This Brand?", "Delete Brand", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                long PKID = long.Parse(dgvWorkspaces[0, dgvWorkspaces.CurrentCell.RowIndex].Value.ToString());
                Context.DeleteRecord("Workspaces", "WorkspaceID", $"{PKID}");

                PopulateGrid();
            }
        }

        #endregion


    }
}
