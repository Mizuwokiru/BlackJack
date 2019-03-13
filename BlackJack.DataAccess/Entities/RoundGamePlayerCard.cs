namespace BlackJack.DataAccess.Entities
{
    public class RoundGamePlayerCard : BaseEntity
    {
        public RoundGamePlayer RoundGamePlayer { get; set; }

        public Card Card { get; set; }
    }
}
