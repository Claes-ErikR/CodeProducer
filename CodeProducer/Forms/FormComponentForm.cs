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
    public partial class FormComponentForm : BaseForm
    {

        #region Private/protected members

        protected string _basefilepath;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes form
        /// </summary>
        public FormComponentForm()
        {
            InitializeComponent();
            _basefilepath = ProgramData.BaseFolder;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Produces a form/component
        /// </summary>
        public override void Produce()
        {
            if (sName.Text != "" && sParent.Text != "")
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.InitialDirectory = _basefilepath;
                    sfd.FileName = sName.Text;
                    sfd.DefaultExt = "txt";
                    DialogResult result = sfd.ShowDialog();
                    if (result == DialogResult.OK)
                        using (ClassProducer newclass = new ClassProducer(sName.Text, null, ClassProducer.ClassType.Normal, true, Visibility.Public, sParent.Text, sDescription.Text, sfd.FileName))
                        {
                            newclass.ImplementIXmlSave();
                            newclass.ImplementIValid();
                            if (sValue.Text != "")
                            {
                                Member member = new Member();
                                member.Attributes = new List<string>();
                                member.Attributes.Add("Browsable(false)");
                                member.ConstructorSet = false;
                                member.Description = "Returns the " + sValue.Text + " value";
                                member.GetProperty = true;
                                member.SetProperty = false;
                                member.Name = "Value";
                                member.PrivateProtected = true;
                                member.Static = false;
                                member.Type = sValue.Text;
                                member.ValueType = true;
                                newclass.AddMember(member);
                            }
                            newclass.Produce();
                            ShowTextFile(sfd.FileName);
                        }
                }
            else
                MessageBox.Show("Not enough indata");
        }

        #endregion

    }
}