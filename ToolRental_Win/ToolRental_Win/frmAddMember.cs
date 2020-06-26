using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolRental_Win
{
    public partial class frmAddMember : Form
    {

        #region Variable Declarations

        long _PKID = 0;
        DataTable _MemberTable = null;
        bool _isNew = false;

        #endregion

        #region Constructors

        public frmAddMember()
        {
            InitializeComponent();
            _isNew = true;
            InitialiseDatatables();
        }

        public frmAddMember(long pkid)
        {
            InitializeComponent();
            _PKID = pkid;
            InitialiseDatatables();
        }

        #endregion

        #region Events

        private void frmAddMember_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveNewMember();
        }

        private void frmAddMember_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region AccessorMethods

        private void InitialiseDatatables()
        {
            string sqlMemberQuery = $"Select * FROM members WHERE memberID = {_PKID}";
            //Get an existing movie record based on Primary Key(_PKID) and allow it to be updated
            _MemberTable = ToolRental_Controller.Context.GetDataTable(sqlMemberQuery, "Members");

            if (_isNew)
            {
                DataRow row = _MemberTable.NewRow();
                _MemberTable.Rows.Add(row);
            }
        }

        #endregion

        #region MutatorMethods

        private void SaveNewMember()
        {
            if (_MemberTable.Rows.Count > 0)
            {
                //ALWAYS Do the end EndEdit of the row, otherwise the data will not persist

                _MemberTable.Rows[0].EndEdit();

                //Call the method in our context class to save the changes to the SQL table
                ToolRental_Controller.Context.SaveDatabaseTable(_MemberTable);

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
            txtFirstName.DataBindings.Add("Text", _MemberTable, "FirstName");
            txtLastName.DataBindings.Add("Text", _MemberTable, "LastName");
            txtPhoneNumber.DataBindings.Add("Text", _MemberTable, "PhoneNumber");
        }

        #endregion



        

       

        
    }
}
