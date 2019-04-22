using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.ViewModels.Models.Game
{
    public class RoundViewModel
    {
        public string PlayerName { get; set; }

        public PlayerType PlayerType { get; set; }

        public List<CardViewModel> Cards { get; set; }

        public RoundState State { get; set; }

        public int Score { get; set; }
    }
}