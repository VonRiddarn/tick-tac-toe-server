namespace TimmyOhman.TicTacToeServer.Models
{
	public class Player : Entity
	{
		public DateTime LastLogin { get; set; }
		public string Username { get; set; } = "UNKNOWN_USER";
		public string Token { get; set; } = string.Empty;

		public Player() {}
	}
}