using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


using SharedGamesClasses;

namespace ConsoleGames {
    /// <summary>
    /// Console interface code which displays an initial menu
    /// from which a user selects an option and then the appropriate sub-menu
    /// is displayed and the user selects a game to be played.
    /// 
    /// Authors: Mike Roggenkamp & Jim Reye
    /// 
    /// Version: September 2012
    /// 
    /// Modification:  Used the Trace class rather than Console class to demonstrate using 
    /// a Trace Listener to redirect output. Though the output is still Console.Out
    /// 
    /// No modifications are to be made to this class.
    /// 
    /// </summary>
    
    class ConsoleMain {
        const int EXIT = 0;

        const int SIMPLE_TWO_UP = 1;
        const int TWENTY_ONE = 2;
        const int CRAZY_EIGHTS = 3;
        const int PIG = 4;
        const int HIGHEST_MENU_NUMBER = PIG;

        static int menuOption = EXIT;
       
        static string mainMenu = "\n\n\tWelcome to Games Online \n\n" +
                                   "To make a selection: Enter the number of" +
                                   " your selection.\n\n" +
                                   "\t 1. Two Up\n\n" +
                                   "\t 2. Twenty-One\n\n" +
                                   "\t 3. Crazy Eights\n\n" +
                                   "\t 4. Pig\n\n\n" +
                                   "\t 0. Exit the program.\n\n";


        static void Main(string[] args) {
            
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;

            do {
                DisplayMenu(mainMenu);
                menuOption = GetMenuOption(EXIT, HIGHEST_MENU_NUMBER);
                switch (menuOption) {
                    case SIMPLE_TWO_UP:
                        TwoUp.PlayConsole();
                        break;

                    case TWENTY_ONE:
                        TwentyOne.PlayConsole();
                        break;

                    case CRAZY_EIGHTS:
                        CrazyEights.PlayConsole();
                        break;

                    case PIG:
                        Pig.PlayConsole();
                        break;
           
                    case EXIT:
                        DisplayEndMessage();
                        break;

                    default:
                        Trace.WriteLine("Major Logical error - this message should not appear!");
                        break;

                }// end switch
            } while (menuOption != EXIT);
        } //end Main

        public static void DisplayMenu(string menu) {
            Trace.WriteLine(menu);
            Trace.Write("\nWhich game do you wish to play? ");
        }// end DisplayMenu

        static void PressAny() {
            Trace.Write("\nPress any key to terminate program ...");
            Console.ReadLine();
        }// end PressAny

        static void DisplayEndMessage() {
            Trace.WriteLine("\n\tThank you for using Games Online\n\n");
            PressAny();
        }//end DisplayEndMessage

        public static int GetMenuOption(int lower, int upper) {
            int option;
            do {
                option = int.Parse(Console.ReadLine());
                if ((option < lower) || (option > upper)) {
                    Trace.WriteLine(string.Format("\n\nPlease enter a number between"
                                      + " {0} and {1}\n", lower, upper));
                }
            } while ((option < lower) || (option > upper));
            return option;
        }//end GetMenuOption
        
    }//end class consoleMain
}//end namespace
