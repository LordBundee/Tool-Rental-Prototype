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
    public partial class frmMembers : Form
    {

        #region variable Declarations

        DataView _dvMembers = null;

        #endregion

        #region Constructors

        public frmMembers()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void frmCustomers_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddMember_Click_1(object sender, EventArgs e)
        {
            frmAddMember frm = new frmAddMember();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateGrid();
            }
        }

        private void dgvCustomers_DoubleClick(object sender, EventArgs e)
        {
            if (dgvMembers.CurrentCell == null)
            {
                return;
            }

            long PKID = long.Parse(dgvMembers[0, dgvMembers.CurrentCell.RowIndex].Value.ToString());
            frmAddMember frm = new frmAddMember(PKID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateGrid();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _dvMembers.RowFilter = $"LastName LIKE '%{txtSearch.Text}%' or PhoneNumber LIKE '%{txtSearch.Text}%'";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteEntry();
        }


        #endregion

        #region AccessorMethods

        private void PopulateGrid()
        {
            string sqlQuery = "SELECT  MemberID, LastName, FirstName, PhoneNumber " +
                              "FROM Members " +
                              "ORDER BY LastName ASC ";

            DataTable dtb = Context.GetDataTable(sqlQuery, "Members");

            _dvMembers = new DataView(dtb);

            dgvMembers.DataSource = _dvMembers;
            dgvMembers.Columns["MemberID"].Visible = false;
        }

        #endregion

        #region MutatorMethods

        private void DeleteEntry()
        {
            if (dgvMembers.CurrentCell == null)
            {
                return;
            }
            if (MessageBox.Show("Delete This Member Account?", "Delete Member Account", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                long PKID = long.Parse(dgvMembers[0, dgvMembers.CurrentCell.RowIndex].Value.ToString());
                Context.DeleteRecord("Members", "MemberID", $"{PKID}");

                PopulateGrid();
            }
        }

        #endregion
    }
}
