namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayerCard : BaseEntity
    {
        public long RoundPlayerId { get; set; }
        public virtual RoundPlayer RoundPlayer { get; set; }

        public long CardId { get; set; }
        public virtual Card Card { get; set; }
    }
}
