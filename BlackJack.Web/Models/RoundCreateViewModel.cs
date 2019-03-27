using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.Web.Models
{
    public class RoundCreateViewModel
    {
        public int RoundId { get; set; }

        // TODO: List of RoundPlayer

        public List<CardViewModel> Cards { get; set; } // or List of RoundPlayerCard?
    }
}
