using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Game : BaseEntity
    {
        public ICollection<GamePlayer> GamePlayers { get; set; }

        public ICollection<Round> Rounds { get; set; }
    }
}
