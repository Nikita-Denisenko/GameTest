using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class UnitPropertyConfiguration : IEntityTypeConfiguration<UnitProperty>
    {
        public void Configure(EntityTypeBuilder<UnitProperty> builder)
        {
            builder.HasKey(up => up.Id);

            builder.Property(up => up.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(up => up.Unit)
                .WithMany(u => u.Properties)
                .HasForeignKey(up => up.UnitId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(up => up.Stat)
                .WithMany()
                .HasForeignKey(up => up.StatId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsMany(wp => wp.Levels, levels =>
            {
                levels.WithOwner().HasForeignKey("UnitPropertyId");

                levels.HasKey("UnitPropertyId", "Level");

                levels.Property(l => l.Level)
                    .IsRequired()
                    .HasColumnName("Level");

                levels.Property(l => l.Value)
                    .IsRequired()
                    .HasColumnName("Value");
            });
        }
    }
}
