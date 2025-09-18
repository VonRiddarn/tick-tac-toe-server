using Microsoft.EntityFrameworkCore;

namespace TimmyOhman.TicTacToeServer;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Scope the TicTacToeContext meaning each HTTPRequest has a fresh independent instance.
		// This is because DBContexts are meant to be disposable bursts to avoid memory bloating and stale values
		builder.Services.AddDbContext<TicTacToeContext>(options => options.UseSqlite("Data Source=tictactoe.db"));
		
		var app = builder.Build();

		app.MapGet("/", () => "Hello World!");

		app.MapGet("/test", (HttpRequest req) => {
			string? name = req.Query["name"];
			return $"Hello, {name}!";
		});

		app.Run();
	}
}

