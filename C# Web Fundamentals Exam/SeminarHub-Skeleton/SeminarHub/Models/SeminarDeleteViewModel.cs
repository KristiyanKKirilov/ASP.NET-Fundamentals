namespace SeminarHub.Models
{
	public class SeminarDeleteViewModel
	{
		/// <summary>
		/// Seminar identifier
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Seminar topic
		/// </summary>
		public string Topic { get; set; } = string.Empty;

		/// <summary>
		/// Seminar date
		/// </summary>
		public string DateAndTime { get; set; } = string.Empty;
	}
}
