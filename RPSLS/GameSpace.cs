using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace RPSLS
{   
    /// <summary>
    /// GAMESPACE Class is the main run game logic after initialization
    /// in the program class. 
    /// </summary>
    class GameSpace
    {   //MemberVariables       
        public Menu menu;
        public List<Player> Players;
        public GesturesGroup GesturesGroup;
        public Player player;

        GestureType player01Gesture;
        GestureType player02Gesture;

        public GameSpace()
        {

            menu = new Menu();                              // Creates the Menu
            Players = new List<Player>();                   // Creates the Player List
            GesturesGroup = new GesturesGroup();

        }    

        public void InitializeMainMenu()                              
        {   //Initial Menu // Handles all the background logic for the main menu 
            int PlayerMenuChoice;
            bool askAgain = false;

            //MENU LOOP
            do
            {
                //MAIN MENU//
                menu.DrawMainMenu();                        // Draws Main menu
                PlayerMenuChoice = MainMenuSelection();     // Asks the player to make selection
                switch (PlayerMenuChoice)                   // Player's choice activate switch
                {
                    case 1:
                        {
                            PlayerSelection();              // Select Players, creates Player1/2 Object collection
                            RunGame();                      // Runs the gesture game
                            askAgain = true; break;
                        } 
                        
                    case 2: menu.DisplayeRules(); askAgain = true; break; // Selection to draw menu rules
                    case 3: askAgain = false; break; //Exits the game
                    default:
                        Console.WriteLine("ERORR 400: Not a Valid Selection");
                        askAgain = false;
                        break;
                }
            } while (askAgain == true);

        }

        public int MainMenuSelection()
        {   // Handles Main Menu user input with validation
            int MainMenuSelection;
            bool askAgain;

            do
            {
                Console.Write("Enter a menu option: ");
                if (int.TryParse(Console.ReadLine(), out MainMenuSelection))
                { return MainMenuSelection; }
                else
                {
                    Console.WriteLine("Incorrect Input");
                    askAgain = true;
                }
            } while (askAgain == true);

            return MainMenuSelection;
        }

        public void PlayerSelection()
        {                                                   // Initializes the game
            Player player01 = null;                         // Game Specific Variables
            Player player02 = null;
            bool askAgain = false;
            int playerSetupChoice;

            
            menu.DrawPlayerSelection();
            
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
                                menu.DrawMainMenu();
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
        {   //The core game package that will have players, human or AI compete with each other.
            int roundCounter = 1;               
            int maxScore = 1;                   //Best of three when set to 1
            int userRounds = 3;
            int roundWinner;
            
            do
            {

                player01Gesture = Players[0].ChooseGesture(Players[0]);                 // Player 1 chooses gesture
                Console.WriteLine($"{Players[0].Name} choose {player01Gesture.Type}");  // Tells player the move

                menu.WaitForKey($"Press ENTER for {Players[1].Name} turn", 500);        // Waits
                
                player02Gesture = Players[1].ChooseGesture(Players[1]);                 // Player 2 chooses gesture
                                            
                roundWinner = CompareGesture();
                
                menu.MenuDecorators("starlng");                                         // Fancy Graphics 
                Console.WriteLine("\n");                                                // Breakline
                Console.WriteLine($"{Players[0].Name} choose {player01Gesture.Type} \n" +
                                  $"{Players[1].Name} choose {player02Gesture.Type}");  // Draws who choose what gesture
                Console.WriteLine("\n");                                                // Breakline

                DetermineRoundWinner(roundWinner);                                      // Determine the round winner and draws within function

                Console.WriteLine("\n");                                                // Breakline
                menu.WaitForKey("Ready for the next round?", 1000);
            }
            while (Players[0].Score <= maxScore && Players[1].Score <= maxScore);

            DetermineEndGame();
        }
                
        public int CompareGesture()
        {
            int winDecide = 0;
            string message = "";
            /// Update Comments
            
            /// Outbounds rules not in Original BBT Theory

            switch (player01Gesture.Value)
            {
                case 0: //rock      //Update outcome verbage//
                    {
                        if ((player02Gesture.Value == 2)        // Crushes Scissors
                            || (player02Gesture.Value == 3))    // Smashes Lizard 
                        { winDecide = 0; message = "Win"; }     // ROCK WINS!!!

                        else if (player02Gesture.Value == 1)    // Paper Covers
                        { winDecide = 1; message = "Lose"; }    // ROCK LOSES

                        else if (player02Gesture.Value == 0)    // SAME = Tie
                        { winDecide = 2; message = "Tie"; }    

                        else { winDecide = 3; message = "No Winner"; }
                        break;
                    }
                case 1: // Paper
                    {
                        if (player02Gesture.Value == 0)//
                        { winDecide = 0; message = "Win"; }     // PAPER WINS!!!

                        else if (player02Gesture.Value == 2)    // PAPER 
                        { winDecide = 1; message = "Lose"; }    // LOSES

                        else if (player02Gesture.Value == 1)    // SAME = Tie
                        { winDecide = 2; message = "Tie"; }

                        else { winDecide = 3; message = "No winner"; }
                        break;
                    }
                case 2: // Scissors
                    {
                        if ((player02Gesture.Value == 1)        // Scissors 
                            || (player02Gesture.Value == 3))    // 
                        { winDecide = 0; message = "Win"; }     // WINS!!!

                        else if ((player02Gesture.Value == 0)   // Scissors 
                            || (player02Gesture.Value == 4))    //
                        { winDecide = 1; message = "Lose"; }    // Loses!!!

                        else if (player02Gesture.Value == 2)    // SAME = Tie
                        { winDecide = 2; message = "Tie"; }

                        else { winDecide = 3; message = "No winner"; }
                        break;
                    }
                case 3: // Lizard
                    {
                        if (player02Gesture.Value == 4)         // Lizard 
                        { winDecide = 0; message = "Win"; }     // WINS!!!

                        else if ((player02Gesture.Value == 0)   // Lizard
                            || (player02Gesture.Value == 2))    //
                        { winDecide = 1; message = "Lose"; }    // Loses!!!

                        else if (player02Gesture.Value == 3)    // SAME = TIE
                        { winDecide = 2; message = "Tie"; }

                        else { winDecide = 3; message = "No winner"; }
                        break;
                    }
                case 4: // Mr. Spock
                    {
                        if (player02Gesture.Value == 2)         // SPOCK
                        { winDecide = 0; message = "Win"; }     // WINS!!!

                        else if (player02Gesture.Value == 3)    // SPOCK
                        { winDecide = 1; message = "Lose"; }    // LOSES

                        else if (player02Gesture.Value == 4)    // SAME = TIE
                        { winDecide = 2; message = "Tie"; }

                        else { winDecide = 3; message = "No winner"; }
                        break;
                    }

                default: menu.BlinkerTrip("COMPARISON LOGIC BROKE \n" +
                    "SPACE TIME FABRIC HAS TORN ABORT ABORT",5, 200);
                    break;
            }
            //Menu.WaitForKey($"{Players[0].Name}:{winDecide} = {message}", 1000); //DEBUGING CW

            return winDecide;
        }

        public void DetermineRoundWinner(int roundWinner)
        {
            ///////// Round Winner /////////
            menu.MenuDecorators("starlng");                                                 // Fancy Graphics 
            if (roundWinner == 0)                                                           // Determine Round winner
            {   // 0 == P1 Win // 1 == P2 Win // 2 else == Tie
                Players[0].Score += 1;                                                      // Increment Player1 Score
                Console.WriteLine($"{ Players[0].Name} WINS! Score: { Players[0].Score}");  // Announce round winner
            }
            else if (roundWinner == 1)
            {
                Players[1].Score += 1;                                                      // Increment Player2 Score
                Console.WriteLine($"{ Players[1].Name} WINS! Score: { Players[1].Score}");  // Announce round winner
            }
            else if (roundWinner == 2) { Console.WriteLine("TIE!!!"); }                     // Determines Tie
            else { { Console.WriteLine("No one won that round!!!"); } }

            Console.WriteLine("ROUND SCORE:");                                              //DRAWS WINNER
            Console.WriteLine($"{Players[0].Name} | Score:{Players[0].Score} pts" +         //Player 1 Score
                            $" Vs. {Players[1].Name} | Score:{Players[1].Score} pts");      //Player 2 Score

            menu.MenuDecorators("starlng");
        }

        public void DetermineEndGame()
        {
            bool gameWinner = true;
            
            if (Players[0].Score > Players[1].Score) { gameWinner = true; }             //Set Player 1 as Winner  
            else { gameWinner = false; }                                                //Set Player 2 as Winner  
                        
            if (gameWinner == true) { Console.WriteLine($"{Players[0].Name} Wins the game with {Players[0].Score} points"); }
            else if (gameWinner == false) { Console.WriteLine($"{Players[1].Name} Wins the game with {Players[1].Score} points"); }
            else { Console.WriteLine("MOM!!! THE UNIVERSE BROKE AGAIN"); }
            
            Console.WriteLine($"{Players[0].Name} Score:{Players[0].Score}" +           //Player 1 Score
                                $" V {Players[1].Name} Score:{Players[1].Score}");      //Player 2 Score
            Console.WriteLine("TEST");
            Console.ReadLine();
        }        
    }
}
