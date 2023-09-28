using System;
using System.Windows.Forms;

namespace Utte.Code.Forms
{

    /// <summary>
    /// Form to manage user settings
    /// </summary>
    public partial class ManageSettings : Form
    {

        /// <summary>
        /// Initializes form
        /// </summary>
        public ManageSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize user settings
        /// </summary>
        public void Initialize()
        {
            chkUseRegions.Checked = Settings.Default.UseRegions;
        }

        /// <summary>
        /// Save user settings and closes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.UseRegions = chkUseRegions.Checked;
            Settings.Default.Save();
            this.Close();
        }

        /// <summary>
        /// Cancel changes and closes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}