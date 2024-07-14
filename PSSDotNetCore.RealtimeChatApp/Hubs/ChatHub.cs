using Microsoft.AspNetCore.SignalR;

namespace PSSDotNetCore.RealtimeChatApp.Hubs
{
	public class ChatHub : Hub
	{
		public async Task ServerReceiveMessage(string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
	}
}
