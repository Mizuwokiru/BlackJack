using System;
using System.Collections.Generic;
using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using Dapper;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DbConnection dbConnection) : base(dbConnection)
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
