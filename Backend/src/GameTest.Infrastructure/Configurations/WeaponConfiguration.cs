using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class WeaponConfiguration : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Id)
                .ValueGeneratedOnAdd();

            builder.OwnsMany(w => w.TemporaryUpgradeLevels, levels =>
            {
                levels.WithOwner()
                    .HasForeignKey("WeaponId");

                levels.HasKey("WeaponId", "Level");

                levels.Property(l => l.Level)
                    .IsRequired()
                    .HasColumnName("Level");

                levels.Property(l => l.Price)
                    .IsRequired()
                    .HasColumnName("Price");
            });

            builder.Navigation(w => w.Properties)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            builder.Navigation(w => w.TemporaryUpgradeLevels)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
