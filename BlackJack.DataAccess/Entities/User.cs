using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.DataAccess.Entities
{
    public class User : IIdentifiable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Money { get; set; }

        public int PlayerForeignKey { get; set; }

        [ForeignKey("PlayerForeignKey")]
        public Player Player { get; set; }
    }
}
