using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerUnitPropertyConfiguration : IEntityTypeConfiguration<PlayerUnitProperty>
    {
        public void Configure(EntityTypeBuilder<PlayerUnitProperty> builder)
        {
            builder.HasKey(pup => pup.Id);

            builder.Property(pup => pup.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(pup => pup.PlayerUnit)
                .WithMany(pu => pu.Properties)
                .HasForeignKey(pup => pup.PlayerUnitId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pup => pup.UnitProperty)
                .WithMany()
                .HasForeignKey(pup => pup.UnitPropertyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
