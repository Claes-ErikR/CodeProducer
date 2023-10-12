using System;
using System.Collections.Generic;
using System.Windows.Forms;
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

            foreach (string Interface in CodeGeneratorBase.ImplementedInterfaces)
                lstImplementedInterfaces.Items.Add(Interface);
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
                        List<Member> members = new List<Member>();
                        foreach (StructMember member in lstStructMembers.Items)
                            members.Add(new Member() {
                                IsStructMember = true,
                                Name = member.Name,
                                ValueIsNullable = member.IsNullable,
                                ReadOnly = member.ReadOnly,
                                Type = member.Type,
                                Static = false,
                                Public = true,
                                PrivateProtected = false,
                                ConstructorSet = chkStructConstructor.Checked,
                            });
                        using (StructProducer newstruct = new StructProducer(sStructName.Text, txtStructDescription.Text, visStructVisibility.Value.ToString(), members, chkStructConstructor.Checked, sfd.FileName))
                        {
                            newstruct.EnsureToStringImplemented();
                            if (chkStructEqualityComparison.Checked)
                                newstruct.ImplementEqualityComparison();
                            if (chkIncludeEmpty.Checked)
                                newstruct.ImplementEmptyInstance(chkStructEqualityComparison.Checked);
                            if (chkArithmeticOperators.Checked)
                                newstruct.AddOperatorClass(sStructName.Text);
                            if (chkArithmeticOperatorsVsDouble.Checked)
                                newstruct.AddOperatorClass("double");
                            if (chkArithmeticOperatorsVsInt.Checked)
                                newstruct.AddOperatorClass("int");
                            if (chkImplementDeconstruct.Checked)
                                newstruct.ImplementDeconstruct();
                            if (chkStructComparisonImplementation.Checked)
                                newstruct.ImplementSortComparison();

                            newstruct.AddImplementedInterfaces(GetImplementedInterfaces());

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

        /// <summary>
        /// Returns a list of added implemented interfaces
        /// </summary>
        /// <returns></returns>
        private List<string> GetImplementedInterfaces()
        {
            List<string> Interfaces = new List<string>();
            ListBox.SelectedObjectCollection SelectedInterfaces = lstImplementedInterfaces.SelectedItems;
            foreach (object Interface in SelectedInterfaces)
                Interfaces.Add(Interface.ToString());
            return Interfaces;
        }

        #endregion

        /// <summary>
        /// Struct for managing a member of a struct
        /// </summary>
        private struct StructMember
        {

            #region Public members

            public string Name;
            public string Type;
            public bool ReadOnly;
            public bool IsNullable;

            #endregion

            #region Public methods

            /// <summary>
            /// Returns string representation of the struct
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                string isNullableText = IsNullable ? "?" : "";
                if (ReadOnly)
                    return Name + " " + Type + isNullableText + " readonly";
                return Name + " " + Type + isNullableText;
            }

            #endregion

        }
    }
}