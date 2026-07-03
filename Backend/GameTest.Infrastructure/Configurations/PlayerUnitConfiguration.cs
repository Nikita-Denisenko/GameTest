using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerUnitConfiguration : IEntityTypeConfiguration<PlayerUnit>
    {
        public void Configure(EntityTypeBuilder<PlayerUnit> builder)
        {
            builder.HasKey(pu => pu.Id);

            builder.Property(pu => pu.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(pu => pu.Player)
                .WithMany(p => p.Units)
                .HasForeignKey(pu => pu.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pu => pu.Unit)
                .WithMany()
                .HasForeignKey(pu => pu.UnitId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
