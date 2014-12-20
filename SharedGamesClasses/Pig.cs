using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;


namespace SharedGamesClasses {
    public static class Pig {

        public const int NUM_OF_PLAYERS = 2;
        public const int USER = 0;
        public const int COMPUTER = 1;
        public const int END_SQUARE = 30;

        public static string[] playersName = new string[NUM_OF_PLAYERS] { "Player", "Computer" };

        private static int[] pointsTotal = new int[NUM_OF_PLAYERS] { 0, 0 };

        private static int holdTotalGUI = 0;

        private static Die die = new Die();
        private static Random random = new Random();


        /// <summary>
        /// Reset all class variables to "zeroed" values,
        /// counters and flags but not the die.
        /// 
        /// used by both Console and GUI to ensure subsequent 
        /// playing of the game is correct
        /// </summary>
        public static void ResetGlobals() {
            for (int i = 0; i < NUM_OF_PLAYERS; i++) {
                pointsTotal[i] = 0; //Reset to zero.
            }
            holdTotalGUI = 0;
        } // end ResetGlobals


        /// <summary>
        /// Gets the pointsTotal of the player.
        /// </summary>
        /// <param name="who"> a player</param>
        /// <returns> the amount of points currently held by the player</returns>
        public static int GetPoints(int who) {
            return pointsTotal[who];
        } // end GetPoints


        /// <summary>
        /// Gets the holdTotalGUI of the player.
        /// </summary>
        /// <returns> the amount of points held in one turn before holding</returns>
        public static int GetHoldTotal() {
            return holdTotalGUI;
        } // end GetHoldTotal


        /// <summary>
        /// Sets the holdTotalGUI of the player.
        /// </summary>
        /// <param name="id"> the amount of points held in one turn before holding</param>
        public static void SetHoldTotal(int id) {
            holdTotalGUI = id;
        } // end GetHoldTotal


        /// <summary>
        /// Reset all class variables to "zeroed" values,
        /// counters and flags but not the die.
        /// 
        /// used by both Console and GUI to ensure subsequent 
        /// playing of the game is correct
        /// Pre: The user wishes to roll again and has pressed yes to another toss.
        /// Post: The dice is tossed and the result is added onto the user's current
        /// score if the toss value is 2-6, else the value is nulled and the hold total
        /// for the current user is erased.
        /// </summary>
        /// <param name="who"> a player</param>
        public static void PlayGame(int who) {
            int holdTotal = 0;
            do {
                //Roll the dice and store the value.
                int rollValue = die.Roll();
                Console.WriteLine("\n{0} threw a {1}", playersName[who], rollValue);
                if (rollValue > 1) {
                    //If they receive a roll of value: 2-6, add their points to their score.
                    holdTotal += rollValue;
                    pointsTotal[who] += rollValue;
                    Console.WriteLine("\n{0} is at position {1}", playersName[who], pointsTotal[who]);
                } else {
                    //If they receive a roll of value: 1, reset their holdTotal and deduct all points.
                    pointsTotal[who] -= holdTotal;
                    Console.WriteLine("\n{0} is at position {1}", playersName[who], pointsTotal[who]);
                    break;
                }

                if (HasWon(who) == true) { break; }

            } while (PromptHold(who) == false); //Ask the player whether they'd like to hold.
        } // end PlayGame


        /// <summary>
        /// Determines whether or not the player/computer wishes to hold.
        /// Random input is devised for the computer.
        /// Pre: A user is about to end their turn after successfully rolling a 2-6.
        /// Post: The user continues their turn if they do not wish to hold.
        /// </summary>
        /// <param name="who"> a player</param>
        /// <returns> true if specified player wants to hold, false otherwise</returns>
        public static bool PromptHold(int who) {
            if (who == COMPUTER) {
                //If the current turn is of a computer, they are given a random hold/continue response.
                string option;
                option = (random.Next(die.GetNumFaces()) > 0? "N" : "Y");
                Console.WriteLine("\nDoes the {0} want to Hold? (Y or N): {1}", playersName[COMPUTER], option);
                return (option == "Y");
            } else {
                //Else if the current turn is of a player, they select whether to hold or not using 'Y' or 'N'.
                string input;
                bool validInput = false;
                do {
                    Console.Write("\nDoes the {0} want to Hold? (Y or N): ", playersName[USER]);
                    input = Console.ReadLine().ToUpper();
                    validInput = input == "Y" || input == "N";
                } while (!validInput);

                return (input == "Y");  //If the selection was Y, return true (The player wants to hold).
            }
        } //end PromptHold


        /// <summary>
        /// Determines if the specified player (who) has won
        /// </summary>
        /// <param name="who"> a player</param>
        /// <returns> true if specified player has won, false otherwise</returns>
        public static bool HasWon(int who) {
            return (pointsTotal[who] >= END_SQUARE);
        } //end HasWon


        /// <summary>
        /// Plays the game of Pig  until the user decides to stop
        /// Used by Console version only
        /// Pre: 
        /// Post: The game is succesfully completed and the user is returned to the main menu.
        /// </summary>
        public static void PlayConsole() {
            do {
                //Until a player has one, give each player their turn.
                while (HasWon(COMPUTER) == false && HasWon(USER) == false) {
                    PlayGame(USER); //The user plays their turn.
                    if (HasWon(USER) == true)
                        break;
                    PlayGame(COMPUTER); //The computer plays their turn.
                }
                Console.WriteLine("\n{0} has won!\n", HasWon(USER) == true ? "Player" : "Computer");
                ResetGlobals();
            } while (ConsoleUtilities.WantToPlayAgain() == true);   //While they still wish to play.
        } //end PlayConsole


        /* The following method should be called by your GUI code.
         * I.e. Do not use it when writing your Console game,
         * but do not delete it. */

        /// <summary>
        /// Plays one roll of the die for a specified player (who).
        /// 
        /// Used by GUI version to roll a die once.
        /// Pre: The user has clicked the Roll Dice button and wishes to roll the dice
        /// Post: The user receives a value that is then added to their total (if 2-6 is
        /// rolled) or does nothing and removes all their current hold total (if 1 is rolled).
        /// </summary>
        /// <param name="who">a player</param>
        /// <param name="firstRoll"> true indicates it is the first roll of "who's" turn,
        /// false indicates it is a continuation of "who's" turn</param>
        /// <returns>true if player has not thrown a 1, otherwise false</returns>
        public static bool PlayGUI(int who, bool firstRoll) {
            bool result = true;
            
            int rollValue = die.Roll(); //Store the dice roll.
            Trace.WriteLine("\n" + playersName[who] + " threw a " + rollValue);
            if (rollValue > 1) {
                //If they receive a roll of value: 2-6, add their points to their score.
                holdTotalGUI += rollValue;
                pointsTotal[who] += rollValue;
                Trace.WriteLine("\n" + playersName[who] + " is at position " + pointsTotal[who]);
            } else {
                //If they receive a roll of value: 1, reset their holdTotal and deduct all points.
                pointsTotal[who] -= holdTotalGUI;
                Trace.WriteLine("\n" + playersName[who] + " is at position " + pointsTotal[who]);
                result = false;
            }

            if (HasWon(who) == true) { result = false; }

            return result;
        }//end PlayGui

    } // end Pig class
}
