using System.Windows.Forms;
using System.Diagnostics;

namespace Utte.Code
{

    /// <summary>
    /// Baseform for code producin forms
    /// </summary>
    public partial class BaseForm : Form
    {

        #region Constructors

        /// <summary>
        /// Initializes components
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Method used to initialize parameters
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Method used to produce the code
        /// </summary>
        public virtual void Produce()
        {
        }

        /// <summary>
        /// Shows help box if available
        /// </summary>
        public virtual void Help()
        {
            MessageBox.Show("No help available on this issue");
        }

        #endregion

        #region Private/protected methods

        /// <summary>
        /// Shows the file in filename
        /// </summary>
        /// <param name="filename"></param>
        protected void ShowTextFile(string filename)
        {
            try
            {
                Process.Start(filename);
            }
            catch
            {
            }
        }

        #endregion

    }
}
