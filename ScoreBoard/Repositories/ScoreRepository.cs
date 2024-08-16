using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ScoreBoard.Data;
using ScoreBoard.Models;
using ScoreBoard.Repositories.Interfaces;

namespace ScoreBoard.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly ApplicationDbContext _context;

        public ScoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<int>> GetMonthsAsync()
        {
            return await _context.Scores
                .Select(s => s.Month)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<Score>> GetScoresByMonthAsync(int month, int pageIndex, int pageSize)
        {
            return await _context.Scores
                .Where(s => s.Month == month)
                .Include(s => s.User)
                .OrderByDescending(s => s.UserScore)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalUserCountAsync()
        {
            return await _context.ApplicationUsers.CountAsync();
        }

        public async Task<ApplicationUser?> GetUserOnPage2Async(int month, int pageIndex, int pageSize)
        {
            var userId = await _context.Scores
        .Where(s => s.Month == month)
        .OrderByDescending(s => s.UserScore)
        .Skip((pageIndex - 1) * pageSize)
        .Take(1)
        .Select(s => s.UserId)
        .FirstOrDefaultAsync();

            if (userId == 0)
            {
                return null; // Không tìm thấy người dùng
            }

            return await _context.ApplicationUsers
                .Include(u => u.Scores)
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }


    }
}
