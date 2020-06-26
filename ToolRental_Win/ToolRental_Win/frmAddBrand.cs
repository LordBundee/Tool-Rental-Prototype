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
    public partial class frmAddBrand : Form
    {
        #region VariableDeclarations

        DataTable _BrandTable = null;
        private bool isNew = false;
        private long _PKID;

        #endregion

        #region Constructors

        public frmAddBrand()
        {
            InitializeComponent();
            isNew = true;
            InitialiseDatatable();
            BindControls();
        }

        public frmAddBrand(long PKID)
        {
            InitializeComponent();
            _PKID = PKID;
            isNew = false;
            InitialiseDatatable();
            BindControls();
        }

        #endregion

        #region Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveNewBrand();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Accessor Methods

        private void InitialiseDatatable()
        {
            String sqlQuery = $"SELECT * FROM Brands WHERE BrandID = {_PKID}";

            _BrandTable = Context.GetDataTable(sqlQuery, "Brands");

            if (isNew)
            {
                DataRow row = _BrandTable.NewRow();
                row["BrandID"] = -1;
                _BrandTable.Rows.Add(row);
            }

        }

        #endregion

        #region Mutator Methods

        private void SaveNewBrand()
        {
            if (_BrandTable.Rows.Count > 0)
            {
                
                _BrandTable.Rows[0].EndEdit();
                ToolRental_Controller.Context.SaveDatabaseTable(_BrandTable);

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
            txtBrand.DataBindings.Add("Text", _BrandTable, "BrandName");
        }

        #endregion




    }
}
