using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Program
    {
        /// <summary>
        /// Sunday October 18 2020
        /// MVP Plus build
        /// - Includes code clean up
        /// - Emphasis of single responsibility
        /// - Extensive Comments
        /// </summary>
        /// <param name="args"></param>
        /// 
        static void Main(string[] args)
        {
            Menu menu = new Menu();     
            GameSpace game = new GameSpace();

            menu.DrawWelcome();         // Draws the fancy start menu with blinking graphics
            game.InitializeMainMenu();  // The whole game starts here
            menu.ExitMessageDraw();     // Draws the exits message
            

        }    
    }
}
