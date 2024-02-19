using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.Models.DataConstants.Category;

namespace SeminarHub.Data.Models
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

        public IList<Category> Categories { get; set; } = new List<Category>();
    }
}


