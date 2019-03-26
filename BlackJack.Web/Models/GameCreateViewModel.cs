using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.Web.Models
{
    public class GameCreateViewModel
    {
        public int GameId { get; set; }

        public List<PlayerModel> Players { get; set; }
    }
}
