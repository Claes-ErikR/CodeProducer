﻿using System;
using System.Windows.Forms;
using Utte.Code.Forms;

namespace Utte.Code
{

    /// <summary>
    /// Main form for codeproducer
    /// </summary>
    public partial class MainForm : Form
    {

        #region Private/protected members

        private int childFormNumber = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes components
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Classes

        /// <summary>
        /// Shows form for producing a general type of class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miGeneralClass_Click(object sender, EventArgs e)
        {
            ShowNewForm(new GeneralClassForm());
        }

        #endregion

        #region Structs

        /// <summary>
        /// Shows form for producing a general type of structs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miGeneralStruct_Click(object sender, EventArgs e)
        {
            ShowNewForm(new GeneralStructForm());
        }

        #endregion

        #region Tools

        /// <summary>
        /// Produces the code from active form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miProduce_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.ActiveMdiChild != null)
                    ((BaseForm)this.ActiveMdiChild).Produce();
                else
                    MessageBox.Show("Error, no form open?");
            }
            catch
            {
                MessageBox.Show("Unkown error");
            }
        }

        /// <summary>
        /// Displays box to manage settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miSettings_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ManageSettings();
                form.Initialize();
                form.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error showing settings");
            }
        }

        #endregion

        #region Windows

        /// <summary>
        /// Puts all childform in cascade style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// Puts all childform in vertical style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// Puts all childform in horizontal style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// Puts all childform in icon style
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        /// <summary>
        /// Close all open forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
                childForm.Close();
        }

        #endregion

        #region Help

        /// <summary>
        /// Shows help if available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void miHelp_Click(object sender, EventArgs e)
        {
            try
            {
                ((BaseForm)this.ActiveMdiChild).Help();
            }
            catch
            {
                MessageBox.Show("Error, no form open?");
            }
        }

        #endregion

        #region Support methods

        /// <summary>
        /// Shows new form
        /// </summary>
        /// <param name="form"></param>
        private void ShowNewForm(BaseForm form)
        {
            form.Initialize();
            form.MdiParent = this;
            form.Text = form.Text + " " + childFormNumber++;
            form.Show();
        }

        #endregion
    }
}
