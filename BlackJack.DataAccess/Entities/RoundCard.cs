namespace BlackJack.DataAccess.Entities
{
    public class RoundCard : BaseEntity
    {
        public long RoundId { get; set; }
        public virtual Round Round { get; set; }

        public long CardId { get; set; }
        public virtual Card Card { get; set; }
    }
}
