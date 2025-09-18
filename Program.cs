using Microsoft.EntityFrameworkCore;

namespace TimmyOhman.TicTacToeServer;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddDbContext<TicTacToeContext>(options => options.UseSqlite("Data Source=tictactoe.db"));
		builder.Configuration.AddJsonFile("secrets.json", optional: false);


		var app = builder.Build();

		// Using makes sure IDisposable die after the scope finsihes.
		using (var scope = app.Services.CreateScope())
		{
			var db = scope.ServiceProvider.GetRequiredService<TicTacToeContext>();
			db.Database.EnsureCreated();
		}


		app.MapGet("/", () => "Hello World!");

		app.Run();
	}
}

