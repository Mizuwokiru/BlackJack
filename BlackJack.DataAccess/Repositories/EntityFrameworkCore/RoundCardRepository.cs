using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundCardRepository : BaseRepository<RoundCard>, IRoundCardRepository
    {
        public RoundCardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<IEnumerable<RoundCard>> GetCards(long roundId)
        {
            Task<List<RoundCard>> cards = _dbContext.RoundCards
                .Where(card => card.RoundId == roundId)
                .ToListAsync();
            return await cards;
        }

        public async Task<bool> HasCards(long roundId)
        {
            RoundCard roundCard = await _dbContext.RoundCards
                .FirstOrDefaultAsync(card => card.RoundId == roundId);
            return roundCard != null;
        }
    }
}
