using BlackJack.Shared.Enums;

namespace BlackJack.DataAccess.Entities
{
    public class Card : BaseEntity
    {
        public Suit Suit { get; set; }

        public Rank Rank { get; set; }
    }
}
