﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;

namespace RPSLS
{
    class GameSpace
    {   //MemberVariables

        
        public Menu Menu;
        public List<Player> Players;
        public Player player;
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
                                player01 = new Human("player01");
                                Console.WriteLine($" {player01.Name} Human Loaded");
                                player02 = new Human("player02");
                                Console.WriteLine($" {player02.Name} Human Loaded");
                                
                                Players.Add(player01);
                                Players.Add(player02);
                                break;

                            }
                        case 2:
                            {/*Create Human v AI*/
                                player01 = new Human("player01");
                                Console.WriteLine($" {player01.Name} Human AI Loaded");
                                player02 = new Computer("Computer AI");
                                Console.WriteLine($" {player02.Name} Computer Loaded");

                                Players.Add(player01);
                                Players.Add(player02);
                                break;
                            }
                        case 3:
                            {/*Create AIvAI*/
                                player01 = new Computer("Computer AI 01");
                                Console.WriteLine($" {player02.Name} Computer Loaded");
                                player02 = new Computer("Computer AI 01");
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
            Console.WriteLine(Players[0].Name.Count()); 
        }


        public Player PlayerSetUp()                     // Proof of Concept
        {                                               // Game Specific Variables
            Player player01 = null;                         
            Player player02 = null;

            player01 = new Human("");
            player02 = new Computer("");
            //Players.Add(player01);
            //Players.Add(player02);
            return null;
        }

    }
}
