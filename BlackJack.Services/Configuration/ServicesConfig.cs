using BlackJack.Services.Services;
using BlackJack.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.Services.Configuration
{
    public static class ServicesConfig
    {
        public static void AddBlackJackServices(this IServiceCollection services)
        {
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGameHistoryService, GameHistoryService>();
        }
    }
}
