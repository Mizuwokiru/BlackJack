﻿using System.Data.Common;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;

namespace BlackJack.DataAccess.Repositories.EntityFrameworkCore
{
    public class RoundPlayerUserRepository : BaseRepository<RoundPlayerUser>, IRoundPlayerUserRepository
    {
        public RoundPlayerUserRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
