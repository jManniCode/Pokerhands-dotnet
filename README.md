# Pokerhands Unit Tests

This repository contains unit tests for the Pokerhands program. The tests are written using xUnit and aim to verify that the program correctly identifies various poker hands and that the main method `CompareHands.CheckHands` correctly determines the winning hand according to standard poker rules.

## Overview

The tests are divided into two parts:

1. **Hand-Identifying Methods**  
   These tests verify that methods such as `IsPair`, `IsTwoPair`, `IsFlush`, `IsStraight`, `IsFullHouse`, `IsThreeOfAKind`, `IsFourOfAKind`, `IsStraightFlush`, `IsRoyalFlush`, and `IsRoyalStraightFlush` function as expected.  
   - For example, `IsFlush(hand)` should return a tuple `(hand, "Flush")` when the hand is a flush (all cards have the same suit) and `(null, null)` if it is not.

2. **Main Method: `CompareHands.CheckHands`**  
   This method compares two poker hands by calling the individual hand-identifying methods in a predefined order (based on a point system) and returns a tuple with the winning hand and its type (e.g., "Two Pair", "High Card", etc.).  
   - The tests for `CheckHands` cover various scenarios, such as comparing a hand with a pair versus a hand with two pair, royal flush versus four of a kind, flush versus flush (where the highest card wins), and tied hands.

## Test Cases

The following test cases have been implemented:

1. **TestHand2Has2PairAndHand1Has1Pair**  
   - **Purpose:** Compare two hands where Hand 2 has two pair and Hand 1 has either a pair or no special hand.
   - **Expected Result:** Hand 2 wins with hand type "Two Pair".

2. **TestIfIsTwoPairIsWorking**  
   - **Purpose:** Verify that `IsTwoPair` correctly identifies a hand with two pair by returning a tuple with the hand and the string "Two Pair".

3. **TestIsFlushCorrect**  
   - **Purpose:** Test that `IsFlush` correctly identifies a flush-hand (all cards having the same suit) and returns a tuple with `(hand, "Flush")`.  
   - For a non-flush hand, it should return a tuple where both fields are null.

4. **TestIsPair & TestIsNotPair**  
   - **Purpose:** Ensure that `IsPair` returns the correct tuple with "Pair" when a pair exists, and `(null, null)` when there is no pair.

5. **TestIsThreeOfAKind**  
   - **Purpose:** Verify that a hand with three cards of the same rank returns "Three of a Kind".

6. **TestIsStraight & TestIsNotStraight**  
   - **Purpose:** Test that a valid straight (e.g., 5,6,7,8,9) is identified as "Straight" and that an invalid straight returns `(null, null)`.

7. **TestIsFullHouse**  
   - **Purpose:** Check that a full house hand (e.g., three 10s and two Kings) returns "Full House".

8. **TestIsFourOfAKind**  
   - **Purpose:** Verify that a hand with four cards of the same rank returns "Four of a Kind".

9. **TestIsStraightFlush**  
   - **Purpose:** Test that a hand that is both straight and flush returns "Straight Flush".

10. **TestIsRoyalFlush**  
    - **Purpose:** Check that a hand with T, J, Q, K, A all in the same suit returns "Royal Flush".

11. **TestIsRoyalStraightFlush**  
    - **Purpose:** Verify that a hand with T, J, Q, K, A in the same suit can also be identified as "Royal Straight Flush" (depending on the implementation).

12. **TestCheckHands_HighCardComparison**  
    - **Purpose:** Compare two hands with only high cards, where the hand with the higher kicker wins.  
    - **Expected Result:** The hand with the higher high card wins, with hand type "High Card".

13. **TestCheckHands_TieScenario**  
    - **Purpose:** Test a tie scenario with two identical high card hands.  
    - **Expected Result:** Since the hands are identical, `CompareHighestCard` should return null and the hand type should be "High Card".
