using System;

namespace RPSLS
{  /// <summary>
   /// This child class inherits from the player class and is
   /// what creates the AI experience for the game.
   /// Destroy only if sentience is questioned
   /// </summary>
    public class Computer : Player
    {
        //Member Variables
        Random Random; //to randomized choices
        public GestureType gesture;

        public Computer(string name, int score) : base(score)
        {
            this.Name = name;
            this.Score = score;
        }

        public override GestureType ChooseGesture(Player player)
        {   // AI'S Gesture section process
            int HashValue = AIrandomGen();                              //Generate's AI Choice

            Menu.Clear();                                               //Draw's Computer's Menu    
            Console.WriteLine($"It's @AI: {player.Name} TURN!");
            Menu.MenuDecorators("slashrt");
            Menu.ComputerChoice();

            switch (HashValue)                                          // the gesture type based on random choice
            {
                case 1: gesture = gesturesGroup.gesturesType[0]; break; // rock 0
                case 2: gesture = gesturesGroup.gesturesType[1]; break; // paper 1
                case 3: gesture = gesturesGroup.gesturesType[2]; break; // scissors 2
                case 4: gesture = gesturesGroup.gesturesType[3]; break; // lizard 3
                case 5: gesture = gesturesGroup.gesturesType[4]; break; // Mr. spock 4
                default:
                    { Console.WriteLine("Please choose from the list"); break; }
            }

            Menu.MenuDecorators("slashlf");

            return gesture;
        }

        private int AIrandomGen()
        {   // Generates computer's AI
            Random = new Random(Guid.NewGuid().GetHashCode());
            int hash = 0; //Scrambles the numbers a bit
            hash = Random.Next(1, 5);
            hash = Random.Next(1, 5);
            hash = Random.Next(1, 5); // Best of three
            return hash;

        }
    }
}
