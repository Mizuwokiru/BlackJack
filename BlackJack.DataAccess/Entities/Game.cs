using BlackJack.Shared.Enums;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Game : BaseEntity
    {
        public GameState State { get; set; }

        public virtual ICollection<GamePlayer> Players { get; set; }

        public virtual ICollection<Step> Rounds { get; set; }
    }
}
