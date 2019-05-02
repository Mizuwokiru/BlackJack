using BlackJack.Shared.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlackJack.DataAccess
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly string _connectionString;

        public UserDbContext(IOptions<DbSettingsOptions> options)
        {
            _connectionString = options.Value.UserConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
