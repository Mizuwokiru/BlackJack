namespace BlackJack.DataAccess.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }

        public bool IsBot { get; set; }
    }
}
