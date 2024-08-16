using ScoreBoard.Models;

namespace ScoreBoard.Repositories.Interfaces
{
	public interface IScoreRepository
	{

		Task<IEnumerable<int>> GetMonthsAsync();
        Task<IEnumerable<Score>> GetScoresByMonthAsync(int month, int pageIndex, int pageSize);
        Task<int> GetTotalUserCountAsync();
        Task<ApplicationUser?> GetUserOnPage2Async(int month, int pageIndex, int pageSize);

    }
}
