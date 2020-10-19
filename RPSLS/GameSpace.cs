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
                
        GestureType player01Gesture;
        GestureType player02Gesture;

        public GameSpace()
        {

            menu = new Menu();                              // Creates the Menu
            Players = new List<Player>();                   // Creates the Player List
            

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
        {   /// This sets up the game for both players and creates the player objects
            /// Creating scenarios such as Human v Computer AI
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
                            {/*Create Human v Human Objects */
                                player01 = new Human("Player 01", 0);
                                Console.WriteLine($" {player01.Name} Human Loaded");
                                player02 = new Human("Player 02", 0);
                                Console.WriteLine($" {player02.Name} Human Loaded");
                                // Add players to lists
                                Players.Add(player01);
                                Players.Add(player02);
                                break;

                            }
                        case 2:
                            {/*Create Human v AI Objects*/
                                player01 = new Human("Player 01", 0);
                                Console.WriteLine($" {player01.Name} Human AI Loaded");
                                player02 = new Computer("HAL 9000", 0);
                                Console.WriteLine($" {player02.Name} Computer Loaded");

                                Players.Add(player01);
                                Players.Add(player02);
                                break;
                            }
                        case 3:
                            {/*Create AIvAI Objects*/
                                player01 = new Computer("SKYNET AI", 0);
                                Console.WriteLine($" {player01.Name} Computer Loaded");
                                player02 = new Computer("DEEP BLUE", 0);
                                Console.WriteLine($" {player02.Name} Computer Loaded");
                                Players.Add(player01);
                                Players.Add(player02);
                                break;
                            }
                        case 4:
                            {   // Exits back to main menu
                                menu.DrawMainMenu();
                                break;
                            }
                        default: // Players should not see this code
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
        {   /// The core game package that will have players, human or AI compete, with each other.
            int roundCounter = 1;               
            int maxScore = 1;                   //Best of three when set to 1
            int userRounds = 3;
            int roundWinner;
            
            do
            {

                player01Gesture = Players[0].ChooseGesture(Players[0]);                 // Player 1 chooses gesture
                //Console.WriteLine($"{Players[0].Name} choose {player01Gesture.Type}");// MVP version hides this so player 2 doesn't know player 1's choice

                menu.WaitForKey($"Press ENTER for {Players[1].Name} turn", 500);        // Waits
                
                player02Gesture = Players[1].ChooseGesture(Players[1]);                 // Player 2 chooses gesture
                                            
                roundWinner = CompareGesture();
                
                menu.MenuDecorators("starlng");                                         // Fancy Graphics 
                Console.WriteLine("\n");                                                // Break line
                Console.WriteLine($"{Players[0].Name} choose {player01Gesture.Type} \n" +
                                  $"{Players[1].Name} choose {player02Gesture.Type}");  // Draws who choose what gesture
                Console.WriteLine("\n");                                                // Break line

                DetermineRoundWinner(roundWinner);                                      // Determine the round winner and draws within function

                Console.WriteLine("\n");                                                // Break line
            }
            while (Players[0].Score <= maxScore && Players[1].Score <= maxScore);

            DetermineEndGame();
        }
                
        public int CompareGesture()
        {
            /// GESTURE DECSION LOGIC ALGORITHM ///
            /// No winner handles potential exceptions - should not happen
            /// Later versions will include verbage for win/lose outcomes
            
            int winDecide = 0;
            string message = "";

            switch (player01Gesture.Value)
            {
                case 0: // ROCK      
                    {
                        if ((player02Gesture.Value == 2)        // Crushes Scissors
                            || (player02Gesture.Value == 3))    // Smashes Lizard 
                        { winDecide = 0; message = "Win"; }     // ROCK WINS!!!

                        else if ((player02Gesture.Value == 1)   // Paper Covers
                            || (player02Gesture.Value == 4))    // Spock Vaporizes
                        { winDecide = 1; message = "Lose"; }    // ROCK LOSES :(

                        else if (player02Gesture.Value == 0)    // SAME = Tie
                        { winDecide = 2; message = "Tie"; }    

                        else { winDecide = 3; message = "No Winner"; }
                        break;
                    }
                case 1: // PAPER
                    {
                        if ((player02Gesture.Value == 0)        // Covers Rock
                            || (player02Gesture.Value == 4))    // Disproves Spock 
                        { winDecide = 0; message = "Win"; }     // PAPER WINS!!!

                        else if ((player02Gesture.Value == 2)   // Scissors cuts 
                            || (player02Gesture.Value == 3))    // Lizards eats 
                        { winDecide = 1; message = "Lose"; }    // PAPER LOSES :(

                        else if (player02Gesture.Value == 1)    // SAME = Tie
                        { winDecide = 2; message = "Tie"; }

                        else { winDecide = 3; message = "No winner"; }
                        break;                                  
                    }
                case 2: // SCISSORS
                    {
                        if ((player02Gesture.Value == 1)        // Cuts paper 
                            || (player02Gesture.Value == 3))    // Decapitates Lizard
                        { winDecide = 0; message = "Win"; }     // SCISSORS WINS!!!

                        else if ((player02Gesture.Value == 0)   // Rock Smashes 
                            || (player02Gesture.Value == 4))    // Spock Smashes
                        { winDecide = 1; message = "Lose"; }    // SCISSORS LOSES!!!

                        else if (player02Gesture.Value == 2)    // SAME = Tie
                        { winDecide = 2; message = "Tie"; }

                        else { winDecide = 3; message = "No winner"; }
                        break;
                    }
                case 3: // LIZARD
                    {
                        if ((player02Gesture.Value == 4)        // Poisons Spock 
                            || (player02Gesture.Value == 1))    // Eats paper
                        { winDecide = 0; message = "Win"; }     // LIZARD WINS!!!

                        else if ((player02Gesture.Value == 0)   // Rock crushes
                            || (player02Gesture.Value == 2))    // Scissors decapitates
                        { winDecide = 1; message = "Lose"; }    // LIZARD LOSES!!!

                        else if (player02Gesture.Value == 3)    // SAME = TIE
                        { winDecide = 2; message = "Tie"; }

                        else { winDecide = 3; message = "No winner"; }
                        break;
                    }
                case 4: // MR. SPOCK
                    {
                        if ((player02Gesture.Value == 2)        // Smashes Scissors 
                            || (player02Gesture.Value == 0))    // Vaporizes Rock
                        { winDecide = 0; message = "Win"; }     // SPOCK WINS!!!

                        else if ((player02Gesture.Value == 3)   // Lizard poisons
                            || (player02Gesture.Value == 1))    // Paper disproves
                        { winDecide = 1; message = "Lose"; }    // SPOCK LOSES!!!

                        else if (player02Gesture.Value == 4)    // SAME = TIE
                        { winDecide = 2; message = "Tie"; }

                        else { winDecide = 3; message = "No winner"; }
                        break;
                    }

                default: menu.BlinkerTrip("COMPARISON LOGIC BROKE \n" +
                    "SPACE TIME FABRIC HAS TORN ABORT ABORT",5, 200);
                    break;
            }
            
            return winDecide;
        }

        public void DetermineRoundWinner(int roundWinner)
        {
            ///////// Round Winner /////////
            menu.MenuDecorators("starlng");                                                 // Fancy Graphics 
            if (roundWinner == 0)                                                           // Determine Round winner
            {   // 0 == P1 Win // 1 == P2 Win // 2 else == Tie
                Players[0].Score += 1;                                                      // Increment Player1 Score
                Console.WriteLine($"{ Players[0].Name} WINS! Score: +1 pts\n");  // Announce round winner
            }
            else if (roundWinner == 1)
            {
                Players[1].Score += 1;                                                      // Increment Player2 Score
                Console.WriteLine($"{ Players[1].Name} WINS! Score: +1 pts\n");  // Announce round winner
            }
            else if (roundWinner == 2) { Console.WriteLine("TIE!!!"); }                     // Determines Tie
            else { { Console.WriteLine("No one won that round!!!"); } }

            Console.WriteLine("ROUND SCORE:");                                              //DRAWS WINNER
            Console.WriteLine($"{Players[0].Name} | Score:{Players[0].Score} pts" +         //Player 1 Score
                            $" Vs. {Players[1].Name} | Score:{Players[1].Score} pts");      //Player 2 Score

            menu.MenuDecorators("starlng");
            menu.WaitForKey("Ready for the next round?", 1000);
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
            
            Console.ReadLine();
        }        
    }
}
