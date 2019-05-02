using AutoMapper;
using BlackJack.DataAccess;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.Services.Services;
using BlackJack.Services.Services.Interfaces;
using BlackJack.Shared.Helpers;
using BlackJack.Shared.Options;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.History;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;

namespace BlackJack.Services.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddBlackJackServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            
            services.Configure<DbSettingsOptions>(configuration.GetSection("DbSettings"));

            bool isDapperEnabled = bool.Parse(configuration["IsDapperEnabled"]);
            if (isDapperEnabled)
            {
                services.AddTransient<ICardRepository, DataAccess.Repositories.Dapper.CardRepository>();
                services.AddTransient<IPlayerRepository, DataAccess.Repositories.Dapper.PlayerRepository>();
                services.AddTransient<IGameRepository, DataAccess.Repositories.Dapper.GameRepository>();
                services.AddTransient<IRoundPlayerRepository, DataAccess.Repositories.Dapper.RoundPlayerRepository>();
                services.AddTransient<IRoundPlayerCardRepository, DataAccess.Repositories.Dapper.RoundPlayerCardRepository>();
            }

            if (!isDapperEnabled)
            {
                services.AddDbContext<GameDbContext>();
                services.AddTransient<ICardRepository, DataAccess.Repositories.EntityFrameworkCore.CardRepository>();
                services.AddTransient<IPlayerRepository, DataAccess.Repositories.EntityFrameworkCore.PlayerRepository>();
                services.AddTransient<IGameRepository, DataAccess.Repositories.EntityFrameworkCore.GameRepository>();
                services.AddTransient<IRoundPlayerRepository, DataAccess.Repositories.EntityFrameworkCore.RoundPlayerRepository>();
                services.AddTransient<IRoundPlayerCardRepository, DataAccess.Repositories.EntityFrameworkCore.RoundPlayerCardRepository>();
            }

            Mapper.Initialize(config =>
            {
                config.CreateMap<RoundPlayer, PlayerGameViewModel>()
                    .ForMember(
                        playerGameViewModel => playerGameViewModel.PlayerName,
                        options => options.MapFrom(
                            roundPlayer => roundPlayer.Player.Name))
                    .ForMember(
                        playerGameViewModel => playerGameViewModel.State,
                        options => options.MapFrom(
                            roundPlayer => roundPlayer.State))
                    .ForMember(
                        playerGameViewModel => playerGameViewModel.Cards,
                        options => options.MapFrom(
                            roundPlayer => roundPlayer.Cards.Select(roundPlayerCard => CardHelper.GetCardCode(roundPlayerCard.Card.Suit, roundPlayerCard.Card.Rank))))
                    .ForMember(
                        playerGameViewModel => playerGameViewModel.Score,
                        options => options.MapFrom(
                            roundPlayer => GameService.CalculateCardScore(roundPlayer.Cards.Select(roundPlayerCard => roundPlayerCard.Card))));
                config.CreateMap<Game, GameGamesHistoryViewModel>()
                    .ForMember(
                        gameGamesHistoryViewModel => gameGamesHistoryViewModel.CreationTime,
                        options => options.MapFrom(
                            game => game.CreationTime))
                    .ForMember(
                        gameGamesHistoryViewModel => gameGamesHistoryViewModel.PlayerCount,
                        options => options.MapFrom(
                            game => game.RoundPlayers.GroupBy(roundPlayer => roundPlayer.PlayerId).Count()))
                    .ForMember(
                        gameGamesHistoryViewModel => gameGamesHistoryViewModel.RoundCount,
                        options => options.MapFrom(
                            game => game.RoundPlayers.GroupBy(roundPlayer => roundPlayer.CreationTime).Count()));
            });

            services.AddTransient<IAuthenticationService, AuthenticationService>();
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

            services.AddDbContext<UserDbContext>();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>();

            return services;
        }

        public static IServiceCollection AddBlackJackMvcIdentity(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Authentication/Login";
                });
            services.AddDbContext<UserDbContext>();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>();

            services.AddAuthorization();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromMinutes(10);
                options.LoginPath = "/Authentication/Login";
                options.SlidingExpiration = true;
            });

            return services;
        }
    }
}
