using System.Security.Cryptography;
using System.Text;

namespace TimmyOhman.TicTacToeServer.Services
{
	public static class AuthServices
	{
		public static string GenerateToken() => Guid.NewGuid().ToString();

		public static string HashPassword(string password, string salt)
		{
			using var sha = SHA256.Create();
			var bytes = Encoding.UTF8.GetBytes(password + salt);
			return Convert.ToHexString(sha.ComputeHash(bytes));
		}
	}
}