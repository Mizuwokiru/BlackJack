using System.Collections.Generic;

namespace BlackJack.DataAccess.Entities
{
    public class Player : IIdentifiable
    {
        public int Id { get; set; }

        public Round Round { get; set; }

        public User User { get; set; }

        public bool IsDealer { get; set; }

        public ICollection<GottenCard> GottenCards { get; set; }

        public decimal Bet { get; set; }

        public decimal Cash { get; set; }
    }
}
