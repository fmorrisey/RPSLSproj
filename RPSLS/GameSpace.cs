using System;

namespace RPSLS
{
    class GameSpace
    {   //MemberVariables

        public Human Human;
        public Computer Computer;
        public Menu Menu;
        //public Player player01;
        //public Player player02;


        public GameSpace()
        {   // Creates our players

            Menu = new Menu();
            

        }


        public void StartGame()
        {   //Welcome players to game
            Menu.Welcome();
            Console.WriteLine("GAME START");
        }

        public void MainMenu()              //Obfuscate in the menu class???
        {   //Initial Menu
            int PlayerMenuChoice;

            Console.WriteLine("RunGame");
            Menu.Pause("LOADING...", 0);    //"LOADS" The game
            PlayerMenuChoice = Menu.MainMenu();

            switch (PlayerMenuChoice)
            {
                case 1: RunGame(); ; break;
                case 2:;break;
                default:
                    break;
            }
            

            //Exitgame(); Use later when player choices to exit the game
        }

        public void RunGame()
        {   //Initializes the game based on MainMenu
            Player player01 = null;
            Player player02 = null;



            //Set_Up Player01 and Player02
            switch (userChoice)
            {
                case "1":
                    {/*Create Human v Human */
                        player01 = new Human();
                        player02 = new Human();
                        break;
                    }
                case "2":
                    {/*Create Human v AI*/
                        player01 = new Human();
                        player02 = new Computer();
                        break;
                    }
                case "":
                    {/*Create AIvAI*/
                        player01 = new Computer();
                        player02 = new Computer();
                        break;
                    }
                default:
                    break;
            }
        }

        public void ThrowSpace()
        {   //The Space where the game happens

        }

        public void Exitgame()
        {   //Exit the game from main menu
            Menu.Pause("EXIT", 800);


        }

        public void PlayerSetUp()
        {
            
        }

    }
}
