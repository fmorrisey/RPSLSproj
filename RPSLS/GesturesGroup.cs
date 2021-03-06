﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    /// <summary>
    /// This class creates the gesture types such as the rock object
    /// and adds it to the group list to be used in the game!
    /// </summary>
    public class GesturesGroup
    {
        
        public List<GestureType> gesturesType;

        public GesturesGroup()
        {
            gesturesType = new List<GestureType>()              // Creates the Gesture List
            {                                                   // This List could use some
                new GestureType("Rock", 0),                        // Here Are Gestures eh
                new GestureType("Paper", 1),
                new GestureType("Scissors", 2),
                new GestureType("Lizard", 3),
                new GestureType("Mr. Spock", 4),
            };

            /*
            Rock 0      crushes     Scissors 2
            Scissors 2  cuts        Paper 1
            Paper 1     covers      Rock 0
            Rock 0      crushes     Lizard 3
            Lizard 3    poisons     Spock 4
            Spock 4     smashes     Scissors 2
            Scissors 2  decapitates Lizard 3
            Lizard 3    eats        Paper 1
            Paper 1     disproves   Spock 4 
            Spock 4     vaporizes   Rock 0


            */
        }
    }
}
