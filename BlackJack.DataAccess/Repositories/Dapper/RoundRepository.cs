using System;
using System.Collections.Generic;
using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class RoundRepository : BaseRepository<Round>, IRoundRepository
    {
        public RoundRepository(IOptions<DbSettingsOptions> options) : base(options)
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

        public IEnumerable<RoundState> GetRoundStates(long userId, int gameSkipCount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoundInfoModel> GetRoundInfo(long userId, int gameSkipCount, int roundSkipCount)
        {
            throw new NotImplementedException();
        }
    }
}
