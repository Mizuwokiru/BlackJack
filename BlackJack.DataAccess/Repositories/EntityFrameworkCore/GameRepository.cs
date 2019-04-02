using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public void FinishAllGames(long userId)
        {
            IEnumerable<Game> unfinishedGames = GetUnfinishedGames(userId);
            foreach (var unfinishedGame in unfinishedGames)
            {
                unfinishedGame.IsFinished = true;
            }
            Update(unfinishedGames);
        }

        public Game GetUnfinishedGame(long userId)
        {
            Game unfinishedGame = GetUnfinishedGames(userId).FirstOrDefault();
            return unfinishedGame;
        }

        public bool HasUnfinishedGames(long userId)
        {
            int unfinishedGamesCount = GetUnfinishedGames(userId).Count();
            return unfinishedGamesCount > 0;
        }

        private IEnumerable<Game> GetUnfinishedGames(long userId)
        {
            IEnumerable<Game> unfinishedGames = _dbContext.Rounds
                .Where(round => round.PlayerId == userId)
                .Select(round => round.Game)
                .Where(game => !game.IsFinished);
            return unfinishedGames;
        }
    }
}
