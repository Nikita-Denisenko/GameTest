using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerWeaponPropertyConfiguration : IEntityTypeConfiguration<PlayerWeaponProperty>
    {
        public void Configure(EntityTypeBuilder<PlayerWeaponProperty> builder)
        {
            builder.HasKey(pwp => pwp.Id);

            builder.Property(pwp => pwp.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(pwp => pwp.PlayerWeapon)
                .WithMany(pw => pw.Properties)
                .HasForeignKey(pwp => pwp.PlayerWeaponId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pwp => pwp.WeaponProperty)
                .WithMany()
                .HasForeignKey(pwp => pwp.WeaponPropertyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
