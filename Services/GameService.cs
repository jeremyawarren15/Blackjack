using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class GameService
    {
        private DeckService deckService = new DeckService();
        private List<Player> Players = new List<Player>();
        private int CurrentMove = 0;

        public bool StartNewGame()
        {
            if (!Players.Any())
            {
                return false;
            }

            deckService.GenerateDeck();
            
            CurrentMove = 0;

            return true;
        }

        public bool StartNewGame(IEnumerable<Player> players)
        {
            if (!players.Any())
            {
                if (!Players.Any())
                {
                    return false;
                }

                return StartNewGame();
            }

            Players = players.ToList();

            return StartNewGame();
        }

        private Player NextPlayer()
        {
            CurrentMove++;

            return Players[CurrentMove % Players.Count];
        }
    }
}
