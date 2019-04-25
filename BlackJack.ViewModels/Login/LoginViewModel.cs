using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Login
{
    public class LoginViewModel
    {
        public IEnumerable<string> UserNames { get; set; }

        [RegularExpression(@"^\w+$", ErrorMessage = "Name has invalid characters")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "Name has too much characters")]
        public string Name { get; set; }
    }
}
