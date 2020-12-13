using Core.Enumerations;
using Core.Models;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTests.CardServiceTest
{
    [TestFixture]
    public class GetFullNameOfCardTest
    {
        [TestCase(Rank.Ace, Suit.Spade, "Ace of Spades")]
        [TestCase(Rank.Two, Suit.Spade, "Two of Spades")]
        [TestCase(Rank.Three, Suit.Spade, "Three of Spades")]
        [TestCase(Rank.Four, Suit.Spade, "Four of Spades")]
        [TestCase(Rank.Five, Suit.Spade, "Five of Spades")]
        [TestCase(Rank.Six, Suit.Spade, "Six of Spades")]
        [TestCase(Rank.Seven, Suit.Spade, "Seven of Spades")]
        [TestCase(Rank.Eight, Suit.Spade, "Eight of Spades")]
        [TestCase(Rank.Nine, Suit.Spade, "Nine of Spades")]
        [TestCase(Rank.Ten, Suit.Spade, "Ten of Spades")]
        [TestCase(Rank.Jack, Suit.Spade, "Jack of Spades")]
        [TestCase(Rank.Queen, Suit.Spade, "Queen of Spades")]
        [TestCase(Rank.King, Suit.Spade, "King of Spades")]
        [TestCase(Rank.Ace, Suit.Heart, "Ace of Hearts")]
        [TestCase(Rank.Two, Suit.Heart, "Two of Hearts")]
        [TestCase(Rank.Three, Suit.Heart, "Three of Hearts")]
        [TestCase(Rank.Four, Suit.Heart, "Four of Hearts")]
        [TestCase(Rank.Five, Suit.Heart, "Five of Hearts")]
        [TestCase(Rank.Six, Suit.Heart, "Six of Hearts")]
        [TestCase(Rank.Seven, Suit.Heart, "Seven of Hearts")]
        [TestCase(Rank.Eight, Suit.Heart, "Eight of Hearts")]
        [TestCase(Rank.Nine, Suit.Heart, "Nine of Hearts")]
        [TestCase(Rank.Ten, Suit.Heart, "Ten of Hearts")]
        [TestCase(Rank.Jack, Suit.Heart, "Jack of Hearts")]
        [TestCase(Rank.Queen, Suit.Heart, "Queen of Hearts")]
        [TestCase(Rank.King, Suit.Heart, "King of Hearts")]
        [TestCase(Rank.Ace, Suit.Club, "Ace of Clubs")]
        [TestCase(Rank.Two, Suit.Club, "Two of Clubs")]
        [TestCase(Rank.Three, Suit.Club, "Three of Clubs")]
        [TestCase(Rank.Four, Suit.Club, "Four of Clubs")]
        [TestCase(Rank.Five, Suit.Club, "Five of Clubs")]
        [TestCase(Rank.Six, Suit.Club, "Six of Clubs")]
        [TestCase(Rank.Seven, Suit.Club, "Seven of Clubs")]
        [TestCase(Rank.Eight, Suit.Club, "Eight of Clubs")]
        [TestCase(Rank.Nine, Suit.Club, "Nine of Clubs")]
        [TestCase(Rank.Ten, Suit.Club, "Ten of Clubs")]
        [TestCase(Rank.Jack, Suit.Club, "Jack of Clubs")]
        [TestCase(Rank.Queen, Suit.Club, "Queen of Clubs")]
        [TestCase(Rank.King, Suit.Club, "King of Clubs")]
        [TestCase(Rank.Ace, Suit.Diamond, "Ace of Diamonds")]
        [TestCase(Rank.Two, Suit.Diamond, "Two of Diamonds")]
        [TestCase(Rank.Three, Suit.Diamond, "Three of Diamonds")]
        [TestCase(Rank.Four, Suit.Diamond, "Four of Diamonds")]
        [TestCase(Rank.Five, Suit.Diamond, "Five of Diamonds")]
        [TestCase(Rank.Six, Suit.Diamond, "Six of Diamonds")]
        [TestCase(Rank.Seven, Suit.Diamond, "Seven of Diamonds")]
        [TestCase(Rank.Eight, Suit.Diamond, "Eight of Diamonds")]
        [TestCase(Rank.Nine, Suit.Diamond, "Nine of Diamonds")]
        [TestCase(Rank.Ten, Suit.Diamond, "Ten of Diamonds")]
        [TestCase(Rank.Jack, Suit.Diamond, "Jack of Diamonds")]
        [TestCase(Rank.Queen, Suit.Diamond, "Queen of Diamonds")]
        [TestCase(Rank.King, Suit.Diamond, "King of Diamonds")]
        public void CanGetCorrectNameOfCard(Rank rank, Suit suit, string expectedResult)
        {
            var service = new CardService();

            var card = new Card(suit, rank);

            var result = service.GetFullNameOfCard(card);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
