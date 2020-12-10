using Domain.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class GameService : IGameService
    {
        private ICardService _cardService;

        private Stack<Card> _deck { get; set; }
        private List<Player> _players { get; set; }
        private Player _dealer { get; set; }
        private int _currentPlayer { get; set; }

        public GameService(ICardService cardService)
        {
            _cardService = cardService;

            _dealer = new Player()
            {
                Name = "Dealer",
                Hand = new List<Card>()
            };

            _currentPlayer = 0;
        }

        public void LoadPlayers(List<Player> players)
        {
            if (!players.Any())
            {
                throw new Exception("Must enter at least one player");
            }

            _players = players;
        }

        public void BeginRound()
        {
            if (!_players.Any())
            {
                throw new Exception("Must load at least one player to begin.");
            }

            // TODO: make this not make a new deck every round
            _deck = _cardService.GetDeck();

            _dealer.Hand.Clear();
            _currentPlayer = 0;

            // TODO: move this out to it's own method
            foreach (var player in _players)
            {
                player.Hand = new List<Card>();
                player.Hand.Add(_deck.Pop());
                player.Hand.Add(_deck.Pop());
            }
        }

        public List<Card> GetCurrentPlayerHand()
        {
            return GetCurrentPlayer().Hand;
        }

        public string GetCurrentPlayerName()
        {
            return GetCurrentPlayer().Name;
        }

        public bool Hit()
        {
            // add card to current players hand
            _players[_currentPlayer]
                .Hand
                .Add(_deck.Pop());

            var handValue = 
                _cardService.GetValueOfHand(GetCurrentPlayerHand());

            if (handValue < 21)
            {
                return true;
            }

            MoveToNextPlayer();

            return false;
        }

        public bool Stand()
        {
            // need to handle if there are no more players
            MoveToNextPlayer();
            return true;
        }

        private Player GetCurrentPlayer()
        {
            return _players[_currentPlayer];
        }

        private void MoveToNextPlayer()
        {
            _currentPlayer++;
        }
    }
}
