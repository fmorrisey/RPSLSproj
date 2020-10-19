using System;
using System.Threading;

namespace RPSLS
{
    /// <summary>
    ///  This class is for the bulk of all menu and displays graphics
    ///  Now free of any logic and should handle 100% draw functions with
    ///  zero return functions.
    /// </summary>
    /// 
    public class Menu
    {
        // No Member Variables
        // Constructor
        public Menu()
        {


        }

        public void DrawWelcome()
        {
            //Welcomes the player to the game

            BlinkerSingle("################################################### \n" +
                         "### WELCOME TO ROCK-PAPER-SCISSORS-LIZARD-SPOCK ### \n" +
                         "################################################### \n", 4, 300);

            Console.Write("################################################### \n" +
                            "### WELCOME TO ROCK-PAPER-SCISSORS-LIZARD-SPOCK ### \n" +
                            "################################################### \n");
            Console.WriteLine("      THE SEQUEAL TO THE SCHOOL YARD CLASSIC          ");
            Console.WriteLine("               -DLC sold separately-               \n");
            Thread.Sleep(800);
            Console.WriteLine("      --Press ENTER to START a New Game!!!--");
            Thread.Sleep(800);
            Console.ReadLine();
            Pause("LOADING...", 1000);               //"LOADS" The game
        }

        public void DrawMainMenu()
        {
            Clear();
            Console.WriteLine("##### MAIN MENU #### \n" +
                              "    1: Play Game \n" +
                              "    2: Display the Rules \n" +
                              "    3: Exit The Game \n");
        }


        public void DisplayeRules()
        {
            Clear();
            MenuDecorators("starlng");
            Console.WriteLine("** THESE ARE THE RULES PASSED DOWN FOR **  \n" +
                              "** GENERATIONS BY THE COOPER CLAN ** \n" +
                              "    ***** REMEMBER THEM WELL ******");
            MenuDecorators("starLng");
            Console.Write("       Rock crushes Scissors \n" +
                          "        Scissors cuts Paper\n" +
                          "         Paper covers Rock\n" +
                          "        Rock crushes Lizard\n" +
                          "        Lizard poisons Spock\n" +
                          "       Spock smashes Scissors\n" +
                          "    Scissors decapitates Lizard \n" +
                          "        Lizard eats Paper \n" +
                          "        Paper disproves Spock \n " +
                          "       Spock vaporizes Rock \n");
            MenuDecorators("starLng");
            WaitForKey("      ---Press Enter to Exit---", 100);
        }

        public void DrawPlayerSelection()
        {
            Clear();
            Console.WriteLine("##### PLAYER SETUP MENU #### \n" +
                              "    1: Human v Human \n" +
                              "    2: Human v Computer \n" +
                              "    3: Computer v Computer \n" +
                              "    4: Return to Main Menu \n");
        }

        public void DrawGestureChoice()
        {   //DRAWS AI SPECIFIC MENU FOR THE COMPUTER AI
            Console.WriteLine("##### PICK A GESTURE #### \n" +
                              "    1: Rock \n" +
                              "    2: Paper \n" +
                              "    3: Scissors \n" +
                              "    4: Lizard \n" +
                              "    5: Spock \n");
        }

        public void DisplayRounds(int rounds)
        {
            Console.WriteLine($"##### ROUND  {rounds} ####");
        }

        public void ComputerChoice()
        {   //DRAWS AI SPECIFIC MENU FOR THE COMPUTER AI
            Console.WriteLine("##### COMPUTER AI GESTURE #### \n" +
                              "    @: Rock \n" +
                              "    @: Paper \n" +
                              "    @: Scissors \n" +
                              "    @: Lizard \n" +
                              "    @: Spock \n");
        }
                
        public void MenuDecorators(string Decoration)
        { // call using the options to decorate the menues!
            string parameterconvert = Decoration.ToLower();
            switch (parameterconvert)
            {
                case "star": Console.WriteLine("***************"); break;
                case "starlng": Console.WriteLine("*****************************************"); break;
                case "dash": Console.WriteLine("---------------"); break;
                case "plus": Console.WriteLine("+++++++++++++++"); break;
                case "equal": Console.WriteLine("==============="); break;
                case "slashrt": Console.WriteLine("////////////////////////////////"); break;
                case "slashlf": Console.WriteLine("////////////////////////////////"); break;
                case "pipe": Console.WriteLine("|||||||||||||||||||"); break;
                case "hash": Console.WriteLine("###################"); break;
                case "div": Console.Write(" || "); break;
                default: Console.WriteLine("/In/Valid//Menu//Decorator/"); break;

            }
        }

        public void ExitMessageDraw()
        {
            Clear();
            Console.WriteLine("Created by: Forrest Morrisey // Oct 2020");
            Console.WriteLine("Thanks For Playing!!!");
            Console.WriteLine("Winners Don't Do Drugs");
            Console.WriteLine("FBI ANTI-PIRACY WARNING");
            WaitForKey("", 1000);
        }

        public void WaitForKey(string message, int waitTime)
        {
            //Basically a CR with text output so the user knows what it's asking for
            Console.WriteLine(message);
            Thread.Sleep(waitTime);// Waits for player to read team info
            Console.ReadLine();
        }

        public void Pause(string message, int waitTime)
        {
            //Basically a CR with text output so the user knows what it's asking for
            Console.WriteLine(message);
            Thread.Sleep(waitTime);// Waits for player to read team info
            //Great for Pseudo Loadscreens
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
                Console.WriteLine();
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
