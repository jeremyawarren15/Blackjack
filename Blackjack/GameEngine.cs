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
                var move = _viewEngine.Move(_gameService.GetCurrentPlayerName(), _gameService.GetCurrentPlayerHand());

                if (move)
                {
                    _gameService.Hit();
                }
                else
                {
                    _gameService.Stand();
                }
            }
        }
    }

}
