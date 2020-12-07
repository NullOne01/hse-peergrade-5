using Peergrade5.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peergrade5
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // I tried to create MVP system.
            try {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormStart());
            }
            catch (Exception ex) {
                // Shit happens. Let's try to make it beuatiful. :)
                MessageBox.Show(ex.Message);
            }
        }
    }
}
