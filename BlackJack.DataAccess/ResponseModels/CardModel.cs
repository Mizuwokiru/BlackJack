using BlackJack.Shared.Enums;

namespace BlackJack.DataAccess.ResponseModels
{
    public class CardModel
    {
        public long Id { get; set; }

        public Suit Suit { get; set; }

        public Rank Rank { get; set; }
    }
}
