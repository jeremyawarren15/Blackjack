using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface ICardGameService<MoveEnumType> where MoveEnumType : Enum
    {
        void LoadPlayers(List<Player> players);
        void BeginRound();
        string GetCurrentPlayerName();
        List<Card> GetCurrentPlayerHand();
        MoveStatus Move(MoveEnumType move);
        bool IsRoundInProgress();
        List<Player> GetWinners();
    }
}
