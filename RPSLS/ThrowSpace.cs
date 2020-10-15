using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class ThrowSpace
    {   //MemberVariables

        public Human Human;
        public Computer Computer;
        public Menu Menu;

        public ThrowSpace()
        {   // Creates our players
            Human player01 = new Human();
            Human player02 = new Human();
            Computer AI = new Computer();
            Menu = new Menu();


        }

        public void RunGame()
        {
            //Menu.Welcome();
            Console.WriteLine("GAME START");
            Menu.Pause("EXIT", 800);




        }

    }
}
