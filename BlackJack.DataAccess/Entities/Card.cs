using BlackJack.DataAccess.Enums;

namespace BlackJack.DataAccess.Entities
{
    public class Card : BaseEntity
    {
        public string Name { get; set; }

        public Suit Suit { get; set; }
    }
}
