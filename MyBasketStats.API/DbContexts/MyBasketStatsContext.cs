using Microsoft.EntityFrameworkCore;
using MyBasketStats.API.Entities;

namespace MyBasketStats.API.DbContexts
{
    public class MyBasketStatsContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeamGameStatsheet)
                .WithMany()
                .HasForeignKey(g => g.HomeTeamGameStatsheetId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .HasOne(g => g.RoadTeamGameStatsheet)
                .WithMany()
                .HasForeignKey(g => g.RoadTeamGameStatsheetId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany()
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            modelBuilder.Entity<Game>()
               .HasOne(g => g.RoadTeam)
               .WithMany()
               .HasForeignKey(g => g.RoadTeamId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<TeamGameStatsheet> TeamGameStatsheets { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Statsheet> Statsheets { get; set; }
        public DbSet<Team> Teams { get; set; }
        public MyBasketStatsContext(DbContextOptions<MyBasketStatsContext> options)
            : base(options) 
        {
        }
    }
}
