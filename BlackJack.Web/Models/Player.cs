namespace BlackJack.Web.Models
{
    public class Player : BaseModel
    {
        public string Name { get; set; }

        public bool IsBot { get; set; }
    }
}
