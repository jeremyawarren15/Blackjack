using NUnit.Framework;
using Services;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ServiceTests.DeckServiceTest
{
    [TestFixture]
    public class GenerateDeckTest
    {
        [Test]
        public void CreatesAllCards()
        {
            var unitUnderTest = new DeckService();

            var deck = unitUnderTest.GenerateDeck();

            var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>();
            var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>();

            Assert.AreEqual(52, deck.Count);

            foreach(var suit in suits)
            {
                foreach(var rank in ranks)
                {
                    Assert.NotNull(deck.FirstOrDefault(x => x.Rank == rank && x.Suit == suit));
                }
            }
        }

        [Test]
        public void CanCreateMultipleDecksCorrectly()
        {
            var numberOfDecks = 15;
            var unitUnderTest = new DeckService();

            var deck = unitUnderTest.GenerateDeck(numberOfDecks);

            var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>();
            var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>();

            Assert.AreEqual(52 * numberOfDecks, deck.Count);

            foreach(var suit in suits)
            {
                foreach(var rank in ranks)
                {
                    Assert.NotNull(deck.FirstOrDefault(x => x.Rank == rank && x.Suit == suit));
                    Assert.AreEqual(numberOfDecks, deck.Count(x => x.Rank == rank && x.Suit == suit));
                }
            }
        }
    }
}
