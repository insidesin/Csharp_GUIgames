using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace SharedGamesClasses {

    /// <summary>
    /// TwentyOne.cs plays the game of Twenty One - 
    /// a card game whereby two parties compete to get a hand of playing cards
    /// whose summed facevalues are closest to 21, without exceeding it.
    /// 
    /// Version May 2012 Jim Reye 
    /// 
    /// </summary>
    public static class TwentyOne {
        public const int NUM_OF_PLAYERS = 2;
        public const int USER = 0;
        public const int DEALER = 1;

        private const string USERS_NAME = "Player";
        private const string DEALERS_NAME = "Dealer";

        private const int NUM_OF_STARTING_CARDS = 2;
        private const int BUST = 21;
        public const int MAXVALUE = 21;
        // More constants and/or class variables may be needed.

        
        private static CardPile cardPile = new CardPile(true);
        private static Hand[] hands = new Hand[NUM_OF_PLAYERS];
        private static int[] pointsTotal = new int[NUM_OF_PLAYERS] { 0, 0 };
        
        public static int[] numOfGamesWon = new int[NUM_OF_PLAYERS] { 0, 0 };

        private static int numOfUserAcesWithValueOne;
        private static int numberOfCardsDealt;
        private static bool playerHasBust = false;
        public static bool ConsoleGame = true;
        
        

        /// <summary>
        /// Set up to play the game, 
        /// by shuffling the pile of cards and dealing the two hands.
        /// </summary>
        public static void SetUpGame() {
            cardPile = new CardPile(true);
            cardPile.Shuffle();
            hands[USER] = new Hand(cardPile.DealCards(NUM_OF_STARTING_CARDS));
            hands[DEALER] = new Hand(cardPile.DealCards(NUM_OF_STARTING_CARDS));
            numOfUserAcesWithValueOne = 0;
            playerHasBust = false;
            numberOfCardsDealt = 0;
        } //end SetUpGame

        /// <summary>
        /// Plays the game of Twenty One until the user decides to stop.
        /// </summary>
        public static void PlayConsole() {

            do {
                SetUpGame();
                DisplayHand(DEALER);
                DisplayHand(USER);

                if (!playerHasBust) {
                    DealACard(USER);
                }

                if (!playerHasBust)
                    DealACard(DEALER);

                DetermineWinner();
            }  while (ConsoleUtilities.WantToPlayAgain() == true);

            numOfGamesWon[USER] = 0;
            numOfGamesWon[DEALER] = 0;
            // Play 21 until the user decides to stop.
        } //end PlayConsole

        /// <summary>
        /// Output the hand of cards of either the User or the Dealer
        ///  using DisplayHand of Hand class
        /// Pre: hands initialised
        /// Post: Displays the hand of cards held by the specified player.
        /// </summary>
        public static void DisplayHand(int player) {
            if (player == USER)
                Trace.Write("\nPlayer has: ");
            else
                Trace.Write("\nDealer has: ");

            hands[player].DisplayHand(false,false);
            if (ConsoleGame) {
                CheckAces(player);
            }
        } // end DisplayHand


        /// <summary>
        /// Checks the starting hand to see if the Dealer has already Busted or has won the game.
        /// Pre: hands initialised
        /// Post: Displays if the Dealer has Already Busted or has won the game
        /// </summary>
        public static void CheckStartingHand() {

            if (HandValue(DEALER) == MAXVALUE) {
                playerHasBust = true;
            } else if (HandValue(DEALER) > BUST) {
                Trace.WriteLine("The Dealer has Bust");
                playerHasBust = true;
            }
        }

        public static int HandValue(int player) {
            int handvalue = 0;
            string cards;

            for (int i = 0; i < hands[player].GetCount(); i++) {

                cards = hands[player].GetCard(i).ToString(true, false);
                if (cards == "J" || cards == "Q" || cards == "K")                   
                    handvalue += 10;
                else if (cards == "A")
                    handvalue += 11;
                else 
                    handvalue += int.Parse(cards);
            }
            
            if (player == USER) 
                handvalue -= numOfUserAcesWithValueOne * 10;
                
            return handvalue;
        }


        /// <summary>
        /// Checks if the User has Aces that hasn't been assigned a value
        /// Pre: An ace is drawn
        /// Post: Prompts the user if he wishes to have the ace valued at 1, or 11
        /// </summary>
        public static bool CheckAces(int player) {
            for (int i = numberOfCardsDealt; i < hands[player].GetCount() && player == USER; i++) {
                numberOfCardsDealt++;

                if (hands[player].GetCard(i).ToString(true, false) == "A" && ConsoleGame) {
                        
                    //Trace.Write("\nYou Have been dealt an Ace, would you like it to be valued at 11");
                    bool AceAsEleven = ConsoleUtilities.DealtAnAce();
                    if (!AceAsEleven)
                        numOfUserAcesWithValueOne++;
                    return true;
                } else if (hands[player].GetCard(i).ToString(true, false) == "A" && !ConsoleGame) {
                    return true; 
                }
              
            }
            return false;
        }

        /// <summary>
        /// Adds a card to the players hand
        /// Pre: If the user or dealer isn't at 21 or they havent stood
        /// Post: Deals a card to the user and then returns the new handvalue of the player
        /// </summary>
        public static int AddCard(int player) {
            hands[player].Add(cardPile.DealOneCard());
            Trace.WriteLine("\nDealing a Card");
            DisplayHand(player);

            return HandValue(player);
        }

        /// <summary>
        /// Checks if the user wishes to hit or stand and if the Dealer has to hit or not
        /// Pre: Hand and cardpile initialised
        /// Post: Prompts the user if he wishes to hit or stand/ Determines if the computer will hit or stand
        /// </summary>
        public static void DealACard(int player) { 
            int handValue = HandValue(player); //HandValue(player);

            while (handValue < BUST && player == USER) {
                if (ConsoleUtilities.HitOrStand())
                    handValue = AddCard(player);
                else
                    break;
            }

            while (handValue < BUST && player == DEALER) {
                if (handValue < 17)
                    handValue = AddCard(player);
                else if (HandValue(DEALER) <= HandValue(USER))
                    handValue = AddCard(player);
                else
                    break;
            }

            if (handValue > BUST)
                playerHasBust = true;

            DisplayHandValue(player);        
        }

        /// <summary>
        /// Determines the winner based on the hand value
        /// Pre: A user has busted or a Users handValue is greater then another
        /// Post: Displays who won, how many games won, and the points in that game.
        /// </summary>
        public static void DetermineWinner() {

            if (HandValue(USER) > 21) {
                Trace.WriteLine(String.Format("\nUser has gone bust ({0} points) You Lose", HandValue(USER)));
                numOfGamesWon[1]++;
            } else if (HandValue(DEALER) > 21) {
                Trace.WriteLine(String.Format("\nDealer has gone bust ({0} points) You Win", HandValue(DEALER)));
                numOfGamesWon[0]++;
            } else if (HandValue(DEALER) < HandValue(USER)) {
                Trace.WriteLine(String.Format("\nUser has ({0} points), Dealer has ({1} points) You Win",
                                  HandValue(USER), HandValue(DEALER)));
                numOfGamesWon[0]++;
            } else if (HandValue(DEALER) > HandValue(USER)) {
                Trace.WriteLine(String.Format("\nUser has ({0} points), Dealer has ({1} points) You Lose",
                                  HandValue(USER), HandValue(DEALER)));
                numOfGamesWon[1]++;
            } else {
                Trace.WriteLine(String.Format("\nUser has ({0} points), Dealer has ({1} points) It's a Tie",
                                  HandValue(USER), HandValue(DEALER)));
            }

            Trace.WriteLine(String.Format("\nYou have won {0} games and Dealer has won {1} games\n",
                            numOfGamesWon[0], numOfGamesWon[1]));
        }

        /// <summary>
        /// Displays the Handvalue of a player
        /// Pre: Cards must be in hand
        /// Post: Displays the handvalues.
        /// </summary>
        public static void DisplayHandValue(int player) {
            if (player == USER)
                Trace.WriteLine(String.Format("\nPlayer Has a Handvalue of: " + HandValue(player)));
            else
                Trace.WriteLine(String.Format("\nDealer Has a Handvalue of: " + HandValue(player)));
        }



        /* The following methods are intended to be called by your GUI code.
         * I.e. you shouldn't need them when writing your Console game,
         * but do not delete them. */

        /// <summary>
        /// Helps the GUI to display what is in a player's hand.
        /// </summary>
        /// <returns>the Hand of the specified player</returns>
        public static Hand GetHand(int player) {
            return hands[player];
        }

        /// <summary>
        /// Helps the GUI to display the number of Aces that 
        /// the user has chosen to have value 1, rather than 11.
        /// </summary>

        /// <returns>the numOfUserAcesWithValueOne</returns>
        public static int GetNumOfUserAcesWithValueOne() {
            return numOfUserAcesWithValueOne;
        }

        /// <summary>
        /// Helps the GUI to display the points total of each player.
        /// </summary>
        /// <returns>the points total of the specified player</returns>
        public static int GetPointsTotal(int player) {
            return pointsTotal[player];
        }

        /// <summary>
        /// Helps the GUI to display the number of games won by each player.
        /// </summary>
        /// <returns>the number of games won by the specified player</returns>
        public static int GetNumOfGamesWon(int player) {
            return numOfGamesWon[player];
        }

        /// <summary>
        /// Helps the GUI to increase the number of Aces that 
        /// the user has chosen to have value 1, rather than 11.
        /// </summary>
        /// <returns>the numOfUserAcesWithValueOne</returns>
        public static int IncreaseNumOfUserAcesWithValueOne() {
            numOfUserAcesWithValueOne += 1;
            return numOfUserAcesWithValueOne;
        }

        /// <summary>
        /// Changes the consolgames variable to false if called in the GUI
        /// </summary>


    } //end class TwentyOne
} //end namespace
