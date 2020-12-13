using Blackjack.Contracts;
using Core.Contracts;
using Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public class GameEngine : IGameEngine
    {
        private IViewEngine _viewEngine;
        private IBlackjackService _gameService;

        public GameEngine(IViewEngine viewEngine, IBlackjackService gameService)
        {
            _viewEngine = viewEngine;
            _gameService = gameService;
        }

        public void Run()
        {
            var newPlayers = _viewEngine.CreatePlayers();

            _gameService.LoadPlayers(newPlayers);
            _gameService.BeginRound();

            while (true)
            {
                var currentPlayerName = _gameService.GetCurrentPlayerName();

                var move = _viewEngine.Move(currentPlayerName, _gameService.GetCurrentPlayerHand());

                if (move)
                {
                    if (!_gameService.Move(BlackjackMove.Hit).MoveSucceeded)
                    {
                        // we are getting the current player as the next player
                        // because the game service has already moved on to the
                        // next player
                        _viewEngine.PlayerBusted(currentPlayerName, _gameService.GetCurrentPlayerName());
                    }
                }
                else
                {
                    _gameService.Move(BlackjackMove.Stand);
                }

                if (!_gameService.IsRoundInProgress())
                {
                    break;
                }
            }

            Console.Clear();

            foreach (var winner in _gameService.GetWinners())
            {
                Console.WriteLine($"{winner.Name} won!");
            }
        }
    }

}
