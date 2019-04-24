﻿using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Shared.Options;
using Microsoft.Extensions.Options;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class RoundCardRepository : BaseRepository<RoundCard>, IRoundCardRepository
    {
        public RoundCardRepository(IOptions<DbSettingsOptions> options) : base(options)
        {
        }
    }
}
