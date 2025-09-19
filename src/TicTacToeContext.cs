using Microsoft.EntityFrameworkCore;
using TimmyOhman.TicTacToeServer.Models.Entities;

namespace TimmyOhman.TicTacToeServer
{
	public class TicTacToeContext : DbContext
	{
		public DbSet<User> Users => Set<User>();
		public DbSet<Game> Games => Set<Game>();

		public TicTacToeContext(DbContextOptions<TicTacToeContext> options) : base(options) {}
	}
}