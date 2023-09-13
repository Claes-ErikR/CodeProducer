using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Utte.Code.Controls
{

    /// <summary>
    /// Form to set values for attribute list
    /// </summary>
    public partial class frmAttributeAddition : Form
    {

        #region Private/protected members

        List<string> _value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the form
        /// </summary>
        public frmAttributeAddition()
        {
            InitializeComponent();
            _value = new List<string>();
        }

        #endregion

        #region Private/protected methods

        /// <summary>
        /// Ok-button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (bBrowsable.Checked)
                _value.Add("Browsable(false)");
            if (!string.IsNullOrEmpty(cbCategory.SelectedItem.ToString()))
                _value.Add("Category(\"" + cbCategory.SelectedItem.ToString() + "\")");
            if(!string.IsNullOrEmpty(sDescription.Text))
                _value.Add("Description(\"" + sDescription.Text + "\")");
            foreach (string item in lstAttributes.Items)
                _value.Add(item);
            if (_value.Count == 0)
                _value = null;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Cancel-button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Adds an Attribute to the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddAttribute_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sAttribute.Text))
                lstAttributes.Items.Add(sAttribute.Text);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the value of the form
        /// </summary>
        public List<string> Value
        {
            get
            {
                return _value;
            }
        }

        #endregion

    }
}