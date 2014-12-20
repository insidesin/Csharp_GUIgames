using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace SharedGamesClasses {

    /// <summary>
    /// TwoUp.cs represents game play of Two Up 
    /// with the user matched against the computer
    /// </summary>
    public static class TwoUp {

        private const string HEADS = "\n\nYou threw Heads - you win\n";
        private const string ODDS = "\n\nYou threw Odds\n";
        private const string TAILS = "\n\nYou threw Tails - I win\n";

        private const string THROW_COINS = "\nPress any key to throw coins again.";

        private static Coin coin1;
        private static Coin coin2;

        private const int NUM_OF_PLAYERS = 2;
        private const int PLAYER_ID = 0;
        private const int COMPUTER_ID = 1;
        public static int[] SCORES = new int[NUM_OF_PLAYERS] { 0, 0 };


        /// <summary>
        /// Since the class is static, we need to be able to initialise local coins.
        /// </summary>
        public static void SetUpCoins() {
            coin1 = new Coin();
            coin2 = new Coin();
        } //end SetUpCoins


        /// <summary>
        /// Reset all class variables to "zeroed" values,
        /// counters and flags but not the coins.
        /// 
        /// used by both Console and GUI to ensure subsequent 
        /// playing of the game is correct
        /// </summary>
        public static void ResetGlobals() {
            for (int i = 0; i < NUM_OF_PLAYERS; i++) {
                SCORES[i] = 0; //Reset to zero.
            }
        }//end ResetGlobals

        /// <summary>
        /// Handles all overarching actions within the game
        /// including coin throwing, winner detection and
        /// coin odds checking.
        /// 
        /// used by both Console and GUI to initiate gameplay
        /// </summary>
        public static void PlayGame() {
            ThrowCoins();
            bool isOdds = OutputWinner() == 1;
            while (isOdds == true) {
                ConsoleUtilities.WaitForKey(THROW_COINS);
                ThrowCoins();
                if (OutputWinner() != 1)
                    break;
            }
            Console.WriteLine("\nYou have {0} points and I have {1} points.\n", SCORES[PLAYER_ID], SCORES[COMPUTER_ID]);
        }//end PlayGame


        /// <summary>
        /// Plays the game of Two Up until the user decides to stop
        /// Used by Console version only
        /// </summary>
        public static void PlayConsole() {
            SetUpCoins();
            do {
                PlayGame();
            }
            while (ConsoleUtilities.WantToPlayAgain() == true);

            // Before exiting the game, reset class variables
            // to appropriate starting values.
            ResetGlobals();
        }//end PlayConsole

        /// <summary>
        /// Flips both coins
        /// Pre: Local coins 1 and 2 exist
        /// Post: coin1 and coin2 flipped.
        /// </summary>
        public static void ThrowCoins() {
            coin1.Flip();
            coin2.Flip();
        }// end ThrowCoins

        /// <summary>
        /// Determines the winner of the current throw if one exists.
        /// Pre: true
        /// Post: updates class variables appropriately and displays the scorecard if a winner is found.
        /// </summary>
        /// <returns>The number of heads from the current throw: 0, 1, or 2.</returns>
        public static int OutputWinner() {
            int numberOfHeads = 0;

            if (coin1.IsHeads() == true)
                numberOfHeads++;
            if (coin2.IsHeads() == true)
                numberOfHeads++;

            switch (numberOfHeads) {
                case 0:
                    Console.WriteLine(TAILS);
                    SCORES[COMPUTER_ID] += 1;
                    break;
                case 1:
                    Console.WriteLine(ODDS);
                    break;
                case 2:
                    Console.WriteLine(HEADS);
                    SCORES[PLAYER_ID] += 1;
                    break;
            }

            return numberOfHeads;
        }// end OutputWinner

        /// <summary>
        /// Needed for GUI (only).
        /// To display the correct face of a coin
        /// </summary>
        /// <param name="coinNum"> which Coin</param>
        /// <returns> true if face is Heads</returns>
        public static bool IsHeads(int coinNum) {
            if (coinNum == 1)
                return coin1.IsHeads();
            else
                return coin2.IsHeads();
        }

    }//end class TwoUp
}//end namespace

