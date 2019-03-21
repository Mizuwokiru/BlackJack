using BlackJack.DataAccess.EntityFramework;
using BlackJack.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BusinessLogic.Configuration
{
    public static class DbAccessConfig
    {
        public static void AddDbAcсess(this IServiceCollection services, string connectionString)
        {
            // EF BEGIN
            services.AddDbContext<GameDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<ICardRepository>(provider =>
            {
                var context = provider.GetService<GameDbContext>();
                return new DataAccess.EntityFramework.Repositories.CardRepository(context);
            });
            services.AddTransient<IGameRepository>(provider =>
            {
                var context = provider.GetService<GameDbContext>();
                return new DataAccess.EntityFramework.Repositories.GameRepository(context);
            });
            services.AddTransient<IPlayerRepository>(provider =>
            {
                var context = provider.GetService<GameDbContext>();
                return new DataAccess.EntityFramework.Repositories.PlayerRepository(context);
            });
            services.AddTransient<IRoundRepository>(provider =>
            {
                var context = provider.GetService<GameDbContext>();
                return new DataAccess.EntityFramework.Repositories.RoundRepository(context);
            });
            services.AddTransient<IGamePlayerRepository>(provider =>
            {
                var context = provider.GetService<GameDbContext>();
                return new DataAccess.EntityFramework.Repositories.GamePlayerRepository(context);
            });
            services.AddTransient<IRoundPlayerRepository>(provider =>
            {
                var context = provider.GetService<GameDbContext>();
                return new DataAccess.EntityFramework.Repositories.RoundPlayerRepository(context);
            });
            services.AddTransient<IRoundPlayerCardRepository>(provider =>
            {
                var context = provider.GetService<GameDbContext>();
                return new DataAccess.EntityFramework.Repositories.RoundPlayerCardRepository(context);
            });
            /*
            services.AddTransient<ICardRepository, DataAccess.EntityFramework.Repositories.CardRepository>();
            services.AddTransient<IGameRepository, DataAccess.EntityFramework.Repositories.GameRepository>();
            services.AddTransient<IPlayerRepository, DataAccess.EntityFramework.Repositories.PlayerRepository>();
            services.AddTransient<IRoundRepository, DataAccess.EntityFramework.Repositories.RoundRepository>();
            services.AddTransient<IGamePlayerRepository, DataAccess.EntityFramework.Repositories.GamePlayerRepository>();
            services.AddTransient<IRoundPlayerRepository, DataAccess.EntityFramework.Repositories.RoundPlayerRepository>();
            services.AddTransient<IRoundPlayerCardRepository, DataAccess.EntityFramework.Repositories.RoundPlayerCardRepository>();
            */
            // EF END

            // TODO: add Dapper support and make it switchable
        }
    }
}
