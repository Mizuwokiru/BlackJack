using BlackJack.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<string>> GetUsers();
        Task<UserViewModel> LoginUser(string name);
    }
}
