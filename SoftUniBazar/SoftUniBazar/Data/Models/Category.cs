using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Data.Models.DataConstants.Category;

namespace SoftUniBazar.Data.Models
{
	public class Category
	{
		[Key]
		[Comment("Category identifier")]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		[Comment("Category name")]
		public string Name { get; set; } = string.Empty;

		public IList<Ad> Ads { get; set; } = new List<Ad>();	
	}
}

