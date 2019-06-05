using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppChat.Abstraction.Model;
using AppChat.Abstraction.Services;

namespace AppChat.Services
{
	public static class ServiceFactory
	{
		private static IQueueService _queueService = new QueueService(onMessageRecieved);
		private static ICacheService _cacheService = new CacheService();

		private static void onMessageRecieved(ChatMessage obj)
		{
			_cacheService.AddAsync(obj);
		}

		public static IChatMessageService Create(Action<ChatMessage> onMessageRecieved = null)
		{
			//Not good 
			var instance =  new ChatMessageService(_queueService, _cacheService);

			return instance;
		}
	}
}
