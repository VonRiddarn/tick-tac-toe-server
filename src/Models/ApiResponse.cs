using System.Net;

namespace TimmyOhman.TicTacToeServer.Models
{
	public class ApiResponse
	{
		public HttpStatusCode Status { get; set; }
		public string Message { get; set; }
		public object? Data { get; set; }

		public ApiResponse(HttpStatusCode status, string message, object? data = null)
		{
			Status = status; 
			Message = message;
			Data = data;
		}
	}
}