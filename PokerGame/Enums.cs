namespace PokerGame
{
    /// <summary>
    /// Represents the Suits in the Card Deck.
    /// </summary>
    public enum SUIT
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    /// <summary>
    /// Represents the Rank or Face of each Card in the Deck.
    /// Caveat: Rank of Cards is in order in this enum, but Ace is a 
    /// special case.  See how this is handled in the ScoreHelper.
    /// </summary>
    public enum RANK
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    /// <summary>
    /// Represents the possible scores for each Hand in the Game, in order.
    /// </summary>
    public enum SCORE
    {
        None,
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }
}