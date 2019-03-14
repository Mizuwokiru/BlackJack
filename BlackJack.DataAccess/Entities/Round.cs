using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class Round : BaseEntity
    {
        public Game Game { get; set; }

        [Required]
        public int Number { get; set; }

        public ICollection<RoundGamePlayerCard> RoundGamePlayerCards { get; set; }
    }
}
