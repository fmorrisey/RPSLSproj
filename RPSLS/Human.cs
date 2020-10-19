using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Human : Player
    {
        /// <summary>
        /// This child class inherits from the player class and is where
        /// all of the human side functions are handled and controlled.
        /// </summary>
        /// 
        //Member Variables
        public GestureType gesture;

        public Human(string name, int score) : base(score)
        {
            this.Name = name;
            this.Score = score;
        }

        public override GestureType ChooseGesture(Player player)
        {   // Logic runs after the gesture has be user selected 
            int playerChoice = 0;
            Menu.Clear();
            Console.WriteLine($"It's {player.Name} TURN!");
            Menu.MenuDecorators("slashlf");

            Menu.DrawGestureChoice();                                   // Draws the menu

            playerChoice = PlayerChooseGesture();                       // Handles input validation

            switch (playerChoice)                                       //Returns the gesture choice
            {
                case 1: gesture = gesturesGroup.gesturesType[0]; break; // rock 0
                case 2: gesture = gesturesGroup.gesturesType[1]; break; // paper 1
                case 3: gesture = gesturesGroup.gesturesType[2]; break; // scissors 2
                case 4: gesture = gesturesGroup.gesturesType[3]; break; // lizard 3
                case 5: gesture = gesturesGroup.gesturesType[4]; break; // spock 4
                default:
                    { Console.WriteLine("Please choose from the list"); break; }
            }
                        
            Menu.MenuDecorators("slashrt");

            return gesture;
        }

        public int PlayerChooseGesture()
        {   // Asks player for their input and validates
            int GestureSelection = 0;
            bool askAgain;
            
            do
            {
                if (int.TryParse(Console.ReadLine(), out GestureSelection)) // If Integer 
                    if (GestureSelection >= 1 && GestureSelection <= 5)     // And Between Range
                    { return GestureSelection; }                            // Return Selection                               
                    else { Console.WriteLine("Incorrect Input"); askAgain = true; }
                else { Console.WriteLine("Incorrect Input"); askAgain = true; }
            } while (askAgain == true);

            return GestureSelection;
        }

    }
}
