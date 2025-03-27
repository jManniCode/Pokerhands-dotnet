using Xunit;

namespace CardGame;

public class PokerTest
{

    [Fact]
    public void TestHand2Has2PairAndHand1Has1Pair()
    {
        var pairHand = new Hand(new List<Card>
        {
            new Card('♠', 'A'),
            new Card('♣', 'A'),
            new Card('♦', 'Q'),
            new Card('♣', 'J'),
            new Card('♥', '4')

        });

        var twoPairHand = new Hand(new List<Card>
        {
            new Card('♠', 'A'),
            new Card('♣', 'A'),
            new Card('♦', 'K'),
            new Card('♣', 'K'),
            new Card('♥', '4')
        });

        var (winningHand, handType) = CompareHands.CheckHands(pairHand, twoPairHand);


        Assert.Equal(twoPairHand, winningHand);
        Assert.Equal("Two Pair", handType);

    }

    [Fact]

    public void TestIfIsTwoPairIsWorking()
    {
        var twoPairHand = new Hand(new List<Card>
        {
            new Card('♠', 'A'),
            new Card('♣', 'A'),
            new Card('♦', 'K'),
            new Card('♣', 'K'),
            new Card('♥', '4')
        });

        var result = CompareHands.IsTwoPair(twoPairHand);

        Assert.NotNull(result);

        Assert.Equal(twoPairHand, result);
    }
    
}

