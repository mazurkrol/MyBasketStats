using Microsoft.EntityFrameworkCore;
using MyBasketStats.API.DbContexts;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Services.PlayerServices;

namespace MyBasketStats.API.Services.TeamServices
{
    public class TeamRepository : ITeamRepository
    {
        private readonly MyBasketStatsContext _context;
        public TeamRepository(MyBasketStatsContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddTeamToDbAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
        }
        public async Task<Team> GetTeamByNameAsync(string name)
        {
            return await _context.Teams
                .Where(c => c.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task AddPlayerAsync(Player player, Team team)
        {
            team.Players.Add(player);
            await _context.SaveChangesAsync();
        }

    }
}
