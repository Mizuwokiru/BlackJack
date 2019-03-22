using BlackJack.DataAccess.Entities;
using BlackJack.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.EntityFramework
{
    public class GameDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<RoundPlayer> RoundPlayers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<RoundPlayerCard> RoundPlayerCards { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasIndex(property => property.Name)
                .IsUnique();

            modelBuilder.Entity<Card>()
                .HasData(GenerateCards());
        }

        public override int SaveChanges()
        {
            AddCreationTime();
            return base.SaveChanges();
        }

        private void AddCreationTime()
        {
            IEnumerable<EntityEntry<BaseEntity>> entries = ChangeTracker.Entries<BaseEntity>().Where(entity => entity.State == EntityState.Added);
            foreach (var entry in entries)
            {
                entry.Entity.CreationTime = DateTime.Now;
            }
        }

        private Card[] GenerateCards()
        {
            var cards = new List<Card>();
            var suits = (IEnumerable<Suit>)Enum.GetValues(typeof(Suit));
            var ranks = (IEnumerable<Rank>)Enum.GetValues(typeof(Rank));
            int i = 1;
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card { Id = i, CreationTime = DateTime.Now, Suit = suit, Rank = rank });
                    i++;
                }
            }
            return cards.ToArray();
        }
    }
}
