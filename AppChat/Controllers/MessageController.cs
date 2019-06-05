using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using AppChat.Abstraction.Model;
using AppChat.Abstraction.Services;
using AppChat.Services;

namespace AppChat.Controllers
{
    public class MessageController : ApiController
    {

	    private readonly IChatMessageService service;

	   // public MessageController(IChatMessageService service)
	    public MessageController()
	    {
			//TODO: Use Ioc for inject service to controller

		    this.service = ServiceFactory.Create();
	    }
        // GET: api/Message
	    [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IEnumerable<ChatMessage>> GetAsync(DateTime timeStamp)
        {
	        var res = await service.GetAsync(timeStamp);

	        return res;
        }

        // POST: api/Message
	    [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<ChatMessage> PostAsync([FromBody]ChatMessage value)
        {
	        await service.SendAsync(value);

			//Return id or object 

	        return value;
        }

	}
}
