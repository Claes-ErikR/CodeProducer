using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utte.Code;

namespace Utte.Code.Controls
{

    /// <summary>
    /// Form to set values for
    /// </summary>
    public partial class DialogMember : Form
    {

        #region Private/protected members

        Member _value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the form
        /// </summary>
        public DialogMember()
        {
            InitializeComponent();
            txtName.Text="";
            tcType.Initialize();
            txtDescription.Text="";
            chkPrivateProtected.Checked=true;
            chkStatic.Checked=false;
            chkGetProperty.Checked=true;
            chkSetProperty.Checked=true;
            chkProtectedSetProperty.Checked = false;
            chkConstructorSet.Checked=false;
            chkValueType.Checked=false;
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
            if (Valid)
            {
                _value = new Member();
                _value.Name = txtName.Text;
                _value.Type = tcType.Text;
                _value.Description = txtDescription.Text;
                _value.PrivateProtected = chkPrivateProtected.Checked;
                _value.Static = chkStatic.Checked;
                _value.GetProperty = chkGetProperty.Checked;
                _value.SetProperty = chkSetProperty.Checked;
                _value.ProtectedSetProperty = chkProtectedSetProperty.Checked;
                _value.ConstructorSet = chkConstructorSet.Checked;
                _value.ValueType = chkValueType.Checked;
                _value.ValueIsNullable = chkPropertyIsNullable.Checked;
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Invalid input");
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
        /// Adds attributes to the member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddAttributes_Click(object sender, EventArgs e)
        {
            frmAttributeAddition faa = new frmAttributeAddition();
            DialogResult result = faa.ShowDialog();
            if (result == DialogResult.OK)
                if (faa.Value.Count > 0)
                    _value.Attributes = faa.Value;
            faa.Dispose();
        }

        /// <summary>
        /// Unchecks protected version if unprotected is true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSetProperty_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSetProperty.Checked)
                chkProtectedSetProperty.Checked = false;
        }

        /// <summary>
        /// Unchecks unprotected version if protected is true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkProtectedSetProperty_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProtectedSetProperty.Checked)
                chkSetProperty.Checked = false;
        }

        /// <summary>
        /// Sets value type box when type is chosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcType_TextChanged(object sender, EventArgs e)
        {
            if (tcType.IsValueType)
            {
                chkValueType.Checked = true;
                chkValueType.Enabled = false;
            }
            else
            {
                chkValueType.Checked = false;
                chkValueType.Enabled = true;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the value of the form
        /// </summary>
        public Member Value
        {
            get
            {
                return _value;
            }
        }

        /// <summary>
        /// Returns true if the input in the form is valid
        /// </summary>
        public bool Valid
        {
            get
            {
                return txtName.Text!="" && tcType.Valid;
            }
        }

        #endregion

    }
}