using BlackJack.DataAccess.Entities;
using BlackJack.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BlackJack.DataAccess
{
    public class GameDbContext : DbContext
    {
        private DbConnection dbConnection;

        public DbSet<Bot> Bots { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<RoundPlayer> RoundPlayers { get; set; }
        public DbSet<RoundPlayerBot> RoundPlayerBots { get; set; }
        public DbSet<RoundPlayerCard> RoundPlayerCards { get; set; }
        public DbSet<RoundPlayerUser> RoundPlayerUsers { get; set; }
        public DbSet<User> Users { get; set; }

        public GameDbContext(DbConnection connection)
        {
            dbConnection = connection;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bot>()
                .HasIndex(property => property.Name)
                .IsUnique();

            modelBuilder.Entity<Card>()
                .HasIndex(card => new { card.Suit, card.Rank })
                .IsUnique();
            modelBuilder.Entity<Card>()
                .HasData(GenerateCards());

            modelBuilder.Entity<User>()
                .HasIndex(property => property.Name)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbConnection);
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
