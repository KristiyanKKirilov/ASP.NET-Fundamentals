using SeminarHub.Data.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.Models.DataConstants.Seminar;
using static SeminarHub.Data.Models.ErrorMessages;

namespace SeminarHub.Models
{
	public class SeminarFormViewModel
	{		
		/// <summary>
		/// Seminar topic
		/// </summary>
		[Required(ErrorMessage = RequiredError)]
		[StringLength(TopicMaxLength,
			MinimumLength = TopicMinLength, 
			ErrorMessage = StringLengthError)]
		[DisplayName("Seminar Topic")]
		public string Topic { get; set; } = string.Empty;

		/// <summary>
		/// Seminar lecturer
		/// </summary>
		[Required(ErrorMessage = RequiredError)]
		[StringLength(LecturerMaxLength, 
			MinimumLength = LecturerMinLength, 
			ErrorMessage = StringLengthError)]
		public string Lecturer { get; set; } = string.Empty;

		/// <summary>
		/// Seminar details
		/// </summary>
		[Required(ErrorMessage = RequiredError)]
		[StringLength(DetailsMaxLength, 
			MinimumLength = DetailsMinLength, 
			ErrorMessage = StringLengthError)]
		[DisplayName("More Info")]
		public string Details { get; set; } = string.Empty;

		/// <summary>
		/// Seminar date
		/// </summary>
		[Required(ErrorMessage = RequiredError)]
		[DisplayName("Date of Seminar")]
		public string DateAndTime { get; set; } = string.Empty;

		/// <summary>
		/// Seminar duration
		/// </summary>
		[Range(DurationMinTime, DurationMaxTime, ErrorMessage = DurationError)]
		public int Duration { get; set; }

		/// <summary>
		/// Seminar category identifier
		/// </summary>
		[Required(ErrorMessage = RequiredError)]
		[DisplayName("Category")]
		public int CategoryId { get; set; }	

		/// <summary>
		/// Collection of categories
		/// </summary>
		public IEnumerable<Category> Categories { get; set; } = new List<Category>();
	}
}
