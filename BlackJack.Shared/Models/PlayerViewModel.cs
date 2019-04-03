using System.ComponentModel.DataAnnotations;

namespace BlackJack.Shared.Models
{
    public class PlayerViewModel
    {
        public long PlayerId { get; set; }

        [RegularExpression(@"^\w+$", ErrorMessage = "Invalid characters")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "Too much characters")]
        public string PlayerName { get; set; }
    }
}
