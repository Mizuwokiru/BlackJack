using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Login
{
    public class UserViewModel
    {
        [RegularExpression(@"^\w+$", ErrorMessage = "Name has invalid characters")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "Name has too much characters")]
        public string Name { get; set; }

        public string Token { get; set; }
    }
}
