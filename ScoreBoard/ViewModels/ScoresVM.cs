using ScoreBoard.Models;

namespace ScoreBoard.ViewModels
{
    public class ScoresVM
    {
        public IEnumerable<Score>? Scores { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public ApplicationUser? UserOnPage2 { get; set; }
    }
}
