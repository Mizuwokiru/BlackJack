using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Card>> GetCards(long roundId)
        {
            Task<List<Card>> cards = _dbContext.RoundCards
                .Where(roundCard => roundCard.RoundId == roundId)
                .Select(roundCard => roundCard.Card)
                .ToListAsync();
            return await cards;
        }
    }
}
