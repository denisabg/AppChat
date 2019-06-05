using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChat.Abstraction.Model
{
	public class ChatMessage
	{
		public Guid Id { get; set; }
		public DateTime DateStamp { get; set; }
		public string UserName { get; set; }
		public string Message { get; set; }

		public ChatMessage()
		{
			this.Id = Guid.NewGuid();
			this.DateStamp = DateTime.UtcNow;
		}
	}
	
}
