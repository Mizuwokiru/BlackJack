using BlackJack.DataAccess.Entities;
using BlackJack.Shared.Enums;
using BlackJack.Shared.Helpers;
using BlackJack.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess
{
    public class GameDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Card> Cards { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<RoundPlayer> RoundPlayers { get; set; }
        public DbSet<RoundPlayerCard> RoundPlayerCards { get; set; }

        public GameDbContext(IOptions<DbSettingsOptions> options)
        {
            _connectionString = options.Value.GameConnectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasIndex(property => property.Name)
                .IsUnique();

            modelBuilder.Entity<Card>()
                .HasIndex(card => new { card.Suit, card.Rank })
                .IsUnique();

            modelBuilder.Entity<Card>()
                .HasData(GenerateCards());
            modelBuilder.Entity<Player>()
                .HasData(new Player
                {
                    Id = Constants.DealerId,
                    CreationTime = DateTime.Now,
                    Name = "Dealer",
                    Type = PlayerType.Dealer
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public override int SaveChanges()
        {
            AddCreationTime();
            return base.SaveChanges();
        }

        private void AddCreationTime()
        {
            IEnumerable<EntityEntry<BaseEntity>> entries = ChangeTracker.Entries<BaseEntity>().Where(entity => entity.State == EntityState.Added);
            var dateTimeNow = DateTime.Now;
            foreach (var entry in entries)
            {
                entry.Entity.CreationTime = dateTimeNow;
            }
        }

        private Card[] GenerateCards()
        {
            var now = DateTime.Now;
            Card[] cards = Enumerable.Range(1, Constants.CardCount)
                .Select(i =>
                {
                    Tuple<Suit, Rank> cardData = CardHelper.GetCardById(i);
                    var card = new Card { Id = i, CreationTime = now, Suit = cardData.Item1, Rank = cardData.Item2 };
                    return card;
                })
                .ToArray();
            return cards;
        }
    }
}
