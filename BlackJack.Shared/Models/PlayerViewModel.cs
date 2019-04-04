using System.ComponentModel.DataAnnotations;

namespace BlackJack.Shared.Models
{
    public class PlayerViewModel
    {
        [RegularExpression(@"^\w+$", ErrorMessage = "Invalid characters")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "Too much characters")]
        public string Name { get; set; }
    }
}
