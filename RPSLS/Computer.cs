using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{   // Computer AI CLASS
    public class Computer : Player
    {   
        //Member Variables
        Random Random; //to randomized choices
        public GestureType gesture;




        public Computer(string name, int score) : base(score)
        {
            this.Name = name;
            this.Score = score;
            
            score = 0;
        }

        public override GestureType ChooseGesture(Player player)
        {   //inherits gesture
            //base.ChooseGesture(player);
            //Computer generates Gesture
            
            int HashValue = AIrandomGen();                               //Generate's AI Choice

            Menu.Clear();
            Console.WriteLine($"It's @AI: {player.Name} TURN!");     
            Menu.MenuDecorators("slashrt");                             
            Menu.ComputerChoice();                                       //Draw's Computer's Menu
            
            switch (HashValue)
            {
                case 1: gesture = gesturesGroup.gesturesType[0]; break; // rock
                case 2: gesture = gesturesGroup.gesturesType[1]; break; // paper
                case 3: gesture = gesturesGroup.gesturesType[2]; break; // scissors
                case 4: gesture = gesturesGroup.gesturesType[3]; break; // lizard
                case 5: gesture = gesturesGroup.gesturesType[4]; break; // spock
                default:
                    { Console.WriteLine("Please choose from the list"); break; }
            }
            
            Menu.MenuDecorators("slashlf");
                       
            return gesture;
        }

        private int AIrandomGen()
        {
            Random = new Random();
            int hash = Random.Next(1, 5);
            return hash;
          
        }
    }
}
