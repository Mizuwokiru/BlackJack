using BlackJack.Shared;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Web.Models
{
    public class GameCreateViewModel
    {
        public int PlayerId { get; set; }

        [Range(0, Constants.MaxBotCount)]
        public int BotCount { get; set; }
    }
}
