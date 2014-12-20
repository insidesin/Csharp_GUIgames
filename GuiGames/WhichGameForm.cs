using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharedGamesClasses;

namespace GuiGames {

    /// <summary>
    /// Allows the user to select a type of game.
    /// </summary>
    public partial class Games : Form {

        private const int TWO_UP = 0;   //IDs and Names of all form options for reference.
        private const int TWENTY_ONE = 1;
        private const int CRAZY_EIGHTS = 2;
        private const int PIG = 3;

        private static string[] FORMS = { "Two Up", "Twenty-One", "Crazy Eights", "Pig" };

        TwoUpForm twoUpForm = new TwoUpForm();                     //Grant access to the TwoUpForm
        TwentyOneForm twentyOneForm = new TwentyOneForm();         //and the TwentyOneForm
        CrazyEightsForm crazyEightsForm = new CrazyEightsForm();   //and the CrazyEightsForm
        PigForm pigForm = new PigForm();                           //and the PigForm.

        public Games() {
            InitializeComponent();
        }

        /// <summary>
        /// Open's the user's selected game form and sets as active window.
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e) {
            switch (cmbGameChoice.SelectedIndex) {
                case TWO_UP:
                    TwoUpForm twoUpForm = new TwoUpForm();    
                    twoUpForm.ShowDialog();
                    break;
                case TWENTY_ONE:
                    TwentyOneForm twentyOneForm = new TwentyOneForm();
                    twentyOneForm.ShowDialog();
                    break;
                case CRAZY_EIGHTS:
                    CrazyEightsForm crazyEightsForm = new CrazyEightsForm();
                    crazyEightsForm.ShowDialog();
                    break;
                case PIG:
                    PigForm pigForm = new PigForm();
                    pigForm.ShowDialog();
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// Completely closes the application.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

    }// end class Games
}//end namespace
