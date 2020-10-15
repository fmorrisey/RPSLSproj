using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conditionals for new game

            //Vars for run Game
            bool newGame = true;
            bool playAgain = true;

            //Initializes the menu
            
            
            //Thu Oct 15 (Basic Run Game)
            Menu menu = new Menu();
            GameSpace game = new GameSpace();
            game.StartGame();
            game.MainMenu();
            menu.Exit();
            

        }    
    }
}
