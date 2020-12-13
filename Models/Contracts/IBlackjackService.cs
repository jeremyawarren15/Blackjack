using Core.Enumerations;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IBlackjackService
    {
        void LoadPlayers(List<Player> players);
        void BeginRound();
        string GetCurrentPlayerName();
        List<Card> GetCurrentPlayerHand();
        MoveStatus Move(BlackjackMove move);
        bool IsRoundInProgress();
        List<Player> GetWinners();
    }
}
