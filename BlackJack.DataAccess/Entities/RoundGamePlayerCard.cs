namespace BlackJack.DataAccess.Entities
{
    public class RoundGamePlayerCard : BaseEntity
    {
        public Round Round { get; set; }

        public Player Player { get; set; }

        public Card Card { get; set; }
    }
}
