using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Type = Homies.Data.Models.Type;

namespace Homies.Data.Configuration
{
    public class TypeConfiguration : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> builder)
        {
            builder.HasData(SeedTypes());
        }

        private Type[] SeedTypes()
        {
            return new Type[]
                {
                    new Type()
                    {
                        Id = 1,
                        Name = "Animals"
                    },
                    new Type()
                    {
                        Id = 2,
                        Name = "Fun"
                    },
                    new Type()
                    {
                        Id = 3,
                        Name = "Discussion"
                    },
                    new Type()
                    {
                        Id = 4,
                        Name = "Work"
                    }
                };
        }
    }
}
