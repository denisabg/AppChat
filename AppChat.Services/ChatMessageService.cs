using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppChat.Abstraction.Model;
using AppChat.Abstraction.Services;


namespace AppChat.Services
{
	public class ChatMessageService: IChatMessageService
	{
		private IQueueService _queueService;
		private ICacheService _cacheService;

		public ChatMessageService(IQueueService queueService, ICacheService cacheService)
		{
			if (queueService == null)
			{
				throw new ArgumentNullException(nameof(queueService));
			}
			if (cacheService == null)
			{
				throw new ArgumentNullException(nameof(cacheService));
			}

			_queueService = queueService;// ?? new QueueService();
			_cacheService = cacheService;
		}

		public async Task SendAsync(ChatMessage chatMessage)
		{
			await _queueService.SendAsync(chatMessage);
			await _cacheService.AddAsync(chatMessage);
		}

		public async Task<IReadOnlyCollection<ChatMessage>> GetAsync(DateTime lastTimeStamp)
		{
			return await _cacheService.GetAsync(lastTimeStamp);
		}
	}
}
