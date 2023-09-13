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
    public partial class CodeTestForm : BaseForm
    {

        #region Private/protected members

        protected string _basefilepath;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes form
        /// </summary>
        public CodeTestForm()
        {
            InitializeComponent();
            _basefilepath = ProgramData.BaseFolder;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Tests the method
        /// </summary>
        public override void Produce()
        {
            //System.Reflection.Emit.MethodBuilder mb = new System.Reflection.Emit.MethodBuilder();
            //System.Reflection.Emit.ILGenerator ig = new System.Reflection.Emit.ILGenerator();
            System.CodeDom.CodeMethodReferenceExpression c = new System.CodeDom.CodeMethodReferenceExpression();
            System.Diagnostics.Process p = new Process();
            //RuntimeMethodHandle rmh = new RuntimeMethodHandle();
            System.Tuple<double> t = System.Tuple.Create<double>(3);
            System.Func<double, double> f = (double x) => 2 * x;


            //double[] k;
            //int[] j;
        }

        #endregion

    }
}