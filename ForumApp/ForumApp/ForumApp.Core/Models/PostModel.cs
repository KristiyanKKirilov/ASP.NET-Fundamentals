using static ForumApp.Infrastructure.Constants.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Core.Models
{
	/// <summary>
	/// Post data transfer model
	/// </summary>
	public class PostModel
	{
		/// <summary>
		/// Post identifier
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Post title
		/// </summary>
		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(MaxTitleLength, MinimumLength = MinTitleLength, ErrorMessage = StringLengthErrorMessage)]		
		public string Title { get; set; } = string.Empty;
		/// <summary>
		/// Post content
		/// </summary>
		[Required(ErrorMessage = RequiredErrorMessage)]
		[StringLength(MaxContentLength, MinimumLength = MinContentLength, ErrorMessage = StringLengthErrorMessage)]
		public string Content { get; set; } = string.Empty;
	}
}
