using TimmyOhman.TicTacToeServer.Models.Entities;

namespace TimmyOhman.TicTacToeServer.Mapping
{
	public static class UserMapper
	{
		// Extention for UserInternal so that we separate concerns.
		// UserInternal is just a Model, this is logic
		public static UserPublic ToPublic(this UserInternal u) => 
		new UserPublic
		{
			Id = u.Id,
			CreatedAt = u.CreatedAt,
			Username = u.Username,
			SelectedImage = u.SelectedImage
		};
	}
}