using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface ICardService
    {
        string GetFullNameOfCard(Card card);
        Stack<Card> GetDeck(int numberOfDecks = 1);
        int GetValueOfHand(List<Card> hand);
    }
}
