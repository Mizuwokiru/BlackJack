using BlackJack.Commons.Enums;

namespace BlackJack.Web.Models
{
    public class Card : BaseModel
    {
        public CardRank Rank { get; set; }

        public Suit Suit { get; set; }
    }
}
