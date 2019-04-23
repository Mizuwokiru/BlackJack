using System.Collections.Generic;

namespace BlackJack.ViewModels.Error
{
    public class ValidationErrorViewModel
    {
        public string Property { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
