using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<string> GetUsers();
        Task<ClaimsIdentity> LoginUser(string name);
    }
}
