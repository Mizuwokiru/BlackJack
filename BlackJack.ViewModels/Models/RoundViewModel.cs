using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.ViewModels.Models
{
    public class RoundViewModel
    {
        public PlayerViewModel Player { get; set; }

        public List<CardViewModel> Cards { get; set; }

        public RoundState State { get; set; }
    }
}
