namespace TimmyOhman.TicTacToeServer.DataTransferObjects
{
	public class RegisterDto
	{
		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;

		public RegisterDto() {}
		public RegisterDto(string username, string password) 
		{
			Username = username;
			Password = password;
		}
	}
}