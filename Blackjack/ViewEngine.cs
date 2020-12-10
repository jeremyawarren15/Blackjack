﻿using Blackjack.Contracts;
using Domain.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public class ViewEngine : IViewEngine
    {
        private ICardService _cardService;

        public ViewEngine(ICardService cardService)
        {
            _cardService = cardService;
        }

        public List<Player> CreatePlayers()
        {
            var players = new List<Player>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Player {players.Count + 1} name: ");
                var name = Console.ReadLine();

                var player = new Player()
                {
                    Cash = 500,
                    Name = name,
                    Hand = new List<Card>()
                };

                players.Add(player);

                Console.Clear();
                Console.WriteLine("Do you have more players? ");
                var shouldContinue = Console.ReadLine() == "yes";

                if (!shouldContinue)
                {
                    break;
                }
            }

            return players;
        }

        // true if hit. false if stand
        public bool Move(string currentPlayerName, List<Card> hand)
        {
            Console.Clear();
            Console.WriteLine($"CurrentPlayer: {currentPlayerName}");

            foreach (var card in hand)
            {
                Console.WriteLine(_cardService.GetFullNameOfCard(card));
            }

            Console.Write("(h)it or (s)tand? ");

            var move = Console.ReadKey().Key;

            switch (move)
            {
                case ConsoleKey.H:
                    return true;
                case ConsoleKey.S:
                    return false;
                default:
                    // need to loop to re-ask for response
                    return false;
            }
        }
    }
}