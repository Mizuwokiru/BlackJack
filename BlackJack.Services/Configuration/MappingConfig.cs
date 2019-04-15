using AutoMapper;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.ResponseModels;
using BlackJack.Services.Services;
using BlackJack.ViewModels.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace BlackJack.Services.Configuration
{
    public static class MappingConfig
    {
        public static void AddBlackJackMapping(this IServiceCollection services)
        {
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
            });
        }
    }
}
