using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.DataAccess.Repositories
{
    public class CardRepository : BaseRepository<Card>
    {
        public CardRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
