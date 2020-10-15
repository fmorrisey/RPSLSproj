using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public abstract class TurnTaker
    {   //Parent level Abstract Class

        public PvP_TT PvP_TT;
        public PvAI_TT PvAI_TT;


        public TurnTaker()
        {
            PvP_TT pvp = new PvP_TT();
            PvAI_TT pvpai = new PvAI_TT();
        }
    }
}
