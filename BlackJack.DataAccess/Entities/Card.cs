using BlackJack.DataAccess.Enums;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Card : BaseEntity
    {
        public CardRank Rank { get; set; }

        public Suit Suit { get; set; }
    }
}
