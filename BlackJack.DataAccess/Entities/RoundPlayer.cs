using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayer : BaseEntity
    {
        [Required]
        public virtual Round Round { get; set; }

        [Required]
        public virtual Player Player { get; set; }

        public bool IsWon { get; set; }

        public virtual ICollection<RoundPlayerCard> Cards { get; set; }
    }
}
