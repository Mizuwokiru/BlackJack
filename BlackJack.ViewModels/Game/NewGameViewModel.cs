using BlackJack.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Game
{
    public class NewGameViewModel
    {
        [Range(0, Constants.MaxBotCount)]
        public int BotCount { get; set; }
    }
}
