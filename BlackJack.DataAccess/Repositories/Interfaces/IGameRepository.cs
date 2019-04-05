using BlackJack.DataAccess.Entities;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<bool> CanToContinueGame(long userId);
        Task<Game> GetUnfinishedGame(long userId);
    }
}
