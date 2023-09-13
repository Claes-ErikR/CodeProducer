using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Utte.Code.Controls;
using Utte.Controls.Input;

namespace Utte.Code
{

    /// <summary>
    /// Main form for creating code
    /// </summary>
    public partial class GeneralStructForm : BaseForm
    {

        #region Private/protected members

        protected string _basefilepath;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes form
        /// </summary>
        public GeneralStructForm()
        {
            InitializeComponent();
            _basefilepath = ProgramData.BaseFolder;
            visStructVisibility.Initialize();
            chkStructConstructor.Checked = true;
            chkStructEqualityComparison.Checked = true;
            chkIncludeEmpty.Checked = true;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Produces a struct
        /// </summary>
        public override void Produce()
        {
            if (sStructName.Valid)
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = _basefilepath;
                    sfd.FileName = sStructName.Text;
                    sfd.DefaultExt = "txt";
                    DialogResult result = sfd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        List<StructMember> members = new List<StructMember>();
                        foreach (StructMember member in lstStructMembers.Items)
                            members.Add(member);
                        List<string> operatorclasses = new List<string>();
                        if (chkArithmeticOperators.Checked)
                            operatorclasses.Add(sStructName.Text);
                        if (chkArithmeticOperatorsVsDouble.Checked)
                            operatorclasses.Add("double");
                        if (chkArithmeticOperatorsVsInt.Checked)
                            operatorclasses.Add("int");
                        using (StructProducer newstruct = new StructProducer(sStructName.Text, txtStructDescription.Text, visStructVisibility.Value.ToString(), members, chkStructConstructor.Checked, chkStructEqualityComparison.Checked, chkIncludeEmpty.Checked, sfd.FileName, operatorclasses, chkImplementDeconstruct.Checked))
                        {
                            newstruct.Produce();
                        }
                        ShowTextFile(sfd.FileName);
                    }
                }
        }

        #endregion

        #region Private/protected methods

        /// <summary>
        /// Adds a struct member to the listbox of struct members
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdMember_Click(object sender, EventArgs e)
        {
            ObjectInitializer oi = new ObjectInitializer();
            StructMember member = new StructMember();
            member.ReadOnly = true;
            oi.InitializeForm("Add struct member", member);
            DialogResult result = oi.ShowDialog();
            if (result == DialogResult.OK)
            {
                member = (StructMember)oi.Value;
                lstStructMembers.Items.Add(member);
            }
            oi.Dispose();
        }

        /// <summary>
        /// Deletes a struct member to the listbox of struct members
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (lstStructMembers.SelectedIndex >= 0)
                lstStructMembers.Items.RemoveAt(lstStructMembers.SelectedIndex);
        }

        #endregion

    }
}