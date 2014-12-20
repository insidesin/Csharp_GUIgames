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
    public partial class ChooseSuitForm : Form {
        public ChooseSuitForm() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void groupBox1_Enter(object sender, EventArgs e) {
        }

        /// <summary>
        /// Changes the currentsuit to whatever suit was selected
        /// Pre: An 8 must of been played by the user
        /// Post: changes the currentsuit to the specified suit
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e) {

            if (this.rbDiamonds.Checked) {
                CrazyEights.SetCurrentSuit(Suit.Diamonds);
            } else if (this.rbClubs.Checked) {
                CrazyEights.SetCurrentSuit(Suit.Clubs);
            } else if (this.rbHearts.Checked) {
                CrazyEights.SetCurrentSuit(Suit.Hearts);
            } else if (this.rbSpades.Checked) {
                CrazyEights.SetCurrentSuit(Suit.Spades);
            }
            CrazyEightsForm.NewSuitHasBeenChosen = true;
            this.Close();

        }

        private void rbDiamonds_CheckedChanged(object sender, EventArgs e) {

        }
    }
}
