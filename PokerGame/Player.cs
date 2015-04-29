using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    public class Player : IComparable<Player>
    {
        #region Constructor

        public Player( string name )
        {
            Name = name;
            Hand = new Hand();
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public Hand Hand { get; set; }

        #endregion

        #region IComparable<Player> Members

        public int CompareTo( Player other )
        {
            //if ( Hand.Score > other.Hand.Score )
            //    return -1;
            //else if ( Hand.Score < other.Hand.Score )
            //    return 1;
            //return 0;

            for ( int i = 4; i >= 0; i-- )
            {
                if ( Hand.Cards[ i ].Rank < other.Hand.Cards[ i ].Rank )
                    return 1;
                else if ( Hand.Cards[ i ].Rank > other.Hand.Cards[ i ].Rank )
                    return -1;
            }
            return 0; 
        }

        #endregion
    }
}
