namespace SeminarHub.Data.Models
{
	public static class ErrorMessages
	{
		/// <summary>
		/// Required error message
		/// </summary>
		public const string RequiredError = "The field {0} is required";

		/// <summary>
		/// String length error message
		/// </summary>
		public const string StringLengthError = "The field {0} must be between {2} and {1} characters long";

		/// <summary>
		/// Seminar duration error message
		/// </summary>
		public const string DurationError = "Value must between {1} and {2}";

		/// <summary>
		/// Invalid date format error message
		/// </summary>		
		public const string InvalidDateFormatError = $"Invalid date! Format must be {DataConstants.DateFormat}";
	}
}
