using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class Round : BaseEntity
    {
        [Required]
        public virtual Game Game { get; set; }

        [Required]
        public int Number { get; set; }

        public virtual IEnumerable<RoundPlayer> Players { get; set; }
    }
}
