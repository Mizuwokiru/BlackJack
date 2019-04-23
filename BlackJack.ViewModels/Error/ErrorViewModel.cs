using System.Net;

namespace BlackJack.ViewModels.Error
{
    public class ErrorViewModel
    {
        public HttpStatusCode StatusCode { get; set; }

        public string StatusText { get; set; }
    }
}
