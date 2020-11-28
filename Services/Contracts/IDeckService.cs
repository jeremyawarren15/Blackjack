using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IDeckService
    {
        void GenerateDeck();
        void GenerateDeck(int numberOfDecks);
        Card Draw();
        void Discard(Card card);
        void Discard(Stack<Card> cards);
    }
}
