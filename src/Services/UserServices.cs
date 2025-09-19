using System.Net;
using TimmyOhman.TicTacToeServer.DataTransferObjects;
using TimmyOhman.TicTacToeServer.Models;
using TimmyOhman.TicTacToeServer.Models.Entities;

namespace TimmyOhman.TicTacToeServer.Services
{
	public static class UserServices
	{
		public static User? GetUserByName(string username, TicTacToeContext db) => db.Users.FirstOrDefault((u) => u.Username == username);

		public static User? GetUserFromToken(TicTacToeContext db, string token) => db.Users.FirstOrDefault((u) => u.AuthToken == token && u.ExpiresAt < DateTime.Now);

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
				return Results.InternalServerError(new ApiResponse(HttpStatusCode.InternalServerError, $"An error occurred while registering the user: {ex.Message}."));
			}

			return Results.Ok(new ApiResponse(HttpStatusCode.OK, "User created successfully.", new {
				username = newUser.Username,
				authToken = newUser.AuthToken
			}));
		}

		public static IResult? ValidateRegisterDto(RegisterDto dto, TicTacToeContext db)
		{
			if(dto.Username.Length < Constants.USERNAME_LENGTH_MIN)
				return Results.BadRequest(new ApiResponse(HttpStatusCode.BadRequest, "Username must be at least 8 characters long!"));
			if(dto.Password.Length < Constants.PASSWORD_LENGTH_MIN)
				return Results.BadRequest(new ApiResponse(HttpStatusCode.BadRequest, "Password must be at least 8 characters long!"));
			if(GetUserByName(dto.Username, db) != null)
				return Results.Conflict(new ApiResponse(HttpStatusCode.Conflict, "Username already exists!"));
			
			return null;
		}
	}
}