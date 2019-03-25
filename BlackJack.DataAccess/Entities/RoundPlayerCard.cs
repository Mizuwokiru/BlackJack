using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayerCard : BaseEntity
    {
        public virtual RoundPlayer RoundPlayer { get; set; }

        public virtual Card Card { get; set; }
    }
}
