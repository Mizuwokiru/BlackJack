using BlackJack.BusinessLogic.Models;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetOrCreateUser(string userName);
        UserModel GetUser(int userId);
    }
}
