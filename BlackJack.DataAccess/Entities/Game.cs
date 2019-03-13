using System;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Game : IIdentifiable
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ICollection<Round> Rounds { get; set; }
    }
}
