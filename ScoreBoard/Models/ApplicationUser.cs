using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{
	public class ApplicationUser
	{
		[Key]
		public int UserId { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
		public bool Gender { get; set; }
		public ICollection<Score> Scores { get; set; } = new List<Score>();
	}
}
