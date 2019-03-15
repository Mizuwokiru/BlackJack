using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayerCard : BaseEntity
    {
        [Required]
        public virtual RoundPlayer RoundPlayer { get; set; }

        [Required]
        public virtual Card Card { get; set; }
    }
}
