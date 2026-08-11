using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class CatPropertyConfiguration : IEntityTypeConfiguration<CatProperty>
    {
        public void Configure(EntityTypeBuilder<CatProperty> builder)
        {
            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(cp => cp.Stat)
                .WithMany()
                .HasForeignKey(cp => cp.StatId);

            builder.HasOne(cp => cp.Cat)
                .WithMany(c => c.Properties)
                .HasForeignKey(cp => cp.CatId);
        }
    }
}
