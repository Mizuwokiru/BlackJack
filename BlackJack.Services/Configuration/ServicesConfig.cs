using AutoMapper;
using BlackJack.DataAccess;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Services.Services;
using BlackJack.Services.Services.Interfaces;
using BlackJack.ViewModels.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

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

            Mapper.Initialize(config =>
            {
                config.CreateMap<Card, CardViewModel>();
                config.CreateMap<RoundInfoModel, RoundViewModel>()
                    .ForMember(
                        roundViewModel => roundViewModel.Cards,
                        options => options.MapFrom(
                            roundInfoModel => Mapper.Map<List<Card>, List<CardViewModel>>(roundInfoModel.Cards)))
                    .ForMember(
                        roundViewModel => roundViewModel.Score,
                        options => options.MapFrom(
                            roundInfoModel => GameService.CalculateCardScore(roundInfoModel.Cards)));
                config.CreateMap<HistoryGameInfoModel, HistoryGameViewModel>();
                config.CreateMap<HistoryRoundInfoModel, HistoryRoundViewModel>()
                    .ForMember(
                        historyRoundViewModel => historyRoundViewModel.Cards,
                        options => options.MapFrom(
                            historyRoundInfoModel => Mapper.Map<IEnumerable<Card>,
                                IEnumerable<CardViewModel>>(historyRoundInfoModel.Cards)));
            });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGameHistoryService, GameHistoryService>();
        }
    }
}
