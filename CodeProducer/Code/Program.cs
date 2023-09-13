using System;
using System.Collections.Generic;
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
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Programming\CodeProducerResults\"))
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Programming\CodeProducerResults\";
                else
                    return @"C:\";
            }
        }

        #endregion

    }
}