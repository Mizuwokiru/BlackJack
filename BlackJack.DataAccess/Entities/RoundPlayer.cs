using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayer : BaseEntity
    {
        public int RoundId { get; set; }
        public virtual Round Round { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        
        public bool IsWon { get; set; }

        public virtual ICollection<RoundPlayerCard> Cards { get; set; }
    }
}
