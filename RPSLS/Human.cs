using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Human : Player
    {
        //Member Variables
        public GestureType gesture;


        public Human(string name, int score) : base(score)
        {
            this.Name = name;
            this.Score = score;
            
            
            
        }

        public override GestureType ChooseGesture(Player player)
        {   //inherits gesture
            //base.ChooseGesture(player);
            
            int playerChoice = 0;
            
            //User chosen logic

            //Menu.PlayerSelection(player);
            Menu.Clear();
            Console.WriteLine($"It's {player.Name} TURN!");
            Menu.MenuDecorators("slashlf");
            playerChoice = Menu.PlayerChoice();
            
            switch (playerChoice)
            {
                case 1: gesture = gesturesGroup.gesturesType[0]; break; // rock
                case 2: gesture = gesturesGroup.gesturesType[1]; break; // paper
                case 3: gesture = gesturesGroup.gesturesType[2]; break; // scissors
                case 4: gesture = gesturesGroup.gesturesType[3]; break; // lizard
                case 5: gesture = gesturesGroup.gesturesType[4]; break; // spock
                default:
                    { Console.WriteLine("Please choose from the list"); break; }
            }

            
            Menu.MenuDecorators("slashrt");

            return gesture;



        }
    }
}
