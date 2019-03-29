namespace BlackJack.DataAccess.Entities
{
    public class StepCard : BaseEntity
    {
        public int RoundId { get; set; }
        public virtual Step Round { get; set; }

        public int CardId { get; set; }
        public virtual Card Card { get; set; }
    }
}
