using System;
using System.Collections.Generic;

namespace PokerGame
{
    /// <summary>
    /// The ScoreHelper class contains methods for scoring Cards in a Player's Hand.
    /// Caveats: A Hand must contain only 5 cards. Jokers/Wild cards are not supported.
    /// </summary>
    public class ScoreHelper
    {
        #region Constructor

        public ScoreHelper()
        {
        }

        #endregion

        /// <summary>
        /// Determines if Cards rank in sequential order.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsStraight( List<Card> c )
        {
            if ( c[ 0 ].Rank == c[ 1 ].Rank - 1 &&
                c[ 1 ].Rank == c[ 2 ].Rank - 1 &&
                c[ 2 ].Rank == c[ 3 ].Rank - 1 &&
                c[ 3 ].Rank == c[ 4 ].Rank - 1 )
                return true;

            // special case where ace ranks higher following king
            if ( c[ 1 ].Rank == RANK.Ten &&
                c[ 2 ].Rank == RANK.Jack &&
                c[ 3 ].Rank == RANK.Queen &&
                c[ 4 ].Rank == RANK.King &&
                c[ 0 ].Rank == RANK.Ace )
                return true;

            return false;
        }

        /// <summary>
        /// Determines if Suits for all Cards are the same.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsFlush( List<Card> c )
        {
            if ( c[ 0 ].Suit == c[ 1 ].Suit &&
                c[ 1 ].Suit == c[ 2 ].Suit &&
                c[ 2 ].Suit == c[ 3 ].Suit &&
                c[ 3 ].Suit == c[ 4 ].Suit )
                return true;

            return false;
        }

        /// <summary>
        /// Determines if Cards pass tests for straight and flush.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsStraightFlush( List<Card> c )
        {
            if ( IsStraight( c ) && IsFlush( c ) )
                return true;

            return false;
        }

        /// <summary>
        /// Checks for sequential rank of 1st 4 or last 4 Cards.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsFourOfAKind( List<Card> c )
        {
            if ( c[ 0 ].Rank == c[ 1 ].Rank &&
                c[ 1 ].Rank == c[ 2 ].Rank &&
                c[ 2 ].Rank == c[ 3 ].Rank )
                return true;

            if ( c[ 1 ].Rank == c[ 2 ].Rank &&
                c[ 2 ].Rank == c[ 3 ].Rank &&
                c[ 3 ].Rank == c[ 4 ].Rank )
                return true;

            return false;
        }

        /// <summary>
        /// Based on Rank of Cards, checks for a pair and a triplet, 
        /// or a triplet and a pair.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsFullHouse( List<Card> c )
        {
            // first pair the same, then 3 of a kind
            if ( c[ 0 ].Rank == c[ 1 ].Rank &&
                c[ 2 ].Rank == c[ 3 ].Rank &&
                c[ 3 ].Rank == c[ 4 ].Rank )
                return true;

            // 3 of a kind, then a pair
            if ( c[ 0 ].Rank == c[ 1 ].Rank &&
                c[ 1 ].Rank == c[ 2 ].Rank &&
                c[ 3 ].Rank == c[ 4 ].Rank )
                return true;

            return false;
        }

        /// <summary>
        /// Checks for existence of 3 equally ranked Cards.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsThreeOfAKind( List<Card> c )
        {
            // first 3 the same
            if ( c[ 0 ].Rank == c[ 1 ].Rank &&
                c[ 1 ].Rank == c[ 2 ].Rank )
                return true;

            // middle 3 the same
            if ( c[ 1 ].Rank == c[ 2 ].Rank &&
                c[ 2 ].Rank == c[ 3 ].Rank )
                return true;

            // last 3 the same
            if ( c[ 2 ].Rank == c[ 3 ].Rank &&
                c[ 3 ].Rank == c[ 4 ].Rank )
                return true;

            return false;
        }

        /// <summary>
        /// Checks for existence of two pairs of identically ranked Cards.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsTwoPair( List<Card> c )
        {
            // Two pairs in the front
            if ( c[ 0 ].Rank == c[ 1 ].Rank &&
                c[ 2 ].Rank == c[ 3 ].Rank )
                return true;

            // A pair in the front and a trailing pair
            if ( c[ 0 ].Rank == c[ 1 ].Rank &&
                c[ 3 ].Rank == c[ 4 ].Rank )
                return true;

            // Two trailing pairs
            if ( c[ 1 ].Rank == c[ 2 ].Rank &&
                c[ 3 ].Rank == c[ 4 ].Rank )
                return true;

            return false;
        }
        
        /// <summary>
        /// Checks for existence of only one pair of identically ranked Cards.
        /// Caveat: must be checked after check for 2 pairs.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsOnePair( List<Card> c )
        {
            if( c[ 0 ].Rank == c[ 1 ].Rank ||
                c[ 1 ].Rank == c[ 2 ].Rank ||
                c[ 2 ].Rank == c[ 3 ].Rank ||
                c[ 3 ].Rank == c[ 4 ].Rank )
                return true;

            return false;
        }

        /// <summary>
        /// Checks to see if Cards pass straight, flush, and are ranked A, 10, J, Q, K
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsRoyalFlush( List<Card> c )
        {
            if ( IsStraight( c ) && IsFlush( c ) &&
                  c[ 0 ].Rank == RANK.Ace &&
                  c[ 1 ].Rank == RANK.Ten &&
                  c[ 2 ].Rank == RANK.Jack &&
                  c[ 3 ].Rank == RANK.Queen &&
                  c[ 4 ].Rank == RANK.King )
                return true;

            return false;
        }

        public void ScoreHand( Hand h )
        {
            // Order is important.  Sort Cards in Hand before scoring.
            h.Cards.Sort();

            // The order of score determination here matters.

            // NOTE: Wikipedia article does not mention royal flush.
            if ( IsRoyalFlush( h.Cards ) )
                h.Score = SCORE.RoyalFlush;
            else if ( IsStraightFlush( h.Cards ) )
                h.Score = SCORE.StraightFlush;
            else if ( IsFourOfAKind( h.Cards ) )
                h.Score = SCORE.FourOfAKind;
            else if ( IsFullHouse( h.Cards ) )
                h.Score = SCORE.FullHouse;
            else if ( IsFlush( h.Cards ) )
                h.Score = SCORE.Flush;
            else if ( IsStraight( h.Cards ) )
                h.Score = SCORE.Straight;
            else if ( IsThreeOfAKind( h.Cards ) )
                h.Score = SCORE.ThreeOfAKind;
            else if ( IsTwoPair( h.Cards ) )
                h.Score = SCORE.TwoPair;
            else if ( IsOnePair( h.Cards ) )
                h.Score = SCORE.OnePair;            
            else
                h.Score = SCORE.HighCard;
        }
    }
}
