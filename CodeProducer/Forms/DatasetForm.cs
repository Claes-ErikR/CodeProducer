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
    public partial class DatasetForm : BaseForm
    {

        #region Private/protected members

        protected string _basefilepath;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes form
        /// </summary>
        public DatasetForm()
        {
            InitializeComponent();
            _basefilepath = ProgramData.BaseFolder;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Produces a dataset
        /// </summary>
        public override void Produce()
        {
            DataSet dataset = new DataSet();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                openFileDialog.Filter = "XML-files (*.XML)|*.XML|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    dataset.ReadXmlSchema(openFileDialog.FileName);
                    DataBaseSupport dbsupport = new DataBaseSupport(dataset);

                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.InitialDirectory = _basefilepath;
                        sfd.FileName = dataset.DataSetName;
                        sfd.Filter = "sql-files (*.sql)|*.sql";
                        sfd.DefaultExt = "sql";
                        DialogResult result = sfd.ShowDialog();
                        if (result == DialogResult.OK)
                            dbsupport.ProduceStoredProcedures(sfd.FileName);
                        ShowTextFile(sfd.FileName);
                    }
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.InitialDirectory = _basefilepath;
                        sfd.FileName = dataset.DataSetName;
                        sfd.Filter = "text-files (*.txt)|*.txt";
                        sfd.DefaultExt = "txt";
                        DialogResult result = sfd.ShowDialog();
                        if (result == DialogResult.OK)
                            dbsupport.ProduceDataSetCode(sfd.FileName);
                        ShowTextFile(sfd.FileName);
                        dbsupport.Dispose();
                    }
                }
            }
        }

        #endregion

    }
}