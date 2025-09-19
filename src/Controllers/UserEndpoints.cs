using TimmyOhman.TicTacToeServer.Models.DataTransfer;
using TimmyOhman.TicTacToeServer.Services;

namespace TimmyOhman.TicTacToeServer.Controllers
{
	public static class UserEndpoints
	{
		public const string ROOT = "/api/Users";

		public static void MapEndpoints(WebApplication app)
		{
			app.MapGet(ROOT, () => "Hello World!");

			// TODO: Use a RegisterDTO later for safe hidden transfer. AND USE POST!
			app.MapGet($"{ROOT}/register-user", (HttpContext ctx, TicTacToeContext db, string username, string password) => {
				return UserServices.Register(new RegisterDto(username, password), db);
			});
		}
	}
}