namespace ForumApp.Infrastructure.Constants
{
	/// <summary>
	/// Constant values used for model validation
	/// </summary>
	public static class ValidationConstants
	{
		/// <summary>
		/// Minimal Post Title Length
		/// </summary>
		public const int MinTitleLength = 10;
		/// <summary>
		/// Maximal Post Title Length
		/// </summary>
		public const int MaxTitleLength = 50;
		/// <summary>
		/// Minimal Post Content Length
		/// </summary>
		public const int MinContentLength = 30;
		/// <summary>
		/// Maximal Post Content Length
		/// </summary>
		public const int MaxContentLength = 1500;
		/// <summary>
		/// Error message for required field
		/// </summary>
		public const string RequiredErrorMessage = "Field {0} is required";
		/// <summary>
		/// Error message for minimal and maximal symbols entered
		/// </summary>
		public const string StringLengthErrorMessage = "{0} must be between {2} and {1} symbols";
	}
}
