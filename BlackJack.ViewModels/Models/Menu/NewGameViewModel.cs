using BlackJack.Shared;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Models.Menu
{
    public class NewGameViewModel
    {
        [Range(0, BlackJackConstants.MaxBotCount)]
        public int BotCount { get; set; }
    }
}
