using BlackJack.DataAccess;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services;
using BlackJack.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.Services.Configuration
{
    public static class ServicesConfig
    {
        public static void AddBlackJackServices(this IServiceCollection services, string orm)
        {
            if (orm == "Dapper")
            {
                services.AddTransient<ICardRepository, DataAccess.Repositories.Dapper.CardRepository>();
                services.AddTransient<IPlayerRepository, DataAccess.Repositories.Dapper.PlayerRepository>();
                services.AddTransient<IGameRepository, DataAccess.Repositories.Dapper.GameRepository>();
                services.AddTransient<IRoundRepository, DataAccess.Repositories.Dapper.RoundRepository>();
                services.AddTransient<IRoundCardRepository, DataAccess.Repositories.Dapper.RoundCardRepository>();
            }

            if (orm == "EntityFrameworkCore")
            {
                services.AddDbContext<GameDbContext>();
                services.AddTransient<ICardRepository, DataAccess.Repositories.EntityFrameworkCore.CardRepository>();
                services.AddTransient<IPlayerRepository, DataAccess.Repositories.EntityFrameworkCore.PlayerRepository>();
                services.AddTransient<IGameRepository, DataAccess.Repositories.EntityFrameworkCore.GameRepository>();
                services.AddTransient<IRoundRepository, DataAccess.Repositories.EntityFrameworkCore.RoundRepository>();
                services.AddTransient<IRoundCardRepository, DataAccess.Repositories.EntityFrameworkCore.RoundCardRepository>();
            }

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGameHistoryService, GameHistoryService>();
        }
    }
}
