using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SharedGamesClasses {

    public static class CrazyEights {

        public const int NUM_OF_PLAYERS = 8;
        public const int USER = 0;
        public const int COMPUTER = 1;

        private const string COMPUTERS_NAME = "Computer";

        private const int NUM_OF_STARTING_CARDS = 1;
        public const int INVALIDCARDS = -1;
        public const int TOOMANYCARDS = -2;
        private const int SORTCARDS = -2;
        public const int MAXIMUMCARDS = 13;
        public const int AVALIDCARD = 0;
        private const int NOPLAYERHASWON = -2;
        public static int ThePlayerWhoWon = NOPLAYERHASWON;
        // More constants and/or class variables may be needed.

        private static CardPile drawPile;     // The pile of cards that the players can draw from.
        private static CardPile discardPile;  // The pile of cards discarded by the players.


        private static Hand[] hands = new Hand[NUM_OF_PLAYERS];

        private static Suit currentSuit;
        public static bool PlayerWon = false;
        public static bool ConsoleGame = true;

        /// <summary>
        /// Set up to play the game, 
        /// by shuffling the drawPile of cards 
        /// and then dealing the two hands.
        /// </summary>
        public static void SetUpGame() {
            PlayerWon = false;
            drawPile = new CardPile(true);
            drawPile.Shuffle();
            hands[USER] = new Hand(drawPile.DealCards(NUM_OF_STARTING_CARDS));
            hands[COMPUTER] = new Hand(drawPile.DealCards(NUM_OF_STARTING_CARDS));
            SetUpTheDiscardPile();
            hands[USER].Sort();
            hands[COMPUTER].Sort();
        } //end SetUpGame


        /// <summary>
        /// Sets up the discard pile so that the first card is the top card of the draw deck,
        /// also the current suit is changed to that of the top cards
        /// Pre: drawpile needs to be initialised
        /// Post: Displays the Top card of the Discard pile and changes the current suit
        /// </summary>
        private static void SetUpTheDiscardPile() {
            discardPile = new CardPile();
            //discardPile.Add(new Card(Suit.Hearts, FaceValue.Eight));
            discardPile.Add(drawPile.DealOneCard());
            DisplayDiscardPileTopCard();
            currentSuit = discardPile.GetLastCardInPile().GetSuit();

        }

        /// <summary>
        /// Display top card of the discard pile in text
        /// Pre: Discardpile and a top card must be initialised
        /// Post: Displays the top card in the discard pile.
        /// </summary>
        public static void DisplayDiscardPileTopCard() {

            Trace.Write("\nThe Card on top of the discard pile is now ");
            Trace.WriteLine(discardPile.GetLastCardInPile().ToString(true, true));
        }

        /// <summary>
        /// Plays the game of Crazy Eights until a player has won
        /// </summary>
        public static void PlayConsole() {
            do {
                SetUpGame();
                DisplayHand(USER);
                DisplayHand(COMPUTER);
                //if a player hasn't won it will alternate between their turns
                while (!PlayerWon) {
                    PlayersTurn(USER);

                    if (!PlayerWon) {
                    PlayersTurn(COMPUTER);
                    }
                }
            } while (ConsoleUtilities.WantToPlayAgain() == true);
            // Play Crazy Eights until the user decides to stop.
        }

        /// <summary>
        /// Allows the player to play a card if they have a valid card in hand,
        /// and if the card chosen is a playable card
        /// Pre: there must be a discard pile and cards in a user's hand
        /// Post: Will place down a card ontop of the discard pile and remove that card from hand
        /// </summary>
        public static int PickACard(int player, string CardToPlay) {
            bool ValidCard = false;


            while (!ValidCard) {
                if (ConsoleGame) {
                    Trace.Write("\nPick One Of Your Cards Or Enter S to Sort Your Cards: ");
                } else {
                    Trace.Write("Pick A Card");
                }
                if (ConsoleGame) {
                    CardToPlay = Console.ReadLine().ToUpper();
                } 


                int Index = CheckIfValidCard(CardToPlay, currentSuit, player);
                //If there is a valid card it will play that card and remove it from hand
                if (Index > INVALIDCARDS) {
                    discardPile.Add(hands[player].GetCard(Index));
                    DisplayDiscardPileTopCard();
                    hands[player].RemoveAt(Index);
                    ValidCard = true;
                //Sorts the players hand
                } else if (Index == SORTCARDS) {
                    hands[player].Sort();
                    DisplayHand(player);
                //For Console Games
                } else if (Index == INVALIDCARDS && !ConsoleGame) {
                    ValidCard = true;
                    return INVALIDCARDS;
                }
            }
            return AVALIDCARD;
        }

        /// <summary>
        /// Checks the drawpile if there is anymore cards left in it, if not it will flip discard pile over,
        ///     and make it become the new drawpile
        /// Pre: Drawpile must be initialised and is called when a player picks up a card
        /// Post: Flips the discard pile making it the new draw pile and displays the new discard pile card.
        /// </summary>
        public static void CheckDrawPile() {

            int CardsinDiscardpile = discardPile.GetCount();

            if (drawPile.GetCount() == 0) {
                Trace.WriteLine("\nThere are no more cards in the draw pile, Turning Over the DiscardPile");


                for (int i = 0; i < CardsinDiscardpile; i++) {
                    drawPile.Add(discardPile.DealOneCard());
                }

                discardPile.Add(drawPile.DealOneCard());
                currentSuit = discardPile.GetLastCardInPile().GetSuit();
                DisplayDiscardPileTopCard();

            }

        }

        /// <summary>
        /// Checks to see if the card the User selected is a valid card to be placed, if it is
        ///     it will return in which position that card is at, if S is selected it will sort the cards.
        /// Pre: Requires the user to Select a card from hand, in which it will take the current suit
        ///     of the discard pile and the players hand.
        /// Post: Will return the position in which the cards are located or indexes that are for different
        ///     purposes such as sorting and or if a invalid card is selected
        /// </summary>
        public static int CheckIfValidCard(string CardToPlay, Suit CardSuit, int player) {

            int index = INVALIDCARDS;

            if (CardToPlay == "S") {
                return index = SORTCARDS;
            }

            for (int i = 0; i < hands[player].GetCount(); i++) {

                if (CardToPlay == hands[player].GetCard(i).ToString(true, true)) {

                    if (hands[player].GetCard(i).GetFaceValue() == FaceValue.Eight) {
                        if (ConsoleGame) {
                            currentSuit = ConsoleUtilities.WhichSuit();
                        }
                        return i;

                    } else if (hands[player].GetCard(i).GetSuit() == CardSuit) {             
                        return i;

                    } else if (hands[player].GetCard(i).GetFaceValue() ==
                               discardPile.GetLastCardInPile().GetFaceValue()) {
                        currentSuit = hands[player].GetCard(i).GetSuit();
                        return i;

                    } else if (FirstCardIsEight()) {
                        currentSuit = hands[player].GetCard(i).GetSuit();
                        return i;

                    } else {
                        Trace.WriteLine("\nYou Cannot Play That Card Right Now");
                        return index;

                    }

                } 

            }

            Console.WriteLine("You Do Not Have That Card");

            return index;
        }

        /// <summary>
        /// Display the User's Hand, Checks to see if they have a valid card they can play also
        /// calls the determinewinners function.
        /// Pre: A player must be selected
        /// Post: PickACard function is called if it's a players turn else the computers turn is called.
        /// </summary>
        public static void PlayersTurn(int player) {
           
            int ValidCard = INVALIDCARDS;

            if (player == USER) {
                Trace.WriteLine("\nYour Turn");
                DisplayHand(player);

            } else if (player == COMPUTER) {
                Trace.WriteLine("\nComputer's Turn");
                DisplayHand(player);

            }
            while (ValidCard == INVALIDCARDS) {
                ValidCard = HasAValidCard(player);
            }

            if (player == USER && ValidCard != TOOMANYCARDS) {
                PickACard(player, "");

            } else if (player == COMPUTER && ValidCard != TOOMANYCARDS) {
                int Index = (ComputerTurn());
                discardPile.Add(hands[player].GetCard(Index));
                DisplayDiscardPileTopCard();
                hands[player].RemoveAt(Index);
                currentSuit = discardPile.GetLastCardInPile().GetSuit();
            }

            DetermineWinner(player);
        
        }

        /// <summary>
        /// Chekcs the Computers hand to see what card he must play first.
        /// Pre: The computer must have a valid card in hand
        /// Post: Returns the position at which the card is held
        /// </summary>
        public static int ComputerTurn() {

            hands[COMPUTER].Sort();

            for (int i = 0; i < hands[COMPUTER].GetCount(); i++) {
                if (FirstCardIsEight() && hands[COMPUTER].GetCard(i).GetFaceValue() != FaceValue.Eight) {      
                    return i;
                }
            }
            for (int i = 0; i < hands[COMPUTER].GetCount(); i++) {

                if (hands[COMPUTER].GetCard(i).GetFaceValue() ==
                            discardPile.GetLastCardInPile().GetFaceValue() &&
                            hands[COMPUTER].GetCard(i).GetFaceValue() != FaceValue.Eight) {
                    return i;

                } 
            }

            for (int i = 0; i < hands[COMPUTER].GetCount(); i++) { 
   
                 if (hands[COMPUTER].GetCard(i).GetSuit() == currentSuit &&
                     hands[COMPUTER].GetCard(i).GetFaceValue() != FaceValue.Eight) {
                    return i;
                } 
            }

            for (int i = 0; i < hands[COMPUTER].GetCount(); i++) {
                 if (hands[COMPUTER].GetCard(i).GetFaceValue() == FaceValue.Eight) {
                    return i;
                }
            }
            return INVALIDCARDS;
        }

        /// <summary>
        /// Checks to see if the first card of the Discard pile is 8, if so allows the user and Computer to
        /// place any card they wish.
        /// Pre: DiscardPile must be intialised
        /// Post: Returns whether or not the first card is an 8 or not
        /// </summary>
        public static bool FirstCardIsEight() {     

            if (discardPile.GetCount() == 1 &&
                            discardPile.GetLastCardInPile().GetFaceValue() == FaceValue.Eight) {
                return true;
            }

            return false; 
        }

        /// <summary>
        /// Check the players hand to see if they have any cards that they can play. or if they
        /// have to may cards and must pass their turn.
        /// Pre: The player selected must have cards in their hands.
        /// Post: Returns a positive integer if there is a valid card, or it will return negative integers
        /// if a player has too many cards or they dont have a valid card.
        /// </summary>
        public static int ValidCard(int player) {

            int Validcard = 0;

            for (Validcard = 0; Validcard < hands[player].GetCount(); Validcard++) {

                if (hands[player].GetCard(Validcard).GetFaceValue() ==
                            discardPile.GetLastCardInPile().GetFaceValue()) {
                    return Validcard;

                } else if (hands[player].GetCard(Validcard).GetSuit() == currentSuit) {
                    return Validcard;

                } else if (hands[player].GetCard(Validcard).GetFaceValue() == FaceValue.Eight) {
                    return Validcard;

                } else if (FirstCardIsEight()) {
                    return Validcard;
                }
            }

            if (hands[player].GetCount() == 13) {
                Trace.WriteLine("\nPlayer Has Too Many Cards, Passing Turn");
                return Validcard = TOOMANYCARDS;
            }

            if (player == USER) {
                Trace.WriteLine("\nYou do not have any playable cards, Drawing a Card");

            } else {
                Trace.WriteLine("\nComputer does not have any playable cards, Drawing a Card");

            }
            return Validcard = INVALIDCARDS;
        }

        /// <summary>
        /// Checks the Users hand to see if they have any playable cards, if not it will pick up a card
        /// Pre: Hand must be initialised
        /// Post: If there are no playable cards, it will pick up a card and then loop unless there is
        /// too many cards in the players hand.
        /// </summary>
        public static int HasAValidCard(int player) {

            int PlayableCard = ValidCard(player);

            if (PlayableCard == INVALIDCARDS) {
                DrawACard(player);

                return INVALIDCARDS;
            } else if (PlayableCard == TOOMANYCARDS) {
                return TOOMANYCARDS;
            }


            return 1;
        }
        /// <summary>
        /// Draws a card for the player
        /// Pre: The player must not have any valid cards they can play
        /// Post: Adds a card to the players hand and then checks if theres any cards left in the drawpile
        /// </summary>
        public static void DrawACard(int player) {
            hands[player].Add(drawPile.DealOneCard());
            CheckDrawPile();
            DisplayHand(player);
        }

        /// <summary>
        /// Determines which player won or if it's a draw when they both have 13 cards and cant play a card.
        /// Pre: A player must be selected
        /// Post: Ends the game and displays who won or drew.
        /// </summary>
        public static int DetermineWinner(int player) {
            ThePlayerWhoWon = NOPLAYERHASWON;
            if (hands[player].GetCount() == 0) {

                if (player == USER) {

                    Trace.WriteLine("\nUser has no cards Left and wins the game.\n");
                    ThePlayerWhoWon = USER;

                } else if (player == COMPUTER) {

                    Trace.WriteLine("\nComputer has no cards Left and wins the game.\n");
                    ThePlayerWhoWon = COMPUTER;
                }

                PlayerWon = true;
            }

            if (hands[USER].GetCount() == 13 && hands[COMPUTER].GetCount() == MAXIMUMCARDS) {
                Trace.WriteLine("\nBoth Players have no cards left they can play, its a Draw\n");
                ThePlayerWhoWon = INVALIDCARDS;
                PlayerWon = true;
            }
            return ThePlayerWhoWon;

        }

        /// <summary>
        /// Output the hand of cards of either the User or the Dealel CardInHand = false;
        /// Pre: hands initialised
        /// Post: Displays the hand of cards held by the specified player.
        /// </summary>
        public static void DisplayHand(int player) {
            
            if (player == USER) {
                Trace.Write("\nPlayer has: ");
            } else {
                Trace.Write("\nDealer has: ");
            }

            hands[player].DisplayHand(true,true);

        } // end DisplayHand

        /// <summary>
        /// Lets the GUI or Console game set the current Suit.
        /// </summary>
        public static void SetCurrentSuit(Suit newSuit) {
            currentSuit = newSuit;
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
        /// Helps the GUI to sort a player's hand.
        /// </summary>
        /// <returns>the Hand of the specified player</returns>
        public static void SortHand(int player) {
            hands[player].Sort();
        }

        /// <summary>
        /// Helps the GUI to display what is on the top of the discard pile.
        /// </summary>
        /// <returns>the card on the top of the discard pile.</returns>
        public static Card GetTopCardOnDiscardPile() {
            return discardPile.GetLastCardInPile();
        }

        /// <summary>
        /// Tells the GUI whether there are any cards left in the draw pile.
        /// </summary>
        /// <returns>True, if there is at least one card in the draw pile. False, otherwise. </returns>
        public static bool DrawPileHasCards() {
            return (drawPile.GetCount() > 0);
        }

      

    } //end class CrazyEights
} //end namespace
