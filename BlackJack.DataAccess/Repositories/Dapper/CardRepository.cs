using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(IOptions<DbSettingsOptions> options) : base(options)
        {
        }

        public IEnumerable<Card> GetPlayerCards(long playerId, long gameId)
        {
            throw new NotImplementedException();
        }
    }
}
