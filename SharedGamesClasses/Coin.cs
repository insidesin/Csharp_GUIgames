using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedGamesClasses {
    /// <summary>
    /// Coin.cs is based on Coin.java written
    /// by Author: Lewis/Loftus "Java Software Solutions"
    /// 
    /// Modification: April 2009 by Mike Roggenkamp
    ///      Converted to C# and School of IT C# Coding Sytle Convention 
    ///      
    /// Represents a coin with two sides that can be flipped.
    /// 
    /// </summary>
    class Coin {
        private const int HEADS = 0;
        private const int TAILS = 1;

        private int face;

        /// <summary>
        /// Random class object used to generate random numbers
        /// Look at Random class for description of methods available
        /// </summary>
        private static Random random = new Random();

        //-----------------------------------------------------------------
        //  Sets up the coin by flipping it initially.
        //-----------------------------------------------------------------
        public Coin() {
            Flip();
        }

        //-----------------------------------------------------------------
        //  Flips the coin by randomly choosing a face value.
        //-----------------------------------------------------------------
        public void Flip() {
            face = random.Next(2);
        }

        //-----------------------------------------------------------------
        //  Returns true if the current face of the coin is heads.
        //-----------------------------------------------------------------
        public bool IsHeads() {
            return (face == HEADS);
        }

        //-----------------------------------------------------------------
        //  Returns the current face of the coin as a string.
        //-----------------------------------------------------------------
        public override string ToString() {
            string faceName;

            if (IsHeads()) {
                faceName = "Heads";
            } else {
                faceName = "Tails";
            }

            return faceName;
        }
    } //end class Coin
}//end namespace
