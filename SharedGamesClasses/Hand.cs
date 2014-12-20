using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SharedGamesClasses {

    public class Hand : IEnumerable {
        // IEnumerable allows code in other classes to use foreach with this class, e.g.
        //      Hand myHand;
        //      ...
        //      foreach (Card card in myHand) {
        //          ...
        //      }
        // The precise details of IEnumerable are unimportant for this assignment.

        private List<Card> cards;

        /// <summary>
        /// Constructor - creates a Hand object that is empty (initially).
        /// </summary>
        public Hand() {
            cards = new List<Card>();
        }

        /// <summary>
        /// Constructor - creates a Hand object from a List of cards.
        /// </summary>
        public Hand(List<Card> cards) {
            this.cards = cards;
        }

        public int CardValue(int index) {
            int Temp = 0;
            bool IsitAnInteger = true;
            IsitAnInteger = int.TryParse(cards[index].ToString(true, false), out Temp);
            Console.WriteLine(Temp);


            return Temp;
        }

        /// <summary>
        /// </summary>
        /// <returns>The number of cards in the hand.</returns>
        public int GetCount() {
            return cards.Count;
        }

        /// <summary>
        /// Gets the card at a given position, without removing it from the hand.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>the card at a given position</returns>
        public Card GetCard(int index) {
            return cards[index];
        }

        /// <summary>
        /// Adds a card to the Hand.
        /// </summary>
        /// <param name="card"></param>
        public void Add(Card card) {
            cards.Add(card);
        }

        /// <summary>
        /// Tests whether the Hand contains a given Card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>True if the card is found in the Hand; otherwise, False.
        /// </returns>
        public bool Contains(Card card) {
            return cards.Contains(card);
        }

        /// <summary>
        /// Removes a given Card from the Hand, if it exists in the Hand.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>True if the card is found and removed; otherwise, False.
        /// </returns>
        public bool Remove(Card card) {
            return cards.Remove(card);
        }

        /// <summary>
        /// Removes a Card from the specified position in the Hand.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        public void RemoveAt(int index) {
            cards.RemoveAt(index);
        }

        /// <summary>
        /// Sorts the cards in the Hand.
        /// </summary>
        public void Sort() {
            cards.Sort();
        }

        /// <summary>
        /// Outputs the hand of cards.
        /// See the ToString method in the Card class for a description of 
        /// the two parameters: shortFormat and displaySuit.
        /// Pre: true
        /// Post: Displayed the hand of cards.
        /// </summary>
        public void DisplayHand(bool shortFormat, bool displaySuit) {
            for (int i = 0; i <= GetCount() - 1; i++) {
                Card card = cards[i];
                Trace.Write(card.ToString(shortFormat, displaySuit) + ", ");
            }
            Trace.WriteLine(" ");
            //
            //**************** CODE NEEDS TO BE ADDED**********************
            // Should be able to call the ToString method in the Card class,
            // as part of this.
            //

        } // end DisplayHand

        // Needed so that IEnumerable works correctly (see comments near top of the file).
        // Do NOT try to call this method directly in your own code.
        public IEnumerator GetEnumerator() {
            return cards.GetEnumerator();
        }
    }
}
