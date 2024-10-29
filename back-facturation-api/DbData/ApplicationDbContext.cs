using back_facturation_api.DbData.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace back_facturation_api.DbData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Déclaration des DbSets pour chaque entité
        public DbSet<UserModel> UserModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurations supplémentaires avec Fluent API si nécessaire
        }
    }
}