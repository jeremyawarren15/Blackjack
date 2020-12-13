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
    public class GetSymbolOfCardTest
    {
        [TestCase(Rank.Ace, Suit.Spade, "A♠")]
        [TestCase(Rank.Two, Suit.Spade, "2♠")]
        [TestCase(Rank.Three, Suit.Spade, "3♠")]
        [TestCase(Rank.Four, Suit.Spade, "4♠")]
        [TestCase(Rank.Five, Suit.Spade, "5♠")]
        [TestCase(Rank.Six, Suit.Spade, "6♠")]
        [TestCase(Rank.Seven, Suit.Spade, "7♠")]
        [TestCase(Rank.Eight, Suit.Spade, "8♠")]
        [TestCase(Rank.Nine, Suit.Spade, "9♠")]
        [TestCase(Rank.Ten, Suit.Spade, "10♠")]
        [TestCase(Rank.Jack, Suit.Spade, "J♠")]
        [TestCase(Rank.Queen, Suit.Spade, "Q♠")]
        [TestCase(Rank.King, Suit.Spade, "K♠")]
        [TestCase(Rank.Ace, Suit.Club, "A♣")]
        [TestCase(Rank.Two, Suit.Club, "2♣")]
        [TestCase(Rank.Three, Suit.Club, "3♣")]
        [TestCase(Rank.Four, Suit.Club, "4♣")]
        [TestCase(Rank.Five, Suit.Club, "5♣")]
        [TestCase(Rank.Six, Suit.Club, "6♣")]
        [TestCase(Rank.Seven, Suit.Club, "7♣")]
        [TestCase(Rank.Eight, Suit.Club, "8♣")]
        [TestCase(Rank.Nine, Suit.Club, "9♣")]
        [TestCase(Rank.Ten, Suit.Club, "10♣")]
        [TestCase(Rank.Jack, Suit.Club, "J♣")]
        [TestCase(Rank.Queen, Suit.Club, "Q♣")]
        [TestCase(Rank.King, Suit.Club, "K♣")]
        [TestCase(Rank.Ace, Suit.Heart, "A♥")]
        [TestCase(Rank.Two, Suit.Heart, "2♥")]
        [TestCase(Rank.Three, Suit.Heart, "3♥")]
        [TestCase(Rank.Four, Suit.Heart, "4♥")]
        [TestCase(Rank.Five, Suit.Heart, "5♥")]
        [TestCase(Rank.Six, Suit.Heart, "6♥")]
        [TestCase(Rank.Seven, Suit.Heart, "7♥")]
        [TestCase(Rank.Eight, Suit.Heart, "8♥")]
        [TestCase(Rank.Nine, Suit.Heart, "9♥")]
        [TestCase(Rank.Ten, Suit.Heart, "10♥")]
        [TestCase(Rank.Jack, Suit.Heart, "J♥")]
        [TestCase(Rank.Queen, Suit.Heart, "Q♥")]
        [TestCase(Rank.King, Suit.Heart, "K♥")]
        [TestCase(Rank.Ace, Suit.Diamond, "A♦")]
        [TestCase(Rank.Two, Suit.Diamond, "2♦")]
        [TestCase(Rank.Three, Suit.Diamond, "3♦")]
        [TestCase(Rank.Four, Suit.Diamond, "4♦")]
        [TestCase(Rank.Five, Suit.Diamond, "5♦")]
        [TestCase(Rank.Six, Suit.Diamond, "6♦")]
        [TestCase(Rank.Seven, Suit.Diamond, "7♦")]
        [TestCase(Rank.Eight, Suit.Diamond, "8♦")]
        [TestCase(Rank.Nine, Suit.Diamond, "9♦")]
        [TestCase(Rank.Ten, Suit.Diamond, "10♦")]
        [TestCase(Rank.Jack, Suit.Diamond, "J♦")]
        [TestCase(Rank.Queen, Suit.Diamond, "Q♦")]
        [TestCase(Rank.King, Suit.Diamond, "K♦")]
        public void GetsCorrectSymbolForCard(Rank rank, Suit suit, string expectedResult)
        {
            var service = new CardService();

            var card = new Card(suit, rank);

            var symbol = service.GetSymbolOfCard(card);

            Assert.AreEqual(expectedResult, symbol);
        }
    }
}
