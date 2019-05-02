using BlackJack.ViewModels.Login;
using System.Threading.Tasks;

namespace BlackJack.Services.Services.Interfaces
{
    public interface IAuthenticationService
    {
        UserNamesViewModel GetUserNames();
        Task Login(string userName);
        Task Logout();
    }
}
