using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Utte.Code.Controls
{

    /// <summary>
    /// Control for creating classes
    /// </summary>
    public partial class ClassProducerControl : UserControl
    {

        #region Private/protected members

        protected List<string> _attributes;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the control
        /// </summary>
        public ClassProducerControl()
        {
            InitializeComponent();
            visClassVisibility.Initialize();
            foreach (string Interface in CodeGeneratorBase.ImplementedInterfaces)
                lstImplementedInterfaces.Items.Add(Interface);
            tcWrapperType.Initialize();
            edClassType.Initialize(ClassProducer.ClassType.Sealed);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a list of members
        /// </summary>
        /// <returns></returns>
        public List<Member> GetMembers()
        {
            List<Member> members = new List<Member>();
            foreach (Member member in lstMembers.Items)
                members.Add(member);
            return members;
        }

        /// <summary>
        /// Returns a list of classes
        /// </summary>
        /// <returns></returns>
        public List<ClassProducer> GetClasses()
        {
            List<ClassProducer> classproducers = new List<ClassProducer>();
            foreach (ClassProducer classproducer in lstClasses.Items)
                classproducers.Add(classproducer);
            return classproducers;
        }

        /// <summary>
        /// Returns a list of added interfaces
        /// </summary>
        /// <returns></returns>
        public List<string> GetInterfaces()
        {
            List<string> Interfaces = new List<string>();
            foreach (string Interface in lstInterfaces.Items)
                Interfaces.Add(Interface);
            return Interfaces;
        }

        /// <summary>
        /// Returns a list of added implemented interfaces
        /// </summary>
        /// <returns></returns>
        public List<string> GetImplementedInterfaces()
        {
            List<string> Interfaces = new List<string>();
            ListBox.SelectedObjectCollection SelectedInterfaces=lstImplementedInterfaces.SelectedItems;
            foreach (object Interface in SelectedInterfaces)
                Interfaces.Add(Interface.ToString());
            return Interfaces;
        }

        #endregion

        #region Private/protected methods

        /// <summary>
        /// Adds attributes to the class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddAttributes_Click(object sender, EventArgs e)
        {
            frmAttributeAddition faa = new frmAttributeAddition();
            DialogResult result = faa.ShowDialog();
            if (result == DialogResult.OK)
                _attributes = faa.Value;
            faa.Dispose();
        }

        /// <summary>
        /// Adds an interface to the lstInterface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmdAddInterface_Click(object sender, EventArgs e)
        {
            if (txtInterface.Text != "")
                lstInterfaces.Items.Add(txtInterface.Text);
        }

        /// <summary>
        /// Adds a member to the lstMembers listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            using (DialogMember dm = new DialogMember())
            {
                DialogResult result = dm.ShowDialog();
                if (result == DialogResult.OK)
                    lstMembers.Items.Add(dm.Value);
            }
        }

        /// <summary>
        /// Deletes marked member from list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDeleteMember_Click(object sender, EventArgs e)
        {
            if(lstMembers.SelectedIndex>=0)
                lstMembers.Items.RemoveAt(lstMembers.SelectedIndex);
        }

        /// <summary>
        /// Moves selected member one step up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdMemberUp_Click(object sender, EventArgs e)
        {
            if (lstMembers.SelectedIndex > 0)
            {
                int index = lstMembers.SelectedIndex - 1;
                object item = lstMembers.Items[lstMembers.SelectedIndex];
                lstMembers.Items.RemoveAt(lstMembers.SelectedIndex);
                lstMembers.Items.Insert(index, item);
                lstMembers.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Moves selected member one step down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdMemberDown_Click(object sender, EventArgs e)
        {
            if (lstMembers.SelectedIndex >= 0 && lstMembers.SelectedIndex != lstMembers.Items.Count-1)
            {
                int index = lstMembers.SelectedIndex + 1;
                object item = lstMembers.Items[lstMembers.SelectedIndex];
                lstMembers.Items.RemoveAt(lstMembers.SelectedIndex);
                lstMembers.Items.Insert(index, item);
                lstMembers.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Adds a class to the lstClasses listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddClass_Click(object sender, EventArgs e)
        {
            DialogClass dc = new DialogClass();
            DialogResult result = dc.ShowDialog();
            if (result == DialogResult.OK)
                lstClasses.Items.Add(dc.Value);
            dc.Dispose();
        }

        /// <summary>
        /// Deletes marked class from list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDeleteClass_Click(object sender, EventArgs e)
        {
            if (lstClasses.SelectedIndex >= 0)
                lstClasses.Items.RemoveAt(lstMembers.SelectedIndex);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Exposes if the object should be implemented as a List wrapper
        /// </summary>
        public bool ImplementListWrapper
        {
            get
            {
                return chkListWrapper.Checked;
            }
        }

        /// <summary>
        /// Exposes the type contained in the list
        /// </summary>
        public string ListWrapperType
        {
            get
            {
                return tcWrapperType.Text;
            }
        }

        /// <summary>
        /// Exposes if comparison to sortshould be implemented for the object
        /// </summary>
        public bool ImplementSortComparison
        {
            get
            {
                return chkComparisonImplementation.Checked;
            }
        }

        /// <summary>
        /// Exposes if equality comparison should be implemented for the object
        /// </summary>
        public bool ImplementEqualityComparison
        {
            get
            {
                return chkEquality.Checked;
            }
        }

        /// <summary>
        /// Exposes if Xml read and save should be implemented for the object
        /// </summary>
        public bool ImplementXmlReadSave
        {
            get
            {
                return chkImplementXmlReadAndSave.Checked;
            }
        }

        /// <summary>
        /// Returns the name of the class
        /// </summary>
        public string ClassName
        {
            get
            {
                return txtName.Text;
            }
        }

        /// <summary>
        /// Returns the attributes for the class
        /// </summary>
        public List<string> ClassAttributes
        {
            get
            {
                return _attributes;
            }
        }

        /// <summary>
        /// Returns the parent class of the class
        /// </summary>
        public string ClassParentClass
        {
            get
            {
                return txtParentClass.Text;
            }
        }

        /// <summary>
        /// Returns the description of the class
        /// </summary>
        public string ClassDescription
        {
            get
            {
                return txtDescription.Text;
            }
        }

        /// <summary>
        /// Returns the visibility of the class
        /// </summary>
        public Visibility ClassVisibility
        {
            get
            {
                return visClassVisibility.Value;
            }
        }

        /// <summary>
        /// Returns type of the class
        /// </summary>
        public ClassProducer.ClassType Type
        {
            get
            {
                return (ClassProducer.ClassType)edClassType.Value;
            }
        }

        /// <summary>
        /// Returns wether the class is a Form or Component
        /// </summary>
        public bool ClassFormComponent
        {
            get
            {
                return bFormComponent.Checked;
            }
        }

        /// <summary>
        /// Returns wether the class implements operators
        /// </summary>
        public bool ImplementOperators
        {
            get
            {
                return chkOperatorsVsSelf.Checked;
            }
        }

        /// <summary>
        /// Returns wether the class implements operators vs double
        /// </summary>
        public bool OperatorsVsDouble
        {
            get
            {
                return chkOperatorVsdouble.Checked;
            }
        }

        /// <summary>
        /// Returns wether the class implements operators vs int
        /// </summary>
        public bool OperatorsVsInt
        {
            get
            {
                return chkOperatorVsint.Checked;
            }
        }

        /// <summary>
        /// Returns wether the class implements deconstruct
        /// </summary>
        public bool ImplementDeconstruct
        {
            get
            {
                return chkImplementDeconstruct.Checked;
            }
        }

        /// <summary>
        /// Returns wether to ensure that ToString is overridden
        /// </summary>
        public bool EnsureToStringOverridden
        {
            get
            {
                return chkEnsureToString.Checked;
            }
        }

        /// <summary>
        /// Returns if the input is valid to create a class
        /// </summary>
        public bool Valid
        {
            get
            {
                return txtName.Text != "" && (!chkListWrapper.Checked || tcWrapperType.Valid);
            }
        }

        #endregion

    }
}
