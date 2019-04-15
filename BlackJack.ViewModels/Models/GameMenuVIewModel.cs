using BlackJack.Shared;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Models
{
    public class GameMenuViewModel
    {
        public bool HasUnfinishedGame { get; set; }

        public int MaxBotCount { get; set; }

        [Range(0, BlackJackConstants.MaxBotCount)]
        public int BotCount { get; set; }
    }
}
