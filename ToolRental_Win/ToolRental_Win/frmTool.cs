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
    public partial class frmTool : Form
    {

        #region Variable Declarations

        long _PKID = 0;
        DataTable _ToolTable = null;
        bool _isNew = false;

        #endregion

        #region Constructors

        public frmTool()
        {
            InitializeComponent();
            _isNew = true;
            InitialiseDataTables();
        }

        public frmTool(long pkid)
        {
            InitializeComponent();
            _PKID = pkid;
            InitialiseDataTables();
        }

        #endregion

        #region Events

        private void frmTool_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmTool_Load(object sender, EventArgs e)
        {
            SetupComboBoxes();
            BindControls();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEntry();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtToolType.Focus();
            cboStatus.Focus();
            txtToolType.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region AccessorMethods

        private void InitialiseDataTables()
        {

            string sqlToolQuery = $"Select * FROM Tools WHERE ToolID = {_PKID}";
            //Get an existing movie record based on Primary Key(_PKID) and allow it to be updated
            _ToolTable = ToolRental_Controller.Context.GetDataTable(sqlToolQuery, "Tools");

            if (_isNew)
            {
                DataRow row = _ToolTable.NewRow();
                _ToolTable.Rows.Add(row);
            }
        }

        #endregion

        #region MutatorMethods

        private void SaveEntry()
        {
            if (_ToolTable.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(_ToolTable.Rows[0]["StatusID"].ToString()))
                {
                    _ToolTable.Rows[0]["StatusID"] = cboStatus.SelectedValue;
                }
                //ALWAYS Do the end EndEdit of the row, otherwise the data will not persist

                _ToolTable.Rows[0].EndEdit();

                //Call the method in our context class to save the changes to the SQL table
                ToolRental_Controller.Context.SaveDatabaseTable(_ToolTable);

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
            
            txtToolType.DataBindings.Add("Text", _ToolTable, "ToolType");
            txtComments.DataBindings.Add("Text", _ToolTable, "Comments");
            cboBrand.DataBindings.Add("SelectedValue", _ToolTable, "BrandID");
            cboStatus.DataBindings.Add("SelectedValue", _ToolTable, "StatusID");


            if (_isNew)
            {
                cboBrand.SelectedIndex = -1;
                cboStatus.SelectedIndex = 0;
            }
        }

        private void SetupComboBoxes()
        {
            SetupBrandComboBox();
            SetupStatusComboBox();

        }

        private void SetupBrandComboBox()
        {
            //Create Datatble as source for combo box
            DataTable _BrandTable = new DataTable();
            string sqlQuery = "SELECT * FROM Brands ORDER BY BrandName ASC ";
            _BrandTable = Context.GetDataTable(sqlQuery, "Brands");

            //Set the value Member
            cboBrand.ValueMember = "BrandID";

            //Set the DisplayMember
            cboBrand.DisplayMember = "BrandName";

            //Set the data source of the combo box by using the data table created above
            cboBrand.DataSource = _BrandTable;
        }

        private void SetupStatusComboBox()
        {
            DataTable _StatusTable = new DataTable();
            string sqlQuery = "SELECT * From ToolStatusTypes ORDER BY Status ASC ";
            _StatusTable = Context.GetDataTable(sqlQuery, "ToolStatusTypes");

            //Set the value Member
            cboStatus.ValueMember = "StatusID";

            //Set the DisplayMember
            cboStatus.DisplayMember = "Status";

            //Set the data source of the combo box by using the data table created above
            cboStatus.DataSource = _StatusTable;

        }

        #endregion
    }
}
