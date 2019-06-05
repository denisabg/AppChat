using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppChat.Abstraction.Model;

namespace AppChat.Abstraction.Services
{
	public interface ICacheService
	{
		Task AddAsync( ChatMessage chatMessage );

		Task<IReadOnlyCollection<ChatMessage>> GetAsync(DateTime lastTimeStamp);
	}
}
