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
            //conditonals for new game
            //add loop here later 

            //Thu Oct 15 (Basic Run Game)
            GameSpace game = new GameSpace();
            game.StartGame();
            game.MainMenu();
            game.ThrowSpace();
            game.Exitgame();

        }
    }
}
