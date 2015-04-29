using System;
using System.Collections.Generic;

namespace PokerGame
{
    public class Game
    {
        #region Public Consts

        // TODO: make this variable by prompting when game starts.
        public const int NUM_PLAYERS = 5;

        // TODO: make this variable, depending on style of game
        public const int NUM_CARDS_PER_PLAYER = 5;

        #endregion

        #region Constructor

        public Game()
        {
            Console.WriteLine( "Starting new Game for {0} Players.", NUM_PLAYERS );
            Console.WriteLine();
            Console.WriteLine( "Creating Deck" );

            // Create a new Card Deck.
            this.Deck = new Deck();

            Console.WriteLine( "Deck Created." );
            this.Deck.PrintAvailableCards();

            // Shuffle the available Cards in the Deck.
            Console.WriteLine( "Shuffling Deck." );
            this.Deck.Shuffle();

            Console.WriteLine( "Deck Shuffled." );
            this.Deck.PrintAvailableCards();

            // Add the Players to the Game.
            AddPlayers( NUM_PLAYERS );

            // Deal Cards to the Players.
            DealCards();

            //SortHands();

            // Score each Player's Hand.
            ScoreHands();

            // Sort the Players by the scores for their Hands.

            // TODO: Break Ties.
        }

        #endregion

        #region Private Methods

        private void ScoreHands()
        {
            Console.WriteLine( "Scoring each Player's Hand." );

            // Set the score for each Hand.
            ScoreHelper sh = new ScoreHelper();

            foreach ( Player p in Players )
            {
                sh.ScoreHand( p.Hand );

                Console.WriteLine( "{0} has a score of: {1}", p.Name, Enum.GetName( typeof( SCORE ), p.Hand.Score ) );
            }            

            Console.WriteLine( "Hands scored." );
            Console.WriteLine();            
        }

        /// <summary>
        /// Sorts the Cards in each Player's Hand.
        /// </summary>
        private void SortHands()
        {
            Console.WriteLine( "Sorting Cards in each Player's Hand." );

            foreach ( Player p in Players )
            {
                p.Hand.Cards.Sort();
            }

            Console.WriteLine( "Hands sorted." );
        }

        /// <summary>
        /// Deals Cards to each Player in the Game.
        /// </summary>
        private void DealCards()
        {
            Console.WriteLine( "Dealing {0} Cards per Player.", NUM_CARDS_PER_PLAYER );

            for ( int i = 0; i < NUM_CARDS_PER_PLAYER; i++ )
            {
                foreach ( Player p in Players )
                {
                    p.Hand.AddCard( Deck.DealCard() );
                }
            }

            Console.WriteLine( "{0} Cards dealt to {1} Players.", NUM_CARDS_PER_PLAYER * NUM_PLAYERS, NUM_PLAYERS );
            Console.WriteLine();
        }

        /// <summary>
        /// Adds the specified number of Players to the Game.
        /// </summary>
        /// <param name="numPlayers"></param>
        private void AddPlayers( int numPlayers )
        {
            Console.WriteLine( "Adding {0} Players.", numPlayers );

            Players = new List<Player>();

            for ( int i = 0; i < numPlayers; i++ )
            {
                Players.Add( new Player( String.Format( "Player: {0}", i ) ) );
            }

            Console.WriteLine( "{0} Players Added.", numPlayers );
            Console.WriteLine();
        }

        #endregion

        #region Properties

        public List<Player> Players { get; set; }

        public Deck Deck { get; set; }

        #endregion
    }
}
