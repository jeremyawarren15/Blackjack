using Autofac;
using Blackjack.Contracts;
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
            builder.RegisterType<GameEngine>().As<IGameEngine>();
            builder.RegisterType<ViewEngine>().As<IViewEngine>();

            // build
            var container = builder.Build();

            var game = container.Resolve<IGameEngine>();

            game.Run();
        }
    }
}
