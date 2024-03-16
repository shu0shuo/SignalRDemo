namespace SignalRDemo.Hubs
{
	public interface IMessageHubClients
	{
		Task SendOffersToUser(List<string> message);
	}
}
