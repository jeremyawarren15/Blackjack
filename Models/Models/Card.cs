using Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Card
    {
        public Rank Rank { get; }
        public Suit Suit { get; }

        public Card(Suit suit, Rank rank)
        {
            Rank = rank;
            Suit = suit;
        }
    }
}
