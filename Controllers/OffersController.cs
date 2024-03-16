using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hubs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OffersController : ControllerBase
	{
		//SignalR
		private IHubContext<MessageHub,IMessageHubClients> _messageHub;
		public OffersController(IHubContext<MessageHub, IMessageHubClients> messageHub)
		{
			_messageHub = messageHub;
		}
		[HttpPost]
		[Route("offers")]
		public string Post()
		{
			List<string> messages = new List<string>();
			messages.Add("20% off");
			messages.Add("30% off");
			_messageHub.Clients.All.SendOffersToUser(messages);
			return "Offer sent successfully to all users!";
		}




		// GET: api/<OffersController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<OffersController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<OffersController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<OffersController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<OffersController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
