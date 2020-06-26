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
    public partial class frmMemberSelect : Form
    {

        #region VariableDeclarations

        public string memberName;
        public string memberPhone;
        public long memberID;

        private DataView _MemberTable = null;

        #endregion

        #region Constructors

        public frmMemberSelect()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMemberSelect_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _MemberTable.RowFilter = $"LastName LIKE '%{txtSearch.Text}%' or PhoneNumber LIKE '%{txtSearch.Text}%'";
        }

        private void dgvMemberSelect_DoubleClick(object sender, EventArgs e)
        {
            long PKID = long.Parse(dgvMemberSelect[0, dgvMemberSelect.CurrentCell.RowIndex].Value.ToString());
            frmNewRental frm = new frmNewRental(PKID);
            frm.ShowDialog();
            this.Close();
        }

        private void btnSelectMember_Click(object sender, EventArgs e)
        {
            if (dgvMemberSelect.CurrentCell == null)
            {
                return;
            }

            long PKID = long.Parse(dgvMemberSelect[0, dgvMemberSelect.CurrentCell.RowIndex].Value.ToString());
            frmNewRental frm = new frmNewRental(PKID);
            frm.ShowDialog();
            this.Close();
        }

        #endregion

        #region AccessorMethods

        private void PopulateGrid()
        {
            String sqlQuery = "SELECT * FROM Members " +
                              "ORDER BY LastName ASC ";

            DataTable dtb = Context.GetDataTable(sqlQuery, "Members");

            _MemberTable = new DataView(dtb);

            dgvMemberSelect.DataSource = _MemberTable;
            dgvMemberSelect.Columns["MemberID"].Visible = false;
        }

        #endregion

    }
}
