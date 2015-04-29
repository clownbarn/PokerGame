using System;

namespace PokerGame
{ 
    public class Card : IComparable<Card>
    {           
        #region Constructor

        public Card( SUIT suit, RANK rank )
        {
            Suit = suit;
            Rank = rank;
        }

        #endregion

        #region Public Methods - Overrides

        public override string ToString()
        {
            return String.Format( "CARD: Suit = {0}, Rank = {1}", Enum.GetName( typeof( SUIT ), Suit ), Enum.GetName( typeof( RANK ), Rank ) );
        }

        #endregion

        #region Properties

        public SUIT Suit { get; set; }

        public RANK Rank { get; set; }

        #endregion

        #region IComparable<Card> Members

        /// <summary>
        /// Used to sort cards by Rank.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( Card other )
        {
            if ( Rank < other.Rank )
                return -1;
            else if ( Rank > other.Rank )
                return 1;
            return 0;
        }

        #endregion
    }
}
