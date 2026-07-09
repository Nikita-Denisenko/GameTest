using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.Navigation(p => p.Items)
               .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Navigation(p => p.Weapons)
               .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Navigation(p => p.Units)
               .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
