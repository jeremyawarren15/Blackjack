using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Contracts
{
    public interface IViewEngine
    {
        bool Move(string currentPlayerName, List<Card> hand);
        List<Player> CreatePlayers();
        void PlayerBusted(string name, string nextPlayerName);
    }
}
