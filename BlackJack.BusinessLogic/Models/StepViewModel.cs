using BlackJack.Shared.Enums;

namespace BlackJack.BusinessLogic.Models
{
    public class StepViewModel
    {
        CardViewModel Card { get; set; }

        RoundState RoundState { get; set; }
    }
}
