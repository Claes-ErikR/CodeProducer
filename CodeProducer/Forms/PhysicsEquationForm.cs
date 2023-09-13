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
    public partial class PhysicsEquationForm : BaseForm
    {

        #region Private/protected members

        protected string _basefilepath;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes form
        /// </summary>
        public PhysicsEquationForm()
        {
            InitializeComponent();
            _basefilepath = ProgramData.BaseFolder;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Produces code for a physics equation
        /// </summary>
        public override void Produce()
        {
            if (txtEquationName.Text != "" && lstVariables.Items.Count > 0)
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = _basefilepath;
                    sfd.FileName = txtEquationName.Text;
                    sfd.DefaultExt = "txt";
                    DialogResult result = sfd.ShowDialog();
                    if (result == DialogResult.OK)
                        using (ClassProducer newclass = new ClassProducer(txtEquationName.Text, null, ClassProducer.ClassType.Static, false, Visibility.Public, "", "Static class for " + txtEquationName.Text.ToLower(), sfd.FileName))
                        {
                            sfd.Dispose();
                            foreach (Member member in lstConstantMembers.Items)
                                newclass.AddMember(member);
                            foreach (string variable in lstVariables.Items)
                            {
                                Member member = new Member();
                                member.Type = variable + "Solution";
                                member.Name = variable;
                                member.Description = "";
                                member.ConstructorSet = false;
                                member.GetProperty = true;
                                member.SetProperty = false;
                                member.PrivateProtected = true;
                                member.Static = true;
                                member.ValueType = false;
                                newclass.AddMember(member);

                                ClassProducer variableclass = new ClassProducer(variable + "Solution", null, ClassProducer.ClassType.Normal, false, Visibility.Public, "SolutionBase", "Class for calculating " + variable.ToLower());

                                Method method = new Method();
                                method.Type = "double";
                                method.Name = "Calculate";
                                method.Description = "Returns the calculated double value of the quantity";
                                method.Override = false;
                                method.Static = false;
                                method.Visibility = Visibility.Public;
                                List<Method.Parameter> parameters = new List<Method.Parameter>();
                                for (int i = 0; i < lstVariables.Items.Count; i++)
                                {
                                    string potvar = lstVariables.Items[i].ToString();
                                    if (potvar != variable)
                                    {
                                        Method.Parameter parameter = new Method.Parameter();
                                        parameter.Type = "double";
                                        parameter.Name = potvar.ToLower();
                                        parameters.Add(parameter);
                                    }
                                }
                                method.Parameters = parameters;
                                variableclass.AddMethod(method);

                                method = new Method();
                                method.Type = "PhysicalValue";
                                method.Name = "Calculate";
                                method.Description = "Returns the calculated PhysicalValue value of the quantity";
                                method.Override = false;
                                method.Static = false;
                                method.Visibility = Visibility.Public;
                                parameters = new List<Method.Parameter>();
                                for (int i = 0; i < lstVariables.Items.Count; i++)
                                {
                                    string potvar = lstVariables.Items[i].ToString();
                                    if (potvar != variable)
                                    {
                                        Method.Parameter parameter = new Method.Parameter();
                                        parameter.Type = "PhysicalValue";
                                        parameter.Name = potvar.ToLower();
                                        parameters.Add(parameter);
                                    }
                                }
                                method.Parameters = parameters;
                                variableclass.AddMethod(method);

                                newclass.AddClass(variableclass);
                            }

                            newclass.Produce();
                            ShowTextFile(sfd.FileName);
                        }
                }
            else
                MessageBox.Show("Not enough indata");
        }

        #endregion

        #region Private/protected methods

        /// <summary>
        /// Adds a variable to the equation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddVariable_Click(object sender, EventArgs e)
        {
            if (txtVariable.Text != "")
            {
                lstVariables.Items.Add(txtVariable.Text);
                txtVariable.Text = "";
            }
        }

        /// <summary>
        /// Adds a constant to the equation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddConstant_Click(object sender, EventArgs e)
        {
            if (txtConstantType.Text != "" && txtConstantName.Text != "")
            {
                Member member = new Member();
                member.Type = txtConstantType.Text;
                member.Name = txtConstantName.Text;
                member.Description = "";
                member.ConstructorSet = false;
                member.GetProperty = true;
                member.SetProperty = false;
                member.PrivateProtected = true;
                member.Static = true;
                member.ValueType = false;
                lstConstantMembers.Items.Add(member);
            }
        }

        #endregion

    }
}