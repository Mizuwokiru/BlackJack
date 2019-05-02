using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayer : BaseEntity
    {
        public long GameId { get; set; }
        public virtual Game Game { get; set; }

        public long PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public RoundPlayerState State { get; set; }

        public virtual ICollection<RoundPlayerCard> Cards { get; set; }
    }
}
