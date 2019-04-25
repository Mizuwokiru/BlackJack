using BlackJack.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Game
{
    public class MenuGameViewModel
    {
        public MenuMenuGameViewModel Menu { get; set; }

        public NewMenuGameViewModel NewGame { get; set; }
    }

    public class MenuMenuGameViewModel
    {
        public bool HasUnfinishedGame { get; set; }

        public int MaxBotCount { get; set; }
    }

    public class NewMenuGameViewModel
    {
        [Range(0, Constants.MaxBotCount)]
        public int BotCount { get; set; }
    }
}
