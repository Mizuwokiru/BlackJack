﻿using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Step : BaseEntity
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public virtual ICollection<StepCard> Cards { get; set; }
    }
}
