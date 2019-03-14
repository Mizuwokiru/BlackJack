using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class CardRepository : AbstractRepository<Card>
    {
        public CardRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
