using System;
using System.Collections.Generic;

namespace RPSLS
{
    class GameSpace
    {   //MemberVariables

        
        public Menu Menu;
        public List<Player> Players;
        //public Player player01;
        //public Player player02;


        public GameSpace()
        {

            Menu = new Menu();                              // Creates the Menu
            Players = new List<Player>();                   // Creates the Player List
            List<Gesture> gestures = new List<Gesture>()    // Creates the Gesture List
            {                                               // This List could use some
                new Gesture("Rock"),                        // Here Gestures eh
                new Gesture("Paper"),
                new Gesture("Scissors"),
                new Gesture("Lizard"),
                new Gesture("Mr. Spock"),
            };
        }

        public void StartGame()
        {   //Welcome players to game
            //Menu.Welcome();
            //Console.WriteLine("GAME START");
            Console.WriteLine("RunGame");
            Menu.Pause("LOADING...", 0);                    //"LOADS" The game
        }

        public void MainMenu()                              //Obfuscate in the menu class???
        {   //Initial Menu
            int PlayerMenuChoice;
            bool askAgain = false;

            //MENU LOOP
            do
            {
                //MAIN MENU//
                PlayerMenuChoice = Menu.MainMenu();         //Loads Graphics and asks for choice
                switch (PlayerMenuChoice)
                {
                    case 1: RunGame(); askAgain = true; break;
                    case 2: Menu.DisplayeRules(); askAgain = true; break;
                    case 3: askAgain = false; break;
                    default:
                        Console.WriteLine("ERORR 400: Not a Valid Selection");
                        askAgain = false;
                        break;
                }
            } while (askAgain == true);


        }

        public void RunGame()
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
                                player01 = new Human();
                                player02 = new Human();
                                Players.Add(player01);
                                Players.Add(player02);
                                break;
                            }
                        case 2:
                            {/*Create Human v AI*/
                                player01 = new Human();
                                player02 = new Computer();
                                Players.Add(player01);
                                Players.Add(player02);
                                
                                break;
                            }
                        case 3:
                            {/*Create AIvAI*/
                                player01 = new Computer();
                                player02 = new Computer();
                                Players.Add(player01);
                                Players.Add(player02);
                                break;
                            }
                        case 4:
                            {
                                MainMenu();
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

        public Player PlayerSetUp()                     // Proof of Concept
        {                                               // Game Specific Variables
            Player player01 = null;                         
            Player player02 = null;

            player01 = new Human();
            player02 = new Computer();
            Players.Add(player01);
            Players.Add(player02);
            return null;
        }

    }
}
