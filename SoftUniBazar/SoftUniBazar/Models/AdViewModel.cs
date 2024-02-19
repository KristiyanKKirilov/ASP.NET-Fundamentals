using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Models
{
	public class AdViewModel
	{
		/// <summary>
		/// Ad identifier
		/// </summary>		
		public int Id { get; set; }

		/// <summary>
		/// Ad name
		/// </summary>		
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Ad description
		/// </summary>	
		public string Description { get; set; } = string.Empty;

		/// <summary>
		/// Ad price
		/// </summary>		
		public decimal Price { get; set; }

		/// <summary>
		/// Ad owner identifier
		/// </summary>		
		public string Owner { get; set; } = string.Empty;

		/// <summary>
		/// Ad date of creation
		/// </summary>		
		public string CreatedOn { get; set; } = string.Empty;

		/// <summary>
		/// Ad image url
		/// </summary>
		public string ImageUrl { get; set; } = string.Empty;

		/// <summary>
		/// Ad category name
		/// </summary>
		public string Category { get; set; } = string.Empty;
		
	}
}
