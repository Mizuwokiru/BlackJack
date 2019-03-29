using BlackJack.DataAccess;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Data.SqlClient;

namespace BlackJack.BusinessLogic.Configuration
{
    public static class DbAccessConfig
    {
        public static void AddDbAcсess(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<DbConnection>(provider => new SqlConnection(config.GetConnectionString("DefaultConnection")));

            // EF BEGIN
            if (config["ORM"] == "EntityFrameworkCore")
            {
                services.AddDbContext<GameDbContext>();

                services.AddTransient<ICardRepository, DataAccess.Repositories.EntityFrameworkCore.CardRepository>();
                services.AddTransient<IPlayerRepository, DataAccess.Repositories.EntityFrameworkCore.PlayerRepository>();
                services.AddTransient<IGamePlayerRepository, DataAccess.Repositories.EntityFrameworkCore.GamePlayerRepository>();
                services.AddTransient<IGameRepository, DataAccess.Repositories.EntityFrameworkCore.GameRepository>();
                services.AddTransient<IStepRepository, DataAccess.Repositories.EntityFrameworkCore.StepRepository>();
                services.AddTransient<IStepCardRepository, DataAccess.Repositories.EntityFrameworkCore.StepCardRepository>();
            }
            // EF END

            // Dapper BEGIN
            if (config["ORM"] == "Dapper")
            {
                // TODO
            }
            // Dapper END
        }
    }
}
