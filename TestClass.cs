using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CardGame.Tests
{
    public class PokerTest
    {
        // Test 1: Jämför två händer där Hand 2 har två par och Hand 1 har endast ett par (eller inget special).
        // Förväntat: Hand 2 vinner med handtypen "Two Pair".
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

        // Test 2: Verifierar att IsTwoPair returnerar en tuple med rätt hand och handtyp "Two Pair"
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

        // Test 3: Testar IsFlush både för en korrekt flush-hand och för en hand som inte är flush
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
            

            // Eftersom vi nu returnerar en tuple (Hand, string), kontrollerar vi enskilda fält
            Assert.Null(noFlush.hand);
            Assert.Null(noFlush.handType);
        }

        // Extra tester för de enskilda handidentifierande metoderna:

        [Fact]
        public void TestIsPair()
        {
            // Hand med ett par (två 5:or)
            var pairHand = new Hand(new List<Card>
            {
                new Card('♠', '5'),
                new Card('♣', '5'),
                new Card('♦', '7'),
                new Card('♣', '9'),
                new Card('♥', 'J')
            });

            var result = CompareHands.IsPair(pairHand);
            Assert.NotNull(result.hand);
            Assert.Equal("Pair", result.handType);
        }

        [Fact]
        public void TestIsNotPair()
        {
            // Hand utan par
            var noPairHand = new Hand(new List<Card>
            {
                new Card('♠', '5'),
                new Card('♣', '6'),
                new Card('♦', '7'),
                new Card('♣', '9'),
                new Card('♥', 'J')
            });

            var result = CompareHands.IsPair(noPairHand);
            Assert.Null(result.hand);
            Assert.Null(result.handType);
        }

        [Fact]
        public void TestIsThreeOfAKind()
        {
            // Hand med tre 8:or
            var threeOfAKindHand = new Hand(new List<Card>
            {
                new Card('♠', '8'),
                new Card('♣', '8'),
                new Card('♦', '8'),
                new Card('♣', 'Q'),
                new Card('♥', 'T')
            });

            var result = CompareHands.IsThreeOfAKind(threeOfAKindHand);
            Assert.NotNull(result.hand);
            Assert.Equal("Three of a Kind", result.handType);
        }

        [Fact]
        public void TestIsStraight()
        {
            // Hand med en straight: 5,6,7,8,9 (olika suits)
            var straightHand = new Hand(new List<Card>
            {
                new Card('♠', '5'),
                new Card('♣', '6'),
                new Card('♦', '7'),
                new Card('♣', '8'),
                new Card('♥', '9')
            });

            var result = CompareHands.IsStraight(straightHand);
            Assert.NotNull(result.hand);
            Assert.Equal("Straight", result.handType);
        }

        [Fact]
        public void TestIsNotStraight()
        {
            // Hand som inte är en straight
            var nonStraightHand = new Hand(new List<Card>
            {
                new Card('♠', '5'),
                new Card('♣', '6'),
                new Card('♦', '7'),
                new Card('♣', '9'),
                new Card('♥', 'J')
            });

            var result = CompareHands.IsStraight(nonStraightHand);
            Assert.Null(result.hand);
            Assert.Null(result.handType);
        }

        [Fact]
        public void TestIsFullHouse()
        {
            // Hand med full house: tre 10:or och två K:or
            var fullHouseHand = new Hand(new List<Card>
            {
                new Card('♠', 'T'),
                new Card('♣', 'T'),
                new Card('♦', 'T'),
                new Card('♣', 'K'),
                new Card('♥', 'K')
            });

            var result = CompareHands.IsFullHouse(fullHouseHand);
            Assert.NotNull(result.hand);
            Assert.Equal("Full House", result.handType);
        }

        [Fact]
        public void TestIsFourOfAKind()
        {
            // Hand med fyra 9:or
            var fourOfAKindHand = new Hand(new List<Card>
            {
                new Card('♠', '9'),
                new Card('♣', '9'),
                new Card('♦', '9'),
                new Card('♣', '9'),
                new Card('♥', 'Q')
            });

            var result = CompareHands.IsFourOfAKind(fourOfAKindHand);
            Assert.NotNull(result.hand);
            Assert.Equal("Four of a Kind", result.handType);
        }

        [Fact]
        public void TestIsStraightFlush()
        {
            // Hand med straight flush: 6,7,8,9,T alla i hjärter
            var straightFlushHand = new Hand(new List<Card>
            {
                new Card('♥', '6'),
                new Card('♥', '7'),
                new Card('♥', '8'),
                new Card('♥', '9'),
                new Card('♥', 'T')
            });

            var result = CompareHands.IsStraightFlush(straightFlushHand);
            Assert.NotNull(result.hand);
            Assert.Equal("Straight Flush", result.handType);
        }

        [Fact]
        public void TestIsRoyalFlush()
        {
            // Hand med royal flush: T, J, Q, K, A alla i spader
            var royalFlushHand = new Hand(new List<Card>
            {
                new Card('♠', 'T'),
                new Card('♠', 'J'),
                new Card('♠', 'Q'),
                new Card('♠', 'K'),
                new Card('♠', 'A')
            });

            var result = CompareHands.IsRoyalFlush(royalFlushHand);
            Assert.NotNull(result.hand);
            Assert.Equal("Royal Flush", result.handType);
        }

        [Fact]
        public void TestIsRoyalStraightFlush()
        {
            // Hand med royal straight flush: T, J, Q, K, A alla i spader
            var royalStraightFlushHand = new Hand(new List<Card>
            {
                new Card('♠', 'T'),
                new Card('♠', 'J'),
                new Card('♠', 'Q'),
                new Card('♠', 'K'),
                new Card('♠', 'A')
            });

            var result = CompareHands.IsRoyalStraightFlush(royalStraightFlushHand);
            Assert.NotNull(result.hand);
            Assert.Equal("Royal Straight Flush", result.handType);
        }

        // Nedan följer två ytterligare tester för CheckHands:

        // Test 1: Två händer med High Card, jämförelse avgörs via CompareHighestCard.
        // Hand1 har högre sista kort än Hand2. Förväntat: Hand1 vinner med "High Card".
        [Fact]
        public void TestCheckHands_HighCardComparison()
        {
            var highCardHand1 = new Hand(new List<Card>
            {
                new Card('♠', 'A'),
                new Card('♣', 'K'),
                new Card('♦', 'Q'),
                new Card('♣', 'J'),
                new Card('♥', '9')
            });

            var highCardHand2 = new Hand(new List<Card>
            {
                new Card('♠', 'A'),
                new Card('♣', 'K'),
                new Card('♦', 'Q'),
                new Card('♣', 'J'),
                new Card('♥', '8')
            });

            var (winningHand, handType) = CompareHands.CheckHands(highCardHand1, highCardHand2);
            Assert.Equal(highCardHand1, winningHand);
            Assert.Equal("High Card", handType);
        }

        // Test 2: Oavgjort scenario (två identiska High Card-händer).
        // Förväntat: Eftersom händerna är lika returnerar CompareHighestCard null, handtypen ska vara "High Card".
        [Fact]
        public void TestCheckHands_TieScenario()
        {
            var tieHand1 = new Hand(new List<Card>
            {
                new Card('♠', 'A'),
                new Card('♣', 'K'),
                new Card('♦', 'Q'),
                new Card('♣', 'J'),
                new Card('♥', '8')
            });

            var tieHand2 = new Hand(new List<Card>
            {
                new Card('♥', 'A'),
                new Card('♠', 'K'),
                new Card('♣', 'Q'),
                new Card('♦', 'J'),
                new Card('♣', '8')
            });

            var (winningHand, handType) = CompareHands.CheckHands(tieHand1, tieHand2);
            Assert.Null(winningHand);
            Assert.Equal("High Card", handType);
        }
    }
}
