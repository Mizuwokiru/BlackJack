using Microsoft.AspNetCore.Identity;

namespace BlackJack.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public long PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }
}
