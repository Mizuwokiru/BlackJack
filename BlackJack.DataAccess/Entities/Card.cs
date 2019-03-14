using BlackJack.DataAccess.Enums;

namespace BlackJack.DataAccess.Entities
{
    public class Card : BaseEntity
    {
        public CardRank Rank { get; set; }

        public Suit Suit { get; set; }
    }
}
