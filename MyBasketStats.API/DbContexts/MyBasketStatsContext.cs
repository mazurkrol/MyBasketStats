using Microsoft.EntityFrameworkCore;
using MyBasketStats.API.Entities;

namespace MyBasketStats.API.DbContexts
{
    public class MyBasketStatsContext : DbContext
    {
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
