using System.Net;
using TimmyOhman.TicTacToeServer.Data;
using TimmyOhman.TicTacToeServer.Models;
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

			app.MapGet($"{ROOT}/{{username}}", (string username, TicTacToeContext db) => {
				var user = UserServices.GetUserByNamePublic(username, db);

				if(user == null)
					return Results.NotFound(new ApiResponse(HttpStatusCode.NotFound, $"Couldn't find user of name {username}."));
				
				return Results.Ok(new ApiResponse(HttpStatusCode.OK, "User found.", user));
			});

			// TODO: Use a RegisterDTO later for safe hidden transfer. AND USE POST!
			app.MapGet($"{ROOT}/register-user", (string username, string password, TicTacToeContext db) => {
				return UserServices.Register(new RegisterDto(username, password), db);
			});
		}
	}
}