using BlackJack.Services.Helpers;
using BlackJack.Services.Services;
using BlackJack.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace BlackJack.Services.Configuration
{
    public static class ServicesConfig
    {
        public static void AddBlackJackServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGameHistoryService, GameHistoryService>();
        }
    }
}
