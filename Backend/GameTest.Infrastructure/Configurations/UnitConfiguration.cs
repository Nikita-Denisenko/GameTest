using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(u => u.StartWeapon)
                .WithMany()
                .HasForeignKey(u => u.StartWeaponId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(u => u.PassiveAbility, pa =>
            {
                pa.Property(p => p.Name)
                    .IsRequired()
                    .HasColumnName("PassiveAbilityName");

                pa.Property(p => p.Description)
                    .IsRequired()
                    .HasColumnName("PassiveAbilityDescription");

                pa.Property(p => p.Bonus)
                    .IsRequired()
                    .HasColumnName("PassiveAbilityBonus");

                pa.Property(p => p.Type)
                    .IsRequired()
                    .HasColumnName("PassiveAbilityType");
            });
        }
    }
}
