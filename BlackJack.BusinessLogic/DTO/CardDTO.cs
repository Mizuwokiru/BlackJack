using BlackJack.Commons.Enums;

namespace BlackJack.BusinessLogic.DTO
{
    public class CardDTO : BaseDTO
    {
        public Suit Suit { get; set; }

        public CardRank Rank { get; set; }
    }
}
