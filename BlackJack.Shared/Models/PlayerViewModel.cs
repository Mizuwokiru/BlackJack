using System.ComponentModel.DataAnnotations;

namespace BlackJack.Shared.Models
{
    public class PlayerViewModel
    {
        public long PlayerId { get; set; }

        [RegularExpression(@"^\w+$")]
        [StringLength(32, MinimumLength = 2)]
        public string PlayerName { get; set; }
    }
}
