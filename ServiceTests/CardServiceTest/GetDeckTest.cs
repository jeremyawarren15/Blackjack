using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTests.CardServiceTest
{
    [TestFixture]
    public class GetDeckTest
    {
        [Test]
        public void GetsAllCards()
        {
            var service = new CardService();

            var cards = service.GetDeck();

            Assert.IsNotNull(cards);
            Assert.IsNotEmpty(cards);
            Assert.AreEqual(52, cards.Count);
        }

        [TestCase(1)]
        [TestCase(231)]
        [TestCase(3)]
        public void GetsMultipleDecksCorrectly(int numberOfDecks)
        {
            var service = new CardService();

            var cards = service.GetDeck(numberOfDecks);

            Assert.IsNotNull(cards);
            Assert.IsNotEmpty(cards);
            Assert.AreEqual(52 * numberOfDecks, cards.Count);
        }

        [Test]
        public void ThrowsErrorIfNegative()
        {
            var service = new CardService();

            Assert.Throws<ArgumentOutOfRangeException>(() => service.GetDeck(-1));
        }

        [Test]
        public void ReturnsNoCardsIfNumberOfDecksIsZero()
        {
            var service = new CardService();

            var cards = service.GetDeck(0);

            Assert.IsNotNull(cards);
            Assert.IsEmpty(cards);
        }
    }
}
