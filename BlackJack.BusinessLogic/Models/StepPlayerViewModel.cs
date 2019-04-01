using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Models
{
    public class StepPlayerViewModel
    {
        public int PlayerId { get; set; }

        public string PlayerName { get; set; }

        public List<CardViewModel> PlayerCards { get; set; }

        public StepState StepState { get; set; }
    }
}
