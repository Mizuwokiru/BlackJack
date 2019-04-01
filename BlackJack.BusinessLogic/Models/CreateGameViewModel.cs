using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Models
{
    public class CreateGameViewModel
    {
        public int GameId { get; set; }

        public List<PlayerViewModel> Players { get; set; }
    }
}
