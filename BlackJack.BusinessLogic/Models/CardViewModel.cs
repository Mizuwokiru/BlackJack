using BlackJack.Shared.Enums;

namespace BlackJack.BusinessLogic.Models
{
    public class CardViewModel : BaseModel
    {
        public Suit Suit { get; set; }

        public Rank Rank { get; set; }
    }
}
