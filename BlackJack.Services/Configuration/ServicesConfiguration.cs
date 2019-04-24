using AutoMapper;
using BlackJack.DataAccess;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Services.Services;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Helpers;
using BlackJack.Shared.Options;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.History;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;

namespace BlackJack.Services.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddBlackJackServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<GameDbContext>();
            
            services.Configure<DbSettingsOptions>(configuration.GetSection("DbSettings"));

            bool isDapperEnabled = bool.Parse(configuration["IsDapperEnabled"]);
            if (isDapperEnabled)
            {
                services.AddTransient<ICardRepository, DataAccess.Repositories.Dapper.CardRepository>();
                services.AddTransient<IPlayerRepository, DataAccess.Repositories.Dapper.PlayerRepository>();
                services.AddTransient<IGameRepository, DataAccess.Repositories.Dapper.GameRepository>();
                services.AddTransient<IRoundRepository, DataAccess.Repositories.Dapper.RoundRepository>();
                services.AddTransient<IRoundCardRepository, DataAccess.Repositories.Dapper.RoundCardRepository>();
            }

            if (!isDapperEnabled)
            {
                services.AddTransient<ICardRepository, DataAccess.Repositories.EntityFrameworkCore.CardRepository>();
                services.AddTransient<IPlayerRepository, DataAccess.Repositories.EntityFrameworkCore.PlayerRepository>();
                services.AddTransient<IGameRepository, DataAccess.Repositories.EntityFrameworkCore.GameRepository>();
                services.AddTransient<IRoundRepository, DataAccess.Repositories.EntityFrameworkCore.RoundRepository>();
                services.AddTransient<IRoundCardRepository, DataAccess.Repositories.EntityFrameworkCore.RoundCardRepository>();
            }

            Mapper.Initialize(config =>
            {
                config.CreateMap<RoundInfoModel, PlayerStateViewModel>()
                    .ForMember(
                        playerStateViewModel => playerStateViewModel.Cards,
                        options => options.MapFrom(
                            roundInfoModel => roundInfoModel.Cards
                                .Select(card => CardHelper.GetCardCode(card.Suit, card.Rank))))
                    .ForMember(
                        playerStateViewModel => playerStateViewModel.Score,
                        options => options.MapFrom(
                            roundInfoModel => GameService.CalculateCardScore(roundInfoModel.Cards)));
                config.CreateMap<GamesHistoryInfoModel, GameViewModel>();
            });

            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IHistoryService, HistoryService>();

            return services;
        }

        public static IServiceCollection AddBlackJackJwtIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection settingsSection = configuration.GetSection("JwtSettings");
            services.Configure<JwtSettingsOptions>(settingsSection);
            JwtSettingsOptions jwtOptions = settingsSection.Get<JwtSettingsOptions>();
            byte[] key = Encoding.ASCII.GetBytes(jwtOptions.TokenSecret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.ClaimsIssuer = jwtOptions.Issuer;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ValidateAudience = false
                };
            });

            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<GameDbContext>();

            services.AddAuthorization();

            return services;
        }

        public static IServiceCollection AddBlackJackMvcIdentity(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Authentication/Login");
                });

            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<GameDbContext>();

            services.AddAuthorization();

            return services;
        }
    }
}
