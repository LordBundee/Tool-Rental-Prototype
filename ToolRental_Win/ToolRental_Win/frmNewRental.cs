using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolRental_Controller;

namespace ToolRental_Win
{
    public partial class frmNewRental : Form
    {
        #region Variable Declarations

        private long _PKID;
        private DataTable _MemberTable = null;
        private DataTable _OnRentalTable = null;
        private DataTable _WorkspacesTable = null;
        private DataView _ToolsTable = null;

        #endregion
      
        #region Constructors

        public frmNewRental(long pkid)
        {
            InitializeComponent();
            _PKID = pkid;
            InitialiseDataTables();
        }

        #endregion

        #region Events

        private void frmNewRental_Load(object sender, EventArgs e)
        {
            SetupComboBox();
            BindControls(); 
        }

        private void btnAddTool_Click(object sender, EventArgs e)
        {
            if (cboWorkspaces.SelectedIndex != -1)
            {
                long ToolID = 0;
                try
                {
                    ToolID = int.Parse(dgvAvailableTools[dgvAvailableTools.Columns["ToolID"].Index, dgvAvailableTools.CurrentCell.RowIndex].Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please select valid tool first!");
                    ToolID = 0;
                }

                if (ToolID != 0)
                {
                    AddToolToAccout();
                }
            }
            else
            {
                MessageBox.Show("Please select a workspace before proceeding!");
            }
        }

        private void btnReturnTool_Click(object sender, EventArgs e)
        {
            long ToolID = 0;
            try
            {
                Debugger.Break();
                ToolID = int.Parse(dgvAvailableTools[dgvAvailableTools.Columns["ToolID"].Index, dgvAvailableTools.CurrentCell.RowIndex].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select valid tool first!");
                ToolID = 0;
            }

            if (ToolID != 0)
            {
                RemoveToolFromAccount();
            }
        }

        private void dgvAvailableTools_DoubleClick(object sender, EventArgs e)
        {
            if (cboWorkspaces.SelectedIndex != -1)
            {
                long ToolID = 0;
                try
                {
                    ToolID = int.Parse(dgvAvailableTools[dgvAvailableTools.Columns["ToolID"].Index, dgvAvailableTools.CurrentCell.RowIndex].Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please select valid tool first!");
                    ToolID = 0;
                }
                if (ToolID != 0)
                {
                    AddToolToAccout();
                }
            }
            else
            {
                MessageBox.Show("Please select a workspace before proceeding!");
            }
        }

        private void dgvCurrent_DoubleClick(object sender, EventArgs e)
        {
            long ToolID = 0;
            try
            {
                ToolID = int.Parse(dgvAvailableTools[dgvAvailableTools.Columns["ToolID"].Index, dgvAvailableTools.CurrentCell.RowIndex].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select valid tool first!");
                ToolID = 0;
            }

            if (ToolID != 0)
            {
                RemoveToolFromAccount();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ToolsTable.RowFilter = $"Tooltype LIKE '%{txtSearch.Text}%' or BrandName LIKE '%{txtSearch.Text}%'";
        }

        private void frmNewRental_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        #endregion

        #region Accessor Methods

        private void InitialiseDataTables()
        {
            InitialiseMembersTable();
            InitialiseOnAccountTable();
            InitialiseAvailableToolsTable();
        }

        private void InitialiseMembersTable()
        {
            string sqlQuery = $"Select * FROM Members WHERE MemberID = {_PKID}";
            //Get an existing movie record based on Primary Key(_PKID) and allow it to be updated
            _MemberTable = ToolRental_Controller.Context.GetDataTable(sqlQuery, "Members");
        }

        private void InitialiseOnAccountTable()
        {
            string sqlQuery =   "SELECT Rentals.RentalID, Tools.ToolID, Tools.ToolType, Brands.BrandName "+
                                "FROM Rentals INNER JOIN "+
                                "Tools ON Rentals.ToolID = Tools.ToolID INNER JOIN "+
                                "Brands ON Tools.BrandID = Brands.BrandID "+
                                $"WHERE Rentals.MemberID = {_PKID} and Rentals.DateReturned is null ";

            _OnRentalTable = ToolRental_Controller.Context.GetDataTable(sqlQuery, "Tools");
            dgvCurrent.DataSource = _OnRentalTable;
            dgvCurrent.Columns["ToolID"].Visible = false;
            dgvCurrent.Columns["RentalID"].Visible = false;
        }

        private void InitialiseAvailableToolsTable()
        {
            string sqlQuery =   "SELECT Tools.ToolID, Tools.ToolType, Brands.BrandName " +
                                "FROM Brands INNER JOIN " +
                                "Tools ON Brands.BrandID = Tools.BrandID " +
                                "WHERE StatusID = 1 " ;

            DataTable dtb = ToolRental_Controller.Context.GetDataTable(sqlQuery, "Tools");
            _ToolsTable = new DataView(dtb);
            dgvAvailableTools.DataSource = _ToolsTable;
            dgvAvailableTools.Columns["ToolID"].Visible = false;
            
        }

        #endregion

        #region Helper Methods

        private void BindControls()
        {
            lblID.DataBindings.Add("Text", _MemberTable, "MemberID");
            lblName.DataBindings.Add("Text", _MemberTable, "FirstName");
            lblSurname.DataBindings.Add("Text", _MemberTable, "LastName");
            lblPhone.DataBindings.Add("Text", _MemberTable, "PhoneNumber");
            //cboWorkspaces.DataBindings.Add("SelectedValue", _WorkspacesTable, "WorkspaceID");
            cboWorkspaces.SelectedIndex = -1;
        }

        private void SetupComboBox()
        {
            //Create Datatble as source for combo box
            string sqlQuery = "SELECT * FROM Workspaces ORDER BY WorkspaceID ASC ";
            _WorkspacesTable = Context.GetDataTable(sqlQuery, "Workspaces");

            //Set the value Member
            cboWorkspaces.ValueMember = "WorkspaceID";

            //Set the DisplayMember
            cboWorkspaces.DisplayMember = "WorkspaceName";

            //Set the data source of the combo box by using the data table created above
            cboWorkspaces.DataSource = _WorkspacesTable;
        }

        #endregion

        #region MutatorMethods
        
        private void AddToolToAccout()
        {

            if (MessageBox.Show("Add this tool to account?", "Add Tool", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                long toolID = long.Parse(dgvAvailableTools[0, dgvAvailableTools.CurrentCell.RowIndex].Value.ToString());
                string dateRented = DateTime.Today.ToString("yyyy/MM/dd");
                long memberID = _PKID;
                long workSpaceID = cboWorkspaces.SelectedIndex + 1;

                string columnNames = "MemberID, WorkspaceID, ToolID, DateRented, DateReturned";
                string columnValues = $"{memberID}, {workSpaceID}, {toolID}, '{dateRented}', null";

                Context.InsertParentTable("Rentals", columnNames, columnValues);

                Context.UpdateRecord("Tools", "StatusID = 2", $"ToolID = {toolID}");
              
                InitialiseDataTables();
            }
        }

        /// <summary>
        /// This Method retrieves the RentalID and ToolID from the selected Tool in the DataGridView and then updates
        /// both the relevant database tables to set a DateReturned value on the Rental Table and sets the Tool's Status
        /// back to active on the Tools Table.
        /// </summary>
        public void RemoveToolFromAccount()
        {
            if (MessageBox.Show("Remove this tool from account?", "Return Tool", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                long rentalID = long.Parse(dgvCurrent[dgvCurrent.Columns["RentalID"].Index, dgvCurrent.CurrentCell.RowIndex].Value.ToString());
                long toolID = long.Parse(dgvCurrent[dgvCurrent.Columns["ToolID"].Index, dgvCurrent.CurrentCell.RowIndex].Value.ToString());
                string dateReturned = DateTime.Today.ToString("yyyy-MM-dd");

                Context.UpdateRecord("Rentals", $"DateReturned = '{dateReturned}'", $"RentalID = {rentalID}");
                Context.UpdateRecord("Tools", "StatusID = 1", $"ToolID = {toolID}");

                InitialiseDataTables();
            }
        }

        #endregion
    }
}
