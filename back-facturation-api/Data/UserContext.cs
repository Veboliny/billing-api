using back_facturation_api.Models;
using Microsoft.EntityFrameworkCore;

namespace back_facturation_api.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // make email unique index
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });
        }
    }
}
