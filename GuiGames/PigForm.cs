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
    /// Provides a GUI for the Pig game in the SharedGamesClasses.
    /// </summary>
    public partial class PigForm : Form {

        private int whosTurn = Pig.USER;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="form"></param>
        public PigForm() {
            InitializeComponent();
            Trace.Listeners.Add(new ListBoxTraceListener(pigListBox));
            Pig.ResetGlobals();
        } //End PigForm

        /// <summary>
        /// Resets all key components to a succesful run through of the game.
        /// Pre: the existing data from the previous game lingers, either after a game
        /// has finished or you have re-entered from the login screen after a game.
        /// Post: the labels and variables have been reset to provide consistent games.
        /// </summary>
        private void ResetForm() {
            Pig.ResetGlobals();
            whosTurn = Pig.USER;
            UpdateLabels();
            btnPlayAgain.Enabled = false;
            btnCancel.Enabled = false;
            btnRoll.Enabled = true;
        } //End ResetForm

        /// <summary>
        /// Displays a popup window asking the current user whether they
        /// would like to hold or not.
        /// Pre: user has finished a dice roll and wishes to continue
        /// Post: the user has selected a decision and the turn has shifted
        /// or the player has held, depending on their choice.
        /// </summary>
        private void WantToHold() {
            DialogResult dialogResult = MessageBox.Show("Does the " + Pig.playersName[whosTurn] +
                                                        " want to hold? (Yes or No)", // The question.
                                                        "Hold?", // The MessageBox's caption.
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes) {
                //Changes the turn to the opposite player.
                whosTurn = whosTurn == Pig.USER ? Pig.COMPUTER : Pig.USER;
                Pig.SetHoldTotal(0);    //Ends the current turn's hold total.
            }
            UpdateLabels();
        } //End WantToHold

        /// <summary>
        /// Updates the visual labels on the screen with their appropriate
        /// information and numbers.
        /// Pre: labels hold old score, name and player information and
        /// require updating.
        /// Post: displays all labels that require updated values.
        /// </summary>
        private void UpdateLabels() {
            lblCompAt.Text = Pig.GetPoints(Pig.COMPUTER).ToString();
            lblPlayerAt.Text = Pig.GetPoints(Pig.USER).ToString();
            lblWhosTurn.Text = Pig.playersName[whosTurn].ToString();
        } //End UpdateLabels

        /// <summary>
        /// Displays the winner of the current round in the textbox and
        /// through a message box popup.
        /// Pre: one use has their score beyond the minimum to win.
        /// Post: displays the cancel and play again buttons whilst removing
        /// the roll button and finally displaying a winning messagebox.
        /// </summary>
        private void ShowWinner() {
            Trace.WriteLine("\n" + Pig.playersName[whosTurn] + " has won!\n");
            MessageBox.Show(Pig.playersName[whosTurn] + " has won! Well Done!"); // The MessageBox's text.

            btnPlayAgain.Enabled = true;
            btnCancel.Enabled = true;
            btnRoll.Enabled = false;
        } //End ShowWinner

        /// <summary>
        /// Runs one complete turn for the individual that clicks the roll button.
        /// Pre: the roll dice button is clicked and the current turn belongs to 
        /// the player referenced in 'whosTurn'.
        /// Post: Sets the players points to however much was achieved in the current
        /// roll total (and hold total, if multiple rolls existed)
        /// </summary>
        private void PlayTurn() {
            btnCancel.Enabled = true;
            //After a succesful play, in which the user did not
            //receive a roll of value: 1.
            if (Pig.PlayGUI(whosTurn, true)) {
                UpdateLabels();
                WantToHold();
            } else {    //On a roll of 1.
                if (Pig.HasWon(whosTurn) == true)
                    ShowWinner();
                whosTurn = whosTurn == Pig.USER ? Pig.COMPUTER : Pig.USER;
                UpdateLabels();
                Pig.SetHoldTotal(0);
            }
        } //End PlayTurn

        /// <summary>
        /// Begins a turn by rolling the dice.
        /// </summary>
        private void btnRoll_Click(object sender, EventArgs e) {
            PlayTurn();
        } //End Roll Click

        /// <summary>
        /// The current form (Pig) is closed and the menu opened.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        } //End Cancel Click

        /// <summary>
        /// Resets the game, ready for another round.
        /// </summary>
        private void btnPlayAgain_Click(object sender, EventArgs e) {
            ResetForm();
        } //End PlayAgain Click
    }
}
