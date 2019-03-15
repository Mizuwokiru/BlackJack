﻿using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Game : BaseEntity
    {
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }

        public virtual ICollection<Round> Rounds { get; set; }
    }
}
