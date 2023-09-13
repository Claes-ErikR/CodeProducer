using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utte.Controls;

namespace Utte.Code
{

    /// <summary>
    /// Control for chosing type
    /// </summary>
    public partial class TypeChoser : ComboBox, IValid
    {

        #region Constructor

        /// <summary>
        /// Initializes basic component
        /// </summary>
        public TypeChoser()
        {
            InitializeComponent();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Initializes items
        /// </summary>
        public void Initialize()
        {
            foreach (string type in _valuetypes)
                Items.Add(type);
            Text = "";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Checks if selected type is value type
        /// </summary>
        public bool IsValueType
        {
            get
            {
                return _valuetypes.Contains(Text);
            }
        }

        /// <summary>
        /// Evaluates if control is valid
        /// </summary>
        public bool Valid
        {
            get 
            {
                return !string.IsNullOrEmpty(Text); 
            }
        }

        #endregion

        #region Private static members

        private static List<string> _valuetypes;

        #endregion

        #region Static constructor

        /// <summary>
        /// Initializes value types
        /// </summary>
        static TypeChoser()
        {
            _valuetypes=new List<string>();
            _valuetypes.Add("double");
            _valuetypes.Add("int");
            _valuetypes.Add("string");
            _valuetypes.Add("bool");
        }

        #endregion

    }
}
