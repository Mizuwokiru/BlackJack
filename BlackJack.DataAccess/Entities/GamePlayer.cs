using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class GamePlayer : BaseEntity
    {
        [Required]
        public virtual Game Game { get; set; }

        [Required]
        public virtual Player Player { get; set; }
    }
}
