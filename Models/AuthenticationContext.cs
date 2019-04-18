using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Models
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
            : base(options)
        {
        }

        public DbSet<AuthenticationItem> AuthenticationItems { get; set; }
    }
}