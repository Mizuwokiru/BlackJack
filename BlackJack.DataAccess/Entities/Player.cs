using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class Player : BaseEntity
    {
        [Required, MaxLength(32)]
        public string Name { get; set; }

        public bool IsPlayable { get; set; }

        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
    }
}
