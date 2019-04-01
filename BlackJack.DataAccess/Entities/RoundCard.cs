namespace BlackJack.DataAccess.Entities
{
    public class RoundCard : BaseEntity
    {
        public int RoundId { get; set; }
        public virtual Round Round { get; set; }

        public int CardId { get; set; }
        public virtual Card Card { get; set; }
    }
}
