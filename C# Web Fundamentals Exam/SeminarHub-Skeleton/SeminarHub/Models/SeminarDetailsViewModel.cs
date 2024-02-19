namespace SeminarHub.Models
{
	public class SeminarDetailsViewModel
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
		/// Seminar lecturer
		/// </summary>
		public string Lecturer { get; set; } = string.Empty;

		/// <summary>
		/// Seminar organizer
		/// </summary>
		public string Organizer { get; set; } = string.Empty;

		/// <summary>
		/// Seminar date
		/// </summary>
		public string DateAndTime { get; set; } = string.Empty;

		/// <summary>
		/// Seminar duration
		/// </summary>
		public int Duration { get; set; }

		/// <summary>
		/// Seminar details
		/// </summary>
		public string Details { get; set; } = string.Empty;

		/// <summary>
		/// Seminar category name
		/// </summary>
		public string Category { get; set; } = string.Empty;
	}
}
