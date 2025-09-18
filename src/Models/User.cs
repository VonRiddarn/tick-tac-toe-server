using TimmyOhman.TicTacToeServer.Services;

namespace TimmyOhman.TicTacToeServer.Models
{
	public class User : Entity
	{
		public string Username { get; set; } = "UNKNOWN_USER";
		public string PasswordHash { get; set; } = "PASSWORD HASH";
		public string? AuthToken { get; set; }
		public DateTime ExpiresAt { get; set; } = DateTime.Now;
		public int SelectedImage {get; set; } = 0;
		public string Token { get; set; } = string.Empty;

		public User() {}

		public User(string username, string passwordHash)
		{
			Username = username;
			PasswordHash = passwordHash;
			AuthToken = AuthServices.GenerateToken();
			ExpiresAt = DateTime.Now.AddHours(Constants.TOKEN_LIFESPAN_HOURS);
		}
	}
}