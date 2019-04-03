namespace BlackJack.Shared.Models
{
    public class GetCardViewModel
    {
        public CardViewModel Card { get; set; }

        public bool CanToTakeMore { get; set; }
    }
}
