using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using SharedGamesClasses;

namespace GuiGames
{
    /// <summary>
    /// Provides a GUI for the Crazy Eights game in the SharedGamesClasses.
    /// </summary>
    public partial class CrazyEightsForm : Form
    {
        private const int PLAYER = 0;
        private const int DEALER = 1;
        public static bool NewSuitHasBeenChosen = false;

        public CrazyEightsForm()
        {
            InitializeComponent();
            Trace.Listeners.Add(new ListBoxTraceListener(crazyEightsListBox));
            CrazyEights.ConsoleGame = false;
        }

        /// <summary>
        /// Loads the drawpile image
        /// </summary>
        private void CrazyEightsForm_Load(object sender, EventArgs e) {
            pboxDrawPile.Image = Images.backOfCard;
            DisableButtons();
        }

        private void DisplayGuiHand(Hand hand, TableLayoutPanel tableLayoutPanel, int person) {

            tableLayoutPanel.Controls.Clear();  // Remove any cards already being shown.

            foreach (Card card in hand) {

                // Construct a PictureBox object.
                PictureBox pictureBox = new PictureBox();
                // Tell the PictureBox to use all the space inside its square.
                pictureBox.Dock = DockStyle.Fill;
                // Remove spacing around the PictureBox. (Default is 3 pixels.)
                pictureBox.Margin = new Padding(0);

                pictureBox.Image = Images.GetCardImage(card);

                // Allow the user to click on a card in their hand.
                if (person == CrazyEights.USER) {
                    // Set event-handler for Click on this PictureBox.
                    pictureBox.Click += new EventHandler(pictureBox_Click);
                    // Tell the PictureBox which Card object it is a picture of.
                    pictureBox.Tag = card;
                }


                // Add the PictureBox object to the tableLayoutPanel.
                tableLayoutPanel.Controls.Add(pictureBox);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e) {
            // Which card was clicked?
            PictureBox clickedPictureBox = (PictureBox)sender;
            Card clickedCard = (Card)clickedPictureBox.Tag;

            TryToPlayCard(clickedCard);
        }

        /// <summary>
        /// Tries to play the selected card, if it's an 8 it will open a new form and pause the current form
        /// until a selection has been made
        /// Pre: A card must be clicked
        /// Post: Plays the givene card if possible
        /// </summary>
        private void TryToPlayCard(Card clickedCard) {

            if (CrazyEights.PickACard(PLAYER, clickedCard.ToString(true, true)) != CrazyEights.INVALIDCARDS){
                lblMessageBox.Text = "";

                //If the card that is clicked is an 8 it will open a new form to change the suit
                if (clickedCard.GetFaceValue() == FaceValue.Eight) {
                    PlayersHand.Enabled = false;
                    Form chooseSuitForm = new ChooseSuitForm();
                    chooseSuitForm.Show();
                    //Keeps the game paused while the user makes a decision
                    while (!NewSuitHasBeenChosen) {
                        RefreshTheFormThenPause(200);
                    }
                    PlayersHand.Enabled = true;
                    NewSuitHasBeenChosen = false;
                } 
                pboxDiscardPile.Image = Images.GetCardImage(CrazyEights.GetTopCardOnDiscardPile());
                DisplayGuiHand(CrazyEights.GetHand(PLAYER), PlayersHand, PLAYER);
                DisplayWinner(PLAYER);

                if (!CrazyEights.PlayerWon) {
                    ComputersTurn();
                }
            } else {
                lblMessageBox.Text = "You Cannot Play\nThat Card Right Now";
            }
        }

        /// <summary>
        /// Re-enables the Deal button and disables the Sort button
        /// Pre: A player has won.
        /// Post: Disables the Sort button and enables the sort button
        /// </summary>
        private void DisableButtons() {
            PlayersHand.Enabled = false;
            btnDeal.Enabled = true;
            btnSort.Enabled = false;
        }

        /// <summary>
        /// Checks if the player has a playable card and or if it has too many cards
        /// Pre: The start of the game or after a computer has played a card
        /// Post: Checks if the user may play a card or must pass/pick up a card
        /// </summary>
        private void UsersTurn() {

            //Checks if they have any valid cards
            if (CrazyEights.ValidCard(PLAYER) < 0) {
                pboxDrawPile.Enabled = true;
                PlayersHand.Enabled = false;
                lblMessageBox.Text = "You Do Not Have A Valid Card \nTo Play, Please Draw A Card";
                DisplayGuiHand(CrazyEights.GetHand(PLAYER), PlayersHand, PLAYER);
            }
            //Passes the turn if they have too many cards
            if (CrazyEights.GetHand(PLAYER).GetCount() == CrazyEights.MAXIMUMCARDS && 
                CrazyEights.ValidCard(PLAYER) < 0) {
                pboxDrawPile.Enabled = false;
                PlayersHand.Enabled = false;
                lblMessageBox.Text = "";
                ComputersTurn();
            }
            //PlayersHand.Enabled = true;
        }

        /// <summary>
        /// Determines who won the game and displays a message
        /// Pre: A Player must have no cards in his or hers hand or they have tied
        /// Post: displays a message
        /// </summary>
        private void DisplayWinner(int Player) {
            int PlayerWon = CrazyEights.DetermineWinner(Player);
            if (PlayerWon == PLAYER) {
                lblMessageBox.Text = "You have won,\nPress deal cards to play again";
                DisableButtons();
            }else if (PlayerWon == DEALER) {
                lblMessageBox.Text = "Dealer has won,\nPress deal cards to play again";
                DisableButtons();
            } else if (PlayerWon == CrazyEights.INVALIDCARDS) {
                lblMessageBox.Text = "Players have Tied,\nPress deal cards to play again";
                DisableButtons();
            }
            
        }

        /// <summary>
        /// The computers Turn
        /// Pre: Called when after a user plays a card or passes their turn
        /// Post: Plays a card if possible
        /// </summary>
        private void ComputersTurn() {
            RefreshTheFormThenPause(500);
            CrazyEights.PlayersTurn(DEALER);
            DisplayGuiHand(CrazyEights.GetHand(DEALER), DealersHand, DEALER);
            pboxDiscardPile.Image = Images.GetCardImage(CrazyEights.GetTopCardOnDiscardPile());         
            DisplayWinner(DEALER);
             if (!CrazyEights.PlayerWon) {
                 UsersTurn();
             }
           
            //PlayersHand.Enabled = true;
        }

        /// <summary>
        /// Sets up the game
        /// Pre: When the deal button is clicked
        /// Post: Sets up the game
        /// </summary>
        private void btnDeal_Click(object sender, EventArgs e) {
            CrazyEights.SetUpGame();
            DisplayGuiHand(CrazyEights.GetHand(DEALER), DealersHand, DEALER);
            DisplayGuiHand(CrazyEights.GetHand(PLAYER), PlayersHand, PLAYER);
            pboxDiscardPile.Image = Images.GetCardImage(CrazyEights.GetTopCardOnDiscardPile());
            lblMessageBox.Text = "";
            btnDeal.Enabled = false;
            btnSort.Enabled = true;
            PlayersHand.Enabled = true;
            UsersTurn();
        }

        /// <summary>
        /// Closes the Game
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        /// Sorts the players hand
        private void btnSort_Click(object sender, EventArgs e) {
            CrazyEights.SortHand(PLAYER);
            DisplayGuiHand(CrazyEights.GetHand(PLAYER), PlayersHand, PLAYER);
        }


        private void PlayersHand_Paint(object sender, PaintEventArgs e) {

        }

        /// <summary>
        /// Draws a card for a player
        /// Pre: The player must have no available cards they can play
        /// Post: Puts a card in the players hand
        /// </summary>
        private void pboxDrawPile_Click(object sender, EventArgs e) {
            //Adds a card to the players hand and checks if theres cards in the drawpile
            CrazyEights.DrawACard(PLAYER);
            DisplayGuiHand(CrazyEights.GetHand(PLAYER), PlayersHand, PLAYER);
            pboxDiscardPile.Image = Images.GetCardImage(CrazyEights.GetTopCardOnDiscardPile());
            pboxDrawPile.Enabled = false;
            lblMessageBox.Text = "";
            PlayersHand.Enabled = true;
            UsersTurn();
        }

        //Pauses the game so they player can see what card they put down
        private static void RefreshTheFormThenPause(int Half_Second) {
            // Let the form display any recent changes to Controls, such as PictureBoxes.
            Application.DoEvents();

            // Wait, then continue.
            Thread.Sleep(Half_Second);
        }



    }
}
