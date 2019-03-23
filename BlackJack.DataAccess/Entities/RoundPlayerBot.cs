namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayerBot : RoundPlayer
    {
        public int BotId { get; set; }
        public virtual Bot Bot { get; set; }
    }
}
