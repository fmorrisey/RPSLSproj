using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace RPSLS
{
    class GameSpace
    {   //MemberVariables

        
        public Menu Menu;
        public List<Player> Players;
        public GesturesGroup GesturesGroup;
        public Player player;
        //public Player player01;
        //public Player player02;



        public GameSpace()
        {

            Menu = new Menu();                              // Creates the Menu
            Players = new List<Player>();                   // Creates the Player List
            GesturesGroup = new GesturesGroup();
            
            
                       
        }

        public void StartGame()
        {
            //Menu.Welcome();                                 //Welcome players to game
            //Menu.Pause("LOADING...", 1000);                    //"LOADS" The game
            
        }

        public void MainMenu()                              //Obfuscate in the Menu class???
        {   //Initial Menu
            int PlayerMenuChoice;
            bool askAgain = false;

            //MENU LOOP
            do
            {
                //MAIN MENU//
                PlayerMenuChoice = Menu.MainMenu();         // This class draws menu and returns
                switch (PlayerMenuChoice)                   // a player's choice
                {
                    case 1:
                        {
                            PlayerSelection();              // Select Players, creates Player1/2 Object collection
                            RunGame();                      // Runs the gesture game
                            askAgain = true; break;
                        } 
                        
                    case 2: Menu.DisplayeRules(); askAgain = true; break;
                    case 3: askAgain = false; break;
                    default:
                        Console.WriteLine("ERORR 400: Not a Valid Selection");
                        askAgain = false;
                        break;
                }
            } while (askAgain == true);

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
                                player01 = new Human("player01", 0);
                                Console.WriteLine($" {player01.Name} Human Loaded");
                                player02 = new Human("player02", 0);
                                Console.WriteLine($" {player02.Name} Human Loaded");
                                
                                Players.Add(player01);
                                Players.Add(player02);
                                break;

                            }
                        case 2:
                            {/*Create Human v AI*/
                                player01 = new Human("player01", 0);
                                Console.WriteLine($" {player01.Name} Human AI Loaded");
                                player02 = new Computer("Computer AI", 0);
                                Console.WriteLine($" {player02.Name} Computer Loaded");

                                Players.Add(player01);
                                Players.Add(player02);
                                break;
                            }
                        case 3:
                            {/*Create AIvAI*/
                                player01 = new Computer("SKYNET AI@1", 0);
                                Console.WriteLine($" {player02.Name} Computer Loaded");
                                player02 = new Computer("DEEP BLUE AI@2", 0);
                                Console.WriteLine($" {player02.Name} Computer Loaded");
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

        public void RunGame()
        {
            bool isPlayer01Turn = true;
            GestureType player01Gesture;
            GestureType player02Gesture;
            int maxScore = 1; //Best of three %5 best of 5

            //best of 3 or more
            //handle ties
                        

            while (Players[0].Score <= maxScore && Players[1].Score <= maxScore)
            {
                if (isPlayer01Turn == true)
                {
                    player01Gesture = Players[0].ChooseGesture(Players[0]);
                    Console.WriteLine($"{Players[0].Name} choose {player01Gesture.Type}");
                    Menu.WaitForKey($"Press ENTER for {Players[1].Name} turn", 500);
                    isPlayer01Turn = false;
                }
                else
                {
                    player02Gesture = Players[1].ChooseGesture(Players[1]);
                    Console.WriteLine($"{Players[1].Name} choose {player02Gesture.Type}");
                    Menu.WaitForKey($"Press ENTER for {Players[0].Name} turn", 500);
                    isPlayer01Turn = true;
                }
                Console.WriteLine("End Loop");
                Menu.Pause("TEST", 1000);


            }
        }

        public void CompareGesture()
        {

        }

        public Player PlayerSetUp()                     // Proof of Concept
        {                                               // Game Specific Variables
            Player player01 = null;                         
            Player player02 = null;

            //player01 = new Human("");
            //player02 = new Computer("");
            //Players.Add(player01);
            //Players.Add(player02);
            return null;
        }

    }
}
