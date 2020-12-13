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
    public class GetValueOfHandTest
    {
        [Test]
        public void ReturnsZeroWithEmptyHand()
        {
            var cardService = new CardService();

            var result = cardService.GetValueOfHand(new List<Card>());

            Assert.AreEqual(0, result);
        }

        [Test]
        public void ReturnsZeroWithNullHand()
        {
            var cardService = new CardService();

            var result = cardService.GetValueOfHand(null);

            Assert.AreEqual(0, result);
        }

        [TestCase(Rank.Ace, 1)]
        [TestCase(Rank.Two, 2)]
        [TestCase(Rank.Three, 3)]
        [TestCase(Rank.Four, 4)]
        [TestCase(Rank.Five, 5)]
        [TestCase(Rank.Six, 6)]
        [TestCase(Rank.Seven, 7)]
        [TestCase(Rank.Eight, 8)]
        [TestCase(Rank.Nine, 9)]
        [TestCase(Rank.Ten, 10)]
        [TestCase(Rank.Jack, 10)]
        [TestCase(Rank.Queen, 10)]
        [TestCase(Rank.King, 10)]
        public void CalculatesCardValueCorrectly(Rank rank, int expectedValue)
        {
            var cardService = new CardService();

            var card = new Card(Suit.Heart, rank);

            var result = cardService.GetValueOfHand(new List<Card>() { card });

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void CanSumMultipleCardsCorrectly()
        {
            var cardService = new CardService();

            var cards = new List<Card>()
            {
                new Card(Suit.Diamond, Rank.Three),
                new Card(Suit.Heart, Rank.Four),
                new Card(Suit.Club, Rank.Jack)
            };

            var result = cardService.GetValueOfHand(cards);

            Assert.AreEqual(17, result);
        }
    }
}
