using Blackjack.Contracts;
using Domain.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public class GameEngine : IGameEngine
    {
        private IViewEngine _viewEngine;
        private IGameService _gameService;

        public GameEngine(IViewEngine viewEngine, IGameService gameService)
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
                    // if Hit() returns false it means the player busted 
                    if (!_gameService.Hit())
                    {
                        // we are getting the current player as the next player
                        // because the game service has already moved on to the
                        // next player
                        _viewEngine.PlayerBusted(currentPlayerName, _gameService.GetCurrentPlayerName());
                    }
                }
                else
                {
                    _gameService.Stand();
                }

                if (_gameService.IsRoundInProgress())
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("Game Over!");
        }
    }

}
