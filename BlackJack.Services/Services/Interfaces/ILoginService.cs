using BlackJack.ViewModels.Login;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlackJack.Services.Services.Interfaces
{
    public interface ILoginService
    {
        UserNamesViewModel GetUsers();
        Task<ClaimsIdentity> Login(UserViewModel userViewModel);
    }
}
