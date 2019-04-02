using BlackJack.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class Player : BaseEntity
    {
        [Required, MaxLength(32)]
        public string Name { get; set; }

        public PlayerType Type { get; set; }
    }
}
