using BlackJack.BusinessLogic.Services;
using BlackJack.BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BusinessLogic.Configuration
{
    public static class BusinessLogicConfig
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddTransient<IGameCreationService, GameCreationService>();
            services.AddTransient<IGameService, GameService>();
        }
    }
}
