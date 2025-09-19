using TimmyOhman.TicTacToeServer.Services;

namespace TimmyOhman.TicTacToeServer.Models.Entities
{
	public class UserInternal : Entity
	{
		public string Username { get; set; } = "UNKNOWN_USER";
		public string PasswordHash { get; set; } = "PASSWORD HASH";
		public string? AuthToken { get; set; }
		public DateTime ExpiresAt { get; set; } = DateTime.Now;
		public int SelectedImage {get; set; } = 0;

		public UserInternal() {}

		public UserInternal(string username, string passwordHash)
		{
			Username = username;
			PasswordHash = passwordHash;
			AuthToken = AuthServices.GenerateToken();
			ExpiresAt = DateTime.Now.AddHours(Constants.TOKEN_LIFESPAN_HOURS);
		}
	}

	public class UserPublic
	{
		public string Username { get; set; } = "UNKNOWN_USER";
		public int SelectedImage {get; set; } = 0;

		public UserPublic() {} 
	}
}