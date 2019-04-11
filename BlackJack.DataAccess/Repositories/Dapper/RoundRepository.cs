using System;
using System.Collections.Generic;
using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using Dapper;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public IEnumerable<RoundInfoModel> GetLastRoundsInfo(long gameId)
        {
            throw new System.NotImplementedException();
        }

        public StepInfoModel GetStepInfo(long userId, long gameId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLastRoundInfo(IEnumerable<RoundInfoModel> roundInfoModels)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HistoryRoundsInfoModel> GetHistoryRoundsInfo(long userId, int skipCount)
        {
            throw new NotImplementedException();
        }
    }
}
