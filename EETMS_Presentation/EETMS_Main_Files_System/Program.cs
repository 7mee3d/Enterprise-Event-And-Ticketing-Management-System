using EETMS_Presentation.EETMS_Main;
using System;
using System.Windows.Forms;
using EETMS_DTOs;

namespace EETMS_Presentation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLoginEETMS());
        }
    }
}
