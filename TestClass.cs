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

        Assert.NotNull(result.hand);
        Assert.Equal(twoPairHand, result.hand);
        Assert.Equal("Two Pair", result.handType);
    }

    [Fact]
    public void TestIsFlushCorrect()
    {
        var flushHand = new Hand(new List<Card>
            {
                new Card('♠', 'A'),
                new Card('♠', 'K'),
                new Card('♠', 'Q'),
                new Card('♠', 'J'),
                new Card('♠', 'T')
            });

        var nonFlushHand = new Hand(new List<Card>
            {
                new Card('♠', 'A'),
                new Card('♣', 'K'),
                new Card('♦', 'Q'),
                new Card('♠', 'J'),
                new Card('♥', 'T')
            });

      
        var isFlushHand = CompareHands.IsFlush(flushHand);
        var noFlush = CompareHands.IsFlush(nonFlushHand);

 
        Assert.NotNull(isFlushHand.hand);
        Assert.Equal(flushHand, isFlushHand.hand);

        Assert.Null(noFlush.hand);
        Assert.Null(noFlush.handType);
    }
}



