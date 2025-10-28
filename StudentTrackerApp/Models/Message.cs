namespace StudentTrackerApp.Models
{
	public class Message
	{
		public int Id { get; set; }
		public int SenderId { get; set; }
		public int RecieverId {  get; set; }
		public string MessageContent { get; set; } = string.Empty;
		public bool ReadByReciever { get; set; }
		public DateTime DateTime { get; set; }
	}
}
