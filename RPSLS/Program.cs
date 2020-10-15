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
            //conditionals for new game
            //add loop here later 
            //Vars for run Game
            bool newGame = true;
            bool playAgain = true;

            //Initializes the menu
            Menu menu = new Menu();
            GameSpace game = new GameSpace();
            game.StartGame();
            game.MainMenu();

            while (newGame != false)
            {
                //Thu Oct 15 (Basic Run Game)
                game.ThrowSpace();
                game.Exitgame();
                menu.PlayAgain(newGame);
            }

            menu.Clear();
            Console.WriteLine("Created by: Forrest Morrisey // Oct 2020");
            Console.WriteLine("Thanks For Playing!!!");
            Console.WriteLine("Winners Don't Do Drugs");
            Console.WriteLine("FBI ANTI-PIRACY WARNING");

            }
    }
}
