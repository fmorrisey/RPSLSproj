using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Policy;

namespace RPSLS
{
    class GameSpace
    {   //MemberVariables

        
        public Menu Menu;
        
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
                    case 1: PlayerSelection(); askAgain = true; break;
                    case 2: Menu.DisplayeRules(); askAgain = true; break;
                    case 3: askAgain = false; break;
                    default:
                        Console.WriteLine("ERORR 400: Not a Valid Selection");
                        askAgain = false;
                        break;
                }
            } while (askAgain == true);


        }

        
                

        public Player PlayerSetUp()                     // Proof of Concept
        {                                               // Game Specific Variables
            Player player01 = null;                         
            Player player02 = null;

            player01 = new Human("");
            player02 = new Computer("");
            Players.Add(player01);
            Players.Add(player02);
            return null;
        }

    }
}
