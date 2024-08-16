using Microsoft.EntityFrameworkCore;
using ScoreBoard.Models;

namespace ScoreBoard.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}


		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Score> Scores { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ApplicationUser>()
				.HasKey(u => u.UserId);

			modelBuilder.Entity<Score>()
				.HasOne(s => s.User)
				.WithMany(u => u.Scores)
				.HasForeignKey(s => s.UserId);

			// Dataseed
			modelBuilder.Entity<ApplicationUser>().HasData(
				new ApplicationUser { UserId = 1, Name = "Lê Đức Tài", ImageUrl = "https://placehold.co/600x400", PhoneNumber = 1234567890, Birthday = new DateTime(2002, 4, 4), Gender = true },
				new ApplicationUser { UserId = 2, Name = "Trần Văn A", ImageUrl = "https://placehold.co/600x400", PhoneNumber = 1234567891, Birthday = new DateTime(2000, 2, 2), Gender = false },
				new ApplicationUser { UserId = 3, Name = "Nguyễn Thị C", ImageUrl = "https://placehold.co/600x400", PhoneNumber = 1234567892, Birthday = new DateTime(1999, 1, 5), Gender = true }
			);

			modelBuilder.Entity<Score>().HasData(
				new Score { ScoreId = 1, UserId = 1, UserScore = 2, Month = 8},
				new Score { ScoreId = 2, UserId = 1, UserScore = 3, Month = 9},
				new Score { ScoreId = 3, UserId = 2, UserScore = 4, Month = 8},
				new Score { ScoreId = 4, UserId = 2, UserScore = 5, Month = 9},
				new Score { ScoreId = 5, UserId = 3, UserScore = 0, Month = 8},
				new Score { ScoreId = 6, UserId = 3, UserScore = 1, Month = 9}
			);
		}


	}
}
