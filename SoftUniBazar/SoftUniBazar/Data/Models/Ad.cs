using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUniBazar.Data.Models.DataConstants.Ad;
namespace SoftUniBazar.Data.Models
{
	public class Ad
	{
		[Key]
		[Comment("Ad identifier")]
        public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		[Comment("Ad name")]
        public string Name { get; set; } = string.Empty;

		[Required]
		[MaxLength(DescriptionMaxLength)]
		[Comment("Ad description")]
		public string Description { get; set; } = string.Empty;

        [Required]
		[Comment("Ad price")]
        public decimal Price { get; set; }

        [Required]
		[Comment("Ad owner identifier")]
        public string OwnerId { get; set; } = string.Empty;
		[Required]
		[ForeignKey(nameof(OwnerId))]
		public IdentityUser Owner { get; set; } = null!;

		[Required]
		[Comment("Ad image url")]
		public string ImageUrl { get; set; } = string.Empty;

        [Required]
		[Comment("Ad date of creation")]
        public DateTime CreatedOn { get; set; }

        [Required]
		[Comment("Ad category identifier")]
        public int CategoryId { get; set; }
		[Required]
		[ForeignKey(nameof(CategoryId))]
		public Category Category { get; set; } = null!;

		public IList<AdBuyer> AdsBuyers { get; set; } = new List<AdBuyer>();

    }
}

