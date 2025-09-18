namespace TimmyOhman.TicTacToeServer.Models
{
	public class Game : Entity
	{
		public string RoomName {get; set; } = string.Empty;
		public string BoardState { get; set; } = string.Empty;
		public int PlayerXId { get; set; } = -1;
		public int PlayerOId { get; set; } = -1;
		public int? WinnerId { get; set; } = null;
		public bool ByForfeit { get; set; } = false;

		public Game() {} // Serialization

	}
}