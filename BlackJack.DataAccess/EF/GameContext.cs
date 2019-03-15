using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.DataAccess.EF
{
    public class GameContext : DbContext
    {
        private const string ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Database=BlackJack";

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<RoundPlayer> RoundPlayers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<RoundPlayerCard> RoundPlayerCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasData(CreateDeck());
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

        private IEnumerable<Card> CreateDeck()
        {
            var deck = new List<Card>();
            var suits = (IEnumerable<Suit>) Enum.GetValues(typeof(Suit));
            var ranks = (IEnumerable<CardRank>)Enum.GetValues(typeof(CardRank));

            int id = 1;
            foreach (var suit in suits)
            {
                deck.AddRange(CreateRanks(suit, ref id, ranks));
            }

            return deck;
        }

        private IEnumerable<Card> CreateRanks(Suit suit, ref int id, IEnumerable<CardRank> ranks)
        {
            var ranksBySuit = new List<Card>();
            foreach (var rank in ranks)
            {
                ranksBySuit.Add(new Card { Id = id, CreationTime = DateTime.Now, Suit = suit, Rank = rank });
                id++;
            }

            return ranksBySuit;
        }
    }
}
