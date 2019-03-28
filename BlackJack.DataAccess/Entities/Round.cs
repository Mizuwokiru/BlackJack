using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Round : BaseEntity
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public int Number { get; set; }

        public bool IsFinished { get; set; }

        public virtual ICollection<RoundPlayer> Players { get; set; }
    }
}
