using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.Web.Models
{
    public class GameViewModel
    {
        public int GameId { get; set; }

        public List<PlayerViewModel> Players { get; set; }
    }
}
