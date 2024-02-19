using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Constants;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Data.Models
{
	[Comment("Shopping List Product")]
	public class Product
	{
		[Key]
		[Comment("Product Identifier")]
		public int Id { get; set; }
		[Required]
		[MaxLength(Conditions.MaxNameLength)]
		[Comment("Product Name")]
		public string Name { get; set; } = string.Empty;
		public List<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
	}
}
