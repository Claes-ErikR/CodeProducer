using System;
using System.Windows.Forms;
using System.IO;

namespace Utte.Code
{

    /// <summary>
    /// Static class for running the program
    /// </summary>
    public static class Program
    {

        #region Constructor

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        #endregion

    }

    public static class ProgramData
    {

        #region Properties

        /// <summary>
        /// Returns basefolder for saving text file with struct/class
        /// </summary>
        public static string BaseFolder
        {
            get
            {
                var path = Settings.Default.BaseFolderPath;
                if (Directory.Exists(path))
                    return path;
                else if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)))
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                else
                    return @"C:\";
            }
        }

        #endregion

    }
}