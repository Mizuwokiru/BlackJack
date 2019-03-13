using BlackJack.DataAccess.Enums;

namespace BlackJack.DataAccess.Entities
{
    public class Card : IIdentifiable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Suit Suit { get; set; }
    }
}
