using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public override void Add(params Card[] items)
        {
            var now = DateTime.Now;
            _dbConnection.Execute($@"INSERT INTO Cards (CreationTime, Suit, Rank) VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', @Suit, @Rank)", items);
        }

        public override void Add(IEnumerable<Card> items)
        {
            var now = DateTime.Now;
            _dbConnection.Execute($@"INSERT INTO Cards (CreationTime, Suit, Rank) VALUES ('{now.ToString("yyyy-MM-dd HH:mm:ss.fffffff")}', @Suit, @Rank)", items);
        }

        public override void Delete(long id)
        {
            _dbConnection.Execute("DELETE FROM Cards WHERE Id = @Id", new { Id = id });
        }

        public override Card Get(long id)
        {
            Card card = _dbConnection.QuerySingle<Card>("SELECT * FROM Cards WHERE Id = @Id", new { Id = id });
            return card;
        }

        public override IEnumerable<Card> GetAll()
        {
            IEnumerable<Card> cards = _dbConnection.Query<Card>("SELECT * FROM Cards");
            return cards;
        }

        public override void Update(params Card[] items)
        {
            _dbConnection.Execute("UPDATE Cards SET Suit = @Suit, Rank = @Rank WHERE Id = @Id", items);
        }

        public override void Update(IEnumerable<Card> items)
        {
            _dbConnection.Execute("UPDATE Cards SET Suit = @Suit, Rank = @Rank WHERE Id = @Id", items);
        }

        public IEnumerable<Card> GetPlayerCards(long playerId, long gameId)
        {
            throw new NotImplementedException();
        }
    }
}
