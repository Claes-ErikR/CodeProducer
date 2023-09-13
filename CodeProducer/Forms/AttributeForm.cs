using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utte.Code.Controls;
using Utte.Controls.Input;
using System.IO;
using System.Diagnostics;

namespace Utte.Code
{

    /// <summary>
    /// Main form for creating code
    /// </summary>
    public partial class AttributeForm : BaseForm
    {

        #region Private/protected members

        protected string _basefilepath;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes form
        /// </summary>
        public AttributeForm()
        {
            InitializeComponent();
            if (Directory.Exists(@"C:\Codeproducer\"))
                _basefilepath = @"C:\Codeproducer\";
            else
                _basefilepath = @"C:\";
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Initializes the AttributeTargets listbox
        /// </summary>
        public override void Initialize()
        {
            lstAttributeUsage.Items.Add("All");
            lstAttributeUsage.Items.Add("Assembly");
            lstAttributeUsage.Items.Add("Class");
            lstAttributeUsage.Items.Add("Constructor");
            lstAttributeUsage.Items.Add("Delegate");
            lstAttributeUsage.Items.Add("Enum");
            lstAttributeUsage.Items.Add("Event");
            lstAttributeUsage.Items.Add("Field");
            lstAttributeUsage.Items.Add("GenericParameter");
            lstAttributeUsage.Items.Add("Interface");
            lstAttributeUsage.Items.Add("Method");
            lstAttributeUsage.Items.Add("Module");
            lstAttributeUsage.Items.Add("Parameter");
            lstAttributeUsage.Items.Add("Property");
            lstAttributeUsage.Items.Add("ReturnValue");
            lstAttributeUsage.Items.Add("Struct");
        }

        /// <summary>
        /// Produces code for an attribute
        /// </summary>
        public override void Produce()
        {
            if (sAttributeName.Text != "")
            {
                string name = sAttributeName.Text;
                if (sAttributeName.Text.Length < 9 || sAttributeName.Text.Substring(sAttributeName.Text.Length - 9, 9) != "Attribute")
                    name += "Attribute";
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = _basefilepath;
                    sfd.FileName = name;
                    sfd.DefaultExt = "txt";
                    DialogResult result = sfd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        List<string> attributes = new List<string>();
                        StringBuilder sb = new StringBuilder("AttributeUsage(");
                        sb.Append(GetAttributesTarget());
                        sb.Append(", AllowMultiple=");
                        sb.Append(bAllowMultiple.Checked.ToString().ToLower());
                        sb.Append(", Inherited=");
                        sb.Append(bInherited.Checked.ToString().ToLower());
                        sb.Append(")");
                        attributes.Add(sb.ToString());
                        using (ClassProducer newclass = new ClassProducer(name, attributes, ClassProducer.ClassType.Normal, false, Visibility.Public, "Attribute", sAttributeDescription.Text, sfd.FileName))
                        {
                            foreach (PropertyTypeName typename in lstAttributeConstructorSetMembers.Items)
                            {
                                Member member = new Member();
                                member.ConstructorSet = true;
                                member.Description = "Returns the " + typename.Type + " value";
                                member.GetProperty = true;
                                member.SetProperty = false;
                                member.Name = typename.Name;
                                member.PrivateProtected = true;
                                member.Static = false;
                                member.Type = typename.Type;
                                member.ValueType = true;
                                newclass.AddMember(member);
                            }

                            foreach (PropertyTypeName typename in lstAttributePropertySetMembers.Items)
                            {
                                Member member = new Member();
                                member.ConstructorSet = false;
                                member.Description = "Returns or sets the " + typename.Type + " value";
                                member.GetProperty = true;
                                member.SetProperty = true;
                                member.Name = typename.Name;
                                member.PrivateProtected = true;
                                member.Static = false;
                                member.Type = typename.Type;
                                member.ValueType = true;
                                newclass.AddMember(member);
                            }
                            newclass.Produce();
                        }
                        ShowTextFile(sfd.FileName);
                    }
                }
            }
            else
                MessageBox.Show("Not enough indata");
        }

        #endregion

        #region Private/protected methods

        /// <summary>
        /// Add member to be set in attributes constructor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAttributeAddConstructorSet_Click(object sender, EventArgs e)
        {
            if (sAttributeConstructorSetType.Text != "" && sAttributeConstructorSetMember.Text != "")
            {
                PropertyTypeName ptn = new PropertyTypeName(sAttributeConstructorSetType.Text, sAttributeConstructorSetMember.Text);
                lstAttributeConstructorSetMembers.Items.Add(ptn);
            }
        }

        /// <summary>
        /// Add member to be set as a property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAttributePropertySet_Click(object sender, EventArgs e)
        {
            if (sAttributePropertySetType.Text != "" && sAttributePropertySet.Text != "")
            {
                PropertyTypeName ptn = new PropertyTypeName(sAttributePropertySetType.Text, sAttributePropertySet.Text);
                lstAttributePropertySetMembers.Items.Add(ptn);
            }
        }

        /// <summary>
        /// Constructs a string of chosen AttributeTargets
        /// </summary>
        /// <returns></returns>
        private string GetAttributesTarget()
        {
            ListBox.SelectedObjectCollection selected = lstAttributeUsage.SelectedItems;
            if (selected.Count == 0)
                return "AttributeTargets.All";
            StringBuilder sb = new StringBuilder();
            foreach (object sel in selected)
            {
                if (sel.ToString() == "All")
                    return "AttributeTargets.All";
                sb.Append("AttributeTargets.");
                sb.Append(sel.ToString());
                sb.Append(" | ");
            }
            sb.Remove(sb.Length - 3, 3);
            return sb.ToString();
        }

        #endregion

        #region Private/protected structs/classes

        /// <summary>
        /// Struct to contain a property and its type
        /// </summary>
        protected struct PropertyTypeName
        {

            #region Public members

            public string Type;
            public string Name;

            #endregion

            #region Constructors

            /// <summary>
            /// Initializes the fields of the struct
            /// </summary>
            /// <param name="type"></param>
            /// <param name="name"></param>
            public PropertyTypeName(string type, string name)
            {
                Type = type;
                Name = name;
            }

            #endregion

            #region Public methods

            /// <summary>
            /// Returns a string representation of the struct
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return Type + " " + Name;
            }

            #endregion

        }

        #endregion

    }
}