using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Game : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        //public virtual ICollection<GameBot> Bots { get; set; }

        public virtual ICollection<Round> Rounds { get; set; }
    }
}
