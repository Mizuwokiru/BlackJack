using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayer : BaseEntity
    {
        public Player Player { get; set; }

        public bool IsWon { get; set; }

        public ICollection<RoundPlayerCard> Cards { get; set; }
    }
}
