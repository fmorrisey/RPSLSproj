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

        public Computer(string name) : base()
        {
            this.Name = name;
            //Console.WriteLine("Computer Loaded");
            //Random random = new Random();
        }

        public override string ChooseGesture(Player player)
        {   //inherits gesture
            base.ChooseGesture(player);
            //Computer generates Gesture
            string gesture = null;
            int HashValue = AIrandomGen();

            switch (HashValue)
            {
                case 1: return gesture = "rock";
                case 2: return gesture = "paper";
                case 3: return gesture = "scissors";
                case 4: return gesture = "lizard";
                case 5: return gesture = "spock";
                default: Console.WriteLine("Error 400"); break;
            }
                       
            return gesture;
        }

        private int AIrandomGen()
        {
            int hash = 0;
            Random.Next(1, 5);
            return hash;
          
        }
    }
}
