using Microsoft.EntityFrameworkCore;
using TimmyOhman.TicTacToeServer.Controllers;
using TimmyOhman.TicTacToeServer.Data;
using TimmyOhman.TicTacToeServer.Utilities;

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

		InitializeDatabase.Initialize(app);

		UserEndpoints.MapEndpoints(app);

		app.Run();
	}
}

