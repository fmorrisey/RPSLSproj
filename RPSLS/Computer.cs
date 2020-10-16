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
        public string Name;
        

        public Computer(string name, int score) : base(score)
        {
            this.Name = name;
            this.Score = score;
            
            score = 0;
        }

        public override string ChooseGesture(Player player)
        {   //inherits gesture
            //base.ChooseGesture(player);
            //Computer generates Gesture
            string gesture = null;
            int HashValue = AIrandomGen();                               //Generate's AI Choice

            Menu.Clear();
            Console.WriteLine($"It's @AI: {player.Name} TURN!");     
            Menu.MenuDecorators("slashrt");                             
            Menu.ComputerChoice();                                       //Draw's Computer's Menu
            
            switch (HashValue)
            {
                case 1:
                    { gesture = "rock"; 
                        //Console.WriteLine($"{player.Name}chose {gesture}");
                        break; 
                    }
                case 2:
                    { gesture = "paper"; 
                        //Console.WriteLine($"{player.Name}chose {gesture}");
                        break;
                    }
                case 3:
                    { gesture = "scissors";
                        //Console.WriteLine($"{player.Name}chose {gesture}");
                        break;
                    }
                case 4:
                    { gesture = "lizard"; 
                        //Console.WriteLine($"{player.Name}chose {gesture}");
                        break;
                    }
                case 5:
                    { gesture = "spock"; 
                        //Console.WriteLine($"{player.Name}chose {gesture}");
                        break;
                    }
                default: Console.WriteLine("Error 400"); break;
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
