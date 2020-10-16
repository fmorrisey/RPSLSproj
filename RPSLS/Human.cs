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
        public string gesture;                               

        public Human(string name, int score) : base(score)
        {
            this.Name = name;
            this.Score = score;
            //Menu = New Menu();
            
        }

        public override string ChooseGesture(Player player)
        {   //inherits gesture
            //base.ChooseGesture(player);
            
            //User chosen logic
            int playerChoice = 0;
            
            bool askAgain = false;

            //Menu.PlayerSelection(player);
            Menu.Clear();
            Console.WriteLine($"It's {player.Name} TURN!");
            Menu.MenuDecorators("slashlf");
            playerChoice = Menu.PlayerChoice();
            
            switch (playerChoice)
            {
                case 1: return gesture = "rock";
                case 2: return gesture = "paper";
                case 3: return gesture = "scissors";
                case 4: return gesture = "lizard";
                case 5: return gesture = "spock";
                default:
                    {
                        Console.WriteLine("Please choose from the list");
                        askAgain = true;
                        break;
                    }
            }
                 

            return null;



        }
    }
}
