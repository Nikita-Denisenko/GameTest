using GameTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTest.Infrastructure.Configurations
{
    public class CatStatConfiguration : IEntityTypeConfiguration<CatStat>
    {
        public void Configure(EntityTypeBuilder<CatStat> builder)
        {
            builder.HasKey(cs => cs.Id);

            builder.Property(cs => cs.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
