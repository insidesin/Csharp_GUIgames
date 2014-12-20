using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedGamesClasses {
    public enum Suit { Clubs, Diamonds, Hearts, Spades }

    public enum FaceValue {
        Two, Three, Four, Five, Six, Seven, Eight, Nine,
        Ten, Jack, Queen, King, Ace
    }



    /// <summary>
    /// Class to represent playing card with a Suit and FaceValue (pips).
    /// 
    /// Based on an earlier Java program written in 2002 for Software Development 1 (ITB410)
    /// 
    /// Default Constructor allows application to have "blank" cards 
    /// 
    /// Mike Roggenkamp & Jim Reye
    /// </summary>
    public class Card : IEquatable<Card>, IComparable<Card> {
        // IEquatable allows Card objects to be compared to see if two cards have the same value.
        // IComparable allows Card objects to be sorted easily.
        // While the precise details of IEquatable and IComparable are unimportant for this assignment,
        // they are needed so that the Hand class's Sort and Contains methods each work correctly.
    
        private Suit suit;
        private FaceValue faceValue;

       // Default constructor: Card is "blank" 
        public Card() {
        }

        // The constructor normally used when you know its Suit and FaceValue values.
        public Card(Suit suit, FaceValue faceValue) {
            this.suit = suit;
            this.faceValue = faceValue;
        }

        // This method lets you create a Card object from a string (which is normally entered by the user).
        // E.g. 10C for Ten Of Clubs; AH for Ace of Hearts.
        // Lowercase is also ok, e.g. 10c for Ten Of Clubs; ah for Ace of Hearts.
        // Returns a Card if the CardCode is valid; otherwise null. 
        public static Card TryToCreateCard(string cardCode) {  

            bool validCardCode = true;
            cardCode = cardCode.ToUpper();
            int faceLength = cardCode.Length - 1;
            if (faceLength < 1)
                return null;  // Otherwise Substring throws an exception.
            string faceAsString = cardCode.Substring(0, faceLength);
            string suitAsString = cardCode.Substring(faceLength, 1);

            Suit suit = 0;
            FaceValue faceValue = 0;

            switch (faceAsString) {
                case "2": faceValue = FaceValue.Two; break;
                case "3": faceValue = FaceValue.Three; break;
                case "4": faceValue = FaceValue.Four; break;
                case "5": faceValue = FaceValue.Five; break;
                case "6": faceValue = FaceValue.Six; break;
                case "7": faceValue = FaceValue.Seven; break;
                case "8": faceValue = FaceValue.Eight; break;
                case "9": faceValue = FaceValue.Nine; break;
                case "10": faceValue = FaceValue.Ten; break;
                case "J": faceValue = FaceValue.Jack; break;
                case "Q": faceValue = FaceValue.Queen; break;
                case "K": faceValue = FaceValue.King; break;
                case "A": faceValue = FaceValue.Ace; break;
                default: validCardCode = false; break;
            }

            

            switch (suitAsString) {
                case "C": suit = Suit.Clubs; break;
                case "D": suit = Suit.Diamonds; break;
                case "H": suit = Suit.Hearts; break;
                case "S": suit = Suit.Spades; break;
                default: validCardCode = false; break;
            }

            if (validCardCode) {
                return new Card(suit, faceValue);
            } else {
                return null;
            }
        }

        // An accessor.
        public Suit GetSuit() {
            return suit;
        }

        // Another accessor.
        public FaceValue GetFaceValue() {
            return faceValue;
        }

        

        // Returns a string that describes the card's value.
        //
        // When shortFormat is False, the card's FaceValue is returned as its full name, 
        //      e.g. Two, Three, ..., King, Ace.
        // When shortFormat is True, the card's FaceValue is returned as one or two characters, 
        //      e.g. 2, 3, ... 10, J, Q, K, A.
        //
        // When displaySuit is False, the card's Suit is ignored.
        // When displaySuit is True, the card's Suit is added on the end, 
        //      e.g. " of Clubs" when shortFormat is False,
        //                or "C" when shortFormat is True, as in "2C".
        public string ToString(bool shortFormat, bool displaySuit)
        {
            string returnString;

            // Describe the FaceValue.
            FaceValue faceValue = GetFaceValue();
            string faceValueAsString = faceValue.ToString();
            if (shortFormat) {
                if (faceValue <= FaceValue.Ten) {
                    faceValueAsString = (faceValue - FaceValue.Two + 2).ToString();
                } else {
                    faceValueAsString = faceValueAsString.Substring(0, 1);
                }
            }

            returnString = faceValueAsString;

            // Describe the Suit.
            if (displaySuit) {
                string suit = GetSuit().ToString();
                if (shortFormat) {
                    suit = suit.Substring(0, 1);
                    returnString += suit;
                } else {
                    returnString += " of " + suit;
                }
            }

            return returnString;
        }

        // Needed so that the Hand class's Contains method works correctly.
        // You should NOT need to call this Equals method directly in your own code.
        // Returns True if one card is equal to another, e.g. myCard.Equals(anotherCard).
        // Otherwise, returns False.
        public bool Equals(Card anotherCard) {
            return (this.suit == anotherCard.suit && this.faceValue == anotherCard.faceValue);
        }

        // Needed so that the Hand class's Sort method works correctly.
        // You should NOT need to call this CompareTo method directly in your own code.
        // Returns:
        //      -1 if the current card precedes anotherCard in the sort order;
        //       0 if the current card is in the same position as anotherCard in the sort order;
        //      +1 if the current card follows anotherCard in the sort order.
        public int CompareTo(Card anotherCard) {

            if (this.suit < anotherCard.suit) {
                return -1;
            } else if (this.suit > anotherCard.suit) {
                return 1;
            } else {
                if (this.faceValue < anotherCard.faceValue) {
                    return -1;
                } else if (this.faceValue > anotherCard.faceValue) {
                    return 1;
                } else {
                    return 0;
                }
            }
        }

    } //end class Card
}//end namespace
