using System;

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
            for ( int i = Game.NUM_CARDS_PER_PLAYER - 1; i >= 0; i-- )
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
