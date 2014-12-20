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
    /// Provides a GUI for the Two Up game in the SharedGamesClasses.
    /// </summary>
    public partial class TwoUpForm : Form {

        private const string HEADS = "\nYou threw Heads - you win\n";
        private const string ODDS = "\nYou threw Odds\n";
        private const string TAILS = "\nYou threw Tails - I win\n";

        private const int PLAYER_ID = 0;
        private const int COMPUTER_ID = 1;
        private int tickCount = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="form"></param>
        public TwoUpForm() {
            InitializeComponent();
            Trace.Listeners.Add(new ListBoxTraceListener(twoUpListBox));
            TwoUp.SetUpCoins();
            TwoUp.ResetGlobals();
        } //End TwoUpForm


        /// <summary>
        /// Throws the two coins and shows the results on the screen.
        /// Pre: The user has thrown the coins and an output is yet to be placed
        /// onto the GUI.
        /// Post: The label of both coin combination is updated with the correct
        /// value. The animation is continuing for it's total of 1000ms.
        /// </summary>
        private void ShowResultsOfThrow() {
            TwoUp.ThrowCoins();
            btnThrowCoins.Enabled = false;
            tmrFlip.Start();    //Start animation timer.
            switch (TwoUp.OutputWinner()) {     //Output the correct roll and winner.
                case 0:
                    lblCoinsTossed.Text = "Tails";
                    Trace.WriteLine(TAILS);
                    break;
                case 1:
                    lblCoinsTossed.Text = "Odds";
                    Trace.WriteLine(ODDS);
                    Trace.WriteLine("Click Throw Coins");
                    return;
                case 2:
                    lblCoinsTossed.Text = "Heads";
                    Trace.WriteLine(HEADS);
                    break;
            }
            btnPlayAgain.Visible = true;
            Trace.WriteLine("\nYou have " + TwoUp.SCORES[PLAYER_ID] + " points and I have " 
                                        + TwoUp.SCORES[COMPUTER_ID] + " points.\n");
        } //End ShowResultsOfThrow

        /// <summary>
        /// Makes the tossed coins appear to be animated by
        /// alternating between the two sides of the coin (images)
        /// until finally reaching the side it landed on.
        /// Pre: The coins require a form of animation and have held values 
        /// (i.e. odds, tails or heads)
        /// Post: The coin picture box images are replaced with the correct
        /// landing of the coins.
        /// </summary>
        private void AnimateCoins() {
            //Set both images to Heads if this is an even loop of the animation.
            SetPictureBox(1, tickCount % 2 == 0 ? true : false);
            SetPictureBox(2, tickCount % 2 == 0 ? true : false);
            tickCount++;

            //Once the animation is complete (after 10 loops/1000ms of time)
            //we will set both picture boxes to the real faces of the coins
            //whilst revealing the labels to show which face it landed on.
            if (tickCount >= 10) {
                SetPictureBox(1, TwoUp.IsHeads(1));
                SetPictureBox(2, TwoUp.IsHeads(2));
                lblCoinsTossed.Visible = true;
                if(lblCoinsTossed.Text == "Odds")
                    btnThrowCoins.Enabled = true;
                tmrFlip.Stop();
                tickCount = 0;  //Reset the timer for next toss.
            }
        } //End AnimateCoins

        /// <summary>
        /// Sets the image in the PictureBox for the given coinNum
        /// to Images.Heads if the Heads parameter is True,
        /// or Images.Tails if the Heads parameter is False.
        /// </summary>
        private void SetPictureBox(int coinNum, bool Heads) {
            if (coinNum == 1)
                pbxFirstCoin.Image = Images.GetCoinImage(Heads);
            else
                pbxSecondCoin.Image = Images.GetCoinImage(Heads);
        } //End SetPictureBox

        /// <summary>
        /// Calls the method to have the coins tossed.
        /// </summary>
        private void btnThrowCoins_Click(object sender, EventArgs e) {
            ShowResultsOfThrow();
        } //End ThrowCoins Click

        /// <summary>
        /// The current form (TwoUp) is closed and the menu opened.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        } //End CancelGame Click

        /// <summary>
        /// Resets the game, ready for another coin toss.
        /// </summary>
        private void btnPlayAgain_Click(object sender, EventArgs e) {
            btnThrowCoins.Enabled = true;
            btnPlayAgain.Visible = false;
            lblCoinsTossed.Visible = false;
        } //End PlayAgain Click

        /// <summary>
        /// On every 100ms tick of the animation timer, call the
        /// method required to animate both coins simultaneously.
        /// </summary>
        private void tmrFlip_Tick(object sender, EventArgs e) {
            AnimateCoins();
        } //End TimerFlip Tick

    } //end class TwoUpForm
} // end namespace
