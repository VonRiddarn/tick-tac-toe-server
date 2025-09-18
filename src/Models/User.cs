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
	}
}