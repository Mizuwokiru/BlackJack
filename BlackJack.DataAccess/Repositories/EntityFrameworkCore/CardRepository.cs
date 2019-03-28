using System.Collections.Generic;
using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        private IEnumerable<Card> _cards;

        public CardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<Card> Cards
        {
            get
            {
                if (_cards == null)
                    _cards = GetAll();
                return _cards;
            }
        }
    }
}
