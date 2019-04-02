using BlackJack.DataAccess;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Data.SqlClient;

namespace BlackJack.Services.Configuration
{
    public static class DbAccessConfig
    {
        public static void AddBlackJackDbAccess(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<DbConnection>(provider => new SqlConnection(config.GetConnectionString("DefaultConnection")));

            if (config["ORM"] == "EntityFrameworkCore")
            {
                services.AddDbContext<GameDbContext>();

                services.AddTransient<ICardRepository, DataAccess.Repositories.EntityFrameworkCore.CardRepository>();
                services.AddTransient<IPlayerRepository, DataAccess.Repositories.EntityFrameworkCore.PlayerRepository>();
                services.AddTransient<IGameRepository, DataAccess.Repositories.EntityFrameworkCore.GameRepository>();
                services.AddTransient<IRoundRepository, DataAccess.Repositories.EntityFrameworkCore.RoundRepository>();
                services.AddTransient<IRoundCardRepository, DataAccess.Repositories.EntityFrameworkCore.RoundCardRepository>();
            }

            if (config["ORM"] == "Dapper")
            {

            }
        }
    }
}
