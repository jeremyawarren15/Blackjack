using Domain.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public class ViewEngine
    {
        private ICardService _cardService;

        public ViewEngine(ICardService cardService)
        {
            _cardService = cardService;
        }

        // true if hit. false if stand
        public bool MoveView(string currentPlayerName, List<Card> hand)
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
