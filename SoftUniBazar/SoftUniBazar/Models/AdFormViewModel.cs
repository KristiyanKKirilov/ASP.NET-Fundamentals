using SoftUniBazar.Data.Models;
using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Data.Models.ErrorMessages;
using static SoftUniBazar.Data.Models.DataConstants.Ad;

namespace SoftUniBazar.Models
{
	public class AdFormViewModel
	{

		/// <summary>
		/// Ad name
		/// </summary>		
		[Required(ErrorMessage = RequiredError)]
		[StringLength(NameMaxLength,
			MinimumLength = NameMinLength,
			ErrorMessage = StringLengthError)]
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Ad description
		/// </summary>	
		[Required(ErrorMessage = RequiredError)]
		[StringLength(DescriptionMaxLength,
			MinimumLength = DescriptionMinLength,
			ErrorMessage = StringLengthError)]
		public string Description { get; set; } = string.Empty;

		/// <summary>
		/// Ad price
		/// </summary>	
		[Required(ErrorMessage = RequiredError)]		
		public decimal Price { get; set; }

		/// <summary>
		/// Ad image url
		/// </summary>
		[Required(ErrorMessage = RequiredError)]
		public string ImageUrl { get; set; } = string.Empty;

		/// <summary>
		/// Ad category identifier
		/// </summary>
		[Required(ErrorMessage = RequiredError)]
		public int CategoryId { get; set; } 
		public IEnumerable<Category> Categories { get; set; } = new List<Category>();
	}
}
