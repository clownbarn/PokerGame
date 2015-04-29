using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Player
    {
        
        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }

        public string Name { get; set; }

        public Hand Hand { get; set; }
    }    
}
