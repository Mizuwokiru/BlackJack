using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Data.Common;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
