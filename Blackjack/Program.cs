using Autofac;
using Domain.Models;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class Program
    {
        static void Main(string[] args)
        {
            // new up container for dependencies
            var builder = new ContainerBuilder();

            // register dependencies
            builder.RegisterType<CardService>().As<ICardService>();
            builder.RegisterType<GameService>().As<IGameService>();

            // build
            var container = builder.Build();

            var cardService = container.Resolve<ICardService>();
            var game = container.Resolve<IGameService>();

            // TODO: Move the following code to another class

            var view = new ViewEngine(cardService);

            var newPlayers = new List<Player>()
            {
                // initialize new players here
                // need to write a view engine 
                // to cover this
            };

            game.LoadPlayers(newPlayers);
            game.BeginRound();

            while (true)
            {
                var move = view.MoveView(game.GetCurrentPlayerName(), game.GetCurrentPlayerHand());

                if (move)
                {
                    game.Hit();
                }
                else
                {
                    game.Stand();
                }
            }
        }
    }
}
