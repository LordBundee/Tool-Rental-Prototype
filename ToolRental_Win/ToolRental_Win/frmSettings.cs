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
    public partial class frmSettings : Form
    {

        #region Constructors

        public frmSettings()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            selectColorTheme();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSettings_Activated(object sender, EventArgs e)
        {
            //read property settings of ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        #endregion

        #region MutatorMehods

        /// <summary>
        /// This method opens the color picker to allow user to pick system background color and then saves selected color 
        /// into the program settings to be initiated during each formActivated event within the program.
        /// </summary>
        private void selectColorTheme()
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)//Check if changed
            {
                //Change property settings of ColourTheme
                Properties.Settings.Default.ColorTheme = colorDialog.Color;
                Properties.Settings.Default.Save();

                //read new property settings of ColourTheme
                this.BackColor = Properties.Settings.Default.ColorTheme;
            }
        }

        #endregion

    }
}
