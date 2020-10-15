using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Human : Player
    {   
        //Member Variables
        

        public Human() : base()
        {
            Console.WriteLine("Human Loaded");
        }

        public override void Gesture()
        {   //inherits gesture
            //User chosen logic

        }
    }
}
