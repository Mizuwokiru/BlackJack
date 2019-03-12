using System;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Game
    {
        /// <summary>
        /// Game identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Game start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Game end time.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Player list.
        /// </summary>
        public List<Player> Players { get; set; }

        /// <summary>
        /// Game winner.
        /// </summary>
        public Player Winner { get; set; }

        /// <summary>
        /// Game loser.
        /// </summary>
        public Player Loser { get; set; }

        /// <summary>
        /// Game rounds.
        /// </summary>
        public ICollection<Round> Rounds { get; set; }
    }
}
