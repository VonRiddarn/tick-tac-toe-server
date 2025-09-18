namespace TimmyOhman.TicTacToeServer.Models
{
	public abstract class Entity
	{
		/*
			Cool fun fact: EF automatically applies

				[Key] : Primary key
    			and
				[DatabaseGenerated(DatabaseGeneratedOption.Identity)] : Auto increment

			To varaibles named Id or ClassnameId.
		*/
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public Entity() {}
	}
}