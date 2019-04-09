using BlackJack.Shared;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Models
{
    public class GameMenuVIewModel
    {
        public bool HasUnfinishedGame { get; set; }

        [Range(0, BlackJackConstants.MaxBotCount)]
        public int BotCount { get; set; }
    }
}
