using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Game : BaseEntity
    {
        public virtual IEnumerable<GamePlayer> Players { get; set; }

        public virtual IEnumerable<Round> Rounds { get; set; }
    }
}
