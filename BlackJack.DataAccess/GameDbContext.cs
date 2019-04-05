using BlackJack.DataAccess.Entities;
using BlackJack.Shared;
using BlackJack.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack.DataAccess
{
    public class GameDbContext : DbContext
    {
        private readonly DbConnection dbConnection;

        public DbSet<Card> Cards { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<RoundCard> RoundCards { get; set; }

        public GameDbContext(DbConnection connection)
        {
            dbConnection = connection;
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
                    Id = BlackJackConstants.DealerId,
                    CreationTime = DateTime.Now,
                    Name = "Dealer",
                    Type = PlayerType.Dealer
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(dbConnection);
        }

        public override int SaveChanges()
        {
            AddCreationTime();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddCreationTime();
            return await base.SaveChangesAsync(cancellationToken);
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
            var cards = new List<Card>();
            IEnumerable<Suit> suits = Enum.GetValues(typeof(Suit)).OfType<Suit>();
            IEnumerable<Rank> ranks = Enum.GetValues(typeof(Rank)).OfType<Rank>();
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
