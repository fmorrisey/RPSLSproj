using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public abstract class Player
    {
        //Member Variables
        public List<Player> Players;
        public Player player;

        public Menu Menu;

        public string Name;

        //CTOR??
        public Player()
        {
                                
            
        }

        public virtual string ChooseGesture(Player player)
        {   //Run Logic here?
            return null;
        }

        
    }
}
