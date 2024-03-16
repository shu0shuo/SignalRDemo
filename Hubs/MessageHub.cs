using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.Hubs
{
	public class MessageHub : Hub<IMessageHubClients>
	{
		ILogger<MessageHub> _logger;
		public MessageHub(ILogger<MessageHub> logger)
		{
			_logger = logger;
			
		}
		/// <summary>
		/// 客户端连接服务端
		/// </summary>
		/// <returns></returns>
		public override Task OnConnectedAsync()
		{
			var id = Context.ConnectionId;
			_logger.LogInformation($"Client ConnectionId=> [[{id}]] Already Connection Server！");
			return base.OnConnectedAsync();
		}
		/// <summary>
		/// 客户端断开连接
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		public override Task OnDisconnectedAsync(Exception exception)
		{
			var id = Context.ConnectionId;
			_logger.LogInformation($"Client ConnectionId=> [[{id}]] Already Close Connection Server!");
			return base.OnDisconnectedAsync(exception);
		}
		public async Task SendOffersToUser(List<string> message){
			await Clients.All.SendOffersToUser(message);
		}
	}
	
}
