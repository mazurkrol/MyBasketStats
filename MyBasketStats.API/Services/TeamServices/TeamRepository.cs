using Microsoft.EntityFrameworkCore;
using MyBasketStats.API.DbContexts;
using MyBasketStats.API.Entities;
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
        public async Task<Team> GetTeamByIdAsync(int id)
        {
            return await _context.Teams.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
