using BlackJack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

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
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
