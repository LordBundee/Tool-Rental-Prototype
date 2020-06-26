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
    public partial class frmWorkspace : Form
    {
        #region mVariable declarations

        private long _PKID;
        private DataTable _SpacesTable = null;
        private bool _isNew = false;

        #endregion
        
        #region Constructors

        public frmWorkspace()
        {
            InitializeComponent();
            _isNew = true;
            InitialiseDataTables();
        }

        public frmWorkspace(long pkid)
        {
            InitializeComponent();
            _PKID = pkid;
            InitialiseDataTables();
        }

        #endregion

        #region Events

        private void frmWorkspace_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmWorkspace_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEntry();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region AccessorMethods

        private void InitialiseDataTables()
        {

            string sqlToolQuery = $"Select * FROM Workspaces WHERE WorkspaceID = {_PKID}";
            //Get an existing movie record based on Primary Key(_PKID) and allow it to be updated
            _SpacesTable = ToolRental_Controller.Context.GetDataTable(sqlToolQuery, "Workspaces");

            if (_isNew)
            {
                DataRow row = _SpacesTable.NewRow();
                _SpacesTable.Rows.Add(row);
            }
        }


        #endregion

        #region MutatorMethods

        private void SaveEntry()
        {
            if (_SpacesTable.Rows.Count > 0)
            {
                //ALWAYS Do the end EndEdit of the row, otherwise the data will not persist

                _SpacesTable.Rows[0].EndEdit();

                //Call the method in our context class to save the changes to the SQL table
                ToolRental_Controller.Context.SaveDatabaseTable(_SpacesTable);

                this.Close();
            }
            else
            {
                MessageBox.Show("No Record Exists");
            }
        }

        #endregion

        #region HelperMethods

        private void BindControls()
        {
            txtWorkspaceName.DataBindings.Add("Text", _SpacesTable, "WorkspaceName");
        }

        #endregion
    }
}
