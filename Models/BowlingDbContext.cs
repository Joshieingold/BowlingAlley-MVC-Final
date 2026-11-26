using Microsoft.EntityFrameworkCore;

namespace ProjectDbStarter.Models
{
    public class BowlingDbContext : DbContext
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options)
            : base(options) { }

        public DbSet<Team> Teams => Set<Team>();
        public DbSet<BowlingUser> Users => Set<BowlingUser>();
        public DbSet<Player> Players => Set<Player>();

        // force singular table name
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<BowlingUser>().ToTable("BowlingUser");
            modelBuilder.Entity<Player>().ToTable("Player");
        }
    }
}
