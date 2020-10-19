using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{   
    /// <summary>
    /// This Class is for the type of gesture object created to be added to the GestureGroup
    /// </summary>

    public class GestureType
    {      
        //Member Variables
        public string Type;
        public int Value;
        
        public GestureType(string type, int value)
        {
            this.Type = type;       // Name ex Lizard
            this.Value = value;     // value attribute
        }

        
    }
}
