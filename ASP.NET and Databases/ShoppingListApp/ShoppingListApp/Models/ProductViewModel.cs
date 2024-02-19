using ShoppingListApp.Constants;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models
{
	public class ProductViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Field {0} is required")]
		[Display(Name = "Product Name")]
		[StringLength(Conditions.MaxNameLength, MinimumLength = Conditions.MinNameLength, ErrorMessage = "Field {0} must be between {2} amd {1} symbols")]
		public string Name { get; set; } = string.Empty;

	}
}
