using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame
{
    public class Hand 
    {
        #region Constructor

        public Hand()
        {
            this.Cards = new List<Card>();

            // Default score == None
            Score = SCORE.None;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a specified Card to the Cards List for this Hand.
        /// </summary>
        /// <param name="c">The Card to add.</param>
        public void AddCard( Card c )
        {
            Cards.Add( c );
        }        

        /// <summary>
        /// Removes a Card from the Cards List for this Hand.
        /// Not implemented.  Would come in handy for full featured Game
        /// where Call and Bet are allowed.
        /// </summary>
        public void RemoveCard()
        {
            // TODO: Implement RemoveCard
            throw new NotImplementedException( "RemoveCard is not Implemented" );
        }

        #endregion

        #region Public Methods - Overrides

        public override string ToString()
        {
            StringBuilder sbHand = new StringBuilder();

            sbHand.AppendLine();
            sbHand.AppendFormat( "Score: {0}", Enum.GetName( typeof( SCORE ), this.Score ) );
            sbHand.AppendLine();
            sbHand.AppendLine();
            sbHand.AppendLine( "Cards:" );

            for ( int i = 0; i < this.Cards.Count; i++ )
            {
                sbHand.AppendLine( this.Cards[ i ].ToString() );
            }

            return sbHand.ToString();
        }

        #endregion

        #region Properties

        public List<Card> Cards { get; set; }

        public SCORE Score { get; set; }

        #endregion
    }
}
