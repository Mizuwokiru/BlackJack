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

        public override void Add(params Game[] items)
        {
            var now = DateTime.Now;
            _dbConnection.Execute($@"INSERT INTO Games (CreationTime, IsFinished) VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', @IsFinished)", items);
        }

        public override void Add(IEnumerable<Game> items)
        {
            var now = DateTime.Now;
            _dbConnection.Execute($@"INSERT INTO Games (CreationTime, IsFinished) VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', @IsFinished)", items);
        }

        public override void Delete(long id)
        {
            _dbConnection.Execute("DELETE FROM Games WHERE Id = @Id", new { Id = id });
        }

        public override Game Get(long id)
        {
            Game game = _dbConnection.QuerySingle<Game>("SELECT * FROM Games WHERE Id = @Id", new { Id = id });
            return game;
        }

        public override IEnumerable<Game> GetAll()
        {
            IEnumerable<Game> games = _dbConnection.Query<Game>("SELECT * FROM Games");
            return games;
        }

        public override void Update(params Game[] items)
        {
            _dbConnection.Execute("UPDATE Games SET IsFinished = @IsFinished WHERE Id = @Id", items);
        }

        public override void Update(IEnumerable<Game> items)
        {
            _dbConnection.Execute("UPDATE Games SET IsFinished = @IsFinished WHERE Id = @Id", items);
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
