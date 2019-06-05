using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using AppChat.Abstraction.Model;
using AppChat.Abstraction.Services;

namespace AppChat.Services
{
	public class QueueService : IQueueService
	{
		private readonly ConcurrentQueue<ChatMessage> _queue = new ConcurrentQueue<ChatMessage>();

		public QueueService( Action<ChatMessage> onMessageReceived)
		{
			this.OnMessageReceived = onMessageReceived;
		}

		public async Task SendAsync(ChatMessage chatMessage)
		{

			_queue.Enqueue(chatMessage);

			if (OnMessageReceived != null)
			{
				OnMessageReceived(chatMessage);
			}

		}

		public Action<ChatMessage> OnMessageReceived { get; }
	}
}
