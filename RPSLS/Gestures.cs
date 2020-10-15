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


    public class Gestures
    {
        //Member Variables
        List<Gestures> GesturesOptions;

        public Gestures()
        {
            GesturesOptions = new List<Gestures>();
        }

        public void LoadGestures()
        {
            
            GesturesOptions.Add(rock);
            GesturesOptions.Add(scissors);
            GesturesOptions.Add(paper);
            GesturesOptions.Add(lizard);
            GesturesOptions.Add(mrspock);
        }
    }
}
