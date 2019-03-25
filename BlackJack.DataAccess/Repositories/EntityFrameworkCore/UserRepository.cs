﻿using System.Data.Common;
using System.Linq;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public User GetUserByName(string userName)
        {
            return _dbContext.Set<User>().Where(user => user.Name == userName).FirstOrDefault();
        }
    }
}
