using System;
using System.Collections.Generic;

namespace PokerGame
{
    public class Deck
    {
        #region Private Variables

        private Random _random = null;

        #endregion

        #region Constructor

        public Deck()
        {
            this.Initialize();

            // Random number generator used for shuffling.
            _random = new Random();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method that adds call cards to AvailableCards.
        /// Currently, this is a standard 52 Card Deck with no Jokers.
        /// </summary>
        public void Initialize()
        {
            foreach ( SUIT s in Enum.GetValues( typeof( SUIT ) ) )
            {
                foreach ( RANK r in Enum.GetValues( typeof( RANK ) ) )
                {
                    if ( null == AvailableCards )
                        AvailableCards = new List<Card>();

                    AvailableCards.Add( new Card( s, r ) );
                }
            }
        }

        /// <summary>
        /// Shuffles the Deck of available (non-dealt) Cards using the
        /// Fisher-Yates algorithm.
        /// </summary>
        public void Shuffle()
        {
            for ( int i = AvailableCards.Count - 1; i > 0; --i )
            {
                int j = _random.Next( i + 1 );

                Card c = AvailableCards[ i ];
                AvailableCards[ i ] = AvailableCards[ j ];
                AvailableCards[ j ] = c;
            }
        }

        /// <summary>
        /// Shuffles the Deck of available Cards the specified number of times.
        /// </summary>
        /// <param name="times">Number of times to shuffle the Deck of available Cards.</param>
        public void Shuffle( int times )
        {
            for ( int i = 0; i < times; i++ )
            {
                Shuffle();
            }
        }

        /// <summary>
        /// Deals a Card by returning it and removing it from the available Cards in the Deck.
        /// </summary>
        /// <returns>A Card from the beginning of the AvailableCards List.</returns>
        public Card DealCard()
        {
            // Deal a card from the top of the deck.
            Card c = AvailableCards[ 0 ];
            AvailableCards.RemoveAt( 0 );

            return c;
        }

        /// <summary>
        /// Prints out each Card in the AvailableCards List to the Console.
        /// </summary>
        public void PrintAvailableCards()
        {
            Console.WriteLine();

            foreach ( Card c in AvailableCards )
            {
                Console.WriteLine( c.ToString() );
            }

            Console.WriteLine();
        }

        #endregion

        #region Properties

        public List<Card> AvailableCards { get; set; }

        #endregion
    }
}
