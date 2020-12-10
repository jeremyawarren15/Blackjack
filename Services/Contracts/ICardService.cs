using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface ICardService
    {
        string GetFullNameOfCard(Card card);
        Stack<Card> GetDeck(int numberOfDecks = 1);
        int GetValueOfHand(List<Card> hand);
    }
}
