using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayerCard : BaseEntity
    {
        public int RoundPlayerId { get; set; }
        public virtual RoundPlayer RoundPlayer { get; set; }

        public int CardId { get; set; }
        public virtual Card Card { get; set; }
    }
}
