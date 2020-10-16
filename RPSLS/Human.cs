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
               

        public Human(string name) : base(name)
        {
            this.Name = name;
            Console.WriteLine("Human Loaded");
            
            
        }

        public override string ChooseGesture(Player player)
        {   //inherits gesture
            base.ChooseGesture();
            
            //User chosen logic
            int playerChoice = 0;
            string gesture = "";

            Menu.PlayerSelection(player);

            switch (playerChoice)
            {
                case 1: return gesture = "rock";
                case 2: return gesture = "paper";
                case 3: return gesture = "scissors";
                case 4: return gesture = "lizard";
                case 5: return gesture = "spock";
                default: Console.WriteLine("Error 400"); break;
            }
                        
            return playerChoice;



        }
    }
}
