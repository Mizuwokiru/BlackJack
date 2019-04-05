using BlackJack.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IGameService
    {
        Task<bool> CanToContinueGame();
        Task ContinueGame();
        Task<List<GamePlayerInfoViewModel>> GetGameInfo();
        Task NewGame(int botCount);
    }
}
