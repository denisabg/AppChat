using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using AppChat.Abstraction.Services;

namespace AppChat.Abstraction.Model
{
	public class CacheService : ICacheService
	{
		private MemoryCache _cache = MemoryCache.Default;

		public async Task AddAsync(ChatMessage chatMessage)
		{

			_cache.Set(chatMessage.Id.ToString(), chatMessage, DateTimeOffset.MaxValue);


			//Task.FromResult()
		}

		public async Task<IReadOnlyCollection<ChatMessage>> GetAsync(DateTime lastTimeStamp)
		{
			var items = _cache.ToArray();

			var values = items.Select(x => x.Value).ToArray();

			var res = values
				.OfType<ChatMessage>()
				.Where(x=>x.DateStamp >= lastTimeStamp.ToUniversalTime())
				.ToArray();

				//.Select(x => x.Value)
				//.OfType<ChatMessage>()
				//.Where(x => x.DateStamp >= lastTimeStamp)
				//.ToArray();
				
			return await Task.FromResult(res);
		}
	}
}
