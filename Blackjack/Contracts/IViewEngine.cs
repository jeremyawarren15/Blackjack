using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Contracts
{
    public interface IViewEngine
    {
        bool MoveView(string currentPlayerName, List<Card> hand);
    }
}
