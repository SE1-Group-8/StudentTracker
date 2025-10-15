namespace StudentTrackerApp.Models
{
	public class CheckIn
	{
		public int Id { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public string Details { get; set; } = string.Empty;

		public string Notes { get; set; } = string.Empty;
	}
}
