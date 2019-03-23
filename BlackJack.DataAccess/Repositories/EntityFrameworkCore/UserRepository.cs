using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
