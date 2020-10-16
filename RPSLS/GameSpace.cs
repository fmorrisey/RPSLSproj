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

        

        GestureType player01Gesture;
        GestureType player02Gesture;

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
                                Console.WriteLine($" {player01.Name} Computer Loaded");
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
            int roundCounter = 1;               
            int maxScore = 1;                   //Best of three
            int userRounds = 3;
            int roundWinner;
            bool gameWinner = true;

            do
            {

                player01Gesture = Players[0].ChooseGesture(Players[0]);                 //Player 1 chooses gesture
                Console.WriteLine($"{Players[0].Name} choose {player01Gesture.Type}");  //Tells player the move
                Menu.WaitForKey($"Press ENTER for {Players[1].Name} turn", 500);        //Waits
                
                player02Gesture = Players[1].ChooseGesture(Players[1]);                 //Player 2 chooses gesture
                Console.WriteLine($"{Players[1].Name} choose {player02Gesture.Type}");  //tells player the move
                
                Menu.MenuDecorators("starlng");                                         //Here we draw the results
                roundWinner = CompareGesture();
                Console.WriteLine($"{Players[0].Name} choose {player01Gesture.Type} \n" +
                                  $"{Players[1].Name} choose {player02Gesture.Type}");
                Menu.MenuDecorators("starlng");
                
                if (roundWinner == 0)                                                   //Determine Round winner
                {   // 0 == P1 Win // 1 == P2 Win // 2 else == Tie
                    Players[0].Score += 1;                                              //Increment Player1 Score
                    Console.WriteLine($"{ Players[0].Name} WINS! Score: { Players[0].Score}"); //Announce round winner
                }
                else if (roundWinner == 1)
                {
                    Players[1].Score += 1;                                              //Increment Player2 Score
                    Console.WriteLine($"{ Players[1].Name} WINS! Score: { Players[1].Score}"); //Announce round winner
                }
                else { Console.WriteLine("TIE!!!");}                                    //Determines Tie

                Menu.MenuDecorators("starlng");
                
                Console.WriteLine("ROUND SCORE:");
                Console.WriteLine($"{Players[0].Name} Score:{Players[0].Score}" +       //Player 1 Score
                                $" V {Players[1].Name} Score:{Players[1].Score}");      //Player 2 Score
                
                Menu.WaitForKey("Ready for the next round?", 1000);
            }
            while (Players[0].Score <= maxScore && Players[1].Score <= maxScore);

            if (Players[0].Score > Players[1].Score) { gameWinner = true; }             //Set Player 1 as Winner  
            else { gameWinner = false; }                                                //Set Player 2 as Winner  

            /////////End Game Logic needs to works/////////
            if (gameWinner == true) { Console.WriteLine($"{Players[0].Name} Wins the game with {Players[0].Score} points"); }
            else if (gameWinner == false) { Console.WriteLine($"{Players[1].Name} Wins the game with {Players[1].Score} points"); }
            else { Console.WriteLine("MOM!!! THE UNIVERSE BROKE AGAIN"); }
            ///////////////////////////////////////////////////////////

            Console.WriteLine($"{Players[0].Name} Score:{Players[0].Score}" +       //Player 1 Score
                                $" V {Players[1].Name} Score:{Players[1].Score}");      //Player 2 Score
            Console.WriteLine("TEST");
            Console.ReadLine();
        }

        public int CompareGesture()
        {
            int winDecide = 0;
            string message = "";
            
            switch (player01Gesture.Value)
            {
                case 0: //rock      //Update outcome verbage//
                    {
                        if ((player02Gesture.Value == 2)        //Crushes Scissors
                            || (player02Gesture.Value == 3))    //Smashes Lizard 
                        { winDecide = 0; message = "Win"; }     //ROCK WINS!!!

                        else if (player02Gesture.Value == 1)    // Paper Covers
                        { winDecide = 1; message = "Lose"; }    //ROCK LOSES
                        else { winDecide = 2; message = "TIE"; }
                        break;
                    }
                case 1: // Paper
                    {
                        if (player02Gesture.Value == 0)//
                        { winDecide = 0; message = "Win"; }      // WINS!!!

                        else if (player02Gesture.Value == 2)    //  
                        { winDecide = 1; message = "Lose"; }     // LOSES
                        else { winDecide = 2; message = "TIE"; }
                        break;
                    }
                case 2: // Scissors
                    {
                        if ((player02Gesture.Value == 1)        //
                            || (player02Gesture.Value == 3))    // 
                        { winDecide = 0; message = "Win"; }     //Scissors WINS!!!
                        else if ((player02Gesture.Value == 0)   //
                            || (player02Gesture.Value == 4))    //
                        { winDecide = 1; message = "Lose"; }    //Scissors Loses!!!
                        else { winDecide = 2; message = "TIE"; }
                        break;
                    }
                case 3: // Lizard
                    {
                        if (player02Gesture.Value == 4)//
                        { winDecide = 0; message = "Win"; } // WINS!!!
                        else if ((player02Gesture.Value == 0) //
                            || (player02Gesture.Value == 2)) //
                        { winDecide = 1; message = "Lose"; } //Scissors Loses!!!
                        else { winDecide = 2; message = "TIE"; }
                        break;
                    }
                case 4: // Mr. Spock
                    {
                        if (player02Gesture.Value == 2)//
                        { winDecide = 0; message = "Win"; } // WINS!!!

                        else if (player02Gesture.Value == 3) //  
                        { winDecide = 1; message = "Lose"; } // LOSES
                        else { winDecide = 2; message = "TIE"; }
                        break;
                    }

                default: Menu.BlinkerTrip("COMPARISON LOGIC BROKE \n" +
                    "SPACE TIME FABRIC HAS TORN ABORT ABORT",5, 200);
                    break;
            }
            //Menu.WaitForKey($"{Players[0].Name}:{winDecide} = {message}", 1000);

            return winDecide;
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
