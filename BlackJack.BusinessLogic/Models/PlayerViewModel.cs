using System.ComponentModel.DataAnnotations;

namespace BlackJack.BusinessLogic.Models
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 6)]
        public string Name { get; set; }
    }
}
