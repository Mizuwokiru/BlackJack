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

        public override void Add(params Round[] items)
        {
            var now = DateTime.Now;
            _dbConnection.Execute($@"INSERT INTO Rounds (CreationTime, GameId, PlayerId, State) VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', @GameId, @PlayerId, @State)", items);
        }

        public override void Add(IEnumerable<Round> items)
        {
            var now = DateTime.Now;
            _dbConnection.Execute($@"INSERT INTO Rounds (CreationTime, GameId, PlayerId, State) VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', @GameId, @PlayerId, @State)", items);
        }

        public override void Delete(long id)
        {
            _dbConnection.Execute("DELETE FROM Rounds WHERE Id = @Id", new { Id = id });
        }

        public override Round Get(long id)
        {
            Round round = _dbConnection.QuerySingle<Round>("SELECT * FROM Rounds WHERE Id = @Id", new { Id = id });
            return round;
        }

        public override IEnumerable<Round> GetAll()
        {
            IEnumerable<Round> rounds = _dbConnection.Query<Round>("SELECT * FROM Rounds");
            return rounds;
        }

        public override void Update(params Round[] items)
        {
            _dbConnection.Execute("UPDATE Rounds SET GameId = @GameId, PlayerId = @PlayerId, State = @State WHERE Id = @Id", items);
        }

        public override void Update(IEnumerable<Round> items)
        {
            _dbConnection.Execute("UPDATE Rounds SET GameId = @GameId, PlayerId = @PlayerId, State = @State WHERE Id = @Id", items);
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
    }
}
