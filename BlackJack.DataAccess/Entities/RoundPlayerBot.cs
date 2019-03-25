namespace BlackJack.DataAccess.Entities
{
    public class RoundPlayerBot : RoundPlayer
    {
        public virtual Bot Bot { get; set; }
    }
}
