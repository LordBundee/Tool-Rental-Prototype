using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolRental_Win
{
    public partial class frmReports : Form
    {
        #region Variable Declarations

        private DataView _ToolTable = null;

        #endregion

        #region Constructors

        public frmReports()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void frmReports_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            InitialiseDataTable();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportUsingStringBuilder();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkRetired_Click(object sender, EventArgs e)
        {
            if (chkRetired.Checked)
            {
                chkActive.Checked = false;
                chkAll.Checked = false;
                chkAtRepair.Checked = false;
                chkOnRental.Checked = false;
                chkWaiting.Checked = false;

                _ToolTable.RowFilter = $"Status LIKE '%Retired%'";
            }
            else
            {
                chkRetired.Checked = true;
            }
        }

        private void chkAll_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkActive.Checked = false;
                chkAtRepair.Checked = false;
                chkOnRental.Checked = false;
                chkRetired.Checked = false;
                chkWaiting.Checked = false;

                _ToolTable.RowFilter = string.Empty;
            }
            else
            {
                chkAll.Checked = true;
            }
        }

        private void chkActive_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                chkAll.Checked = false;
                chkAtRepair.Checked = false;
                chkOnRental.Checked = false;
                chkRetired.Checked = false;
                chkWaiting.Checked = false;

                _ToolTable.RowFilter = $"Status LIKE '%Active%'";
            }
            else
            {
                chkActive.Checked = true;
            }
        }

        private void chkWaiting_Click(object sender, EventArgs e)
        {
            if (chkWaiting.Checked)
            {
                chkActive.Checked = false;
                chkAll.Checked = false;
                chkAtRepair.Checked = false;
                chkOnRental.Checked = false;
                chkRetired.Checked = false;

                _ToolTable.RowFilter = $"Status LIKE '%Awaiting%'";
            }
            else
            {
                chkWaiting.Checked = true;
            }
        }

        private void chkAtRepair_Click(object sender, EventArgs e)
        {
            if (chkAtRepair.Checked)
            {
                chkActive.Checked = false;
                chkAll.Checked = false;
                chkOnRental.Checked = false;
                chkRetired.Checked = false;
                chkWaiting.Checked = false;

                _ToolTable.RowFilter = $"Status LIKE '%On Repair%'";
            }
            else
            {
                chkAtRepair.Checked = true;
            }
        }

        private void chkOnRental_Click(object sender, EventArgs e)
        {
            if (chkOnRental.Checked)
            {
                chkActive.Checked = false;
                chkAll.Checked = false;
                chkRetired.Checked = false;
                chkWaiting.Checked = false;
                chkAtRepair.Checked = false;

                _ToolTable.RowFilter = $"Status LIKE '%Rental%'";
            }
            else
            {
                chkOnRental.Checked = true;
            }
        }

        #endregion

        #region Accessor Methods

        private void InitialiseDataTable()
        {

            string sqlToolQuery =   "SELECT Tools.ToolID, Tools.ToolType, Brands.BrandName, " +
                                    "ToolStatusTypes.Status, Tools.Comments " +
                                    "FROM Tools " +
                                    "INNER JOIN Brands ON Brands.BrandID = Tools.BrandID " +
                                    "INNER JOIN ToolStatusTypes ON ToolStatusTypes.StatusID = Tools.StatusID ";

            //Get an existing movie record based on Primary Key(_PKID) and allow it to be updated
            DataTable dtb = ToolRental_Controller.Context.GetDataTable(sqlToolQuery, "Tools");

            _ToolTable = new DataView(dtb);
            dgvTools.DataSource = _ToolTable;
            dgvTools.Columns["Comments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }


        #endregion

        #region Mutator Methods

        private void ExportUsingStringBuilder()
        {
            StringBuilder csv = new StringBuilder();

            foreach (DataRowView drv in _ToolTable)
            {
                csv.AppendLine($"{drv["ToolID"].ToString()}, " +
                                  $"{drv["ToolType"].ToString()}, " +
                                  $"{drv["BrandName"].ToString()}, " +
                                  $"{drv["Status"].ToString()}, " +
                                  $"{drv["Comments"].ToString()}");

            }

            File.WriteAllText(Application.StartupPath + @"\ToolReport.csv", csv.ToString());
            MessageBox.Show("Export Completed", "Tool Rental");
        }



        #endregion

    }
}
