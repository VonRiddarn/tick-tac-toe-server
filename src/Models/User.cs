namespace TimmyOhman.TicTacToeServer.Models
{
	public class User : Entity
	{
		public string Username { get; set; } = "UNKNOWN_USER";
		public string Password { get; set; } = "PASSWORD HASH";
		public int SelectedImage {get; set; } = 0;
		public string Token { get; set; } = string.Empty;

		public User() {}
	}
}