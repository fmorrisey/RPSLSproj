using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{   //Contains information for Gestures inheritance

    //Rock crushes Scissors
    //Scissors cuts Paper
    //Paper covers Rock
    //Rock crushes Lizard
    //Lizard poisons Spock
    //Spock smashes Scissors
    //Scissors decapitates Lizard


    public class GestureType : GesturesGroup
    {
        //Member Variables
        public string Type;
        
        public GestureType(string type)
        {
            this.Type = type;       //Name ex Lizard
            
        }

        
    }
}
