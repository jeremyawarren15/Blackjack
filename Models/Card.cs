using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Card
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Suit suit, Rank rank)
        {
            Rank = rank;
            Suit = suit;
        }
    }
}
