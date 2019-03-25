using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.Web.Models
{
    public class GameViewModel
    {
        public int GameId { get; set; }

        public UserModel User { get; set; }

        public IEnumerable<BotModel> Bots { get; set; }

        public IEnumerable<RoundModel> Rounds { get; set; }
    }
}
