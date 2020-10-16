using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public abstract class Player
    {
        //Member Variables
        public List<Player> Players;
        public Player player;

        public Menu Menu;

        public string Name;

        //CTOR??
        public Player(string name)
        {
            Menu = new Menu();                              // Creates the Menu
            Players = new List<Player>();
            this.Name = name;
            
        }

        public virtual string ChooseGesture(Player player)
        {   //Run Logic here?
            return null;
        }

        public void PlayerSelection()
        {                                                   // Initializes the game
            Player player01 = null;                         // Game Specific Variables
            Player player02 = null;
            bool askAgain = false;
            int playerSetupChoice;


            Menu.Clear();
            Console.WriteLine("##### PLAYER SETUP MENU #### \n" +
                              "    1: Human v Human \n" +
                              "    2: Human v Computer \n" +
                              "    3: Computer v Computer \n" +
                              "    4: Return to Main Menu \n");

            do
            {                                               //Set_Up Player01 and Player02
                Console.Write("Enter a menu option: ");
                if (int.TryParse(Console.ReadLine(), out playerSetupChoice))
                {
                    switch (playerSetupChoice)
                    {
                        case 1:
                            {/*Create Human v Human */
                                player01 = new Human("player01");
                                player02 = new Human("player02");
                                Players.Add(player01);
                                Players.Add(player02);
                                break;

                            }
                        case 2:
                            {/*Create Human v AI*/
                                player01 = new Human("player01");
                                player02 = new Computer("Computer AI");
                                Players.Add(player01);
                                Players.Add(player02);
                                break;
                            }
                        case 3:
                            {/*Create AIvAI*/
                                player01 = new Computer("Computer AI 01");
                                player02 = new Computer("Computer AI 01");
                                Players.Add(player01);
                                Players.Add(player02);
                                break;
                            }
                        case 4:
                            {
                                Menu.MainMenu();
                                break;
                            }
                        default:
                            Console.WriteLine("ERROR 400");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect Input");
                    askAgain = true;
                }
            }
            while (askAgain == true);
                        
        }
    }
}
