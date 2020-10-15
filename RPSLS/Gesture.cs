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


    public class Gesture
    {
        //Member Variables
        public string gesture;
        
        public Gesture(string gesture)
        {
            this.gesture = gesture;
        }

        public void LoadGestures()
        {
            
            
        }
    }
}
