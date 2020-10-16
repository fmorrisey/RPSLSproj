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


    public class GestureType
    {
        //Member Variables
        public string Type;
        public int Value;
        
        public GestureType(string type, int value)
        {
            this.Type = type;       //Name ex Lizard
            this.Value = value;       //Name ex Lizard
        }

        
    }
}
