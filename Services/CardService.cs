using Domain.Enumerations;
using Domain.Models;
using Extensions;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class CardService : ICardService
    {
        public string GetFullNameOfCard(Card card)
        {
            return $"{card.Rank} of {card.Suit}s";
        }

        public Stack<Card> GetDeck(int numberOfDecks = 1)
        {
            if (numberOfDecks < 0)
            {
                throw new ArgumentOutOfRangeException("Number of decks cannot be negative.");
            }

            if (numberOfDecks == 0)
            {
                return new Stack<Card>();
            }

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

        public int GetValueOfHand(List<Card> cards)
        {
            int sum = 0;

            if (cards == null)
            {
                return sum;
            }

            foreach (var card in cards)
            {
                sum += GetValue(card);
            }

            return sum;
        }

        private int GetValue(Card card)
        {
            switch (card.Rank)
            {
                case Rank.Ace:
                    return 1;
                case Rank.Two:
                    return 2;
                case Rank.Three:
                    return 3;
                case Rank.Four:
                    return 4;
                case Rank.Five:
                    return 5;
                case Rank.Six:
                    return 6;
                case Rank.Seven:
                    return 7;
                case Rank.Eight:
                    return 8;
                case Rank.Nine:
                    return 9;
                case Rank.Ten:
                case Rank.Jack:
                case Rank.Queen:
                case Rank.King:
                    return 10;
            }

            return 0;
        }
    }
}
