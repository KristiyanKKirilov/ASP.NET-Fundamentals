using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Data.Models
{
	[Comment("Product Note")]
	public class ProductNote
	{
		[Key]
		[Comment("Note Identifier")]
		public int Id { get; set; }
		[Required]
		[MaxLength(Conditions.MaxContentLength)]
		[Comment("Note Content")]
		public string Content { get; set; } = string.Empty;
		[Required]
		[Comment("Product Identifier")]
		public int ProductId {  get; set; }
		[ForeignKey(nameof(ProductId))]
		public Product Product { get; set; } = null!;
	}
}