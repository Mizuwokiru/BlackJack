namespace BlackJack.Shared.Options
{
    public class JwtSettingsOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string TokenSecret { get; set; }

        public int Lifetime { get; set; }
    }
}
