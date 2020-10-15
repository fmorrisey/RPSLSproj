using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class PvP_TT : TurnTaker
    
        
        public void PvPTurn()
        {
            bool isDinosTurn = true;
            while (//Logic)
            {
                if (isDinosTurn == true)
                {
                    HumanChoice(//Player[0]);
                    isDinosTurn = false;
                }
                else
                {
                    HumanChoice(fleet.robots[0]);
                    isDinosTurn = true;
                }
            }
        }
    }
        
        
        public void playerChoice()
        {

        }
    }
}
