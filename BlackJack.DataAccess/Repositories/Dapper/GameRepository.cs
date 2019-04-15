using System;
using System.Collections.Generic;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(IOptions<DbSettingsOptions> options) : base(options)
        {
        }

        public int GetPlayerCount(long gameId)
        {
            throw new System.NotImplementedException();
        }

        public Game GetUnfinishedGame(long userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HistoryGameInfoModel> GetGamesHistory(long userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
