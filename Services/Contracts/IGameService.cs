using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IGameService
    {
        void LoadPlayers(List<Player> players);
        void BeginRound();
        string GetCurrentPlayerName();
        List<Card> GetCurrentPlayerHand();
        bool Hit();
        bool Stand();
        bool IsRoundComplete();
    }
}
