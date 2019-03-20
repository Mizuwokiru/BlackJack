using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Game : BaseEntity
    {
        public virtual IEnumerable<GamePlayer> GamePlayers { get; set; }

        public virtual IEnumerable<Round> Rounds { get; set; }
    }
}
