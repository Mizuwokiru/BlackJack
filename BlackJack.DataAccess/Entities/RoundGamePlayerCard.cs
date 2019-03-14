namespace BlackJack.DataAccess.Entities
{
    public class RoundGamePlayerCard : BaseEntity
    {
        public Round Round { get; set; }

        public GamePlayer GamePlayer { get; set; }

        public Card Card { get; set; }
    }
}
