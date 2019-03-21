using BlackJack.BusinessLogic.Models;
using BlackJack.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Utils
{
    public static class Mapper
    {
        public static PlayerViewModel MapPlayer(Player player)
        {
            return Map(player, p => new PlayerViewModel
            {
                Id = p.Id,
                Name = p.Name
            });
        }

        public static IEnumerable<PlayerViewModel> MapPlayers(IEnumerable<Player> players)
        {
            return Map(players, player => new PlayerViewModel
            {
                Id = player.Id,
                Name = player.Name
            });
        }

        public static CardViewModel MapCard(Card card)
        {
            return Map(card, c => new CardViewModel
            {
                Suit = c.Suit,
                Rank = c.Rank
            });
        }

        public static IEnumerable<CardViewModel> MapCards(IEnumerable<Card> cards)
        {
            return Map(cards, card => new CardViewModel
            {
                Suit = card.Suit,
                Rank = card.Rank
            });
        }

        private static TDestination Map<TSource, TDestination>(TSource source, Func<TSource, TDestination> func)
        {
            return func(source);
        }

        private static IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sources, Func<TSource, TDestination> func)
        {
            var dest = new List<TDestination>();
            foreach (var source in sources)
            {
                dest.Add(Map(source, func));
            }
            return dest;
        }
    }
}
