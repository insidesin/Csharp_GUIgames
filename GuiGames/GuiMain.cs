using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GuiGames {
    
    static class GuiMain {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Games());
        }

    }//end GuiMain
}//end namespace
