using Extensions;
using Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class DeckService : IDeckService
    {
        private Stack<Card> Deck = new Stack<Card>();
        private Stack<Card> DiscardPile = new Stack<Card>();

        public bool HasCards
        {
            get { return Deck.Any(); }
        }

        public bool DiscardPileHasCards
        {
            get { return DiscardPile.Any(); }
        }

        public Card Draw()
        {
            // if there are no more cards in the deck
            // this will attempt to make more cards
            // from the discard pile
            if (!Deck.Any() && DiscardPile.Any())
            {
                Deck = new Stack<Card>(DiscardPile.Shuffle());
            }

            return Deck.Pop();
        }

        public void GenerateDeck()
        {
            Reset();
            Deck = GetAllCards();
        }

        public void GenerateDeck(int numberOfDecks)
        {
            Reset();
            Deck = GetAllCards(numberOfDecks);
        }

        public void Discard(Card card)
        {
            DiscardPile.Push(card);
        }

        public void Discard(Stack<Card> cards)
        {
            foreach(var card in cards)
            {
                DiscardPile.Push(card);
            }
        }

        private Stack<Card> GetAllCards(int numberOfDecks = 1)
        {
            var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>();
            var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>();

            var tempDeck = new List<Card>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    for (int i = 0; i < numberOfDecks; i++)
                    {
                        tempDeck.Add(new Card(suit, rank));
                    }
                }
            }

            return new Stack<Card>(tempDeck.Shuffle());
        }

        private void Reset()
        {
            Deck.Clear();
            DiscardPile.Clear();
        }
    }
}
