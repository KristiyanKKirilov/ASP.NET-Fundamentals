using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Models
{
	public class AdBuyer
	{
		[Required]
		[Comment("Buyer identifier")]
		public string BuyerId { get; set; } = string.Empty;
		[ForeignKey(nameof(BuyerId))]
		public IdentityUser Buyer { get; set; } = null!;

        [Required]
		[Comment("Ad identifier")]
        public int AdId { get; set; }
		[ForeignKey(nameof(AdId))]
		public Ad Ad { get; set; } = null!;

    }
}

//•	BuyerId – a  string, Primary Key, foreign key (required)
//•	Buyer – IdentityUser
//•	AdId – an integer, Primary Key, foreign key (required)
//•	Ad – Ad
