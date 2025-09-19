using TimmyOhman.TicTacToeServer.DataTransferObjects;
using TimmyOhman.TicTacToeServer.Models;

namespace TimmyOhman.TicTacToeServer.Services
{
	public static class UserServices
	{
		public static User? GetUserByName(string username, TicTacToeContext db) => db.Users.FirstOrDefault((u) => u.Username == username);

		public static IResult Register(RegisterDto dto, TicTacToeContext db)
		{
			// Validate the data transfer object values
			var r = ValidateRegisterDto(dto, db);
			if(r != null) 
				return r;

			string salt = Environment.GetEnvironmentVariable("HASH_SALT") ?? "fa11back-54lt";
			string passwordHash = AuthServices.HashPassword(dto.Password, salt);
			var newUser = new User(dto.Username, passwordHash);

			try
			{
				db.Add(newUser);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				return Results.Problem($"An error occurred while registering the user: {ex.Message}");
			}

			return Results.Ok(new {
				status = "400",
				title = "User created successfully",
				username = newUser.Username,
				authToken = newUser.AuthToken
			});
		}

		public static IResult? ValidateRegisterDto(RegisterDto dto, TicTacToeContext db)
		{
			if(dto.Username.Length < Constants.USERNAME_LENGTH_MIN)
				return Results.BadRequest("Username must be at least 8 characters long!");
			if(dto.Password.Length < Constants.PASSWORD_LENGTH_MIN)
				return Results.BadRequest("Password must be at least 8 characters long!");
			if(GetUserByName(dto.Username, db) != null)
				return Results.Conflict("Username already exists!");
			
			return null;
		}
	}
}