﻿using Domain.Models;
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

            _deck = new Stack<Card>();
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

            AddCardsToDeckIfNeeded();

            Deal();
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
            DealToPlayer(GetCurrentPlayer());

            var handValue = 
                _cardService.GetValueOfHand(GetCurrentPlayerHand());

            if (handValue < 21)
            {
                // return true if can repeat
                return true;
            }

            MoveToNextPlayer();

            // return false if busted
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

        private void Deal()
        {
            _currentPlayer = 0;

            foreach (var player in _players)
            {
                player.Hand = new List<Card>();
            }

            _dealer.Hand.Clear();

            for (int i = 0; i < 2; i++)
            {
                foreach (var player in _players)
                {
                    DealToPlayer(player);
                }

                DealToDealer();
            }
        }

        private void DealToDealer()
        {
            _dealer.Hand.Add(_deck.Pop());
            AddCardsToDeckIfNeeded();
        }

        private void DealToPlayer(Player player)
        {
            player.Hand.Add(_deck.Pop());
            AddCardsToDeckIfNeeded();
        }

        private void AddCardsToDeckIfNeeded()
        {
            // if the deck falls below 1 deck
            if (_deck.Count < 52)
            {
                // generate 3 more
                var nextDeck = _cardService.GetDeck(3);
                foreach (var card in nextDeck)
                {
                    // and append them to the deck
                    _deck.Push(card);
                }
            }
        }
    }
}
