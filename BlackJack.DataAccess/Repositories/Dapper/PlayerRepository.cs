using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(IOptions<DbSettingsOptions> options) : base(options)
        {
        }

        public IEnumerable<string> GetUsers()
        {
            string sqlQuery =
                @"SELECT [Name] FROM [Players]
                  WHERE [Type] = @Type";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<string> userNames = connection.Query<string>(sqlQuery, new { Type = (int)PlayerType.User });
                return userNames;
            }
        }

        public Player GetUser(string name)
        {
            string sqlQuery =
                @"SELECT * FROM [Players]
                  WHERE [Name] = @Name";
            using (var connection = new SqlConnection(_connectionString))
            {
                Player player = connection.QuerySingleOrDefault<Player>(sqlQuery, new { Name = name });
                return player;
            }
        }

        public int GetBotCount()
        {
            string sqlQuery =
                @"SELECT COUNT(*) FROM [Players]
                  WHERE [Type] = @Type";
            using (var connection = new SqlConnection(_connectionString))
            {
                int botCount = connection.QuerySingle<int>(sqlQuery, new { Type = (int)PlayerType.Bot });
                return botCount;
            }
        }

        public IEnumerable<Player> GetBots(int count)
        {
            string sqlQuery =
                @"SELECT * FROM [Players]
                  WHERE [Type] = @Type";
            using (var connection = new SqlConnection(_connectionString))
            {
                IEnumerable<Player> players = connection.Query<Player>(sqlQuery, new { Type = (int)PlayerType.Bot });
                return players;
            }
        }
    }
}
