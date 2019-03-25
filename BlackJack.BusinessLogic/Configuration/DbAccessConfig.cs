using BlackJack.DataAccess;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Data.SqlClient;

namespace BlackJack.BusinessLogic.Configuration
{
    public static class DbAccessConfig
    {
        public static void AddDbAcсess(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<DbConnection>(provider => new SqlConnection(connectionString));

            // EF BEGIN
            services.AddDbContext<GameDbContext>();
            // возможно стоит переделать в Scoped
            services.AddTransient<IBotRepository, DataAccess.Repositories.EntityFrameworkCore.BotRepository>();
            services.AddTransient<ICardRepository, DataAccess.Repositories.EntityFrameworkCore.CardRepository>();
            services.AddTransient<IGameRepository, DataAccess.Repositories.EntityFrameworkCore.GameRepository>();
            services.AddTransient<IRoundRepository, DataAccess.Repositories.EntityFrameworkCore.RoundRepository>();
            services.AddTransient<IRoundPlayerBotRepository, DataAccess.Repositories.EntityFrameworkCore.RoundPlayerBotRepository>();
            services.AddTransient<IRoundPlayerUserRepository, DataAccess.Repositories.EntityFrameworkCore.RoundPlayerUserRepository>();
            services.AddTransient<IRoundPlayerCardRepository, DataAccess.Repositories.EntityFrameworkCore.RoundPlayerCardRepository>();
            services.AddTransient<IUserRepository, DataAccess.Repositories.EntityFrameworkCore.UserRepository>();
            // EF END

            // Dapper BEGIN

            // Dapper END
        }
    }
}
