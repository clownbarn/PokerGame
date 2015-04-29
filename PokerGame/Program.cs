using System;

namespace PokerGame
{
    class Program
    {
        static void Main( string[] args )
        {
            //TestHandScoring();           


            Game g = new Game();

            // Leave console open until Escape is pressed.
            while ( Console.ReadKey().Key != ConsoleKey.Escape ) { }
        }

        #region Test Methods

        /// <summary>
        /// Sanity checks for the individual scoring algorithms
        /// and ScoreHelper.GetScore()
        /// </summary>
        private static void TestHandScoring()
        {
            ScoreHelper sh = new ScoreHelper();
            bool b = false;

            //
            // Test IsStraight()
            //
            Hand hand1 = new Hand();
            hand1.AddCard( new Card( SUIT.Spades, RANK.Nine ) );
            hand1.AddCard( new Card( SUIT.Diamonds, RANK.Eight ) );
            hand1.AddCard( new Card( SUIT.Spades, RANK.Seven ) );
            hand1.AddCard( new Card( SUIT.Hearts, RANK.Six ) );
            hand1.AddCard( new Card( SUIT.Clubs, RANK.Five ) );

            sh.ScoreHand( hand1 );
            b = hand1.Score == SCORE.Straight;
            Console.WriteLine( "Hand 1 is Straight: {0}.", b );
            Console.WriteLine( hand1.ToString() );

            Hand hand2 = new Hand();
            hand2.AddCard( new Card( SUIT.Spades, RANK.Ten ) );
            hand2.AddCard( new Card( SUIT.Diamonds, RANK.Jack ) );
            hand2.AddCard( new Card( SUIT.Spades, RANK.Queen ) );
            hand2.AddCard( new Card( SUIT.Hearts, RANK.King ) );
            hand2.AddCard( new Card( SUIT.Clubs, RANK.Ace ) );

            sh.ScoreHand( hand2 );
            b = hand2.Score == SCORE.Straight;
            Console.WriteLine( "Hand 2 is Straight: {0}.", b );
            Console.WriteLine( hand2.ToString() );

            //
            // Test IsFlush()
            //
            Hand hand3 = new Hand();
            hand3.AddCard( new Card( SUIT.Spades, RANK.Ace ) );
            hand3.AddCard( new Card( SUIT.Spades, RANK.Jack ) );
            hand3.AddCard( new Card( SUIT.Spades, RANK.Ten ) );
            hand3.AddCard( new Card( SUIT.Spades, RANK.Six ) );
            hand3.AddCard( new Card( SUIT.Spades, RANK.Three ) );

            sh.ScoreHand( hand3 );
            b = hand3.Score == SCORE.Flush;
            Console.WriteLine( "Hand 3 is Flush: {0}.", b );
            Console.WriteLine( hand3.ToString() );

            //
            // Test IsRoyalFlush()
            //
            Hand hand4 = new Hand();
            hand4.AddCard( new Card( SUIT.Spades, RANK.Ace ) );
            hand4.AddCard( new Card( SUIT.Spades, RANK.Ten ) );
            hand4.AddCard( new Card( SUIT.Spades, RANK.Jack ) );
            hand4.AddCard( new Card( SUIT.Spades, RANK.Queen ) );
            hand4.AddCard( new Card( SUIT.Spades, RANK.King ) );

            sh.ScoreHand( hand4 );
            b = hand4.Score == SCORE.RoyalFlush;
            Console.WriteLine( "Hand 4 is Royal Flush: {0}.", b );
            Console.WriteLine( hand4.ToString() );

            //
            // Test IsStraightFlush()
            //
            Hand hand5 = new Hand();
            hand5.AddCard( new Card( SUIT.Diamonds, RANK.Nine ) );
            hand5.AddCard( new Card( SUIT.Diamonds, RANK.Eight ) );
            hand5.AddCard( new Card( SUIT.Diamonds, RANK.Seven ) );
            hand5.AddCard( new Card( SUIT.Diamonds, RANK.Six ) );
            hand5.AddCard( new Card( SUIT.Diamonds, RANK.Five ) );

            sh.ScoreHand( hand5 );
            b = hand5.Score == SCORE.StraightFlush;
            Console.WriteLine( "Hand 5 is Straight Flush: {0}.", b );
            Console.WriteLine( hand5.ToString() );

            //
            // Test IsFourOfAKind()
            //
            Hand hand6 = new Hand();
            hand6.AddCard( new Card( SUIT.Clubs, RANK.Four ) );
            hand6.AddCard( new Card( SUIT.Diamonds, RANK.Four ) );
            hand6.AddCard( new Card( SUIT.Hearts, RANK.Four ) );
            hand6.AddCard( new Card( SUIT.Spades, RANK.Four ) );
            hand6.AddCard( new Card( SUIT.Clubs, RANK.Ace ) );

            sh.ScoreHand( hand6 );
            b = hand6.Score == SCORE.FourOfAKind;
            Console.WriteLine( "Hand 6 is Four Of A Kind: {0}.", b );
            Console.WriteLine( hand6.ToString() );

            //
            // Test IsThreeOfAKind()
            //
            Hand hand7 = new Hand();
            hand7.AddCard( new Card( SUIT.Clubs, RANK.Four ) );
            hand7.AddCard( new Card( SUIT.Diamonds, RANK.Four ) );
            hand7.AddCard( new Card( SUIT.Hearts, RANK.Four ) );
            hand7.AddCard( new Card( SUIT.Spades, RANK.Five ) );
            hand7.AddCard( new Card( SUIT.Clubs, RANK.Ten ) );

            sh.ScoreHand( hand7 );
            b = hand7.Score == SCORE.ThreeOfAKind;
            Console.WriteLine( "Hand 7 is Three Of A Kind: {0}.", b );
            Console.WriteLine( hand7.ToString() );

            Hand hand8 = new Hand();
            hand8.AddCard( new Card( SUIT.Spades, RANK.Two ) );
            hand8.AddCard( new Card( SUIT.Clubs, RANK.Four ) );
            hand8.AddCard( new Card( SUIT.Diamonds, RANK.Four ) );
            hand8.AddCard( new Card( SUIT.Hearts, RANK.Four ) );
            hand8.AddCard( new Card( SUIT.Clubs, RANK.Ten ) );

            sh.ScoreHand( hand8 );
            b = hand8.Score == SCORE.ThreeOfAKind;
            Console.WriteLine( "Hand 8 is Three Of A Kind: {0}.", b );
            Console.WriteLine( hand8.ToString() );

            Hand hand9 = new Hand();
            hand9.AddCard( new Card( SUIT.Spades, RANK.Two ) );
            hand9.AddCard( new Card( SUIT.Clubs, RANK.Three ) );
            hand9.AddCard( new Card( SUIT.Clubs, RANK.Four ) );
            hand9.AddCard( new Card( SUIT.Diamonds, RANK.Four ) );
            hand9.AddCard( new Card( SUIT.Hearts, RANK.Four ) );

            sh.ScoreHand( hand9 );
            b = hand9.Score == SCORE.ThreeOfAKind;
            Console.WriteLine( "Hand 9 is Three Of A Kind: {0}.", b );
            Console.WriteLine( hand9.ToString() );

            //
            // Test IsTwoPair()
            //
            Hand hand10 = new Hand();
            hand10.AddCard( new Card( SUIT.Spades, RANK.Three ) );
            hand10.AddCard( new Card( SUIT.Clubs, RANK.Three ) );
            hand10.AddCard( new Card( SUIT.Clubs, RANK.Four ) );
            hand10.AddCard( new Card( SUIT.Diamonds, RANK.Four ) );
            hand10.AddCard( new Card( SUIT.Hearts, RANK.King ) );

            sh.ScoreHand( hand10 );
            b = hand10.Score == SCORE.TwoPair;
            Console.WriteLine( "Hand 10 is Two Pair: {0}.", b );
            Console.WriteLine( hand10.ToString() );

            Hand hand11 = new Hand();
            hand11.AddCard( new Card( SUIT.Hearts, RANK.Two ) );
            hand11.AddCard( new Card( SUIT.Spades, RANK.Three ) );
            hand11.AddCard( new Card( SUIT.Clubs, RANK.Three ) );
            hand11.AddCard( new Card( SUIT.Clubs, RANK.Four ) );
            hand11.AddCard( new Card( SUIT.Diamonds, RANK.Four ) );

            sh.ScoreHand( hand11 );
            b = hand11.Score == SCORE.TwoPair;
            Console.WriteLine( "Hand 11 is Two Pair: {0}.", b );
            Console.WriteLine( hand11.ToString() );

            Hand hand12 = new Hand();
            hand12.AddCard( new Card( SUIT.Spades, RANK.Three ) );
            hand12.AddCard( new Card( SUIT.Clubs, RANK.Three ) );
            hand12.AddCard( new Card( SUIT.Hearts, RANK.Five ) );
            hand12.AddCard( new Card( SUIT.Clubs, RANK.Six ) );
            hand12.AddCard( new Card( SUIT.Diamonds, RANK.Six ) );

            sh.ScoreHand( hand12 );
            b = hand12.Score == SCORE.TwoPair;
            Console.WriteLine( "Hand 12 is Two Pair: {0}.", b );
            Console.WriteLine( hand12.ToString() );

            //
            // Test IsOnePair()
            //
            Hand hand13 = new Hand();
            hand13.AddCard( new Card( SUIT.Spades, RANK.Three ) );
            hand13.AddCard( new Card( SUIT.Clubs, RANK.Three ) );
            hand13.AddCard( new Card( SUIT.Hearts, RANK.Five ) );
            hand13.AddCard( new Card( SUIT.Clubs, RANK.Six ) );
            hand13.AddCard( new Card( SUIT.Diamonds, RANK.Seven ) );

            sh.ScoreHand( hand13 );
            b = hand13.Score == SCORE.OnePair;
            Console.WriteLine( "Hand 13 is One Pair: {0}.", b );
            Console.WriteLine( hand13.ToString() );

            Hand hand14 = new Hand();
            hand14.AddCard( new Card( SUIT.Spades, RANK.Three ) );
            hand14.AddCard( new Card( SUIT.Clubs, RANK.Four ) );
            hand14.AddCard( new Card( SUIT.Hearts, RANK.Four ) );
            hand14.AddCard( new Card( SUIT.Clubs, RANK.Six ) );
            hand14.AddCard( new Card( SUIT.Diamonds, RANK.Seven ) );

            sh.ScoreHand( hand14 );
            b = hand14.Score == SCORE.OnePair;
            Console.WriteLine( "Hand 14 is One Pair: {0}.", b );
            Console.WriteLine( hand14.ToString() );

            Hand hand15 = new Hand();
            hand15.AddCard( new Card( SUIT.Spades, RANK.Three ) );
            hand15.AddCard( new Card( SUIT.Clubs, RANK.Four ) );
            hand15.AddCard( new Card( SUIT.Hearts, RANK.Five ) );
            hand15.AddCard( new Card( SUIT.Clubs, RANK.Five ) );
            hand15.AddCard( new Card( SUIT.Diamonds, RANK.Seven ) );

            sh.ScoreHand( hand15 );
            b = hand15.Score == SCORE.OnePair;
            Console.WriteLine( "Hand 15 is One Pair: {0}.", b );
            Console.WriteLine( hand15.ToString() );

            Hand hand16 = new Hand();
            hand16.AddCard( new Card( SUIT.Spades, RANK.Three ) );
            hand16.AddCard( new Card( SUIT.Clubs, RANK.Four ) );
            hand16.AddCard( new Card( SUIT.Hearts, RANK.Five ) );
            hand16.AddCard( new Card( SUIT.Clubs, RANK.Six ) );
            hand16.AddCard( new Card( SUIT.Diamonds, RANK.Six ) );

            sh.ScoreHand( hand16 );
            b = hand16.Score == SCORE.OnePair;
            Console.WriteLine( "Hand 16 is One Pair: {0}.", b );
            Console.WriteLine( hand16.ToString() );

            //
            // Test to see if Hand's score falls through to HighCard
            //
            Hand hand17 = new Hand();
            hand17.AddCard( new Card( SUIT.Spades, RANK.Two ) );
            hand17.AddCard( new Card( SUIT.Clubs, RANK.Four ) );
            hand17.AddCard( new Card( SUIT.Hearts, RANK.Six ) );
            hand17.AddCard( new Card( SUIT.Clubs, RANK.Eight ) );
            hand17.AddCard( new Card( SUIT.Diamonds, RANK.Ten ) );

            Console.WriteLine();
            Console.WriteLine( "Hand 17 is really lousy." );
            sh.ScoreHand( hand17 );
            b = hand17.Score == SCORE.HighCard;

            string msg = b ? String.Format( "Hand 17 is HighCard: {0}.", b ) : String.Format( "Something went wrong. Hand 17 is: {0}", Enum.GetName( typeof( SCORE ), hand17.Score ) );

            Console.WriteLine( msg );
            Console.WriteLine( hand17.ToString() );
        }

        #endregion
    }
}
