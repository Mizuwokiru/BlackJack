namespace BlackJack.DataAccess.Entities
{
    public class GamePlayer : BaseEntity
    {
        public Game Game { get; set; }

        public Player Player { get; set; }
    }
}
