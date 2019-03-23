using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.DataAccess.Entities
{
    public class User : BaseEntity
    {
        [Required, MaxLength(32)]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
