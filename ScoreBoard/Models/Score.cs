namespace ScoreBoard.Models
{
	public class Score
	{
        public int ScoreId { get; set; }
        public int UserId { get; set; }
        public int UserScore { get; set; }
        public int Month { get; set; }
		public ApplicationUser? User { get; set; }
	}
}
