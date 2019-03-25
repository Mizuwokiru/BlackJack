using BlackJack.BusinessLogic.Models;

namespace BlackJack.Web.Models
{
    public class GameCreateViewModel
    {
        public UserModel User { get; set; }

        public int BotCount { get; set; }
    }
}
