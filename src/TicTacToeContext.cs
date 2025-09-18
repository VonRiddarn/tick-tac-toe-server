using Microsoft.EntityFrameworkCore;
using TimmyOhman.TicTacToeServer.Models;

namespace TimmyOhman.TicTacToeServer
{
	public class TicTacToeContext : DbContext
	{
		public DbSet<Player> Players => Set<Player>();
		public DbSet<Game> Games => Set<Game>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=tictactoe.db");
		}
	}
}