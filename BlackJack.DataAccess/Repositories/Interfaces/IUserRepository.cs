using BlackJack.DataAccess.Entities;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByName(string userName);
    }
}
