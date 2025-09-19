using TimmyOhman.TicTacToeServer.Data;

namespace TimmyOhman.TicTacToeServer.Utilities
{
	public static class InitializeDatabase
	{
		public static void Initialize(WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var db = scope.ServiceProvider.GetRequiredService<TicTacToeContext>();
			db.Database.EnsureCreated();
		} // Scope is Disposed because of using and IDisposeable
	}
}