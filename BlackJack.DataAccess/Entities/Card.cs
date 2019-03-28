using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Card : BaseEntity
    {
        public Suit Suit { get; set; }

        public Rank Rank { get; set; }

        //public virtual ICollection<RoundPlayerCard> RoundPlayerCards { get; set; }
    }
}
