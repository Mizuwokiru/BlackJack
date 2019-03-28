namespace BlackJack.DataAccess.Entities
{
    public class GamePlayer : BaseEntity
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
