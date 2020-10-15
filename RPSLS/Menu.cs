using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPSLS
{
    //This Class is focused on menus for the player to interact with
    class Menu
    {
        //Member Variables
        
        //Update for RPSLS//

        //Constructor
        public Menu()
        {
            //Update for RPSLS

        }

        public void Welcome()
        {
            //Welcomes the player to the game

            BlinkerSingle("################################################### \n" +
                         "### WELCOME TO ROCK-PAPER-SCISSORS-LIZARD-SPOCK ### \n" +
                         "################################################### \n", 4, 300);

            Console.WriteLine("################################################### \n" +
                            "### WELCOME TO ROCK-PAPER-SCISSORS-LIZARD-SPOCK ### \n" +
                            "################################################### \n");
            Console.WriteLine("      THE SEQUEAL TO THE SCHOOL YARD CLASSIC          ");
            Console.WriteLine("               -DLC sold separately-               \n");
            Thread.Sleep(800);
            Console.WriteLine("      --Press ENTER to START a New Game!!!--");
            Thread.Sleep(800);
            Console.ReadLine();
        }

        public bool PlayAgain(bool newGame)
        {
            newGame = false;
            Clear();
            BlinkerTrip("Play Again???", 3, 300);
            Console.WriteLine("enter y/n");
            
            
            while (newGame != true)
            {
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "y": newGame = true; return newGame;
                    case "Y": newGame = true; return newGame;
                    case "n": newGame = false; return newGame;
                    case "N": newGame = false; return newGame;
                    default: Console.WriteLine("Please enter Y or N");break;
                }
                Console.WriteLine(newGame + userChoice);
            }
            
            return newGame;
        }

        public void TeamInit()
        {
            Clear();
            Console.WriteLine("HERE ARE THE TWO TEAMS!!!");
            Console.WriteLine("Wish them luck!");
            Pause("Press ENTER to start the battle", 800);
            
        }

        //HERE LIES THAR LEGACY CODE RRRR....
        /*
        //Update for RPSLS
        public void DisplayScore(List<Dinosaur> dinosaurs, List<Robot> robots)
        {   //An Attempt to make a table but will require actual table commands and custom classes
            //https://stackoverflow.com/questions/856845/how-to-best-way-to-draw-table-in-console-app-c
            Console.WriteLine("DAS DINO HERD!!!");
            MenuDecorators("dash");

            for (int i = 0; i < dinosaurs.Count; i++)
            {
                //Row 1
                Console.Write($"| {dinosaurs[i].Type} |");
                MenuDecorators("div");
                Console.Write($"| {robots[i].Name} |");

                // Row 2
                Console.Write($"{dinosaurs[i].Health} |");
                MenuDecorators("div");
                Console.Write($"| {robots[i].Health} |");

                // Row 3
                Console.Write($"{dinosaurs[i].Energy} |");
                MenuDecorators("div");
                Console.Write($"| {robots[i].PowerLevel} |");

                // Row 4
                Console.Write($"{dinosaurs[i].AttackType} |");
                MenuDecorators("div");
                Console.Write($"| {robots[i].Weapon} |");

                //Row 5
                Console.WriteLine($"{dinosaurs[i].AttackPower} |");
                MenuDecorators("div");
                Console.Write($"| {robots[i].AttackPower} |");
            }

            Console.WriteLine("DER ROBO Fleet!!!");
            MenuDecorators("dash");

            for (int i = 0; i < robots.Count; i++)
            {
                Console.Write($"| {robots[i].Name} |");
                Console.Write($"{robots[i].Health} |");
                Console.Write($"{robots[i].PowerLevel} |");
                Console.Write($"{robots[i].Weapon} |");
                Console.WriteLine($"{robots[i].AttackPower} |");
            }
        }

        //Update for RPSLS
        public void DisplayDinoHerd(List<Dinosaur> dinosaurs)
        { // This creates and prints a list of Dinos for the player
            Console.WriteLine();
            MenuDecorators("star");
            Console.WriteLine("DAS DINO HERD!!!");
            MenuDecorators("dash");

            for (int i = 0; i < dinosaurs.Count; i++)
            {
                Console.Write($"| {dinosaurs[i].Type} |");
                Console.Write($"{dinosaurs[i].Health} |");
                Console.Write($"{dinosaurs[i].Energy} |");
                Console.Write($"{dinosaurs[i].AttackType} |");
                Console.WriteLine($"{dinosaurs[i].AttackPower} |");
            }
        }

        //Update for RPSLS
        public void DisplayRobotFleet(List<Robot> robots)
        { // This creates and prints a list of robots for the player
            MenuDecorators("star");
            Console.WriteLine("DER ROBO Fleet!!!");
            MenuDecorators("dash");
            
            for (int i = 0; i < robots.Count; i++)
            {
                Console.Write($"| {robots[i].Name} |");
                Console.Write($"{robots[i].Health} |");
                Console.Write($"{robots[i].PowerLevel} |");
                Console.Write($"{robots[i].Weapon} |");
                Console.WriteLine($"{robots[i].AttackPower} |");
            }
        }*/

        //Update for RPSLS???
        public void MenuDecorators(string Decoration)
        { // call using the options to decorate the menues!
            string parameterconvert = Decoration.ToLower();
            switch (parameterconvert)
            {
                case "star": Console.WriteLine("***************");break;
                case "dash": Console.WriteLine("---------------");break;
                case "plus": Console.WriteLine("+++++++++++++++"); break;
                case "equal": Console.WriteLine("==============="); break;
                case "slashrt": Console.WriteLine("///////////////"); break;
                case "slashlf": Console.WriteLine("\\\\\\\\\\\\\\\\"); break;
                case "pipe": Console.WriteLine("|||||||||||||||||||"); break;
                case "hash": Console.WriteLine("###################"); break;
                case "div": Console.Write(" || "); break;
                default: Console.WriteLine("/In/Valid//Menu//Decorator/"); break;

            }
        }
        
        public void Pause(string message, int waitTime)
        {
            //Basically a CR with text output so the user knows what it's asking for
            Console.WriteLine(message);
            Thread.Sleep(waitTime);// Waits for player to read team info
            Console.ReadLine();
        }
        
        public void BlinkerTrip(string text, int blinkNum, int milliseconds)
        {
            //COPIED AND MODIFIED FROM STACKOVERFLOW https://stackoverflow.com/questions/4755204/adding-line-break
            //Takes in custom text, repeats three times, blinks as much as you like, and at a set interval

            bool visible = true;
            for (int i = 0; i < blinkNum; i++)
            {
                string alert = visible ? ($"{text} {text} {text}") : "";
                visible = !visible;
                Console.Clear();
                Console.Write("{0}\n", alert);
                Thread.Sleep(milliseconds);
            }
        }
        
        public void BlinkerSingle(string text, int blinkNum, int milliseconds)
        {
            //COPIED AND MODIFIED FROM STACKOVERFLOW https://stackoverflow.com/questions/4755204/adding-line-break
            //Takes in custom text, repeats three times, blinks as much as you like, and at a set interval

            bool visible = true;
            for (int i = 0; i < blinkNum; i++)
            {
                string alert = visible ? ($"{text}") : "";
                visible = !visible;
                Console.Clear();
                Console.Write("{0}\n", alert);
                Thread.Sleep(milliseconds);
            }
        }
        
        public void Clear()
        {
            //Clears the menu
            Console.Clear();
        }

        
    }
}
