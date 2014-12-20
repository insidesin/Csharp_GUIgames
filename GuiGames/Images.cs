using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using SharedGamesClasses;

namespace GuiGames {

    /// <summary>
    /// Provides easy access to coin and card images, via the GetCoinImage and GetCardImage methods.
    /// 
    /// For your assignment, it is not important to understand all the finer details 
    /// of all the methods in this class.
    /// 
    /// Do not confuse this class with the Microsoft-provided class, Image, which has a similar name.
    /// </summary>
    public static class Images {

        private static Bitmap heads;
        private static Bitmap tails;

        public static Bitmap backOfCard;
        private static Bitmap[,] cardImages;
        /// <summary>
        /// Constructor - Loads images from disk files.
        /// </summary>
        static Images() {
            // Load coin images.
            heads = LoadImage("Coins", "Heads150");
            tails = LoadImage("Coins", "Tails150");

            // Load card images.
            backOfCard = Images.LoadImage("Cards", "CardBack_Red");
            cardImages = new Bitmap[CardPile.NUM_SUITS, CardPile.NUM_CARDS_PER_SUIT];

            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++) {
                for (FaceValue faceValue = FaceValue.Two; faceValue <= FaceValue.Ace; faceValue++) {
                    Card card = new Card(suit, faceValue);
                    string cardImageName = GetCardImageName(card);
                    cardImages[(int) card.GetSuit(), (int) card.GetFaceValue()] = LoadImage("Cards", cardImageName);
                }
            }
        }

        /// <summary>
        /// Returns a head or tails image.
        /// </summary>
        /// <param name="Heads"></param>
        /// <returns>a head image if prarameter Heads is True; a tails image otherwise</returns>
        public static Bitmap GetCoinImage(bool Heads) {
            if (Heads) {
                return heads;
            } else {
                return tails;
            }
        }

        /// <summary>
        /// Returns the image for a given Card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>the image for the Card specified by the parameter.</returns>
        public static Bitmap GetCardImage(Card card) {
            return cardImages[(int)card.GetSuit(), (int)card.GetFaceValue()];
        }

        /// <summary>
        /// Used by the constructor in this class only.  Do NOT use elsewhere.
        /// </summary>
        private static string GetCardImageName(Card card) {
            Suit suit = card.GetSuit();
            FaceValue faceValue = card.GetFaceValue();
            return string.Format("{0}{1}", suit.ToString().TrimEnd('s'), faceValue);
        }

        /// <summary>
        /// Used by the constructor in this class only.  Do NOT use elsewhere.
        /// </summary>
        private static Bitmap LoadImage(string subfolderName, string imageName) {
            string fileSpec = string.Format(@".\Images\{0}\{1}.png", subfolderName, imageName);
            Bitmap bitmap = new Bitmap(fileSpec);
            return bitmap;
        }
    }
}
