using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class PlayerItemConfiguration : IEntityTypeConfiguration<PlayerItem>
    {
        public void Configure(EntityTypeBuilder<PlayerItem> builder)
        {
            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(pi => pi.Player)
                .WithMany(p => p.Items)
                .HasForeignKey(pi => pi.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.Item)
                .WithMany()
                .HasForeignKey(pi => pi.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
