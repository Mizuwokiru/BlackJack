namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayerUser : RoundPlayer
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
