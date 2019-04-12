using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Models
{
    public class UserViewModel
    {
        [RegularExpression(@"^\w+$", ErrorMessage = "Invalid characters")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "Too much characters")]
        public string Name { get; set; }

        public string Token { get; set; }
    }
}
