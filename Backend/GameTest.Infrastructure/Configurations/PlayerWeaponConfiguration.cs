using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerWeaponConfiguration : IEntityTypeConfiguration<PlayerWeapon>
    {
        public void Configure(EntityTypeBuilder<PlayerWeapon> builder)
        {
            builder.HasKey(pw => pw.Id);

            builder.Property(pw => pw.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(pw => pw.Player)
                .WithMany(p => p.Weapons)
                .HasForeignKey(pw => pw.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pw => pw.Weapon)
                .WithMany()
                .HasForeignKey(pw => pw.WeaponId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
