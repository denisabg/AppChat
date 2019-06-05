using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppChat.Abstraction.Model;

namespace AppChat.Abstraction.Services
{
	public interface IChatMessageService
	{
		Task SendAsync( ChatMessage chatMessage );

		Task<IReadOnlyCollection<ChatMessage>> GetAsync(DateTime lastTimeStamp);
	}
}
