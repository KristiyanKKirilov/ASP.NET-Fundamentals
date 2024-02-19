using System.ComponentModel.DataAnnotations;

namespace TextSplitter.Models
{
	public class TextViewModel
	{
		/// <summary>
		/// Text content
		/// </summary>
		[Required(ErrorMessage = "The Text field is required")]
		[StringLength(30, MinimumLength = 2, ErrorMessage = "Text should be between 2 and 30 symbols")]
		public string Text { get; set; } = string.Empty;
		/// <summary>
		/// Splitted text content
		/// </summary>
		public string SplitText {  get; set; } = string.Empty;	

	}
}
