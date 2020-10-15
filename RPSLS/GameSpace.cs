using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class GameSpace
    {   //MemberVariables

        public Human Human;
        public Computer Computer;
        public Menu Menu;
        public TurnTaker TurnTaker;

        public GameSpace()
        {   // Creates our players
            Human player01 = new Human();
            Human player02 = new Human();
            Computer AI = new Computer();
            Menu = new Menu();
            
        }
              

        public void StartGame()
        {   //Welcome players to game
            //Menu.Welcome();
            Console.WriteLine("GAME START");
        }

        public void MainMenu()
        {   //Inital Menu
            Console.WriteLine("RunGame");

            //Exitgame(); Use later when player choices to exit the game
        }

        public void RunGame()
        {   //Initializes the game based on MainMenu
            //Load necessary game path
            // Path 1: PVP Player01 v Player02

            // Path 2; PvAI Player01 v ComputerAI(Skynet???) 
        }

        public void ThrowSpace()
        {   //The Space where the game happens
            
        }

        public void Exitgame()
        {   //Exit the game from main menu
            Menu.Pause("EXIT", 800);


        }


    }
}
