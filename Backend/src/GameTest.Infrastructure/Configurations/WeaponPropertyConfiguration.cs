using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class WeaponPropertyConfiguration : IEntityTypeConfiguration<WeaponProperty>
    {
        public void Configure(EntityTypeBuilder<WeaponProperty> builder)
        {
            builder.HasKey(wp => wp.Id);

            builder.Property(wp => wp.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(wp => wp.Weapon)
                .WithMany(w => w.Properties)
                .HasForeignKey(wp => wp.WeaponId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(wp => wp.Stat)
                .WithMany()
                .HasForeignKey(wp => wp.StatId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsMany(wp => wp.Levels, levels =>
            {
                levels.WithOwner().HasForeignKey("WeaponPropertyId");

                levels.HasKey("WeaponPropertyId", "Level");

                levels.Property(l => l.Level)
                    .IsRequired()
                    .HasColumnName("Level");

                levels.Property(l => l.Value)
                    .IsRequired()
                    .HasColumnName("Value");

                levels.Property(l => l.Price)
                    .IsRequired()
                    .HasColumnName("Price");
            });

            builder.Navigation(wp => wp.Levels)
               .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
