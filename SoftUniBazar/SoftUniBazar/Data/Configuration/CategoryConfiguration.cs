using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftUniBazar.Data.Models;
using System.Xml.Linq;

namespace SoftUniBazar.Data.Configuration
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder
				.HasData(SeedCategories());


		}

		private Category[] SeedCategories()
		{
			return new Category[]
			{
				new Category()
				{
					Id = 1,
					Name = "Books"
				},
				new Category()
				{
					Id = 2,
					Name = "Cars"
				},
				new Category()
				{
					Id = 3,
					Name = "Clothes"
				},
				new Category()
				{
					Id = 4,
					Name = "Home"
				},
				new Category()
				{
					Id = 5,
					Name = "Technology"
				}
			};
		}

	}
}
