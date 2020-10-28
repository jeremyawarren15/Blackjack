using Extensions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class DeckService
    {
        private List<Card> Deck { get; set; }

        public List<Card> GenerateDeck()
        {
            Deck.Clear();

            var suits = Enum.GetValues(typeof(Suit)).Cast<Suit>();
            var ranks = Enum.GetValues(typeof(Rank)).Cast<Rank>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Deck.Add(new Card(suit, rank));
                }
            }

            return Deck.Shuffle();
        }
    }
}
