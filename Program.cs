using Microsoft.EntityFrameworkCore;
using TimmyOhman.TicTacToeServer.DataTransferObjects;
using TimmyOhman.TicTacToeServer.Services;

namespace TimmyOhman.TicTacToeServer;

public class Program
{
	public static void Main(string[] args)
	{
		// Load environment variables
		DotNetEnv.Env.Load();


		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddDbContext<TicTacToeContext>(options => options.UseSqlite("Data Source=tictactoe.db"));

		var app = builder.Build();

		// Using makes sure IDisposable die after the scope finsihes.
		using (var scope = app.Services.CreateScope())
		{
			var db = scope.ServiceProvider.GetRequiredService<TicTacToeContext>();
			db.Database.EnsureCreated();
		}

		app.MapGet("/", () => "Hello World!");
		// TODO: Use a RegisterDTO later for safe hidden transfer. AND USE POST!
		app.MapGet("/api/register-user", (HttpContext ctx, TicTacToeContext db, string username, string password) => {
			return UserServices.Register(new RegisterDto(username, password), db);
		});

		app.Run();
	}
}

