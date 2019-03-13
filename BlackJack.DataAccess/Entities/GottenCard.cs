namespace BlackJack.DataAccess.Entities
{
    public class GottenCard : IIdentifiable
    {
        public int Id { get; set; }

        public Card Card { get; set; }

        public Player Player { get; set; }
    }
}
