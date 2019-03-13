namespace BlackJack.DataAccess.Entities
{
    public class RoundGamePlayer : BaseEntity
    {
        public Round Round { get; set; }

        public GamePlayer GamePlayer { get; set; }

        public bool IsWon { get; set; }
    }
}
