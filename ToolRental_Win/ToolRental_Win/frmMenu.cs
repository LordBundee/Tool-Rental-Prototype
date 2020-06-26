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
    public partial class frmMenu : Form
    {

        #region Constructors

        public frmMenu()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void frmMenu_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            frmTools frm = new frmTools();
            frm.ShowDialog();
        }

        private void btnNewRental_Click(object sender, EventArgs e)
        {
            frmMemberSelect frm = new frmMemberSelect();
            frm.ShowDialog();
        }

        private void btnWorkspaces_Click(object sender, EventArgs e)
        {
            frmWorkspaces frm = new frmWorkspaces();
            frm.ShowDialog();
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            frmRentals frm = new frmRentals();
            frm.ShowDialog();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            frmMembers frm = new frmMembers();
            frm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReports frm = new frmReports();
            frm.ShowDialog();
        }



        #endregion
    }
}
