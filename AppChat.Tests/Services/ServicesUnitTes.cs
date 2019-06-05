using System;
using System.Threading.Tasks;
using AppChat.Abstraction.Model;
using AppChat.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppChat.Tests.Services
{
	[TestClass]
	public class ServicesUnitTes
	{
		[TestMethod]
		public async Task TestMethodMessageService()
		{
			ChatMessage chatMessageFirst = new ChatMessage {Message = "body 1", UserName = "name 1"};
			ChatMessage chatMessageSecond = new ChatMessage {Message = "body 2", UserName = "name 2"};
			ChatMessage chatMessageThird = new ChatMessage {Message = "body 3", UserName = "name 3"};

			//{
			//	Message = "body",
			//	UserName = "name",
			//	DateStamp = DateTime.UtcNow,
			//	Id = Guid.NewGuid()
			//};

			//Action<ChatMessage> onMessageReceived = delegate(ChatMessage message)
			//{
			//	if (message == null) throw new ArgumentNullException(nameof(message));
				
			//};


			//var cacheS = new CacheService();

			await _cacheS.AddAsync(chatMessageFirst);
			await _cacheS.AddAsync(chatMessageSecond);
			await _cacheS.AddAsync(chatMessageThird);

			
			var cache = await _cacheS.GetAsync(DateTime.UtcNow.AddMinutes(-15));

			Assert.IsNotNull(cache);


			await _queueS.SendAsync(chatMessageFirst);
			await _queueS.SendAsync(chatMessageSecond);
			await _queueS.SendAsync(chatMessageThird);



			var service = new ChatMessageService(_queueS,_cacheS);

			Assert.IsNotNull(service);



			var res = await service.GetAsync(DateTime.UtcNow.AddMinutes(-15));

			Assert.IsNotNull(res);

		}


		private readonly QueueService _queueS = new QueueService(delegate(ChatMessage message)
		{
			if (message == null) throw new ArgumentNullException(nameof(message));
		});

		private readonly CacheService _cacheS = new CacheService();
	}

}
