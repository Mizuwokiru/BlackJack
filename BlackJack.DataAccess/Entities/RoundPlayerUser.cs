namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayerUser : RoundPlayer
    {
        public virtual User User { get; set; }
    }
}
