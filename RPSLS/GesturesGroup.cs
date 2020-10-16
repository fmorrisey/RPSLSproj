using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class GesturesGroup
    {
        public string name;
        public List<GestureType> gesturesType;

        public GesturesGroup()
        {
            gesturesType = new List<GestureType>()              // Creates the Gesture List
            {                                                   // This List could use some
                new GestureType("Rock"),                        // Here Gestures eh
                new GestureType("Paper"),
                new GestureType("Scissors"),
                new GestureType("Lizard"),
                new GestureType("Mr. Spock"),
            };
        }
    }
}
