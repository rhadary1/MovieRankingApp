namespace RankingApp.Database
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using RankingApp.Enums;

    public class RankedItemContext : DbContext
    {
        public DbSet<RankedItem> RankedItems { get; set; }
    
        public string DbPath { get; }  

        public RankedItemContext(DbContextOptions<RankedItemContext> options) : base(options)
        {
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RankedItem>().ToTable("RankedItem");
        }
    }

    public class RankedItem
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int Ranking { get; set; }
        public ItemType Type { get; set; }
        public string? Title { get; set; }
    }
}
