using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace SharedGamesClasses {

    /// <summary>
    /// PileOfCards holds a collection of playing cards.
    /// Objects in this class may be used for different purposes.
    /// When first constructed, a PileOfCards object may contain a full deck of 52 playing cards,
    /// with all the combinations of FaceValue (from Two to Ace) and Suit (from Clubs to Spades).
    /// Alternatively, a PileOfCards object may be constructed as an empty pile, 
    /// e.g. for holding cards that have been discarded during a game.
    /// 
    /// Jim Reye - May 2012
    /// </summary>
    public class CardPile {

        public static int NUM_SUITS = 4;
        public static int NUM_CARDS_PER_SUIT = 13;
        public static int NUM_OF_CARDS = 52;
        private List<Card> pile = new List<Card>();

        private static Random random = new Random();


        /// <summary>
        /// Constructor. 
        /// Normally used to initialise a pile of cards with a full deck of 52 playing cards.
        /// </summary>
        public CardPile(bool initialiseWith52Cards) {

            if (initialiseWith52Cards) {
                // Add 52 cards - One card of each Suit and FaceValue combination to the pile.
                for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++) {
                    for (FaceValue faceValue = FaceValue.Two; faceValue <= FaceValue.Ace; faceValue++) {
                        pile.Add(new Card(suit, faceValue));
                    }
                }
            }
            // else, there are no cards in the pile.
        }

        /// <summary>
        /// Default Constructor - no cards in the pile.
        /// </summary>
        public CardPile() {
        }

        /// <summary>
        /// Adds a card to the pile.
        /// </summary>
        public void Add(Card card) {
            pile.Add(card);
        }

        /// <summary>
        /// Returns the number of cards in the pile, currently.
        /// </summary>
        public int GetCount() {
            return pile.Count;
        }

        /// <summary>
        /// Returns the card in the last position in the pile,
        /// but does not remove it from the pile.
        /// </summary>
        /// <returns></returns>
        public Card GetLastCardInPile() {
            return pile[pile.Count - 1];
        }

        /// <summary>
        /// Shuffles a pile of cards
        /// Pre:   true
        /// Post:  cards in the pile list are rearranged into a random order
        /// </summary>
        public void Shuffle() {
            for (int i = 0; i < GetCount(); i++) {
                int RandomNumber = random.Next(GetCount());
                Card Temp = pile[RandomNumber];
                pile[RandomNumber] = pile[i];
                pile[i] = Temp;

            }
        } //end Shuffle

        /// <summary>
        /// Deals the next card from the pile
        /// Pre: true
        /// Post: returns the next card in the pile, removing it from the pile.
        /// </summary>
        /// <returns>a card</returns>
        public Card DealOneCard() {
            Card card = pile[0];
            card.ToString(true, true);
            pile.RemoveAt(0);
            return card;
        } //end DealOneCard

        /// <summary>
        /// Deals a number of cards from the pile.
        /// Pre: true
        /// Post: numCardsToDeal cards of the pile have been dealt, removing them from the pile.
        /// </summary>
        /// <returns>A list containing the next numCardsToDeal cards from the pile</returns>
        public List<Card> DealCards(int numCardsToDeal) {
            List<Card> cards = new List<Card>();
            for (int i = 0; i <= numCardsToDeal - 1; i++) {
                cards.Add(DealOneCard());
            }
            
            return cards;
        } //end DealCards

    }//end class Pack

}//end namespace
