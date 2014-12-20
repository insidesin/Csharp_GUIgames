using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using SharedGamesClasses;

namespace GuiGames {

    /// <summary>
    /// Provides a GUI for the Twenty-One game in the SharedGamesClasses.
    /// </summary>
    public partial class TwentyOneForm : Form {

        private const int PLAYER = 0;
        private const int DEALER = 1;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="form"></param>
        public TwentyOneForm() {
            InitializeComponent();
            Trace.Listeners.Add(new ListBoxTraceListener(twentyOneListBox));
            TwentyOne.ConsoleGame = false;
        }

        private void TwentyOneForm_Load(object sender, EventArgs e) {
        }

        private void DisplayGuiHand(Hand hand, TableLayoutPanel tableLayoutPanel) {

            tableLayoutPanel.Controls.Clear();  // Remove any cards already being shown.

            foreach (Card card in hand) {

                // Construct a PictureBox object.
                PictureBox pictureBox = new PictureBox();
                // Tell the PictureBox to use all the space inside its square.
                pictureBox.Dock = DockStyle.Fill;
                // Remove spacing around the PictureBox. (Default is 3 pixels.)
                pictureBox.Margin = new Padding(0);

                pictureBox.Image = Images.GetCardImage(card);

                // Add the PictureBox object to the tableLayoutPanel.
                tableLayoutPanel.Controls.Add(pictureBox);
            }
        }
        /// <summary>
        /// Adds a card to a Users Hand and then checks if they have gone bust or not
        /// Pre: They must not have 21 already and have hit the hit button
        /// Post: Deals a card to the player
        /// </summary>
        private void btnHit_Click(object sender, EventArgs e) {
            TwentyOne.AddCard(PLAYER);
            DisplayGuiHand(TwentyOne.GetHand(PLAYER), playerTableLayoutPanel);
            CheckHandForAce();
            lblPlayersHandValue.Text = TwentyOne.HandValue(PLAYER).ToString();
            if (TwentyOne.HandValue(PLAYER) > TwentyOne.MAXVALUE) {             
                TwentyOne.DetermineWinner();
                PlayerHasBusted.Visible = true;
                DisplayGamesWon();
                DisableButtons();
            }


        }
        /// <summary>
        /// Disables the hit and stand button but enables the dealCards button
        /// </summary>
        private void DisableButtons() {
            btnHit.Enabled = false;
            btnStand.Enabled = false;
            btnDealCards.Enabled = true;
        }

        /// <summary>
        /// Checks the hand if it has an Ace or not, and allows the user to specify its value
        /// Pre: A Ace in the players hand
        /// Post: Changes the value of the Ace
        /// </summary>
        public void CheckHandForAce() {
           

            if (TwentyOne.CheckAces(PLAYER)) {
                DialogResult dialogResult = MessageBox.Show("Would You like the ace to be 1?",
                                            "You have been dealt and Ace", // The MessageBox's caption.
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes) {
                    TwentyOne.IncreaseNumOfUserAcesWithValueOne();
                    lblValue.Text = TwentyOne.GetNumOfUserAcesWithValueOne().ToString();
                    
                }
             }
            DisplayHandValue(PLAYER);
            if (TwentyOne.HandValue(PLAYER) == TwentyOne.MAXVALUE) {
                DisableButtons();
                ComputersTurn();
            }
        }

        /// <summary>
        /// Displays the Users hand Value and updates the players hand image
        /// </summary>
        private void DisplayHandValue(int player) {

            if (player == PLAYER) {
                lblPlayersHandValue.Text = TwentyOne.HandValue(PLAYER).ToString();
                DisplayGuiHand(TwentyOne.GetHand(PLAYER), playerTableLayoutPanel);
            } else {
                lblDealersHandvalue.Text = TwentyOne.HandValue(DEALER).ToString();
                DisplayGuiHand(TwentyOne.GetHand(DEALER), dealerTableLayoutPanel);
            }
        }

        /// <summary>
        /// Sets up the game of 21
        /// </summary>
        private void btnDealCards_Click(object sender, EventArgs e) {
            TwentyOne.SetUpGame();
            DisplayGuiHand(TwentyOne.GetHand(DEALER), dealerTableLayoutPanel);
            DisplayGuiHand(TwentyOne.GetHand(PLAYER), playerTableLayoutPanel);
            TwentyOne.DisplayHand(DEALER);
            TwentyOne.DisplayHand(PLAYER);
            DisplayHandValue(PLAYER);
            DisplayHandValue(DEALER);  
            lblValue.Text = TwentyOne.GetNumOfUserAcesWithValueOne().ToString();
            DealerHasBusted.Visible = false;
            PlayerHasBusted.Visible = false;
            btnDealCards.Enabled = false;
            btnHit.Enabled = true;
            btnStand.Enabled = true;
            CheckHandForAce();
            CheckHandForAce();
        }

        private void twentyOneListBox_SelectedIndexChanged(object sender, EventArgs e) {

        }

        /// <summary>
        /// Locks in the handvalue of the user and allows the computer to have a turn
        /// </summary>
        private void btnStand_Click(object sender, EventArgs e) {
            DisableButtons();
            ComputersTurn();
        }

        //Displays the games won
        private void DisplayGamesWon() {

            lblPlayerGamesWonValue.Text = TwentyOne.GetNumOfGamesWon(PLAYER).ToString();
            lblDealerGamesWonValue.Text = TwentyOne.GetNumOfGamesWon(DEALER).ToString();

        }

        /// <summary>
        /// Allows the computer to have a turn
        /// Pre: User had stood or has reached 21
        /// Post: Allows the Comptuer to have a turn
        /// </summary>
        private void ComputersTurn() {
            TwentyOne.DealACard(DEALER);
            DisplayHandValue(DEALER);
            TwentyOne.DetermineWinner();
            DisplayGamesWon();
            if (TwentyOne.HandValue(DEALER) > TwentyOne.MAXVALUE) {
                DealerHasBusted.Visible = true;
            }
        }

        private void btnCanelGame_Click(object sender, EventArgs e) {
            TwentyOne.numOfGamesWon[PLAYER] = 0;
            TwentyOne.numOfGamesWon[DEALER] = 0;
            this.Close();
        }

        private void PlayerHasBusted_Click(object sender, EventArgs e) {

        }

    } //end class TwentyOneForm
} //end namespace
