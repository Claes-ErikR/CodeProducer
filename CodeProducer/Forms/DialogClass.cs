using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Utte.Code.Controls
{

    /// <summary>
    /// Form to set values for a new class
    /// </summary>
    public partial class DialogClass : Form
    {

        #region Private/protected members

        ClassProducer _value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the form
        /// </summary>
        public DialogClass()
        {
            InitializeComponent();
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
                _value = new ClassProducer(cpClass.ClassName,cpClass.ClassAttributes, cpClass.Type,cpClass.ClassFormComponent, cpClass.ClassVisibility, cpClass.ClassParentClass, cpClass.ClassDescription);
                List<Member> members = cpClass.GetMembers();
                foreach (Member member in members)
                    _value.AddMember(member);
                List<ClassProducer> classproducers = cpClass.GetClasses();
                foreach (ClassProducer classproducer in classproducers)
                    _value.AddClass(classproducer);
                _value.AddInterfaces(cpClass.GetInterfaces());
                _value.AddImplementedInterfaces(cpClass.GetImplementedInterfaces());
                if (cpClass.ImplementEqualityComparison)
                    _value.ImplementEqualityComparison();
                if (cpClass.ImplementOperators)
                    _value.AddOperatorClass(cpClass.ClassName);
                if (cpClass.OperatorsVsDouble)
                    _value.AddOperatorClass("double");
                if (cpClass.OperatorsVsInt)
                    _value.AddOperatorClass("int");

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

        #endregion

        #region Properties

        /// <summary>
        /// Returns the value of the form
        /// </summary>
        public ClassProducer Value
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
                return true;
            }
        }

        #endregion

    }
}