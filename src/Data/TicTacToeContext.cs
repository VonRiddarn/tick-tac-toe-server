using Microsoft.EntityFrameworkCore;
using TimmyOhman.TicTacToeServer.Models.Entities;

namespace TimmyOhman.TicTacToeServer.Data
{
	public class TicTacToeContext : DbContext
	{
		public DbSet<UserInternal> Users => Set<UserInternal>();
		public DbSet<Game> Games => Set<Game>();

		public TicTacToeContext(DbContextOptions<TicTacToeContext> options) : base(options) {}
		
	}
}