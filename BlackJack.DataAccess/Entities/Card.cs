using BlackJack.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class Card : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public Suit Suit { get; set; }

        [Required]
        public int Value { get; set; } // Как быть с тузом?
    }
}
