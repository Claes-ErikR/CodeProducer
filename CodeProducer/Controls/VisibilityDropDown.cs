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
    /// Dropdown for chosing visibility level for classes, methods etc
    /// </summary>
    public partial class VisibilityDropDown : ComboBox
    {

        #region Constructor

        /// <summary>
        /// Initializes the combobox
        /// </summary>
        public VisibilityDropDown()
        {
            InitializeComponent();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Initializes dropdown style and members of dropdown
        /// </summary>
        public void Initialize()
        {
            this.Items.Clear();
            this.Items.Add("public");
            this.Items.Add("protected");
            this.Items.Add("private");
            this.Items.Add("internal");
            this.Items.Add("protected internal");
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndex = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns chosen visibility level
        /// </summary>
        public Visibility Value
        {
            get
            {
                switch (this.SelectedIndex)
                {
                    case 0:
                        return Visibility.Public;
                    case 1:
                        return Visibility.Protected;
                    case 2:
                        return Visibility.Private;
                    case 3:
                        return Visibility.Internal;
                    case 4:
                        return Visibility.ProtectedInternal;
                }
                throw new NotImplementedException("Not implemented visibility level in VisibilityDropDown");
            }
        }

        #endregion

    }
}
