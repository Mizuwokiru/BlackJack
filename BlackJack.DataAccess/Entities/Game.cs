using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Game : BaseEntity
    {
        public bool IsFinished { get; set; }

        public virtual ICollection<RoundPlayer> RoundPlayers { get; set; }
    }
}
