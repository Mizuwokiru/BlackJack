using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class Round : BaseEntity
    {
        public virtual Game Game { get; set; }

        [Required]
        public int Number { get; set; }

        public bool IsFinished { get; set; }

        public virtual ICollection<RoundPlayer> Players { get; set; }
    }
}
