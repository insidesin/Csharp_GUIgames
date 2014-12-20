using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SharedGamesClasses {

    // <summary>
    /// ConsoleUtilities.cs provides commonly used Display methods
    /// in the Console version of each games. 
    /// </summary>
    class ConsoleUtilities {
        private static string YES = "Y";
        private static string NO = "N";
        private static string HIT = "H";
        private static string STAND = "S";
        private const string DIAMOND = "D";
        private const string CLUB = "C";
        private const string HEART = "H";
        private const string SPADE = "S";
        


        /// <summary>
        /// Asks the user if they wish to play again.
        /// Pre:  none
        /// Post: whether the user wishes to play again.
        /// </summary>
        /// <returns>
        /// true if the user wishes to play again,
        /// false otherwise
        /// </returns>
        public static bool WantToPlayAgain() {
            string input;
            bool validInput = false;
            do {
                Trace.Write("Play Again? (Y or N): ");
                input = Console.ReadLine().ToUpper();
                validInput = input == YES || input == NO;
            } while (!validInput);

            return (input == YES);
        } // end WantToPlayAgain

        public static bool DealtAnAce() {
            string input;
            bool validInput = false;
            do {
                Trace.Write("\nYou Have been dealt an Ace, would you like it to be valued at 11 (Y/N): "); 
                input = Console.ReadLine().ToUpper();
                validInput = input == YES || input == NO;
            } while (!validInput);

            return (input == YES);
        } // end YESORNO

        public static bool HitOrStand() {
            string input;
            bool validInput = false;
            do {
                Trace.Write("\nWould You Like to hit (H) or stand (S): ");
                input = Console.ReadLine().ToUpper();
                validInput = input == HIT || input == STAND;
            } while (!validInput);

            return (input == HIT);
        } // end YESORNO

        public static Suit WhichSuit() {
            string input;
            Suit suit = Suit.Diamonds;
            bool validInput = false;
            do {
                Trace.Write("\nWhat Suit Would You Like ");
                input = Console.ReadLine().ToUpper();
                validInput = input == DIAMOND || input == SPADE || input == CLUB || input == HEART;
            } while (!validInput);

            switch (input) {

                case DIAMOND: suit = Suit.Diamonds;
                              return suit;
                case CLUB: suit = Suit.Clubs;
                              return suit;
                case HEART: suit = Suit.Hearts;
                              return suit;
                case SPADE: suit = Suit.Spades;
                              return suit;
                default: return suit;

                }

        } // end YESORNO


        /// <summary>
        /// Displays a prompt and waits for a key press.
        /// Pre:  prompt to display; not null, nor empty
        /// Post: prompt was displayed and user pressed a key.
        /// </summary>
        /// <param name="prompt">the prompt to display to the user</param>
        public static void WaitForKey(string prompt) {
            Debug.Assert(!String.IsNullOrEmpty(prompt), "prompt != null");

            Console.Write(prompt);
            Console.ReadKey();
            Console.WriteLine();
        } // end WaitForKey


    }
}
