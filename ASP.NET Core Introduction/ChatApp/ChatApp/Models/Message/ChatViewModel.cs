namespace ChatApp.Models.Message
{
	public class ChatViewModel
	{
		/// <summary>
		/// Content of current message
		/// </summary>
		public MessageViewModel CurrentMessage { get; set; } 
		/// <summary>
		/// Message collection
		/// </summary>
		public List<MessageViewModel> Messages { get; set; }
	}
}
