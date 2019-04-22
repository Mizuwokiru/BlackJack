using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.ViewModels.Models.Game
{
    public class PlayerStateViewModel
    {
        public string PlayerName { get; set; }

        public List<CardViewModel> Cards { get; set; }

        public RoundState State { get; set; }

        public int Score { get; set; }
    }
}