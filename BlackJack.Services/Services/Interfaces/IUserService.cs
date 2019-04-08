using BlackJack.ViewModels.Models;
using System.Collections.Generic;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<string> GetUsers();
        UserViewModel LoginUser(string name);
    }
}
