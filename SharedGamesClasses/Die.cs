using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SharedGamesClasses {
    /// <summary>
    /// Die.cs models a many sided die with each face 
    /// having a distinct and unique value between 1 
    /// and the number of faces.
    /// 
    /// default is a 6 sided die.
    /// 
    /// Mike Roggenkamp April 2009
    /// 
    /// Modifications: Set the Randon object to static so that multiple dice 
    /// are more likely to have diffent faceValues.  July 2009 MGR
    /// 
    /// 
    /// 
    /// </summary>
    public class Die {
        private const int MIN_FACES = 4;
        private const int DEFAULT_FACE_VALUE = 1;
        private const int SIX_SIDED = 6;
        

        private int numFaces;   // number of sides on the die
        private int faceValue;  // current value showing on the die

        private int initialFaceValue; //use only in Reset()

        private static Random random = new Random();
    

       //-----------------------------------------------------------------
       //  Parameterless Constructor
       //  defaults to a six-sided die with a default initial face value.
       //-----------------------------------------------------------------
        public Die() {
           
           numFaces = SIX_SIDED;
           faceValue = DEFAULT_FACE_VALUE;
        } 

       //-----------------------------------------------------------------
       //  Explicitly sets the size of the die. Defaults to a size of
       //  six if the parameter is invalid.  Face value is randomly chosen
       //-----------------------------------------------------------------
       public Die(int faces){
           
           if (faces < MIN_FACES) {
                numFaces = SIX_SIDED;
            } else {
                numFaces = faces;
            }

            faceValue = Roll();
	        initialFaceValue = faceValue;
       }

       //-----------------------------------------------------------------
       //  Rolls the die and returns the result.
       //-----------------------------------------------------------------
       public int Roll() {
           faceValue =  random.Next(numFaces) + 1;
           return faceValue;
       }
     
     
       //-----------------------------------------------------------------
       //  Resets the die face value to its initial value.
       //-----------------------------------------------------------------
       public void Reset() {
           faceValue = initialFaceValue;
        }

       //----------------------------------------------------------------- 
       //  Returns the current die value.
       //-----------------------------------------------------------------
       public int GetFaceValue() {
           return faceValue;
       }

       //----------------------------------------------------------------- 
       //  Returns the number of faces of this die .
       //-----------------------------------------------------------------
       public int GetNumFaces() {
           return numFaces;
       }

  
        //----------------------------------------------------------------
        // Returns a String representation of the dice's attributes.
        //----------------------------------------------------------------
       public override string ToString() {
           string str = "current face    = " + faceValue + "\n" +
                       "number of faces = " + numFaces + "\n" ;
           return str;
       }
    }

}
