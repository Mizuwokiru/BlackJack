using System;
using System.Collections.Generic;
using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class RoundCardRepository : BaseRepository<RoundCard>, IRoundCardRepository
    {
        public RoundCardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public override void Add(params RoundCard[] items)
        {
            var now = DateTime.Now;
            _dbConnection.Execute($@"INSERT INTO RoundCards (CreationTime, RoundId, CardId) VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', @RoundId, @CardId)", items);
        }

        public override void Add(IEnumerable<RoundCard> items)
        {
            var now = DateTime.Now;
            _dbConnection.Execute($@"INSERT INTO RoundCards (CreationTime, RoundId, CardId) VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', @RoundId, @CardId)", items);
        }

        public override void Delete(long id)
        {
            _dbConnection.Execute("DELETE FROM RoundCards WHERE Id = @Id", new { Id = id });
        }

        public override RoundCard Get(long id)
        {
            RoundCard roundCard = _dbConnection.QuerySingle<RoundCard>("SELECT * FROM RoundCards WHERE Id = @Id", new { Id = id });
            return roundCard;
        }

        public override IEnumerable<RoundCard> GetAll()
        {
            IEnumerable<RoundCard> roundCards = _dbConnection.Query<RoundCard>("SELECT * FROM RoundCards");
            return roundCards;
        }

        public override void Update(params RoundCard[] items)
        {
            _dbConnection.Execute("UPDATE RoundCards SET RoundId = @RoundId, CardId = @CardId WHERE Id = @Id", items);
        }

        public override void Update(IEnumerable<RoundCard> items)
        {
            _dbConnection.Execute("UPDATE RoundCards SET RoundId = @RoundId, CardId = @CardId WHERE Id = @Id", items);
        }
    }
}
