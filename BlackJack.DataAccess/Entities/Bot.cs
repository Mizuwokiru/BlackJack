using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class Bot : BaseEntity
    {
        [Required, MaxLength(32)]
        public string Name { get; set; }
    }
}
