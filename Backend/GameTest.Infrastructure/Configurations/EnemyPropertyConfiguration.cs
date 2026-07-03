using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class EnemyPropertyConfiguration : IEntityTypeConfiguration<EnemyProperty>
    {
        public void Configure(EntityTypeBuilder<EnemyProperty> builder)
        {
            builder.HasKey(ep => ep.Id);

            builder.Property(ep => ep.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(ep => ep.Enemy)
                .WithMany(e => e.Properties)
                .HasForeignKey(ep => ep.EnemyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ep => ep.Stat)
                .WithMany()
                .HasForeignKey(ep => ep.StatId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
