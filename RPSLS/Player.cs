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
        public string Name;
        public int Score;
        public Menu Menu;
        public string gesture;


        public GesturesGroup gesturesGroup;
        
        //CTOR??
        public Player(int score)
        {
            gesturesGroup = new GesturesGroup();
            Menu = new Menu();
        }

        public virtual GestureType ChooseGesture(Player player)
        {   //Run Logic here?
            return null;
        }

        
    }
}
