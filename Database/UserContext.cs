using Microsoft.EntityFrameworkCore;
using RankingApp.Model;

namespace RankingApp.Database
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Id property as auto-incremented (identity)
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>(entity =>
                { entity.HasIndex(e => e.Email).IsUnique(); });

            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
