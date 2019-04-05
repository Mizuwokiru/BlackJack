using System.ComponentModel.DataAnnotations;

namespace BlackJack.Shared.Models
{
    public class MenuViewModel
    {
        public bool CanToContinueGame { get; set; }

        [Range(0, BlackJackConstants.MaxBotCount)]
        public int BotCount { get; set; }
    }
}
