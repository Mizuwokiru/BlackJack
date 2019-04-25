using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.ResponseModels;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        IEnumerable<Card> GetPlayerCards(long playerId, long gameId);

        void GetRoundCards(IEnumerable<RoundInfoModel> roundInfoModels);
    }
}
