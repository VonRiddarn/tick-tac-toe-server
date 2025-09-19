using Microsoft.EntityFrameworkCore;
using TimmyOhman.TicTacToeServer.Controllers;

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

		UserEndpoints.MapEndpoints(app);

		app.Run();
	}
}

